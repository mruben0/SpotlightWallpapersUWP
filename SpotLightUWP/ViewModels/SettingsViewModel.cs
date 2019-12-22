using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Helpers;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using System;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;

namespace SpotLightUWP.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;
        private string _versionDescription;
        private bool shouldUpdateDaily;
        private ICommand _switchThemeCommand;
        private readonly IBackgroundTaskService _backgroundTaskService;
        private readonly IWallpaperService _wallpaperService;
        private readonly IHTTPService _hTTPService;
        private readonly IIOManager _iOManager;
        private readonly IBingHTTPService _bingHTTPService;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { Set(ref _elementTheme, value); }
        }

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { Set(ref _versionDescription, value); }
        }

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public ICommand ShwitchDailyWallpaperModeCommand => new RelayCommand(async () =>
        {
            if (ShouldUpdateDaily)
            {
                _backgroundTaskService.RegisterBackgroundTask("BingDaily", new TimeTrigger(60 * 24, false), true);
         
                var lastImage = await _bingHTTPService.GetLastImage();
                var lasImagePath = await _hTTPService.DownLoadAsync(new Uri(lastImage.URI), _iOManager.DailyWallpaperFolderPath);
                await _wallpaperService.SetAsAsync(lasImagePath);
            }
            else
            {
                _backgroundTaskService.UnRegisterBackgroundTask("BingDaily", true);
            }
        });

        public bool ShouldUpdateDaily
        {
            get { return shouldUpdateDaily; }
            set { Set(ref shouldUpdateDaily, value); }
        }

        public SettingsViewModel(IBackgroundTaskService backgroundTaskService,
                                 IWallpaperService wallpaperService,
                                 IHTTPService hTTPService,
                                 IIOManager iOManager,
                                 IBingHTTPService bingHTTPService)
        {
            _backgroundTaskService = backgroundTaskService ?? throw new System.ArgumentNullException(nameof(backgroundTaskService));
            _wallpaperService = wallpaperService ?? throw new System.ArgumentNullException(nameof(wallpaperService));
            _hTTPService = hTTPService ?? throw new System.ArgumentNullException(nameof(hTTPService));
            _iOManager = iOManager ?? throw new System.ArgumentNullException(nameof(iOManager));
            _bingHTTPService = bingHTTPService ?? throw new ArgumentNullException(nameof(bingHTTPService));
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
            ShouldUpdateDaily = _backgroundTaskService.HasRegistered("BingDaily");
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
