using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvices.Model
{
   public class AdviceDataService
   {
      private List<Advice> _lstAdvices;

      public AdviceDataService()
      {
         LoadAdvices();
      }

      private void LoadAdvices()
      {
         _lstAdvices = new List<Advice>();

         _lstAdvices.Add(new Advice() { Id = 1, IsActive = false, Name = "Advice 1"});
         _lstAdvices.Add(new Advice() { Id = 2, IsActive = false, Name = "Advice 2"});
         _lstAdvices.Add(new Advice() { Id = 3, IsActive = false, Name = "Advice 3"});
         _lstAdvices.Add(new Advice() { Id = 4, IsActive = false, Name = "Advice 4"});
         _lstAdvices.Add(new Advice() { Id = 5, IsActive = false, Name = "Advice 5"});
         _lstAdvices.Add(new Advice() { Id = 6, IsActive = false, Name = "Advice 6"});
         _lstAdvices.Add(new Advice() { Id = 7, IsActive = false, Name = "Advice 7"});
      }

      public Advice GetAdvice(int Id)
      {
         return _lstAdvices.FirstOrDefault(x => x.Id == Id);
      }

      public List<Advice> GetAllAdvices()
      {
         return _lstAdvices;
      }

      public void UpdateAdvice(Advice advice)
      {
         if (advice == null)
            throw new ArgumentNullException("advice");

         Advice adviceToUpdate = GetAdvice(advice.Id);

         if (adviceToUpdate == null)
            throw new Exception("Cannot find advice with id: " + advice.Id.ToString());

         adviceToUpdate.Update(advice);
      }
   }
}
