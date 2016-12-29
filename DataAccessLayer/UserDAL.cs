using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Security.Cryptography;
using System.IO;

namespace DataAccessLayer
{
    public class UserDAL :SpaPracticeEntities
    {




        SpaPracticeEntities dbcontext = new SpaPracticeEntities();
        //SpaPracticeDB dbcontext = new SpaPracticeDB();
        public UserEL CheckUserAuthentication(string userName, string password, int? branchID)
        {
            //var UserDetails = dbcontext.tblusers.Where(x => x.UserName.Trim().ToUpper() == userName && x.Password.Trim().ToUpper() == password).FirstOrDefault();
            var UserDetails = dbcontext.tblusers.Where(x => x.UserName.Trim().ToUpper() == userName && x.Password.Trim().ToUpper() == password && x.FK_BranchID == branchID).FirstOrDefault();
            if (UserDetails != null)
            {
                UserEL objUser = new UserEL()
                {
                    UserId = UserDetails.UserId,
                    BranchId = UserDetails.FK_BranchID == null ? 0 : UserDetails.FK_BranchID,
                    UserName = UserDetails.UserName,
                    Name = UserDetails.Name,
                    Email = UserDetails.Email,
                    RoleId = UserDetails.FK_RoleId
                    //UserId = UserDetails.UserId,
                    //UserName = UserDetails.UserName,
                    //Name = UserDetails.Name,
                    //Email = UserDetails.Email
                    
                };

                return objUser;
            }
            else
            {
                return null;
            }
        }


