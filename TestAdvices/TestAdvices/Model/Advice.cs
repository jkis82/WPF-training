using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvices.Model
{
   public class Advice : INotifyPropertyChanged
   {
      private bool   _isActive;
      private string _name;
      private int    _id;

      public int Id
      {
         get { return _id; }
         set { _id = value;  RaisePropertyChanged("Id"); }
      }

      public string Name
      {
         get { return _name; }
         set { _name = value; RaisePropertyChanged("Name") ;}
      }

      public bool IsActive
      {
         get { return _isActive; }
         set { _isActive = value; RaisePropertyChanged("IsActive"); }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void RaisePropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }

      public void Update(Advice advice)
      {
         this.IsActive = advice.IsActive;
      }
   }
}
