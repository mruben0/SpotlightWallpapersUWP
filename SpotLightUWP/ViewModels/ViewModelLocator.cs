using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SpotLightUWP.Helpers;
using SpotLightUWP.Services;
using SpotLightUWP.Views;

namespace SpotLightUWP.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register(() => new WallpaperService());
            SimpleIoc.Default.Register(() => new IOManager());
            SimpleIoc.Default.Register(() => new HTTPService());
            SimpleIoc.Default.Register(() => new DialogService());
            SimpleIoc.Default.Register(() => new ImageNameManager());
            SimpleIoc.Default.Register(() => new DataService());

            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<ImageGalleryViewModel, ImageGalleryPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => ServiceLocator.Current.GetInstance<ImageGalleryDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => ServiceLocator.Current.GetInstance<ImageGalleryViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public WallpaperService WallpaperService => ServiceLocator.Current.GetInstance<WallpaperService>();

        public IOManager IOManager => ServiceLocator.Current.GetInstance<IOManager>();

        public HTTPService HTTPService => ServiceLocator.Current.GetInstance<HTTPService>();

        public DialogService DialogService => ServiceLocator.Current.GetInstance<DialogService>();

        public ImageNameManager ImageNameManager => ServiceLocator.Current.GetInstance<ImageNameManager>();

        public DataService DataService => ServiceLocator.Current.GetInstance<DataService>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
