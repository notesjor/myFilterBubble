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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.btn_update = new System.Windows.Forms.Button();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.lbl_progress = new System.Windows.Forms.Label();
      this.btn_search = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
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
      this.groupBox1.Size = new System.Drawing.Size(852, 50);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "C:\\Indexed";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.textBox1);
      this.groupBox2.Controls.Add(this.btn_search);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Location = new System.Drawing.Point(0, 50);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(852, 50);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "SEARCH";
      // 
      // groupBox3
      // 
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox3.Location = new System.Drawing.Point(0, 100);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(852, 360);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "RESULTS";
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
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progressBar1.Location = new System.Drawing.Point(78, 16);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(771, 31);
      this.progressBar1.TabIndex = 1;
      // 
      // lbl_progress
      // 
      this.lbl_progress.AutoSize = true;
      this.lbl_progress.Dock = System.Windows.Forms.DockStyle.Right;
      this.lbl_progress.Location = new System.Drawing.Point(849, 16);
      this.lbl_progress.MinimumSize = new System.Drawing.Size(0, 30);
      this.lbl_progress.Name = "lbl_progress";
      this.lbl_progress.Size = new System.Drawing.Size(0, 30);
      this.lbl_progress.TabIndex = 2;
      this.lbl_progress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_search
      // 
      this.btn_search.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_search.Location = new System.Drawing.Point(774, 16);
      this.btn_search.Name = "btn_search";
      this.btn_search.Size = new System.Drawing.Size(75, 31);
      this.btn_search.TabIndex = 1;
      this.btn_search.Text = "SEARCH";
      this.btn_search.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.textBox1.Location = new System.Drawing.Point(3, 16);
      this.textBox1.MinimumSize = new System.Drawing.Size(0, 31);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(771, 31);
      this.textBox1.TabIndex = 2;
      // 
      // QuickDemo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(852, 460);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "QuickDemo";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lbl_progress;
    private System.Windows.Forms.Button btn_update;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button btn_search;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}

