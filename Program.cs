﻿using System;
using System.Windows.Forms;

namespace MultiLauncher {
  static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainWindow());
    }
  }
}
