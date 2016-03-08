using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using TestAdvices.Model;
using TestAdvices.ViewModel.Commands;

namespace TestAdvices.ViewModel
{
   public class AdviceViewModel : INotifyPropertyChanged
   {
      #region Interface to View

      private string _adviceSummaryText;

      public ObservableCollection<VmAdvice> VmAdvices { get; private set; } 
      public ICommand CommitTransitionCommand { get; private set; }

      public string AdviceSummaryText
      {
         get { return _adviceSummaryText; }
         set { _adviceSummaryText = value; OnPropertyChanged(); }
      }

      #endregion

      private AdviceDataService _adviceDataService;

      public AdviceViewModel()
         : this(new AdviceDataService())
      {
      }

      public AdviceViewModel(AdviceDataService adviceDataService)
      {
         Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");

         _adviceDataService = adviceDataService;

         LoadVmAdvices();
         LoadCommands();
         UpdateAdviceSummaryText();
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
         {
            EvaluateEnableStates();
            UpdateAdviceSummaryText();
         }
      }

      private void UpdateAdviceSummaryText()
      {
         int cntActive = VmAdvices.Count(x => x.State == VmAdviceState.Active);

         switch (cntActive)
         {
            case 0:
               AdviceSummaryText = "Er zijn geen adviezen actief";
               break;

            case 1:
               AdviceSummaryText = "Er is een advies actief";
               break;

            default:
               AdviceSummaryText = string.Format("Er zijn {0} adviezen actief", cntActive);
               break;
         }
      }

      private void EvaluateEnableStates()
      {
         var advicesStarting  = VmAdvices.Where(x => x.State == VmAdviceState.Starting).ToList();   // Can only be one
         var advicesStopping  = VmAdvices.Where(x => x.State == VmAdviceState.Stopping).ToList();   // Can be more than one

         foreach (var vmAdvice in VmAdvices)
            vmAdvice.EvaluateEnableState(advicesStarting, advicesStopping);
      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
