using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer.Repository;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class PackageDAL : SpaPracticeEntities
    {
        #region Insert And Update Function Start
        public int InsertUpdatePackage(tblpackage objtblpackage)
        {

            try
            {
                var package = tblpackages.Where(x => x.Package_Id == objtblpackage.Package_Id).FirstOrDefault();
                if (package == null)
                {

                    tblpackages.Add(objtblpackage);
                    SaveChanges();
                }
                else
                {

                    var context = new SpaPracticeEntities();
                    var obj = context.tblpackages.Where(p => p.Package_Id == objtblpackage.Package_Id).FirstOrDefault();
                    if (obj != null)
                    {
                        //Entry(objtblpackage).State = EntityState.Modified;
                        //SaveChanges();
                        objtblpackage.Id = obj.Id;
                        context.Entry(obj).CurrentValues.SetValues(objtblpackage);
                        context.SaveChanges();
                    }
                    //Entry(objtblpackage).State = EntityState.Modified;
                    //SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objtblpackage.Id;
        }
        public void InsertUpdatePackage(tblpackagedtl objtblpackagedtl)
        {

            try
            {

                var package = tblpackagedtls.Where(x => x.Package_Id == objtblpackagedtl.Package_Id
                    && x.ServiceId == objtblpackagedtl.ServiceId).FirstOrDefault();
                if (package == null)
                {
                    tblpackagedtl objpackagedtl = new tblpackagedtl();
                    objpackagedtl.Package_Id = objtblpackagedtl.Package_Id;
                    objpackagedtl.ServiceId = objtblpackagedtl.ServiceId;
                    tblpackagedtls.Add(objpackagedtl);
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion Insert And Update Function End

        #region Delete Function Start 
        public void DeletePackageDtlByPackageServiceID(int packageid)
        {
            SpaPracticeEntities db = new SpaPracticeEntities();
            var remove = from aremove in db.tblpackagedtls
                         where aremove.Package_Id == packageid
                         select aremove;

            if (remove != null)
            {
                db.tblpackagedtls.RemoveRange(remove);
                db.SaveChanges();
            }

        }
        public bool DeleteServicesById(int packageid, int serviceId)
        {
            try
            {
                tblpackagedtl itemToRemove = tblpackagedtls.SingleOrDefault(x => x.Package_Id == packageid && x.ServiceId == serviceId);
                //tblpackage itemToRemove=t.SingleOrDefault(x=>x.Package_Id==packageid and )
                //tblservice itemToRemove = tblservices.SingleOrDefault(x => x.ServiceId == serviceId && x.FK_BranchID == branchID);
                //itemToRemove.IsActive = false;
                Entry(itemToRemove).State = EntityState.Deleted;
                SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // ......................Code Added By Sam on 05052016............................
        public bool DeletePackageByPackageId(int packageid, int? branchid)
        {
            try
            {
                List<tblpackagedtl> packageDtlToRemove = tblpackagedtls.Where(x => x.Package_Id == packageid).ToList();
                if (packageDtlToRemove != null)
                {
                    foreach (tblpackagedtl pkg in packageDtlToRemove)
                    {
                        Entry(pkg).State = EntityState.Deleted;
                        SaveChanges();
                    }
                }
                tblpackage packageToRemove = tblpackages.SingleOrDefault(x => x.Id == packageid && x.fk_BranchID == branchid);
                Entry(packageToRemove).State = EntityState.Deleted;
                SaveChanges();
               

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // ......................Code Added By Sam on 05052016............................

        #endregion Delete Function End

        #region Check Function Start

        public bool IsExistedPackageID(string packageid, string packagename, int? branchid)
        {

            var IsService = tblpackages.Where(x => x.Package_Id != packageid && x.Package_Name == packagename && x.IsActive==true && x.fk_BranchID==branchid).FirstOrDefault();
            if (IsService != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistedPackageName(string packagename,int? branchid)
        {

            var IsService = tblpackages.Where(x => x.Package_Name == packagename && x.fk_BranchID==branchid).FirstOrDefault();
            if (IsService != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        public bool CheckPackageName(string userName, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.UserName.Trim().ToUpper() == userName && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Check Function End

        #region Get Function Start

        public tblpackage GetPackageByPackageId(int updatePackageId, int? branchID)
        {
            var Package = tblpackages.Where(x => x.Id == updatePackageId && x.fk_BranchID == branchID).FirstOrDefault();
            if (Package != null)
            {
                tblpackage Objtblpackage = new tblpackage()
                {
                    Package_Id = Package.Package_Id,
                    Package_Name = Package.Package_Name,
                    Package_Rate = Package.Package_Rate,
                    Package_Validity = Package.Package_Validity,
                    fk_BranchID = Package.fk_BranchID

                };
                return Objtblpackage;
            }
            else
            {
                return null;
            }
        } 
        public PackageEL GetAllPackageDtlById(int packageid, int serviceid, int? branchID)
        {
            PackageEL PackageList = new PackageEL();
            PackageList = (from p in tblpackages
                           join pd in tblpackagedtls on p.Id equals pd.Package_Id
                           join ser in tblservices on pd.ServiceId equals ser.ServiceId
                           where (p.Id == packageid
                                && pd.ServiceId == serviceid && p.fk_BranchID == branchID)
                           select new PackageEL()
                           {
                               ID = p.Id,
                               Package_Id = p.Package_Id,
                               Package_Name = p.Package_Name,
                               Starting_Date = p.Starting_Date,
                               Validity_Date = p.Validity_Date,
                               //Package_Validity = p.Package_Validity,
                               //Package_Rate = ser.Amount,
                               Package_Rate = p.Package_Rate,
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName


                           }).FirstOrDefault();
            return PackageList;
        }

        /*---------------------------Added by Sandip Das on 03-06-2016------------------------*/
        public decimal? GetAmtFromServiceId(int? serviceId)
        {
            var query = tblmapservices.Where(x => x.FK_ServiceId == serviceId).Select(x => x.Amount).FirstOrDefault();
            return query;
        }
        public string ServiceByPkgId(int? PkgId)
        {
            string s = "";
            var serv = tblpackagedtls.Where(x => x.Package_Id == PkgId).Select(x => x.ServiceId).ToList();
            foreach (var item in serv)
            {
                s += item.ToString() + ',';
            }
            return s.TrimEnd(',');
        }
        public decimal AmtByServId(int? ServId)
        {
            var amt = tblmapservices.Where(x => x.FK_ServiceId == ServId).Select(x => x.Amount).FirstOrDefault();
            return (decimal)amt;
        }
        /*----------------------------------------END----------------------------------------*/
        // .......................Code Added by Sam on 05052016........................

        public PackageEL GetAllPackageDtlByPackageId(int packageid, int? branchID)
        {
            PackageEL PackageList = new PackageEL();
            PackageList = (from p in tblpackages where (p.Id == packageid && p.fk_BranchID == branchID)
                           select new PackageEL()
                           {
                               ID = p.Id,
                               Package_Id = p.Package_Id,
                               Package_Name = p.Package_Name,
                               Starting_Date = p.Starting_Date,
                               Validity_Date = p.Validity_Date,
                               //Package_Validity = p.Package_Validity,
                               //Package_Rate = ser.Amount,
                               Package_Rate = p.Package_Rate,
                               isActive=p.IsActive,
                               TaxId=p.TaxID,
                               //ServiceId = ser.ServiceId,
                               //ServiceName = ser.ServiceName


                           }).FirstOrDefault();
            return PackageList;
        }

        // .......................Code Added by Sam on 05052016 Above........................
        public List<PackageEL> GetAllPackage(int? branchID)
        {
            List<PackageEL> PackageList = new List<PackageEL>();
            PackageList = (from p in tblpackages
                           join pd in tblpackagedtls on p.Id equals pd.Package_Id
                           join ser in tblservices on pd.ServiceId equals ser.ServiceId 
                           where p.fk_BranchID==branchID && p.IsActive==true
                           select new PackageEL()
                           {
                               ID = p.Id,
                               Package_Id = p.Package_Id,
                               Package_Name = p.Package_Name,
                               Starting_Date=p.Starting_Date,
                               Validity_Date=p.Validity_Date,
                               Package_Validity = p.Package_Validity,
                               Package_Rate = ser.Amount,
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName

                           }).ToList();
            return PackageList.OrderBy(x=>x.Package_Name).ToList(); 


           //  string serv = "";
           // //List<tblpackage> Package = new List<tblpackage>();
           // List<PackageEL> PackageList = new List<PackageEL>();
           // List<tblservice> service = new List<tblservice>();
             
           //var Package = (from p in tblpackages
           //            where p.fk_BranchID == branchID && p.IsActive == true
           //            select p);

            
           // PackageList=tblpackagedtls.Select(x => new PackageEL()
           // {

           //     Package_Id = x.,
           //     Package_Name = x.Package_Name,
               
           //     ServiceDetail = x.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
           //     //                new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList(),
           //     //ServiceCharge = x.tblappointmentservicemappings.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
           //     //new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).Sum(r => r.Amount),
           //     Discount = x.Discount == null ? 0 : x.Discount,
           //     TotalAmount = x.TotalAmount == null ? 0 : x.TotalAmount
           // }).ToList();



           //foreach (var pack in Package)
           //{
           //    service = (from p in tblpackages
           //               join pd in tblpackagedtls on p.Id equals pd.Package_Id
           //               join ser in tblservices on pd.ServiceId equals ser.ServiceId
           //               where p.fk_BranchID == branchID && p.IsActive == true && p.Id == pack.Id
           //               select new tblservice()
           //                   {
           //                       ServiceId = ser.ServiceId,
           //                       ServiceName = ser.ServiceName
           //                   }).ToList();
           //    foreach (var item in service)
           //    {
           //        serv = serv + "," + item.ServiceName;

           //    }
              
           //    PackageList.Add()
           //}
        }



        public int GetServiceIdByServiceName(string servicename, int? branchID)
        {

            return tblservices.Where(x=>x.ServiceName==servicename && x.FK_BranchID==branchID).ToList().Select(x=>x.ServiceId).FirstOrDefault();
            //var Package = tblpackages.Where(x => x.Id == updatePackageId && x.fk_BranchID == branchID).FirstOrDefault();
            //if (Package != null)
            //{
            //    tblpackage Objtblpackage = new tblpackage()
            //    {
            //        Package_Id = Package.Package_Id,
            //        Package_Name = Package.Package_Name,
            //        Package_Rate = Package.Package_Rate,
            //        Package_Validity = Package.Package_Validity,
            //        fk_BranchID = Package.fk_BranchID

            //    };
            //    return Objtblpackage;
            //}
            //else
            //{
            //    return null;
            //}
        } 

        #endregion Get Function End

        #region Extra Code Start
        public int InsertUpdateDoctorFees(tblservice objservice)
        {

            try
            {
                if (objservice.ServiceId == 0)
                {
                    tblservices.Add(objservice);
                    SaveChanges();
                }
                else
                {
                    Entry(objservice).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objservice.ServiceId;
        }

        public UserEL GetUserById(int UserId, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.UserId == UserId && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                UserEL objUser = new UserEL()
                {
                    UserId = UserDetails.UserId,
                    UserName = UserDetails.UserName,
                    Name = UserDetails.Name,
                    Email = UserDetails.Email,
                    Password = UserDetails.Password
                };

                return objUser;
            }
            else
            {
                return null;
            }
        }

        #endregion Extra Code End


        public IEnumerable<PackageEL> GetListOfPackages(int? branchId = 0)
        {
            List<string> ServiceList = new List<string>();
            string serv = "";
            List<int> PackageServiceList = new List<int>();
            var packageList = tblpackages.Where(x => x.fk_BranchID == branchId).Select(x => new PackageEL
            {
                 
                              
                               //ServiceId = ser.ServiceId,
                               //ServiceName = ser.ServiceName





                ID=x.Id,
                Package_Id=x.Package_Id,
                Package_Name=x.Package_Name, 
                Starting_Date=x.Starting_Date,
                Validity_Date=x.Validity_Date,
                Package_Validity = x.Package_Validity,
                Package_Rate = x.Package_Rate,
                isActive=x.IsActive
                //,
                 
                //IsActive = x.IsActive,
            }).ToList().OrderBy(x=>x.Package_Name);
            foreach (var item in packageList)
            {

                var result = tblpackagedtls.Where(p => p.Package_Id == item.ID).ToList();
                foreach (var r in result)
                {
                    string serviceName = tblpackagedtls.Where(x => x.ServiceId == r.ServiceId).Select(x => x.tblservice.ServiceName).FirstOrDefault();
                    ServiceList.Add(serviceName);
                }

                foreach (string service in ServiceList)
                {
                    serv += service + ",";
                }
                item.ServiceName = serv.TrimEnd(',');
                ServiceList.Clear();
                serv = null;
            }
            return packageList.ToList();
        }
    }
}
