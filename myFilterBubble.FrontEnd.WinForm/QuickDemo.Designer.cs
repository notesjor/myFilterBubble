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
      this.radio_sent = new System.Windows.Forms.RadioButton();
      this.radio_doc = new System.Windows.Forms.RadioButton();
      this.radio_contains = new System.Windows.Forms.RadioButton();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.lbl_statistics = new System.Windows.Forms.Label();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
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
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(1139, 62);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "W:\\eBooks";
      // 
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progressBar1.Location = new System.Drawing.Point(104, 19);
      this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(931, 39);
      this.progressBar1.TabIndex = 1;
      // 
      // btn_index_delete
      // 
      this.btn_index_delete.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_index_delete.Location = new System.Drawing.Point(1035, 19);
      this.btn_index_delete.Margin = new System.Windows.Forms.Padding(4);
      this.btn_index_delete.Name = "btn_index_delete";
      this.btn_index_delete.Size = new System.Drawing.Size(100, 39);
      this.btn_index_delete.TabIndex = 3;
      this.btn_index_delete.Text = "DEL";
      this.btn_index_delete.UseVisualStyleBackColor = true;
      this.btn_index_delete.Click += new System.EventHandler(this.btn_index_delete_Click);
      // 
      // lbl_progress
      // 
      this.lbl_progress.AutoSize = true;
      this.lbl_progress.Dock = System.Windows.Forms.DockStyle.Right;
      this.lbl_progress.Location = new System.Drawing.Point(1135, 19);
      this.lbl_progress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_progress.MinimumSize = new System.Drawing.Size(0, 37);
      this.lbl_progress.Name = "lbl_progress";
      this.lbl_progress.Size = new System.Drawing.Size(0, 37);
      this.lbl_progress.TabIndex = 2;
      this.lbl_progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_update
      // 
      this.btn_update.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_update.Location = new System.Drawing.Point(4, 19);
      this.btn_update.Margin = new System.Windows.Forms.Padding(4);
      this.btn_update.Name = "btn_update";
      this.btn_update.Size = new System.Drawing.Size(100, 39);
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
      this.groupBox2.Location = new System.Drawing.Point(0, 62);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox2.Size = new System.Drawing.Size(1139, 62);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "SEARCH";
      // 
      // txt_search
      // 
      this.txt_search.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.txt_search.Location = new System.Drawing.Point(4, 19);
      this.txt_search.Margin = new System.Windows.Forms.Padding(4);
      this.txt_search.MinimumSize = new System.Drawing.Size(4, 37);
      this.txt_search.Multiline = true;
      this.txt_search.Name = "txt_search";
      this.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_search.Size = new System.Drawing.Size(963, 39);
      this.txt_search.TabIndex = 2;
      // 
      // btn_search_del
      // 
      this.btn_search_del.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_search_del.Location = new System.Drawing.Point(967, 19);
      this.btn_search_del.Margin = new System.Windows.Forms.Padding(4);
      this.btn_search_del.Name = "btn_search_del";
      this.btn_search_del.Size = new System.Drawing.Size(68, 39);
      this.btn_search_del.TabIndex = 3;
      this.btn_search_del.Text = "< DEL";
      this.btn_search_del.UseVisualStyleBackColor = true;
      this.btn_search_del.Click += new System.EventHandler(this.btn_search_del_Click);
      // 
      // btn_search
      // 
      this.btn_search.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_search.Location = new System.Drawing.Point(1035, 19);
      this.btn_search.Margin = new System.Windows.Forms.Padding(4);
      this.btn_search.Name = "btn_search";
      this.btn_search.Size = new System.Drawing.Size(100, 39);
      this.btn_search.TabIndex = 1;
      this.btn_search.Text = "SEARCH";
      this.btn_search.UseVisualStyleBackColor = true;
      this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.radio_sent);
      this.groupBox3.Controls.Add(this.radio_doc);
      this.groupBox3.Controls.Add(this.radio_contains);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(0, 124);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox3.Size = new System.Drawing.Size(1139, 62);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "OPTIONS";
      // 
      // radio_sent
      // 
      this.radio_sent.AutoSize = true;
      this.radio_sent.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_sent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radio_sent.Location = new System.Drawing.Point(160, 19);
      this.radio_sent.Margin = new System.Windows.Forms.Padding(4);
      this.radio_sent.Name = "radio_sent";
      this.radio_sent.Size = new System.Drawing.Size(104, 39);
      this.radio_sent.TabIndex = 2;
      this.radio_sent.Text = "IN 1 SENT";
      this.radio_sent.UseVisualStyleBackColor = true;
      // 
      // radio_doc
      // 
      this.radio_doc.AutoSize = true;
      this.radio_doc.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radio_doc.Location = new System.Drawing.Point(64, 19);
      this.radio_doc.Margin = new System.Windows.Forms.Padding(4);
      this.radio_doc.Name = "radio_doc";
      this.radio_doc.Size = new System.Drawing.Size(96, 39);
      this.radio_doc.TabIndex = 1;
      this.radio_doc.Text = "IN 1 DOC";
      this.radio_doc.UseVisualStyleBackColor = true;
      // 
      // radio_contains
      // 
      this.radio_contains.AutoSize = true;
      this.radio_contains.Checked = true;
      this.radio_contains.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_contains.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radio_contains.Location = new System.Drawing.Point(4, 19);
      this.radio_contains.Margin = new System.Windows.Forms.Padding(4);
      this.radio_contains.Name = "radio_contains";
      this.radio_contains.Size = new System.Drawing.Size(60, 39);
      this.radio_contains.TabIndex = 0;
      this.radio_contains.TabStop = true;
      this.radio_contains.Text = "ANY";
      this.radio_contains.UseVisualStyleBackColor = true;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.lbl_statistics);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox4.Location = new System.Drawing.Point(0, 186);
      this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox4.Size = new System.Drawing.Size(1139, 62);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "STATISTICS";
      // 
      // lbl_statistics
      // 
      this.lbl_statistics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_statistics.Location = new System.Drawing.Point(4, 19);
      this.lbl_statistics.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_statistics.Name = "lbl_statistics";
      this.lbl_statistics.Size = new System.Drawing.Size(1131, 39);
      this.lbl_statistics.TabIndex = 0;
      this.lbl_statistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.panel1);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(0, 248);
      this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox5.Size = new System.Drawing.Size(1139, 319);
      this.groupBox5.TabIndex = 4;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "RESULT";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.grid_results);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(4, 19);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1131, 296);
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
      this.grid_results.Margin = new System.Windows.Forms.Padding(4);
      this.grid_results.Name = "grid_results";
      this.grid_results.ReadOnly = true;
      this.grid_results.RowHeadersVisible = false;
      this.grid_results.RowHeadersWidth = 51;
      this.grid_results.Size = new System.Drawing.Size(1131, 296);
      this.grid_results.TabIndex = 0;
      this.grid_results.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_results_CellClick);
      // 
      // FILE
      // 
      this.FILE.HeaderText = "FILE";
      this.FILE.MinimumWidth = 6;
      this.FILE.Name = "FILE";
      this.FILE.ReadOnly = true;
      // 
      // RANK
      // 
      this.RANK.FillWeight = 50F;
      this.RANK.HeaderText = "RANK";
      this.RANK.MinimumWidth = 6;
      this.RANK.Name = "RANK";
      this.RANK.ReadOnly = true;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      // 
      // QuickDemo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1139, 567);
      this.Controls.Add(this.groupBox5);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(4);
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
    private System.Windows.Forms.RadioButton radio_contains;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label lbl_statistics;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView grid_results;
    private System.Windows.Forms.DataGridViewTextBoxColumn FILE;
    private System.Windows.Forms.DataGridViewTextBoxColumn RANK;
    private System.Windows.Forms.Button btn_search_del;
    private System.Windows.Forms.Button btn_index_delete;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton radio_sent;
        private System.Windows.Forms.RadioButton radio_doc;
    }
}

