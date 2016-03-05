using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAdvices.Model;

namespace TestAdvices.ViewModel
{
   public enum VmAdviceState
   {
      NotActive,
      Starting,
      Active,
      Stopping
   }

   public class VmAdvice
   {
      public VmAdviceState State  { get; set; }
      public Advice        Advice { get; set; }

      public VmAdvice(Advice advice)
      {
         this.Advice = advice;
         this.State  = (advice.IsActive) ? VmAdviceState.Active : VmAdviceState.NotActive;
      }
   }
}
