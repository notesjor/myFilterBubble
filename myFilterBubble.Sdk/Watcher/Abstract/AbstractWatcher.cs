using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    protected abstract void ParseFile(string filePath, string modelPath);

    private string GetModelPath(string watchPath)
    {
      watchPath = watchPath.Replace("/", @"\").Replace("\\", @"\").Replace(_path2Watch, string.Empty);
      while (watchPath.StartsWith(@"\"))
        watchPath = watchPath.Substring(1);

      return Path.Combine(_path2Model, watchPath);
    }
  }
}
