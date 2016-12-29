using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Repository;
using EntityLayer;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;


namespace DataAccessLayer
{
    public class AppointmentDAL : SpaPracticeEntities
    {
        public List<string> GetAppointmentScheduleTime()
        {
            int CalenderInterval = default(int);
            List<string> TimeList = new List<string>();
            tblcompdetail comDetails = tblcompdetails.FirstOrDefault();
            int.TryParse(comDetails.Interval.ToString(), out CalenderInterval);

            int startHour = Convert.ToInt32(comDetails.Opening_Time.Substring(0, 2));
            int startMin = Convert.ToInt32(comDetails.Opening_Time.Substring(3, 2));

            int endHour = Convert.ToInt32(comDetails.Closing_Time.Substring(0, 2));
            int endMin = Convert.ToInt32(comDetails.Closing_Time.Substring(3, 2));

            //int.TryParse(tblappointmentsettings.FirstOrDefault().CalenderInterval.ToString(), out CalenderInterval);

            DateTime startTime = new DateTime(2000, 1, 1, startHour, startMin, 0);
            DateTime endTime = new DateTime(2000, 1, 1, endHour, endMin, 0);
            TimeSpan interval = new TimeSpan(0, 30, 0);

            switch (CalenderInterval)
            {
                case 1:
                    interval = new TimeSpan(0, 30, 0);
                    TimeList = populateDropdown(startTime, endTime, interval);
                    break;
                case 2:
                    interval = new TimeSpan(1, 0, 0);
                    TimeList = populateDropdown(startTime, endTime, interval);
                    break;
                case 3:
                    interval = new TimeSpan(2, 0, 0);
                    TimeList = populateDropdown(startTime, endTime, interval);
                    break;
            }

            return TimeList;
        }


        private List<string> populateDropdown(DateTime startTime, DateTime endTime, TimeSpan interval)
        {
            List<string> dropdown = new List<string>();

            DateTime time = startTime;

            while (time <= endTime)
            {
                dropdown.Add(time.ToString("HH:mm tt"));
                time = time.Add(interval);
            }

            return dropdown;
        }


