using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
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

        private string ResultPathGenerator(string url, string path, string name = null)
        {
            string _name = name ?? Path.GetFileName(url);
            var cleanName = ImageNameManager.CleanName(_name);
            string resultPath = Path.Combine(path, cleanName);
            return resultPath;
        }

        public async Task DownloadImages(List<ImageDTO> imageDTOs, bool AsTemplate = true)
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
            foreach (var imagedto in imageDTOs)
            {
               await DownloadImage(imagedto.URI, imagedto.Name, downloadFolder);
            }
        }        

        public async Task DownloadImage(string Url, string name = null, string Path = null)
        {
            string _path = Path ?? DownloadPath;
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url, _path, name)))
                {
                 await client.DownloadFileTaskAsync(new Uri(Url), ResultPathGenerator(Url, _path, name));
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
