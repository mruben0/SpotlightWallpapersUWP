using SpotLightUWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
