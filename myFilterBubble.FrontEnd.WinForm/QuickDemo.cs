using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using myFilterBubble.Sdk;
using myFilterBubble.Sdk.Features;

namespace myFilterBubble.FrontEnd.WinForm
{
  public partial class QuickDemo : Form
  {
    private readonly FilterBubble _bubble;

    private readonly Color[] _highlightColor = {Color.Red, Color.Blue, Color.HotPink, Color.Purple};
    private readonly List<Guid> _kwicGuids = new List<Guid>();
    private readonly FilterBubbleSearchIndex _search;
    private AbstractCorpusAdapter _doc;
    private string _docName;
    private int _page;
    private int _pageMax;
    private Selection _sel;

    public QuickDemo()
    {
      Console.Write("INIT...");
      InitializeComponent();
      _bubble = new FilterBubble("Test", Guid.Parse("65bed36eaf8541bea885062d295a4b94"));
      _bubble.Add(@"C:\Indexed");

      _search = _bubble.GetSearchIndex();
      Console.WriteLine("OK!");
      Console.WriteLine($"{_search.IndexedDocumentCount} DOCUMENTS ALREADY INDEXED!");
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        btn_index_delete.Invoke((MethodInvoker) delegate { btn_index_delete.Enabled = false; });
        btn_update.Invoke((MethodInvoker) delegate { btn_update.Enabled = false; });

        var index = _bubble.GetIndexBuilder();

        var plock = new object();

        progressBar1.Invoke(
                            (MethodInvoker) delegate
                            {
                              progressBar1.Maximum = index.FilesTotal.Count();
                              progressBar1.Minimum = 0;
                              progressBar1.Value = index.FilesIndexed.Count;
                              Console.WriteLine(
                                                $"{index.FilesIndexed.Count} / {index.FilesTotal.Count()} = {(double) index.FilesIndexed.Count / index.FilesTotal.Count() * 100.0}% INDEXED");
                            });

        Parallel.ForEach(
                         index.FilesNew,
                         item =>
                         {
                           try
                           {
                             index.Parse(item, false);
                             lock (plock)
                             {
                               progressBar1.Invoke((MethodInvoker) delegate { progressBar1.Value++; });
                               Console.WriteLine($"Indexed: {item}");
                             }
                           }
                           catch (Exception ex)
                           {
                             lock (plock)
                             {
                               Console.WriteLine("########");
                               Console.WriteLine(ex.Message);
                               Console.WriteLine("--------");
                               Console.WriteLine(ex.StackTrace);
                               Console.WriteLine("########");
                               Console.WriteLine();
                             }
                           }
                         });

        btn_index_delete.Invoke((MethodInvoker) delegate { btn_index_delete.Enabled = true; });
        btn_update.Invoke((MethodInvoker) delegate { btn_index_delete.Enabled = true; });
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

      Directory.Delete(_bubble.IndexPath, true);
      Close();
    }

    private void btn_openPdf_Click(object sender, EventArgs e)
    {
      Process.Start(Path.Combine(@"C:\Indexed", _docName.Replace(".cec6", ".pdf")));
    }

    private void btn_pageIndex_next_Click(object sender, EventArgs e)
    {
      if (_page + 1 >= _pageMax)
        return;

      _page++;
      OpenPage(_page);
    }

