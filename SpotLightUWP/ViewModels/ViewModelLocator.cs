﻿using System;
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

            SimpleIoc.Default.Register<ShellViewModel>();
            Register<SpotlightViewModel, SpotlightPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<DownloadedImagesViewModel, DownloadedImagesPage>();
        }

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => ServiceLocator.Current.GetInstance<ImageGalleryDetailViewModel>();

        public SpotlightViewModel SpotlightViewModel => ServiceLocator.Current.GetInstance<SpotlightViewModel>();
    
        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public WallpaperService WallpaperService => ServiceLocator.Current.GetInstance<WallpaperService>();

        public IOManager IOManager => ServiceLocator.Current.GetInstance<IOManager>();

        public HTTPService HTTPService => ServiceLocator.Current.GetInstance<HTTPService>();

        public DialogService DialogService => ServiceLocator.Current.GetInstance<DialogService>();

        public ImageNameManager ImageNameManager => ServiceLocator.Current.GetInstance<ImageNameManager>();

        public DownloadedImagesViewModel DownloadedImagesViewModel => ServiceLocator.Current.GetInstance<DownloadedImagesViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