        public UserEL ForgotPassword(string email, int? branchID)
        {
            var UserDetails = dbcontext.tblusers.Where(x => x.Email.Trim().ToUpper() == email.Trim().ToUpper() && x.FK_BranchID == branchID).FirstOrDefault();

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

        public List<tblrole> GetAllRole(int? branchID)
        {
            List<tblrole> roleList = tblroles.Where(x => x.RoleId < 5 && x.RoleId != 1 && x.FK_BranchID == branchID).ToList();
            return roleList;
        }

        public int InsertUpdateUser(tbluser objuser)
        {

            try
            {
                if (objuser.UserId == 0)
                {
                    tblusers.Add(objuser);
                    SaveChanges();
                }
                else
                {
                    Entry(objuser).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objuser.UserId;
        }

        public bool CheckUserName(string userName, int? branchID)
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

        public int InsertUpdateDoctorAvailability(tblavailablity objavailability)
        {

            try
            {
                if (objavailability.AvailableId == 0)
                {
                    tblavailablities.Add(objavailability);
                    SaveChanges();
                }
                else
                {
                    Entry(objavailability).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objavailability.AvailableId;
        }


        public List<UserEL> GetAllUser(int? branchID)
        {


            List<UserEL> userList = tblusers.Where(x => x.FK_RoleId != 6 && x.FK_BranchID == branchID).Select(x => new UserEL()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                Mobile = x.Mobile,
                Specialization = x.Specialization,
                RoleId = x.FK_RoleId,
                RoleName = x.tblrole.RoleName,
                Status = x.IsActive == true ? "Active" : "Blocked",
                Fees = (x.tblservices.FirstOrDefault() == null ? 0 : x.tblservices.FirstOrDefault().Amount)
            }).ToList();

            //foreach (var item in userList)
            //{
            //    item.Fees = tblservices.Where(m => m.FK_UserId == item.UserId).FirstOrDefault().Amount;
            //}



            return userList;
        }

        public UserEL GetAllUserById(int uId, int? branchID)
        {

            UserEL userList = tblusers.Where(x => x.UserId == uId && x.FK_BranchID == branchID).Select(x => new UserEL()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Name = x.Name,
                Email = x.Email,
                Mobile = x.Mobile,
                Password = x.Password,
                Specialization = x.Specialization,
                RoleId = x.FK_RoleId,
                RoleName = x.tblrole.RoleName,
                Status = x.IsActive == true ? "Active" : "Blocked",
                Fees = (x.tblservices.FirstOrDefault() == null ? 0 : x.tblservices.FirstOrDefault().Amount)
            }).ToList().FirstOrDefault();

            return userList;
        }

        public bool DeleteUserById(int userId, int? branchID)
        {
            try
            {
                tbluser itemToRemove = tblusers.SingleOrDefault(x => x.UserId == userId && x.FK_BranchID == branchID);
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

        public UserEL GetUserDetailsByPatientId(int ClientId, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.tblclients.FirstOrDefault().ClientId == ClientId && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                UserEL objUser = new UserEL()
                {
                    UserId = UserDetails.UserId,
                    UserName = UserDetails.UserName,
                    Name = UserDetails.Name,
                    Email = UserDetails.Email,
                    Password = UserDetails.Password,
                    BranchCode = UserDetails.tblbranch.BranchCode,
                    BranchName = UserDetails.tblbranch.BranchName
                };

                return objUser;
            }
            else
            {
                return null;
            }
        }

        public tbluser GetTableUserById(int? userId, int? branchID)
        {
            return tblusers.Where(x => x.UserId == userId && x.FK_BranchID == branchID).FirstOrDefault();
        }
        public tbluser GetTableUserByRoleId(int? roleId)
        {
            return tblusers.Where(x => x.FK_RoleId == roleId).FirstOrDefault();
        }
        public tblservice GetServiceByUserId(int? userId, int? branchID)
        {
            return tblservices.Where(x => x.FK_UserId == userId && x.FK_BranchID == branchID).FirstOrDefault();
        }

        public tblavailablity GetAvailabilityByUserId(int? userId, int? branchID)
        {
            return tblavailablities.Where(x => x.FK_UserId == userId && x.FK_BranchID == branchID).FirstOrDefault();
        }


        public void InsertUpdateRoleByBranch(int? branchID)
        {

            try
            {

                using (SpaPracticeEntities db = new SpaPracticeEntities())
                {
                    db.tblroles.ToList().ForEach(x =>
                    {
                        x.FK_BranchID = branchID;
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public UserEL ChangePassword(string oldpassword, string newpassword, string retypenewpassword, int? branchID)
        {
            var UserDetails = dbcontext.tblusers.Where(x => x.Password == oldpassword && x.FK_BranchID == branchID).FirstOrDefault();
            if (UserDetails != null)
            {
                UserEL objUser = new UserEL();
                if (newpassword == retypenewpassword)
                {
                    {
                        UserDetails.Password = Encrypt(newpassword);
                        dbcontext.SaveChanges();
                    }
                }
                return objUser;
            }
            else { return null; }
        }


        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public bool CheckUserMobileNumber(string mobile, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.Mobile == mobile && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<UserEL> GetAllUserDetailForGrid(int? branchID)
        {
            List<UserEL> objUserEL = new List<UserEL>();
            List<string> EducationList = new List<string>();
            List<string> SpecializationList = new List<string>();
            string Education = "";
            string Specialization = "";

            var LeftJoin = (from u in tblusers
                            where u.FK_RoleId != 6 && u.FK_BranchID == branchID
                            select new UserEL()
                            {
                                UserId = u.UserId,
                                UserName = u.UserName,
                                Name = u.Name,
                                Email = u.Email,
                                Password = u.Password,
                                Mobile = u.Mobile,
                                //effective_date = u.tblservices.FirstOrDefault().Effective_Date,
                                RoleId = u.FK_RoleId,
                                RoleName = u.tblrole.RoleName,
                                Status = u.IsActive == true ? "Active" : "Blocked",
                                Fees = (u.tblservices.FirstOrDefault() == null ? 0 : u.tblservices.FirstOrDefault().Amount)

                                //EmployeeName = emp.Name,
                                //DepartmentName = dept != null ? dept.Name : null
                            }).ToList().OrderBy(u => u.UserId);



            //foreach (var item in LeftJoin)
            //{

            //    //...........For Education Detail Added by Sam on 16052016..................
            //    var result = tbluesreducationmappings.Where(p => p.Fk_UserId == item.UserId).ToList();
            //    foreach (var r in result)
            //    {

            //        string DegreeName = tbleducations.Where(x => x.EducationId == r.Fk_EducationId).Select(x => x.EducationName).FirstOrDefault();

            //        //EducationList.Add(DegreeName);
            //        //foreach (string degree in EducationList)
            //        //{
            //        if (DegreeName != null)
            //        {
            //            Education += DegreeName + ",";
            //            DegreeName = "";
            //        }
            //        //}
            //        //item.Education = Education.TrimEnd(',');                    
            //    }
            //    if (Education != null)
            //    {
            //        item.Education = Education.TrimEnd(',');
            //        EducationList.Clear();
            //        Education = null;
            //    }
            //    //...........For Education Detail Above Added by Sam on 16052016..................

            //    //...........For Specialization Detail Added by Sam on 16052016..................

            //    var Specializationresult = tbluesrspecializationmappings.Where(p => p.Fk_UserId == item.UserId).ToList();
            //    foreach (var sr in Specializationresult)
            //    {

            //        string SpecializationName = tblspecilizations.Where(x => x.specilizationId == sr.Fk_SpecializationId).Select(x => x.specilizationName).FirstOrDefault();
            //        //SpecializationList.Add(SpecializationName);
            //        //foreach (string specialization in SpecializationList)
            //        //{
            //        if (SpecializationName != null)
            //        {
            //            Specialization += SpecializationName + ",";
            //            SpecializationName = "";
            //        }


            //    }
            //    if (Specialization != null)
            //    {
            //        item.Specialization = Specialization.TrimEnd(',');
            //        SpecializationList.Clear();
            //        Specialization = null;
            //    }
            //    //...........For Education Detail Above Added by Sam on 16052016..................


            //}
            return LeftJoin;




        }

        public bool CheckUserMobileNumberForUpdate(int userid, string mobile, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.Mobile == mobile && x.UserId != userid && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserEmailForUpdate(int userid, string email, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.Email == email && x.UserId != userid && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserEmail(string email, int? branchID)
        {
            var UserDetails = tblusers.Where(x => x.Email == email && x.FK_BranchID == branchID).FirstOrDefault();

            if (UserDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public UserEL GetUserList(int? branchID)
        {
            UserEL objUserEL = new UserEL();
            List<UserList> emptyUser = new List<UserList>();
            List<UserList> User = dbcontext.tblusers.Where(x => x.FK_BranchID == branchID && x.FK_RoleId != 6 && x.FK_RoleId != 5 && x.FK_RoleId != 1 && x.IsActive == true).Select(x => new UserList
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Mobile,
                Specialization = x.Specialization,
                Active = x.IsActive == true ? "Yes" : "No",
                FK_RoleId = x.FK_RoleId.Value,
            }).ToList();
            foreach (var item in User)
            {
                string RoleName = dbcontext.tblroles.Where(x => x.RoleId == item.FK_RoleId).Select(x => x.RoleName).FirstOrDefault();
                item.RoleName = RoleName;
            }
            objUserEL.UserList = User.ToList();
            return objUserEL;
        }

        public UserEL GetRoleList(int? branchID)
        {
            UserEL objUserEL = new UserEL();
            List<CustomList> Role = dbcontext.tblroles.Where(x => x.FK_BranchID == branchID && x.RoleId != 6 && x.RoleId != 5 && x.RoleId != 1).Select(x => new CustomList { Id = x.RoleId, Name = x.RoleName }).ToList();
            Role.Add(new CustomList { Id = 0, Name = "Select A Role" });
            objUserEL.RoleList = Role.OrderBy(x => x.Id).ToList();
            return objUserEL;
        }

        public string GetRoleById(int Id = 0)
        {
            var role = dbcontext.tblroles.Where(x => x.RoleId == Id).Select(x => x.RoleName).FirstOrDefault();
            return role.ToString();
        }


        public IEnumerable<UserEL> FetchListOfUsers(int id = 0, int branchId = 0)
        {
            var userList = dbcontext.tblusers.Where(x => x.FK_BranchID == branchId && x.UserId == id).Select(x => new UserEL
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Name = x.Name,
                Password = x.Password,
                Mobile=x.Mobile, 
                Email = x.Email, 
                RoleId = (int)x.FK_RoleId,
            });
            foreach (var item in userList)
            {
                string RoleName = dbcontext.tblroles.Where(x => x.RoleId == item.RoleId).Select(x => x.RoleName).ToString();
                item.RoleName = RoleName;
            }
            return userList.ToList();
        }
    }
}
