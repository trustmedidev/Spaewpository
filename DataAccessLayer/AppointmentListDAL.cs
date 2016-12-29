using DataAccessLayer.Repository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public  class AppointmentListDAL :SpaPracticeEntities
    {
        #region For Appointment List start
        //public List<AppointmentEL> GetClientListBySearchCriteria(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        //{

        //    List<AppointmentEL> AppointmentListbypackage = new List<AppointmentEL>();
        //    List<AppointmentEL> AppointmentListbyservice = new List<AppointmentEL>();
        //    List<AppointmentEL> AppointmentListbyservicebypackage = new List<AppointmentEL>();
        //    int cnt;
        //    //AppointmentEL objAppointmentEL=new AppointmentEL(); 
        //    List<AppointmentEL> servicecount = new List<AppointmentEL>();
        //    List<tblappointment> objtblappointment = new List<tblappointment>();
        //    int apsercnt;
        //    if (byselection == 0)
        //    {
        //        #region

        //        //........................bypackage........................
        //        AppointmentListbypackage = (from app in tblappointments
        //                                    join c in tblclients on app.FK_ClientId equals c.ClientId
        //                                    join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
        //                                    join
        //                                        pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                                    where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                        && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                        && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
        //                                    select new AppointmentEL()
        //                                    {
        //                                        AppointmentId = app.AppointmentId,
        //                                        AppointmentTime = app.AppointmentTime,
        //                                        AppointmentDate = app.AppointmentDate,
        //                                        ClientName = c.ClientName,
        //                                        CaseHistory = c.CaseHistory,
        //                                        TotalPaid = app.Total == null ? 0 : app.Total,
        //                                        DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
        //                                        Discount = app.Discount == null ? 0 : app.Discount,
        //                                        Service = pkg.Package_Name,
        //                                        TotalAmount = app.GrossAmount,
        //                                        IsActive = app.IsActive,
        //                                        Status = app.IsActive == true ? "Active" : "Cancelled"
        //                                    }).ToList();
        //        objtblappointment = (from app in tblappointments
        //                             where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                 && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                 && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
        //                             select app).ToList();
        //        string serv = default(string);
        //        foreach (tblappointment ap in objtblappointment)
        //        {
        //            AppointmentEL objAppointmentEL = new AppointmentEL();
        //            objAppointmentEL.AppointmentId = ap.AppointmentId;
        //            objAppointmentEL.AppointmentTime = ap.AppointmentTime;
        //            objAppointmentEL.AppointmentDate = ap.AppointmentDate;
        //            objAppointmentEL.ClientName = ap.tblclient.ClientName;
        //            objAppointmentEL.CaseHistory = ap.tblclient.CaseHistory;
        //            objAppointmentEL.TotalPaid = ap.Total == null ? 0 : ap.Total;
        //            objAppointmentEL.DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount;
        //            objAppointmentEL.Discount = ap.Discount == null ? 0 : ap.Discount;
        //            //Service = pkg.Package_Name,
        //            objAppointmentEL.TotalAmount = ap.GrossAmount;
        //            objAppointmentEL.IsActive = ap.IsActive;
        //            objAppointmentEL.Status = ap.IsActive == true ? "Active" : "Cancelled";

        //            List<tblappointmentservicemapping> objtblappointmentservicemapping = new List<tblappointmentservicemapping>();
        //            objtblappointmentservicemapping = (from mapserv in tblappointmentservicemappings
        //                                               where mapserv.FK_AppointmentId == ap.AppointmentId
        //                                               select mapserv).ToList();
        //            if (objtblappointmentservicemapping != null)
        //            {
        //                foreach (var item in objtblappointmentservicemapping)
        //                {

        //                    serv += item.tblservice.ServiceName + ",";
        //                }
        //                serv.TrimEnd(',');
                        
        //                objAppointmentEL.Service = serv;
        //                serv = "";
        //                AppointmentListbyservice.Add(objAppointmentEL);
        //            }
        //        }
        //        foreach (AppointmentEL item in AppointmentListbyservice)
        //        {
        //            AppointmentListbypackage.Add(item);
        //        }

        //        return AppointmentListbypackage;
        //        #endregion
        //    }
        //    else if (byselection == 1)
        //    {
        //        #region

        //        //........................bypackage........................
        //        AppointmentListbypackage = (from app in tblappointments
        //                                    join c in tblclients on app.FK_ClientId equals c.ClientId
        //                                    //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
        //                                    join appserv in tblappointmentservicemappings on app.AppointmentId equals appserv.FK_AppointmentId
        //                                    join
        //                                        //pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                                    tserv in tblservices on appserv.FK_ServiceId equals tserv.ServiceId
        //                                    where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                        && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                        && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
        //                                    select new AppointmentEL()
        //                                    {
        //                                        AppointmentId = app.AppointmentId,
        //                                        AppointmentTime = app.AppointmentTime,
        //                                        AppointmentDate = app.AppointmentDate,
        //                                        ClientName = c.ClientName,
        //                                        CaseHistory = c.CaseHistory,
        //                                        TotalPaid = app.Total == null ? 0 : app.Total,
        //                                        DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
        //                                        Discount = app.Discount == null ? 0 : app.Discount,
        //                                        //Service = pkg.Package_Name,
        //                                        Service=tserv.ServiceName,
        //                                        TotalAmount = app.GrossAmount,
        //                                        IsActive = app.IsActive,
        //                                        Status = app.IsActive == true ? "Active" : "Cancelled"
        //                                    }).ToList();
        //        objtblappointment = (from app in tblappointments
        //                             where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                 && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                 && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
        //                             select app).ToList();
        //        string serv = default(string);
        //        foreach (tblappointment ap in objtblappointment)
        //        {
        //            AppointmentEL objAppointmentEL = new AppointmentEL();
        //            objAppointmentEL.AppointmentId = ap.AppointmentId;
        //            objAppointmentEL.AppointmentTime = ap.AppointmentTime;
        //            objAppointmentEL.AppointmentDate = ap.AppointmentDate;
        //            objAppointmentEL.ClientName = ap.tblclient.ClientName;
        //            objAppointmentEL.CaseHistory = ap.tblclient.CaseHistory;
        //            objAppointmentEL.TotalPaid = ap.Total == null ? 0 : ap.Total;
        //            objAppointmentEL.DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount;
        //            objAppointmentEL.Discount = ap.Discount == null ? 0 : ap.Discount;
        //            //Service = pkg.Package_Name,
        //            objAppointmentEL.TotalAmount = ap.GrossAmount;
        //            objAppointmentEL.IsActive = ap.IsActive;
        //            objAppointmentEL.Status = ap.IsActive == true ? "Active" : "Cancelled";

        //            List<tblappointmentservicemapping> objtblappointmentservicemapping = new List<tblappointmentservicemapping>();
        //            objtblappointmentservicemapping = (from mapserv in tblappointmentservicemappings
        //                                               where mapserv.FK_AppointmentId == ap.AppointmentId
        //                                               select mapserv).ToList();
        //            if (objtblappointmentservicemapping != null)
        //            {
        //                foreach (var item in objtblappointmentservicemapping)
        //                {
        //                    serv += item.tblservice.ServiceName + ",";
        //                }
        //                serv.TrimEnd(',');

        //                objAppointmentEL.Service = serv;
        //                serv = "";
        //                AppointmentListbyservice.Add(objAppointmentEL);
        //            }
        //        }
        //        foreach (AppointmentEL item in AppointmentListbyservice)
        //        {
        //            AppointmentListbypackage.Add(item);
        //        }

        //        return AppointmentListbypackage;
        //        #endregion
        //    }
        //    else if (byselection == 2)
        //    {
        //        #region BYPackage
        //        if (ServiceType > 0)
        //        {
        //            //........................bypackage........................
        //            AppointmentListbypackage = (from app in tblappointments
        //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
        //                                        join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
        //                                        join
        //                                            pkg in tblpackagedtls on appkg.FK_PackageId equals pkg.Package_Id
        //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                            && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
        //                                        select new AppointmentEL()
        //                                        {
        //                                            AppointmentId = app.AppointmentId,
        //                                            AppointmentTime = app.AppointmentTime,
        //                                            AppointmentDate = app.AppointmentDate,
        //                                            ClientName = c.ClientName,
        //                                            CaseHistory = c.CaseHistory,
        //                                            TotalPaid = app.Total == null ? 0 : app.Total,
        //                                            DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
        //                                            Discount = app.Discount == null ? 0 : app.Discount,
        //                                            //Service = pkg.tb.Package_Name,
        //                                            TotalAmount = app.GrossAmount,
        //                                            IsActive = app.IsActive,
        //                                            Status = app.IsActive == true ? "Active" : "Cancelled"
        //                                        }).ToList();
        //            objtblappointment = (from app in tblappointments
        //                                 where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
        //                                     && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
        //                                 select app).ToList();
        //            string serv = default(string);
        //            foreach (tblappointment ap in objtblappointment)
        //            {
        //                AppointmentEL objAppointmentEL = new AppointmentEL();
        //                objAppointmentEL.AppointmentId = ap.AppointmentId;
        //                objAppointmentEL.AppointmentTime = ap.AppointmentTime;
        //                objAppointmentEL.AppointmentDate = ap.AppointmentDate;
        //                objAppointmentEL.ClientName = ap.tblclient.ClientName;
        //                objAppointmentEL.CaseHistory = ap.tblclient.CaseHistory;
        //                objAppointmentEL.TotalPaid = ap.Total == null ? 0 : ap.Total;
        //                objAppointmentEL.DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount;
        //                objAppointmentEL.Discount = ap.Discount == null ? 0 : ap.Discount;
        //                //Service = pkg.Package_Name,
        //                objAppointmentEL.TotalAmount = ap.GrossAmount;
        //                objAppointmentEL.IsActive = ap.IsActive;
        //                objAppointmentEL.Status = ap.IsActive == true ? "Active" : "Cancelled";

        //                List<tblappointmentpackagepping> objtblappointmentservicemapping = new List<tblappointmentpackagepping>();
        //                objtblappointmentservicemapping = (from mapserv in tblappointmentpackageppings
        //                                                   where mapserv.FK_AppointmentId == ap.AppointmentId
        //                                                   select mapserv).ToList();
        //                if (objtblappointmentservicemapping != null)
        //                {
        //                    foreach (var item in objtblappointmentservicemapping)
        //                    {

        //                        serv += item.FK_PackageId + ",";
        //                    }
        //                    serv.TrimEnd(',');

        //                    objAppointmentEL.Service = serv;
        //                    serv = "";
        //                    AppointmentListbyservice.Add(objAppointmentEL);
        //                }
        //            }
        //            foreach (AppointmentEL item in AppointmentListbyservice)
        //            {
        //                AppointmentListbypackage.Add(item);
        //            }

        //            //return AppointmentListbypackage;
        //        }
        //        return AppointmentListbypackage;
        //        #endregion BYPackage
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
         
        #endregion For Appointment List End

        public AppointmentEL GetApppointmentByClntNameforPayment(string cname, int? branchID)
        {
            tblappointment objtblappointment = new tblappointment();
            objtblappointment = tblappointments.Where(x => x.tblclient.ClientName == cname && x.FK_BranchID == branchID).FirstOrDefault();
            if (objtblappointment.ByPackage == true)
            {
                var item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.tblclient.ClientName == cname && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode=app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                return item;
            }
            else if (objtblappointment.ByPackage == false)
            {
                var item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.tblclient.ClientName == cname && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                return item;
            }
            else
            {
                return null;
            }

        }
        public AppointmentEL GetApppointmentByDateforPayment(DateTime date, int? branchID)
        {
            tblappointment objtblappointment = new tblappointment();
            objtblappointment = tblappointments.Where(x => EntityFunctions.TruncateTime(x.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && x.FK_BranchID == branchID).FirstOrDefault();
            if (objtblappointment.ByPackage == true)
            {
                var item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                return item;
            }
            else if (objtblappointment.ByPackage == false)
            {
                var item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum=app.BankCardNo_,
                                BankName=app.BankName
                            }).FirstOrDefault();
                return item;
            }
            else
            {
                return null;
            }

        }
        public AppointmentEL GetApppointmentByAllforPayment(int? AppId, string cname, DateTime date, int? branchID)
        {
            tblappointment objtblappointment = new tblappointment();
            AppointmentEL item = new AppointmentEL();
            if (AppId > 0 && cname != "" && date != Convert.ToDateTime(null))
            {
                objtblappointment = tblappointments.Where(x => x.AppointmentId == AppId && x.tblclient.ClientName == cname && EntityFunctions.TruncateTime(x.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && x.FK_BranchID == branchID).FirstOrDefault();
                if (objtblappointment.ByPackage == true)
                {
                    item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == AppId && app.tblclient.ClientName == cname && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else if (objtblappointment.ByPackage == false)
                {
                    item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == AppId && app.tblclient.ClientName == cname && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else
                {
                    return null;
                }
            }
            else if (AppId > 0 && cname != "" && date == Convert.ToDateTime(null))
            {
                objtblappointment = tblappointments.Where(x => x.AppointmentId == AppId && x.tblclient.ClientName == cname && x.FK_BranchID == branchID).FirstOrDefault();
                if (objtblappointment.ByPackage == true)
                {
                    item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == AppId && app.tblclient.ClientName == cname && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else if (objtblappointment.ByPackage == false)
                {
                    item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == AppId && app.tblclient.ClientName == cname && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else
                {
                    return null;
                }
            }
            else if (AppId == 0 && cname != "" && date != Convert.ToDateTime(null))
            {
                objtblappointment = tblappointments.Where(x => x.tblclient.ClientName == cname && EntityFunctions.TruncateTime(x.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && x.FK_BranchID == branchID).FirstOrDefault();
                if (objtblappointment.ByPackage == true)
                {
                    item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.tblclient.ClientName == cname && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else if (objtblappointment.ByPackage == false)
                {
                    item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.tblclient.ClientName == cname && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else
                {
                    return null;
                }
            }
            else if (AppId > 0 && cname == "" && date != Convert.ToDateTime(null))
            {
                objtblappointment = tblappointments.Where(x => x.AppointmentId == AppId && EntityFunctions.TruncateTime(x.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && x.FK_BranchID == branchID).FirstOrDefault();
                if (objtblappointment.ByPackage == true)
                {
                    item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == AppId && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else if (objtblappointment.ByPackage == false)
                {
                    item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId > 0 && EntityFunctions.TruncateTime(app.AppointmentDate.Value) == EntityFunctions.TruncateTime(date) && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                TotalAmount = app.GrossAmount,
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,
                                paymentmode = app.PaymentMode,
                                BankCardNum = app.BankCardNo_,
                                BankName = app.BankName
                            }).FirstOrDefault();
                    //return item;
                }
                else
                {
                    return null;
                }
            }
            return item;
        }

        public List<AppointmentEL> GetClientListBySearchCriteria(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {

            List<AppointmentEL> AppointmentListbypackage = new List<AppointmentEL>();
            List<AppointmentEL> AppointmentListbyservice = new List<AppointmentEL>();
            List<AppointmentEL> AppointmentListbyservicebypackage = new List<AppointmentEL>();
            //int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            //int apsercnt;
            if (byselection == 0)
            {
                #region

                //........................bypackage........................
                AppointmentListbypackage = (from app in tblappointments
                                            join c in tblclients on app.FK_ClientId equals c.ClientId
                                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                            join
                                                pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                            where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                            select new AppointmentEL()
                                            {
                                                AppointmentId = app.AppointmentId,
                                                AppointmentTime = app.AppointmentTime,
                                                AppointmentDate = app.AppointmentDate,
                                                ClientName = c.ClientName,
                                                Mobile=c.Mobile,
                                                CaseHistory = c.CaseHistory,
                                                TotalPaid = app.Total == null ? 0 : app.Total,
                                                DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
                                                Discount = app.Discount == null ? 0 : app.Discount,
                                                Service = pkg.Package_Name,
                                                TotalAmount = app.GrossAmount,
                                                IsActive = app.IsActive,
                                                Status = app.IsActive == true ? "Active" : "Cancelled"
                                            }).ToList();
                foreach (var item in AppointmentListbypackage)
                {
                    //item.Service = FetchServiceById((int)item.FK_PackageId, item.ServiceType, (int)branchID);
                    //item.Coupon = tbl_couponcode.Where(x => x.coupon_id == item.FK_CouponId).Select(x => x.coupon_discount_amt).FirstOrDefault();
                    //item.TotalAmount = GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount);
                }

                //........................byservice........................
                AppointmentListbyservice = (from app in tblappointments
                                            join c in tblclients on app.FK_ClientId equals c.ClientId
                                            //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                            //join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                           // join
                                           //     ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                            where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                            select new AppointmentEL()
                                            {
                                                AppointmentId = app.AppointmentId,
                                                AppointmentTime = app.AppointmentTime,
                                                AppointmentDate = app.AppointmentDate,
                                                ClientName = c.ClientName,
                                                Mobile = c.Mobile,
                                                CaseHistory = c.CaseHistory,
                                                TotalPaid = app.Total == null ? 0 : app.Total,
                                                DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
                                                Discount = app.Discount == null ? 0 : app.Discount,
                                                //Service = ser.ServiceName,
                                                //serviceid=appser.FK_ServiceId,
                                                TotalAmount = app.GrossAmount,
                                                IsActive = app.IsActive,
                                                Status = app.IsActive == true ? "Active" : "Cancelled"
                                            }).ToList();

                foreach (var item in AppointmentListbyservice)
                {
                    AppointmentListbypackage.Add(item);
                    item.Service = FetchServiceById((int)item.AppointmentId, (int)branchID);
                    //item.Coupon = tbl_couponcode.Where(x => x.coupon_id == item.FK_CouponId).Select(x => x.coupon_discount_amt).FirstOrDefault();
                    //item.TotalAmount = GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount);
                }





                return AppointmentListbypackage;

                #endregion
                //}
            }
            else if (byselection == 1)
            {
                #region Byservice Section

                AppointmentListbyservice = (from app in tblappointments
                                            join c in tblclients on app.FK_ClientId equals c.ClientId
                                            //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                            join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                            //join
                                             //   ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                            where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                && (appser.FK_ServiceId == (ServiceType != null ? ServiceType : appser.FK_ServiceId))
                                            select new AppointmentEL()
                                            {
                                                AppointmentId = app.AppointmentId,
                                                AppointmentTime = app.AppointmentTime,
                                                AppointmentDate = app.AppointmentDate,
                                                ClientName = c.ClientName,
                                                Mobile = c.Mobile,
                                                CaseHistory = c.CaseHistory,
                                                TotalPaid = app.Total == null ? 0 : app.Total,
                                                DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
                                                Discount = app.Discount == null ? 0 : app.Discount,
                                                //Service = ser.ServiceName,
                                                TotalAmount = app.GrossAmount,
                                                IsActive = app.IsActive,
                                                Status = app.IsActive == true ? "Active" : "Cancelled"
                                            }).ToList();
                foreach (var item in AppointmentListbyservice)
                {
                    item.Service = FetchServiceById((int)item.AppointmentId, (int)branchID);
                    //item.Coupon = tbl_couponcode.Where(x => x.coupon_id == item.FK_CouponId).Select(x => x.coupon_discount_amt).FirstOrDefault();
                    //item.TotalAmount = GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount);
                }

                return AppointmentListbyservice;

                #endregion Byservice Section
            }
            else if (byselection == 2)
            {

                #region BYPackage
                AppointmentListbypackage = (from app in tblappointments
                                            join c in tblclients on app.FK_ClientId equals c.ClientId
                                            //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                            join
                                                pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                            where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                && app.FK_BranchID == branchID && app.ByPackage == true
                                                && app.GrossAmount > 0
                                                && (appkg.FK_PackageId == (ServiceType != null ? ServiceType : appkg.FK_PackageId))
                                            select new AppointmentEL()
                                            {
                                                AppointmentId = app.AppointmentId,
                                                AppointmentTime = app.AppointmentTime,
                                                AppointmentDate = app.AppointmentDate,
                                                ClientName = c.ClientName,
                                                Mobile = c.Mobile,
                                                CaseHistory = c.CaseHistory,
                                                TotalPaid = app.Total == null ? 0 : app.Total,
                                                DueAmount = app.DueAmount == null ? 0 : app.DueAmount,
                                                Discount = app.Discount == null ? 0 : app.Discount,
                                                Service = pkg.Package_Name,
                                                TotalAmount = app.GrossAmount,
                                                IsActive = app.IsActive,
                                                Status = app.IsActive == true ? "Active" : "Cancelled"
                                            }).ToList();
                foreach (var item in AppointmentListbypackage)
                {
                    //item.Service = FetchServiceById((int)item.FK_PackageId, item.ServiceType, (int)branchID);
                    //item.Coupon = tbl_couponcode.Where(x => x.coupon_id == item.FK_CouponId).Select(x => x.coupon_discount_amt).FirstOrDefault();
                    //item.TotalAmount = GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount);
                }
                return AppointmentListbypackage;
                #endregion BYPackage

            }


            return null;

        }


        public List<AppointmentEL> GetListBySearchCriteria(string clientname, int? ServiceType, int? PackageType, DateTime? FromDate, DateTime? Todate, int? branchID)
        {
            List<AppointmentEL> result = new List<AppointmentEL>();

            var query = tblappointments.Where(t => t.FK_BranchID == branchID);

            if (ServiceType.HasValue && ServiceType.Value > 0)
            {
                query = query.Where(t => t.FK_ServiceId == ServiceType.Value);
            }

            if (PackageType.HasValue && PackageType.Value > 0)
            {
                List<tblappointmentpackagepping> packages = tblappointmentpackageppings.Where(t => t.FK_PackageId == PackageType.Value && t.FK_AppointmentId.HasValue).ToList();

                List<int> appointmentids = new List<int>();

                if (packages != null && packages.Count() > 0)
                {
                    appointmentids = packages.Select(t => t.FK_AppointmentId.Value).ToList();

                    query = query.Where(t => appointmentids.Contains(t.AppointmentId));
                }
            }

            if (FromDate.HasValue)
            {
                query = query.Where(t => EntityFunctions.TruncateTime(t.AppointmentDate.Value) >= EntityFunctions.TruncateTime(FromDate.Value));
            }

            if (Todate.HasValue)
            {
                query = query.Where(t => EntityFunctions.TruncateTime(t.AppointmentDate.Value) <= EntityFunctions.TruncateTime(Todate.Value));
            }

            if (!string.IsNullOrWhiteSpace(clientname))
            {
                query = query.Where(t => t.tblclient.ClientName == clientname);
            }

            List<tblappointment> modelist = query.ToList();

            if (modelist != null && modelist.Count() > 0)
            {
                result = modelist.Select(t => new AppointmentEL()
                {
                    AppointmentId = t.AppointmentId,
                    AppointmentTime = t.AppointmentTime,
                    AppointmentDate = t.AppointmentDate,
                    ClientName = t.tblclient.ClientName,
                    Mobile = t.tblclient.Mobile,
                    CaseHistory = t.tblclient.CaseHistory,
                    TotalPaid = t.PaymentDoneAmount.HasValue ? t.PaymentDoneAmount.Value : 0,
                    DueAmount = t.DueAmount.HasValue ? t.DueAmount.Value : 0,
                    Discount = t.Discount.HasValue ? t.Discount.Value : 0,
                    Service = t.ByPackage.HasValue ? (t.ByPackage.Value == true ? "By Package" : "By Service") : ((PackageType.HasValue && PackageType.Value > 0) ? "By Package" : "By Service"),
                    TotalAmount = t.NetPayableAmount,
                    IsActive = t.IsActive,
                    Status = t.IsActive == true ? "Active" : "Cancelled"
                }).ToList();
            }

            return result;
        }

        public string FetchServiceById(int? AppId, int? branchId)
        {
            string s = default(string);
            List<string> l = new List<string>();
            var query = (from app in tblappointments
                         join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                         where (app.AppointmentId == AppId && app.FK_BranchID == branchId)
                         select appser.tblservice.ServiceName).ToList();

            foreach (var item in query)
            {
                s += item + ",";
            }
            return s.TrimEnd(',');
        }

        //public string FetchServiceById(int? AppId, int? branchId, bool? bypackage)
        //{
        //    string s = default(string);
        //    if (bypackage == false)
        //    {
        //        //string s = default(string);
        //        List<string> l = new List<string>();
        //        var query = (from app in tblappointments
        //                     join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
        //                     where (app.AppointmentId == AppId && app.FK_BranchID == branchId)
        //                     select appser.tblservice.ServiceName).ToList();

        //        foreach (var item in query)
        //        {
        //            s += item + ",";
        //        }
        //        //return s.TrimEnd(',');
        //    }
        //    else
        //    {
        //        var query = (from app in tblappointments
        //                     join apppkg in tblappointmentpackageppings on app.AppointmentId equals apppkg.FK_AppointmentId
        //                     where (app.AppointmentId == AppId && app.FK_BranchID == branchId)
        //                     select apppkg.FK_PackageId.Value).FirstOrDefault();
        //        s = query.ToString();
        //    }
        //    return s;
        //}
    }
}
