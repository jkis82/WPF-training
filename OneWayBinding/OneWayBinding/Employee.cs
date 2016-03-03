using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OneWayBinding
{
   public class Employee : INotifyPropertyChanged
   {
      private string _name;
      private string _title;

      public event PropertyChangedEventHandler PropertyChanged;

      public string Name
      {
         get { return _name; }
         set
         {
            _name = value;
            RaisePropertyChanged(); 
         }
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
      private void RaisePropertyChanged([CallerMemberName] string caller = "")
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
      }

      public static ObservableCollection<Employee> GetEmployees()
      {
         var list = new ObservableCollection<Employee>();

         list.Add(new Employee() { Name = "John", Title = "ir."});
         list.Add(new Employee() { Name = "Rob", Title = "ir."});
         list.Add(new Employee() { Name = "Rogier", Title = "dr. ir."});
         list.Add(new Employee() { Name = "Nel", Title = "drs. ing."});

         return list;
      }

   }
}
