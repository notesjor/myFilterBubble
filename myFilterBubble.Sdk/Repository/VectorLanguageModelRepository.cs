using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myFilterBubble.Sdk.Repository {
  public static class VectorLanguageModelRepository
  {
    public static Dictionary<string, double> GetVectorLanguageModel(string languageCode)
    {
      return File.ReadAllLines($"Model/{languageCode}/qsearch.csv")
                 .Select(line => line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries))
                 .ToDictionary(split => split[0], split => double.Parse(split[1]));
    }
  }
}