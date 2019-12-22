using GalaSoft.MvvmLight;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Helpers;
using SpotLightUWP.Core.Models;
using SpotLightUWP.Services.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class DataService : ObservableObject, IDataService
    {
        private ObservableCollection<ImageDTO> _source;
        private int _updateDate;
        private readonly IHTTPService _httpService;
        private readonly IBingHTTPService _bingHTTPService;
        private readonly IIOManager _iOManager;
        private readonly IDialogService _dialogService;
        public StorageFolder AppdataFolder => ApplicationData.Current.LocalFolder;
        private string _datefilePath => Path.Combine(AppdataFolder.Path, "dt");
        private IOManagerParams _iOManagerParams;

        public DataService(IHTTPService httpService,
                           IBingHTTPService bingHTTPService,
                           IIOManager iOManager,
                           IDialogService dialogService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _bingHTTPService = bingHTTPService ?? throw new ArgumentNullException(nameof(bingHTTPService));
            _iOManager = iOManager ?? throw new ArgumentNullException(nameof(iOManager));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _iOManager.Initialize();
        }

        public async Task InitializeAsync(int page, IOManagerParams @params)
        {
            ImageDTOList = new List<ImageDTO>();
            _iOManagerParams = @params;
            _iOManager.Initialize(_iOManagerParams);

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
                dataFolder = await StorageFolder.GetFolderFromPathAsync(Path.Combine(_iOManager.TemplatePath, page.ToString()));
            }
            else
            {
                dataFolder = await StorageFolder.GetFolderFromPathAsync(Path.Combine(_iOManager.DownloadPath, page.ToString()));
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
                ImageDTOList = await _httpService.GetPhotosByPageAsync(page);
            }
            else if(_iOManagerParams == IOManagerParams.Bing)
            {
                ImageDTOList = await _bingHTTPService.GetImages();
                IsTemplate = false;
            }
            else
            {

            }

            if (ImageDTOList.Count > 0)
            {
                if (_iOManagerParams == IOManagerParams.SpotLight)
                {
                    await _iOManager.DownloadImages(ImageDTOList, page, IsTemplate);

                    return true;
                }             
            }
            else
            {
                //notify about internet connection
                await _dialogService.ShowAlertAsync("Please Check your internet connection");
                Application.Current.Exit();
            }

            return false;
        }

        public async Task DownloadById(string ID)
        {
            var image = Source.FirstOrDefault(i => i.Id == ID);
            await _iOManager.DownloadImage(image.URI);
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public List<ImageDTO> ImageDTOList { get; set; }

        public int UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}
