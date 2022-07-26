#region

using System;
using System.Collections.Generic;
using System.IO;
using myFilterBubble.Sdk.Features;

#endregion

namespace myFilterBubble.Sdk
{
  [Serializable]
  public class FilterBubble
  {
    private readonly List<string> _sources = new List<string>();

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

    private FilterBubble()
    {
    }

    public string Displayname { get; set; }
    public Guid Guid { get; set; }
    public string IndexPath { get; set; }
    public IEnumerable<string> Sources => _sources;

    public void Add(string directory)
    {
      _sources.Add(directory);
    }

    public FilterBubbleIndexBuilder GetIndexBuilder() => new FilterBubbleIndexBuilder(this);

    public FilterBubbleIndexWatchdog GetIndexWatchdog() => new FilterBubbleIndexWatchdog(this);

    public FilterBubbleSearchIndex GetSearchIndex() => new FilterBubbleSearchIndex(this);

    public void Remove(string directory)
    {
      _sources.Remove(directory);
    }
  }
}