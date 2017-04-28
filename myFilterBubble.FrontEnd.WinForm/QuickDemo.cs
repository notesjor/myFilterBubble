using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myFilterBubble.Sdk;

namespace myFilterBubble.FrontEnd.WinForm
{
  public partial class QuickDemo : Form
  {
    private FilterBubble _bubble;

    public QuickDemo()
    {
      InitializeComponent();
      _bubble = new FilterBubble("Test", Guid.Parse("65bed36eaf8541bea885062d295a4b94"));
      _bubble.Add(new LocalFolderSource {FolderPath = @"C:\Indexed"});
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
      var index = _bubble.GetIndexBuilder();

      var plock = new object();
      var items = _watcher.AllSourceFiles.ToArray();

      progressBar1.Maximum = items.Length;
      progressBar1.Minimum = 0;
      progressBar1.Value = 0;

      Parallel.ForEach(
        items,
        item =>
        {
          _watcher.Parse(item, false);
          lock (plock)
            progressBar1.Invoke((MethodInvoker) delegate { progressBar1.Value++; });
        });
    }

    private void btn_search_Click(object sender, EventArgs e)
    {

    }

    private void btn_doc_prev_Click(object sender, EventArgs e)
    {

    }

    private void btn_doc_next_Click(object sender, EventArgs e)
    {

    }

    private void btn_page_prev_Click(object sender, EventArgs e)
    {

    }

    private void btn_page_next_Click(object sender, EventArgs e)
    {

    }

    private void btn_similarityCheck_Click(object sender, EventArgs e)
    {

    }
  }
}
