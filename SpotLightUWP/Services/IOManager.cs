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
            _downloadPath = Path.Combine(appdata.ToString(),_downloadedfolder);
            if (!Directory.Exists(_downloadPath))
            {
                Directory.CreateDirectory(_downloadPath);
            }
        }

        private string ResultPathGenerator(string url)
        {
            string name = Path.GetFileName(url);
            string resultPath = Path.Combine(_downloadPath, name);
            return resultPath;
        }

        public void DownloadImages(List<string> Urls)
        {
            if (!Directory.Exists(_downloadPath))
            {
                Directory.CreateDirectory(_downloadPath);
            }
            foreach (var url in Urls)
            {
                DownloadImage(url);
            }
        }

        private void DownloadImage(string Url)
        {
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url)))
                {
                    client.DownloadFile(new Uri(Url), ResultPathGenerator(Url));
                }
            }
        }
    }
}
