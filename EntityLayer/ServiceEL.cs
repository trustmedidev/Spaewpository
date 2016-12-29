using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ServiceEL
    {
        public Nullable<int> FK_BranchID { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int TimeExpende { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> FK_UserId { get; set; }
        public Nullable<System.DateTime> Effective_Date { get; set; }
        public string TaxID { get; set; }
    }
}
