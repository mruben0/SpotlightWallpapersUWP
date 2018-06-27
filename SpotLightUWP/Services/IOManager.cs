using SpotLightUWP.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class IOManager
    {
        private  ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private  ImageNameManager ImageNameManager => Locator.ImageNameManager;
        private string _downloadPath;
        private string _templatePath;
        private string _downloadedfolder = "DownloadedFolder";
        private string _templateFolder = "Templates";
        
        public IOManager()
        {
            var appdata = ApplicationData.Current.LocalFolder;
            DownloadPath = Path.Combine(appdata.Path,_downloadedfolder);
            TemplatePath = Path.Combine(appdata.Path, _templateFolder);
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
            }
            if (!Directory.Exists(TemplatePath))
            {
                Directory.CreateDirectory(TemplatePath);
            }
        }

        private string ResultPathGenerator(string url, string path)
        {
            string name = Path.GetFileName(url);
            var cleanName = ImageNameManager.CleanName(name);
            string resultPath = Path.Combine(path, cleanName);
            return resultPath;
        }

        public async Task DownloadImages(List<string> Urls, bool AsTemplate = true)
        {
            string downloadFolder;
            if (AsTemplate)
            {
                downloadFolder = TemplatePath;
            }
            else
            {
                downloadFolder = DownloadPath;
            }
            foreach (var url in Urls)
            {
               await DownloadImage(url, downloadFolder);
            }
            //todo: delete
            System.Diagnostics.Debug.WriteLine("DownloadPath \n" + DownloadPath);
        }        

        public async Task DownloadImage(string Url, string Path = null)
        {
            string _path = Path ?? DownloadPath;
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url, _path)))
                {
                 await client.DownloadFileTaskAsync(new Uri(Url), ResultPathGenerator(Url, _path));
                }
            }
        }

        public string DownloadPath
        {
            get { return _downloadPath; }
            set { _downloadPath = value; }
        }

        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }

    }
}
