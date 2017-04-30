using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace myFilterBubble.Sdk
{
  public class FileFormatPdf : AbstractFileFormat
  {
    protected internal override string[] FileExtensions => new[] {".pdf"};

    public override void ReadFile(
      string filePath,
      out List<Dictionary<string, object>> pages,
      out Dictionary<string, object> cmeta)
    {
      pages = new List<Dictionary<string, object>>();
      cmeta = new Dictionary<string, object> { { "FILE", filePath } };

      var last = 0;

      using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      {
        var pdfReader = new PdfReader(fs);

        var strategy = new SimpleTextExtractionStrategy();
        for (var i = 0; i < pdfReader.NumberOfPages; i++)
        {
          var tmp = PdfTextExtractor.GetTextFromPage(pdfReader, i + 1, strategy);
          var text = tmp.Substring(last);
          last = tmp.Length;

          pages.Add(new Dictionary<string, object>
          {
            {"Text", text},
            {"PAGE", i }
          });
        }

        foreach (var info in pdfReader.Info)
          if (!cmeta.ContainsKey(info.Key))
            cmeta.Add(info.Key, info.Value);
      }
    }
  }
}
