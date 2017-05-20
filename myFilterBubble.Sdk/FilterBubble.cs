using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using myFilterBubble.Sdk.Repository;

namespace myFilterBubble.Sdk
{
  [Serializable]
  public class FilterBubble
  {
    private List<string> _sources = new List<string>();
    public Guid Guid { get; set; }
    public string IndexPath { get; set; }
    public string Displayname { get; set; }
    public IEnumerable<string> Sources => _sources;

    private FilterBubble() { }

    public FilterBubble(string displayname, Guid? guid = null, string indexPath = null)
    {
      Displayname = displayname;
      Guid = guid ?? Guid.NewGuid();
      IndexPath = string.IsNullOrEmpty(indexPath)
                    ? Path.Combine(
                      Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                      "myFilterBubble",
                      Guid.ToString("N"))
                    : indexPath;
      if (!Directory.Exists(IndexPath))
        Directory.CreateDirectory(IndexPath);
    }

    public void Add(string directory) => _sources.Add(directory);
    public void Remove(string directory) => _sources.Remove(directory);

    public FilterBubbleSearchIndex GetSearchIndex() => new FilterBubbleSearchIndex(this);

    public FilterBubbleIndexBuilder GetIndexBuilder() => new FilterBubbleIndexBuilder(this);

    public FilterBubbleIndexWatchdog GetIndexWatchdog() => new FilterBubbleIndexWatchdog(this);
  }
}
