using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myFilterBubble.Sdk.Repository {
  public static class LanguageVectorModelRepository
  {
    private static Dictionary<string, Dictionary<string, double>> _languageVectorModelCache = new Dictionary<string, Dictionary<string, double>>();
    private static object _languageVectorModelCacheLock = new object();

    public static Dictionary<string, double> GetModel(string languageCode)
    {
      lock (_languageVectorModelCacheLock)
      {
        if (!_languageVectorModelCache.ContainsKey(languageCode))
          _languageVectorModelCache.Add(languageCode, LoadModel(languageCode));
        return _languageVectorModelCache[languageCode];
      }
    }

    private static Dictionary<string, double> LoadModel(string languageCode)
    {
      return File.ReadAllLines($"Model/{languageCode}/qsearch.csv")
                 .Select(line => line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries))
                 .ToDictionary(split => split[0], split => double.Parse(split[1]));
    }
  }
}