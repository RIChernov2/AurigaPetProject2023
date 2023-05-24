using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AurigaPetProject2023.UIviaWPF.Windows.Converters
{
    public class DateTimeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime < DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
