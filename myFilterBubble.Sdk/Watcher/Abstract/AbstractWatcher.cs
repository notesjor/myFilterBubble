using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Core.DocumentProcessing.Tagger.Special;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;

namespace myFilterBubble.Sdk.Watcher.Abstract
{
  [Serializable]
  public abstract class AbstractWatcher
  {
    private static Dictionary<string, double> _qmodel;

    private string _path2Watch;
    private string _path2Model;
    private string _bubbleId;

    [NonSerialized]
    private FileSystemWatcher _watcher;
    
    private AbstractWatcher() => Initialize();

    protected AbstractWatcher(string path2Watch): this(path2Watch, Guid.NewGuid().ToString("N")) { }

    protected AbstractWatcher(string path2Watch, string bubbleId)
    {
      _bubbleId = bubbleId;

      _path2Watch = path2Watch.Replace("/", @"\").Replace("\\", @"\");
      _path2Model = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "myFilterBubble",
        _bubbleId);

      Initialize();
    }

    public abstract string Filter { get; }

    public string Path2Watch => _path2Watch;

    public string Path2Model => _path2Model;

    public IEnumerable<string> AllModelFiles => Directory.GetFiles(_path2Model, "*.cec6", SearchOption.AllDirectories);

    public IEnumerable<string> AllSourceFiles => Directory.GetFiles(_path2Watch, Filter, SearchOption.AllDirectories);

    public void Parse(string path, bool overwrite)
    {
      var model = GetModelPath(path);
      if (File.Exists(model) && !overwrite)
        return;

      ParseFile(path, model);
    }

    private void Initialize()
    {
      _watcher = new FileSystemWatcher
      {
        Path = _path2Watch,
        Filter = Filter,
        IncludeSubdirectories = true
      };

      _watcher.Changed += WatcherOnChanged;
      _watcher.Created += WatcherOnCreated;
      _watcher.Deleted += WatcherOnDeleted;
      _watcher.Renamed += WatcherOnRenamed;

      _watcher.EnableRaisingEvents = true;

      if (_qmodel != null)
        return;

      _qmodel = File.ReadAllLines("Model/de-DE/qsearch.csv")
                    .Select(line => line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries))
                    .ToDictionary(split => split[0], split => double.Parse(split[1]));
    }

    private void WatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
    {
      if (renamedEventArgs.ChangeType != WatcherChangeTypes.Renamed)
        return;

      try
      {
        File.Move(GetModelPath(renamedEventArgs.OldFullPath), GetModelPath(renamedEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }
    }

    private void WatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Deleted)
        return;

      try
      {
        File.Delete(GetModelPath(fileSystemEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }
    }

    private void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Created)
        return;

      Parse(fileSystemEventArgs.FullPath, true);
    }

    private void WatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Changed)
        return;

      try
      {
        File.Delete(GetModelPath(fileSystemEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }

      Parse(fileSystemEventArgs.FullPath, true);
    }

    private void ParseFile(string filePath, string modelPath)
    {
      List<Dictionary<string, object>> pages;
      Dictionary<string, object> cmeta;

      ReadFile(filePath, out pages, out cmeta);

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

    protected abstract void ReadFile(string filePath, out List<Dictionary<string, object>> pages, out Dictionary<string, object> cmeta);

    private string GetModelPath(string watchPath)
    {
      watchPath = watchPath.Replace("/", @"\").Replace("\\", @"\").Replace(_path2Watch, string.Empty);
      while (watchPath.StartsWith(@"\"))
        watchPath = watchPath.Substring(1);

      var res = Path.Combine(_path2Model, watchPath);
      var dir = Path.GetDirectoryName(res);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      res = Path.Combine(dir, Path.GetFileNameWithoutExtension(res) + ".cec6");

      return res;
    }
  }
}
