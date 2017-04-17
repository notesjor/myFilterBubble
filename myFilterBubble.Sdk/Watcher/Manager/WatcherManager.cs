using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using myFilterBubble.Sdk.Watcher.Abstract;

namespace myFilterBubble.Sdk.Watcher.Manager
{
  public class WatcherManager
  {
    public WatcherManager() { }

    public WatcherManager(string path) => Load(path);

    private List<AbstractWatcher> _watchers = new List<AbstractWatcher>();

    public void Add(AbstractWatcher watcher) => _watchers.Add(watcher);

    public IEnumerable<AbstractWatcher> Watchers => _watchers;

    public void Remove(AbstractWatcher watcher) => _watchers.Remove(watcher);

    public void Load(string path) => _watchers = Serializer.Deserialize<List<AbstractWatcher>>(path);

    public void Save(string path) => Serializer.Serialize(_watchers, path, true);
  }
}
