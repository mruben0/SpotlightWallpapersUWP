using CommonServiceLocator;
using Core.Models;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace SpotLightUWP
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;
        private IConfigsService _configsService;
        private Configs configs;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);
            IBackgroundTaskInstance taskInstance = args.TaskInstance;
            _configsService = ServiceLocator.Current.GetInstance<IConfigsService>();
            configs = _configsService.GetConfigs();

            if (taskInstance.Task.Name == "BingDaily")
            {
                await ChangeDailyWallpaperAsync();
            }
            if (taskInstance.Task.Name == "BingNewImageTrigger")
            {
                await NewImageNotifyAsync();
            }
        }

        private async Task NewImageNotifyAsync()
        {
            var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            var bingService = ServiceLocator.Current.GetInstance<IBingHTTPService>();
            var lastImage = await bingService.GetLastImage();
            configs.LastBackgroundJobDate = DateTimeOffset.Now;
            if (configs.LastNotifiedImageUri != lastImage.URI)
            {
                dialogService.ShowNotification("Spotlight Wallpapers", "Hey, There are new images, click to see them", lastImage.URI);
                configs.LastNotifiedImageUri = lastImage.URI;
                _configsService.SaveConfigs(configs);
            }
        }

        private async Task ChangeDailyWallpaperAsync()
        {
            var wallpaperService = ServiceLocator.Current.GetInstance<IWallpaperService>();
            var bingService = ServiceLocator.Current.GetInstance<IBingHTTPService>();
            var httpService = ServiceLocator.Current.GetInstance<IHTTPService>();
            var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            var ioManager = ServiceLocator.Current.GetInstance<IIOManager>();
            var lastImage = await bingService.GetLastImage();
            var lasImagePath = await httpService.DownLoadAsync(new Uri(lastImage.URI), ioManager.DailyWallpaperFolderPath);
            await wallpaperService.SetAsAsync(lasImagePath);
            configs.LastBackgroundJobDate = DateTimeOffset.Now;
            if (configs.LastChangedImageUri != lastImage.URI)
            {
                dialogService.ShowNotification("Spotlight Wallpapers", "Hey, Your wallpaper has been changed, you can turn off this from settings", lastImage.URI);
                configs.LastChangedImageUri = lastImage.URI;
                _configsService.SaveConfigs(configs);
            }
        }

        public App()
        {
            InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size() { Height = 1200, Width = 820 };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(ViewModels.SpotlightViewModel), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
