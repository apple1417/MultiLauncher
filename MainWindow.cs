using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MultiLauncher {
  public partial class MainWindow : Form {
    private readonly Dictionary<Button, LaunchProfile> ProfileMap;
    public MainWindow() {
      InitializeComponent();

      List<LaunchProfile> allProfiles = LaunchProfile.LoadProfiles();

      if (allProfiles.Count == 0) {
        Button button = new Button {
          Text = "ERROR: No Profiles Detected",
          AutoSize = true,
          MinimumSize = new Size(200, 40),
          Font = new Font("Microsoft Sans Serif", 12),
          ForeColor = Color.Red,
        };
        button.Click += (sender, e) => Close();
        ButtonTable.Controls.Add(button);
        return;
      }

      ProfileMap = new Dictionary<Button, LaunchProfile>();

      ButtonTable.RowCount = allProfiles.Count;
      ButtonTable.RowStyles.Clear();

      foreach (LaunchProfile prof in allProfiles) {
        Button button = new Button {
          Text = prof.Name,
          AutoSize = true,
          MinimumSize = new Size(200, 40),
          Font = new Font("Microsoft Sans Serif", 12)
        };
        button.Click += Button_Click;

        ButtonTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        ButtonTable.Controls.Add(button);

        ProfileMap.Add(button, prof);
      }
    }

    private void MainWindow_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Escape) {
        Close();
      }
    }

    private void Button_Click(object sender, EventArgs e) {
      ProfileMap[(Button)sender].Launch();
      Close();
    }
  }
}
