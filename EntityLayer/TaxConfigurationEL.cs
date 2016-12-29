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
        public string Tax_Name { get; set; }
        public Nullable<decimal> Tax_Rate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
    }
}
