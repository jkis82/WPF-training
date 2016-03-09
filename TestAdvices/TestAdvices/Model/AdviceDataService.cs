using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvices.Model
{
   public class AdviceDataService
   {
      private List<HmiElementInfo> _lstAdvices;

      public AdviceDataService()
      {
         LoadAdvices();
      }

      private void LoadAdvices()
      {
         _lstAdvices = new List<HmiElementInfo>();

         for (int i = 1; i < 8; i++)
         {
            string fmtDescription = (i == 1) ? "dit is advies {0}" : "advies {0}";

            _lstAdvices.Add(new HmiElementInfo()
            {
               Id          = i,
               Description = "H/E procedure " + string.Format(fmtDescription, i),
               IsActive    = false,
               IsVisible   = true,
               IsEnabled   = true,
               Label       = string.Format("HMI100{0}", i)
            });
         }
      }

      public HmiElementInfo GetAdvice(int Id)
      {
         return _lstAdvices.FirstOrDefault(x => x.Id == Id);
      }

      public List<HmiElementInfo> GetAllAdvices()
      {
         return _lstAdvices;
      }

      public void UpdateAdvice(HmiElementInfo advice)
      {
         if (advice == null)
            throw new ArgumentNullException("advice");

         HmiElementInfo adviceToUpdate = GetAdvice(advice.Id);

         if (adviceToUpdate == null)
            throw new Exception("Cannot find advice with id: " + advice.Id.ToString());

         adviceToUpdate.Update(advice);
      }
   }
}
