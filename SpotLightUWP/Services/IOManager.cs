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
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class IOManager
    {
        private  ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private  ImageNameManager ImageNameManager => Locator.ImageNameManager;
        private string _downloadPath;
        private string _templatePath;
        public string _downloadedfolder = "DownloadedFolder";
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

        public string ResultPathGenerator(string url, string path, string id=null ,string name = null)
        {
            string _name = name ?? Path.GetFileName(url);
            if (id != null)
            {
                _name = $"__{id}__" + _name;
            }
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
                foreach (var imagedto in imageDTOs)
                {
                    await DownloadImage(imagedto.TemplateUri,imagedto.Id, imagedto.Name, downloadFolder);
                }
            }
            else
            {
                downloadFolder = DownloadPath;
                foreach (var imagedto in imageDTOs)
                {
                    await DownloadImage(imagedto.URI, imagedto.Id ,imagedto.Name, downloadFolder);
                }
            }          
        }        

        public async Task DownloadImage(string Url, string id = null, string name = null, string Path = null)
        {
            string _path = Path ?? DownloadPath;
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(ResultPathGenerator(Url, _path,id, name)))
                {
                 await client.DownloadFileTaskAsync(new Uri(Url), ResultPathGenerator(Url, _path,id, name));
                }
            }
        }

        public async Task SaveImageAs(ImageDTO image)
        {
           StorageFile currentImage = await StorageFile.GetFileFromPathAsync(image.URI);
           byte[] buffer;
           Stream stream = await currentImage.OpenStreamForReadAsync();
           buffer = new byte[stream.Length];
           await stream.ReadAsync(buffer, 0, (int)stream.Length);
           var savePicker = new FileSavePicker();
           savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
           savePicker.FileTypeChoices.Add("JPEG-Image", new List<string>() { ".jpg" });
           savePicker.FileTypeChoices.Add("PNG-Image", new List<string>() { ".png" });
           savePicker.SuggestedSaveFile = currentImage;
           savePicker.SuggestedFileName = currentImage.Name;
           var file = await savePicker.PickSaveFileAsync();
           if (file != null)
           {
               CachedFileManager.DeferUpdates(file);
               await FileIO.WriteBytesAsync(file, buffer);
               await CachedFileManager.CompleteUpdatesAsync(file);
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
