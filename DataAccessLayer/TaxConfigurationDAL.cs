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
    public class TaxConfigurationDAL : SpaPracticeEntities
    {
        #region Crud Function Start

        public int InsertTaxLog(tbltaxlog objtbltaxlog)
        {
            if (objtbltaxlog.TaxLogId == 0)
            {
                tbltaxlogs.Add(objtbltaxlog);
                SaveChanges();
            }
            else {}
            return objtbltaxlog.TaxLogId;
        }
        public bool CheckTaxName(string taxName, int? branchID)
        {
            var dtls = tbltaxmasters.Where(x => x.Tax_Name.Trim().ToUpper() == taxName && x.FK_BranchID == branchID).FirstOrDefault();

            if (dtls != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int InsertMapTax(tblmaptax objtbl_maptax)
        {
            if (objtbl_maptax.MapTaxId == 0)
            {
                tblmaptaxes.Add(objtbl_maptax);
                SaveChanges();
            }
            else { }
            return objtbl_maptax.MapTaxId;
        }
        public int InsertUpdateTaxType(tbltaxmaster objtbltaxmaster)
        {
            try
            {
                if (objtbltaxmaster.Tax_Id == 0)
                {
                    tbltaxmasters.Add(objtbltaxmaster);

                    SaveChanges();
                }
                else
                {
                    Entry(objtbltaxmaster).State = EntityState.Modified;
                    SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objtbltaxmaster.Tax_Id;
        } 
        public bool DeleteTaxTypeById(int id, int? branchID)
        {
            try
            {
                tbltaxmaster itemToRemove = tbltaxmasters.SingleOrDefault(x => x.Tax_Id == id && x.FK_BranchID == branchID);
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
        public tbltaxmaster GetAllTaxTypeById(int? ID, int? branchID)
        {
            return tbltaxmasters.Where(x => x.Tax_Id == ID && x.FK_BranchID == branchID).FirstOrDefault();
        }

        /*-----------------------Rev By Sandip Das on 02-06-2016---------------------------------*/
        public TaxConfigurationEL GetRateAndEfcDateById(int? Id, DateTime? EfcDate)
        {
            return tblmaptaxes.Where(x => x.FK_TaxId == Id && x.EffectiveDate == EfcDate).Select(x => new TaxConfigurationEL()
            {
                Tax_Rate=x.TaxRate,
                EffectiveDate=x.EffectiveDate,
            }).FirstOrDefault();
        }
        
        public decimal? GetRateFromTax(int? taxId)
        {
            var query = tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).ToList();
            decimal? query1 = new decimal();
            if (query.Count > 1)
            {
                var closestdate = query.Where(x => x <= DateTime.Today).DefaultIfEmpty().Max();
                query1 = (tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.TaxRate).FirstOrDefault()==null?0:tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.TaxRate).FirstOrDefault());
            }
            else
            {
                query1 = (tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.TaxRate).FirstOrDefault() == null ? 0 : tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.TaxRate).FirstOrDefault());
            }
            return (decimal)query1;
        }
        public DateTime? GetDateFromTax(int? taxId)
        {
            var query = tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).ToList();
            DateTime? query1 = new DateTime();
            if (query.Count > 1)
            {
                var closestdate = query.Where(x => x <= DateTime.Today).DefaultIfEmpty().Max();
                query1 = (tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate).FirstOrDefault()==null?Convert.ToDateTime(null):tblmaptaxes.Where(x => x.EffectiveDate == closestdate).Select(x => x.EffectiveDate).FirstOrDefault());
            }
            else
            {
                query1 = (tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).FirstOrDefault() == null ? Convert.ToDateTime(null) : tblmaptaxes.Where(x => x.FK_TaxId == taxId).Select(x => x.EffectiveDate).FirstOrDefault());
            }
            return (DateTime)query1;
        }
        public List<TaxConfigurationEL> GetAllTaxTypeForGrid(int? branchID)
        {
            //List<tbltaxmaster> CouponList = tbltaxmasters.Where(x => x.FK_BranchID == branchID).Distinct().ToList();
            //return CouponList.OrderBy(x => x.Tax_Name).ToList();

            var query = tbltaxmasters.Where(x => x.FK_BranchID == branchID).Select(x => new TaxConfigurationEL()
            {
                Tax_Name=x.Tax_Name,
                Tax_Id=(int)x.Tax_Id,
                IsActive=(bool)x.IsActive,
            }).ToList();
            
            foreach (var item in query)
            {
                item.Tax_Rate = GetRateFromTax(item.Tax_Id);
                item.EffectiveDate = GetDateFromTax(item.Tax_Id);
            }
            return query.ToList();
        }
        /*-----------------------End Rev By Sandip Das on 02-06-2016---------------------------------*/
        #endregion Get Method End 

        #region Check Function Start 
        public bool CheckExistingTaxType(string CouponName, int? branchID, int Id)
        {
            bool ret = false;
            try
            {
                tbltaxmaster t = new tbltaxmaster();
                if (Id == 0)
                {

                    t = tbltaxmasters.Where(x => x.Tax_Name.ToLower() == CouponName.ToLower() && x.FK_BranchID == branchID && x.IsActive==true).FirstOrDefault();
                }
                else
                {
                    t = tbltaxmasters.Where(x => x.Tax_Name.ToLower() == CouponName.ToLower() && x.FK_BranchID == branchID && x.Tax_Id != Id && x.IsActive == true).FirstOrDefault();
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

        #endregion Check Function End

    }
}
