using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string iconCode = value as string;

            if (string.IsNullOrEmpty(iconCode))
                return null;

            return $"https://openweathermap.org/img/wn/{iconCode}@2x.png";
        }

        // View에서 ViewModel로의 변환은 필요하지 않으므로 NotImplementedException을 던집니다.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
