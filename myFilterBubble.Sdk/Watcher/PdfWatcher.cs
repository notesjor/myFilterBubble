using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myFilterBubble.Sdk.Watcher.Abstract;

namespace myFilterBubble.Sdk.Watcher
{
  [Serializable]
  public class PdfWatcher : AbstractWatcher
  {
    public PdfWatcher(string path2Watch) : base(path2Watch) { }

    public override string Filter => "*.pdf";

    protected override void ParseFile(string filePath, string modelPath)
    {
      
    }
  }
}
