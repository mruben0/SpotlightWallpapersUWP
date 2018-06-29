using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class DataService : ObservableObject
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


        public async Task InitializeAsync()
        {
            await GetAllDataFromServerAsync();
            Source = await GetGalleryDataAsync();
        }

        public  async Task<ObservableCollection<ImageDTO>> GetGalleryDataAsync(bool IsTemplate = true)
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
                        await IOManager.DownloadImages(imageDTOs, true);
                    }
                    else
                    {
                        await IOManager.DownloadImages(imageDTOs, false);
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
                // up to date
            }
        }

        public  async Task DownloadById(string ID)
        {
            var image = Source.FirstOrDefault(i => i.Id == ID);
            await  IOManager.DownloadImage(image.URI);
        }

        private  void SaveBaseDate()
        {
            if (File.Exists(_datefilePath))
             using (var sw = new StreamWriter(_datefilePath))
            {
                 sw.WriteLine(UpdateDate.ToString());
            }
        }

        private  int GetBaseDate()
        {
            if (File.Exists(_datefilePath))
            {
                using (var sr = new StreamReader(_datefilePath))
                {
                    var date = sr.ReadLine();
                    return Convert.ToInt32(date);
                }                
            }
            else
            {
                File.Create(_datefilePath).Dispose();
                return 0;
            }               
        }

        public  ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public  int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
