using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListBinding
{
   public class Employee : INotifyPropertyChanged
   {
      private string _name;
      private string _title;
      private DateTime _startDate;

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

      public DateTime StartDate
      {
         get { return _startDate; }
         set
         {
            _startDate = value;
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

         list.Add(new Employee() { Name = "John", Title = "ir.", StartDate = new DateTime(1956, 4, 26)});
         list.Add(new Employee() { Name = "Rob", Title = "ir.", StartDate = new DateTime(1960, 1, 1) });
         list.Add(new Employee() { Name = "Rogier", Title = "dr. ir.", StartDate = new DateTime(1960, 4, 26) });
         list.Add(new Employee() { Name = "Nel", Title = "drs. ing.", StartDate = new DateTime(1958, 2, 27) });

         return list;
      }

   }
}
