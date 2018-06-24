using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

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

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
