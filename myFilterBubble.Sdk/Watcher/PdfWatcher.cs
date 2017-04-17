using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using myFilterBubble.Sdk.Watcher.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace myFilterBubble.Sdk.Watcher
{
  [Serializable]
  public class PdfWatcher : AbstractWatcher
  {
    public PdfWatcher(string path2Watch) : base(path2Watch) { }

    public override string Filter => "*.pdf";
    
    protected override void ReadFile(
      string filePath,
      out List<Dictionary<string, object>> pages,
      out Dictionary<string, object> cmeta)
    {
      pages = new List<Dictionary<string, object>>();
      cmeta = new Dictionary<string, object> { { "FILE", filePath } };

      using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      {
        var pdfReader = new PdfReader(fs);

        var strategy = new SimpleTextExtractionStrategy();
        for (var i = 0; i < pdfReader.NumberOfPages; i++)
          pages.Add(new Dictionary<string, object>
          {
            {"Text", PdfTextExtractor.GetTextFromPage(pdfReader, i + 1, strategy)},
            {"PAGE", i }
          });

        foreach (var info in pdfReader.Info)
          if (!cmeta.ContainsKey(info.Key))
            cmeta.Add(info.Key, info.Value);
      }
    }
  }
}
