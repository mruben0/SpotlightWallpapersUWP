using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Helpers;
using SpotLightUWP.Core.Models;
using SpotLightUWP.Helpers;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SpotLightUWP.ViewModels
{
    public class ImageGalleryDetailViewModel : ViewModelBase
    {
        private static UIElement _image;
        private int _count;
        private ImageDTO _selectedImage;
        private ObservableCollection<ImageDTO> _source;
        private string _fullsizedImage;
        private readonly IIOManager _iOManager;
        private readonly IHTTPService _hTTPService;
        private readonly IWallpaperService _wallpaperService;

        public ImageGalleryDetailViewModel(IIOManager iOManager, IHTTPService hTTPService, IWallpaperService wallpaperService)
        {
            _iOManager = iOManager ?? throw new ArgumentNullException(nameof(iOManager));
            _hTTPService = hTTPService ?? throw new ArgumentNullException(nameof(hTTPService));
            _wallpaperService = wallpaperService ?? throw new ArgumentNullException(nameof(wallpaperService));
        }

        public ICommand SaveImageAs => new RelayCommand(async () =>

        await SaveItem());

        public ICommand SetAsWallpaper => new RelayCommand(async () =>
       {
           await _wallpaperService.SetAsAsync(SelectedImage.URI);
       });

        public ICommand SetAsLockscreen => new RelayCommand(async () =>
        {
            await _wallpaperService.SetAsAsync(SelectedImage.URI, setAs: SetAs.Lockscreen);
        });

        public ICommand ToLeft => new RelayCommand(async () => await MoveLeft());
        public ICommand ToRight => new RelayCommand(async () => await MoveRight());

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(ImageDetailNavigationParams imageDetailNavigationArgs, NavigationMode navigationMode)
        {
            Source = imageDetailNavigationArgs.Source;
            _count = _hTTPService.GetCount();
            if (!string.IsNullOrEmpty(imageDetailNavigationArgs.Id) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.FirstOrDefault(i => i.Id == imageDetailNavigationArgs.Id);
            }
            else if (!string.IsNullOrEmpty(imageDetailNavigationArgs.Name) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.FirstOrDefault(i => i.Name == imageDetailNavigationArgs.Name);
            }
            else
            {
                var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SpotlightViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage
                        = Source.FirstOrDefault(i => i.Id == selectedImageId);
                }
            }
           
            SelectedImage.URI = await _hTTPService.DownloadByIdAsync(ImageNameManager.GetId(SelectedImage.Name), SelectedImage.Name,null, _iOManager.DownloadPath);
            RaisePropertyChanged(nameof(SelectedImage));

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(SpotlightViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public async Task<string> DownLoadSelectedAsync()
        {
            return await _hTTPService.DownLoadAsync(new Uri(SelectedImage.URI), ImageNameManager.ResultPathGenerator(SelectedImage.URI, _iOManager.DownloadPath, SelectedImage.Id, SelectedImage.Name));
        }

        public async Task MoveLeft()
        {
            var newId = GetNewId();
            if (Source.Any(e => e.Id == newId))
            {
                SelectedImage = Source.FirstOrDefault(e => e.Id == newId);
                SelectedImage.URI = await _hTTPService.DownloadByIdAsync(newId, SelectedImage.Name, ImageNameManager.ResultPathGenerator(SelectedImage.URI, _iOManager.DownloadPath, SelectedImage.Id, SelectedImage.Name), null);
                RaisePropertyChanged(nameof(SelectedImage));
            }
        }

        public async Task MoveRight()
        {
            var newId = GetNewId(false);
            if (Source.Any(e => e.Id == newId))
            {
                SelectedImage = Source.FirstOrDefault(e => e.Id == newId);
                SelectedImage.URI = await _hTTPService.DownloadByIdAsync(newId, SelectedImage.Name, ImageNameManager.ResultPathGenerator(SelectedImage.URI, _iOManager.DownloadPath, SelectedImage.Id, SelectedImage.Name), null);
                RaisePropertyChanged(nameof(SelectedImage));
            }
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(SpotlightViewModel.ImageGalleryAnimationClose, _image);
        }

        private async Task SaveItem()
        {
            await _iOManager.SaveImageAs(SelectedImage.URI);
        }

        private string GetNewId(bool toLeft = true)
        {
            if (toLeft)
            {
                var currentIndex = Source.IndexOf(SelectedImage);
                if (currentIndex != 0)
                {
                    var nextIndex = --currentIndex;
                    return Source.ElementAt(nextIndex).Id;
                }
            }
            else
            {
                var currentIndex = Source.IndexOf(SelectedImage);
                if (currentIndex != Source.IndexOf(Source.Last()))
                {
                    var nextIndex = ++currentIndex;
                    return Source.ElementAt(nextIndex).Id;
                }
            }
            return "1";
        }

        public string FullSizedImage
        {
            get => _fullsizedImage;
            set
            {
                Set(ref _fullsizedImage, value);
            }
        }

        public ImageDTO SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ApplicationData.Current.LocalSettings.SaveString(SpotlightViewModel.ImageGallerySelectedIdKey, SelectedImage.Id);
            }
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }
    }
}
