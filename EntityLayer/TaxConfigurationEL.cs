using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TaxConfigurationEL
    {
        public Nullable<int> FK_BranchID { get; set; }
        public int Tax_Id { get; set; }
        public int HCode { get; set; }
        public int DCode { get; set; }
        public string Tax_Name { get; set; }

        public string ConfigNm { get; set; }
        public bool HdActiveYN { get; set; }

        public string TnSname { get; set; }
        public Nullable<bool> STax { get; set; }
        public string addSub { get; set; }

        public string TermsType { get; set; }
        public string CalOn { get; set; }

        public Nullable<decimal> CalPer { get; set; }
        public Nullable<decimal> CalVal { get; set; }
        

        public Nullable<decimal> Tax_Rate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
    }
}
