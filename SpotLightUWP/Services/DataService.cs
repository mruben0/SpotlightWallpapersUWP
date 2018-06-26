using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using SpotLightUWP.Models;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{ 
    public static class DataService
    {
        private static ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private static HTTPService _hTTPService => Locator.HTTPService;
        private static IOManager IOManager => Locator.IOManager;
        private static DialogService DialogService => Locator.DialogService;
        private static ObservableCollection<ImageDTO> _source;

        public static async Task<ObservableCollection<ImageDTO>> GetGalleryData()
        {
            var data = new ObservableCollection<ImageDTO>();
            var dataFolder = await StorageFolder.GetFolderFromPathAsync(IOManager.DownloadPath);
            var items = await dataFolder.GetItemsAsync();
            foreach (var item in items)
            {
                data.Add(new ImageDTO()
                {
                    URI = item.Path,
                    Name = item.Name,
                });
            }

            //for (int i = 1; i <= 10; i++)
            //{
            //    data.Add(new SampleImage()
            //    {
            //        ID = $"{i}",
            //        Source = $"ms-appx:///Assets/SampleData/SamplePhoto{i}.png",
            //        Name = $"Image sample {i}"
            //    });
            //}

            return data;
        }

        private static int _updateDate;

        public static async Task GetDataFromServerAsync()
        {

            var dataDate = _hTTPService.UpdatedDate();
            if (dataDate > UpdateDate)
            {
                UpdateDate = dataDate;
                var imageDTOs = _hTTPService.URLParser();
                await IOManager.DownloadImages(imageDTOs.Select(i => i.URI).ToList());

            }
           Source = await GetGalleryData();
        }


        public static ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set
            {
                _source = value;
            }
        }
        public static int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
