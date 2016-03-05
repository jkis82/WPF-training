using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdvices.Model
{
   public class Advice
   {
      public int    Id       { get; set; }
      public string Name     { get; set; }
      public bool   IsActive { get; set; }

      public void Update(Advice advice)
      {
         this.IsActive = advice.IsActive;
      }
   }
}
