﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
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
        results = SearchContains();
      }
      else if (radio_insentence.Checked)
      {
        results = SearchInSentences();
      }
      else if (radio_phrase.Checked)
      {
        results = SearchPhrase();
      }
      else
      {
        results = SearchVector();
      }
      watch.Stop();
      var timeSearch = watch.ElapsedMilliseconds;

      if (results.Count == 0)
      {
        lbl_statistics.Text = "NO DOCS FOUND";
        return;
      }

      var best = results.OrderByDescending(x => x.Value).First();

      watch.Restart();
      var doc = _search.Load(best.Key);
      watch.Stop();
      var timeLoad = watch.ElapsedMilliseconds;

      watch.Restart();
      var sel = doc.ToSelection();
      var blo = sel.CreateBlock<DocumentBestSnippetBlock>();
      blo.Calculate();
      var page = blo.GetBestDocument().OrderByDescending(x=>x.Value).First().Key;
      watch.Stop();
      var timeBest = watch.ElapsedMilliseconds;

      watch.Restart();
      var text = sel.GetReadableDocument(page, "Wort").ConvertToPlainText();
      watch.Stop();
      var timeConvert = watch.ElapsedMilliseconds;

      txt_page.Text = text;

      lbl_statistics.Text = $"{results?.Count} DOCS found in {timeSearch}ms / load {timeLoad}ms / best {timeBest}ms / read {timeConvert}ms => {timeSearch + timeLoad + timeBest + timeConvert}ms";

      grid_results.SuspendLayout();
      grid_results.Rows.Clear();

      foreach (var result in results.OrderByDescending(x=>x.Value))
      {
        grid_results.Rows.Add(result.Key, result.Value);
      }

      grid_results.ResumeLayout(false);
    }

    private Dictionary<string, double> SearchVector()
    {
      return _search.SearchVector(txt_search.Text);
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

    private Dictionary<string, double> SearchContains()
    {
      return _search.SearchContains(txt_search.Text);
    }

    private void btn_similarityCheck_Click(object sender, EventArgs e)
    {

    }

    private void btn_pageIndex_prev_Click(object sender, EventArgs e)
    {

    }

    private void btn_pageIndex_next_Click(object sender, EventArgs e)
    {

    }

    private void grid_results_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void grid_similar_CellClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
