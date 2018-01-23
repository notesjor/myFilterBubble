using System.Collections.Generic;
using System.Linq;

namespace myFilterBubble.Sdk.FileFormat.Abstract {
  public abstract class AbstractFileFormat
  {
    public bool MatchesFileExtension(string path)
    {
      path = path.ToLower();
      return FileExtensions.Any(x => path.EndsWith(x));
    }

    protected internal abstract string[] FileExtensions { get; }

    public abstract void ReadFile(
      string filePath,
      out List<Dictionary<string, object>> pages,
      out Dictionary<string, object> cmeta);
  }
}