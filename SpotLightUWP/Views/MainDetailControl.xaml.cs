using System;

using SpotLightUWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpotLightUWP.Views
{
    public sealed partial class MainDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(MainDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MainDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MainDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
