using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private static int _updateDate;
        public static StorageFolder AppdataFolder => ApplicationData.Current.LocalFolder;
        private static string _datefilePath => Path.Combine(AppdataFolder.Path, "dt");

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
            
            return data;
        }

        public static async Task GetDataFromServerAsync()
        {

            var dataDate = _hTTPService.UpdatedDate();
            UpdateDate = GetBaseDate();
            if (dataDate > UpdateDate)
            {
                UpdateDate = dataDate;
                var imageDTOs = _hTTPService.URLParser();
                await IOManager.DownloadImages(imageDTOs.Select(i => i.URI).ToList());
                SaveBaseDate();
            }
            Source = await GetGalleryData();
        }

        private static void SaveBaseDate()
        {            
            if (!File.Exists(_datefilePath))
            {
                File.Create(_datefilePath);
            }
            var dd = UpdateDate.ToString();
            File.WriteAllLines(_datefilePath, new string[] { dd});
        }

        private static int GetBaseDate()
        {
            if (File.Exists(_datefilePath))
            {
                var date = File.ReadAllLines(_datefilePath).FirstOrDefault();
                return Convert.ToInt32(date);
            }
            return 0;
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
