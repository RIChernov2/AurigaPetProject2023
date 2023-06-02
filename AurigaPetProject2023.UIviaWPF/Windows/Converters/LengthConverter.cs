using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AurigaPetProject2023.UIviaWPF.Windows.Converters
{
    // Уменьшение длины родителя на 20
    public class LengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameterDouble, CultureInfo culture)
        {
            //return ((double)value)-20;
            return ((double)value) - System.Convert.ToDouble(parameterDouble);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

