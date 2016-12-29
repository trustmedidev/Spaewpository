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

    public class ReportDAL : SpaPracticeEntities
    {

        #region For Collection Report start
        public List<ReportEL> GetClientListBySearchCriteria(int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {
            List<ReportEL> clientListbypackage = new List<ReportEL>();
            List<ReportEL> clientListbyservice = new List<ReportEL>();
            List<ReportEL> clientListbyservicebypackage = new List<ReportEL>();
            int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            int apsercnt;

            if (byselection == 0)
            {
                #region
                //........................bypackage........................
                clientListbypackage = (from app in tblappointments
                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                       join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                       join
                                           pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                       where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                           && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                           && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                       select new ReportEL()
                                       {
                                           AppointmentDate = app.AppointmentDate,
                                           ClientName = c.ClientName,
                                           ServiceName = pkg.Package_Name,
                                           TotalAmount = app.GrossAmount,
                                           Discount = app.Discount
                                       }).ToList();

                //........................byservice........................
                servicecount = (from app in tblappointments
                                join c in tblclients on app.FK_ClientId equals c.ClientId
                                where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                    && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                    && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                select new AppointmentEL()

                                                   {
                                                       AppointmentId = app.AppointmentId,
                                                       Discount = app.Discount,
                                                       TotalAmount=app.GrossAmount
                                                   }).ToList();
                if (servicecount != null)
                {
                    foreach (AppointmentEL ap in servicecount)
                    {
                        cnt = (from app in tblappointments
                               join c in tblclients on app.FK_ClientId equals c.ClientId
                               join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                               where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                               select new ReportEL()).Count();
                        if (cnt > 0)
                        {
                            clientListbyservice = (from app in tblappointments
                                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                   where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                       && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                                                   select new ReportEL()
                                                   {
                                                       AppointmentDate = app.AppointmentDate,
                                                       ClientName = c.ClientName,
                                                       ServiceName = ser.ServiceName,
                                                       TotalAmount = app.GrossAmount,
                                                       //TotalAmount = app.GrossAmount,
                                                       Discount = (ap.Discount / cnt)
                                                   }).ToList();
                        }
                        else
                        {
                            clientListbyservice = (from app in tblappointments
                                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                   where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                       && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                   select new ReportEL()
                                                   {
                                                       AppointmentDate = app.AppointmentDate,
                                                       ClientName = c.ClientName,
                                                       ServiceName = ser.ServiceName,
                                                       TotalAmount = app.GrossAmount,
                                                       //TotalAmount = app.GrossAmount,
                                                       Discount = app.Discount
                                                   }).ToList();
                        }

                        foreach (var item in clientListbyservice)
                        {
                            clientListbypackage.Add(item);
                        }
                    }

                }
                else
                {
                    return clientListbypackage;
                }

                return clientListbypackage;

                #endregion

            }
            else if (byselection == 1)
            {
                #region Byservice Section
                #region Service Count
                servicecount = (from app in tblappointments
                                join c in tblclients on app.FK_ClientId equals c.ClientId
                                where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                select new AppointmentEL() { AppointmentId = app.AppointmentId, Discount = app.Discount }).ToList();
                #endregion Service Count

                if (ServiceType > 0)
                {
                    if (servicecount != null)
                    {
                        foreach (AppointmentEL ap in servicecount)
                        {
                            #region counting section for service
                            cnt = (from app in tblappointments join c in tblclients on app.FK_ClientId equals c.ClientId 
                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId 
                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId 
                                   where  (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) 
                                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) 
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 
                                   && app.AppointmentId == ap.AppointmentId select new ReportEL()).Count();

                            #endregion counting section for service

                            #region If Service Counting number is more than 1
                            if (cnt > 1)
                            {
                                clientListbyservice = (from app in tblappointments join c in tblclients on app.FK_ClientId equals c.ClientId 
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId 
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where ser.ServiceId == ServiceType && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) 
                                                       && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false 
                                                       && app.GrossAmount > 0 
                                                       && app.AppointmentId == ap.AppointmentId 
                                                       select new ReportEL() { AppointmentDate = app.AppointmentDate, ClientName = c.ClientName, ServiceName = ser.ServiceName, TotalAmount = app.GrossAmount, Discount = (ap.Discount / cnt) }).ToList();
                            }
                            #endregion If Service Counting number is more than 1

                            #region If Service Counting number is 1
                            else if (cnt == 1)
                            {
                                clientListbyservice = (from app in tblappointments join c in tblclients on app.FK_ClientId equals c.ClientId 
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId 
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where ser.ServiceId == ServiceType && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                       select new ReportEL() { AppointmentDate = app.AppointmentDate, ClientName = c.ClientName, ServiceName = ser.ServiceName, TotalAmount = app.GrossAmount, Discount = app.Discount }).ToList();
                            }
                            #endregion If Service Counting number is 1

                            if (clientListbyservice.Count > 0)
                            {
                                foreach (var item in clientListbyservice)
                                {
                                    clientListbypackage.Add(item);
                                }
                            }
                        }
                        return clientListbypackage;
                    }
                    else
                    {
                        return clientListbyservice;
                    }
                }
                else
                {
                    #region if Service type is 0
                    if (servicecount != null)
                    {
                        foreach (AppointmentEL ap in servicecount)
                        {
                            cnt = (from app in tblappointments
                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                   where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new ReportEL()).Count();
                            if (cnt > 0)
                            {
                                clientListbyservice = (from app in tblappointments join c in tblclients on app.FK_ClientId equals c.ClientId join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId select new ReportEL() { AppointmentDate = app.AppointmentDate, ClientName = c.ClientName, ServiceName = ser.ServiceName, TotalAmount = app.GrossAmount, Discount = (ap.Discount / cnt) }).ToList();
                            }
                            else
                            {
                                clientListbyservice = (from app in tblappointments join c in tblclients on app.FK_ClientId equals c.ClientId join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 select new ReportEL() { AppointmentDate = app.AppointmentDate, ClientName = c.ClientName, ServiceName = ser.ServiceName, TotalAmount = app.GrossAmount, Discount = app.Discount }).ToList();
                            }

                            foreach (var item in clientListbyservice)
                            {
                                clientListbypackage.Add(item);
                            }
                        }
                        return clientListbypackage;
                    }
                    #endregion if Service type is 0
                }
                #endregion Byservice Section 
            }
            else if (byselection == 2)
            {

                #region BYPackage
                if (ServiceType > 0)
                {
                    //........................bypackage........................
                    clientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                               && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                               && pkg.Id == ServiceType
                                           select new ReportEL()
                                           {
                                               AppointmentDate = app.AppointmentDate,
                                               ClientName = c.ClientName,
                                               ServiceName = pkg.Package_Name,
                                               TotalAmount = app.GrossAmount,
                                               Discount = app.Discount
                                           }).ToList();
                }
                else
                {
                    clientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                               && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0

                                           select new ReportEL()
                                           {
                                               AppointmentDate = app.AppointmentDate,
                                               ClientName = c.ClientName,
                                               ServiceName = pkg.Package_Name,
                                               TotalAmount = app.GrossAmount,
                                               Discount = app.Discount
                                           }).ToList();
                }
                return clientListbypackage;
                #endregion BYPackage

            }


            return null;

        }

        public List<ReportEL> GetReportListBySearchCriteria(int? ServiceType, int? PackageType, DateTime? FromDate, DateTime? Todate, int? branchID)
        {
            List<ReportEL> result = new List<ReportEL>();

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

            List<tblappointment> modelist = query.ToList();

            if (modelist != null && modelist.Count() > 0)
            {
                foreach (tblappointment item in modelist)
                {
                    ReportEL tempData = new ReportEL();

                    tempData.ClientId = item.FK_ClientId;
                    tempData.AppointmentDate = item.AppointmentDate;
                    tempData.ClientName = item.tblclient.ClientName;
                    tempData.TotalAmount = (item.Total) + (item.TaxAmount.HasValue ? item.TaxAmount.Value : 0);
                    tempData.Discount = item.Discount.HasValue ? item.Discount.Value : 0;

                    bool IsPackage = false;

                    if (item.ByPackage.HasValue)
                    {
                        if (item.ByPackage.Value == true)
                        {
                            IsPackage = true;
                        }
                    }
                    else if (PackageType.HasValue && PackageType.Value > 0)
                    {
                        IsPackage = true;
                    }

                    if (IsPackage)
                    {
                        List<tblpackage> mapp = (from appmap in tblappointmentpackageppings
                                                 join pckg in tblpackages on appmap.FK_PackageId equals pckg.Id
                                                 where appmap.FK_AppointmentId == item.AppointmentId
                                                 select pckg).ToList();

                        if (mapp != null && mapp.Count() > 0)
                        {
                            foreach (var val in mapp)
                            {
                                if (string.IsNullOrWhiteSpace(tempData.ServiceName))
                                {
                                    tempData.ServiceName = val.Package_Name;
                                }
                                else
                                {
                                    tempData.ServiceName = ", " + val.Package_Name;
                                }
                            }
                        }
                        else
                        {
                            tempData.ServiceName = "";
                        }
                    }
                    else
                    {
                        try
                        {
                            tempData.ServiceName = item.tblservice.ServiceName;
                        }
                        catch
                        {
                            tempData.ServiceName = "";
                        }
                    }

                    result.Add(tempData);
                }
            }

            return result;
        } 

        #endregion For Collection Report End 

        #region For Appointment Report start

        public List<ReportEL> GetAppointmentReportBySearchCriteria(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {
            List<ReportEL> appointmentReportlistbypackage = new List<ReportEL>();
            List<ReportEL> appointmentReportlistbyservice = new List<ReportEL>();
            List<ReportEL> appointmentReportlistbyservicebypackage = new List<ReportEL>();
            int cnt;
            int apsercnt;

            if (byselection == 0)
            {
                #region
                //........................bypackage........................
                appointmentReportlistbypackage = (from app in tblappointments
                                                  join c in tblclients on app.FK_ClientId equals c.ClientId
                                                  join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                                  join
                                                      pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                                  where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                      && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                      && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                                  select new ReportEL()
                                                  {
                                                      AppointmentDate = app.AppointmentDate,
                                                      ClientName = c.ClientName,
                                                      ServiceName = pkg.Package_Name,
                                                      TotalAmount = app.GrossAmount,
                                                      Discount = app.Discount
                                                  }).ToList();

                //........................byservice........................
                apsercnt = (from app in tblappointments
                            join c in tblclients on app.FK_ClientId equals c.ClientId
                            where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                            select new ReportEL()).Count();
                if (apsercnt > 1)
                {

                }
                else
                {
                    cnt = (from app in tblappointments
                           join c in tblclients on app.FK_ClientId equals c.ClientId
                           join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                           join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                           select new ReportEL()).Count();
                    if (cnt > 0)
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              TotalAmount = ser.Amount,
                                                              //TotalAmount = app.GrossAmount,
                                                              Discount = (app.Discount / cnt)
                                                          }).ToList();
                    }
                    else
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              TotalAmount = ser.Amount,
                                                              //TotalAmount = app.GrossAmount,
                                                              Discount = app.Discount
                                                          }).ToList();
                    }
                }







                foreach (var item in appointmentReportlistbyservice)
                {
                    appointmentReportlistbypackage.Add(item);
                }

                return appointmentReportlistbypackage;

                #endregion

            }
            else if (byselection == 1)
            {


                if (ServiceType > 0)
                {

                    cnt = (from app in tblappointments
                           join c in tblclients on app.FK_ClientId equals c.ClientId
                           join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                           join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                           select new ReportEL()).Count();
                    if (cnt > 0)
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                              && ser.ServiceId == ServiceType
                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              //TotalAmount = app.GrossAmount,
                                                              TotalAmount = ser.Amount,
                                                              Discount = (app.Discount / cnt)
                                                          }).ToList();
                    }
                    else
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                              && ser.ServiceId == ServiceType
                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              //TotalAmount = app.GrossAmount,
                                                              TotalAmount = ser.Amount,
                                                              Discount = app.Discount
                                                          }).ToList();
                    }
                }
                else
                {
                    cnt = (from app in tblappointments
                           join c in tblclients on app.FK_ClientId equals c.ClientId
                           join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                           join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                               && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                           select new ReportEL()).Count();
                    if (cnt > 0)
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0

                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              //TotalAmount = app.GrossAmount,
                                                              TotalAmount = ser.Amount,
                                                              Discount = (app.Discount / cnt)
                                                              //Discount = app.Discount
                                                          }).ToList();
                    }
                    else
                    {
                        appointmentReportlistbyservice = (from app in tblappointments
                                                          join c in tblclients on app.FK_ClientId equals c.ClientId
                                                          join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                                                          where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                              && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0

                                                          select new ReportEL()
                                                          {
                                                              AppointmentDate = app.AppointmentDate,
                                                              ClientName = c.ClientName,
                                                              ServiceName = ser.ServiceName,
                                                              //TotalAmount = app.GrossAmount,
                                                              TotalAmount = ser.Amount,
                                                              Discount = ser.Amount
                                                              //Discount = app.Discount
                                                          }).ToList();
                    }

                }
                //else
                //{
                //    clientListbyservice = (from app in tblappointments
                //                           join c in tblclients on app.FK_ClientId equals c.ClientId
                //                           join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                           join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                           where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                               && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                               && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                           select new ReportEL()
                //                        {
                //                            AppointmentDate = app.AppointmentDate,
                //                            ClientName = c.ClientName,
                //                            ServiceName = ser.ServiceName,
                //                            TotalAmount = app.GrossAmount,
                //                            Discount = app.Discount
                //                        }).ToList();
                //}
                //}

                return appointmentReportlistbyservice;
            }
            else if (byselection == 2)
            {
                if (ServiceType > 0)
                {
                    //........................bypackage........................
                    appointmentReportlistbypackage = (from app in tblappointments
                                                      join c in tblclients on app.FK_ClientId equals c.ClientId
                                                      join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                                      join
                                                          pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                                      where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                          && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                                          && pkg.Id == ServiceType
                                                      select new ReportEL()
                                                      {
                                                          AppointmentDate = app.AppointmentDate,
                                                          ClientName = c.ClientName,
                                                          ServiceName = pkg.Package_Name,
                                                          TotalAmount = app.GrossAmount,
                                                          Discount = app.Discount
                                                      }).ToList();
                }
                else
                {
                    appointmentReportlistbypackage = (from app in tblappointments
                                                      join c in tblclients on app.FK_ClientId equals c.ClientId
                                                      join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                                      join
                                                          pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                                      where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                          && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0

                                                      select new ReportEL()
                                                      {
                                                          AppointmentDate = app.AppointmentDate,
                                                          ClientName = c.ClientName,
                                                          ServiceName = pkg.Package_Name,
                                                          TotalAmount = app.GrossAmount,
                                                          Discount = app.Discount
                                                      }).ToList();
                }
                return appointmentReportlistbypackage;
            }
            else
            {
                return null;
            }


            //if (ServiceType > 0)
            //{


            //clientList = (from c in tblclients
            //              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
            //              where ((EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                    && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                    && ((ap.FK_ServiceId == (ServiceType > 0 ? ServiceType : ap.FK_ServiceId)))
            //                    && ap.FK_BranchID == branchID)
            //              select new ReportEL()
            //              {
            //                  AppointmentDate = ap.AppointmentDate,
            //                  ClientName = c.ClientName,
            //                  ServiceName = ap.tblservice.ServiceName,
            //                  TotalAmount = ap.GrossAmount,
            //                  Discount = ap.Discount
            //              }).ToList();
            //}
            //else if (DoctorId > 0)
            //{
            //    clientList = (from c in tblclients
            //                  join ap in tblappointments on c.ClientId equals ap.FK_ClientId
            //                  where ((EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                        && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                        && ((ap.FK_UserId == (DoctorId > 0 ? DoctorId : ap.FK_UserId)))
            //                        && ap.FK_BranchID == branchID)
            //                  select new ReportEL()
            //                  {
            //                      AppointmentDate = ap.AppointmentDate,
            //                      ClientName = c.ClientName,
            //                      ServiceName = ap.tblservice.ServiceName,
            //                      TotalAmount = ap.GrossAmount,
            //                      Discount = ap.Discount
            //                  }).ToList();
            //}
            //else
            //{
            //    clientList = (from c in tblclients
            //                  join ap in tblappointments on c.ClientId equals ap.FK_ClientId
            //                  where ((EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                        && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
            //                        && ap.FK_BranchID == branchID)
            //                  select new ReportEL()
            //                  {
            //                      AppointmentDate = ap.AppointmentDate,
            //                      ClientName = c.ClientName,
            //                      ServiceName = ap.tblservice.ServiceName,
            //                      TotalAmount = ap.GrossAmount,
            //                      Discount = ap.Discount
            //                  }).ToList();
            //}

            //return clientList;
        }

        #endregion For Appointment Report End

        #region ClientReport Upload Start

        #region Crud Function Start
        public int InsertUpdateClientReportUpload(tblreport objtblreport)
        {
            try
            {
                if (objtblreport.ReportId == 0)
                {

                    tblreports.Add(objtblreport);

                    SaveChanges();
                }
                else
                {
                    tblreport otblreport = new tblreport();
                    otblreport = tblreports.Where(x => x.ReportId == objtblreport.ReportId).FirstOrDefault();
                    otblreport.ReportName = objtblreport.ReportName;
                    otblreport.ReportDescription = objtblreport.ReportDescription;
                    otblreport.ReportPath = objtblreport.ReportPath;
                    Entry(otblreport).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objtblreport.ReportId;
        } 
       
        public bool DeleteClientUploadReportById(int id, int? branchID)
        {
            try
            {
                tblreport itemToRemove = tblreports.SingleOrDefault(x =>x.ReportId == id && x.Fk_BranchID==branchID );
                itemToRemove.IsActive = false;
                Entry(itemToRemove).State = EntityState.Modified;
                SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Crud Function End
        #region Get Function Start
        public List<tblreport> GetClientUploadReportByBranchId(int? branchid)
        {
            List<tblreport> objtblreport = tblreports.Where(x => x.IsActive == true && x.Fk_BranchID==branchid).ToList();
            return objtblreport;
        } 

       public tblreport GetReportDataByReportId(int reportid,int? branchid)
       {
           try
           {
               tblreport objtblreport = tblreports.Where(x => x.IsActive == true && x.Fk_BranchID == branchid && x.ReportId == reportid).FirstOrDefault();
               return objtblreport;
           }
           catch (Exception ex)
           {
               throw;
           }

        }

        public ClientEL GetClientIdByClientnameByMobileNumber(string clientname,string mobile,int? branchid)
        {
            ClientEL ObjclientEL = new ClientEL();
            ObjclientEL = (from c in tblclients
                           where c.ClientName == clientname && c.Mobile == mobile && c.FK_BranchID == branchid && c.IsActive == true
                           select new ClientEL()
                        {
                            ClientId = c.ClientId
                        }).FirstOrDefault();
            return ObjclientEL;

        }

        #endregion Get Function End

        #endregion ClientReport Upload End

        #region TherapistReport Start

        public List<TherapistEL> GetTherapistList(int? branchID)
        {
            List<TherapistEL> query = new List<TherapistEL>();
            

            query = (from app in tblappointments
                        join thp in tbltherapists
                        on app.FK_TherapistId equals thp.TherapistId
                        where (thp.TherapistId == app.FK_TherapistId && thp.FK_BranchId == branchID)
                        select new TherapistEL()
                        {
                            ApptId=app.AppointmentId,
                            Name=thp.Name,
                            AppointmentDate=app.AppointmentDate,
                            //ServiceName=app.tblappointmentservicemappings.FirstOrDefault().tblservice.ServiceName,
                            TotalAmount=app.GrossAmount,
                            Commission=thp.Commission,
                            TherapistAmount = (app.GrossAmount * thp.Commission)/100,
                        }).ToList();
            foreach (var item in query)
            {
                string s = "";
                var val = (from appt in tblappointments
                          join appser in tblappointmentservicemappings on appt.AppointmentId equals appser.FK_AppointmentId
                          join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                          where(appt.AppointmentId == item.ApptId)
                          select appser.tblservice.ServiceName).ToList();
                foreach (var n in val)
                {                    
                    s += n + ",";
                }
                if (val != null)
                {
                    item.ServiceName = s;
                }
                else
                {
                    //item.ServiceName= tblappointmentpackageppings.FirstOrDefault().
                }
            }
            return query;
        }
        public List<TherapistEL> SearchTherapist(string ThpName, DateTime? sdate, DateTime? edate, int? branchID)
        {
            List<TherapistEL> query = new List<TherapistEL>();

            if (ThpName != "" && sdate != null && edate != null)
            {
                query = (from app in tblappointments
                         join thp in tbltherapists
                         on app.FK_TherapistId equals thp.TherapistId
                         where (thp.Name == ThpName && EntityFunctions.TruncateTime(app.AppointmentDate) >= (sdate != null ? EntityFunctions.TruncateTime(sdate) : EntityFunctions.TruncateTime(app.AppointmentDate))
                         && EntityFunctions.TruncateTime(app.AppointmentDate) <= (sdate != null ? EntityFunctions.TruncateTime(sdate) : EntityFunctions.TruncateTime(app.AppointmentDate))
                         && thp.FK_BranchId == branchID)
                         select new TherapistEL()
                         {
                             ApptId = app.AppointmentId,
                             Name = thp.Name,
                             AppointmentDate = app.AppointmentDate,
                             //ServiceName = app.tblappointmentservicemappings.FirstOrDefault().tblservice.ServiceName,
                             TotalAmount = app.GrossAmount,
                             Commission = thp.Commission,
                             TherapistAmount = (app.GrossAmount * thp.Commission) / 100,
                         }).ToList();
                foreach (var item in query)
                {
                    string s = "";
                    var val = (from appt in tblappointments
                               join appser in tblappointmentservicemappings on appt.AppointmentId equals appser.FK_AppointmentId
                               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                               where (appt.AppointmentId == item.ApptId)
                               select appser.tblservice.ServiceName).ToList();
                    foreach (var n in val)
                    {
                        s += n + ",";
                    }
                    if (val != null)
                    {
                        item.ServiceName = s;
                    }
                    else
                    {
                        //item.ServiceName= tblappointmentpackageppings.FirstOrDefault().
                    }
                }
            }
            else if (ThpName != "" && sdate == null && edate == null)
            {
                query = (from app in tblappointments
                         join thp in tbltherapists
                         on app.FK_TherapistId equals thp.TherapistId
                         where (thp.Name == ThpName && thp.FK_BranchId == branchID)
                         select new TherapistEL()
                         {
                             ApptId = app.AppointmentId,
                             Name = thp.Name,
                             AppointmentDate = app.AppointmentDate,
                            // ServiceName = app.tblappointmentservicemappings.FirstOrDefault().tblservice.ServiceName,
                             TotalAmount = app.GrossAmount,
                             Commission = thp.Commission,
                             TherapistAmount = (app.GrossAmount * thp.Commission) / 100,
                         }).ToList();
                foreach (var item in query)
                {
                    string s = "";
                    var val = (from appt in tblappointments
                               join appser in tblappointmentservicemappings on appt.AppointmentId equals appser.FK_AppointmentId
                               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                               where (appt.AppointmentId == item.ApptId)
                               select appser.tblservice.ServiceName).ToList();
                    foreach (var n in val)
                    {
                        s += n + ",";
                    }
                    if (val != null)
                    {
                        item.ServiceName = s;
                    }
                    else
                    {
                        //item.ServiceName= tblappointmentpackageppings.FirstOrDefault().
                    }
                }
            }
            else if (ThpName == "" && sdate != null && edate != null)
            {
                query = (from app in tblappointments
                         join thp in tbltherapists
                         on app.FK_TherapistId equals thp.TherapistId
                         where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (sdate != null ? EntityFunctions.TruncateTime(sdate) : EntityFunctions.TruncateTime(app.AppointmentDate))
                         && EntityFunctions.TruncateTime(app.AppointmentDate) <= (edate != null ? EntityFunctions.TruncateTime(edate) : EntityFunctions.TruncateTime(app.AppointmentDate))
                         && thp.FK_BranchId == branchID)
                         select new TherapistEL()
                         {
                             ApptId = app.AppointmentId,
                             Name = thp.Name,
                             AppointmentDate = app.AppointmentDate,
                             //ServiceName = app.tblappointmentservicemappings.FirstOrDefault().tblservice.ServiceName,
                             TotalAmount = app.GrossAmount,
                             Commission = thp.Commission,
                             TherapistAmount = (app.GrossAmount * thp.Commission) / 100,
                         }).ToList();
                foreach (var item in query)
                {
                    string s = "";
                    var val = (from appt in tblappointments
                               join appser in tblappointmentservicemappings on appt.AppointmentId equals appser.FK_AppointmentId
                               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                               where (appt.AppointmentId == item.ApptId)
                               select appser.tblservice.ServiceName).ToList();
                    foreach (var n in val)
                    {
                        s += n + ",";
                    }
                    if (val != null)
                    {
                        item.ServiceName = s;
                    }
                    else
                    {
                        //item.ServiceName= tblappointmentpackageppings.FirstOrDefault().
                    }
                }
            }
            else if (ThpName == "" && sdate == null && edate == null)
            {
                query = GetTherapistList(branchID);
            }
            return query;
        }
        public List<TherapistEL> GetThpNameList(string ThpName, int? branchID)
        {
            List<TherapistEL> query = new List<TherapistEL>();
            query = tbltherapists.Where(x => x.Name.Contains(ThpName)).Select(x => new TherapistEL { Name = x.Name }).ToList();
            return query;
        }

        public List<TherapistEL> GetAllTherapistNameID(int? branchID)
        {
            List<TherapistEL> query = new List<TherapistEL>();
            query = tbltherapists.Where(x => x.FK_BranchId==branchID).Select(x => new TherapistEL { Name = x.Name,TherapistId=x.TherapistId }).ToList();
            return query;
        }

        #endregion


    }

}