    private void btn_pageIndex_prev_Click(object sender, EventArgs e)
    {
      if (_page - 1 < 0)
        return;

      _page--;
      OpenPage(_page);
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
      Dictionary<string, double> results = null;

      var watch = new Stopwatch();
      watch.Start();
      if (radio_contains.Checked)
        results = SearchContains();
      else if (radio_insentence.Checked)
        results = SearchInSentences();
      else if (radio_phrase.Checked)
        results = SearchPhrase();
      else
        results = SearchVector();
      watch.Stop();
      var timeSearch = watch.ElapsedMilliseconds;

      if (results.Count == 0)
      {
        lbl_statistics.Text = "NO DOCS FOUND";
        return;
      }

      var queries = txt_search.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
      var best = results.OrderByDescending(x => x.Value).First();

      watch.Restart();
      OpenDocument(best.Key);
      watch.Stop();
      var timeLoad = watch.ElapsedMilliseconds;

      watch.Restart();
      var page = GetBestPage(queries);
      watch.Stop();
      var timeBest = watch.ElapsedMilliseconds;

      watch.Restart();
      OpenPage(page);
      watch.Stop();
      var timeConvert = watch.ElapsedMilliseconds;

      lbl_statistics.Text =
        $"{results?.Count} DOCS found in {timeSearch}ms / load {timeLoad}ms / best {timeBest}ms / read {timeConvert}ms => {timeSearch + timeLoad + timeBest + timeConvert}ms";

      grid_results.SuspendLayout();
      grid_results.Rows.Clear();

      foreach (var result in results.OrderByDescending(x => x.Value))
        grid_results.Rows.Add(result.Key, result.Value);

      grid_results.ResumeLayout(false);
    }

    private void btn_search_del_Click(object sender, EventArgs e)
    {
      txt_search.Text = string.Empty;
    }

    private void btn_similarityCheck_Click(object sender, EventArgs e)
    {
      var watch = new Stopwatch();

      watch.Start();
      var results = _search.SearchVector(_search.GetIndexedDocumentVector(_docName));
      watch.Stop();

      lbl_statistics.Text = $"{results.Count} SIMILAR DOCS FOUND in {watch.ElapsedMilliseconds} ms";

      grid_similar.SuspendLayout();
      grid_similar.Rows.Clear();

      foreach (var result in results.OrderByDescending(x => x.Value))
        grid_similar.Rows.Add(result.Key, result.Value);

      grid_similar.ResumeLayout(false);
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("UPDATE wirklich starten?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
          DialogResult.No)
        return;

      backgroundWorker1.RunWorkerAsync();
    }

    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      OpenPage(GetPage(_kwicGuids[e.RowIndex]));
    }

    private int GetBestPage(IEnumerable<string> queries)
    {
      var blo = _sel.CreateBlock<DocumentBestSnippetBlock>();
      blo.LayerQueries = queries;
      blo.Calculate();
      return GetPage(blo.GetBestDocument().OrderByDescending(x => x.Value).First().Key);
    }

    private Guid GetPage(int page)
    {
      if (_sel == null || page < 0 || page >= _pageMax)
        return Guid.Empty;

      foreach (var d in _sel.DocumentMetadata)
        if (d.Value.ContainsKey("PAGE") && (int) d.Value["PAGE"] == page)
          return d.Key;
      return Guid.Empty;
    }

    private int GetPage(Guid guid)
    {
      return (int) _sel.GetDocumentMetadata(guid)["PAGE"];
    }

