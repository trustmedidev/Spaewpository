using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;
using EntityLayer;

namespace DataAccessLayer
{
    public class TaxConfigDAL : SpaPracticeEntities
    {
        public int InsertUpdateHdr(tbltaxconfigheader objtbltaxconfigheader, tbltaxcofigdetail objtbltaxcofigdetail)
        {

            try
            {

                int code;
                var BNValue = tbltaxconfigheaders.Max(i => (int?)i.Code).GetValueOrDefault();
                if (BNValue == 0)
                {
                    code = 1;
                }
                else
                {
                    code = Int32.Parse(BNValue.ToString());
                    code = code + 1;
                }

                //new insert 
                if (objtbltaxconfigheader.Code == 0)
                {
                    objtbltaxconfigheader.Code = code;
                    ////objOpeningstockHdr.ItemOpeningTranId = GetOpeningTran();
                    tbltaxconfigheaders.Add(objtbltaxconfigheader);
                    SaveChanges();
                    return code;
                }
                else
                {
                    var appOrg = tblitemopeningheaders.Find(objtbltaxconfigheader.Code);
                    Entry(appOrg).CurrentValues.SetValues(objtbltaxconfigheader);
                    SaveChanges();

                    //make all inactive in detail
                    var objOpeningDtl = tbltaxcofigdetails.Where(p => p.TaxConfigHdCd == objtbltaxconfigheader.Code).ToList();
                    objOpeningDtl.ForEach(a => a.ActiveYN = false);
                    SaveChanges();
                    return objtbltaxconfigheader.Code;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

            //return 0;
        }

        #region Insert  Update detail grid
        public int InsertUpdateDetai(tbltaxcofigdetail objtbltaxcofigdetail)
        {
            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    int code = 0;

                    if (objtbltaxcofigdetail.Code == 0)
                    {
                        //====================================

                        var BNValue = tbltaxcofigdetails.Max(i => (int?)i.Code).GetValueOrDefault();
                        if (BNValue == 0)
                        {
                            code = 1;
                        }
                        else
                        {
                            code = Int32.Parse(BNValue.ToString());
                            code = code + 1;
                        }
                        //====================================

                        objtbltaxcofigdetail.Code = code;
                        tbltaxcofigdetails.Add(objtbltaxcofigdetail);
                        //ObjStock.InsertUpdateStock(objItemopeningDtl.ItemOpeningCd, code, obkStockEntry);
                        SaveChanges();
                        dbTran.Commit();
                    }
                    else
                    {

                        var appOrg = tblitemopeningdetails.Find(objtbltaxcofigdetail.Code, objtbltaxcofigdetail.TaxConfigHdCd);
                        Entry(appOrg).CurrentValues.SetValues(objtbltaxcofigdetail);
                        SaveChanges();
                        //ObjStock.InsertUpdateStock(objItemopeningDtl.ItemOpeningCd, objItemopeningDtl.Code, obkStockEntry);
                        dbTran.Commit();
                    }
                    return code;

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        #endregion


        }

        #region Bind Header Grid===
        public void BindList(int BranchID, DataGridView grd)
        {
            try
            {
                var data = (dynamic)null;
                if (Globalmethods.IsAdmin == true)
                {

                    data = (from p in tbltaxconfigheaders
                            join br in tblbranches on p.BranchCd equals br.BranchID
                            orderby br.BranchName, p.Description
                            select new
                            {
                                code = p.Code,                               
                                Brabchcd = p.BranchCd,                                
                                BranchName = br.BranchName,                                
                                Description = p.Description,                               
                                HActiveYN = p.ActiveYN


                            }
                               ).ToList();
                }

                else
                {
                    data = (from p in tbltaxconfigheaders

                            join br in tblbranches on p.BranchCd equals br.BranchID
                            where p.BranchCd == Globalmethods.BranchCD
                            orderby br.BranchName, p.Description
                            select new
                            {
                                code = p.Code,
                                Brabchcd = p.BranchCd,
                                BranchName = br.BranchName,
                                Description = p.Description,
                                ActiveYN = p.ActiveYN

                            }
                               ).ToList();
                }

                if (data != null)
                {
                    grd.DataSource = null;
                    grd.DataSource = data;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Bind detail grid

        public List<TaxConfigurationEL> BindDtlList(int Code)
        {
            //  var Dtl=null;
            try
            {
                List<TaxConfigurationEL> objTaxConfigurationEL = new List<TaxConfigurationEL>();
                objTaxConfigurationEL = (from OpDtl in tbltaxcofigdetails
                                   //join It in tblitems on OpDtl.itemcd equals It.Code
                                   //   into t1
                                   //from It in t1.DefaultIfEmpty()
                                   //join Unt in tblunits on OpDtl.UnitCd equals Unt.Code
                                   //   into t2
                                   //from Unt in t2.DefaultIfEmpty()
                                   //join Unt1 in tblunits on OpDtl.SubUnitCd equals Unt1.Code
                                   //   into t3
                                   //from Unt1 in t3.DefaultIfEmpty()
                                   //where OpDtl.ItemOpeningCd == Code
                                   //orderby It.Description
                                         select new TaxConfigurationEL()
                                   {
                                       DCode = OpDtl.Code,
                                       ConfigNm = OpDtl.Name,
                                       STax = OpDtl.TaxYN,
                                       addSub = OpDtl.AddSub,
                                       CalOn=OpDtl.CalOn,
                                       CalPer=OpDtl.CalPer,
                                       CalVal=OpDtl.CalVal,
                                       TermsType=OpDtl.TermsType,
                                       IsActive = OpDtl.ActiveYN
                                   }
                         ).ToList();


                return objTaxConfigurationEL;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
