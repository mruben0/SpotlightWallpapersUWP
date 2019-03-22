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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SpotLightUWP.ViewModels
{
    public class BingImageViewModel : ViewModelBase
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private IOManager IOManager => Locator.IOManager;
        private HTTPService _httpService => Locator.HTTPService;
        private WallpaperService WallpaperService => Locator.WallpaperService;
        private static UIElement _image;
        private ObservableCollection<ImageDTO> _source;
        private string _fullsizedImage;
        private DataService _dataService;
        private int _id;

        public BingImageViewModel()
        {
            ImgPath = "a/b";
            ImageDTOList = new List<ImageDTO>();
            _dataService = new DataService();
            IOManager.Initialize(IOManagerParams.Bing);
        }

        public ICommand SaveImageAs => new RelayCommand(async () => await SaveItem());

        public ICommand SetAsWallpaper => new RelayCommand(async () =>
        {
            await WallpaperService.SetAsAsync(ImgPath);
        });

        public ICommand SetAsLockscreen => new RelayCommand(async () =>
        {
            await WallpaperService.SetAsAsync(ImgPath, setAs: SetAs.Lockscreen);
        });

        public ICommand ToLeft => new RelayCommand(async () => await MoveLeft());
        public ICommand ToRight => new RelayCommand(async () => await MoveRight());

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(NavigationMode navigationMode)
        {
            await _dataService.InitializeAsync(1, IOManagerParams.Bing);
            ImageDTOList = _dataService.ImageDTOList;
            try
            {
                Image = ImageDTOList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            _id = ImageDTOList.IndexOf(Image);

            ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), IOManager.DownloadPath);
            RaisePropertyChanged(nameof(ImgPath));

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(SpotlightViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public async Task MoveLeft()
        {
            if (_id > 0)
            {
                _id -= 1;
                if (ImageDTOList[_id] != null)
                {
                    Image = ImageDTOList[_id];
                    ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), IOManager.DownloadPath);
                    RaisePropertyChanged(nameof(ImgPath));
                }
            }
        }

        public async Task MoveRight()
        {
            if (_id < ImageDTOList.Count() - 1)
            {
                _id += 1;
                if (ImageDTOList[_id] != null)
                {
                    Image = ImageDTOList[_id];
                    ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), IOManager.DownloadPath);
                    RaisePropertyChanged(nameof(ImgPath));
                }
            }
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(SpotlightViewModel.ImageGalleryAnimationClose, _image);
        }

        private async Task SaveItem()
        {
            await IOManager.SaveImageAs(ImgPath);
        }

        public string FullSizedImage
        {
            get => _fullsizedImage;
            set
            {
                Set(ref _fullsizedImage, value);
            }
        }

        public ImageDTO Image;

        public List<ImageDTO> ImageDTOList;

        private string _path;

        public string ImgPath
        {
            get { return _path; }
            set { _path = value; }
        }

        public ObservableCollection<ImageDTO> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }
    }
}
