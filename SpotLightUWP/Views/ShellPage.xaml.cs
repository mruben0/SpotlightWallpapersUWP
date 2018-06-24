using System;
using SpotLightUWP.Services;
using SpotLightUWP.ViewModels;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SpotLightUWP.Views
{
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel
        {
            get { return DataContext as ShellViewModel; }
        }

        public ShellPage()
        {
            InitializeComponent();
            //HideNavViewBackButton();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView);
        }

        //private void HideNavViewBackButton()
        //{
        //    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 6))
        //    {
        //        navigationView.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
        //    }
        //}
    }
}
