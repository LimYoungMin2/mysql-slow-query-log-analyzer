namespace GrupArGe.MySQL.SlowQueryLogAnalyzer
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this._txtDebug = new System.Windows.Forms.RichTextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this._txtLogFilePath = new System.Windows.Forms.TextBox();
      this._btnBrowse = new System.Windows.Forms.Button();
      this._btnAnalyze = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _txtDebug
      // 
      this._txtDebug.Location = new System.Drawing.Point(32, 123);
      this._txtDebug.Name = "_txtDebug";
      this._txtDebug.Size = new System.Drawing.Size(1067, 577);
      this._txtDebug.TabIndex = 0;
      this._txtDebug.Text = "";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(82, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Log File Path:";
      // 
      // _txtLogFilePath
      // 
      this._txtLogFilePath.Location = new System.Drawing.Point(160, 44);
      this._txtLogFilePath.Name = "_txtLogFilePath";
      this._txtLogFilePath.Size = new System.Drawing.Size(328, 20);
      this._txtLogFilePath.TabIndex = 2;
      this._txtLogFilePath.Text = "C:\\WORKS\\slow.log";
      // 
      // _btnBrowse
      // 
      this._btnBrowse.Location = new System.Drawing.Point(504, 42);
      this._btnBrowse.Name = "_btnBrowse";
      this._btnBrowse.Size = new System.Drawing.Size(75, 23);
      this._btnBrowse.TabIndex = 3;
      this._btnBrowse.Text = "Browse";
      this._btnBrowse.UseVisualStyleBackColor = true;
      this._btnBrowse.Click += new System.EventHandler(this.EH_BtnBrowse_Click);
      // 
      // _btnAnalyze
      // 
      this._btnAnalyze.Location = new System.Drawing.Point(585, 42);
      this._btnAnalyze.Name = "_btnAnalyze";
      this._btnAnalyze.Size = new System.Drawing.Size(75, 23);
      this._btnAnalyze.TabIndex = 4;
      this._btnAnalyze.Text = "Analyze";
      this._btnAnalyze.UseVisualStyleBackColor = true;
      this._btnAnalyze.Click += new System.EventHandler(this.EH_BtnAnalyze_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 750);
      this.Controls.Add(this._btnAnalyze);
      this.Controls.Add(this._btnBrowse);
      this.Controls.Add(this._txtLogFilePath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._txtDebug);
      this.Name = "MainForm";
      this.Text = "MySQL Slow Query Log Analyzer";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox _txtDebug;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox _txtLogFilePath;
    private System.Windows.Forms.Button _btnBrowse;
    private System.Windows.Forms.Button _btnAnalyze;
  }
}

