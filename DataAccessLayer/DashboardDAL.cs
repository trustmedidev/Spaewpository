using DataAccessLayer.Repository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DashboardDAL : SpaPracticeEntities
    {
        public DashboardEL GetApppointmentCountBydate(int? branchID)
        {
            DateTime todayDate = DateTime.Today;
            DashboardEL objDashboard = new DashboardEL();

            objDashboard.TotalAppointment = tblappointments.Where(x => x.AppointmentDate == todayDate && x.FK_BranchID == branchID).Count();
            if (objDashboard.TotalAppointment>0)
            {
                objDashboard.TotalCollection = tblappointments.Where(x => x.AppointmentDate == todayDate && x.FK_BranchID == branchID).Sum(x => x.GrossAmount);
            }
            return objDashboard;
        }

        //public DashboardEL GetMonthPatientChartByService()
        //{
        //    DateTime monthRenge = DateTime.Today.AddMonths(-2);
        //    DashboardEL objDashboard = new DashboardEL();



        //    var patientList = (from s in tblServices
        //                       join apps in tblAppointmentServiceMappings on s.ServiceId equals apps.FK_ServiceId
        //                       join ap in tblAppointments on apps.FK_AppointmentId equals ap.AppointmentId
        //                       join p in tblPatients on ap.FK_PatientId equals p.PatientId
        //                       where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= monthRenge && EntityFunctions.TruncateTime(ap.AppointmentDate) <= DateTime.Today)
        //                       group s by new { s.ServiceName, ap.AppointmentDate.Value.Month } into g
        //                       select new { ServiceName = g.Key.ServiceName, AppointmentDate = g.Key.Month, Count = g.Count() }).ToList();

        //    return objDashboard;
        //}

        public List<MonthPatientChartByService> GetMonthlyClientChartByService(int? branchID)
        {
            DateTime monthRenge = DateTime.Today.AddMonths(-2);
            List<MonthPatientChartByService> objDashboard = new List<MonthPatientChartByService>();

            try
            {

                var clientList = (from s in tblservices                                  
                                   //join ap in tblappointments on s.ServiceId equals ap.FK_ServiceId
                                   join mser in tblappointmentservicemappings on s.ServiceId equals mser.FK_ServiceId
                                   join ap in tblappointments on mser.FK_AppointmentId equals ap.AppointmentId
                                   join c in tblclients on ap.FK_ClientId equals c.ClientId
                                   where (EntityFunctions.TruncateTime(ap.AppointmentDate.Value) >= monthRenge && EntityFunctions.TruncateTime(ap.AppointmentDate.Value) <= DateTime.Today && ap.FK_BranchID == branchID)
                                   group s by new { ServiceName = s.ServiceName, Month = ap.AppointmentDate.Value.Month } into g
                                   let count = g.Count(f => f.ServiceId > 0)
                                   select new { ServiceName = g.Key.ServiceName, AppointmentDate = g.Key.Month, Count = count }).OrderBy(x => x.ServiceName).ToList();

                //foreach (var item in patientList)
                //{

                var grps = from d in clientList
                           group d by d.ServiceName
                               into grp
                               select new
                               {
                                   Foo = grp.Key,
                                   Bars = grp.Select(d2 => d2.Count).ToArray(),
                                   Mon = grp.Select(d3 => d3.AppointmentDate).ToArray()
                               };

                foreach (var item in grps)
                {
                    MonthPatientChartByService m = new MonthPatientChartByService();
                    m.ServiceName = item.Foo;
                    if (item.Bars.Count() == 1)
                    {
                        m.Month1 = item.Bars[0];
                        m.Month2 = 0;
                        m.Month3 = 0;
                    }
                    else if (item.Bars.Count() == 2)
                    {
                        m.Month1 = item.Bars[0];
                        m.Month2 = item.Bars[1];
                        m.Month3 = 0;
                    }
                    if (item.Bars.Count() == 3)
                    {
                        m.Month1 = item.Bars[0];
                        m.Month2 = item.Bars[1];
                        m.Month3 = item.Bars[2];
                    }
                    //m.MonthName = item.Mon[0] + "," + item.Mon[1] + "," + item.Mon[2];
                    objDashboard.Add(m);

                }
            }
            catch (Exception)
            {
            }
            return objDashboard;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public List<MonthPatientChartByCollection> GetMonthlyClientChartByCollection(int? branchID)
        {

            DateTime monthRenge = DateTime.Today.AddMonths(-2);
            List<MonthPatientChartByCollection> objDashboard = new List<MonthPatientChartByCollection>();
            try
            {
                var objList = (from s in tblservices                             
                               //join ap in tblappointments on s.ServiceId equals ap.FK_ServiceId
                               join mser in tblappointmentservicemappings on s.ServiceId equals mser.FK_ServiceId
                               join ap in tblappointments on mser.FK_AppointmentId equals ap.AppointmentId
                               join c in tblclients on ap.FK_ClientId equals c.ClientId
                               where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= monthRenge && EntityFunctions.TruncateTime(ap.AppointmentDate) <= DateTime.Today && ap.FK_BranchID == branchID)                               
                               select new { ServiceName = s.ServiceName, AppointmentDate = ap.AppointmentDate.Value.Month, Total = ap.Total }).OrderBy(x => x.ServiceName).ToList();

                //foreach (var item in patientList)
                //{ orderby g.Sum(x => (x.TotalAmount.HasValue ? x.TotalAmount.Value : 0)) descending

                var clientList = (from c in objList
                                  group c by new { c.ServiceName, c.AppointmentDate }
                                      into grouped
                                      select new
                                      {
                                          ServiceName = grouped.Key.ServiceName,
                                          AppointmentDate = grouped.Key.AppointmentDate,
                                          Total = grouped.Sum(x => x.Total)
                                      }).OrderBy(x => x.ServiceName).ToList();

                var grps = from d in clientList
                           group d by d.ServiceName
                               into grp
                               select new
                               {
                                   ServiceName = grp.Key,
                                   Total = grp.Select(d2 => d2.Total).ToArray(),
                                   Mon = grp.Select(d3 => d3.AppointmentDate).ToArray()
                               };

                foreach (var item in grps)
                {
                    MonthPatientChartByCollection m = new MonthPatientChartByCollection();
                    m.ServiceName = item.ServiceName;
                    if (item.Total.Count() == 1)
                    {
                        m.Month1 = item.Total[0];
                        m.Month2 = 0;
                        m.Month3 = 0;
                    }
                    else if (item.Total.Count() == 2)
                    {
                        m.Month1 = item.Total[0];
                        m.Month2 = item.Total[1];
                        m.Month3 = 0;
                    }
                    if (item.Total.Count() == 3)
                    {
                        m.Month1 = item.Total[0];
                        m.Month2 = item.Total[1];
                        m.Month3 = item.Total[2];
                    }
                    //m.MonthName = item.Mon[0] + "," + item.Mon[1] + "," + item.Mon[2];
                    objDashboard.Add(m);

                }
            }
            catch (Exception)
            {
            }
            return objDashboard;
        }


        AppointmentListDAL appointmentListDAL = new AppointmentListDAL();
        public List<AppointmentEL> GetAppointByDay(int? branchID ,int bypackage)    // ap.AppointmentDate.Value.Month == todayDate.Month
        {
            DateTime todayDate = DateTime.Today;
            List<AppointmentEL> AppointmentsList = new List<AppointmentEL>();
            
            if (bypackage == 1)
            {

                
                var aplist = (from ap in tblappointments
                              join c in tblclients on ap.FK_ClientId equals c.ClientId
                              join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
                              join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                              //join pkgdtl in tblpackagedtls on pkg.Id equals pkgdtl.Package_Id
                              //join ser in tblservices on pkgdtl.ServiceId equals ser.ServiceId
                              where ap.FK_BranchID == branchID && ap.ByPackage == true && ap.AppointmentDate == todayDate && ap.GrossAmount > 0
                              select (new AppointmentEL()
                              {
                                  ClientName = c.ClientName,
                                  AppointmentTime = ap.AppointmentTime,
                                  Service = pkg.Package_Name
                                  //Service = ser.ServiceName
                              })).ToList();
                foreach (var item in aplist)
                {
                    AppointmentsList.Add(item);
                }
            }
            else
            {
                var aplist = (from ap in tblappointments
                              join c in tblclients on ap.FK_ClientId equals c.ClientId
                              join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
                              join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                              where ap.FK_BranchID == branchID && ap.ByPackage == false && ap.AppointmentDate == todayDate
                              select (new AppointmentEL()
                              {
                                  ClientName = c.ClientName,
                                  AppointmentTime = ap.AppointmentTime,
                                  //Service = ser.ServiceName
                                  AppointmentId=ap.AppointmentId
                              })).GroupBy(grp=>grp.ClientName).Select(s=>s.FirstOrDefault()).ToList();
                foreach (var item in aplist)
                {
                    item.Service = appointmentListDAL.FetchServiceById(item.AppointmentId, branchID);
                    AppointmentsList.Add(item);
                }
            }
           
            
             
            return AppointmentsList;
        }
        //public List<AppointmentEL> GetAppointByDay(int? branchID)
        //{
        //    DateTime todayDate = DateTime.Today;
        //    //  return tblAppointments.Where(x => x.AppointmentDate == todayDate).ToList();

        //    List<AppointmentEL> AppointmentsList = tblappointments.Where(x => x.AppointmentDate == todayDate && x.TotalAmount != null && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
        //   {
        //       PatientName = x.tblpatient.PatientName,
        //       AppointmentTime = x.AppointmentTime,
        //       DoctorName=x.tbluser.Name,
        //       Service=x.tblservice.ServiceName
        //   }).ToList();
        //    return AppointmentsList;
        //}

        //public List<AppointmentEL> SearchAppointmentByDate(DateTime date, int? branchID)
        //{
        //    // DateTime todayDate = DateTime.Today;
        //    //  return tblAppointments.Where(x => x.AppointmentDate == todayDate).ToList();

        //    List<AppointmentEL> AppointmentsList = tblappointments.Where(x => x.AppointmentDate == date.Date && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
        //    {
        //        clientName = x.tblpatient.PatientName,
        //        AppointmentTime = x.AppointmentTime
        //    }).ToList();
        //    return AppointmentsList;
        //}

        public List<AppointmentEL> SearchAppointmentByDateAndService(DateTime date, int service, int? branchID)
        {

            List<AppointmentEL> AppointmentsList = tblappointmentservicemappings.Where(x => x.FK_ServiceId == service && x.FK_BranchID == branchID).Where(m => m.FK_AppointmentId == m.tblappointment.AppointmentId && m.tblappointment.AppointmentDate == date).Select(s => new AppointmentEL()
          {
              AppointmentTime = s.tblappointment.AppointmentTime
          }).ToList();
            return AppointmentsList;
        }

        public List<AppointmentEL> SearchAppointmentByDateAndServiceAndName(DateTime date, int service, int clienttid, int? branchID,int bypackage)
        {
            List<AppointmentEL> AppointmentsList = new List<AppointmentEL>();
            if (bypackage==1)
            {
            if((service!=0) && (clienttid!=0))
            {
                AppointmentsList = (from ap in tblappointments 
                                    join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId 
                                    join pkgser in tblpackagedtls on appkg.FK_PackageId equals pkgser.Package_Id join pkg in tblpackages on pkgser.Package_Id equals pkg.Id
                                    join ser in tblservices on pkgser.ServiceId equals ser.ServiceId
                                    where ser.ServiceId == service  && ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                    && ap.FK_ClientId == clienttid && ap.ByPackage==true
                                    select new AppointmentEL()
                                    {
                                        AppointmentTime = ap.AppointmentTime
                                    }
                                                       ).ToList();
            }
            else if ((service != 0) && (clienttid == 0))
            {
                AppointmentsList = (from ap in tblappointments
                                    join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
                                    join pkgser in tblpackagedtls on appkg.FK_PackageId equals pkgser.Package_Id
                                    join pkg in tblpackages on pkgser.Package_Id equals pkg.Id
                                    join ser in tblservices on pkgser.ServiceId equals ser.ServiceId
                                    where ser.ServiceId == service && ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                    && ap.ByPackage == true
                                    select new AppointmentEL()
                                    {
                                        AppointmentTime = ap.AppointmentTime
                                    }
                                                       ).ToList();
            }
            else if ((service == 0) && (clienttid != 0))
            {
                AppointmentsList = (from ap in tblappointments
                                    join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
                                    join pkgser in tblpackagedtls on appkg.FK_PackageId equals pkgser.Package_Id
                                    join pkg in tblpackages on pkgser.Package_Id equals pkg.Id
                                    join ser in tblservices on pkgser.ServiceId equals ser.ServiceId
                                    where ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                    && ap.FK_ClientId == clienttid && ap.ByPackage == true
                                     
                                    select new AppointmentEL()
                                    {
                                        AppointmentTime = ap.AppointmentTime
                                    }
                                                       ).ToList();
            }
            else if ((service == 0) && (clienttid == 0))
            {
                AppointmentsList = (from ap in tblappointments
                                    join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
                                    join pkgser in tblpackagedtls on appkg.FK_PackageId equals pkgser.Package_Id
                                    join pkg in tblpackages on pkgser.Package_Id equals pkg.Id
                                    join ser in tblservices on pkgser.ServiceId equals ser.ServiceId
                                    where  ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                    && ap.ByPackage == true

                                    select new AppointmentEL()
                                    {
                                        AppointmentTime = ap.AppointmentTime
                                    }
                                                       ).ToList();
            }
            }

                //..........................................Byservice .......................
            else
            {
                if ((service != 0) && (clienttid != 0))
                {
                    AppointmentsList = (from ap in tblappointments
                                        join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
                                        join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                                        where ser.ServiceId == service && ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                        && ap.FK_ClientId == clienttid && ap.ByPackage == false
                                        select new AppointmentEL()
                                        {
                                            AppointmentTime = ap.AppointmentTime
                                        }
                                                           ).ToList();
                }
                else if((service != 0) && (clienttid == 0))
                {
                    AppointmentsList = (from ap in tblappointments
                                        join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
                                        join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                                        where ser.ServiceId == service && ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                        && ap.ByPackage == false
                                        select new AppointmentEL()
                                        {
                                            AppointmentTime = ap.AppointmentTime
                                        }
                                                           ).ToList();
                }
                else if ((service == 0) && (clienttid != 0))
                {
                    AppointmentsList = (from ap in tblappointments
                                        join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
                                        join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                                        where   ap.FK_ClientId == clienttid && ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                        && ap.ByPackage == false
                                        select new AppointmentEL()
                                        {
                                            AppointmentTime = ap.AppointmentTime
                                        }
                                                          ).ToList();
                }
                else if ((service == 0) && (clienttid == 0))
                {
                    AppointmentsList = (from ap in tblappointments
                                        join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
                                        join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
                                        where  ap.FK_BranchID == branchID && ap.AppointmentDate == date
                                        && ap.ByPackage == false
                                        select new AppointmentEL()
                                        {
                                            AppointmentTime = ap.AppointmentTime
                                        }
                                                          ).ToList();
                }
            }

            
            
                
            //    tblappointments.Where(x=>x.AppointmentDate)

            //List<AppointmentEL> AppointmentsList = tblappointments.Where(x => x.FK_ServiceId == (service != 0 ? service : x.FK_ServiceId)
            //                                       && x.FK_BranchID == branchID).Where(c => c.FK_ClientId == (clienttid != 0 ? clienttid : c.FK_ClientId) && c.AppointmentDate == date).Select(s => new AppointmentEL()
            //{
            //    AppointmentTime = s.AppointmentTime
            //}).ToList();
            return AppointmentsList;
        }

        //public List<AppointmentEL> SearchAppointmentByDateAndUserId(DateTime date, int UserId, int? branchID)
        //{
        //    // DateTime todayDate = DateTime.Today;
        //    //  return tblAppointments.Where(x => x.AppointmentDate == todayDate).ToList();

        //    List<AppointmentEL> AppointmentsList = tblappointments.Where(x => x.AppointmentDate == date.Date && x.FK_UserId == UserId && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
        //    {
        //        PatientName = x.tblpatient.PatientName,
        //        AppointmentTime = x.AppointmentTime
        //    }).ToList();
        //    return AppointmentsList;
        //}

        //public List<AppointmentEL> SearchAppointmentByDateAndServiceId(DateTime date, int UserId, int? branchID)
        //{
        //    List<AppointmentEL> AppointmentsList = tblappointments.Where(x => x.AppointmentDate == date.Date && x.FK_ServiceId == UserId && x.FK_BranchID == branchID).Select(x => new AppointmentEL()
        //    {
        //        PatientName = x.tblpatient.PatientName,
        //        AppointmentTime = x.AppointmentTime
        //    }).ToList();
           
        //    return AppointmentsList;
        //}
        #region -------------------------------------Company Details---------------------------------------
        public int InsertUpdateCompDetails(tblcompdetail objtblcompdetail)
        {
            if (objtblcompdetail.Comp_Id == 0)
            {
                tblcompdetails.Add(objtblcompdetail);
                SaveChanges();
            }
            else
            {
                var Id = tblcompdetails.Find(objtblcompdetail.Comp_Id);
                Entry(Id).CurrentValues.SetValues(objtblcompdetail);
                SaveChanges();
            }
            return objtblcompdetail.Comp_Id;
        }
        public tblcompdetail CompanyDetails()
        {
            return tblcompdetails.FirstOrDefault();
        }
        #endregion
    }

}
