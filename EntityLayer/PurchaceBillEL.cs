using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
    public class PurchaceBillEL
    {
        public decimal TotBasicValue { get; set; }
        public decimal TotVal { get; set; }
        public decimal TotDisc { get; set; }
        public decimal TotValue { get; set; }
        //public string Unit { get; set; }
        //public DateTime ExpiryDt { get; set; }

        public string BatchNo { get; set; }
        public int BatchCd { get; set; }


        public int DCode { get; set; }
        public int ItemCd { get; set; }
        public string Item { get; set; }
        public int UnitCd { get; set; }
        public string Unit { get; set; }
        public DateTime ExpiryDt { get; set; }

        //public string BatchNo { get; set; }
        //public int BatchCd { get; set; }

        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal TaxPer { get; set; }
        public decimal TaxVal { get; set; }
        public decimal Amount { get; set; }
        public bool ActiveYN { get; set; }
        public bool HActiveYN { get; set; }
        public string TranId { get; set; }

        //public DateTime ExpiryDt { get; set; }
        //public string SubUnit { get; set; }
    }
}
