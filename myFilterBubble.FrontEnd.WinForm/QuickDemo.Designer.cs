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
      this.lbl_progress = new System.Windows.Forms.Label();
      this.btn_update = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txt_search = new System.Windows.Forms.TextBox();
      this.btn_search = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.radio_similarity = new System.Windows.Forms.RadioButton();
      this.radio_contains = new System.Windows.Forms.RadioButton();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.lbl_statistics = new System.Windows.Forms.Label();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.txt_page = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btn_similarityCheck = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.lbl_page_info = new System.Windows.Forms.Label();
      this.btn_page_next = new System.Windows.Forms.Button();
      this.btn_page_prev = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lbl_doc_info = new System.Windows.Forms.Label();
      this.btn_doc_next = new System.Windows.Forms.Button();
      this.btn_doc_prev = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.progressBar1);
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
      this.progressBar1.Size = new System.Drawing.Size(773, 31);
      this.progressBar1.TabIndex = 1;
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
      this.txt_search.Size = new System.Drawing.Size(773, 31);
      this.txt_search.TabIndex = 2;
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
      this.radio_similarity.Location = new System.Drawing.Point(83, 16);
      this.radio_similarity.Name = "radio_similarity";
      this.radio_similarity.Size = new System.Drawing.Size(85, 31);
      this.radio_similarity.TabIndex = 1;
      this.radio_similarity.Text = "SIMILARITY";
      this.radio_similarity.UseVisualStyleBackColor = true;
      // 
      // radio_contains
      // 
      this.radio_contains.AutoSize = true;
      this.radio_contains.Checked = true;
      this.radio_contains.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_contains.Location = new System.Drawing.Point(3, 16);
      this.radio_contains.Name = "radio_contains";
      this.radio_contains.Size = new System.Drawing.Size(80, 31);
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
      this.txt_page.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_page.Location = new System.Drawing.Point(193, 16);
      this.txt_page.Multiline = true;
      this.txt_page.Name = "txt_page";
      this.txt_page.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txt_page.Size = new System.Drawing.Size(658, 242);
      this.txt_page.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btn_similarityCheck);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(3, 16);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(190, 242);
      this.panel1.TabIndex = 0;
      // 
      // btn_similarityCheck
      // 
      this.btn_similarityCheck.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_similarityCheck.Location = new System.Drawing.Point(0, 211);
      this.btn_similarityCheck.Name = "btn_similarityCheck";
      this.btn_similarityCheck.Size = new System.Drawing.Size(190, 31);
      this.btn_similarityCheck.TabIndex = 4;
      this.btn_similarityCheck.Text = "SIMILAR";
      this.btn_similarityCheck.UseVisualStyleBackColor = true;
      this.btn_similarityCheck.Click += new System.EventHandler(this.btn_similarityCheck_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.lbl_page_info);
      this.panel3.Controls.Add(this.btn_page_next);
      this.panel3.Controls.Add(this.btn_page_prev);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 64);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(190, 38);
      this.panel3.TabIndex = 3;
      // 
      // lbl_page_info
      // 
      this.lbl_page_info.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_page_info.Location = new System.Drawing.Point(38, 0);
      this.lbl_page_info.Name = "lbl_page_info";
      this.lbl_page_info.Size = new System.Drawing.Size(114, 38);
      this.lbl_page_info.TabIndex = 3;
      this.lbl_page_info.Text = "0 / 0";
      this.lbl_page_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_page_next
      // 
      this.btn_page_next.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_page_next.Location = new System.Drawing.Point(152, 0);
      this.btn_page_next.Name = "btn_page_next";
      this.btn_page_next.Size = new System.Drawing.Size(38, 38);
      this.btn_page_next.TabIndex = 2;
      this.btn_page_next.Text = ">";
      this.btn_page_next.UseVisualStyleBackColor = true;
      this.btn_page_next.Click += new System.EventHandler(this.btn_page_next_Click);
      // 
      // btn_page_prev
      // 
      this.btn_page_prev.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_page_prev.Location = new System.Drawing.Point(0, 0);
      this.btn_page_prev.Name = "btn_page_prev";
      this.btn_page_prev.Size = new System.Drawing.Size(38, 38);
      this.btn_page_prev.TabIndex = 1;
      this.btn_page_prev.Text = "<";
      this.btn_page_prev.UseVisualStyleBackColor = true;
      this.btn_page_prev.Click += new System.EventHandler(this.btn_page_prev_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Top;
      this.label4.Location = new System.Drawing.Point(0, 51);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(36, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "PAGE";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lbl_doc_info);
      this.panel2.Controls.Add(this.btn_doc_next);
      this.panel2.Controls.Add(this.btn_doc_prev);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 13);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(190, 38);
      this.panel2.TabIndex = 0;
      // 
      // lbl_doc_info
      // 
      this.lbl_doc_info.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_doc_info.Location = new System.Drawing.Point(38, 0);
      this.lbl_doc_info.Name = "lbl_doc_info";
      this.lbl_doc_info.Size = new System.Drawing.Size(114, 38);
      this.lbl_doc_info.TabIndex = 3;
      this.lbl_doc_info.Text = "0 / 0";
      this.lbl_doc_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_doc_next
      // 
      this.btn_doc_next.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_doc_next.Location = new System.Drawing.Point(152, 0);
      this.btn_doc_next.Name = "btn_doc_next";
      this.btn_doc_next.Size = new System.Drawing.Size(38, 38);
      this.btn_doc_next.TabIndex = 2;
      this.btn_doc_next.Text = ">";
      this.btn_doc_next.UseVisualStyleBackColor = true;
      this.btn_doc_next.Click += new System.EventHandler(this.btn_doc_next_Click);
      // 
      // btn_doc_prev
      // 
      this.btn_doc_prev.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_doc_prev.Location = new System.Drawing.Point(0, 0);
      this.btn_doc_prev.Name = "btn_doc_prev";
      this.btn_doc_prev.Size = new System.Drawing.Size(38, 38);
      this.btn_doc_prev.TabIndex = 1;
      this.btn_doc_prev.Text = "<";
      this.btn_doc_prev.UseVisualStyleBackColor = true;
      this.btn_doc_prev.Click += new System.EventHandler(this.btn_doc_prev_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Top;
      this.label3.Location = new System.Drawing.Point(0, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "DOCUMENT";
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
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
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
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label lbl_page_info;
    private System.Windows.Forms.Button btn_page_next;
    private System.Windows.Forms.Button btn_page_prev;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lbl_doc_info;
    private System.Windows.Forms.Button btn_doc_next;
    private System.Windows.Forms.Button btn_doc_prev;
    private System.Windows.Forms.Label label3;
  }
}

