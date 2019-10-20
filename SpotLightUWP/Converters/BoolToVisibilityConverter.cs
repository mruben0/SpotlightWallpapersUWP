using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SpotLightUWP.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolVlue)
            {
                if (parameter is string stringParam && stringParam == "reverse")
                {
                    return boolVlue ? Visibility.Collapsed : Visibility.Visible;
                }
                else
                {
                    return boolVlue ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            throw new ArgumentException(nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