        public int InsertPaymentDtl(tblpaymentdtl objtblpaymentdtl)
        {
            try
            {
                if (objtblpaymentdtl.PaymentID == 0)
                {

                    tblpaymentdtls.Add(objtblpaymentdtl);
                    SaveChanges();
                }
                else
                {
                    var appOrg = tblpaymentdtls.Find(objtblpaymentdtl.PaymentID);
                    Entry(appOrg).CurrentValues.SetValues(objtblpaymentdtl);
                    //Entry(objAppointment).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return objtblpaymentdtl.PaymentID;
        }

        public int InsertPaymentDtl(tblpaymentdtl objtblpaymentdtl, tblappointment appointMentModel, out string Message)
        {
            Message = "";

            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    tblappointment tempAppoData = tblappointments.Where(t => t.AppointmentId == appointMentModel.AppointmentId).FirstOrDefault();

                    if (tempAppoData != null && tempAppoData.AppointmentId > 0)
                    {
                        if (tempAppoData.IsPaymentComplete.HasValue && tempAppoData.IsPaymentComplete.Value == true)
                        {
                            Message = "Payment already done for this appointment!";
                            return 0;
                        }

                        appointMentModel.AdvanceAmount = tempAppoData.AdvanceAmount;
                        appointMentModel.AppointmentDate = tempAppoData.AppointmentDate;
                        appointMentModel.AppointmentTime = tempAppoData.AppointmentTime;
                        appointMentModel.BalanceAmount = tempAppoData.BalanceAmount;
                        appointMentModel.BankCardNo_ = tempAppoData.BankCardNo_;
                        appointMentModel.BankName = tempAppoData.BankName;
                        appointMentModel.ByPackage = tempAppoData.ByPackage;
                        //appointMentModel.CouponDiscountAmount = tempAppoData.CouponDiscountAmount;
                        appointMentModel.CreatedBy = tempAppoData.CreatedBy;
                        appointMentModel.CreatedDate = tempAppoData.CreatedDate;
                        //appointMentModel.Discount = tempAppoData.Discount;
                        //appointMentModel.DueAmount = tempAppoData.DueAmount;
                        appointMentModel.FK_BranchID = tempAppoData.FK_BranchID;
                        appointMentModel.FK_ClientId = tempAppoData.FK_ClientId;
                        //appointMentModel.FK_CouponId = tempAppoData.FK_CouponId;
                        appointMentModel.FK_ServiceId = tempAppoData.FK_ServiceId;
                        appointMentModel.FK_TaxId = tempAppoData.FK_TaxId;
                        appointMentModel.FK_TherapistId = tempAppoData.FK_TherapistId;
                        appointMentModel.FK_UserId = tempAppoData.FK_UserId;
                        //appointMentModel.GrossAmount = tempAppoData.GrossAmount;
                        appointMentModel.IsActive = tempAppoData.IsActive;
                        //appointMentModel.IsPaymentComplete = tempAppoData.IsPaymentComplete;
                        //appointMentModel.IsPaymentProcessStarted = tempAppoData.IsPaymentProcessStarted;
                        //appointMentModel.ManualDiscountAmount = tempAppoData.ManualDiscountAmount;
                        //appointMentModel.ManualDiscountPercentage = tempAppoData.ManualDiscountPercentage;
                        appointMentModel.ModifyDate = DateTime.Now;
                        //appointMentModel.NetPayableAmount = tempAppoData.NetPayableAmount;
                        appointMentModel.NetTotal = tempAppoData.NetTotal;
                        //appointMentModel.PaymentDoneAmount = tempAppoData.PaymentDoneAmount;
                        appointMentModel.PaymentMode = tempAppoData.PaymentMode;
                        appointMentModel.PaymentType = tempAppoData.PaymentType;
                        //appointMentModel.ReceivedAmount = tempAppoData.ReceivedAmount;
                        //appointMentModel.TaxAmount = tempAppoData.TaxAmount;
                        appointMentModel.Total = tempAppoData.Total;
                        appointMentModel.TotalTax = tempAppoData.TotalTax;

                        Entry(tempAppoData).CurrentValues.SetValues(appointMentModel);
                        SaveChanges();

                        objtblpaymentdtl.CreatedDate = DateTime.Now;
                        objtblpaymentdtl.PaymentID = 0;

                        tblpaymentdtls.Add(objtblpaymentdtl);
                        SaveChanges();

                        dbTran.Commit();

                        Message = "Payment done successfully.";
                        return objtblpaymentdtl.PaymentID;
                    }
                    else
                    {
                        dbTran.Rollback();
                        Message = "Appointment record not found!";
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    Message = "Payment details failed to save because: " + ex.Message;
                    return 0;
                }
            }
        }

        public int InsertUpdateAppointment(tblappointment objAppointment)
        {

            try
            {
                if (objAppointment.AppointmentId == 0)
                {
                    tblappointments.Add(objAppointment);
                    SaveChanges();
                }
                else
                {
                    var appOrg = tblappointments.Find(objAppointment.AppointmentId);
                    Entry(appOrg).CurrentValues.SetValues(objAppointment);
                    //Entry(objAppointment).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return objAppointment.AppointmentId;
        }
        public int InsertUpdateappointmentpackagepping(tblappointmentpackagepping objtblappointmentpackagepping)
        {

            try
            {
                if (objtblappointmentpackagepping.AppointmentPackageId == 0)
                {
                    tblappointmentpackageppings.Add(objtblappointmentpackagepping);
                    SaveChanges();
                }
                else
                {
                    var appOrg = tblappointmentpackageppings.Find(objtblappointmentpackagepping.AppointmentPackageId);
                    Entry(appOrg).CurrentValues.SetValues(objtblappointmentpackagepping);
                    //Entry(objAppointment).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return objtblappointmentpackagepping.AppointmentPackageId;
        }
        public void InsertUpdateappointmentservice(tblappointmentservicemapping objtblappointmentservicemapping)
        {

            try
            {
                //        if (objtblappointmentservicemapping.AppointmentServiceId == 0)
                //        {
                tblappointmentservicemappings.Add(objtblappointmentservicemapping);
                SaveChanges();
                //        }
                //        else
                //        {

                //            var appOrg = tblappointmentservicemappings.Find(objtblappointmentservicemapping.AppointmentServiceId);
                //            Entry(appOrg).CurrentValues.SetValues(objtblappointmentservicemapping);
                //            //Entry(objAppointment).State = EntityState.Modified;
                //            SaveChanges();
                //        }
            }
            catch (Exception ex)
            {

            }
            //return objtblappointmentservicemapping.FK_ServiceId;
        }
        //public void InsertUpdateappointmentservice(tblappointmentservicemapping objtblappointmentservicemapping)
        //{
        // try
        //    {

        //        var package = tblappointmentservicemappings.Where(x => x.AppointmentServiceId == objtblappointmentservicemapping.AppointmentServiceId).FirstOrDefault();
        //        if (package == null)
        //        {
        //            tblpackagedtl objpackagedtl = new tblpackagedtl();
        //            objpackagedtl.Package_Id = objtblpackagedtl.Package_Id;
        //            objpackagedtl.ServiceId = objtblpackagedtl.ServiceId;                    
        //            tblpackagedtls.Add(objpackagedtl);
        //            SaveChanges();
        //        } 
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        public decimal? GetServiceChargeByServiceID(int? id, int? branchID)
        {
            return tblservices.Where(x => x.ServiceId == id && x.FK_BranchID == branchID).Select(x => x.Amount).FirstOrDefault();
        }
        public bool? GetAppointmentDtlBypackage(int i, int? branchID)
        {
            return tblappointments.Where(x => x.AppointmentId == i && x.FK_BranchID == branchID).Select(x => x.ByPackage).FirstOrDefault();
        }
        public List<tblservice> GetAllServicesByPackageIdAppointmentId(int appointmentid, int? packageId, int? branchID)
        {
            List<tblservice> objtblservice = new List<tblservice>();
            var service = (from p in tblpackages
                           join pa in tblappointmentpackageppings on p.Id equals pa.FK_PackageId
                           join a in tblappointments on pa.FK_AppointmentId equals a.AppointmentId
                           join pd in tblpackagedtls on p.Id equals pd.Package_Id
                           join ser in tblservices on pd.ServiceId equals ser.ServiceId
                           where (a.AppointmentId == appointmentid) && (p.Id == packageId) && (a.FK_BranchID == branchID)
                           select (new
                           {
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName
                           })
                                   ).ToList().Select(x => new tblservice()
                                   {
                                       ServiceId = x.ServiceId,
                                       ServiceName = x.ServiceName
                                   });
            if (service != null)
            {
                foreach (var item in service)
                    objtblservice.Add(new tblservice() { ServiceId = item.ServiceId, ServiceName = item.ServiceName });
            }

            return objtblservice;
        }
        public tblservice GetAllServicesByServiceIdAppointmentId(int appointmentid, int? ServiceId, int? branchID)
        {
            tblservice objtblservice = new tblservice();
            var service = (from a in tblappointments
                           join aps in tblappointmentservicemappings on a.AppointmentId equals aps.FK_AppointmentId
                           join ser in tblservices on aps.FK_ServiceId equals ser.ServiceId
                           where (a.AppointmentId == appointmentid) && (ser.ServiceId == ServiceId) && (a.FK_BranchID == branchID)
                           select (new
                           {
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName
                           })
                               ).ToList().Select(x => new tblservice()
                               {
                                   ServiceId = x.ServiceId,
                                   ServiceName = x.ServiceName
                               }).FirstOrDefault();

            if (service != null)
            {
                objtblservice = (tblservice)service;
                return objtblservice;
            }
            else
            {
                return null;
            }




        }
        public List<AppointmentEL> GetAllApppointment(int? branchID, int bypackage)
        {
            List<AppointmentEL> objAppointmentEL = new List<AppointmentEL>();
            if (bypackage == 1)
            {
                objAppointmentEL = (from c in tblclients
                                    join ap in tblappointments on c.ClientId equals ap.FK_ClientId
                                    join app in tblappointmentpackageppings on ap.AppointmentId equals app.FK_AppointmentId
                                    join p in tblpackages on app.FK_PackageId equals p.Id
                                    join pd in tblpackagedtls on p.Id equals pd.Package_Id
                                    join
                                        //join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                                        ser in tblservices on pd.ServiceId equals ser.ServiceId
                                    //where (ap.AppointmentDate == DateTime.Today && c.IsActive == true && ap.FK_BranchID == branchID
                                    where (c.IsActive == true && ap.FK_BranchID == branchID && ap.ByPackage == true

                                    )
                                    select new AppointmentEL()
                                     {
                                         ClientName = c.ClientName,
                                         CaseHistory = c.CaseHistory,
                                         AppointmentDate = ap.AppointmentDate,
                                         AppointmentTime = ap.AppointmentTime,
                                         TotalPaid = ap.Total == null ? 0 : ap.Total,
                                         DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount,
                                         Discount = ap.Discount == null ? 0 : ap.Discount,
                                         Service = ser.ServiceName
                                     }).ToList();
            }
            else
            {
                objAppointmentEL = (from c in tblclients
                                    join ap in tblappointments on c.ClientId equals ap.FK_ClientId
                                    join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                                    //join p in tblpackages on aps.FK_PackageId equals p.Id
                                    //join pd in tblpackagedtls on p.Id equals pd.Package_Id
                                    join
                                        //join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                                        ser in tblservices on aps.FK_ServiceId equals ser.ServiceId
                                    //where (ap.AppointmentDate == DateTime.Today && c.IsActive == true && ap.FK_BranchID == branchID
                                    where (c.IsActive == true && ap.FK_BranchID == branchID && ap.ByPackage == false

                                    )
                                    select new AppointmentEL()
                                    {
                                        ClientName = c.ClientName,
                                        CaseHistory = c.CaseHistory,
                                        AppointmentDate = ap.AppointmentDate,
                                        AppointmentTime = ap.AppointmentTime,
                                        TotalPaid = ap.Total == null ? 0 : ap.Total,
                                        DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount,
                                        Discount = ap.Discount == null ? 0 : ap.Discount,
                                        Service = ser.ServiceName
                                    }).ToList();

            }
            return objAppointmentEL.OrderByDescending(x => x.AppointmentDate).ToList();
        }
        //.................Code Added By Sam on 25052016...........................

        //public List<AppointmentEL> GetAllApppointmentNewFortest(int? branchID, int bypackage)
        public IEnumerable<AppointmentEL> GetAllApppointmentNewFortest(int? branchID, int bypackage)
        {
            List<AppointmentEL> objAppointmentEL = new List<AppointmentEL>();

            List<string> ServiceList = new List<string>();
            string serv = "";
            if (bypackage == 1)
            {

                // ..................Code Added by Sam on 26052016...........................
                var TodayAppointment = tblappointments.Where(x => x.FK_BranchID == branchID && x.ByPackage == true && x.IsActive == true && x.AppointmentDate == DateTime.Today).Select(x => new AppointmentEL
                {
                    TherapistName = x.tbltherapist.Name,
                    AppointmentId = x.AppointmentId,
                    Discount = x.Discount,
                    DueAmount = x.DueAmount,
                    TotalAmount = x.GrossAmount,
                    AppointmentDate = x.AppointmentDate,
                    AppointmentTime = x.AppointmentTime,
                    advanceamount = x.AdvanceAmount,
                    TotalPaid = x.Total,
                    recievedamount = x.ReceivedAmount,
                    balanceamount = x.BalanceAmount,
                    paymenttype = x.PaymentType,
                    clientid = x.FK_ClientId
                }).ToList().OrderBy(x => x.AppointmentId);
                if (TodayAppointment != null && TodayAppointment.Count() > 0)
                {
                    foreach (var varTodayAppointment in TodayAppointment)
                    {
                        var client = tblclients.Where(x => x.ClientId == varTodayAppointment.clientid).Select(x => new AppointmentEL
                        {

                            clientid = x.ClientId,
                            ClientName = x.ClientName
                        }).FirstOrDefault();
                        if (client != null)
                        {
                            varTodayAppointment.clientid = client.clientid;
                            varTodayAppointment.ClientName = client.ClientName;
                        }
                        var appkg = (from apppkg in tblappointmentpackageppings where apppkg.FK_AppointmentId == varTodayAppointment.AppointmentId select apppkg).ToList();
                        if (appkg != null && appkg.Count > 0)
                        {
                            foreach (var pkgid in appkg)
                            {
                                var package = (from pkg in tblpackages where pkg.Id == pkgid.FK_PackageId select pkg).FirstOrDefault();
                                if (package != null)
                                {

                                    //foreach (var pkgdtl in package)
                                    //{

                                    varTodayAppointment.PackageName = package.Package_Name;
                                    var pkgdetail = (from pkdetail in tblpackagedtls where pkdetail.Package_Id == package.Id select pkdetail).ToList();
                                    if (pkgdetail != null && pkgdetail.Count > 0)
                                    {
                                        foreach (var varpkgdetail in pkgdetail)
                                        {
                                            string serviceName = (from ser in tblservices where ser.ServiceId == varpkgdetail.ServiceId select ser.ServiceName).FirstOrDefault();
                                            ServiceList.Add(serviceName);
                                        }

                                        if (ServiceList != null && ServiceList.Count > 0)
                                        {
                                            foreach (string service in ServiceList)
                                            {
                                                serv += service + ",";
                                            }
                                            varTodayAppointment.ServiceName = serv.TrimEnd(',');
                                            ServiceList.Clear();
                                            serv = null;
                                        }
                                    }

                                    //}
                                }

                            }
                        }
                    }
                }

                return TodayAppointment;
            }
            else
            {
                var TodayAppointment = tblappointments.Where(x => x.FK_BranchID == branchID && x.ByPackage == false && x.IsActive == true && x.AppointmentDate == DateTime.Today).Select(x => new AppointmentEL
                {
                    TherapistName = x.tbltherapist.Name,
                    AppointmentId = x.AppointmentId,
                    Discount = x.Discount,
                    DueAmount = x.DueAmount,
                    TotalAmount = x.GrossAmount,
                    AppointmentDate = x.AppointmentDate,
                    AppointmentTime = x.AppointmentTime,
                    advanceamount = x.AdvanceAmount,
                    TotalPaid = x.Total,
                    recievedamount = x.ReceivedAmount,
                    balanceamount = x.BalanceAmount,
                    paymenttype = x.PaymentType,
                    clientid = x.FK_ClientId
                }).ToList().OrderBy(x => x.AppointmentId);
                if (TodayAppointment != null && TodayAppointment.Count() > 0)
                {
                    foreach (var varTodayAppointment in TodayAppointment)
                    {
                        var client = tblclients.Where(x => x.ClientId == varTodayAppointment.clientid).Select(x => new AppointmentEL
                        {

                            clientid = x.ClientId,
                            ClientName = x.ClientName
                        }).FirstOrDefault();
                        if (client != null)
                        {
                            varTodayAppointment.clientid = client.clientid;
                            varTodayAppointment.ClientName = client.ClientName;
                        }
                        var appserivce = (from appser in tblappointmentservicemappings where appser.FK_AppointmentId == varTodayAppointment.AppointmentId select appser).ToList();
                        if (appserivce != null && appserivce.Count > 0)
                        {
                            foreach (var serid in appserivce)
                            {
                                string serviceName = (from ser in tblservices where ser.ServiceId == serid.FK_ServiceId select ser.ServiceName).FirstOrDefault();
                                ServiceList.Add(serviceName);
                            }

                            if (ServiceList != null && ServiceList.Count > 0)
                            {
                                foreach (string service in ServiceList)
                                {
                                    serv += service + ",";
                                }
                                varTodayAppointment.ServiceName = serv.TrimEnd(',');
                                ServiceList.Clear();
                                serv = null;
                            }
                        }
                    }
                }
                return TodayAppointment;
            }

        }
        // ..................Code Added Above by Sam on 26052016...........................

        //var client = tblclients.Where(x => x.FK_BranchID == branchID && x.IsActive == true).Select(x => new AppointmentEL
        //{

        //    clientid=x.ClientId,
        //    ClientName=x.ClientName 
        //}).ToList().OrderBy(x => x.clientid); 
        //foreach (var item in client)
        //{
        //    var appoint = (from ap in tblappointments where ap.FK_ClientId == item.clientid && ap.ByPackage == true select ap).ToList();
        //    if (appoint != null && appoint.Count > 0)
        //    {
        //        foreach (var appitem in appoint)
        //        {
        //            var appkg = (from apppkg in tblappointmentpackageppings where apppkg.FK_AppointmentId == appitem.AppointmentId select apppkg).ToList();
        //            if (appkg != null && appkg.Count > 0)
        //            {
        //                foreach (var pkgid in appkg)
        //                {
        //                    var package = (from pkg in tblpackages where pkg.Id == pkgid.FK_PackageId select pkg).ToList();
        //                    if (package != null && package.Count > 0)
        //                    {

        //                        foreach (var pkgdtl in package)
        //                        {
        //                            item.PackageName = pkgdtl.Package_Name;
        //                            var pkgdetail = (from pkdetail in tblpackagedtls where pkdetail.Package_Id == pkgdtl.Id select pkdetail).ToList();
        //                            if (pkgdetail != null && pkgdetail.Count > 0)
        //                            {
        //                                foreach (var varpkgdetail in pkgdetail)
        //                                {
        //                                    string serviceName = (from ser in tblservices where ser.ServiceId == varpkgdetail.ServiceId select ser.ServiceName).FirstOrDefault();
        //                                    ServiceList.Add(serviceName);
        //                                }

        //                                if(ServiceList!=null && ServiceList.Count>0)
        //                                {
        //                                    foreach (string service in ServiceList)
        //                                    {
        //                                        serv += service + ",";
        //                                    }
        //                                    item.ServiceName = serv.TrimEnd(',');
        //                                    ServiceList.Clear();
        //                                    serv = null; 
        //                                }
        //                            }

        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //}



        //objAppointmentEL = (from c in tblclients
        //                    join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                    join app in tblappointmentpackageppings on ap.AppointmentId equals app.FK_AppointmentId
        //                    join p in tblpackages on app.FK_PackageId equals p.Id
        //                    join pd in tblpackagedtls on p.Id equals pd.Package_Id
        //                    join
        //                        //join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                        ser in tblservices on pd.ServiceId equals ser.ServiceId
        //                    //where (ap.AppointmentDate == DateTime.Today && c.IsActive == true && ap.FK_BranchID == branchID
        //                    where (c.IsActive == true && ap.FK_BranchID == branchID && ap.ByPackage == true

        //                    )
        //                    select new AppointmentEL()
        //                    {
        //                        ClientName = c.ClientName,
        //                        CaseHistory = c.CaseHistory,
        //                        AppointmentDate = ap.AppointmentDate,
        //                        AppointmentTime = ap.AppointmentTime,
        //                        TotalPaid = ap.Total == null ? 0 : ap.Total,
        //                        DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount,
        //                        Discount = ap.Discount == null ? 0 : ap.Discount,
        //                        Service = ser.ServiceName
        //                    }).ToList();
        //return client;
        //    }
        //    else
        //    {
        //objAppointmentEL = (from c in tblclients
        //                    join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                    join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                    //join p in tblpackages on aps.FK_PackageId equals p.Id
        //                    //join pd in tblpackagedtls on p.Id equals pd.Package_Id
        //                    join
        //                        //join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                        ser in tblservices on aps.FK_ServiceId equals ser.ServiceId
        //                    //where (ap.AppointmentDate == DateTime.Today && c.IsActive == true && ap.FK_BranchID == branchID
        //                    where (c.IsActive == true && ap.FK_BranchID == branchID && ap.ByPackage == false

        //                    )
        //                    select new AppointmentEL()
        //                    {
        //                        ClientName = c.ClientName,
        //                        CaseHistory = c.CaseHistory,
        //                        AppointmentDate = ap.AppointmentDate,
        //                        AppointmentTime = ap.AppointmentTime,
        //                        TotalPaid = ap.Total == null ? 0 : ap.Total,
        //                        DueAmount = ap.DueAmount == null ? 0 : ap.DueAmount,
        //                        Discount = ap.Discount == null ? 0 : ap.Discount,
        //                        Service = ser.ServiceName
        //                    }).ToList();
        //    return null;

        //}

        //     return null;
        //return objAppointmentEL.OrderByDescending(x => x.AppointmentDate).ToList();
        //}




        //.................Code Added Above By Sam on 25052016...........................
        public tblappointment GetAllApppointmentByID(int appointmentId, int? branchID)
        {
            return tblappointments.Where(x => x.AppointmentId == appointmentId && x.FK_BranchID == branchID).FirstOrDefault();

        }
        public tblappointment GetAllApppointmentByClientid(int clientid, string mobile, int? branchID)
        {
            tblappointment objtblappointment = new tblappointment();
            var appointment = (from app in tblappointments
                               join c in tblclients on app.FK_ClientId equals c.ClientId
                               where c.ClientId == clientid && c.Mobile == mobile && c.FK_BranchID == branchID
                               select new
                               {
                                   AppointmentId = app.AppointmentId
                               }).ToList().Select(x => new tblappointment()
                                   {
                                       AppointmentId = x.AppointmentId
                                   }).FirstOrDefault();
            return appointment;
            //return tblappointments.Where(x => x.AppointmentId == appointmentId && x.FK_BranchID == branchID).FirstOrDefault();
        }
        //public decimal? GetServiceChargeByServiceId(int serviceid,int branchid)
        //{
        //    tblservice objtblservice = tblservices.Where(x => x.ServiceId == serviceid && x.FK_BranchID == branchid && x.IsActive == true).FirstOrDefault();
        //    if(objtblservice!=null)
        //    {
        //        decimal? amt = objtblservice.Amount;
        //        return amt;
        //    }
        //    else
        //    {

        //    }
        //}

        //public List<tblTaxConfiguration> GetTaxDetails()
        //{
        //    List<tblTaxConfiguration> tax = tblTaxConfigurations.Where(x => x.IsActive == true).ToList();
        //    return tax;
        //}
        public int InsertUpdateAppointmentServiceMapping(tblappointmentservicemapping objAppointmentServiceMapping)
        {

            try
            {
                if (objAppointmentServiceMapping.AppointmentServiceId == 0)
                {
                    tblappointmentservicemappings.Add(objAppointmentServiceMapping);
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objAppointmentServiceMapping.AppointmentServiceId;
        }
        public List<AppointmentEL> GetAllPayment(int? branchID)
        {

            List<AppointmentEL> ApppointmentList = tblappointments.Where(x => x.AppointmentDate == DateTime.Today && x.GrossAmount != null && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
            {

                AppointmentId = x.AppointmentId,
                Service = x.tblservice.ServiceName,
                ServiceCharge = x.tblservice.Amount,
                //ServiceList = x.tblappointmentservicemappings.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
                //                new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList(),
                //ServiceCharge = x.tblappointmentservicemappings.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
                //new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).Sum(r => r.Amount),
                Discount = x.Discount == null ? 0 : x.Discount,
                TotalAmount = x.GrossAmount == null ? 0 : x.GrossAmount
            }).ToList();

            //foreach (var item in ApppointmentList)
            //{
            // //   var services = tblappointmentservicemappings.Where(m => m.FK_AppointmentId == item.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
            // //                    new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList();
            //    string ServicesName = string.Empty;

            //    var services = item.ServiceList;

            //    foreach (var service in services)
            //    {
            //        ServicesName += service.ServiceName + ",";
            //    }
            //    item.Service =ServicesName !="" ? ServicesName.Substring(0, ServicesName.Length - 1) : "";
            //}

            return ApppointmentList;
        }
        public bool GetAppointmentByTimeAndDate(string appointmenttime, DateTime? day, int? branchID)
        {
            bool ret = false;

            tblappointment t = new tblappointment();

            t = tblappointments.Where(x => x.AppointmentTime == appointmenttime && x.AppointmentDate == day && x.IsActive == true && x.FK_BranchID == branchID).FirstOrDefault();
            if (t != null)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        public List<AppointmentEL> GetAllApppointmentList(int? branchID)
        {
            List<AppointmentEL> ApppointmentList = tblappointments.Where(x => x.FK_BranchID == branchID && x.GrossAmount > 0).Select(x => new AppointmentEL()
            {
                AppointmentId = x.AppointmentId,
                ClientName = x.tblclient.ClientName,
                //PatientName = x.tblpatient.PatientName,
                CaseHistory = x.tblclient.CaseHistory,
                AppointmentDate = x.AppointmentDate,
                AppointmentTime = x.AppointmentTime,
                TotalPaid = x.Total == null ? 0 : x.Total,
                DueAmount = x.DueAmount == null ? 0 : x.DueAmount,
                Discount = x.Discount == null ? 0 : x.Discount,
                Service = x.tblservice.ServiceName,
                IsActive = x.IsActive,
                Status = x.IsActive == true ? "Active" : "Cancelled"
                //ServiceList = x.tblappointmentservicemappings.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
                //             new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList(),

            }).ToList();

            //foreach (var item in ApppointmentList)
            //{
            //    // var services = tblappointmentservicemappings.Where(m => m.FK_AppointmentId == item.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
            //    //                  new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList();
            //    string ServicesName = string.Empty;

            //    var services = item.ServiceList;

            //    foreach (var service in services)
            //    {
            //        ServicesName += service.ServiceName + ",";
            //    }
            //    item.Service = ServicesName != "" ? ServicesName.Substring(0, ServicesName.Length - 1) : "";
            //}

            return ApppointmentList;
        }
        // ............................. Code Commented by Sandip 17032016.........................

        //public List<AppointmentEL> GetAllApppointmentBySearchCriteria(string patientName, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID)
        //{

        //    List<AppointmentEL> ApppointmentList = tblappointments.Where(x => x.tblpatient.PatientName == (patientName == "" ? x.tblpatient.PatientName : patientName)
        //         && (EntityFunctions.TruncateTime(x.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(x.AppointmentDate)))
        //                             && (EntityFunctions.TruncateTime(x.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(x.AppointmentDate)))
        //                             && (x.FK_ServiceId == (ServiceType == 0 ? x.FK_ServiceId : ServiceType))
        //                             && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
        //                             {
        //                                 PatientName = x.tblpatient.PatientName,
        //                                 CaseHistory = x.tblpatient.CaseHistory,
        //                                 AppointmentDate = x.AppointmentDate,
        //                                 AppointmentTime = x.AppointmentTime,
        //                                 TotalPaid = x.Total == null ? 0 : x.Total,
        //                                 DueAmount = x.DueAmount == null ? 0 : x.DueAmount,
        //                                 Discount = x.Discount == null ? 0 : x.Discount,
        //                                 Service = x.tblservice.ServiceName,
        //                                 IsActive = x.IsActive,
        //                                 Status = x.IsActive == true ? "Active" : "Cancelled"
        //                                 //ServiceList = x.tblappointmentservicemappings.Where(m => m.FK_AppointmentId == x.AppointmentId).Where(t => t.FK_ServiceId == t.tblservice.ServiceId).Select(s =>
        //                                 //             new ServiceCharges() { ServiceName = s.tblservice.ServiceName, Amount = s.tblservice.Amount }).ToList(),
        //                             }).ToList();

        //    //foreach (var item in ApppointmentList)
        //    //{
        //    //    string ServicesName = string.Empty;

        //    //    var services = item.ServiceList;

        //    //    foreach (var service in services)
        //    //    {
        //    //        ServicesName += service.ServiceName + ",";
        //    //    }
        //    //    item.Service = ServicesName != "" ? ServicesName.Substring(0, ServicesName.Length - 1) : "";
        //    //}


        //    return ApppointmentList;
        //}

        // ............................. Code above Commented by Sandip 17032016.........................
        public void CancelAppointment(string AppId, bool active, int? branchID)
        {

            try
            {

                //var ls = AppId.Split(',');
                var ls = AppId.Split(new[] { ',' }).Select(Int32.Parse).ToList();

                // var objAppointment = new tblappointment() { AppointmentId = AppId, IsActive = active };

                var some = tblappointments.Where(x => ls.Contains(x.AppointmentId) && x.FK_BranchID == branchID).ToList();
                some.ForEach(a => a.IsActive = active);


                // tblappointments.Attach(objAppointment);
                // Entry(objAppointment).Property(X => X.IsActive).IsModified = true;
                SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<tblservice> GetAllServiceByPackageId(int packageid, int? branchID)
        {
            List<tblservice> servicelist = new List<tblservice>();
            var data = (from p in tblpackages.Where(p => p.Id == packageid && p.fk_BranchID == branchID)
                        join pd in tblpackagedtls on p.Id equals pd.Package_Id
                        join ser in tblservices on pd.ServiceId equals ser.ServiceId
                        //where (p.Package_Id == packageid
                        //      && p.fk_BranchID == branchID && p.IsActive==true)
                        //      && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate)))
                        //      && (aps.FK_ServiceId == (ServiceType != 1 ? ServiceType : aps.FK_ServiceId)
                        //)

                        //                    public string Package_Id { get; set; }
                        //public string Package_Name { get; set; }
                        //public int Package_Validity { get; set; }
                        //public Decimal Package_Rate { get; set; }

                        //public int ServiceId { get; set; }
                        //public string ServiceName { get; set; }

                        select new
                        {
                            ServiceId = ser.ServiceId,
                            ServiceName = ser.ServiceName,
                            Amount = p.Package_Rate

                        }).ToList();
            // servicelist = (List<tblservice>)data;
            foreach (var item in data)
            {
                servicelist.Add(new tblservice() { ServiceId = item.ServiceId, ServiceName = item.ServiceName + "  (RS: " + Convert.ToString(item.Amount) + ")", Amount = item.Amount });
            }
            return servicelist;
        }
        //public bool GetCouponValidity(string couponid,int? branchid)
        //{  
        //    tblcoupanmaster objtblcoupanmaster=new tblcoupanmaster();
        //     //EntityFunctions.
        //    //int? valid = EntityFunctions.DiffDays(validDate, curdt);

        //    string startDateAsString = System.DateTime.Today.ToString("yyyyMMdd");
        //    objtblcoupanmaster = tblcoupanmasters.Where(x => x.Coupon_Id == couponid && x.FK_BranchID == branchid).FirstOrDefault();



        //     if (objtblcoupanmaster != null)
        //     {
        //         DateTime validDate = objtblcoupanmaster.Coupan_SDateVld.Value.AddDays(Convert.ToDouble(objtblcoupanmaster.Coupan_Validity));
        //         DateTime curdt = System.DateTime.Now;
        //         var days = (validDate - curdt).Days;
        //         if((int)days>0)
        //         {
        //              return true;
        //         }
        //         else
        //         {
        //            return false;
        //          }

        //     }
        //     else
        //     {
        //         return false;
        //     }


        //    //if (objtblcoupanmaster != null)
        //        //bool isactive=tblcoupanmasters.Where(x=>x.)

        //}
        public tblcoupanmaster GetCouponValidity(string couponid, int? branchid)
        {
            tblcoupanmaster objtblcoupanmaster = new tblcoupanmaster();
            return objtblcoupanmaster = tblcoupanmasters.Where(x => x.Coupan_Name == couponid && x.FK_BranchID == branchid && x.IsActive == true).FirstOrDefault();
            //if (objtblcoupanmaster != null)
            //{
            //    DateTime validDate = objtblcoupanmaster.Coupan_SDateVld.Value.AddDays(Convert.ToDouble(objtblcoupanmaster.Coupan_Validity));
            //    DateTime curdt = System.DateTime.Now;
            //    var days = (validDate - curdt).Days;
            //    if ((int)days > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}
            //else
            //{
            //    return false;
            //}




        }
        public decimal? GetServiceChargeByServiceId(int id, int? branchid)
        {
            decimal? amount = tblservices.Where(x => x.ServiceId == id && x.FK_BranchID == branchid && x.IsActive == true).Select(y => y.Amount).FirstOrDefault();
            return amount;


        }
        public List<tblpackage> GetAllPackage(int? branchid)
        {

            List<tblpackage> packagelist = tblpackages.Where(x => x.fk_BranchID == branchid && x.IsActive == true).ToList();
            return packagelist.OrderBy(x => x.Package_Name).ToList();
        }
        public tbltherapist GetAllTherapist(int? branchid, string time, DateTime date, int? thId)
        {
            //List<tbltherapist> therapistlist = tbltherapists.Where(x => x.FK_BranchId == branchid && x.IsActive == true).ToList();
            //return therapistlist.OrderBy(x => x.Name).ToList();

            tbltherapist therapistlist = tbltherapists.Where(x => x.FK_BranchId == branchid && x.IsActive == true && x.Availability.StartsWith(time) && x.TherapistId == thId).FirstOrDefault();
            if (therapistlist != null)
            {
                //therapistlist.Name = therapistlist.Name + " (" + GetTherapistAvailability(thId) + ") ";
                //therapistlist.Name = therapistlist.Name + " (" + GetTherapistAvailability(date, time, thId) + ") ";
            }
            return therapistlist;
        }
        public List<tblcoupanmaster> GetAllCouponNameByName(string taxname, int? branchid)
        {

            List<tblcoupanmaster> CouponList = tblcoupanmasters.Where(x => x.IsActive == true && x.Coupan_Name.Contains(taxname)).Select(x => new
            {
                Coupon_Id = x.Coupon_Id,
                Coupan_Name = x.Coupan_Name
            }).ToList().Select(t => new tblcoupanmaster()
            {
                Coupon_Id = t.Coupon_Id,
                Coupan_Name = t.Coupan_Name
            }).ToList();

            return CouponList;
        }


        public int GetIdByName(string cname, int? branchId)
        {
            return tblcoupanmasters.Where(x => x.FK_BranchID == branchId && x.Coupon_Id == cname).Select(x => x.Id).FirstOrDefault();
        }
        #region Appointment Payment Form Start

        #region Get Method for Appointment Payment



        public List<tblservice> GetAllServicesByPackageIDforPayment(int packageid, int? branchID)
        {
            List<tblservice> ServiceList = new List<tblservice>();
            var Service = (from pkg in tblpackages
                           join pkgdtl in tblpackagedtls on pkg.Id equals pkgdtl.Package_Id
                           join ser in tblservices on pkgdtl.ServiceId equals ser.ServiceId
                           where pkg.Id == packageid && pkg.fk_BranchID == branchID
                           select new
                           {
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName
                           }).ToList().Select(x => new tblservice()
                           {
                               ServiceId = x.ServiceId,
                               ServiceName = x.ServiceName
                           });
            return Service.OrderBy(x => x.ServiceId).ToList();

        }

        public List<tblservice> GetAllServiceByPackageIDforPayment(int packageid, int? branchID)
        {
            List<tblservice> ServiceList = new List<tblservice>();
            ServiceList = (from pkg in tblpackages
                           join pkgdtl in tblpackagedtls on pkg.Id equals pkgdtl.Package_Id
                           join ser in tblservices on pkgdtl.ServiceId equals ser.ServiceId
                           where pkg.Id == packageid && pkg.fk_BranchID == branchID
                           select new
                       {
                           ServiceId = ser.ServiceId,
                           ServiceName = ser.ServiceName
                       }).AsEnumerable().Select(x => new tblservice
                          {
                              ServiceId = x.ServiceId,
                              ServiceName = x.ServiceName
                          }).ToList();
            return ServiceList.OrderBy(x => x.ServiceId).ToList();

        }

        public List<tblservice> GetAllServicesByAppointmnetIdforPayment(int appointmentid, int? branchID)
        {
            List<tblservice> ServiceList = new List<tblservice>();
            var Service = (from app in tblappointments
                           join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                           join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                           where app.AppointmentId == appointmentid && app.FK_BranchID == branchID
                           select new
                           {
                               ServiceId = ser.ServiceId,
                               ServiceName = ser.ServiceName
                           }).ToList().Select(x => new tblservice()
                           {
                               ServiceId = x.ServiceId,
                               ServiceName = x.ServiceName
                           });
            return Service.OrderBy(x => x.ServiceId).ToList();
        }

        public AppointmentEL GetApppointmentByIDforPayment(int appointmentId, int? branchID)
        {
            tblappointment objtblappointment = new tblappointment();
            objtblappointment = tblappointments.Where(x => x.AppointmentId == appointmentId && x.FK_BranchID == branchID).FirstOrDefault();
            if (objtblappointment.ByPackage == true)
            {
                var item = (from app in tblappointments
                            join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                            join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == appointmentId && app.FK_BranchID == branchID

                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                packageid = pkg.Id,
                                ServiceName = pkg.Package_Name,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                paymentmode = app.PaymentMode,
                                // Code added by Sam on 12092016................
                                //TotalAmount = app.GrossAmount,
                                TotalAmount = app.Total,
                                // Code Above added by Sam on 12092016................
                                advanceamount = app.AdvanceAmount,

                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,


                                FK_TaxId = app.FK_TaxId,
                                TaxAmount = app.TaxAmount,
                                CouponDiscountAmount = app.CouponDiscountAmount,
                                ManualDiscountPercentage = app.ManualDiscountPercentage,
                                ManualDiscountAmount = app.ManualDiscountAmount,
                                NetPayableAmount = app.NetPayableAmount,
                                PaymentDoneAmount = app.PaymentDoneAmount,
                                IsPaymentComplete = app.IsPaymentComplete,
                                IsPaymentProcessStarted = app.IsPaymentProcessStarted,
                                FK_CouponId = app.FK_CouponId
                            }).FirstOrDefault();
                return item;
            }
            else if (objtblappointment.ByPackage == false)
            {
                var item = (from app in tblappointments
                            join apser in tblappointmentservicemappings on app.AppointmentId equals apser.FK_AppointmentId
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where app.AppointmentId == appointmentId && app.FK_BranchID == branchID
                            select new AppointmentEL()
                            {
                                AppointmentId = app.AppointmentId,
                                ClientName = c.ClientName,
                                AppointmentDate = app.AppointmentDate,
                                paymenttype = app.PaymentType,
                                paymentmode = app.PaymentMode,
                                // Code added by Sam on 12092016................
                                //TotalAmount = app.GrossAmount,
                                TotalAmount = app.Total,
                                // Code Above added by Sam on 12092016................
                                advanceamount = app.AdvanceAmount,
                                recievedamount = app.ReceivedAmount,
                                Discount = app.Discount,
                                DueAmount = app.DueAmount,
                                IsActive = app.IsActive,

                                FK_TaxId = app.FK_TaxId,
                                TaxAmount = app.TaxAmount,
                                CouponDiscountAmount = app.CouponDiscountAmount,
                                ManualDiscountPercentage = app.ManualDiscountPercentage,
                                ManualDiscountAmount = app.ManualDiscountAmount,
                                NetPayableAmount = app.NetPayableAmount,
                                PaymentDoneAmount = app.PaymentDoneAmount,
                                IsPaymentComplete = app.IsPaymentComplete,
                                IsPaymentProcessStarted = app.IsPaymentProcessStarted,
                                FK_CouponId = app.FK_CouponId
                            }).FirstOrDefault();
                return item;
            }
            else
            {
                return null;
            }

        }

        public tblappointment GetApppointmentByID(int appointmentId, int? branchID)
        {
            return tblappointments.Where(x => x.AppointmentId == appointmentId && x.FK_BranchID == branchID).FirstOrDefault();
        }

        #endregion Get Method for Appointment Payment end

        #region Crud Function Already Mentioned Above

        #endregion Crud Function Already Mentioned Above

        #endregion Appointment Payment Form end
        public tblclient GetAllClientByID(int clientId, string mobile, int? branchID)
        {
            return tblclients.Where(x => x.ClientId == clientId && x.Mobile == mobile && x.FK_BranchID == branchID).FirstOrDefault();
        }
        public List<ClientEL> GetAllClient(int? branchID)
        {
            List<ClientEL> ClientList = (from a in tblclients
                                         //join b in tbl_appointment on a.ClientID equals b.FK_ClientID
                                         where a.IsActive == true && a.FK_BranchID == branchID
                                         select new ClientEL
                                         {
                                             ClientId = a.ClientId,
                                             //AppointmentID = b.AppointmentID,
                                             AddedDate = a.AddedDate,
                                             Address = a.Address,
                                             CaseHistory = a.CaseHistory,
                                             DateOfBirth = a.DateOfBirth,
                                             Email = a.Email,
                                             //HasMediclaim = x.HasMediclaim,
                                             IsActive = a.IsActive,
                                             MaritalStatus = a.MaritalStatus,
                                             Sex = a.Sex,
                                             Mobile = a.Mobile,
                                             //ClientId = x.ClientID,
                                             ClientName = a.ClientName,
                                             ReferralSource = a.ReferralSource,
                                             SendEmail = a.SendEmail,
                                             SendSMS = a.SendSMS

                                         }).ToList();
            foreach (var item in ClientList)
            {

                var appId = tblappointments.Where(x => x.FK_ClientId == item.ClientId && x.FK_BranchID == branchID).Select(x => x.AppointmentId).FirstOrDefault();
                //item.AppointmentID = appId;
            }

            if (ClientList != null) { return ClientList; }
            else { return ClientList = null; }
        }
        public List<ClientEL> GetAllClientForBirthday(string ClientName, string planType, DateTime? FromDate, DateTime? toDate, int? branchID)
        {
            List<ClientEL> ClientList = new List<ClientEL>();

            // Search Only By ClientName
            if (!string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(planType) && FromDate == null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (client.ClientName == ClientName && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search Only By Date
            else if (string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(planType) && FromDate != null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate) && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search Only By PlanType
            else if (string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(planType) && FromDate == null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              //where (appt.PlanType == planType && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search By ClientName & Date
            else if (!string.IsNullOrEmpty(ClientName) && string.IsNullOrEmpty(planType) && FromDate != null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (client.ClientName == ClientName && EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate)
                              && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search By PlanType & Date
            else if (string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(planType) && FromDate != null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (
                                  //appt.PlanType == planType &&
                              EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate)
                              && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search By ClientName & PlanType
            else if (!string.IsNullOrEmpty(ClientName) && !string.IsNullOrEmpty(planType) && FromDate == null)
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (
                                  //appt.PlanType == planType && 
                              client.ClientName == ClientName
                              && client.FK_BranchID == branchID)
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            // Search By All Fields
            else
            {
                ClientList = (from client in tblclients
                              join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                              where (client.ClientName == ClientName && client.FK_BranchID == branchID
                                  //&& (appt.PlanType == planType)
                              && EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate))
                              select new ClientEL()
                              {
                                  ClientId = client.ClientId,
                                  ClientName = client.ClientName,
                                  Sex = client.Sex,
                                  Address = client.Address,
                                  DateOfBirth = (DateTime)client.DateOfBirth,
                                  Email = client.Email,
                                  Mobile = client.Mobile,
                              }).ToList();
            }
            return ClientList;
        }
        public tbltaxmaster GetTaxMasterDetail(int taxid, int? branchID)
        {
            return tbltaxmasters.Where(x => x.Tax_Id == taxid && x.FK_BranchID == branchID).FirstOrDefault();
        }
        public string GetTherapistAvailability(int? thId, string day)
        {
            string status = "";
            string s = day.Substring(0, 2).ToUpper() + " ->Full Day";
            var query = tbltherapists.Where(x => x.TherapistId == thId && x.TherapistLeave.Contains(s)).Select(x => x.TherapistId).FirstOrDefault();
            if (query != 0) { status = "Not Available"; } else { status = "Available"; }
            return status;
        }
        public string GetStatus(int? thId, DateTime? date, TimeSpan? time)
        {
            string status = "";
            string days = date.Value.DayOfWeek.ToString();

            var v = tblappointments.Where(x => EntityFunctions.TruncateTime(x.AppointmentDate) == EntityFunctions.TruncateTime(date)).Select(x => x.AppointmentTime).ToList();

            if (v.Count() == 0)
            {
                status = "Available";
            }
            else
            {
                foreach (var item in v)
                {
                    string[] split = item.Split('-');
                    string t = split[0].Trim();

                    TimeSpan fdt = TimeSpan.Parse(split[0].Trim().Substring(0, 5));
                    TimeSpan tdt = TimeSpan.Parse(split[1].Trim().Substring(0, 5)); //  && thp.Days.Contains(days)

                    // Here, I am checking, if the 'SelectedTime' lies between 'fdt' and 'tdt' of column 'AppointmentTime' from table 'Appointment'
                    if (time >= fdt && time <= tdt)
                    {
                        var query = (from app in tblappointments
                                     join thp in tbltherapists on app.FK_TherapistId equals thp.TherapistId
                                     where (app.FK_TherapistId == thId && EntityFunctions.TruncateTime(app.AppointmentDate) == EntityFunctions.TruncateTime(date)
                                     && app.AppointmentTime.StartsWith(t))
                                     select (thp.TherapistId)).FirstOrDefault();
                        if (query > 0)
                        {
                            status = "Not Available";
                        }
                        else if (query == 0)
                        {
                            var r = tbltherapists.Where(x => x.TherapistId == thId && x.Days.Contains(days) && x.TherapistLeave.Contains("Full Day")).Select(x => x.TherapistId).FirstOrDefault();
                            //if (r != 0) { status = "Available"; } else { status = "Not Available"; }
                            if (r != 0) { status = "Not Available"; } else { status = "Available"; }
                        }
                    }
                    else if (time <= fdt && time >= tdt)
                    { status = "Available"; }
                    else
                    {
                        var thp = tbltherapists.Where(x => x.TherapistId == thId && x.Days.Contains(days) && !x.TherapistLeave.Contains("Full Day")).Select(x => x.TherapistId).FirstOrDefault();
                        //if (thp != 0) { status = "Available"; } else { status = "Not Available"; }
                        if (thp != 0) { status = "Not Available"; } else { status = "Available"; }
                    }
                }
            }
            return status;
        }
        public List<string> GetApptTime(DateTime? dt, int? branchId)
        {
            return tblappointments.Where(x => EntityFunctions.TruncateTime(x.AppointmentDate) == EntityFunctions.TruncateTime(dt) && x.FK_BranchID == branchId).Select(x => x.AppointmentTime).ToList();
        }
        //public List<TherapistEL> Availability(int? branchID)
        //{
        //    var query = tbltherapists.Where(x => x.FK_BranchId == branchID).Select(x => new TherapistEL() { TherapistId = x.TherapistId, Name = x.Name, Availability = x.Availability }).ToList();
        //    return query;
        //}
        public List<TherapistEL> Availability(int? branchID)
        {
            var query = tbltherapists.Where(x => x.FK_BranchId == branchID).Select(x => new TherapistEL() { TherapistId = x.TherapistId, Name = x.Name, Availability = x.Timings }).ToList();
            return query;
        }
        public List<TherapistEL> Availability(string dayname, int? branchID)
        {
            var query = tbltherapists.Where(x => x.FK_BranchId == branchID && x.Days.Contains(dayname)).Select(x => new TherapistEL() { TherapistId = x.TherapistId, Name = x.Name, Availability = x.Timings }).ToList();
            return query;
        }

        public List<TherapistEL> GetTherapistName(int? ThId, DateTime? dt, TimeSpan? t, string day)
        {
            var query = tbltherapists.Where(x => x.TherapistId == ThId).Select(x => new TherapistEL { TherapistId = x.TherapistId, Name = x.Name }).ToList();
            foreach (var item in query)
            {
                //item.Name = item.Name + " (" + GetStatus(item.TherapistId, dt, t) +")";
                item.Name = item.Name + " (" + GetTherapistAvailability(ThId, day) + ")";
            }
            return query.OrderBy(o => o.TherapistId).ToList();
        }
        public List<TherapistEL> GetTherapistByTime(DateTime? dt, TimeSpan? t)
        {
            var query = tbltherapists.Select(x => x.Availability).ToList();
            List<TherapistEL> query1 = new List<TherapistEL>();
            foreach (var item in query)
            {
                string[] split1 = item.Split('-');
                string s = split1[0].Trim();

                TimeSpan fdt1 = TimeSpan.Parse(split1[0].Substring(0, 5));
                TimeSpan tdt2 = TimeSpan.Parse(split1[1].Substring(0, 5));

                TimeSpan SelectedTime1 = (TimeSpan)t;

                if (SelectedTime1 >= fdt1 && SelectedTime1 < tdt2)
                {
                    query1 = tbltherapists.Where(x => x.Availability.StartsWith(s)).Select(x => new TherapistEL { TherapistId = x.TherapistId, Name = x.Name }).ToList();
                    //foreach (var i in query1)
                    //{
                    //    i.Name = i.Name + " (" + GetStatus(i.TherapistId, dt, t) + ")";
                    //}
                    //return query1.OrderBy(o => o.TherapistId).ToList();
                }
            }
            return query1.OrderBy(o => o.TherapistId).ToList();
        }
        public int GetClientIdFromMobile(string mobile)
        {
            var Result = tblclients.Where(x => x.Mobile.Contains(mobile.Trim())).FirstOrDefault();
            int Id = Result.ClientId;
            return Id;
        }
        public List<int> GetThpIdFromTime(string day)
        {
            var r = tbltherapists.Where(x => x.Timings.Contains(day.Substring(0, 1))).Select(x => x.TherapistId).ToList();
            return r;
        }
        //............... Code updated by sam on 07092016.................................... 




        public List<tbltherapist> GetTherepistNameforAppointmentSchedule(int? branchid)
        {

            List<tbltherapist> objtbltherapist = (from th in tbltherapists where th.FK_BranchId == branchid select th).ToList();
            return objtbltherapist;
            //List<tbltherapist>=

            //List<tbltherapist> objtbltherapist = tbltherapists.Where(x => x.FK_BranchId == branchid).Select(x => x.Name,x=>x.t);
            //var therepist = tbltherapists.Where(x => x.FK_BranchId == branchid).Select(x => x.Name).ToList();
            //return therepist; 
        }

        public List<string> GetAppointmentScheduleTimeforTherepist()
        {
            int CalenderInterval = 1;
            List<string> TimeList = new List<string>();
            tblcompdetail comDetails = tblcompdetails.FirstOrDefault();

            int.TryParse(comDetails.Interval.ToString(), out CalenderInterval);

            int startHour = Convert.ToInt32(comDetails.Opening_Time.Substring(0, 2));
            int startMin = Convert.ToInt32(comDetails.Opening_Time.Substring(3, 2));

            int endHour = Convert.ToInt32(comDetails.Closing_Time.Substring(0, 2));
            int endMin = Convert.ToInt32(comDetails.Closing_Time.Substring(3, 2));

            DateTime startTime = new DateTime(2000, 1, 1, startHour, startMin, 0);
            DateTime endTime = new DateTime(2000, 1, 1, endHour, endMin, 0);
            TimeSpan interval = new TimeSpan(1, 0, 0);
            //TimeList = populateDropdownScheduleTimeforTherepist(startTime, endTime, interval);
            switch (CalenderInterval)
            {
                case 1:
                    interval = new TimeSpan(0, 30, 0);
                    TimeList = populateDropdownScheduleTimeforTherepist(startTime, endTime, interval);
                    break;
                case 2:
                    interval = new TimeSpan(1, 0, 0);
                    TimeList = populateDropdownScheduleTimeforTherepist(startTime, endTime, interval);
                    break;
                case 3:
                    interval = new TimeSpan(2, 0, 0);
                    TimeList = populateDropdownScheduleTimeforTherepist(startTime, endTime, interval);
                    break;
            }

            return TimeList;
        }


        private List<string> populateDropdownScheduleTimeforTherepist(DateTime startTime, DateTime endTime, TimeSpan interval)
        {
            var minutesPassed = (int)(interval.TotalMinutes);

            List<string> dropdown = new List<string>();

            DateTime time = startTime;

            while (time < endTime)
            {
                if (Convert.ToInt32(minutesPassed) == 30)
                {
                    dropdown.Add(time.ToString("HH:mm tt") + "-" + time.AddMinutes(30).ToString("HH:mm tt"));
                    time = time.Add(interval);
                }
                if (Convert.ToInt32(minutesPassed) == 60)
                {
                    dropdown.Add(time.ToString("HH:mm tt") + "-" + time.AddHours(1).ToString("HH:mm tt"));
                    time = time.Add(interval);
                }

                if (Convert.ToInt32(minutesPassed) == 120)
                {
                    dropdown.Add(time.ToString("HH:mm tt") + "-" + time.AddHours(2).ToString("HH:mm tt"));
                    time = time.Add(interval);
                }


            }

            return dropdown;
        }


        public List<string> GetCompanyOpeningTime()
        {
            int CalenderInterval = 2;
            List<string> TimeList = new List<string>();

            //int.TryParse(tblappointmentsettings.FirstOrDefault().CalenderInterval.ToString(), out CalenderInterval);
            DateTime startTime = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime endTime = new DateTime(2000, 1, 2, 0, 0, 0);
            TimeSpan interval = new TimeSpan(1, 0, 0);
            TimeList = populateCompanyOpeningDropdown(startTime, endTime, interval);
            //switch (CalenderInterval)
            //{
            //    case 1:
            //        interval = new TimeSpan(0, 15, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //    case 2:
            //        interval = new TimeSpan(0, 30, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //    case 3:
            //        interval = new TimeSpan(1, 15, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //}

            return TimeList;
        }


        private List<string> populateCompanyOpeningDropdown(DateTime startTime, DateTime endTime, TimeSpan interval)
        {
            List<string> dropdown = new List<string>();

            DateTime time = startTime;

            while (time <= endTime)
            {
                dropdown.Add(time.ToString("HH:mm tt"));
                time = time.Add(interval);
            }

            return dropdown;
        }



        public List<string> GetCompanyClosingTime()
        {
            //int CalenderInterval = 2;
            List<string> TimeList = new List<string>();

            //int.TryParse(tblappointmentsettings.FirstOrDefault().CalenderInterval.ToString(), out CalenderInterval);
            DateTime startTime = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime endTime = new DateTime(2000, 1, 2, 0, 0, 0);
            TimeSpan interval = new TimeSpan(1, 0, 0);
            TimeList = populateCompanyClosingDropdown(startTime, endTime, interval);
            //switch (CalenderInterval)
            //{
            //    case 1:
            //        interval = new TimeSpan(0, 15, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //    case 2:
            //        interval = new TimeSpan(0, 30, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //    case 3:
            //        interval = new TimeSpan(1, 15, 0);
            //        TimeList = populateDropdown(startTime, endTime, interval);
            //        break;
            //}

            return TimeList;
        }


        private List<string> populateCompanyClosingDropdown(DateTime startTime, DateTime endTime, TimeSpan interval)
        {
            List<string> dropdown = new List<string>();

            DateTime time = startTime;

            while (time <= endTime)
            {
                dropdown.Add(time.ToString("HH:mm tt"));
                time = time.Add(interval);
            }

            return dropdown;
        }

        public List<tbltherapist> GetTherepistDetail(int? branchID)
        {
            List<tbltherapist> objtbltherapist = (from cd in tbltherapists select cd).ToList().OrderBy(x => x.TherapistId).ToList();
            return objtbltherapist;
        }

        public List<string> GetAppointmenttimeByTherepistidAndAppointmentdate(int therepistid, DateTime dt, int? branchID)
        {
            List<string> appointmenttiming = new List<string>();
            appointmenttiming = (from app in tblappointments
                                 where app.FK_TherapistId == therepistid
                                     && EntityFunctions.TruncateTime(app.AppointmentDate) == EntityFunctions.TruncateTime(dt)
                                     && app.FK_BranchID == branchID
                                 select app.AppointmentTime).ToList();
            return appointmenttiming;
        }


        public List<tblappointment> GetAppointmentdetailByTherapistId(int therapistid, DateTime appdt, int? branchID)
        {
            List<tblappointment> objtblappointment = (from ap in tblappointments
                                                      where ap.FK_TherapistId == therapistid
                                                          && (EntityFunctions.TruncateTime(ap.AppointmentDate) == EntityFunctions.TruncateTime(appdt))
                                                          && ap.FK_BranchID == branchID
                                                      select ap).ToList();
            return objtblappointment;
        }


        public string GetTaxDtlByServiceID(int serviceid, int? branchID)
        {
            string taxdtl = (from ser in tblservices
                             where ser.ServiceId == serviceid && ser.FK_BranchID == branchID
                             select ser.TaxID).FirstOrDefault();

            return taxdtl;
        }

        public string GetTaxDtlByPackageID(int packageid, int? branchID)
        {
            string taxdtl = (from pkg in tblpackages
                             where pkg.Id == packageid && pkg.fk_BranchID == branchID
                             select pkg.TaxID).FirstOrDefault();

            return taxdtl;
        }


        public List<tblcoupanmaster> GetAllValidCouponDtl(int? branchid)
        {
            List<tblcoupanmaster> CouponList = new List<tblcoupanmaster>();

            var cpnmaster = (from cpn in tblcoupanmasters
                             where cpn.IsActive == true && cpn.FK_BranchID == branchid
                             select cpn).ToList();
            foreach (var item in cpnmaster)
            {
                if (item.Coupan_SDateVld.Value.AddDays(Convert.ToDouble(item.Coupan_Validity)) > DateTime.Now)
                {
                    CouponList.Add(item);
                }
            }

            //&& ((EntityFunctions.TruncateTime(cpn.Coupan_SDateVld).Value.AddDays(Convert.ToDouble(cpn.Coupan_Validity))) >= EntityFunctions.TruncateTime(DateTime.Now)
            //List<tblcoupanmaster> CouponList = tblcoupanmasters.Where(x => x.IsActive == true && x.Coupan_Name.Contains(taxname)).Select(x => new
            //{
            //    Coupon_Id = x.Coupon_Id,
            //    Coupan_Name = x.Coupan_Name
            //}).ToList().Select(t => new tblcoupanmaster()
            //{
            //    Coupon_Id = t.Coupon_Id,
            //    Coupan_Name = t.Coupan_Name
            //}).ToList();

            return CouponList;
        }

        public decimal? GetCoupanAmtByCoupanID(int coupanid, int? branchID)
        {

            decimal? coupanamt = (from cpn in tblcoupanmasters where cpn.Id == coupanid && cpn.FK_BranchID == branchID select cpn.Coupon_Amt).FirstOrDefault();
            return coupanamt;
        }


        public List<PaymentDtlEL> GetAppointmentPaymentDtl(int? branchid)
        {
            List<PaymentDtlEL> objPaymentDtlEL = new List<PaymentDtlEL>();
            List<tblpaymentdtl> PaymentDtl = tblpaymentdtls.Where(t => t.Fk_BranchId == branchid && EntityFunctions.TruncateTime(t.CreatedDate) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();

            foreach (var item in PaymentDtl)
            {
                PaymentDtlEL PaymentDtlEL = new PaymentDtlEL();
                PaymentDtlEL.PaymentID = item.PaymentID;
                PaymentDtlEL.ClientName = item.tblappointment.tblclient.ClientName;
                PaymentDtlEL.Payment_Type = item.Payment_Type;
                PaymentDtlEL.Payment_Mode = item.Payment_Mode;
                PaymentDtlEL.Total_Amt = item.Total_Amt;
                PaymentDtlEL.Service_Amt = item.Service_Amt;
                PaymentDtlEL.Tax_Amt = item.Tax_Amt;
                PaymentDtlEL.Discount_Amt = item.Discount_Amt;
                PaymentDtlEL.Net_Amt = item.Net_Amt;
                PaymentDtlEL.Advance_Amt = item.Advance_Amt;
                PaymentDtlEL.Due_Amt = item.Due_Amt;
                objPaymentDtlEL.Add(PaymentDtlEL);
            }
            return objPaymentDtlEL;
        }

        public List<PaymentDtlEL> GetaoopintmentPaymentDtlByClientID(int ClientId, int? branchID)
        {
            List<PaymentDtlEL> objpaymentdtllist = new List<PaymentDtlEL>();
            PaymentDtlEL objtblpaymentdtl = new PaymentDtlEL();
            var paymentdtl = (from pd in tblpaymentdtls
                              from app in tblappointments
                              where pd.Fk_AppointmentId == app.AppointmentId && app.FK_ClientId == ClientId
                              select new
                     {
                         PaymentID = pd.PaymentID,
                         Appointmentid = app.AppointmentId,
                         Appointmentdate = app.AppointmentDate,
                     }).ToList();

            foreach (var item in paymentdtl)
            {
                objtblpaymentdtl.PaymentID = item.PaymentID;
                objtblpaymentdtl.Fk_AppointmentId = item.Appointmentid;
                objtblpaymentdtl.appointmentdate = item.Appointmentdate;
                objpaymentdtllist.Add(objtblpaymentdtl);
            }
            return objpaymentdtllist;

        }

        public List<PaymentDtlEL> GetAppointmentPaymentAllDtls(int? branchID, int? ClientId, DateTime? dt, int? AppointmentId)
        {
            var query = tblpaymentdtls.Where(t => t.Fk_BranchId == branchID);

            //var query = (from a in tblappointments
            //             join pd in tblpaymentdtls on a.AppointmentId equals pd.Fk_AppointmentId into resultTbl
            //             where (a.AppointmentId == AppointmentId) && (a.FK_ClientId == ClientId) && (a.FK_BranchID == branchID)
            //             from res in resultTbl.DefaultIfEmpty()
            //             select res);

            if (ClientId.HasValue && ClientId.Value > 0)
            {
                query = query.Where(t => t.tblappointment.FK_ClientId == ClientId.Value);
            }

            if (dt.HasValue)
            {
                query = query.Where(t => EntityFunctions.TruncateTime(t.CreatedDate) == EntityFunctions.TruncateTime(dt));
            }

            if (AppointmentId.HasValue && AppointmentId.Value > 0)
            {
                query = query.Where(t => t.Fk_AppointmentId == AppointmentId.Value);
            }

            List<tblpaymentdtl> PaymentDtl = query.ToList();

            List<PaymentDtlEL> result = new List<PaymentDtlEL>();

            if (PaymentDtl != null && PaymentDtl.Count() > 0)
            {
                foreach (var item in PaymentDtl)
                {
                    PaymentDtlEL tempData = new PaymentDtlEL();

                    tempData.PaymentID = item.PaymentID;
                    tempData.ClientName = item.tblappointment.tblclient.ClientName;
                    tempData.Payment_Type = item.Payment_Type;
                    tempData.Payment_Mode = item.Payment_Mode;
                    tempData.Total_Amt = item.Total_Amt;
                    tempData.Service_Amt = item.Service_Amt;
                    tempData.Tax_Amt = item.Tax_Amt;
                    tempData.Discount_Amt = item.Discount_Amt;
                    tempData.Net_Amt = item.Net_Amt;
                    tempData.Advance_Amt = item.Advance_Amt;
                    tempData.Due_Amt = item.Due_Amt;
                    tempData.Fk_AppointmentId = item.Fk_AppointmentId;
                    result.Add(tempData);
                }
            }

            return result;
        }

        public List<PaymentDtlEL> GetAllUnpaidAppointments(int? BranchId, int? ClientId, int? AppointmentId)
        {
            List<PaymentDtlEL> result = new List<PaymentDtlEL>();

            var query = tblappointments.Where(t => t.FK_BranchID == BranchId && (!t.IsPaymentComplete.HasValue || (t.IsPaymentComplete.HasValue && t.IsPaymentComplete.Value == false)));

            if (ClientId.HasValue && ClientId.Value > 0)
            {
                query = query.Where(t => t.FK_ClientId == ClientId.Value);
            }

            if (AppointmentId.HasValue && AppointmentId.Value > 0)
            {
                query = query.Where(t => t.AppointmentId == AppointmentId.Value);
            }

            List<tblappointment> modellist = query.ToList();

            if (modellist != null && modellist.Count() > 0)
            {
                result = modellist.Select(t => new PaymentDtlEL()
                {
                    appointmentdate = t.AppointmentDate,
                    Fk_AppointmentId = t.AppointmentId
                }).ToList();
            }

            return result;
        }



        public tblpaymentdtl CheckPaymentDtl(int appointmentid, int? branchID)
        {
            tblpaymentdtl objtblpaymentdtl = new tblpaymentdtl();
            objtblpaymentdtl = (from pd in tblpaymentdtls where pd.Fk_AppointmentId == appointmentid && pd.Fk_BranchId == branchID && pd.Due_Amt != null select pd).FirstOrDefault();
            return objtblpaymentdtl;
        }

        public PaymentDtlEL GetAllPaymentDtlByID(int appointmentId, int? branchID)
        {
            List<PaymentDtlEL> objpaymentdtllist = new List<PaymentDtlEL>();
            PaymentDtlEL objtblpaymentdtl = new PaymentDtlEL();
            var paymentdtl = (from pd in tblpaymentdtls where pd.Fk_AppointmentId == appointmentId && pd.Fk_BranchId == branchID select pd).FirstOrDefault();
            if (paymentdtl != null)
            {


                objtblpaymentdtl.ClientName = paymentdtl.tblappointment.tblclient.ClientName;
                objtblpaymentdtl.appointmentdate = paymentdtl.tblappointment.AppointmentDate;
                objtblpaymentdtl.Fk_AppointmentId = paymentdtl.tblappointment.AppointmentId;
                objtblpaymentdtl.dateofbirth = paymentdtl.tblappointment.tblclient.DateOfBirth;
                objtblpaymentdtl.ReferralSource = paymentdtl.tblappointment.tblclient.ReferralSource;
                objtblpaymentdtl.Sex = paymentdtl.tblappointment.tblclient.Sex;
                objtblpaymentdtl.Mobile = paymentdtl.tblappointment.tblclient.Mobile;


                objtblpaymentdtl.Total_Amt = paymentdtl.Total_Amt;

                objtblpaymentdtl.Service_Amt = paymentdtl.Service_Amt;
                objtblpaymentdtl.Net_Amt = paymentdtl.Net_Amt;
                objtblpaymentdtl.Tax_Amt = paymentdtl.tblappointment.TotalTax;
                objtblpaymentdtl.Received_Amt = paymentdtl.Received_Amt;

                objtblpaymentdtl.Fk_AppointmentId = paymentdtl.tblappointment.AppointmentId;



                return objtblpaymentdtl;
            }
            else
            {
                return null;
            }



        }







        //............... Code Above updated by sam on 07092016....................................  
    }
}
