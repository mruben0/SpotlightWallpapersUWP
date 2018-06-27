using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class DataService
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private ImageNameManager ImageNameManager => Locator.ImageNameManager;
        private HTTPService _hTTPService => Locator.HTTPService;
        private IOManager IOManager => Locator.IOManager;
        private DialogService DialogService => Locator.DialogService;
        private ObservableCollection<ImageDTO> _source;
        private int _updateDate;
        public StorageFolder AppdataFolder => ApplicationData.Current.LocalFolder;
        private string _datefilePath => Path.Combine(AppdataFolder.Path, "dt");

        public  async Task<ObservableCollection<ImageDTO>> GetGalleryData(bool IsTemplate = true)
        {
            StorageFolder dataFolder = await StorageFolder.GetFolderFromPathAsync(IOManager.DownloadPath);            

            if (IsTemplate)
            {
               dataFolder = await StorageFolder.GetFolderFromPathAsync(IOManager.TemplatePath);
            }

            var data = new ObservableCollection<ImageDTO>();
            var items = await dataFolder.GetItemsAsync();
            foreach (var item in items)
            {
                data.Add(new ImageDTO()
                {
                    URI = item.Path,
                    Id = ImageNameManager.GetId(item.Name),
                    Name = ImageNameManager.CreateName(item.Name),
                });
            }            
            return data;
        }

        public async Task GetAllDataFromServerAsync(bool IsTemplate = true)
        {
            var dataDate = _hTTPService.UpdatedDate();
            UpdateDate = GetBaseDate();
            if (dataDate > UpdateDate)
            {
                UpdateDate = dataDate;
                var imageDTOs = _hTTPService.URLParser();
                if (imageDTOs != null)
                {
                    if (IsTemplate)
                    {
                        await IOManager.DownloadImages(imageDTOs.Select(i => i.TemplateUri).ToList(), true);
                    }
                    else
                    {
                        await IOManager.DownloadImages(imageDTOs.Select(i => i.URI).ToList(), false);
                    }
                    SaveBaseDate();
                }
                else
                {
                    //notif about internet connection
                }
            }
            else
            {
                //todo notif about up to date
            }
            Source = await GetGalleryData();
        }

        public  async Task DownloadById(int ID)
        {
            var image = Source.FirstOrDefault(i => i.Id == ID);
            await  IOManager.DownloadImage(image.URI);
        }

        private  void SaveBaseDate()
        {  
            File.WriteAllLines(_datefilePath, new string[] { UpdateDate.ToString() });
        }

        private  int GetBaseDate()
        {
            if (File.Exists(_datefilePath))
            {
                using (var tr = new StreamReader(_datefilePath))
                {
                    var date = File.ReadAllLines(_datefilePath).FirstOrDefault();
                    return Convert.ToInt32(date);
                }                
            }
            return 0;
        }

        public  ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set
            {
                _source = value;
            }
        }

        public  int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
