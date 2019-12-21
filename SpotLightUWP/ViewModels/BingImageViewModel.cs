using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Models;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SpotLightUWP.ViewModels
{
    public class BingImageViewModel : ViewModelBase
    {
        private static UIElement _image;
        private ObservableCollection<ImageDTO> _source;
        private string _fullsizedImage;
        private int _id;
        private ImageDTO _imageDto;
        private string _path;
        private readonly IHTTPService _httpService;
        private readonly IDataService _dataService;
        private readonly IIOManager _iOManager;
        private readonly IWallpaperService _wallpaperService;
        private readonly IDialogService _dialogService;

        public BingImageViewModel(IHTTPService httpService,
                                 IDataService dataService,
                                 IIOManager iOManager,
                                 IWallpaperService wallpaperService,
                                 IDialogService dialogService)
        {
            ImgPath = "a/b";
            ImageDTOList = new List<ImageDTO>();
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _iOManager = iOManager ?? throw new ArgumentNullException(nameof(iOManager));
            _wallpaperService = wallpaperService ?? throw new ArgumentNullException(nameof(wallpaperService));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public async Task InitializeAsync(NavigationMode navigationMode)
        {
            _iOManager.Initialize(IOManagerParams.Bing);
            await _dataService.InitializeAsync(1, IOManagerParams.Bing);
            ImageDTOList = _dataService.ImageDTOList;
            try
            {
                Image = ImageDTOList.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            _id = ImageDTOList.IndexOf(Image);

            ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), _iOManager.DownloadPath);
            RaisePropertyChanged(nameof(ImgPath));

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(SpotlightViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public ICommand SaveImageAs => new RelayCommand(async () => await SaveItem());

        public ICommand SetAsWallpaper => new RelayCommand(async () =>
        {
            await _wallpaperService.SetAsAsync(ImgPath);
             _dialogService.ShowNotification("DONE", "Wallpaper successfully has been set");
        });

        public ICommand SetAsLockscreen => new RelayCommand(async () =>
        {
            await _wallpaperService.SetAsAsync(ImgPath, setAs: SetAs.Lockscreen);
             _dialogService.ShowNotification("Done","LockScreen successfully has been set");
        });

        public ICommand SethBothCommand => new RelayCommand(async () =>
        {
            await _wallpaperService.SetAsAsync(ImgPath);
            await _wallpaperService.SetAsAsync(ImgPath, setAs: SetAs.Lockscreen);
             _dialogService.ShowNotification("DONE", "Wallpaper and LockScreen successfully has been set");
        });

        public ICommand ToLeft => new RelayCommand(async () => await MoveLeft(), _id > 0);

        public ICommand ToRight => new RelayCommand(async () => await MoveRight(), _id < ImageDTOList.Count() - 1);

        public void SetImage(UIElement image) => _image = image;

        public async Task MoveLeft()
        {
            if (_id > 0)
            {
                _id -= 1;
                if (ImageDTOList[_id] != null)
                {
                    Image = ImageDTOList[_id];
                    ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), _iOManager.DownloadPath);
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
                    ImgPath = await _httpService.DownLoadAsync(new Uri(Image.URI), _iOManager.DownloadPath);
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
            await _iOManager.SaveImageAs(ImgPath);
        }

        public string FullSizedImage
        {
            get => _fullsizedImage;
            set
            {
                Set(ref _fullsizedImage, value);
            }
        }

        public ImageDTO Image
        {
            get { return _imageDto; }
            set
            {
                _imageDto = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        public List<ImageDTO> ImageDTOList;

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
