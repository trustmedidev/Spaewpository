using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class ItemOpeningStockEL
    {
      public int DCode { get; set; }
      public int ItemCd { get; set; }
      public string Item { get; set; }
      public int UnitCd { get; set; }
      public string Unit { get; set; }
      public DateTime ExpiryDt { get; set; }
      public int SubUnitCd { get; set; }
      public decimal SubQty { get; set; }
      public decimal Quantity { get; set; }
      public decimal Rate { get; set; }
      public bool ActiveYN { get; set; }
   
    }
}