    private void grid_results_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      var fn = grid_results.Rows[e.RowIndex].Cells[0].Value.ToString();
      OpenDocument(fn);
      OpenPage(GetBestPage(txt_search.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)));
    }

    private void grid_results_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void grid_similar_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      var fn = grid_results.Rows[e.RowIndex].Cells[0].Value.ToString();
      OpenDocument(fn);
      OpenPage(GetBestPage(txt_search.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)));
    }

    private void HighlightSearchTerms()
    {
      var terms = txt_search.Text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
      for (var i = 0; i < terms.Length; i++)
      {
        var term = terms[i];
        if (!txt_page.Text.Contains(term)) continue;
        var matchString = Regex.Escape(term);
        foreach (Match match in Regex.Matches(txt_page.Text, matchString))
        {
          txt_page.Select(match.Index, term.Length);
          txt_page.SelectionColor = _highlightColor[i % _highlightColor.Length];
          txt_page.Select(txt_page.TextLength, 0);
          txt_page.SelectionColor = txt_page.ForeColor;
        }
      }
    }

    private void MakeTextBlackAgain()
    {
      txt_page.SelectAll();
      txt_page.SelectionColor = txt_page.ForeColor;
    }

    private void OpenDocument(string docName)
    {
      _docName = docName;
      _doc = _search.Load(docName);
      _pageMax = _doc.CountDocuments;
      _sel = _doc.ToSelection();

      try
      {
        radPdfViewer1.LoadDocument(Path.Combine(@"C:\Indexed", _docName.Replace(".cec6", ".pdf")));
      }
      catch
      {
        radPdfViewer1.UnloadDocument();
      }

      var vm = new TextLiveSearchViewModel {Selection = _sel};
      vm.AddQuery(new FilterQuerySingleLayerAnyMatch
      {
        LayerQueries = txt_search.Text.Split(' '),
        LayerDisplayname = "Wort"
      });
      vm.Execute();

      _kwicGuids.Clear();
      dataGridView1.SuspendLayout();
      dataGridView1.Rows.Clear();
      foreach (DataRow row in vm.GetDataTable().Rows)
      {
        dataGridView1.Rows.Add(row[3], row[4], row[5], row[1]);
        _kwicGuids.Add((Guid) row[1]);
      }

      dataGridView1.ResumeLayout();
    }

    private void OpenPage(int pageIndex)
    {
      var page = GetPage(pageIndex);

      if (_sel == null || page == Guid.Empty)
        return;

      txt_page.Text = _sel.GetReadableDocument(page, "Wort").ConvertToPlainText();
      MakeTextBlackAgain();
      HighlightSearchTerms();

      try
      {
        radPdfViewer1.PdfViewerElement.GoToPage(pageIndex);
      }
      catch
      {
        // ignore
      }

      _page = _sel.GetDocumentMetadata(page, "PAGE", -1);
      lbl_pageIndex.Text = $"{_page + 1} / {_pageMax}";
    }

    private Dictionary<string, double> SearchContains()
    {
      return _search.SearchContains(txt_search.Text);
    }

    private Dictionary<string, double> SearchInSentences()
    {
      var results = _search.SearchContains(txt_search.Text);
      var query = new AbstractFilterQuery[]
      {
        new FilterQuerySingleLayerAllInOneSentence
        {
          LayerQueries = txt_search.Text.Split(
                                               new[] {" "},
                                               StringSplitOptions.RemoveEmptyEntries)
        }
      };

      var temp = new Dictionary<string, double>();
      Parallel.ForEach(
                       results,
                       x =>
                       {
                         var d = _search.Load(x.Key);
                         var s = d.ToSelection();
                         if (s.CreateTemporary(query).CountDocuments > 0)
                           temp.Add(x.Key, x.Value);
                       });
      results = temp;
      return results;
    }

    private Dictionary<string, double> SearchPhrase()
    {
      var results = _search.SearchContains(txt_search.Text);
      var query = new AbstractFilterQuery[]
      {
        new FilterQuerySingleLayerExactPhrase
        {
          LayerQueries = txt_search.Text.Split(
                                               new[] {" "},
                                               StringSplitOptions.RemoveEmptyEntries)
        }
      };

      var temp = new Dictionary<string, double>();
      Parallel.ForEach(
                       results,
                       x =>
                       {
                         var d = _search.Load(x.Key);
                         var s = d.ToSelection();
                         if (s.CreateTemporary(query).CountDocuments > 0)
                           temp.Add(x.Key, x.Value);
                       });
      results = temp;
      return results;
    }

    private Dictionary<string, double> SearchVector()
    {
      return _search.SearchVector(txt_search.Text);
    }

    private void txt_search_TextChanged(object sender, EventArgs e)
    {
      var length = txt_search.Text.Length;
      var valid = length > 2000;

      radio_similarity.Font = new Font(
                                       "Microsoft Sans Serif",
                                       8.25F,
                                       valid ? FontStyle.Bold : FontStyle.Bold | FontStyle.Strikeout,
                                       GraphicsUnit.Point,
                                       0);
      radio_similarity.Text = valid ? "SIMILARITY" : $"SIMILARITY ({2000 - length})";
      radio_similarity.ForeColor = valid ? Color.Black : Color.Gray;
    }
  }
}