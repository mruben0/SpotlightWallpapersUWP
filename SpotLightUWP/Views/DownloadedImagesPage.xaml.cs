using SpotLightUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace SpotLightUWP.Views
{
    public sealed partial class DownloadedImagesPage : Page
    {
       
        private DownloadedImagesViewModel ViewModel
        {
            get { return DataContext as DownloadedImagesViewModel; }
        }

        public DownloadedImagesPage()
        {
            InitializeComponent();
            Loaded += SpotlightPage_Loaded;
        }

        private async void SpotlightPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.InitializeAsync(gridView);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                await ViewModel.LoadAnimationAsync();
            }
        }
    }
}
