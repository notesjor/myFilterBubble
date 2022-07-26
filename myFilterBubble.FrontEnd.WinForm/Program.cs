#region

using System;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace myFilterBubble.FrontEnd.WinForm
{
  internal static class Program
  {
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      MessageBox.Show($"{e.Exception.Message}\n-----\n{e.Exception.StackTrace}");
    }

    /// <summary>
    ///   Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    private static void Main()
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
  }
}