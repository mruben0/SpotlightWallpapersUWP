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
        private BingHTTPService _bingHTTPService => Locator.BingHTTPService;
        public IOManager iOManager => Locator.IOManager;
        private DialogService DialogService => Locator.DialogService;
        private ObservableCollection<ImageDTO> _source;
        private int _updateDate;
        public StorageFolder AppdataFolder => ApplicationData.Current.LocalFolder;
        private string _datefilePath => Path.Combine(AppdataFolder.Path, "dt");
        private IOManagerParams _iOManagerParams;

        public async Task InitializeAsync(int page, IOManagerParams @params)
        {
            ImageDTOList = new List<ImageDTO>();
            _iOManagerParams = @params;
            iOManager.Initialize(_iOManagerParams);

            bool success = await GetAllDataFromServerAsync(page);
            if (success)
            {
                Source = await GetGalleryDataAsync(page);
            }
        }

        public async Task<ObservableCollection<ImageDTO>> GetGalleryDataAsync(int page, bool IsTemplate = true)
        {
            StorageFolder dataFolder;

            if (IsTemplate)
            {
                dataFolder = await StorageFolder.GetFolderFromPathAsync(Path.Combine(iOManager.TemplatePath, page.ToString()));
            }
            else
            {
                dataFolder = await StorageFolder.GetFolderFromPathAsync(Path.Combine(iOManager.DownloadPath, page.ToString()));
            }

            var data = new ObservableCollection<ImageDTO>();
            var items = await dataFolder.GetItemsAsync();
            var ListItems = items.ToList();
            foreach (var item in ListItems)
            {
                var id = ImageNameManager.GetId(item.Name);

                data.Add(new ImageDTO()
                {
                    URI = item.Path,
                    Id = id.ToString(),
                    Name = item.Name
                });
            }

            return data;
        }

        public async Task<bool> GetAllDataFromServerAsync(int page, bool IsTemplate = true)
        {
            if (_iOManagerParams == IOManagerParams.SpotLight)
            {
                ImageDTOList = await _hTTPService.GetPhotosByPageAsync(page);
            }
            else
            {
                ImageDTOList = await _bingHTTPService.URLParserAsync();
                IsTemplate = false;
            }

            if (ImageDTOList.Count > 0 && _iOManagerParams == IOManagerParams.SpotLight)
            {
                await iOManager.DownloadImages(ImageDTOList, page, IsTemplate);

                return true;
            }
            else
            {
                return false;
                //notif about internet connection
            }
        }

        public async Task DownloadById(string ID)
        {
            var image = Source.FirstOrDefault(i => i.Id == ID);
            await iOManager.DownloadImage(image.URI);
        }

        private int GetBaseDate()
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

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public List<ImageDTO> ImageDTOList;

        public int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
