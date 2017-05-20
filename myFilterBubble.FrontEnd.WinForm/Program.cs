using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myFilterBubble.FrontEnd.WinForm
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new QuickDemo());
        Application.ThreadException += Application_ThreadException;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"{ex.Message}\n-----\n{ex.StackTrace}");
      }
    }

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
      MessageBox.Show($"{e.Exception.Message}\n-----\n{e.Exception.StackTrace}");
    }
  }
}
