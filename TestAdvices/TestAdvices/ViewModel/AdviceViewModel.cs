using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAdvices.Model;
using TestAdvices.ViewModel.Commands;

namespace TestAdvices.ViewModel
{
   public class AdviceViewModel
   {
      #region Interface to View

      public ObservableCollection<VmAdvice> VmAdvices { get; private set; } 
      public ICommand CommitTransitionCommand { get; private set; }

      #endregion

      private AdviceDataService _adviceDataService;

      public AdviceViewModel()
         : this(new AdviceDataService())
      {
      }

      public AdviceViewModel(AdviceDataService adviceDataService)
      {
         _adviceDataService = adviceDataService;

         LoadVmAdvices();
         LoadCommands();
      }

      private void LoadCommands()
      {
         CommitTransitionCommand = new CustomCommand(CommitTransition, CanCommitTransition);
      }

      private void CommitTransition(object obj)
      {
         foreach (var vmAdvice in VmAdvices)
            vmAdvice.CommitTransition();
      }

      private bool CanCommitTransition(object obj)
      {
         return true;
      }

      private void LoadVmAdvices()
      {
         VmAdvices = new ObservableCollection<VmAdvice>();

         foreach (var advice in _adviceDataService.GetAllAdvices())
         {
            VmAdvice newVmAdvice = new VmAdvice(advice);

            newVmAdvice.PropertyChanged += NewVmAdviceOnPropertyChanged;   // Alternative for EventAggregator

            VmAdvices.Add(newVmAdvice);
         }
      }

      private void NewVmAdviceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
      {
         if (propertyChangedEventArgs.PropertyName == "State")
            EvaluateEnableStates();
      }

      private void EvaluateEnableStates()
      {
         var advicesStarting  = VmAdvices.Where(x => x.State == VmAdviceState.Starting).ToList();   // Can only be one
         var advicesStopping  = VmAdvices.Where(x => x.State == VmAdviceState.Stopping).ToList();   // Can be more than one

         foreach (var vmAdvice in VmAdvices)
            vmAdvice.EvaluateEnableState(advicesStarting, advicesStopping);
      }
   }
}
