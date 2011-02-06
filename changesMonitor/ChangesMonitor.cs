using System;
using System.IO;
using System.Diagnostics;

namespace changesMonitor
{
    public class ChangesMonitor : IDisposable
    {
        private readonly FileSystemWatcher _fsw;

        const string SSource = "FileSystemChangesMonitor";
        const string SLog = "Application";
        const string SEvent = "monitored FS have been changed";

        public ChangesMonitor()
        {
            var param = new ParamsReader();
            _fsw = new FileSystemWatcher
                       {
                           Path = param.Path,
                           NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Size,
                           Filter = param.Filter
                       };

            // Add event handlers.
            _fsw.Changed += onChanged;
            _fsw.Created += onChanged;
            //_fsw.Deleted += onChanged;
            //_fsw.Renamed += onRenamed;

            _fsw.EnableRaisingEvents = true;

            if (!EventLog.SourceExists(SSource))
                EventLog.CreateEventSource(SSource, SLog);
        }

        protected void onChanged(object source, FileSystemEventArgs e)
        {
            EventLog.WriteEntry(SSource, SEvent, EventLogEntryType.Information);
        }

        protected void onRenamed(object source, RenamedEventArgs e)
        {
        }

        public void Dispose()
        {
            _fsw.EnableRaisingEvents = false;
            _fsw.Dispose();
        }
    }
}