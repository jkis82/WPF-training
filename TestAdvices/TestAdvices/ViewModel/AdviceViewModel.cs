using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAdvices.Model;

namespace TestAdvices.ViewModel
{
   public class AdviceViewModel
   {
      #region Interface to View

      public ObservableCollection<VmAdvice> VmAdvices { get; private set; } 

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
      }

      private void LoadVmAdvices()
      {
         VmAdvices = new ObservableCollection<VmAdvice>();

         foreach (var advice in _adviceDataService.GetAllAdvices())
            VmAdvices.Add(new VmAdvice(advice));
      }
   }
}
