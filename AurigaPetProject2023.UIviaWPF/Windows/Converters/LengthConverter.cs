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


//public class WidthConverter : IMultiValueConverter
//{
//    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
//    {
//        if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
//            return null;

//        double parentWidth = (double)values[0];
//        double newWidth = (double)values[1];

//        if (newWidth > parentWidth)
//            return parentWidth;
//        else
//            return newWidth;
//    }

//    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }
//}
