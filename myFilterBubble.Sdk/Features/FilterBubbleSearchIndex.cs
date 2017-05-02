using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Core.DocumentProcessing.Tagger.Special;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace myFilterBubble.Sdk
{
  public class FilterBubbleSearchIndex
  {
    private readonly FilterBubble _filterBubble;
    private Dictionary<string, HashSet<string>> _contains;
    private Dictionary<string, Dictionary<string, double>> _vector;

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
            lock (@lock)
              _contains.Add(Path.GetFileNameWithoutExtension(file), content);
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
            var content = Serializer.Deserialize<KeyValuePair<string, double>[]>(file).ToDictionary(x => x.Key, x => x.Value);
            lock (@lock)
              _vector.Add(Path.GetFileNameWithoutExtension(file), content);
          }
          catch
          {
            // ignore
          }
        });
    }

    public Dictionary<string, double> SearchContains(string query)
    {
      var split = query.Split(new[] {" ", ",", ".", ":", ";", "-"}, StringSplitOptions.RemoveEmptyEntries);
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
          
          lock (@lock)
            res.Add(doc.Key, count);
        });

      return res;
    }

    public Dictionary<string, double> SearchVector(string query)
    {
      throw new NotImplementedException();
      var dic = DocumentInMemoryAnalytics.Frequency(query);

    }

    public Dictionary<string, double> CompareVector(string document)
    {
      if (!_vector.ContainsKey(document))
        return null;
      throw new NotImplementedException();
      var doc = _vector[document];

    }

    public AbstractCorpusAdapter Load(string fileName)
    {
      return CorpusAdapterWriteDirect.Create(Path.Combine(_filterBubble.IndexPath, fileName));
    }
  }
}