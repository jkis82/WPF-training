using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OneWayBinding
{
   public class Employee : INotifyPropertyChanged
   {
      private string _name;
      private string _title;

      public string Name {
         get { return _name; }
         set { _name = value;
            RaisePropertyChanged(); 
         }
      }

      private void RaisePropertyChanged([CallerMemberName] string caller = "")
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
      }

      public string Title
      {
         get { return _title; }
         set
         {
            _title = value;
            RaisePropertyChanged();
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;
   }
}
