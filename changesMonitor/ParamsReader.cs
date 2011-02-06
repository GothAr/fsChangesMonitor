using System;
using System.IO;
using System.Web.Script.Serialization;

namespace changesMonitor
{
    internal class JsonObject
    {
        public string Path { get; set; }
        public string Filter { get; set; }
        public string RunChangingCmd { get; set; }
        public string RunCmd { get; set; }
    }

    public class ParamsReader
    {
        public string Path { get; private set; }
        public string Filter { get; private set; }

        // path to exe|bat that can change the monitored files
        public string RunChangingCommand { get; private set; }
        // path to exe|bat that dont change monitored files
        public string RunCommand { get; private set; }

        public ParamsReader()
        {
            try
            {
                var jsonParse = new JavaScriptSerializer();
                var json = jsonParse.Deserialize<JsonObject>(GetJsonContent());
                
                Path = json.Path;
                Filter = json.Filter;

                RunChangingCommand = json.RunChangingCmd;
                RunCommand = json.RunCmd;
            }catch(Exception)
            {
                Path = string.Empty;
                Filter = string.Empty;
                RunChangingCommand = string.Empty;
                RunCommand = string.Empty;
            }
        }

        private static string GetJsonContent()
        {
            var fs = new FileStream("params.json", FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs);
            
            var buf = new char[fs.Length];
            sr.ReadBlock(buf, 0, (int) fs.Length);

            return new string(buf);
        }
    }
}