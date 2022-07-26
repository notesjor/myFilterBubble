#region

using System.ServiceProcess;

#endregion

namespace myFilterBubble.Service
{
  internal static class Program
  {
    /// <summary>
    ///   Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    private static void Main()
    {
      var ServicesToRun = new ServiceBase[]
      {
        new Service1()
      };
      ServiceBase.Run(ServicesToRun);
    }
  }
}