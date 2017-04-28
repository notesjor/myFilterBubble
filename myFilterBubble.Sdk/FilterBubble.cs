using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace myFilterBubble.Sdk
{
  [Serializable]
  public class FilterBubble
  {
    private List<AbstractSource> _sources = new List<AbstractSource>();
    public Guid Guid { get; set; }
    public string IndexPath { get; set; }
    public string Displayname { get; set; }
    public IEnumerable<AbstractSource> Sources => _sources;

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
    }

    public void Add(AbstractSource source) => _sources.Add(source);
    public void Remove(AbstractSource source) => _sources.Remove(source);

    public FilterBubbleSearchIndex GetSearchIndex() => new FilterBubbleSearchIndex(this);

    public FilterBubbleIndexBuilder GetIndexBuilder() => new FilterBubbleIndexBuilder(this);

    public FilterBubbleIndexWatchdog GetIndexWatchdog() => new FilterBubbleIndexWatchdog(this);
  }
}
