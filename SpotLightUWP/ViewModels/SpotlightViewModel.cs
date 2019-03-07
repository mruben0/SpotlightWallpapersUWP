using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
using SpotLightUWP.Services;
using SpotLightUWP.Views;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace SpotLightUWP.ViewModels
{
    public class SpotlightViewModel : ViewModelBase
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;

        public SpotlightPage SpotlightPage;
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";
        public const string ImageGalleryAnimationOpen = "ImageGallery_AnimationOpen";
        public const string ImageGalleryAnimationClose = "ImageGallery_AnimationClose";
        private DataService _dataService;
        private object _selected;
        private bool _isLoaded;
        private IOManager _iOManager => Locator.IOManager;
        private HTTPService _httpService => Locator.HTTPService;
        private static string _downloadPath;
        private static string _templatePath;
        private ObservableCollection<ImageDTO> _source;
        private int _lastPage;
        private int _count;
        private GridView _imagesGridView;
        private int _maxPagesCount;

        public SpotlightViewModel()
        {
            IsLoaded = false;
            _downloadPath = _iOManager.DownloadPath;
            _templatePath = _iOManager.TemplatePath;
            DataService = new DataService();
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
            _count = _httpService.GetCount();
            _maxPagesCount = (int)Math.Floor((decimal)_count / 14);
            _lastPage = _maxPagesCount;
            if (Source == null || Source?.Count == 0)
            {
                Source = await UpdateSourceAsync(_maxPagesCount);
            }
            _imagesGridView = imagesGridView;
            UpdateButtons();
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

        public NavigationServiceEx NavigationService
        {
            get
            {
                return CommonServiceLocator.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            }
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ImageDTO;
            _imagesGridView.PrepareConnectedAnimation(ImageGalleryAnimationOpen, selected, "galleryImage");
            NavigationService.Navigate(typeof(ImageGalleryDetailViewModel).FullName, new ImageDetailNavigationParams(Source, selected.Id));
        }

        private async Task<ObservableCollection<ImageDTO>> UpdateSourceAsync(int page)
        {
            await DataService.InitializeAsync(page, IOManagerParams.SpotLight);
            return DataService.Source;
        }

        private async Task EraseDownloaded()
        {
            _iOManager.EraseDownloaded();
            Source = await UpdateSourceAsync(_lastPage);
            IsLoaded = true;
        }

        private async Task MoveLeftAsync()
        {
            if (CanTurnLeft)
            {
                IsLoaded = false;
                _lastPage++;
                UpdateButtons();

                Source = await UpdateSourceAsync(_lastPage);
                IsLoaded = true;
            }
        }

        private async Task MoveRightAsync()
        {
            if (CanTurnRight)
            {
                IsLoaded = false;
                _lastPage -= 1;
                UpdateButtons();

                Source = await UpdateSourceAsync(_lastPage);
                IsLoaded = true;
            }
        }

        public object Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public DataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
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

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public bool CanTurnLeft => _lastPage < _maxPagesCount;
        public bool CanTurnRight => _lastPage > 1;

        private void UpdateButtons()
        {
            RaisePropertyChanged(nameof(CanTurnLeft));
            RaisePropertyChanged(nameof(CanTurnRight));
        }
    }
}
