using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Extern.QuickIndex;
using CorpusExplorer.Sdk.Extern.TextSharp.PDF;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText;

namespace myFilterBubble.FrontEnd.WinForm
{
  public partial class QuickDemo : Form
  {
    private QuickIndex _quickIndex;
    private Dictionary<Guid, string> _dict;
    private string _corpusPath = "corpus/data.cec6";
    private const string _rootPath = @"C:\eBooks";

    public QuickDemo()
    {
      Console.Write("INIT...");
      CorpusExplorerEcosystem.InitializeMinimal();
      if (!Directory.Exists("corpus"))
        Directory.CreateDirectory("corpus");
      InitializeComponent();
#if DEBUG
      if (!File.Exists(_corpusPath))
        _corpusPath = "W:/eBooks-MFB/" + _corpusPath;
#endif

      if (File.Exists(_corpusPath))
      {
        _quickIndex = new QuickIndex(_corpusPath);
        _dict = Serializer.Deserialize<Dictionary<Guid, string>>("corpus/data.bin");
      }
      Console.WriteLine("OK!");
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        btn_index_delete.Invoke((MethodInvoker)delegate { btn_index_delete.Enabled = false; });
        btn_update.Invoke((MethodInvoker)delegate { btn_update.Enabled = false; });

        var files = Directory.GetFiles(_rootPath, "*.pdf", SearchOption.AllDirectories);

        progressBar1.Invoke((MethodInvoker)delegate
                           {
                             progressBar1.Maximum = 5;
                             progressBar1.Minimum = 0;
                             progressBar1.Value = 1;
                             Console.WriteLine($"1 / 5 = Read {files.Length} files");
                           });

        var scraper = new TextSharpPdfScraper { Strategy = TextSharpPdfScraper.TextSharpPdfScraperStrategy.Location };
        scraper.Input.Enqueue(files);
        scraper.Execute();

        progressBar1.Invoke((MethodInvoker)delegate
        {
          progressBar1.Maximum = 5;
          progressBar1.Minimum = 0;
          progressBar1.Value = 2;
          Console.WriteLine($"2 / 5 = Cleaning");
        });

        // no cleanup

        progressBar1.Invoke((MethodInvoker)delegate
        {
          progressBar1.Maximum = 5;
          progressBar1.Minimum = 0;
          progressBar1.Value = 3;
          Console.WriteLine($"3 / 5 = Tagging");
        });

        var tagger = new RawTextTagger();
        tagger.Input = scraper.Output;
        tagger.Execute();
        var corpus = tagger.Output.First();
        corpus.Save(_corpusPath, false);
        _dict = corpus.DocumentMetadata.ToDictionary(x => x.Key, x => (string)x.Value["Datei"]);
        Serializer.Serialize(_dict, "corpus/data.bin", false);

        progressBar1.Invoke((MethodInvoker)delegate
        {
          progressBar1.Maximum = 5;
          progressBar1.Minimum = 0;
          progressBar1.Value = 4;
          Console.WriteLine($"4 / 5 = Build QuickIndex");
        });

        _quickIndex = new QuickIndex(_corpusPath);

        btn_index_delete.Invoke((MethodInvoker)delegate { btn_index_delete.Enabled = true; });
        btn_update.Invoke((MethodInvoker)delegate { btn_index_delete.Enabled = true; });

        progressBar1.Invoke((MethodInvoker)delegate
        {
          progressBar1.Maximum = 5;
          progressBar1.Minimum = 0;
          progressBar1.Value = 4;
          Console.WriteLine($"5 / 5 = COMPLETE!");
        });
      }
      catch (Exception ex)
      {
        Console.WriteLine("########--------########");
        Console.WriteLine(ex.Message);
        Console.WriteLine("--------########--------");
        Console.WriteLine(ex.StackTrace);
        Console.WriteLine("########--------########");
        Console.WriteLine();
      }
    }

    private void btn_index_delete_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(
                          "Index wirklich löschen? Das Programm wird automatisch beendet und muss manuell neu gestartet werden.",
                          "Index löschen?", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;

      if (Directory.Exists("corpus"))
        Directory.Delete("corpus", true);
      Close();
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
      Dictionary<long, HashSet<int>> results = null;

      var watch = new Stopwatch();
      watch.Start();
      if (radio_contains.Checked)
        results = _quickIndex.SearchAny(txt_search.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
      else if (radio_doc.Checked)
        results = _quickIndex.SearchAllInOneDocument(txt_search.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
      else if (radio_sent.Checked)
        results = _quickIndex.SearchAllInOneSentence(txt_search.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
      watch.Stop();
      var timeSearch = watch.ElapsedMilliseconds;

      if (results.Count == 0)
      {
        lbl_statistics.Text = "NO DOCS FOUND";
        return;
      }

      lbl_statistics.Text = $"{results?.Count} DOCS found in {timeSearch}ms";

      grid_results.SuspendLayout();
      grid_results.Rows.Clear();

      foreach (var result in results.OrderByDescending(x => x.Value.Count))
        grid_results.Rows.Add(_dict[_quickIndex.Resolve(result.Key)].Replace("C:\\", "W:\\"), result.Value.Count);

      grid_results.ResumeLayout(false);
    }

    private void btn_search_del_Click(object sender, EventArgs e)
    {
      txt_search.Text = string.Empty;
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("UPDATE wirklich starten?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
          DialogResult.No)
        return;

      backgroundWorker1.RunWorkerAsync();
    }

    private void grid_results_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      var fn = grid_results.Rows[e.RowIndex].Cells[0].Value.ToString();
      Process.Start(fn);
    }
  }
}