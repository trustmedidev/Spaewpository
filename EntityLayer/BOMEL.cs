using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class BOMEL
    {
       public int ItemCd { get; set; }
       public int UnitCd { get; set; }
       public string Item { get; set; }
       public string Unit { get; set; }

       public decimal Qty { get; set; }
       public decimal Rate { get; set; }
       public bool DActiveYN { get; set; }


    }
}
