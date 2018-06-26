using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using SpotLightUWP.Models;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{ 
    public static class DataService
    {
        private static ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private static HTTPService _hTTPService => Locator.HTTPService;
        private static IOManager IOManager => Locator.IOManager;
        private static DialogService DialogService => Locator.DialogService;       

        // TODO WTS: Remove this once your image gallery page is displaying real data
        public static ObservableCollection<SampleImage> GetGallerySampleData()
        {
            var data = new ObservableCollection<SampleImage>();
            for (int i = 1; i <= 10; i++)
            {
                data.Add(new SampleImage()
                {
                    ID = $"{i}",
                    Source = $"ms-appx:///Assets/SampleData/SamplePhoto{i}.png",
                    Name = $"Image sample {i}"
                });
            }

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
                var dd = imageDTOs.Select(i => i.URI).ToList();
                await IOManager.DownloadImages(dd);

            }
        }

        public static int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
