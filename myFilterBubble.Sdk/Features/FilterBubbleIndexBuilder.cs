using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using myFilterBubble.Sdk.Helper;
using myFilterBubble.Sdk.Repository;

namespace myFilterBubble.Sdk.Features
{
  public class FilterBubbleIndexBuilder
  {
    private readonly FilterBubble _filterBubble;

    public FilterBubbleIndexBuilder(FilterBubble filterBubble) { _filterBubble = filterBubble; }

    public IEnumerable<string> FilesTotal
      => new HashSet<string>(from source in _filterBubble.Sources
                             from filter in FileFormatRepository.GetFileFilterArray()
                             from file in Directory.GetFiles(source, filter, SearchOption.AllDirectories)
                             select file);

    public Dictionary<string, string> FilesIndexed
    {
      get
      {
        var res = new Dictionary<string, string>();
        foreach (var x in FilesTotal)
        {
          var y = GetIndexPath(x);
          if (File.Exists(y))
            res.Add(x, y);
        }
        return res;
      }
    }

    public IEnumerable<string> FilesNew => FilesTotal.Where(x => !File.Exists(GetIndexPath(x)));

    public void Parse(string path, bool overwrite)
    {
      var model = GetIndexPath(path);
      if (File.Exists(model) && !overwrite)
        return;

      ParseFile(path, model);
    }

    private string GetIndexPath(string path)
    {
      if (!Directory.Exists(_filterBubble.IndexPath))
        Directory.CreateDirectory(_filterBubble.IndexPath);

      return Path.Combine(_filterBubble.IndexPath, Path.GetFileNameWithoutExtension(path) + ".cec6");
    }

    private void ParseFile(string filePath, string modelPath)
    {
      List<Dictionary<string, object>> pages;
      Dictionary<string, object> cmeta;

      // READ FILE
      var provider = FileFormatRepository.GetMatchingProvider(filePath);
      provider.ReadFile(filePath, out pages, out cmeta);

      // DETECT LANGUAGE
      cmeta.Add("LANGUAGE", LanguageDetectorHelper.DetectLanguage(ref pages));

      AbstractCorpusAdapter corpus;
      HashSet<string> list;
      Dictionary<string, double> vecs;
      ExecuteProcessingWorkflow(out corpus, out list, out vecs, pages, cmeta);

      if (corpus == null)
        return;

      // SAVE MODEL
      corpus.Save(modelPath, false);
      Serializer.Serialize(list, modelPath + ".list", false);
      Serializer.Serialize(vecs.ToArray(), modelPath + ".vecs", false);
    }

    public static void InlineCorpus(
      ref string inlineText,
      out AbstractCorpusAdapter corpus)
    {
      HashSet<string> list;
      Dictionary<string, double> vecs;
      Inline(ref inlineText, out corpus, out list, out vecs);
    }

    public static void InlineList(
      ref string inlineText,
      out HashSet<string> list)
    {
      AbstractCorpusAdapter corpus;
      Dictionary<string, double> vecs;
      Inline(ref inlineText, out corpus, out list, out vecs);
    }

    public static void InlineVector(
      ref string inlineText,
      out Dictionary<string, double> vecs)
    {
      AbstractCorpusAdapter corpus;
      HashSet<string> list;
      Inline(ref inlineText, out corpus, out list, out vecs);
    }

    public static void Inline(ref string inlineText, out AbstractCorpusAdapter corpus, out HashSet<string> list, out Dictionary<string, double> vecs)
    {
      var pages = new List<Dictionary<string, object>>
      {
        new Dictionary<string, object>
        {
          {"Text", inlineText},
          { "PAGE", 1}
        }
      };

      // DETECT LANGUAGE
      var cmeta = new Dictionary<string, object> { { "LANGUAGE", LanguageDetectorHelper.DetectLanguage(ref pages) } };
      ExecuteProcessingWorkflow(out corpus, out list, out vecs, pages, cmeta);
    }

    private static void ExecuteProcessingWorkflow(
      out AbstractCorpusAdapter corpus,
      out HashSet<string> list,
      out Dictionary<string, double> vecs,
      IEnumerable<Dictionary<string, object>> pages,
      Dictionary<string, object> cmeta)
    {
      // CLEAN TEXT
      var cleanup = new StandardCleanup();
      foreach (var page in pages)
        cleanup.Input.Enqueue(page);
      cleanup.Execute();

      // PARSE TEXT
      var tagger = new RawTextTagger
      {
        Input = cleanup.Output,
        CorpusBuilder = new CorpusBuilderWriteDirect()
      };
      tagger.Execute();

      // GET CORPUS-MODEL
      corpus = tagger.Output.FirstOrDefault();
      if (corpus == null || corpus.CountDocuments == 0 || corpus.CountToken == 0)
      {
        corpus = null;
        list = null;
        vecs = null;
        return;
      }

      // POST-PRODUCTION
      foreach (var m in cmeta)
        corpus.SetCorpusMetadata(m.Key, m.Value);

      // SAVE MODEL
      list = new HashSet<string>(corpus.GetLayers("Wort").First().Values);
      vecs = ContextToVec(corpus);
    }

    private static Dictionary<string, double> ContextToVec(AbstractCorpusAdapter corpus)
    {
      var layer = corpus?.GetLayers("Wort")?.First();
      var doc = layer?[layer.DocumentGuids.First()];
      if (doc == null)
        return null;

      var count = 0.0;
      var dic = new Dictionary<string, double>();

      foreach (var s in doc)
      {
        count += s.Length;
        foreach (var w in s)
        {
          var key = layer[w];
          if (dic.ContainsKey(key))
            dic[key]++;
          else
            dic.Add(key, 1);
        }
      }

      var min = (int)(1 + Math.Log(count / 500));
      dic = dic.Where(x => x.Value > min).ToDictionary(x => x.Key, x => x.Value);

      var languageVectors = LanguageVectorModelRepository.GetModel((string)corpus.GetCorpusMetadata("LANGUAGE"));
      var model = GetVectors(languageVectors, dic.Keys.ToArray());
      return dic.Where(x => model.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => (x.Value / count) * model[x.Key]);
    }

    private static Dictionary<string, double> GetVectors(Dictionary<string, double> languageVectors, IEnumerable<string> words)
      => words.Where(languageVectors.ContainsKey).ToDictionary(entry => entry, entry => languageVectors[entry]);
  }
}