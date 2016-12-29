using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PackageEL
    {
        public int ID { get; set; }
        public string Package_Id { get; set; }
        public string Package_Name { get; set; }
        public int Package_Validity { get; set; }
        public Nullable<Decimal> Package_Rate { get; set; } 
        public Nullable<DateTime> Starting_Date { get; set; } 
        public Nullable<DateTime> Validity_Date { get; set; } 
        public Nullable<Boolean> isActive { get; set; }
        public List<service> ServiceDetail  {get;set;}
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string TaxId { get; set; }
        //public string BranchCode { get; set; }
        //public string BranchName { get; set; }
        //public string Password { get; set; }
        //public string Mobile { get; set; }
        //public int? RoleId { get; set; }
        //public string RoleName { get; set; }
        //public Decimal? Fees { get; set; }
    }

    public class service 
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
