using System;
using System.Globalization;
using System.Windows.Data;
using TestAdvices.ViewModel;

namespace TestAdvices.View.Converter
{
   public class StateToTextConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         try
         {
            switch ((VmAdviceState)value)
            {
               case VmAdviceState.InActive: return Resources.Resources.StateInActive;
               case VmAdviceState.Starting: return Resources.Resources.StateStarting;
               case VmAdviceState.Active  : return Resources.Resources.StateActive  ;
               case VmAdviceState.Stopping: return Resources.Resources.StateStopping;
            }
         }
         catch (Exception)
         {
         }

         return "???";
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }
   }
}
