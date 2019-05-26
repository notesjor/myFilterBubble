using System.Linq;
using myFilterBubble.Sdk.FileFormat;
using myFilterBubble.Sdk.FileFormat.Abstract;

namespace myFilterBubble.Sdk.Repository
{
  public static class FileFormatRepository
  {
    private static string[] _fileFilterArray;

    private static readonly AbstractFileFormat[] _formats =
    {
      new FileFormatPdf()
    };

    public static string[] GetFileFilterArray()
    {
      if (_fileFilterArray != null)
        return _fileFilterArray;

      _fileFilterArray = (from format in _formats from extension in format.FileExtensions select $"*{extension}")
       .ToArray();
      return _fileFilterArray;
    }

    public static AbstractFileFormat GetMatchingProvider(string path)
    {
      return _formats.FirstOrDefault(x => x.MatchesFileExtension(path));
    }
  }
}