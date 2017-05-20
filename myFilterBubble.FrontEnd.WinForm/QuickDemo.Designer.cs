namespace myFilterBubble.FrontEnd.WinForm
{
  partial class QuickDemo
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.btn_index_delete = new System.Windows.Forms.Button();
      this.lbl_progress = new System.Windows.Forms.Label();
      this.btn_update = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txt_search = new System.Windows.Forms.TextBox();
      this.btn_search_del = new System.Windows.Forms.Button();
      this.btn_search = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.radio_similarity = new System.Windows.Forms.RadioButton();
      this.radio_phrase = new System.Windows.Forms.RadioButton();
      this.radio_insentence = new System.Windows.Forms.RadioButton();
      this.radio_contains = new System.Windows.Forms.RadioButton();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.lbl_statistics = new System.Windows.Forms.Label();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.txt_page = new System.Windows.Forms.TextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lbl_pageIndex = new System.Windows.Forms.Label();
      this.btn_pageIndex_next = new System.Windows.Forms.Button();
      this.btn_pageIndex_prev = new System.Windows.Forms.Button();
      this.panel4 = new System.Windows.Forms.Panel();
      this.grid_similar = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btn_similarityCheck = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.grid_results = new System.Windows.Forms.DataGridView();
      this.FILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RANK = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid_similar)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid_results)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.progressBar1);
      this.groupBox1.Controls.Add(this.btn_index_delete);
      this.groupBox1.Controls.Add(this.lbl_progress);
      this.groupBox1.Controls.Add(this.btn_update);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(854, 50);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "C:\\Indexed";
      // 
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progressBar1.Location = new System.Drawing.Point(78, 16);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(698, 31);
      this.progressBar1.TabIndex = 1;
      // 
      // btn_index_delete
      // 
      this.btn_index_delete.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_index_delete.Location = new System.Drawing.Point(776, 16);
      this.btn_index_delete.Name = "btn_index_delete";
      this.btn_index_delete.Size = new System.Drawing.Size(75, 31);
      this.btn_index_delete.TabIndex = 3;
      this.btn_index_delete.Text = "DEL";
      this.btn_index_delete.UseVisualStyleBackColor = true;
      this.btn_index_delete.Click += new System.EventHandler(this.btn_index_delete_Click);
      // 
      // lbl_progress
      // 
      this.lbl_progress.AutoSize = true;
      this.lbl_progress.Dock = System.Windows.Forms.DockStyle.Right;
      this.lbl_progress.Location = new System.Drawing.Point(851, 16);
      this.lbl_progress.MinimumSize = new System.Drawing.Size(0, 30);
      this.lbl_progress.Name = "lbl_progress";
      this.lbl_progress.Size = new System.Drawing.Size(0, 30);
      this.lbl_progress.TabIndex = 2;
      this.lbl_progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_update
      // 
      this.btn_update.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_update.Location = new System.Drawing.Point(3, 16);
      this.btn_update.Name = "btn_update";
      this.btn_update.Size = new System.Drawing.Size(75, 31);
      this.btn_update.TabIndex = 0;
      this.btn_update.Text = "UPDATE";
      this.btn_update.UseVisualStyleBackColor = true;
      this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txt_search);
      this.groupBox2.Controls.Add(this.btn_search_del);
      this.groupBox2.Controls.Add(this.btn_search);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Location = new System.Drawing.Point(0, 50);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(854, 50);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "SEARCH";
      // 
      // txt_search
      // 
      this.txt_search.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.txt_search.Location = new System.Drawing.Point(3, 16);
      this.txt_search.MinimumSize = new System.Drawing.Size(4, 31);
      this.txt_search.Multiline = true;
      this.txt_search.Name = "txt_search";
      this.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_search.Size = new System.Drawing.Size(722, 31);
      this.txt_search.TabIndex = 2;
      this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
      // 
      // btn_search_del
      // 
      this.btn_search_del.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_search_del.Location = new System.Drawing.Point(725, 16);
      this.btn_search_del.Name = "btn_search_del";
      this.btn_search_del.Size = new System.Drawing.Size(51, 31);
      this.btn_search_del.TabIndex = 3;
      this.btn_search_del.Text = "< DEL";
      this.btn_search_del.UseVisualStyleBackColor = true;
      this.btn_search_del.Click += new System.EventHandler(this.btn_search_del_Click);
      // 
      // btn_search
      // 
      this.btn_search.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_search.Location = new System.Drawing.Point(776, 16);
      this.btn_search.Name = "btn_search";
      this.btn_search.Size = new System.Drawing.Size(75, 31);
      this.btn_search.TabIndex = 1;
      this.btn_search.Text = "SEARCH";
      this.btn_search.UseVisualStyleBackColor = true;
      this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.radio_similarity);
      this.groupBox3.Controls.Add(this.radio_phrase);
      this.groupBox3.Controls.Add(this.radio_insentence);
      this.groupBox3.Controls.Add(this.radio_contains);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(0, 100);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(854, 50);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "OPTIONS";
      // 
      // radio_similarity
      // 
      this.radio_similarity.AutoSize = true;
      this.radio_similarity.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_similarity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radio_similarity.ForeColor = System.Drawing.Color.Gray;
      this.radio_similarity.Location = new System.Drawing.Point(218, 16);
      this.radio_similarity.Name = "radio_similarity";
      this.radio_similarity.Size = new System.Drawing.Size(135, 31);
      this.radio_similarity.TabIndex = 1;
      this.radio_similarity.Text = "SIMILARITY (2000)";
      this.radio_similarity.UseVisualStyleBackColor = true;
      // 
      // radio_phrase
      // 
      this.radio_phrase.AutoSize = true;
      this.radio_phrase.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_phrase.Location = new System.Drawing.Point(149, 16);
      this.radio_phrase.Name = "radio_phrase";
      this.radio_phrase.Size = new System.Drawing.Size(69, 31);
      this.radio_phrase.TabIndex = 3;
      this.radio_phrase.Text = "PHRASE";
      this.radio_phrase.UseVisualStyleBackColor = true;
      // 
      // radio_insentence
      // 
      this.radio_insentence.AutoSize = true;
      this.radio_insentence.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_insentence.Location = new System.Drawing.Point(91, 16);
      this.radio_insentence.Name = "radio_insentence";
      this.radio_insentence.Size = new System.Drawing.Size(58, 31);
      this.radio_insentence.TabIndex = 2;
      this.radio_insentence.Text = "ALL-IN";
      this.radio_insentence.UseVisualStyleBackColor = true;
      // 
      // radio_contains
      // 
      this.radio_contains.AutoSize = true;
      this.radio_contains.Checked = true;
      this.radio_contains.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_contains.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radio_contains.Location = new System.Drawing.Point(3, 16);
      this.radio_contains.Name = "radio_contains";
      this.radio_contains.Size = new System.Drawing.Size(88, 31);
      this.radio_contains.TabIndex = 0;
      this.radio_contains.TabStop = true;
      this.radio_contains.Text = "CONTAINS";
      this.radio_contains.UseVisualStyleBackColor = true;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.lbl_statistics);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox4.Location = new System.Drawing.Point(0, 150);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(854, 50);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "STATISTICS";
      // 
      // lbl_statistics
      // 
      this.lbl_statistics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_statistics.Location = new System.Drawing.Point(3, 16);
      this.lbl_statistics.Name = "lbl_statistics";
      this.lbl_statistics.Size = new System.Drawing.Size(848, 31);
      this.lbl_statistics.TabIndex = 0;
      this.lbl_statistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.txt_page);
      this.groupBox5.Controls.Add(this.panel2);
      this.groupBox5.Controls.Add(this.panel4);
      this.groupBox5.Controls.Add(this.panel1);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(0, 200);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(854, 261);
      this.groupBox5.TabIndex = 4;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "RESULT";
      // 
      // txt_page
      // 
      this.txt_page.BackColor = System.Drawing.Color.White;
      this.txt_page.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_page.ForeColor = System.Drawing.Color.Black;
      this.txt_page.Location = new System.Drawing.Point(203, 47);
      this.txt_page.Multiline = true;
      this.txt_page.Name = "txt_page";
      this.txt_page.ReadOnly = true;
      this.txt_page.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txt_page.Size = new System.Drawing.Size(448, 211);
      this.txt_page.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lbl_pageIndex);
      this.panel2.Controls.Add(this.btn_pageIndex_next);
      this.panel2.Controls.Add(this.btn_pageIndex_prev);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(203, 16);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(448, 31);
      this.panel2.TabIndex = 3;
      // 
      // lbl_pageIndex
      // 
      this.lbl_pageIndex.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_pageIndex.Location = new System.Drawing.Point(31, 0);
      this.lbl_pageIndex.Name = "lbl_pageIndex";
      this.lbl_pageIndex.Size = new System.Drawing.Size(386, 31);
      this.lbl_pageIndex.TabIndex = 7;
      this.lbl_pageIndex.Text = "0 / 0";
      this.lbl_pageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_pageIndex_next
      // 
      this.btn_pageIndex_next.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_pageIndex_next.Location = new System.Drawing.Point(417, 0);
      this.btn_pageIndex_next.Name = "btn_pageIndex_next";
      this.btn_pageIndex_next.Size = new System.Drawing.Size(31, 31);
      this.btn_pageIndex_next.TabIndex = 6;
      this.btn_pageIndex_next.Text = ">";
      this.btn_pageIndex_next.UseVisualStyleBackColor = true;
      this.btn_pageIndex_next.Click += new System.EventHandler(this.btn_pageIndex_next_Click);
      // 
      // btn_pageIndex_prev
      // 
      this.btn_pageIndex_prev.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_pageIndex_prev.Location = new System.Drawing.Point(0, 0);
      this.btn_pageIndex_prev.Name = "btn_pageIndex_prev";
      this.btn_pageIndex_prev.Size = new System.Drawing.Size(31, 31);
      this.btn_pageIndex_prev.TabIndex = 5;
      this.btn_pageIndex_prev.Text = "<";
      this.btn_pageIndex_prev.UseVisualStyleBackColor = true;
      this.btn_pageIndex_prev.Click += new System.EventHandler(this.btn_pageIndex_prev_Click);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.grid_similar);
      this.panel4.Controls.Add(this.btn_similarityCheck);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel4.Location = new System.Drawing.Point(651, 16);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(200, 242);
      this.panel4.TabIndex = 2;
      // 
      // grid_similar
      // 
      this.grid_similar.AllowUserToAddRows = false;
      this.grid_similar.AllowUserToDeleteRows = false;
      this.grid_similar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.grid_similar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid_similar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
      this.grid_similar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid_similar.Location = new System.Drawing.Point(0, 31);
      this.grid_similar.Name = "grid_similar";
      this.grid_similar.ReadOnly = true;
      this.grid_similar.RowHeadersVisible = false;
      this.grid_similar.Size = new System.Drawing.Size(200, 211);
      this.grid_similar.TabIndex = 5;
      this.grid_similar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_similar_CellClick);
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.HeaderText = "FILE";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.FillWeight = 50F;
      this.dataGridViewTextBoxColumn2.HeaderText = "RANK";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // btn_similarityCheck
      // 
      this.btn_similarityCheck.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_similarityCheck.Location = new System.Drawing.Point(0, 0);
      this.btn_similarityCheck.Name = "btn_similarityCheck";
      this.btn_similarityCheck.Size = new System.Drawing.Size(200, 31);
      this.btn_similarityCheck.TabIndex = 4;
      this.btn_similarityCheck.Text = "..:: SIMILAR ::..";
      this.btn_similarityCheck.UseVisualStyleBackColor = true;
      this.btn_similarityCheck.Click += new System.EventHandler(this.btn_similarityCheck_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.grid_results);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(3, 16);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(200, 242);
      this.panel1.TabIndex = 0;
      // 
      // grid_results
      // 
      this.grid_results.AllowUserToAddRows = false;
      this.grid_results.AllowUserToDeleteRows = false;
      this.grid_results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.grid_results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid_results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FILE,
            this.RANK});
      this.grid_results.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid_results.Location = new System.Drawing.Point(0, 0);
      this.grid_results.Name = "grid_results";
      this.grid_results.ReadOnly = true;
      this.grid_results.RowHeadersVisible = false;
      this.grid_results.Size = new System.Drawing.Size(200, 242);
      this.grid_results.TabIndex = 0;
      this.grid_results.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_results_CellClick);
      // 
      // FILE
      // 
      this.FILE.HeaderText = "FILE";
      this.FILE.Name = "FILE";
      this.FILE.ReadOnly = true;
      // 
      // RANK
      // 
      this.RANK.FillWeight = 50F;
      this.RANK.HeaderText = "RANK";
      this.RANK.Name = "RANK";
      this.RANK.ReadOnly = true;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      // 
      // QuickDemo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(854, 461);
      this.Controls.Add(this.groupBox5);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "QuickDemo";
      this.Text = "QuickDEMO";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid_similar)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid_results)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lbl_progress;
    private System.Windows.Forms.Button btn_update;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txt_search;
    private System.Windows.Forms.Button btn_search;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton radio_similarity;
    private System.Windows.Forms.RadioButton radio_contains;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lbl_statistics;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.TextBox txt_page;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btn_similarityCheck;
    private System.Windows.Forms.RadioButton radio_phrase;
    private System.Windows.Forms.RadioButton radio_insentence;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lbl_pageIndex;
    private System.Windows.Forms.Button btn_pageIndex_next;
    private System.Windows.Forms.Button btn_pageIndex_prev;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.DataGridView grid_results;
    private System.Windows.Forms.DataGridViewTextBoxColumn FILE;
    private System.Windows.Forms.DataGridViewTextBoxColumn RANK;
    private System.Windows.Forms.DataGridView grid_similar;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.Button btn_search_del;
    private System.Windows.Forms.Button btn_index_delete;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
  }
}

