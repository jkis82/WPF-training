using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAdvices.Model;
using TestAdvices.ViewModel.Commands;

namespace TestAdvices.ViewModel
{
   public enum VmAdviceState
   {
      InActive,
      Starting,
      Active,
      Stopping
   }

   public class VmAdvice : INotifyPropertyChanged
   {
      private VmAdviceState _state;
      private Advice        _advice;
      private bool          _isEnabled;

      public ICommand InvokeTransitionCommand { get; private set; }

      public VmAdviceState State
      {
         get { return _state; }
         set
         {
            _state = value;
            RaisePropertyChanged("State");
         }
      }

      public Advice Advice
      {
         get { return _advice; }
         set
         {
            _advice = value;
            RaisePropertyChanged("Advice");
         }
      }

      public bool IsEnabled
      {
         get { return _isEnabled; }
         set { _isEnabled = value; RaisePropertyChanged("IsEnabled"); }
      }

      public VmAdvice(Advice advice)
      {
         this.Advice    = advice;
         this.State     = (advice.IsActive) ? VmAdviceState.Active : VmAdviceState.InActive;
         this.IsEnabled = true;

         LoadCommands();
      }

      private void LoadCommands()
      {
         InvokeTransitionCommand = new CustomCommand(InvokeTransition, CanInvokeTransition);
      }

      private void InvokeTransition(object obj)
      {
         switch (State)    // TODO: Obfuscate this using a dictionary
         {
            case VmAdviceState.InActive:
               State = VmAdviceState.Starting;
               break;

            case VmAdviceState.Starting:
               State = VmAdviceState.InActive;
               break;

            case VmAdviceState.Active:
               State = VmAdviceState.Stopping;
               break;

            case VmAdviceState.Stopping:
               State = VmAdviceState.Active;
               break;
         }
      }

      private bool CanInvokeTransition(object obj)
      {
         return true;
      }

      public event PropertyChangedEventHandler PropertyChanged;

      internal void EvaluateEnableState(List<VmAdvice> advicesStarting, List<VmAdvice> advicesStopping)
      {
         if (advicesStarting.Count >= 1)
            IsEnabled = (State == VmAdviceState.Starting);
         else if (advicesStopping.Count >= 1)
            IsEnabled = (State == VmAdviceState.Stopping || State == VmAdviceState.Active);
         else
            IsEnabled = true;
      }


      private void RaisePropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }

      public void CommitTransition()
      {
         switch (State)
         {
            case VmAdviceState.Starting:
               State = VmAdviceState.Active;
               Advice.IsActive = true;
               break;

            case VmAdviceState.Stopping:
               State = VmAdviceState.InActive;
               Advice.IsActive = false;
               break;
         }
      }
   }
}
