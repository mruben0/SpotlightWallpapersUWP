using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;

using SpotLightUWP.Models;
using SpotLightUWP.Services;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace SpotLightUWP.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;


        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public MainViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            //var data = await SampleDataService.GetSampleModelDataAsync();

            //foreach (var item in data)
            //{
            //    SampleItems.Add(item);
            //}

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }

        public ICommand TestingCommand => new RelayCommand(async () =>
        {
            var wallpaperService = Locator.WallpaperService;
            await wallpaperService.PickAndSetWallpaper();
        });
    }
}
