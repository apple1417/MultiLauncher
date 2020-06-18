namespace MultiLauncher {
  partial class MainWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.ButtonTable = new System.Windows.Forms.TableLayoutPanel();
      this.SuspendLayout();
      // 
      // ButtonTable
      // 
      this.ButtonTable.AutoSize = true;
      this.ButtonTable.ColumnCount = 1;
      this.ButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.ButtonTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ButtonTable.Location = new System.Drawing.Point(0, 0);
      this.ButtonTable.Name = "ButtonTable";
      this.ButtonTable.Padding = new System.Windows.Forms.Padding(3);
      this.ButtonTable.RowCount = 1;
      this.ButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.ButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
      this.ButtonTable.Size = new System.Drawing.Size(284, 261);
      this.ButtonTable.TabIndex = 0;
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.ButtonTable);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.KeyPreview = true;
      this.Name = "MainWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ButtonTable;
    }
}

