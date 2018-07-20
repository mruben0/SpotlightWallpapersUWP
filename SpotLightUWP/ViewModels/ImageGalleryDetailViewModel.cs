using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Helpers;
using SpotLightUWP.Models;
using SpotLightUWP.Services;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SpotLightUWP.ViewModels
{
    public class ImageGalleryDetailViewModel : ViewModelBase
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private IOManager IOManager => Locator.IOManager;
        private HTTPService _httpService => Locator.HTTPService;
        private WallpaperService WallpaperService => Locator.WallpaperService;
        private static UIElement _image;
        private ImageDTO _selectedImage;
        private ObservableCollection<ImageDTO> _source;
        private string _fullsizedImage;

        public ImageGalleryDetailViewModel()
        {
        }

        public ICommand SaveImageAs => new RelayCommand(async () => await SaveItem());

        public ICommand SetAsWallpaper => new RelayCommand( async() =>
        {
            await WallpaperService.SetAsAsync(SelectedImage.URI);
        });

        public ICommand SetAsLockscreen => new RelayCommand(async() =>
        {
            await WallpaperService.SetAsAsync(SelectedImage.URI,setAs: SetAs.Lockscreen);
        });

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(ImageDetailNavigationParams imageDetailNavigationArgs, NavigationMode navigationMode)
        {
            Source = imageDetailNavigationArgs.Source;

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
                    SelectedImage = Source.FirstOrDefault(i => i.Id == selectedImageId);
                }
            }

            SelectedImage.URI = await _httpService.DownloadByIdAsync(SelectedImage.Id);

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(SpotlightViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public async Task<string> DownLoadSelectedAsync()
        {
            return await _httpService.DownloadByIdAsync(SelectedImage.Id);
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(SpotlightViewModel.ImageGalleryAnimationClose, _image);
        }

        private async Task SaveItem()
        {
           await IOManager.SaveImageAs((ImageDTO)SelectedImage);
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
               // UpdateImage();
            }
        }

        public void UpdateImage()
        {
            Task.Run(async () =>
            {
                FullSizedImage = await _httpService.DownloadByIdAsync(SelectedImage.Id);
            }).Wait();
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

    }
}
