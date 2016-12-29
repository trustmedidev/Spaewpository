using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using EntityLayer;
using System.Data.Entity.Core.Objects;
using DataAccessLayer.Repository;
using System.Data.Entity;

namespace DataAccessLayer
{
  public  class SettingDAL : SpaPracticeEntities
    {
        //#region Serice and Rate

        #region Service & rate

      public int InsertServiceLog(tblservicelog objtblservicelog)
      {
          if (objtblservicelog.ServiceLogId == 0)
          {
              tblservicelogs.Add(objtblservicelog);
              SaveChanges();
          }
          else { }
          return objtblservicelog.ServiceLogId;
      }
      public int InsertMapService(tblmapservice objtblmapservice)
      {
          if (objtblmapservice.MapServiceId == 0)
          {
              tblmapservices.Add(objtblmapservice);
              SaveChanges();
          }
          else { }
          return objtblmapservice.MapServiceId;
      }
      public int InsertUpdateSerivceAndRate(tblservice objService)
      {
          try
          {
              if (objService.ServiceId == 0)
              {
                  tblservices.Add(objService);
                  SaveChanges();
              }
              else
              {
                  Entry(objService).State = EntityState.Modified;
                  SaveChanges();
              }
          }
          catch (Exception)
          {

              throw;
          }
          return objService.ServiceId;
      } 
      public List<ServiceEL> GetAllServicesForServiceAndRateGrid(int? branchID)
        {
            //List<tblservice> servicelist = new List<tblservice>();
            //var data = (from p in tblservices.Where(p =>p.FK_BranchID == branchID)
            //            select new
            //            {
            //                ServiceId = p.ServiceId,
            //                ServiceName = p.ServiceName,
            //                Amount = p.Amount,
            //                Effective_Date=p.Effective_Date,
            //                IsActive=p.IsActive,

            //            }).ToList();
            //// servicelist = (List<tblservice>)data;
            //foreach (var item in data)
            //{
            //    servicelist.Add(new tblservice() { ServiceId = item.ServiceId, ServiceName = item.ServiceName, Amount = item.Amount, Effective_Date = item.Effective_Date, IsActive = item.IsActive });  
            //}
            //return servicelist.OrderBy(p => p.ServiceName).ToList();

            var query = tblservices.Where(x => x.FK_BranchID == branchID).Select(x => new ServiceEL()
            {
                ServiceName = x.ServiceName,
                ServiceId = (int)x.ServiceId,
                IsActive = (bool)x.IsActive,
                TimeExpende=(int)x.TimeExpende,
            }).ToList();

            foreach (var item in query)
            {
                item.Amount = GetRateFromService(item.ServiceId);
                item.Effective_Date = GetDateFromService(item.ServiceId);
            }
            return query.ToList();

        } 
        public tblservice GetAllServicesById(int? serviceId, int? branchID)
        {
            return tblservices.Where(x => x.ServiceId == serviceId && x.FK_BranchID == branchID).FirstOrDefault();
        }
        public bool CheckServiceName(string serviceName, int? branchID)
        {
            var dtls = tblservices.Where(x => x.ServiceName.Trim().ToUpper() == serviceName && x.FK_BranchID == branchID).FirstOrDefault();

            if (dtls != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckExistingService(string serviceName, int? branchID, int serviceId)
        {
            bool ret = false;
            try
            {
                tblservice t = new tblservice();
                if (serviceId == 0)
                {
                    t = tblservices.Where(x => x.ServiceName.ToLower() == serviceName.ToLower() && x.FK_UserId == null && x.FK_BranchID == branchID && x.IsActive==true).FirstOrDefault();
                }
                else
                {
                    t = tblservices.Where(x => x.ServiceName.ToLower() == serviceName.ToLower() && x.FK_UserId == null && x.FK_BranchID == branchID && x.ServiceId != serviceId && x.IsActive == true).FirstOrDefault();
                }
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
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion Service & rate

         

     

      public List<tblcoupanmaster> GetAllCoupon(int? branchid)
      {
          List<tblcoupanmaster> couponlist = tblcoupanmasters.Where(x => x.FK_BranchID == branchid && x.IsActive == true).ToList();
          couponlist.Add(new tblcoupanmaster() { Coupon_Id = "0", Coupan_Name = "Select Gift Coupon" });
          return couponlist.OrderBy(x => x.Coupon_Id).ToList();
      }


      //......................Code Modified By Sandip on 04042016..........................


      //public List<tblpackage> GetAllPackage(int? branchid)
      //{

      //    List<tblpackage> packagelist = tblpackages.Where(x => x.fk_BranchID == branchid && x.IsActive == true).ToList();
      //    packagelist.Add(new tblpackage() { Package_Id = "0", Package_Name = "Select Package" });
      //    return packagelist.OrderBy(x => x.Package_Id).ToList();
      //}

      public List<tblpackage> GetAllPackage(int? branchid)
      {

          List<tblpackage> packagelist = tblpackages.Where(x => x.fk_BranchID == branchid && x.IsActive == true).ToList();
          packagelist.Add(new tblpackage() { Package_Id = "0", Package_Name = "Select Package" });
          return packagelist.OrderBy(x => x.Package_Id).ToList();
      }


      public Decimal? GetCouponAmountByID(string couponid, int? branchID)
      {

          Decimal? amount = tblcoupanmasters.Where(x => x.Coupon_Id == couponid && x.IsActive == true && x.FK_BranchID==branchID).FirstOrDefault().Coupon_Amt;
          if(amount!=null)
          {
              return amount;
          }
          else
          {
              return null;
          }

         
      }
      
      public List<tblservice> GetAllServices(int? branchID)
      {
          List<tblservice> ServiceList = tblservices.Where(x => x.IsActive == true && x.FK_UserId == null && x.FK_BranchID == branchID).ToList();

          //ServiceList.Add(new tblservice() { ServiceId = 0, ServiceName = "Select Service" });

          return ServiceList.OrderBy(x => x.ServiceName).ToList();
      }
      //public List<tblservice> GetAllServicesForGrid(int? branchID)
      //{
      //    List<tblservice> ServiceList = tblservices.Where(x => x.IsActive == true && x.FK_UserId == null && x.FK_BranchID == branchID).ToList();
      //    return ServiceList.OrderBy(x => x.ServiceId).ToList();
      //}
      public List<tblservice> GetAllServicesForGrid(int? branchID)
      {
          List<tblservice> servicelist = new List<tblservice>();
          var data = (from p in tblservices.Where(p => p.IsActive == true && p.FK_UserId == null && p.FK_BranchID == branchID)
                      select new
                      {
                          ServiceId = p.ServiceId,
                          ServiceName = p.ServiceName,
                          Amount = ""
                      }).ToList();
          // servicelist = (List<tblservice>)data;
          foreach (var item in data)
          {

              decimal? Amnt = GetRateFromService(item.ServiceId);
              servicelist.Add(new tblservice()
              {
                  ServiceId = item.ServiceId,
                  ServiceName = item.ServiceName + "  (RS: " + Convert.ToString(Amnt) + ")",
                  Amount = Amnt
              });
          }
          return servicelist.OrderBy(p => p.ServiceId).ToList();
      }
      
      /*--------------------------------Rev By Sandip Das on 02-06-2016----------------------------*/
      public List<tblclient> ShowTodaysBirthdayList(int? branchId)
      {
          return tblclients.Where(x => x.FK_BranchID == branchId && x.DateOfBirth == DateTime.Today).ToList();
      }
      public List<ServiceEL> GetRateAndEfcDateById(int? Id, DateTime? EfcDate)
      {
          var query = tblmapservices.Where(x => x.FK_ServiceId == Id && x.EffectiveDate == EfcDate && x.EffectiveDate != null && x.Amount != null).Select(x => new ServiceEL()
          {
              Amount = x.Amount,
              Effective_Date = x.EffectiveDate,
          }).ToList();
          return query.ToList();
      }
      public List<NVP> GetAllServiceByEfcDate(int? branchId)
      {
          List<NVP> Service = new List<NVP>();
          List<NVP> serviceList = new List<NVP>();
          var serviceIdList = tblservices.Where(x => x.FK_BranchID == branchId).Select(x => x.ServiceId).ToList();

          foreach (var id in serviceIdList)
          {
              var efcdateList = tblmapservices.Where(x => x.FK_ServiceId == id).Select(x => x.EffectiveDate.Value).ToList();
              var closestdate = efcdateList.Where(x => x <= DateTime.Today).DefaultIfEmpty().Max();
              if (closestdate != null)
              {
                  //taxList = tbl_maptax.Where(x => x.EffectiveDate == closestdate).Select(x => new NVP { Value = x.tbl_tax.TaxId, Text = x.tbl_tax.TaxName + " " + "(" + x.tbl_tax.TaxRate + ")" }).OrderByDescending(x=>x.Value).GroupBy(g=>g.Value).Select(s=>s.FirstOrDefault()).ToList();
                  //taxList = tbl_maptax.Where(x => x.EffectiveDate == closestdate).Select(x => new NVP { Value = x.tbl_tax.TaxId, Text = x.tbl_tax.TaxName + " " + "(" + x.tbl_tax.TaxRate + "%" + ")" }).ToList();
                  serviceList = tblmapservices.Where(x => x.EffectiveDate == closestdate).Select(x => new NVP { Value = x.FK_ServiceId, Text =x.tblservice.ServiceName + " " + "(" + x.Amount + "Rs" + ")" }).ToList();
                  var order = serviceList.OrderByDescending(o => o.Value).GroupBy(g => g.Value).Select(s => s.FirstOrDefault());
                  foreach (var item in order)
                  {
                      Service.Add(item);
                  }
              }
          }
          return Service;
      }
      public decimal? GetRateFromService(int? serviceId)
      {
          var query = tblmapservices.Where(x => x.FK_ServiceId == serviceId && x.EffectiveDate != null).Select(x => x.EffectiveDate.Value).ToList();
          decimal? query1 = new decimal();
          if (query.Count > 1)
          {
              var closestdate = query.Where(x => x.Date <= DateTime.Today.Date).DefaultIfEmpty().Max();
              query1 = (tblmapservices.Where(x => x.EffectiveDate == closestdate).Select(x => x.Amount) == null ? 0 : tblmapservices.Where(x => x.EffectiveDate == closestdate).Select(x => x.Amount).FirstOrDefault());
          }
          else
          {
              query1 = (tblmapservices.Where(x => x.FK_ServiceId == serviceId).Select(x => x.Amount) == null ? 0 : tblmapservices.Where(x => x.FK_ServiceId == serviceId).Select(x => x.Amount).FirstOrDefault());
          }
          return (decimal?)query1;
      }
      public DateTime? GetDateFromService(int? serviceId)
      {
          var query = tblmapservices.Where(x => x.FK_ServiceId == serviceId && x.EffectiveDate != null).Select(x => x.EffectiveDate).ToList();
          DateTime? query1 = new DateTime();
          if (query.Count > 1)
          {
              var closestdate = query.Where(x => x.Value.Date <= DateTime.Today.Date).DefaultIfEmpty().Max();
              query1 = (tblmapservices.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate) == null ? Convert.ToDateTime(null) : tblmapservices.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate).FirstOrDefault());
          }
          else
          {
              query1 = (tblmapservices.Where(x => x.FK_ServiceId == serviceId).Select(x => x.EffectiveDate) == null ? Convert.ToDateTime(null) : tblmapservices.Where(x => x.FK_ServiceId == serviceId).Select(x => x.EffectiveDate).FirstOrDefault());
          }
          return (DateTime?)query1;
      }

      #region ------------------------Therapist---------------------------

      public int InsertUpdateTherapist(tbltherapist objtbltherapist)
      {
          if (objtbltherapist.TherapistId == 0)
          {
              tbltherapists.Add(objtbltherapist);
              SaveChanges();
          }
          else
          {
              var Id = tbltherapists.Find(objtbltherapist.TherapistId);
              Entry(Id).CurrentValues.SetValues(objtbltherapist);
              SaveChanges();
          }
          return objtbltherapist.TherapistId;
      }

      public List<TherapistEL> TherapistList(int? branchId)
      {
          var s = tbltherapists.Where(x => x.FK_BranchId == branchId).Select(x => new TherapistEL 
          {
              TherapistId=x.TherapistId,
              Name=x.Name,
              Address=x.Address,
              Commission=x.Commission,
              Email=x.Email,
              Days=x.Days,
              Mobile=x.Mobile,
              IsActive=x.IsActive,
              Specialist=x.Specialist,
              Timings=x.Timings,
              Leaves=x.TherapistLeave
          }).ToList();
          foreach (var item in s)
          {
              if (item.IsActive == true) { item.Status = "Active"; }
              else {item.Status = "Inactive"; }
          }
          return s;
      }
      public tbltherapist TherapistById(int? ThpId, int? branchId)
      {
          return tbltherapists.Where(x => x.TherapistId == ThpId && x.FK_BranchId == branchId).FirstOrDefault();
      }
      public Boolean DeleteTherapist(int? ThpId, int? branchID)
      {
          //int s = default(int);
          //if (ThpId > 0)
          //{
          //    //tbltherapist objtbltherapist = new tbltherapist();
          //    var del = tbltherapists.Find(ThpId);
          //    //objtbltherapist.IsActive = false;
          //    //tbltherapists.Add(objtbltherapist);
          //    tbltherapists.Remove(del);
          //    s=SaveChanges();
          //}
          //if (s > 0) { return true; } else { return false; }
          try
          {
              tbltherapist itemToRemove = tbltherapists.SingleOrDefault(x => x.TherapistId == ThpId && x.FK_BranchId == branchID);
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

      public List<string> GetAllMobileClient(int branchId)
      {
          return tbltherapists.Where(x => x.FK_BranchId == branchId).Select(x => x.Mobile).ToList();
      }


      #endregion 

      /*--------------------------------Rev By Sandip Das on 02-06-2016----------------------------*/
      public List<tbltaxmaster> GetAllTaxTypeForListbox(int? branchID)
      {
          List<tbltaxmaster> TaxList = tbltaxmasters.Where(x => x.IsActive == true && x.FK_BranchID == branchID).ToList();
          //TaxList.Add(new tbltaxmaster { Tax_Id = 0, Tax_Name = "All Active" });
          return TaxList.OrderBy(x => x.Tax_Name).ToList();
      }

      public List<tblservice> GetAllServicesForCheckList(int? branchID)
      {
          //List<tblservice> ServiceList = tblservices.Where(x => x.IsActive == true && x.FK_UserId == null && x.FK_BranchID == branchID).Select(new servi          return ServiceList.OrderBy(x => x.ServiceId).ToList();

          List<tblservice> objtblservice = new List<Repository.tblservice>();
          var serviceList = from service in tblservices.Where(x => x.IsActive == true && x.FK_UserId == null && x.FK_BranchID == branchID)
                            select new
                            {
                                ServiceId = service.ServiceId,
                                ServiceName = service.ServiceName + "(" + (service.Amount) + ")"

                            };

          if (serviceList != null)
          {
              foreach (var item in serviceList)
              {
                  objtblservice.Add(new tblservice() { ServiceId = item.ServiceId, ServiceName = item.ServiceName });
              }
              return objtblservice;
          }
          else
          {
              return null;
          }
      }

      //public List<tblservice> GetAllServicesForGrid(int? branchID)
      //{
      //    List<tblservice> ServiceList = tblservices.Where(x => x.IsActive == true && x.FK_UserId == null && x.FK_BranchID == branchID).Select( new ServiceId=x.}.ToList();
      //    return ServiceList.OrderBy(x => x.ServiceId).ToList();
      //}
      public List<tbluser> GetAllExpert(int? branchID)
      {
          List<tbluser> DoctorList = tblusers.Where(x => x.FK_RoleId == 2 && x.FK_BranchID == branchID).ToList();

          DoctorList.Add(new tbluser() { UserId = 0, Name = "Select Expert" });

          return DoctorList.OrderBy(x => x.UserId).ToList();
      }
      public List<tbluser> GetAllAppointmentDoctor(int? branchID)
      {
          List<tbluser> DoctorList = tblusers.Where(x => x.FK_RoleId == 2 && x.FK_BranchID == branchID).ToList();


          return DoctorList;
      }

      public bool DeleteServicesById(int serviceId, int? branchID)
      {
          try
          {
              tblservice itemToRemove = tblservices.SingleOrDefault(x => x.ServiceId == serviceId && x.FK_BranchID == branchID);
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


      public tblservice GetServicesIdByUserId(int UserId, int? branchID)
      {
          return tblservices.Where(x => x.FK_UserId == UserId && x.FK_BranchID == branchID).FirstOrDefault();
      }

        //public tblavailablity GetAvailablityIdByUserId(int UserId, int? branchID)
        //{
        //    return tblavailablities.Where(x => x.FK_UserId == UserId && x.FK_BranchID == branchID).FirstOrDefault();
        //}
        //public tblavailablity GetAvailablityIdByServiceId(int ServiceId, int? branchID)
        //{
        //    //var ret = tblavailablities.Where(x => x.FK_ServiceId == ServiceId);
        //    //if (ret != null)
        //    //{
        //    //    return ret.FirstOrDefault();
        //    //}
        //    //else
        //    //{
        //    //    return new tblavailablity();
        //    //}
        //    return tblavailablities.Where(x => x.FK_ServiceId == ServiceId && x.FK_BranchID == branchID).FirstOrDefault();
        //}

      
        //#endregion

        //#region Tax Configuration
        ////public int InsertUpdateTaxConfiguration(tblTaxConfiguration objTax)
        ////{
        ////    try
        ////    {
        ////        if (objTax.TaxId == 0)
        ////        {
        ////            tblTaxConfigurations.Add(objTax);
        ////            SaveChanges();
        ////        }
        ////        else
        ////        {
        ////            Entry(objTax).State = EntityState.Modified;
        ////            SaveChanges();
        ////        }
        ////    }
        ////    catch (Exception)
        ////    {

        ////        throw;
        ////    }
        ////    return objTax.TaxId;
        ////}

        ////public tblTaxConfiguration GetAllTaxById(int taxId)
        ////{
        ////    return tblTaxConfigurations.Where(x => x.TaxId == taxId).FirstOrDefault();
        ////}

        ////public List<tblTaxConfiguration> GetAllTax()
        ////{
        ////    List<tblTaxConfiguration> TaxList = tblTaxConfigurations.Where(x => x.IsActive == true).ToList();

        ////    return TaxList;
        ////}

        ////public bool DeleteTaxById(int taxId)
        ////{
        ////    try
        ////    {
        ////        tblTaxConfiguration itemToRemove = tblTaxConfigurations.FirstOrDefault(x => x.TaxId == taxId);
        ////        itemToRemove.IsActive = false;
        ////        Entry(itemToRemove).State = EntityState.Modified;
        ////        SaveChanges();

        ////        return true;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return false;
        ////    }
        ////}
        //public int InsertUpdateAppintmentSeeting(tblappointmentsetting objService)
        //{
        //    try
        //    {

        //        Entry(objService).State = EntityState.Modified;
        //        SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return objService.AppSettingId;
        //}

      public tblcompdetail GetLogo(int AppSettingId, int? branchID)
      {
          return tblcompdetails.Where(x => x.Comp_Id == AppSettingId && x.FK_BranchId == branchID).FirstOrDefault();
      }


      public int InsertUpdateAppintmentAvailability(tblavailablity objAvail)
      {
          try
          {
              if (objAvail.AvailableId == 0)
              {
                  tblavailablities.Add(objAvail);
                  SaveChanges();
              }
              else
              {
                  Entry(objAvail).State = EntityState.Modified;
                  SaveChanges();
              }
          }
          catch (Exception)
          {

              throw;
          }
          return objAvail.AvailableId;
      }
      public List<ClientEL> GetAllClientForBirthday(string clientname, DateTime? date,  int? branchID)
      {
          List<ClientEL> ClientList = new List<ClientEL>();
          if (date == null)
          {
              ClientList = (from client in tblclients
                            join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                            where (client.ClientName == (clientname != null ? clientname : client.ClientName) && client.FK_BranchID == branchID)
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
          else
          {
              ClientList = (from client in tblclients
                            join appt in tblappointments on client.ClientId equals appt.FK_ClientId
                            where (client.ClientName == (clientname != null ? clientname : client.ClientName)
                            && client.FK_BranchID == branchID
                    && EntityFunctions.TruncateTime(client.DateOfBirth.Value) >= EntityFunctions.TruncateTime(date.Value) && EntityFunctions.TruncateTime(client.DateOfBirth.Value) <= EntityFunctions.TruncateTime(date.Value))

                            //&& EntityFunctions.TruncateTime(client.DateOfBirth.Value.Month)>=EntityFunctions.TruncateTime(FromDate.Value.Month))
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
     

      //public List<ClientEL> GetAllClientForBirthday(string ClientName, DateTime? FromDate,  DateTime? toDate, int? branchID)
      //{
      //    List<ClientEL> ClientList = new List<ClientEL>();
      //    if (toDate==null)
      //    {
      //        ClientList = (from client in tblclients
      //                      join appt in tblappointments on client.ClientId equals appt.FK_ClientId
      //                      where (client.ClientName == (ClientName !=null? ClientName:client.ClientName) && client.FK_BranchID == branchID)
      //                      select new ClientEL()
      //                      {
      //                          ClientId = client.ClientId,
      //                          ClientName = client.ClientName,
      //                          Sex = client.Sex,
      //                          Address = client.Address,
      //                          DateOfBirth = (DateTime)client.DateOfBirth,
      //                          Email = client.Email,
      //                          Mobile = client.Mobile,
      //                      }).ToList();
      //    }
      //    else
      //    {
      //        ClientList = (from client in tblclients
      //                      join appt in tblappointments on client.ClientId equals appt.FK_ClientId
      //                      where (client.ClientName == (ClientName != null ? ClientName : client.ClientName)
      //                      && client.FK_BranchID == branchID
      //              && ((client.DateOfBirth.Value.Month >= FromDate.Value.Month) && (client.DateOfBirth.Value.Month <= toDate.Value.Month)))

      //                      //&& EntityFunctions.TruncateTime(client.DateOfBirth.Value.Month)>=EntityFunctions.TruncateTime(FromDate.Value.Month))
      //                      select new ClientEL()
      //                      {
      //                          ClientId = client.ClientId,
      //                          ClientName = client.ClientName,
      //                          Sex = client.Sex,
      //                          Address = client.Address,
      //                          DateOfBirth = (DateTime)client.DateOfBirth,
      //                          Email = client.Email,
      //                          Mobile = client.Mobile,
      //                      }).ToList();
      //    }


          // Search Only By ClientName
          //if (!string.IsNullOrEmpty(ClientName))
          ////&& string.IsNullOrEmpty(planType) && FromDate == null)
          //{
          //    ClientList = (from client in tblclients
          //                  //join appt in tbl_appointment on client.ClientID equals appt.FK_ClientID
          //                  where (client.ClientName == ClientName && client.FK_BranchID == branchID)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search Only By Date
          //else if (string.IsNullOrEmpty(ClientName))
          ////&& string.IsNullOrEmpty(planType) && FromDate != null)
          //{
          //    ClientList = (from client in tblclients
          //                  //join appt in tbl_appointment on client.ClientID equals appt.FK_ClientID
          //                  where (EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate) && client.FK_BranchID == branchID)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search Only By PlanType
          //else if (string.IsNullOrEmpty(ClientName))
          ////&& !string.IsNullOrEmpty(planType) && FromDate == null)
          //{
          //    ClientList = (from client in tblclients
          //                  join appt in tblappointments on client.ClientId equals appt.FK_ClientId
          //                  //where (appt.PlanType == planType && client.FK_BranchID == branchID)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search By ClientName & Date
          //else if (!string.IsNullOrEmpty(ClientName))
          ////&& string.IsNullOrEmpty(planType) && FromDate != null)
          //{
          //    ClientList = (from client in tblclients
          //                  //join appt in tbl_appointment on client.ClientID equals appt.FK_ClientID
          //                  where (client.ClientName == ClientName && EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate)
          //                  && client.FK_BranchID == branchID)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search By PlanType & Date
          //else if (string.IsNullOrEmpty(ClientName))
          ////&& !string.IsNullOrEmpty(planType) && FromDate != null)
          //{
          //    ClientList = (from client in tblclients
          //                  join appt in tblappointments on client.ClientId equals appt.FK_ClientId
          //                  where 
          //                  //(appt.PlanType == planType && 
          //                  EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate)
          //                  && client.FK_BranchID == branchID
          //                      //)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search By ClientName & PlanType
          //else if (!string.IsNullOrEmpty(ClientName))
          ////&& !string.IsNullOrEmpty(planType) && FromDate == null)
          //{
          //    ClientList = (from client in tblclients
          //                  join appt in tblappointments on client.ClientId equals appt.FK_ClientId
          //                  //where (appt.PlanType == planType && client.ClientName == ClientName
          //                  //&& client.FK_BranchID == branchID)
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          //}
          //// Search By All Fields
          //else
          //{
          //    ClientList = (from client in tblclients
          //                  join appt in tblappointments on client.ClientId equals appt.FK_ClientId
          //                  where (client.ClientName == ClientName && client.FK_BranchID == branchID
          //                  //&& (appt.PlanType == planType)
          //                  && EntityFunctions.TruncateTime(client.DateOfBirth) == EntityFunctions.TruncateTime(FromDate))
          //                  select new ClientEL()
          //                  {
          //                      ClientId = client.ClientId,
          //                      ClientName = client.ClientName,
          //                      Sex = client.Sex,
          //                      Address = client.Address,
          //                      DateOfBirth = (DateTime)client.DateOfBirth,
          //                      Email = client.Email,
          //                      Mobile = client.Mobile,
          //                  }).ToList();
          }
          return ClientList;
      }

      public string GetTaxToatlAmount(int serviceId, int? branchID)
      {
          string TaxAmount = "";
          try
          {
              var taxids = tblservices.Where(x => x.ServiceId == serviceId && x.FK_BranchID == branchID).Select(x => x.TaxID).FirstOrDefault();
              decimal totaltax = 0;
              string[] ids = null;
              if (taxids.Contains(','))
              {
                  ids = taxids.Split(',');

                  foreach (var item in ids)
                  {
                      int? tid = Convert.ToInt32(item);
                      var amount = GetRateFromTax(tid);
                      totaltax += Convert.ToDecimal(amount);


                  }


              }
              else
              {
                  var amount = GetRateFromTax(Convert.ToInt32(taxids));
                  totaltax = Convert.ToDecimal(amount);
              }

              TaxAmount = Convert.ToString(totaltax);
          }
          catch (Exception)
          {


          }

          return TaxAmount;
      }

      public string GetTaxTotalAmountByPackageId(int Id, int? branchID)
      {
          string TaxAmount = "";
          try
          {
              var taxids = tblpackages.Where(x => x.Id == Id && x.fk_BranchID == branchID).Select(x => x.TaxID).FirstOrDefault();
              decimal totaltax = 0;
              string[] ids = null;
              if (taxids.Contains(','))
              {
                  ids = taxids.Split(',');

                  foreach (var item in ids)
                  {
                      int? tid = Convert.ToInt32(item);
                      var amount = GetRateFromTax(tid);
                      totaltax += Convert.ToDecimal(amount);


                  }


              }
              else
              {
                  var amount = GetRateFromTax(Convert.ToInt32(taxids));
                  totaltax = Convert.ToDecimal(amount);
              }

              TaxAmount = Convert.ToString(totaltax);
          }
          catch (Exception)
          {


          }

          return TaxAmount;
      }
      //#endregion

      public string GetServiceToatlAmount(int serviceId, int? branchID)
      {
          string TaxAmount = "";
          try
          {
              var taxids = tblservices.Where(x => x.ServiceId == serviceId && x.FK_BranchID == branchID).Select(x => x.TaxID).FirstOrDefault();
              decimal totaltax = 0;
              string[] ids = null;
              if (taxids.Contains(','))
              {
                  ids = taxids.Split(',');

                  foreach (var item in ids)
                  {
                      int? tid = Convert.ToInt32(item);
                      var amount = GetRateFromTax(tid);
                      totaltax += Convert.ToDecimal(amount);


                  }


              }
              else
              {
                  var amount = GetRateFromService(Convert.ToInt32(serviceId));
                  totaltax = Convert.ToDecimal(amount);
              }

              TaxAmount = Convert.ToString(totaltax);
          }
          catch (Exception)
          {


          }

          return TaxAmount;
      }
      public decimal? GetRateFromTax(int? taxId)
      {
          var query = tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).ToList();
          decimal? query1 = new decimal();
          if (query.Count > 1)
          {
              var closestdate = query.Where(x => x.Value.Date <= DateTime.Today.Date).DefaultIfEmpty().Max();
              query1 = (tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.TaxRate).FirstOrDefault() == null ? 0 : tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.TaxRate).FirstOrDefault());
          }
          else
          {
              query1 = (tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.TaxRate).FirstOrDefault() == null ? 0 : tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.TaxRate).FirstOrDefault());
          }
          return (decimal)query1;
      }

      //public decimal? GetRateFromService(int? srvId)
      //{
      //    var query = tblservicelogs.Where(x => x.FK_ServiceId == srvId).Select(x => x.EffectiveDate).ToList();
      //    decimal? query1 = new decimal();
      //    if (query.Count > 1)
      //    {
      //        var closestdate = query.Where(x => x.Value.Date <= DateTime.Today.Date).DefaultIfEmpty().Max();
      //        query1 = (tblservicelogs.Where(x => x.EffectiveDate == closestdate).Select(x => x.Rate).FirstOrDefault() == null ? 0 : tblservicelogs.Where(x => x.EffectiveDate == closestdate).Select(x => x.Rate).FirstOrDefault());
      //    }
      //    else
      //    {
      //        query1 = (tblservicelogs.Where(x => x.FK_ServiceId == srvId).Select(x => x.Rate).FirstOrDefault() == null ? 0 : tblservicelogs.Where(x => x.FK_ServiceId == srvId).Select(x => x.Rate).FirstOrDefault());
      //    }
      //    return (decimal)query1;
      //}
        //public DateTime? GetDateFromTax(int? taxId)
        //{
        //    var query = tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).ToList();
        //    DateTime? query1 = new DateTime();
        //    if (query.Count > 1)
        //    {
        //        var closestdate = query.Where(x => x <= DateTime.Today).DefaultIfEmpty().Max();
        //        query1 = (tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate).FirstOrDefault()==null?Convert.ToDateTime(null):tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate).FirstOrDefault());
        //    }
        //    else
        //    {
        //        query1 = (tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).FirstOrDefault() == null ? Convert.ToDateTime(null) : tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).FirstOrDefault());
        //    }
        //    return (DateTime)query1;
        //}

      public decimal GetPackageAmount(int id,int? branchId)
      {
          var Pkg = tblpackages.Where(x => x.Id == id && x.fk_BranchID == branchId).Select(x => x.Package_Rate).FirstOrDefault();

          return Pkg;
      }

      public int? GetTotalTime(int serviceId, int? branchID)
      {
          int? TotalTime = 0;
          try
          {
              TotalTime = tblservices.Where(x => x.ServiceId == serviceId && x.FK_BranchID == branchID).Select(x => x.TimeExpende).FirstOrDefault();

              
          }
          catch (Exception)
          {


          }

          return TotalTime;
      }




      public int InsertPrintSetup(tblprintsetup objtblprintsetup)
      {
          if (objtblprintsetup.Id == 0)
          {
              tblprintsetups.Add(objtblprintsetup);
              SaveChanges();
          }
          else
          {
                var Id = tblprintsetups.Find(objtblprintsetup.Id);
                Entry(Id).CurrentValues.SetValues(objtblprintsetup);
                SaveChanges();
          }
          return objtblprintsetup.Id;
      }

      public tblprintsetup PrintDetails()
      {
          return tblprintsetups.FirstOrDefault();
      }

      public Boolean? GetStatusOfInventory(int? inventoryId)
      {
          var query = tblinventories.Where(x => x.Id == inventoryId).Select(x => x.IsActive).FirstOrDefault();
          if (query == true) { return true; } else { return false; }
      }
      public Boolean? GetStatusOfService(int? serviceId)
      {
          var query = tblservices.Where(x => x.ServiceId == serviceId).Select(x => x.IsActive).FirstOrDefault();
          if (query == true) { return true; } else { return false; }
      }
      public Boolean? GetStatusOfTherapist(int? ThpId)
      {
          var query = tbltherapists.Where(x => x.TherapistId == ThpId).Select(x => x.IsActive).FirstOrDefault();
          if (query == true) { return true; } else { return false; }
      }
    }
}
