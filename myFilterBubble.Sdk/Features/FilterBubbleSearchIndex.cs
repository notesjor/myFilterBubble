#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

#endregion

namespace myFilterBubble.Sdk.Features
{
  public class FilterBubbleSearchIndex
  {
    private readonly Dictionary<string, HashSet<string>> _contains;
    private readonly FilterBubble _filterBubble;
    private readonly Dictionary<string, Dictionary<string, double>> _vector;

    public FilterBubbleSearchIndex(FilterBubble filterBubble)
    {
      _filterBubble = filterBubble;

      var filesList = Directory.GetFiles(_filterBubble.IndexPath, "*.list");
      var filesVec = Directory.GetFiles(_filterBubble.IndexPath, "*.vec");
      var @lock = new object();

      _contains = new Dictionary<string, HashSet<string>>();
      Parallel.ForEach(
                       filesList,
                       file =>
                       {
                         try
                         {
                           var content = Serializer.Deserialize<HashSet<string>>(file);
                           lock (@lock) _contains.Add(Path.GetFileNameWithoutExtension(file), content);
                         }
                         catch
                         {
                           // ignore
                         }
                       });

      _vector = new Dictionary<string, Dictionary<string, double>>();
      Parallel.ForEach(
                       filesVec,
                       file =>
                       {
                         try
                         {
                           var content = Serializer.Deserialize<KeyValuePair<string, double>[]>(file)
                                                   .ToDictionary(x => x.Key, x => x.Value);
                           lock (@lock) _vector.Add(Path.GetFileNameWithoutExtension(file), content);
                         }
                         catch
                         {
                           // ignore
                         }
                       });
    }

    public int IndexedDocumentCount => _vector.Count;

    private double CalculateSimilarity(Dictionary<string, double> vectorA, Dictionary<string, double> vectorB)
    {
      // Funktion stark vereinfacht
      var ab = 0.0d;
      var a2 = 0.0d;
      var b2 = 0.0d;

      foreach (var pair in vectorA)
      {
        if (!vectorB.ContainsKey(pair.Key))
          continue;
        var b = vectorB[pair.Key];

        //var b = vectorB.ContainsKey(pair.Key) ? vectorB[pair.Key] : 0;

        ab += pair.Value * b;
        a2 += pair.Value * pair.Value;
        b2 += b          * b;
      }

      return ab / (Math.Sqrt(a2) * Math.Sqrt(b2));
    }

    public Dictionary<string, double> GetIndexedDocumentVector(string docName) => _vector[docName];

    public AbstractCorpusAdapter Load(string fileName) =>
      CorpusAdapterWriteDirect.Create(Path.Combine(_filterBubble.IndexPath, fileName));

    private static char[] _separator = { ' ', ',', '.', ':', ';', '-' };

    public Dictionary<string, double> SearchContains(string query)
    {
      var split = query.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
      var res = new Dictionary<string, double>();
      var @lock = new object();

      Parallel.ForEach(
                       _contains,
                       doc =>
                       {
                         double count = split.Count(s => doc.Value.Contains(s));
                         if (count < 1)
                           return;
                         count /= split.Length;

                         lock (@lock) res.Add(doc.Key, count);
                       });

      return res;
    }

    public Dictionary<string, double> SearchVector(string fulltext)
    {
      FilterBubbleIndexBuilder.InlineVector(ref fulltext, out var fulltextVecs);

      return fulltextVecs == null ? null : SearchVector(fulltextVecs);
    }

    public Dictionary<string, double> SearchVector(Dictionary<string, double> fulltextVecs)
    {
      var rlo = new object();
      var res = new Dictionary<string, double>();

      Parallel.ForEach(
                       _vector,
                       docs =>
                       {
                         try
                         {
                           var sim = CalculateSimilarity(fulltextVecs, docs.Value);
                           if (double.IsInfinity(sim) || double.IsNaN(sim) || sim < 0.7)
                             return;

                           lock (rlo) res.Add(docs.Key, sim);
                         }
                         catch
                         {
                           // ignore
                         }
                       });

      return res;
    }
  }
}