using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvices.Model
{
   public class HmiElementInfo : INotifyPropertyChanged
   {
      private bool   _isActive;
      private string _description;
      private int    _id;
      private bool   _isVisible;
      private bool   _isEnabled;
      private string _label;
      private int?   _detectionStatus;

      public int Id
      {
         get { return _id; }
         set { _id = value;  RaisePropertyChanged("Id"); }
      }

      public string Description
      {
         get { return _description; }
         set { _description = value; RaisePropertyChanged("Description") ;}
      }

      public bool IsActive
      {
         get { return _isActive; }
         set { _isActive = value; RaisePropertyChanged("IsActive"); }
      }

      public bool IsVisible
      {
         get { return _isVisible; }
         set { _isVisible = value; RaisePropertyChanged("IsVisible"); }
      }

      public bool IsEnabled
      {
         get
         {
            return _isEnabled;
         }

         set
         {
            _isEnabled = value;
            RaisePropertyChanged("IsEnabled");
         }
      }

      public string Label
      {
         get
         {
            return _label;
         }

         set
         {
            _label = value;
            RaisePropertyChanged("Label");
         }
      }

      public int? DetectionStatus
      {
         get
         {
            return _detectionStatus;
         }

         set
         {
            _detectionStatus = value;
            RaisePropertyChanged("DetectionStatus");
         }
      }


      public event PropertyChangedEventHandler PropertyChanged;

      private void RaisePropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }

      public void Update(HmiElementInfo advice)
      {
         this.IsActive = advice.IsActive;
      }
   }
}
