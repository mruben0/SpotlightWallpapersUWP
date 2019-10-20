using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Models;
using SpotLightUWP.Helpers;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SpotLightUWP.ViewModels
{
    public class DownloadedImagesViewModel : ViewModelBase
    {
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";
        public const string ImageGalleryAnimationOpen = "ImageGallery_AnimationOpen";
        public const string ImageGalleryAnimationClose = "ImageGallery_AnimationClose";
        private readonly IHTTPService _httpService;
        private readonly IIOManager _iOManager;
        private readonly IDataService _dataService;
        private object _selected;
        private bool _isLoaded;
        private static string _downloadPath;
        private static string _templatePath;
        private ObservableCollection<ImageDTO> _source;
        private int _lastPage;
        private int _count;

        private GridView _imagesGridView;

        public DownloadedImagesViewModel(IHTTPService httpService, IIOManager iOManager, IDataService dataService)
        {
            IsLoaded = false;
            _httpService = httpService ?? throw new System.ArgumentNullException(nameof(httpService));
            _iOManager = iOManager ?? throw new System.ArgumentNullException(nameof(iOManager));
            _dataService = dataService ?? throw new System.ArgumentNullException(nameof(dataService));
            _lastPage = 1;
            _downloadPath = _iOManager.DownloadPath;
            _templatePath = _iOManager.TemplatePath;
        }

        public ICommand ItemSelectedCommand => new RelayCommand<ItemClickEventArgs>(OnsItemSelected);

        public ICommand EraseImages => new RelayCommand(async () =>
        {
            IsLoaded = false;
            await EraseDownloaded();
        });

        public ICommand ToLeft => new RelayCommand(async () => await MoveLeftAsync());

        public ICommand ToRight => new RelayCommand(async () => await MoveRightAsync());

        public async Task InitializeAsync(GridView imagesGridView)
        {
            _iOManager.Initialize();
            if (Source == null || Source?.Count == 0)
            {
                await UpdateSourceAsync(1);
            }
            _imagesGridView = imagesGridView;
            IsLoaded = true;
        }

        public async Task LoadAnimationAsync()
        {
            var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGallerySelectedIdKey);
            if (selectedImageId != null)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryAnimationClose);
                if (animation != null)
                {
                    var item = _imagesGridView.Items.FirstOrDefault(i => ((ImageDTO)i).Id == selectedImageId);
                    _imagesGridView.ScrollIntoView(item);
                    await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage");
                }

                ApplicationData.Current.LocalSettings.SaveString(ImageGallerySelectedIdKey, string.Empty);
            }
        }

        private async Task UpdateSourceAsync(int page)
        {
            _count = 14;
            Source = await _dataService.GetGalleryDataAsync(page, false);
        }

        private async Task EraseDownloaded()
        {
            _iOManager.EraseDownloaded();
            _lastPage = 1;
            await UpdateSourceAsync(_lastPage);
            IsLoaded = true;
        }

        private async Task MoveLeftAsync()
        {
            if (_lastPage > 1)
            {
                IsLoaded = false;
                _lastPage--;

                await UpdateSourceAsync(_lastPage);
                IsLoaded = true;
            }
        }

        private async Task MoveRightAsync()
        {
            if (_lastPage <= _count)
            {
                IsLoaded = false;
                _lastPage++;

                await UpdateSourceAsync(_lastPage);
                IsLoaded = true;
            }
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ImageDTO;
            _imagesGridView.PrepareConnectedAnimation(ImageGalleryAnimationOpen, selected, "galleryImage");
            NavigationService.Navigate(typeof(ImageGalleryDetailViewModel).FullName, new ImageDetailNavigationParams(Source, selected.Id));
        }

        public NavigationServiceEx NavigationService
        {
            get
            {
                return CommonServiceLocator.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            }
        }

        public object Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set
            {
                _isLoaded = value;
                RaisePropertyChanged(nameof(IsLoaded));
            }
        }
    }
}
