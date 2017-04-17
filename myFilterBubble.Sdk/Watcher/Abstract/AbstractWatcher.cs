using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;

namespace myFilterBubble.Sdk.Watcher.Abstract
{
  [Serializable]
  public abstract class AbstractWatcher
  {
    private string _path2Watch;
    private string _path2Model;
    private string _bubbleId;

    [NonSerialized]
    private FileSystemWatcher _watcher;

    private AbstractWatcher() => Initialize();

    protected AbstractWatcher(string path2Watch)
    {
      _path2Watch = path2Watch.Replace("/", @"\").Replace("\\", @"\");
      _path2Model = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "myFilterBubble",
        _bubbleId);
      _bubbleId = Guid.NewGuid().ToString("N");

      Initialize();
    }

    public abstract string Filter { get; }

    public string Path2Watch => _path2Watch;

    public string Path2Model => _path2Model;

    public IEnumerable<string> AllModelFiles => Directory.GetFiles(_path2Model, "*.mfb", SearchOption.AllDirectories);

    public IEnumerable<string> AllSourceFiles => Directory.GetFiles(_path2Watch, Filter, SearchOption.AllDirectories);

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

      ParseFile(fileSystemEventArgs.FullPath, GetModelPath(fileSystemEventArgs.FullPath));
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

      ParseFile(fileSystemEventArgs.FullPath, GetModelPath(fileSystemEventArgs.FullPath));
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
    }

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

      return res;
    }
  }
}
