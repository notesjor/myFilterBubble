#region

using System.Collections.Generic;
using System.IO;

#endregion

namespace myFilterBubble.Sdk.Features
{
  public class FilterBubbleIndexWatchdog
  {
    private readonly FilterBubble _filterBubble;
    private List<FileSystemWatcher> _watches;

    public FilterBubbleIndexWatchdog(FilterBubble filterBubble)
    {
      _filterBubble = filterBubble;

      _watches = new List<FileSystemWatcher>();
      foreach (var source in filterBubble.Sources)
      {
        var w = new FileSystemWatcher
        {
          Path = source,
          Filter = "*.*",
          IncludeSubdirectories = true
        };

        w.Changed += WatcherOnChanged;
        w.Created += WatcherOnCreated;
        w.Deleted += WatcherOnDeleted;
        w.Renamed += WatcherOnRenamed;

        w.EnableRaisingEvents = true;
      }
    }

    private void WatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Changed)
        return;

      try
      {
        // ToDo: File.Delete(GetModelPath(fileSystemEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }

      // ToDo: Parse(fileSystemEventArgs.FullPath, true);
    }

    private void WatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Created)
        return;

      // ToDo: Parse(fileSystemEventArgs.FullPath, true);
    }

    private void WatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
      if (fileSystemEventArgs.ChangeType != WatcherChangeTypes.Deleted)
        return;

      try
      {
        // ToDo: File.Delete(GetModelPath(fileSystemEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }
    }

    private void WatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
    {
      if (renamedEventArgs.ChangeType != WatcherChangeTypes.Renamed)
        return;

      try
      {
        // ToDo: File.Move(GetModelPath(renamedEventArgs.OldFullPath), GetModelPath(renamedEventArgs.FullPath));
      }
      catch
      {
        // ignore
      }
    }
  }
}