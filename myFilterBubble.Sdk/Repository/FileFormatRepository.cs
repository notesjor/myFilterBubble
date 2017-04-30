﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFilterBubble.Sdk.Repository
{
  public static class FileFormatRepository
  {
    private static string[] _fileFilterArray;

    private static AbstractFileFormat[] _formats = new[]
    {
      new FileFormatPdf()
    };

    public static AbstractFileFormat GetMatchingProvider(string path)
    {
      return _formats.FirstOrDefault(x => x.MatchesFileExtension(path));
    }

    public static string[] GetFileFilterArray()
    {
      if (_fileFilterArray != null)
        return _fileFilterArray;

      _fileFilterArray = (from format in _formats from extension in format.FileExtensions select $"*{extension}").ToArray();
      return _fileFilterArray;
    }
  }
}
