using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myFilterBubble.Sdk.Watcher;

namespace myFilterBubble.FrontEnd.WinForm
{
  public partial class QuickDemo : Form
  {
    public QuickDemo()
    {
      InitializeComponent();
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
      var bubble = new PdfWatcher(@"C:\Indexed\", "65bed36eaf8541bea885062d295a4b94");
      var plock = new object();
      var items = bubble.AllSourceFiles.ToArray();

      progressBar1.Maximum = items.Length;
      progressBar1.Minimum = 0;
      progressBar1.Value = 0;

      Parallel.ForEach(
        items,
        item =>
        {
          bubble.Parse(item, false);
          lock (plock)
            progressBar1.Invoke((MethodInvoker) delegate { progressBar1.Value++; });
        });
    }
  }
}
