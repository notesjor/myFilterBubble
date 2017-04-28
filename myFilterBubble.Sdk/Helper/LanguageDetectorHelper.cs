using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFilterBubble.Sdk.Helper
{
  public static class LanguageDetectorHelper
  {
    public static string DetectLanguage(this Dictionary<string, object> rawDocument)
    {
      if (!rawDocument.ContainsKey("Text"))
        return null;

      // TODO
      return "de-DE";
    }
  }
}
