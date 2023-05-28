using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AurigaPetProject2023.UIviaWPF.Windows.Converters
{
    public class UserShortInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IUserShortResponseInfo typedValues)
            {
                return $"ID = {typedValues.UserID}, Login = {typedValues.LoginName ??= "none"}, Phone = {typedValues.Phone ??= "none"}";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
