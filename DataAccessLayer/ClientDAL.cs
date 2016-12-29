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
    public class ClientDAL : SpaPracticeEntities
    {
        //SpaPracticeEntities db = new SpaPracticeEntities();
        public int InsertUpdateClient(tblclient objClient)
        {
            try
            {
                if (objClient.ClientId == 0)
                {

                    tblclients.Add(objClient);
                    SaveChanges();
                }
                else
                {
                    Entry(objClient).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objClient.ClientId;
        }

        public List<tblappointment> GetPatientAppointmentListByPatientId(int clientId)
        {
            return tblappointments.Where(x => x.FK_ClientId == clientId).ToList();
        }
        //public List<tblAppointment> GetPatientAppointmentListByPatientId(int clientId)
        //{
        //    return tblAppointments.Where(x => x.FK_ClientId == clientId).ToList();
        //}
        public List<ClientEL> GetAllClient()
        {
            List<ClientEL> ClientList = tblclients.Where(x => x.IsActive == true).Select(x => new ClientEL()
            {
                AddedDate = x.AddedDate,
                Address = x.Address,
                CaseHistory = x.CaseHistory,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                IsActive = x.IsActive,
                MaritalStatus = x.MaritalStatus,
                Sex = x.Sex,
                Mobile = x.Mobile,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ReferralSource = x.ReferralSource,
                SendEmail = x.SendEmail,
                SendSMS = x.SendSMS

            }).ToList();

            return ClientList;
        }

        public List<ClientEL> GetAllClientByBranchId(int? branchid)
        {
            List<ClientEL> ClientList = tblclients.Where(x => x.IsActive == true).Select(x => new ClientEL()
            {
                AddedDate = x.AddedDate,
                Address = x.Address,
                CaseHistory = x.CaseHistory,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                IsActive = x.IsActive,
                MaritalStatus = x.MaritalStatus,
                Sex = x.Sex,
                Mobile = x.Mobile,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ReferralSource = x.ReferralSource,
                SendEmail = x.SendEmail,
                SendSMS = x.SendSMS

            }).ToList();

            return ClientList;
        }
        public List<tbldocument> GetAllDocumentsByClientId(int ClientId)
        {
            return tbldocuments.Where(x => x.IsActive == true && x.FK_ClientId == ClientId).ToList();
        }
        //public List<tblDocument> GetAllDocumentsByClientId(int ClientId)
        //{
        //    return tblDocuments.Where(x => x.IsActive == true && x.FK_ClientId == ClientId).ToList();
        //}
        public int InsertUpdateClientDocument(tbldocument objDoc)
        {

            try
            {
                if (objDoc.DocumentId == 0)
                {
                    tbldocuments.Add(objDoc);
                    SaveChanges();
                }
                else
                {
                    var data = tbldocuments.Where(p => p.DocumentId == objDoc.DocumentId).FirstOrDefault();
                    if (data != null)
                    {
                        Entry(data).CurrentValues.SetValues(objDoc);
                        SaveChanges();
                    }
                    //Entry(objDoc).State = EntityState.Modified;
                    //SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objDoc.DocumentId;
        }
        public List<ClientEL> GetAllClientByClientName(string clientName)
        {
            List<ClientEL> ClientList = tblclients.Where(x => x.IsActive == true && x.ClientName.Contains(clientName)).Select(x => new ClientEL()
            {
                AddedDate = x.AddedDate,
                Address = x.Address,
                CaseHistory = x.CaseHistory,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                IsActive = x.IsActive,
                MaritalStatus = x.MaritalStatus,
                Mobile = x.Mobile,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ReferralSource = x.ReferralSource,
                SendEmail = x.SendEmail,
                SendSMS = x.SendSMS
            }).ToList();

            return ClientList;
        }

        // .........................Code added by Sandip on 17032016.........................

        public List<ClientEL> GetAllClientByClientName(string clientName, int? branchid)
        {
            List<ClientEL> ClientList = tblclients.Where(x => x.IsActive == true && x.ClientName.Contains(clientName)).Select(x => new ClientEL()
            {
                AddedDate = x.AddedDate,
                Address = x.Address,
                CaseHistory = x.CaseHistory,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                IsActive = x.IsActive,
                MaritalStatus = x.MaritalStatus,
                Mobile = x.Mobile,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ReferralSource = x.ReferralSource,
                SendEmail = x.SendEmail,
                SendSMS = x.SendSMS
            }).ToList();

            return ClientList;
        }








        public int GetClientbyClientNamebyMobileno(string clientName, string mobileno, int? branchid)
        {
            //int cnt = tblclients.Where(x => x.IsActive == true && x.ClientName.Contains(clientName) && x.Mobile.Contains(mobileno)).Count();
            int cnt = tblclients.Where(x => x.IsActive == true && x.Mobile.Contains(mobileno)).Count();
            return cnt;
        }


        //public List<ClientEL> GetAllClientBySearchCriteria(string clientName, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchid)
        //{
        //    List<ClientEL> ClientList = new List<ClientEL>();

        //    if (ServiceType > 1)
        //    {
        //        ClientList = (from p in tblclients
        //                      join ap in tblappointments on p.ClientId equals ap.FK_ClientId
        //                      join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                      where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                            && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                            && (aps.FK_ServiceId == (ServiceType != 1 ? ServiceType : aps.FK_ServiceId)
        //                      ))
        //                      select new ClientEL()
        //                      {
        //                          AddedDate = p.AddedDate,
        //                          Address = p.Address,
        //                          CaseHistory = p.CaseHistory,
        //                          DateOfBirth = p.DateOfBirth,
        //                          Email = p.Email,
        //                          IsActive = p.IsActive,
        //                          Sex = p.Sex,
        //                          MaritalStatus = p.MaritalStatus,
        //                          Mobile = p.Mobile,
        //                          ClientId = p.ClientId,
        //                          ClientName = p.ClientName,
        //                          ReferralSource = p.ReferralSource,
        //                          SendEmail = p.SendEmail,
        //                          SendSMS = p.SendSMS
        //                      }).ToList();
        //    }
        //    else
        //    {
        //        ClientList = (from p in tblclients
        //                      join ap in tblappointments on p.ClientId equals ap.FK_ClientId
        //                      join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                      where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate))))
        //                      select new ClientEL()
        //                      {
        //                          AddedDate = p.AddedDate,
        //                          Address = p.Address,
        //                          CaseHistory = p.CaseHistory,
        //                          DateOfBirth = p.DateOfBirth,
        //                          Email = p.Email,
        //                          IsActive = p.IsActive,
        //                          Sex = p.Sex,
        //                          MaritalStatus = p.MaritalStatus,
        //                          Mobile = p.Mobile,
        //                          ClientId = p.ClientId,
        //                          ClientName = p.ClientName,
        //                          ReferralSource = p.ReferralSource,
        //                          SendEmail = p.SendEmail,
        //                          SendSMS = p.SendSMS
        //                      }).ToList();
        //    }

        //    return ClientList;
        //}
        // .........................Code above added by Sandip on 17032016.........................
        public tblclient GetPatientByClientId(int clientId)
        {
            return tblclients.Where(x => x.ClientId == clientId).FirstOrDefault();
        }

        //public tblclient GetClientByClientIdBranchId(int clientId,int? branchid)
        //{
        //    return tblclients.Where(x => x.ClientId == clientId && x.FK_BranchID == branchid).FirstOrDefault();
        //}

        public List<tblclient> GetClientByBranchId(int branchid)
        {
            return tblclients.Where(x => x.FK_BranchID == branchid && x.IsActive == true).ToList();
        }

        public tblclient GetClientByClientId(int clientId, int? branchid)
        {
            return tblclients.Where(x => x.ClientId == clientId && x.FK_BranchID == branchid).FirstOrDefault();
        }
        public tblclient GetClientByClientIdBranchId(int clientId, int? branchid)
        {
            return tblclients.Where(x => x.ClientId == clientId).FirstOrDefault();
        }
        public int InsertUpdateClientInUSerTable(tbluser objUser)
        {

            try
            {
                if (objUser.UserId == 0)
                {
                    tblusers.Add(objUser);
                    SaveChanges();
                }
                else
                {
                    var context = new SpaPracticeEntities();
                    var obj = context.tblusers.Where(p => p.UserId == objUser.UserId).FirstOrDefault();
                    if (obj != null)
                    {
                        context.Entry(obj).CurrentValues.SetValues(objUser);
                        context.SaveChanges();
                    }
                    //  Entry(objUser).State = EntityState.Modified;
                    //  SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objUser.UserId;
        }
        public List<ClientEL> GetAllPractice()
        {
            List<ClientEL> ClientList = tblclients.Where(x => x.IsActive == true).Select(x => new ClientEL()
            {
                AddedDate = x.AddedDate,
                Address = x.Address,
                CaseHistory = x.CaseHistory,
                DateOfBirth = x.DateOfBirth,
                Age = Convert.ToString(DateTime.Today.Year - Convert.ToDateTime(x.DateOfBirth).Year),
                Email = x.Email,
                IsActive = x.IsActive,
                MaritalStatus = x.MaritalStatus,
                Sex = x.Sex,
                Mobile = x.Mobile,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ReferralSource = x.ReferralSource,
                SendEmail = x.SendEmail,
                SendSMS = x.SendSMS

            }).ToList();

            return ClientList;
        }


        public bool DeleteClienttById(int Clientid, int branchID)
        {
            try
            {

                tblclient itemToRemove = tblclients.SingleOrDefault(x => x.ClientId == Clientid && x.FK_BranchID == branchID);
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



        #region GetMethod of Client Start
        //public List<ClientEL> GetClientListBySearchCriteria(string clientName, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchid, int byselection)
        //{
        //    List<ClientEL> ClientList = new List<ClientEL>();
        //    if (byselection == 0)
        //    {
        //        if (clientName == "")
        //        {
        //            ClientList = (from c in tblclients
        //                          join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                          where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                 && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                 && c.FK_BranchID == branchid && ap.GrossAmount>0 && ap.ByPackage !=null
        //                          select new ClientEL()
        //                          {
        //                              ClientId = c.ClientId,
        //                              ClientName = c.ClientName,
        //                              Address = c.Address,
        //                              DateOfBirth = c.DateOfBirth,
        //                              Email = c.Email,
        //                              Mobile = c.Mobile,
        //                              Amount = ap.GrossAmount
        //                          }).ToList();
        //            return ClientList;
        //        }
        //        else
        //        {
        //            ClientList = (from c in tblclients
        //                          join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                          where c.ClientName == clientName && (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                 && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                 && c.FK_BranchID == branchid && ap.GrossAmount > 0 && ap.ByPackage != null
        //                          select new ClientEL()
        //                          {
        //                              ClientId = c.ClientId,
        //                              ClientName = c.ClientName,
        //                              Address = c.Address,
        //                              DateOfBirth = c.DateOfBirth,
        //                              Email = c.Email,
        //                              Mobile = c.Mobile,
        //                              Amount = ap.GrossAmount
        //                          }).ToList();
        //            return ClientList;
        //        }
        //    }


        //    //.....................byserivce=1.....................serivcebase

        //    if (byselection == 1)
        //    {
        //        if (ServiceType > 0)
        //        {
        //            if (clientName == "")
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
        //                              join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                              where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == true && ap.GrossAmount > 0 && pkg.Id == ServiceType
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //            else
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
        //                              join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                              where c.ClientName == clientName && (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == true && ap.GrossAmount > 0 && pkg.Id == ServiceType
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //        }
        //        else
        //        {
        //            if (clientName == "")
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
        //                              join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                              where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == true  && ap.GrossAmount > 0 
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //            else
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join appkg in tblappointmentpackageppings on ap.AppointmentId equals appkg.FK_AppointmentId
        //                              join pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
        //                              where c.ClientName == clientName && (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == true && ap.GrossAmount > 0  
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //        }
        //    }


        //    //.....................bypackage=2.....................Servicebase

        //    if (byselection == 2)
        //    {
        //        if (ServiceType > 0)
        //        {
        //            if (clientName == "")
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
        //                              join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
        //                              where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == false && ap.GrossAmount > 0 && ser.ServiceId == ServiceType
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ser.Amount
        //                                  //Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //            else
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
        //                              join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
        //                              where c.ClientName == clientName && (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == false && ap.GrossAmount > 0 && ser.ServiceId == ServiceType
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ser.Amount
        //                                  //Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //        }
        //        else
        //        {
        //            if (clientName == "")
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
        //                              join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
        //                              where (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == false && ap.GrossAmount > 0 
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount = ser.Amount
        //                                  //Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //            else
        //            {
        //                ClientList = (from c in tblclients
        //                              join ap in tblappointments on c.ClientId equals ap.FK_ClientId
        //                              join apser in tblappointmentservicemappings on ap.AppointmentId equals apser.FK_AppointmentId
        //                              join ser in tblservices on apser.FK_ServiceId equals ser.ServiceId
        //                              where c.ClientName == clientName && (EntityFunctions.TruncateTime(ap.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && (EntityFunctions.TruncateTime(ap.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(ap.AppointmentDate)))
        //                                     && c.FK_BranchID == branchid && ap.ByPackage == false && ap.GrossAmount > 0  
        //                              select new ClientEL()
        //                              {
        //                                  ClientId = c.ClientId,
        //                                  ClientName = c.ClientName,
        //                                  Address = c.Address,
        //                                  DateOfBirth = c.DateOfBirth,
        //                                  Email = c.Email,
        //                                  Mobile = c.Mobile,
        //                                  Amount =ser.Amount
        //                                  //Amount = ap.GrossAmount
        //                              }).ToList();
        //                return ClientList;
        //            }
        //        }
        //    }









































        //    if (ServiceType > 1)
        //    {
        //        ClientList = (from p in tblclients
        //                      join ap in tblappointments on p.ClientId equals ap.FK_ClientId
        //                      join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                      where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                            && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                            && (aps.FK_ServiceId == (ServiceType != 1 ? ServiceType : aps.FK_ServiceId)
        //                      ))
        //                      select new ClientEL()
        //                      {
        //                          AddedDate = p.AddedDate,
        //                          Address = p.Address,
        //                          CaseHistory = p.CaseHistory,
        //                          DateOfBirth = p.DateOfBirth,
        //                          Email = p.Email,
        //                          IsActive = p.IsActive,
        //                          Sex = p.Sex,
        //                          MaritalStatus = p.MaritalStatus,
        //                          Mobile = p.Mobile,
        //                          ClientId = p.ClientId,
        //                          ClientName = p.ClientName,
        //                          ReferralSource = p.ReferralSource,
        //                          SendEmail = p.SendEmail,
        //                          SendSMS = p.SendSMS
        //                      }).ToList();
        //    }
        //    else
        //    {
        //        ClientList = (from p in tblclients
        //                      join ap in tblappointments on p.ClientId equals ap.FK_ClientId
        //                      join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
        //                      where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
        //                             && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate))))
        //                      select new ClientEL()
        //                      {
        //                          AddedDate = p.AddedDate,
        //                          Address = p.Address,
        //                          CaseHistory = p.CaseHistory,
        //                          DateOfBirth = p.DateOfBirth,
        //                          Email = p.Email,
        //                          IsActive = p.IsActive,
        //                          Sex = p.Sex,
        //                          MaritalStatus = p.MaritalStatus,
        //                          Mobile = p.Mobile,
        //                          ClientId = p.ClientId,
        //                          ClientName = p.ClientName,
        //                          ReferralSource = p.ReferralSource,
        //                          SendEmail = p.SendEmail,
        //                          SendSMS = p.SendSMS
        //                      }).ToList();
        //    }

        //    return ClientList;
        //}


        #endregion  GetMethod of Client End






        // .........................Code above added by Sandip on 17032016.........................
        public List<ClientEL> GetAllPatientBySearchCriteria(string clientName, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchid)
        {
            List<ClientEL> ClientList = new List<ClientEL>();
            //List<PatientEL> PatientList = tblPatients.Where(x => x.IsActive == true && x.PatientName==patientName).Select(x => new PatientEL()
            //FromDate.Val
            //List<PatientEL> PatientList = tblPatients.Where(x => x.IsActive == true
            //    && x.PatientName == (patientName != null ? patientName : x.PatientName)
            //    && x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblService.ServiceId == ( ServiceType.Value != 1 ? ServiceType.Value : x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblService.ServiceId)
            //    && ((x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate >= (FromDate != null ? FromDate : x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate)
            //    && x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate <= (Todate != null ? Todate : x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate))))
            //    .Select(x => new PatientEL()

            //&& ((x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate >= (FromDate != null ? FromDate : x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate)
            //&& x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate <= (Todate != null ? Todate : x.tblAppointments.FirstOrDefault().tblAppointmentServiceMappings.FirstOrDefault().tblAppointment.AppointmentDate)))

            if (ServiceType > 1)
            {
                ClientList = (from p in tblclients
                              join ap in tblappointments on p.ClientId equals ap.FK_ClientId
                              join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                              where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
                                     && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
                                    && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate)))
                                    && (aps.FK_ServiceId == (ServiceType != 1 ? ServiceType : aps.FK_ServiceId)
                              ))
                              select new ClientEL()
                              {
                                  AddedDate = p.AddedDate,
                                  Address = p.Address,
                                  CaseHistory = p.CaseHistory,
                                  DateOfBirth = p.DateOfBirth,
                                  Email = p.Email,
                                  IsActive = p.IsActive,
                                  Sex = p.Sex,
                                  MaritalStatus = p.MaritalStatus,
                                  Mobile = p.Mobile,
                                  ClientId = p.ClientId,
                                  ClientName = p.ClientName,
                                  ReferralSource = p.ReferralSource,
                                  SendEmail = p.SendEmail,
                                  SendSMS = p.SendSMS
                              }).ToList();
            }
            else
            {
                ClientList = (from p in tblclients
                              join ap in tblappointments on p.ClientId equals ap.FK_ClientId
                              join aps in tblappointmentservicemappings on ap.AppointmentId equals aps.FK_AppointmentId
                              where (p.ClientName == (clientName != "" ? clientName : p.ClientName)
                                     && (EntityFunctions.TruncateTime(p.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(p.AddedDate)))
                                     && (EntityFunctions.TruncateTime(p.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(p.AddedDate))))
                              select new ClientEL()
                              {
                                  AddedDate = p.AddedDate,
                                  Address = p.Address,
                                  CaseHistory = p.CaseHistory,
                                  DateOfBirth = p.DateOfBirth,
                                  Email = p.Email,
                                  IsActive = p.IsActive,
                                  Sex = p.Sex,
                                  MaritalStatus = p.MaritalStatus,
                                  Mobile = p.Mobile,
                                  ClientId = p.ClientId,
                                  ClientName = p.ClientName,
                                  ReferralSource = p.ReferralSource,
                                  SendEmail = p.SendEmail,
                                  SendSMS = p.SendSMS
                              }).ToList();
            }

            return ClientList;
        }

        // .........................Code added by Sandip on 17032016.........................








        //...................................Code Added By Sam on 27052016.................................. 
        #region For Appointment List start
        public List<ClientEL> GetClientListBySearchCriteriaNewForTest(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {

            List<ClientEL> ClientListbypackage = new List<ClientEL>();
            List<ClientEL> ClientListbyservice = new List<ClientEL>();
            List<ClientEL> ClientListbyservicebypackage = new List<ClientEL>();
            int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            int apsercnt;
            if (byselection == 0)
            {
                #region
                ClientListbypackage = (from c in tblclients
                                       where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                           && (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && c.FK_BranchID == branchID && c.IsActive == true
                                       select new ClientEL()
                                       {
                                           ClientId = c.ClientId,
                                           ClientName = c.ClientName,
                                           Address = c.Address,
                                           Sex = c.Sex,
                                           DateOfBirth = c.DateOfBirth,
                                           Email = c.Email,
                                           Mobile = c.Mobile,
                                       }).ToList();
                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
                #endregion
            }
            else if (byselection == 1)
            {


                var package = (from app in tblappointments where app.FK_BranchID == branchID && app.ByPackage == true select app);
                if (package != null && package.Count() > 0)
                {
                    foreach (var pkg in package)
                    {
                        var clientlist = (from c in tblclients
                                          where c.ClientId == pkg.FK_ClientId &&
                                              (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                              && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                              && c.FK_BranchID == branchID
                                          select new ClientEL()
                                              {
                                                  ClientId = c.ClientId,
                                                  ClientName = c.ClientName,
                                                  Address = c.Address,
                                                  Sex = c.Sex,
                                                  DateOfBirth = c.DateOfBirth,
                                                  Email = c.Email,
                                                  Mobile = c.Mobile,
                                                  Amount = pkg.GrossAmount
                                              }).ToList();
                        if (clientlist != null && clientlist.Count > 0)
                        {
                            foreach (var client in clientlist)
                                ClientListbypackage.Add(client);
                        }
                    }
                    return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
                }
            }
            else if (byselection == 2)
            {

                #region BYPackage
                if (ServiceType > 0)
                {
                    //........................bypackage........................
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                         (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                         && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                          && pkg.Id == ServiceType
                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount
                                           }).ToList();
                }
                else
                {
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                           (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0

                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount
                                           }).ToList();
                }
                return ClientListbypackage;
                #endregion BYPackage

            }


            return null;

        }
        #endregion For Appointment List End
        //...................................Code Added Above By Sam on 27052016..................................



        //...................................Code Added By Sam on 30052016........................................ 

        #region For Client List start

        public List<ClientEL> GetClientListBySearchCriteriaNewForGrid(string clientname, string mobile, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {

            List<ClientEL> ClientListbypackage = new List<ClientEL>();
            List<ClientEL> ClientListbyservice = new List<ClientEL>();
            List<ClientEL> ClientListbyservicebypackage = new List<ClientEL>();
            int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            int apsercnt;
            if (byselection == 0)
            {
                #region
                //if (clientname != null)
                //{

                //}
                //else
                //{
                //........................bypackage........................
                ClientListbypackage = (from c in tblclients
                                       //join app in tblappointments
                                       //on c.ClientId equals app.FK_ClientId
                                       //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                       //join
                                       //    pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                       where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                       && c.Mobile == (mobile != null ? mobile : c.Mobile)
                                           && (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && c.FK_BranchID == branchID && c.IsActive == true
                                       //&& app.ByPackage == true && app.GrossAmount > 0
                                       select new ClientEL()
                                       {
                                           ClientId = c.ClientId,
                                           ClientName = c.ClientName,
                                           Address = c.Address,
                                           Sex = c.Sex,
                                           DateOfBirth = c.DateOfBirth,
                                           Email = c.Email,
                                           Mobile = c.Mobile,
                                           //Amount = app.GrossAmount
                                       }).ToList();

                //........................byservice........................
                //servicecount = (from app in tblappointments
                //                join c in tblclients on app.FK_ClientId equals c.ClientId
                //                where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                select new AppointmentEL()

                //                {
                //                    AppointmentId = app.AppointmentId,
                //                    Discount = app.Discount
                //                }).ToList();
                //if (servicecount != null)
                //{
                //    foreach (AppointmentEL ap in servicecount)
                //    {
                //        cnt = (from app in tblappointments
                //               join c in tblclients on app.FK_ClientId equals c.ClientId
                //               join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //               where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //               select new AppointmentEL()).Count();
                //        if (cnt > 0)
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //                                        select new ClientEL()
                //                                        {

                //                      ClientId = c.ClientId,
                //                      ClientName = c.ClientName,
                //                      Address = c.Address,
                //                      Sex = c.Sex,
                //                      DateOfBirth = c.DateOfBirth,
                //                      Email = c.Email,
                //                      Mobile = c.Mobile,
                //                      Amount = app.GrossAmount
                //                  }).ToList();
                //        }
                //        else
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                                   select new ClientEL()
                //                                        {
                //                                            ClientId = c.ClientId,
                //                                            ClientName = c.ClientName,
                //                                            Address = c.Address,
                //                                            Sex = c.Sex,
                //                                            DateOfBirth = c.DateOfBirth,
                //                                            Email = c.Email,
                //                                            Mobile = c.Mobile,
                //                                            Amount = app.GrossAmount
                //                                        }).ToList();
                //        }

                //        foreach (var item in ClientListbyservice)
                //        {
                //            ClientListbypackage.Add(item);
                //        }
                //    }

                //}
                //else
                //{
                //    return ClientListbypackage;
                //}

                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();

                #endregion
                //}
            }
            else if (byselection == 1)
            {
                #region Byservice Section
                #region Service Count
                servicecount = (from app in tblappointments
                                join c in tblclients on app.FK_ClientId equals c.ClientId
                                where
                                 (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                 && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
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
                            cnt = (from app in tblappointments
                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();

                            #endregion counting section for service

                            #region If Service Counting number is more than 1
                            if (cnt > 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0
                                                       && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is more than 1

                            #region If Service Counting number is 1
                            else if (cnt == 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is 1

                            if (ClientListbyservice.Count > 0)
                            {
                                foreach (var item in ClientListbyservice)
                                {
                                    ClientListbypackage.Add(item);
                                }
                            }
                        }
                        return ClientListbypackage;
                    }

                    else
                    {
                        return ClientListbyservice;
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
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();
                            if (cnt > 0)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }
                            else
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                      (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }

                            foreach (var item in ClientListbyservice)
                            {
                                ClientListbypackage.Add(item);
                            }
                        }
                        return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
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
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                         (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                         && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                          && pkg.Id == ServiceType
                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount
                                           }).ToList();
                }
                else
                {
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                           (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0

                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount
                                           }).ToList();
                }
                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
                #endregion BYPackage

            }


            return null;

        }

        public List<ClientEL> GetClientListBySearchCriteria(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection)
        {

            List<ClientEL> ClientListbypackage = new List<ClientEL>();
            List<ClientEL> ClientListbyservice = new List<ClientEL>();
            List<ClientEL> ClientListbyservicebypackage = new List<ClientEL>();
            int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            int apsercnt;
            if (byselection == 0)
            {
                #region
                //if (clientname != null)
                //{

                //}
                //else
                //{
                //........................bypackage........................
                ClientListbypackage = (from c in tblclients
                                       //join app in tblappointments
                                       //on c.ClientId equals app.FK_ClientId
                                       //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                       //join
                                       //    pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                       where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                           && (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && c.FK_BranchID == branchID && c.IsActive == true
                                       //&& app.ByPackage == true && app.GrossAmount > 0
                                       select new ClientEL()
                                       {
                                           ClientId = c.ClientId,
                                           ClientName = c.ClientName,
                                           Address = c.Address,
                                           Sex = c.Sex,
                                           DateOfBirth = c.DateOfBirth,
                                           Email = c.Email,
                                           Mobile = c.Mobile,
                                           Discount = c.tblappointments.FirstOrDefault().Discount,
                                           Due = c.tblappointments.FirstOrDefault().DueAmount,
                                           ModeOfPayment = c.tblappointments.FirstOrDefault().PaymentMode,
                                           Amount = c.tblappointments.FirstOrDefault().GrossAmount,
                                           AppId = c.tblappointments.FirstOrDefault().AppointmentId,
                                       }).ToList();

                //........................byservice........................
                //servicecount = (from app in tblappointments
                //                join c in tblclients on app.FK_ClientId equals c.ClientId
                //                where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                select new AppointmentEL()

                //                {
                //                    AppointmentId = app.AppointmentId,
                //                    Discount = app.Discount
                //                }).ToList();
                //if (servicecount != null)
                //{
                //    foreach (AppointmentEL ap in servicecount)
                //    {
                //        cnt = (from app in tblappointments
                //               join c in tblclients on app.FK_ClientId equals c.ClientId
                //               join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //               where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //               select new AppointmentEL()).Count();
                //        if (cnt > 0)
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //                                        select new ClientEL()
                //                                        {

                //                      ClientId = c.ClientId,
                //                      ClientName = c.ClientName,
                //                      Address = c.Address,
                //                      Sex = c.Sex,
                //                      DateOfBirth = c.DateOfBirth,
                //                      Email = c.Email,
                //                      Mobile = c.Mobile,
                //                      Amount = app.GrossAmount
                //                  }).ToList();
                //        }
                //        else
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                                   select new ClientEL()
                //                                        {
                //                                            ClientId = c.ClientId,
                //                                            ClientName = c.ClientName,
                //                                            Address = c.Address,
                //                                            Sex = c.Sex,
                //                                            DateOfBirth = c.DateOfBirth,
                //                                            Email = c.Email,
                //                                            Mobile = c.Mobile,
                //                                            Amount = app.GrossAmount
                //                                        }).ToList();
                //        }

                //        foreach (var item in ClientListbyservice)
                //        {
                //            ClientListbypackage.Add(item);
                //        }
                //    }

                //}
                //else
                //{
                //    return ClientListbypackage;
                //}

                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();

                #endregion
                //}
            }
            else if (byselection == 1)
            {
                #region Byservice Section
                #region Service Count
                servicecount = (from app in tblappointments
                                join c in tblclients on app.FK_ClientId equals c.ClientId
                                where
                                 (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                 && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
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
                            cnt = (from app in tblappointments
                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();

                            #endregion counting section for service

                            #region If Service Counting number is more than 1
                            if (cnt > 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0
                                                       && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is more than 1

                            #region If Service Counting number is 1
                            else if (cnt == 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is 1

                            if (ClientListbyservice.Count > 0)
                            {
                                foreach (var item in ClientListbyservice)
                                {
                                    ClientListbypackage.Add(item);
                                }
                            }
                        }
                        return ClientListbypackage;
                    }

                    else
                    {
                        return ClientListbyservice;
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
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();
                            if (cnt > 0)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Discount = app.Discount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                       }).ToList();
                            }
                            else
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                      (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Discount = app.Discount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                       }).ToList();
                            }

                            foreach (var item in ClientListbyservice)
                            {
                                ClientListbypackage.Add(item);
                            }
                        }
                        return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
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
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                         (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                         && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0
                                          && pkg.Id == ServiceType
                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount,
                                               Discount = app.Discount,
                                               Due = app.DueAmount,
                                               ModeOfPayment = app.PaymentMode,
                                               AppId = app.AppointmentId,
                                           }).ToList();
                }
                else
                {
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                           (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0

                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount,
                                               Discount = app.Discount,
                                               Due = app.DueAmount,
                                               ModeOfPayment = app.PaymentMode,
                                               AppId = app.AppointmentId,
                                           }).ToList();
                }
                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
                #endregion BYPackage

            }


            return null;

        }
        #endregion For Appointment List End

        //...................................Code Added Above By Sam on 30052016..................................

        public ClientEL GetClientIdByDocId(int? docId)
        {
            var ClientDtls = tbldocuments.Where(x => x.DocumentId == docId).Select(x => new ClientEL { ClientId = x.FK_ClientId, ClientName = x.tblclient.ClientName }).FirstOrDefault();
            return ClientDtls;
        }
        public List<tbldocument> GetAllDocumentsByDocId(int? docId)
        {
            return tbldocuments.Where(x => x.IsActive == true && x.DocumentId == docId).ToList();
        }
        public bool DeleteDocumentById(int? DocId)
        {
            bool IsInserted = false;
            var DeleteDoc = tbldocuments.Where(x => x.DocumentId == DocId).FirstOrDefault();
            DeleteDoc.DocumentId = Convert.ToInt32(DocId);
            tbldocuments.Remove(DeleteDoc);
            int ReturnValue = SaveChanges();
            if (ReturnValue == 1) { return IsInserted = true; } else { return IsInserted = false; }
        }

        public IEnumerable<AppointmentEL> GetClientAppointmentListByClientId(int ClientId, int? branchID)
        {
            AppointmentDAL appointmentdal = new AppointmentDAL();
            var Query = tblappointments.Where(x => x.FK_ClientId == ClientId && x.FK_BranchID == branchID).Select(x => new AppointmentEL
            {
                AppointmentId = x.AppointmentId,
                AppointmentDate = (DateTime)x.AppointmentDate,
                ClientName = x.tblclient.ClientName,
                Discount = x.Discount,
                TotalAmount = x.Total,
                GrossAmount = x.GrossAmount,
                DueAmount = x.DueAmount,
                TotalTax = x.TotalTax,
                paymentmode = x.PaymentMode,
                NetTotal = x.NetTotal,
                paymenttype = x.PaymentType,
                advanceamount = x.AdvanceAmount,
                TherapistName = x.tbltherapist.Name,
                recievedamount = x.ReceivedAmount,
                balanceamount = x.BalanceAmount,
            }).ToList();
            foreach (var item in Query)
            {
                //if (item.ServiceId > 0)
                //{
                //    var Result = tbl_service.Where(x => x.ServiceID == item.ServiceId).Select(x => x.ServiceName).FirstOrDefault();
                //    item.Service = Result;
                //}
                //else
                //{
                //var Result = tbl_mappackageservice.Where(x => x.FK_PackageId == item.PackageId).Select(x => x.tbl_service.ServiceName).ToList();
                //foreach (var s in Result)
                //{                        
                //  item.Service = appointmentdal.FetchServiceById((int)item.PackageId, item.ServiceType, (int)branchID);
                //}
                //}
                // item.Coupon = tbl_couponcode.Where(x => x.coupon_id == item.FK_CouponId).Select(x => x.coupon_discount_amt).FirstOrDefault();
                // item.TotalAmount = GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount) == null ? 0 : GetTotalAmount(branchID, item.RegCharge, item.ServiceCharge, item.TaxAmount);
            }
            return Query.ToList();
        }
        public List<ClientEL> GetClientListBySearchCriteriaNew(string clientname, int? ServiceType, DateTime? FromDate, DateTime? Todate, int? branchID, int byselection, string paymentmode, int? billno)
        {

            List<ClientEL> ClientListbypackage = new List<ClientEL>();
            List<ClientEL> ClientListbyservice = new List<ClientEL>();
            List<ClientEL> ClientListbyservicebypackage = new List<ClientEL>();
            int cnt;
            List<AppointmentEL> servicecount = new List<AppointmentEL>();
            int apsercnt;
            if (byselection == 0)
            {
                #region
                //if (clientname != null)
                //{

                //}
                //else
                //{
                //........................bypackage........................
                ClientListbypackage = (from c in tblclients
                                       //join app in tblappointments
                                       //on c.ClientId equals app.FK_ClientId
                                       //join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                       //join
                                       //    pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                       where c.ClientName == (clientname != null ? clientname : c.ClientName)
                                           && (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && c.FK_BranchID == branchID && c.IsActive == true && c.tblappointments.FirstOrDefault().AppointmentId == (billno != 0 ? billno : c.tblappointments.FirstOrDefault().AppointmentId)
                                           && c.tblappointments.FirstOrDefault().PaymentMode == (paymentmode != null ? paymentmode : c.tblappointments.FirstOrDefault().PaymentMode)
                                       //&& app.ByPackage == true && app.GrossAmount > 0
                                       select new ClientEL()
                                       {
                                           ClientId = c.ClientId,
                                           ClientName = c.ClientName,
                                           Address = c.Address,
                                           Sex = c.Sex,
                                           DateOfBirth = c.DateOfBirth,
                                           Email = c.Email,
                                           Mobile = c.Mobile,
                                           Discount = c.tblappointments.FirstOrDefault().Discount,
                                           Due = c.tblappointments.FirstOrDefault().DueAmount,
                                           ModeOfPayment = c.tblappointments.FirstOrDefault().PaymentMode,
                                           Amount = c.tblappointments.FirstOrDefault().GrossAmount,
                                           AppId = c.tblappointments.FirstOrDefault().AppointmentId,
                                           ByPackage=c.tblappointments.FirstOrDefault().ByPackage,
                                       }).ToList();

                //........................byservice........................
                //servicecount = (from app in tblappointments
                //                join c in tblclients on app.FK_ClientId equals c.ClientId
                //                where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                    && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                select new AppointmentEL()

                //                {
                //                    AppointmentId = app.AppointmentId,
                //                    Discount = app.Discount
                //                }).ToList();
                //if (servicecount != null)
                //{
                //    foreach (AppointmentEL ap in servicecount)
                //    {
                //        cnt = (from app in tblappointments
                //               join c in tblclients on app.FK_ClientId equals c.ClientId
                //               join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //               join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //               where (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //               select new AppointmentEL()).Count();
                //        if (cnt > 0)
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                //                                        select new ClientEL()
                //                                        {

                //                      ClientId = c.ClientId,
                //                      ClientName = c.ClientName,
                //                      Address = c.Address,
                //                      Sex = c.Sex,
                //                      DateOfBirth = c.DateOfBirth,
                //                      Email = c.Email,
                //                      Mobile = c.Mobile,
                //                      Amount = app.GrossAmount
                //                  }).ToList();
                //        }
                //        else
                //        {
                //            ClientListbyservice = (from app in tblappointments
                //                                        join c in tblclients on app.FK_ClientId equals c.ClientId
                //                                        join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                //                                        join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId

                //                                        where c.ClientName == (clientname != null ? clientname : c.ClientName) && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate)))
                //                                            && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                //                                   select new ClientEL()
                //                                        {
                //                                            ClientId = c.ClientId,
                //                                            ClientName = c.ClientName,
                //                                            Address = c.Address,
                //                                            Sex = c.Sex,
                //                                            DateOfBirth = c.DateOfBirth,
                //                                            Email = c.Email,
                //                                            Mobile = c.Mobile,
                //                                            Amount = app.GrossAmount
                //                                        }).ToList();
                //        }

                //        foreach (var item in ClientListbyservice)
                //        {
                //            ClientListbypackage.Add(item);
                //        }
                //    }

                //}
                //else
                //{
                //    return ClientListbypackage;
                //}

                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();

                #endregion
                //}
            }
            else if (byselection == 1)
            {
                #region Byservice Section
                #region Service Count
                servicecount = (from app in tblappointments
                                join c in tblclients on app.FK_ClientId equals c.ClientId
                                where
                                 (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                 && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
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
                            cnt = (from app in tblappointments
                                   join c in tblclients on app.FK_ClientId equals c.ClientId
                                   join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                   join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0 && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();

                            #endregion counting section for service

                            #region If Service Counting number is more than 1
                            if (cnt > 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0 && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                                       && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                           ByPackage=app.ByPackage
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is more than 1

                            #region If Service Counting number is 1
                            else if (cnt == 1)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) && ser.ServiceId == ServiceType && (EntityFunctions.TruncateTime(app.AppointmentDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && (EntityFunctions.TruncateTime(app.AppointmentDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(app.AppointmentDate))) && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                                       && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                           ByPackage = app.ByPackage
                                                       }).ToList();
                            }
                            #endregion If Service Counting number is 1

                            if (ClientListbyservice.Count > 0)
                            {
                                foreach (var item in ClientListbyservice)
                                {
                                    ClientListbypackage.Add(item);
                                }
                            }
                        }
                        return ClientListbypackage;
                    }

                    else
                    {
                        return ClientListbyservice;
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
                                   where (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                   && app.FK_BranchID == branchID && app.ByPackage == false && app.GrossAmount > 0
                                   && app.AppointmentId == ap.AppointmentId
                                   select new AppointmentEL()).Count();
                            if (cnt > 0)
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                       (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                                       && app.GrossAmount > 0 && app.AppointmentId == ap.AppointmentId
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Discount = app.Discount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                           ByPackage = app.ByPackage
                                                       }).ToList();
                            }
                            else
                            {
                                ClientListbyservice = (from app in tblappointments
                                                       join c in tblclients on app.FK_ClientId equals c.ClientId
                                                       join appser in tblappointmentservicemappings on app.AppointmentId equals appser.FK_AppointmentId
                                                       join ser in tblservices on appser.FK_ServiceId equals ser.ServiceId
                                                       where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                                      (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                                       && app.FK_BranchID == branchID && app.ByPackage == false
                                                       && app.GrossAmount > 0 && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                                       select new ClientEL()
                                                       {
                                                           ClientId = c.ClientId,
                                                           ClientName = c.ClientName,
                                                           Address = c.Address,
                                                           Sex = c.Sex,
                                                           DateOfBirth = c.DateOfBirth,
                                                           Email = c.Email,
                                                           Mobile = c.Mobile,
                                                           Amount = app.GrossAmount,
                                                           Discount = app.Discount,
                                                           Due = app.DueAmount,
                                                           ModeOfPayment = app.PaymentMode,
                                                           AppId = app.AppointmentId,
                                                           ByPackage = app.ByPackage
                                                       }).ToList();
                            }

                            foreach (var item in ClientListbyservice)
                            {
                                ClientListbypackage.Add(item);
                            }
                        }
                        return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
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
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                         (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                         && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0 && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)
                                          && pkg.Id == ServiceType
                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount,
                                               Discount = app.Discount,
                                               Due = app.DueAmount,
                                               ModeOfPayment = app.PaymentMode,
                                               AppId = app.AppointmentId,
                                               ByPackage = app.ByPackage
                                           }).ToList();
                }
                else
                {
                    ClientListbypackage = (from app in tblappointments
                                           join c in tblclients on app.FK_ClientId equals c.ClientId
                                           join appkg in tblappointmentpackageppings on app.AppointmentId equals appkg.FK_AppointmentId
                                           join
                                               pkg in tblpackages on appkg.FK_PackageId equals pkg.Id
                                           where c.ClientName == (clientname != null ? clientname : c.ClientName) &&
                                           (EntityFunctions.TruncateTime(c.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                           && (EntityFunctions.TruncateTime(c.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(c.AddedDate)))
                                          && app.FK_BranchID == branchID && app.ByPackage == true && app.GrossAmount > 0 && app.AppointmentId == (billno != 0 ? billno : app.AppointmentId)
                                   && app.PaymentMode == (paymentmode != null ? paymentmode : app.PaymentMode)

                                           select new ClientEL()
                                           {
                                               ClientId = c.ClientId,
                                               ClientName = c.ClientName,
                                               Address = c.Address,
                                               Sex = c.Sex,
                                               DateOfBirth = c.DateOfBirth,
                                               Email = c.Email,
                                               Mobile = c.Mobile,
                                               Amount = app.GrossAmount,
                                               Discount = app.Discount,
                                               Due = app.DueAmount,
                                               ModeOfPayment = app.PaymentMode,
                                               AppId = app.AppointmentId,
                                               ByPackage = app.ByPackage
                                           }).ToList();
                }
                return ClientListbypackage.OrderBy(x => x.ClientName).ToList();
                #endregion BYPackage

            }


            return null;

        }
        public List<ClientEL> GetAllClient(int? branchID)
        {
            //var r = (from app in tblappointments
            //         join client in tblclients on app.FK_ClientId equals client.ClientId
            //         where app.FK_BranchID == branchID
            //         select new ClientEL()
            //         {
            //             ClientId = client.ClientId,
            //             ClientName = client.ClientName
            //         }).ToList();
            //return r.OrderBy(x => x.ClientName).ToList();
            //return tblappointments.Where(x => x.FK_BranchID == branchID).Select(x => new ClientEL { ClientId = x.tblclient.ClientId, ClientName = x.tblclient.ClientName }).OrderBy(o=>o.ClientName).ToList();
            return tblclients.Where(x => x.FK_BranchID == branchID).Select(x => new ClientEL { ClientId = x.ClientId, ClientName = x.ClientName }).OrderBy(o => o.ClientName).ToList();
        }
        public List<ClientEL> GetAllAppointmentId(int? branchID)
        {
            //var r = (from app in tblappointments
            //         join client in tblclients on app.FK_ClientId equals client.ClientId
            //         where app.FK_BranchID == branchID
            //         select new ClientEL()
            //         {
            //             AppId = app.AppointmentId,

            //         }).ToList();
            //return r;
            return tblappointments.Where(x => x.FK_BranchID == branchID).Select(x => new ClientEL { AppId = x.AppointmentId }).ToList();
        }
        
        /**Client Report Code Added**/
        List<ClientEL> TypeList = new List<ClientEL>();
        List<ClientEL> ClientList = new List<ClientEL>();
        List<ClientEL> PaymentModeList = new List<ClientEL>();
        List<ClientEL> BillList = new List<ClientEL>();

        public List<ClientEL> GetAllClientReport(int? branchID)
        {
            List<ClientEL> ClientReport = new List<ClientEL>();
            ClientReport = (from pay in tblpaymentdtls
                            where pay.Fk_BranchId == branchID
                           select new ClientEL()
                           {
                               ClientId = pay.tblappointment.FK_ClientId,
                               AppId = pay.Fk_AppointmentId,
                               AddedDate = pay.tblappointment.tblclient.AddedDate,
                               Amount = pay.Total_Amt,
                               ByPackage = pay.tblappointment.ByPackage,
                               ClientName = pay.tblappointment.tblclient.ClientName,
                               Discount = pay.Discount_Amt,
                               Due = pay.Due_Amt,
                               ModeOfPayment = pay.Payment_Mode,
                               PaymentId = pay.PaymentID
                           }).ToList();


            List<ClientEL> result = new List<ClientEL>();

            if (ClientReport != null && ClientReport.Count() > 0)
            {
                List<int> ClientIds = ClientReport.Select(t => t.ClientId.Value).Distinct().ToList();

                foreach (int id in ClientIds)
                {
                    List<int> Appids = ClientReport.Where(t => t.ClientId == id).Select(t => t.AppId.Value).Distinct().ToList();

                    foreach (int AppoId in Appids)
                    {
                        ClientEL tempData = ClientReport.Where(t => t.AppId == AppoId && t.ClientId == id).OrderByDescending(t=>t.PaymentId).FirstOrDefault();

                        result.Add(new ClientEL()
                        {
                            ClientId = tempData.ClientId,
                            AppId = tempData.AppId,
                            AddedDate = tempData.AddedDate,
                            Amount = tempData.Amount,
                            ByPackage = tempData.ByPackage,
                            ClientName = tempData.ClientName,
                            Discount = tempData.Discount,
                            Due = tempData.Due,
                            ModeOfPayment = tempData.ModeOfPayment,
                        });
                    }
                }
            }

            return result;
        }

        public List<ClientEL> GetReportByParam(int? branchId, DateTime? FromDate, DateTime? Todate, List<bool> SelTypeList, List<string> ClientsList
           , List<string> PaymentMode, List<int> billsList)
        {
            List<ClientEL> result = new List<ClientEL>();

            result = (from app in tblappointments
                      join pay in tblpaymentdtls on app.AppointmentId equals pay.Fk_AppointmentId
                      join client in tblclients on app.FK_ClientId equals client.ClientId
                      where app.FK_BranchID == branchId
                      && (EntityFunctions.TruncateTime(client.AddedDate) >= (FromDate != null ? EntityFunctions.TruncateTime(FromDate) : EntityFunctions.TruncateTime(client.AddedDate)))
                      && (EntityFunctions.TruncateTime(client.AddedDate) <= (Todate != null ? EntityFunctions.TruncateTime(Todate) : EntityFunctions.TruncateTime(client.AddedDate)))
                      select new ClientEL()
                      {
                          AppId = app.AppointmentId,
                          AddedDate = client.AddedDate,
                          Amount = pay.Total_Amt,
                          ByPackage = app.ByPackage,
                          ClientId = client.ClientId,
                          ClientName = client.ClientName,
                          Discount = pay.Discount_Amt,
                          Due = pay.Due_Amt,
                          ModeOfPayment = pay.Payment_Mode,
                      }).ToList();

            if (SelTypeList.Count > 0)
            {                
                var type = new List<ClientEL>();
                type.Clear();
                foreach (var stype in SelTypeList)
                {
                    type = result.Where(x => x.ByPackage == stype).ToList();
                }
                if (type.Count > 0)
                {
                    TypeList = type;
                }
                result.Clear();
                result = TypeList;
            }

            if (ClientsList.Count > 0)
            {
                var cname = new List<ClientEL>();
                cname.Clear();
                int id = default(int);
                foreach (var client in ClientsList)
                {
                    id = tblclients.Where(x => x.ClientName == client).Select(x => x.ClientId).FirstOrDefault();
                    var v = result.Where(x => x.ClientId == id).ToList();
                    foreach (var i in v)
                    {
                        cname.Add(i);
                    }
                }
                if (cname.Count > 0)
                {
                    ClientList = cname;
                }
                result.Clear();
                result = ClientList;
            }

            if (PaymentMode.Count > 0)
            {
                var pmode = new List<ClientEL>();
                pmode.Clear();
                foreach (var mode in PaymentMode)
                {
                    var m = result.Where(x => x.ModeOfPayment == mode.ToUpper()).ToList();
                    foreach (var pm in m)
                    {
                        pmode.Add(pm);
                    }
                }
                if (pmode.Count > 0)
                {
                    PaymentModeList = pmode;
                }
                result.Clear();
                result = PaymentModeList;
            }

            if (billsList.Count > 0)
            {
                var bill = new List<ClientEL>();
                bill.Clear();
                foreach (var b in billsList)
                {
                    var p = result.Where(x => x.AppId == b).ToList();
                    foreach (var bb in p)
                    {
                        bill.Add(bb);
                    }
                }
                if (bill.Count > 0)
                {
                    BillList = bill;
                }
                result.Clear();
                result = BillList;
            }

            return result.ToList();
        }

        //public List<ClientEL> SearchByType(int? branchID, string type)
        //{
        //    if (type != "")
        //    {
        //        if (type == "By Service")
        //        {
        //            TypeList = tblappointments.Where(x => x.FK_BranchID == branchID && x.ByPackage == false).Select(x => new ClientEL
        //            {
        //                AppointmentId = x.AppointmentId,
        //                AddedDate = x.tblclient.AddedDate,
        //                Amount = x.GrossAmount,
        //                ByPackage = x.ByPackage,
        //                ClientName = x.tblclient.ClientName,
        //                Discount = x.Discount,
        //                Due = x.DueAmount,
        //                ModeOfPayment = x.PaymentMode,
        //            }).ToList();
        //        }
        //        else
        //        {
        //            TypeList = tblappointments.Where(x => x.FK_BranchID == branchID && x.ByPackage == true).Select(x => new ClientEL
        //            {
        //                AppointmentId = x.AppointmentId,
        //                AddedDate = x.tblclient.AddedDate,
        //                Amount = x.GrossAmount,
        //                ByPackage = x.ByPackage,
        //                ClientName = x.tblclient.ClientName,
        //                Discount = x.Discount,
        //                Due = x.DueAmount,
        //                ModeOfPayment = x.PaymentMode,
        //            }).ToList();
        //        }
        //    }
        //    return TypeList; 
        //}
        //public List<ClientEL> SearchByClient(int? branchID, string clientname)
        //{
        //    if (clientname != "")
        //    {
        //            ClientList = tblappointments.Where(x => x.FK_BranchID == branchID && x.tblclient.ClientName == clientname).Select(x => new ClientEL
        //            {
        //                AppointmentId = x.AppointmentId,
        //                AddedDate = x.tblclient.AddedDate,
        //                Amount = x.GrossAmount,
        //                ByPackage = x.ByPackage,
        //                ClientName = x.tblclient.ClientName,
        //                Discount = x.Discount,
        //                Due = x.DueAmount,
        //                ModeOfPayment = x.PaymentMode,
        //            }).ToList();
        //    }
        //    return ClientList; 
        //}
        //public List<ClientEL> SearchByPaymentMode(int? branchID, string mode)
        //{
        //    if (mode != "")
        //    {
        //        PaymentModeList = tblappointments.Where(x => x.FK_BranchID == branchID && x.PaymentMode == mode).Select(x => new ClientEL
        //        {
        //            AppointmentId = x.AppointmentId,
        //            AddedDate = x.tblclient.AddedDate,
        //            Amount = x.GrossAmount,
        //            ByPackage = x.ByPackage,
        //            ClientName = x.tblclient.ClientName,
        //            Discount = x.Discount,
        //            Due = x.DueAmount,
        //            ModeOfPayment = x.PaymentMode,
        //        }).ToList();
        //    }
        //    return PaymentModeList;
        //}
        //public List<ClientEL> SearchByBills(int? branchID, int? billno)
        //{
        //    if (billno != 0)
        //    {
        //        PaymentModeList = tblappointments.Where(x => x.FK_BranchID == branchID && x.AppointmentId == billno).Select(x => new ClientEL
        //        {
        //            AppointmentId = x.AppointmentId,
        //            AddedDate = x.tblclient.AddedDate,
        //            Amount = x.GrossAmount,
        //            ByPackage = x.ByPackage,
        //            ClientName = x.tblclient.ClientName,
        //            Discount = x.Discount,
        //            Due = x.DueAmount,
        //            ModeOfPayment = x.PaymentMode,
        //        }).ToList();
        //    }
        //    return PaymentModeList;
        //}
        /**Client Report Code Ended**/
    }
}
