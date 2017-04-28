using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using myFilterBubble.Sdk.Repository;

namespace myFilterBubble.Sdk {
  public class FilterBubbleIndexBuilder
  {
    private readonly FilterBubble _filterBubble;

    public FilterBubbleIndexBuilder(FilterBubble filterBubble) { _filterBubble = filterBubble; }

    public void Parse(string path, bool overwrite)
    {
      var model = GetIndexPath(path);
      if (File.Exists(model) && !overwrite)
        return;

      ParseFile(path, model);
    }

    private string GetIndexPath(string path)
    {
      path = path.Replace("/", @"\").Replace("\\", @"\").Replace(_filterBubble.IndexPath, string.Empty);
      while (path.StartsWith(@"\"))
        path = path.Substring(1);

      var res = Path.Combine(_filterBubble.IndexPath, path);
      var dir = Path.GetDirectoryName(res);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      res = Path.Combine(dir, Path.GetFileNameWithoutExtension(res) + ".cec6");

      return res;
    }

    private void ParseFile(string filePath, string modelPath)
    {
      List<Dictionary<string, object>> pages;
      Dictionary<string, object> cmeta;

      var provider = FileFormatRepository.GetMatchingProvider(filePath);
      provider.ReadFile(filePath, out pages, out cmeta);

      var cleanup = new StandardCleanup();
      foreach (var page in pages)
        cleanup.Input.Enqueue(page);

      cleanup.Execute();

      var tagger = new RawTextTagger
      {
        Input = cleanup.Output,
        CorpusBuilder = new CorpusBuilderWriteDirect()
      };
      tagger.Execute();

      var model = tagger.Output.FirstOrDefault();
      if (model == null)
        return;

      foreach (var m in cmeta)
        model.SetCorpusMetadata(m.Key, m.Value);

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

      var model = GetVectors(dic.Keys.ToArray());
      return dic.Where(x => model.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => (x.Value / count) * model[x.Key]);
    }

    private Dictionary<string, double> GetVectors(IEnumerable<string> words) => words.Where(entry => _qmodel.ContainsKey(entry)).ToDictionary(entry => entry, entry => _qmodel[entry]);
  }
}