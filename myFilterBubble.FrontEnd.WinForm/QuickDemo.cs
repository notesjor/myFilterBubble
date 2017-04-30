using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    private FilterBubbleSearchIndex _search;

    public QuickDemo()
    {
      InitializeComponent();
      _bubble = new FilterBubble("Test", Guid.Parse("65bed36eaf8541bea885062d295a4b94"));
      _bubble.Add(@"C:\Indexed");

      _search = _bubble.GetSearchIndex();
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
      var index = _bubble.GetIndexBuilder();

      var plock = new object();

      progressBar1.Maximum = index.FilesTotal.Count();
      progressBar1.Minimum = 0;
      progressBar1.Value = index.FilesIndexed.Count;

      Parallel.ForEach(
        index.FilesNew,
        item =>
        {
          index.Parse(item, false);
          lock (plock)
            progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value++; });
        });
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
      Dictionary<string, double> results = null;

      var watch = new Stopwatch();
      watch.Start();
      if (radio_contains.Checked)
      {
        results = _search.Contains(txt_search.Text);
      }
      else if (radio_insentence.Checked)
      {
        var temp = _search.Contains(txt_search.Text);
      }
      else if (radio_phrase.Checked)
      {

      }
      else
      {
        
      }
      watch.Stop();

      lbl_statistics.Text = $"{results?.Count} DOCS found in {watch.ElapsedMilliseconds}ms";
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
