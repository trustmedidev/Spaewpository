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
   public class CouponDAL:SpaPracticeEntities
   {

       #region Crud Function Start
       public int InsertUpdateCoupon(tblcoupanmaster objtblcoupanmaster)
        {
            try
            {
                if (objtblcoupanmaster.Id == 0)
                {
                    tblcoupanmasters.Add(objtblcoupanmaster);
                     
                    SaveChanges();
                }
                else
                {
                    Entry(objtblcoupanmaster).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objtblcoupanmaster.Id;
        } 
       public bool DeleteCouponsById(int id, int? branchID)
       {
           try
           {
               tblcoupanmaster itemToRemove = tblcoupanmasters.SingleOrDefault(x => x.Id == id && x.FK_BranchID == branchID);
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

       #region Get Method Start
       public tblcoupanmaster GetAllCouponById(int? ID, int? branchID)
        {
            return tblcoupanmasters.Where(x => x.Id == ID && x.FK_BranchID == branchID).FirstOrDefault();
        } 
       public List<tblcoupanmaster> GetAllCouponForGrid(int? branchID)
       {
           List<tblcoupanmaster> CouponList = tblcoupanmasters.Where(x => x.FK_BranchID == branchID).ToList();
           return CouponList.OrderBy(x => x.Coupan_Name).ToList();
       }

       #endregion Get Method End

       #region Check Existing Function Start
       public bool CheckExistingCoupon(string CouponName, int? branchID, int Id)
       {
           bool ret = false;
           try
           {
               tblcoupanmaster t = new tblcoupanmaster();
               if (Id == 0)
               {

                   t = tblcoupanmasters.Where(x => x.Coupan_Name.ToLower() == CouponName.ToLower() && x.FK_BranchID == branchID).FirstOrDefault();
               }
               else
               {
                   t = tblcoupanmasters.Where(x => x.Coupan_Name.ToLower() == CouponName.ToLower() && x.FK_BranchID == branchID && x.Id != Id).FirstOrDefault();
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
       #endregion Check Existing Function 

       #region Extra Code Start
       public tblservice GetServicesIdByUserId(int UserId, int? branchID)
        {
            return tblservices.Where(x => x.FK_UserId == UserId && x.FK_BranchID == branchID).FirstOrDefault();
        }

       #endregion Extra Code End
   }
}
