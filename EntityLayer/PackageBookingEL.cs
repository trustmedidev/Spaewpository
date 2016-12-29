using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class PackageBookingEL
    {
       //Fk_ClientId` `PkgBookingDate` `ValidityDate` `Fk_BranchId` `IsActive` `Fk_PackageId`
         
            public int PackageBookingId { get; set; } 
            public int Fk_ClientId { get; set; } 
            public string ClientName { get; set; }  
            public string PackageID { get; set; } 
            public string PackageName { get; set; } 
            public string ServiceName { get; set; }
            public string Service { get; set; }
            public DateTime? PkgBookingDate { get; set; } 
            public DateTime? ValidityDate { get; set; } 
            //public List<ServiceCharges> ServiceList { get; set; } 
            public Nullable<int> serviceid { get; set; } 
            public decimal? ServiceCharge { get; set; } 
            public bool? IsActive { get; set; }
            public string Status { get; set; }

             
        }

        //public class ServiceCharges
        //{

        //    public string ServiceName { get; set; }

        //    public decimal? Amount { get; set; }

        //}
    }
 
