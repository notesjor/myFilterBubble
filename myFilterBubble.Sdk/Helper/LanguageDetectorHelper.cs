#region

using System.Collections.Generic;

#endregion

namespace myFilterBubble.Sdk.Helper
{
  public static class LanguageDetectorHelper
  {
    public static string DetectLanguage(ref List<Dictionary<string, object>> rawDocument) =>
      /*
      if (!rawDocument.ContainsKey("Text"))
        return null;
      */
      // TODO
      "de-DE";
  }
}