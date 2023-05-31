using System;
using System.Globalization;
using System.Windows.Data;

namespace AurigaPetProject2023.UIviaWPF.Windows.Converters
{
    public class DiscountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte doubleValue)
            {
                return $"Скидка {doubleValue}%";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
