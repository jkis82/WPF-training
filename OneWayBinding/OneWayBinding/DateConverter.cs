using System;
using System.Globalization;
using System.Windows.Data;

namespace ListBinding
{
   public class DateConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return ((DateTime) value).ToString("d");
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }
}
