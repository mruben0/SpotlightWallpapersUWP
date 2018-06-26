using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SpotLightUWP.Services
{
    public class IOManager
    {
        private string _downloadPath { get; set; }
        private string _downloadedfolder = "DownloadedFolder";
        
        public IOManager()
        {
            var appdata = ApplicationData.Current.LocalFolder;
            DownloadPath = Path.Combine(appdata.Path,_downloadedfolder);
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
            }
        }

        private string ResultPathGenerator(string url)
        {
            string name = Path.GetFileName(url);
            string resultPath = Path.Combine(DownloadPath, name);
            return resultPath;
        }

        public async Task DownloadImages(List<string> Urls)
        {
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
            }
            foreach (var url in Urls)
            {
               await DownloadImage(url);
            }
            //todo: delete
            System.Diagnostics.Debug.WriteLine("DownloadPath \n" + DownloadPath);
        }

        private async Task DownloadImage(string Url)
        {
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url)))
                {
                  client.DownloadFileAsync(new Uri(Url), ResultPathGenerator(Url));
                }
            }
        }

        public string DownloadPath
        {
            get { return _downloadPath; }
            set { _downloadPath = value; }
        }
    }
}
