using System.ServiceProcess;

namespace changesMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new MonitorService() 
                                              };
            ServiceBase.Run(servicesToRun);
        }
    }
}
