using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using TestAdvices.Model;
using TestAdvices.Utilities;
using TestAdvices.ViewModel.Commands;

namespace TestAdvices.ViewModel
{
   public class CustomSelectViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      #region Interface to View

      private string _adviceSummaryText;
      private string _caption;

      public ObservableCollection<VmHmiElementInfo> HmiElements { get; private set; } 
      public ICommand CommitTransitionCommand { get; private set; }

      public string AdviceSummaryText
      {
         get { return _adviceSummaryText; }
         set { _adviceSummaryText = value; OnPropertyChanged(); }
      }

      public string Caption
      {
         get         { return _caption; }
         private set { if (_caption != value) { _caption = value; OnPropertyChanged(); } }
      }

      #endregion

      private List<HmiElementInfo> _hmiElementList = new List<HmiElementInfo>();

      public CustomSelectViewModel()
      {
         Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL"); // Todo: Remove

         HmiElements = new ObservableCollection<VmHmiElementInfo>();

         CreateHmiElements(new AdviceDataService().GetAllAdvices());    // Todo: Remove
         LoadCommands();
      }
      
      #region Commands

      private void LoadCommands()
      {
         CommitTransitionCommand = new CustomCommand(CommitTransition, CanCommitTransition);
      }

      /// <summary>
      /// The operator clicked the button "Ok"
      /// </summary>
      /// <param name="obj"></param>
      private void CommitTransition(object obj)
      {
         foreach (var vmAdvice in HmiElements)
            vmAdvice.CommitTransition();

         List<HmiElementInfo> newInfo = new List<HmiElementInfo>();

         foreach (VmHmiElementInfo info in HmiElements)
            newInfo.Add(info.Advice);

         UpdateHmiElements(newInfo);
      }

      private bool CanCommitTransition(object obj)
      {
         return true;
      }

      #endregion
      
      #region Implement ICustomCommandViewModel

      /// <summary>
      /// Create the hmi elements for this viewmodel.
      /// </summary>
      /// <param name="hmiElementInfos"></param>
      public void CreateHmiElements(IEnumerable<HmiElementInfo> hmiElementInfos)
      {
         _hmiElementList = hmiElementInfos.ToList();

         string commonPrefix = Resources.Resources.Advices;

         if (_hmiElementList.Count >= 2)
         {
            commonPrefix = CommonStringPrefix.Of(_hmiElementList.Select(x => x.Description).ToList());

            RemoveCommonPrefix(commonPrefix, _hmiElementList);
         }

         Caption = commonPrefix;

         ReloadObservableHmiElements(_hmiElementList.Where(x => x.IsVisible));
         UpdateAdviceSummaryText();
      }

      /// <summary>
      /// Update the hmi elements fro this viewmodel.
      /// </summary>
      /// <param name="hmiElementInfos"></param>
      public void UpdateHmiElements(IEnumerable<HmiElementInfo> hmiElementInfos)
      {
         var updatedHmiElementInfos = new List<HmiElementInfo>(_hmiElementList);

         foreach (var hmiElementInfo in hmiElementInfos)
         {
            var updatedHmiElement = updatedHmiElementInfos.Single(x => x.Label == hmiElementInfo.Label);

            updatedHmiElement.IsEnabled       = hmiElementInfo.IsEnabled;
            updatedHmiElement.IsActive        = hmiElementInfo.IsActive;
            updatedHmiElement.DetectionStatus = hmiElementInfo.DetectionStatus;
            updatedHmiElement.IsVisible       = hmiElementInfo.IsVisible;
         }

         ReloadObservableHmiElements(updatedHmiElementInfos.Where(x => x.IsVisible));
         UpdateAdviceSummaryText();
      }

      /// <summary>
      /// Remove a common prefix from all hmi element descriptions.
      /// </summary>
      /// <param name="commonPrefix"></param>
      /// <param name="hmiElements"></param>
      private void RemoveCommonPrefix(string commonPrefix, IList<HmiElementInfo> hmiElements)
      {
         foreach (var hmiElement in hmiElements)
         {
            var description = hmiElement.Description.Remove(0, commonPrefix.Length);
            hmiElement.Description = char.ToUpper(description[0]) + description.Substring(1);
         }
      }

      private void ReloadObservableHmiElements(IEnumerable<HmiElementInfo> hmiElementInfos)
      {
         HmiElements.Clear();

         foreach (var hmiElementInfo in hmiElementInfos)
         {
            VmHmiElementInfo newVmAdvice = new VmHmiElementInfo(hmiElementInfo);

            newVmAdvice.PropertyChanged += NewVmAdviceOnPropertyChanged;   // Alternative for EventAggregator

            HmiElements.Add(newVmAdvice);
         }
      }

      /// <summary>
      /// Called to get the text displayed in the combobox main text area.
      /// </summary>
      /// <param name="e"></param>
      private void UpdateAdviceSummaryText()
      {
         int cntActive = HmiElements.Count(x => x.State == VmAdviceState.Active);

         switch (cntActive)
         {
            case 0:
               AdviceSummaryText = Resources.Resources.AdvicesNoneActive;
               break;

            case 1:
               AdviceSummaryText = Resources.Resources.AdvicesOneActive;
               break;

            default:
               AdviceSummaryText = string.Format(Resources.Resources.AdvicesMultiActive, cntActive);
               break;
         }
      }

      #endregion

      private void NewVmAdviceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
      {
         if (propertyChangedEventArgs.PropertyName == "State")
            EvaluateEnableStates();
      }
 
      private void EvaluateEnableStates()
      {
         var advicesStarting  = HmiElements.Where(x => x.State == VmAdviceState.Starting).ToList();   // Can only be one
         var advicesStopping  = HmiElements.Where(x => x.State == VmAdviceState.Stopping).ToList();   // Can be more than one

         foreach (var vmAdvice in HmiElements)
            vmAdvice.EvaluateEnableState(advicesStarting, advicesStopping);
      }

      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
