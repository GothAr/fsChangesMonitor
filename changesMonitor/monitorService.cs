using System.ServiceProcess;

namespace changesMonitor
{
    public partial class MonitorService : ServiceBase
    {
        private ChangesMonitor Monitor { get; set; }
        
        public MonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Monitor = new ChangesMonitor();
        }

        protected override void OnStop()
        {
            Monitor.Dispose();
        }
    }
}
