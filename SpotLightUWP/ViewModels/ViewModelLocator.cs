using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Services;
using SpotLightUWP.Services;
using SpotLightUWP.Services.Base;
using SpotLightUWP.Views;

namespace SpotLightUWP.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<NavigationServiceEx, NavigationServiceEx>();
            SimpleIoc.Default.Register<IWallpaperService, WallpaperService>();

            SimpleIoc.Default.Register<IHTTPService, HTTPService>();
            SimpleIoc.Default.Register<IBingHTTPService, BingHTTPService>();
            SimpleIoc.Default.Register<IIOManager, IOManager>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IBackgroundTaskService, BackgroundTaskService>();
            SimpleIoc.Default.Register<IConfigsService, ConfigsService>();

            SimpleIoc.Default.Register<ShellViewModel>();
            Register<SpotlightViewModel, SpotlightPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<DownloadedImagesViewModel, DownloadedImagesPage>();
            Register<BingImageViewModel, BingImage>();
        }

        public BingImageViewModel BingImageViewModel => ServiceLocator.Current.GetInstance<BingImageViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => ServiceLocator.Current.GetInstance<ImageGalleryDetailViewModel>();

        public SpotlightViewModel SpotlightViewModel => ServiceLocator.Current.GetInstance<SpotlightViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public WallpaperService WallpaperService => ServiceLocator.Current.GetInstance<WallpaperService>();

        public DialogService DialogService => ServiceLocator.Current.GetInstance<DialogService>();

        public DownloadedImagesViewModel DownloadedImagesViewModel => ServiceLocator.Current.GetInstance<DownloadedImagesViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
