using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace changesMonitor
{
    [RunInstaller(true)]

    public class MonitorServiceInstaller : Installer
    {
        private ServiceProcessInstaller _spi;
        private ServiceInstaller _si;

        public MonitorServiceInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _spi = new ServiceProcessInstaller();
            _si = new ServiceInstaller();

            _spi.Account = ServiceAccount.LocalSystem;
            _si.ServiceName = "FileSystemChangesMonitor";
            _si.StartType = ServiceStartMode.Manual;
            _si.DisplayName = "File System Changes Monitor";

            Installers.AddRange
                (
                    new Installer[]
                        {
                            _si,
                            _si
                        });
        }
    }
}