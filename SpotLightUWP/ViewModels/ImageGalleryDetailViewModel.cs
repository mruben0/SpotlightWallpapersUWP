using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

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
        private static UIElement _image;
        private object _selectedImage;
        private ObservableCollection<ImageDTO> _source;

        public object SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ApplicationData.Current.LocalSettings.SaveString(ImageGalleryViewModel.ImageGallerySelectedIdKey, ((ImageDTO)SelectedImage).Id.ToString());
            }
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ImageGalleryDetailViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = DataService.GetGalleryData().Result;
        }

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(string ImageId, NavigationMode navigationMode)
        {
            if (!string.IsNullOrEmpty(ImageId) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.FirstOrDefault(i => i.Id.ToString() == ImageId);
            }
            else
            {
                var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGalleryViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.Id.ToString() == selectedImageId);
                }
            }

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(ImageGalleryViewModel.ImageGalleryAnimationClose, _image);
        }
    }
}
