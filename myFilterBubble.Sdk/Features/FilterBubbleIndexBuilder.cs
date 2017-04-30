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

namespace myFilterBubble.Sdk {
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
      var model = tagger.Output.FirstOrDefault();
      if (model == null || model.CountDocuments == 0 || model.CountToken == 0)
        return;

      // POST-PRODUCTION
      foreach (var m in cmeta)
        model.SetCorpusMetadata(m.Key, m.Value);

      // SAVE MODEL
      model.Save(modelPath, false);
      Serializer.Serialize(new HashSet<string>(model.GetLayers("Wort").First().Values), modelPath + ".list", false);
      Serializer.Serialize(ContextToVec(model).ToArray(), modelPath + ".vecs", false);
    }

    private Dictionary<string, double> ContextToVec(AbstractCorpusAdapter corpus)
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

      var languageVectors = LanguageVectorModelRepository.GetModel((string) corpus.GetCorpusMetadata("LANGUAGE"));
      var model = GetVectors(languageVectors, dic.Keys.ToArray());
      return dic.Where(x => model.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => (x.Value / count) * model[x.Key]);
    }

    private Dictionary<string, double> GetVectors(Dictionary<string, double> languageVectors, IEnumerable<string> words) 
      => words.Where(languageVectors.ContainsKey).ToDictionary(entry => entry, entry => languageVectors[entry]);
  }
}