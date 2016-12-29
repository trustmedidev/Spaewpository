using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using EntityLayer;
using System.Data.Entity;

namespace DataAccessLayer
{
   public class PackageBookingDAL:SpaPracticeEntities
    {

       public int InsertUpdatePackageBooking(tblpackagebooking objtblpackagebooking)
       {
           try
           {
               if (objtblpackagebooking.PkgBookingId == 0)
               {
                   tblpackagebookings.Add(objtblpackagebooking); 
                   SaveChanges();
               }
               else
               {
                   Entry(objtblpackagebooking).State = EntityState.Modified;
                   SaveChanges();
               }
           }
           catch (Exception)
           {

               throw;
           }
           return objtblpackagebooking.PkgBookingId;
       }

       public tblpackage GetPackageByPackageId(int PackageId, int? branchID)
       {
           var Package = tblpackages.Where(x => x.Id == PackageId && x.fk_BranchID == branchID).FirstOrDefault();
           if (Package != null)
           {
               tblpackage Objtblpackage = new tblpackage()
               {
                   Package_Id = Package.Package_Id,
                   //Package_Name = Package.Package_Name,
                   //Package_Rate = Package.Package_Rate,
                   //Package_Validity = Package.Package_Validity,
                   //fk_BranchID = Package.fk_BranchID

               };
               return Objtblpackage;
           }
           else
           {
               return null;
           }
       }

       public tblclient GetClientIdByClientNameByPhoneNumber(string clientname,string mobile,int? branchid)
       {
           tblclient objtblclient = new tblclient();
           try
           {
               //var client = new ();
               var client = (from c in tblclients
                             where c.ClientName == clientname && c.Mobile == mobile && c.FK_BranchID == branchid
                             select new
                             {
                                 ClientName = c.ClientName,
                                 ClientId = c.ClientId
                             }).ToList()
                                 .Select(x => new tblclient()
                                 {
                                     ClientId = x.ClientId,
                                     ClientName = x.ClientName
                                 }).FirstOrDefault();
               objtblclient = (tblclient)client;
               return objtblclient;
           }
           catch (Exception ex)
           {
               throw;
           }
          

       }

       public List<PackageBookingEL> GetAllPackageBooking(int? branchID)
       {

           List<PackageBookingEL> objtblpackagebooking = new List<PackageBookingEL>();

           try
           {
            
               objtblpackagebooking = (from c in tblclients
                                   join pb in tblpackagebookings on c.ClientId equals pb.Fk_ClientId
                                   join pkg in tblpackages on pb.Fk_PackageId equals pkg.Id
                                   join pkgdtl in tblpackagedtls on pkg.Id equals pkgdtl.Package_Id
                                   join ser in tblservices on pkgdtl.ServiceId equals ser.ServiceId
                                   //join pd in tblpackagedtls on p.Id equals pd.Package_Id
                                   //join
                                   //    //join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                                   //    ser in tblservices on pd.ServiceId equals ser.ServiceId
                                   //where (ap.AppointmentDate == DateTime.Today && c.IsActive == true && ap.FK_BranchID == branchID
                                   where (c.IsActive == true && pkg.fk_BranchID == branchID  

                                   )
                                   select new PackageBookingEL()
                                   {
                                        
                                       ClientName = c.ClientName,                                        
                                       PackageID = pkg.Package_Id,
                                       PackageName = pkg.Package_Name,
                                       ServiceName = ser.ServiceName,
                                       PkgBookingDate = pb.PkgBookingDate,
                                       ValidityDate = pb.ValidityDate, 
                                   }).ToList();
            
            
           return objtblpackagebooking;
       }
           catch (Exception ex)
           {

               throw;
           }

       }

    }
}
