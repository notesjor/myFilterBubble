using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace myFilterBubble.Service
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    static void Main()
    {
      var ServicesToRun = new ServiceBase[]
                                    {
                                      new Service1()
                                    };
      ServiceBase.Run(ServicesToRun);
    }
  }
}
