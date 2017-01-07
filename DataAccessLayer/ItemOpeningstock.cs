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
 public   class ItemOpeningstock : SpaPracticeEntities
    {
        StockDAL ObjStock = new StockDAL();
        public int InsertUpdateOpeningstockHdr(tblitemopeningheader objOpeningstockHdr, tblitemopeningdetail obopeningStockDtlj)
        {

            try
            {

                int code;
                var BNValue = tblitemopeningheaders.Max(i => (int?)i.Code).GetValueOrDefault();
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
                if (objOpeningstockHdr.Code == 0)
                {
                    objOpeningstockHdr.Code = code;
                    objOpeningstockHdr.ItemOpeningTranId = GetOpeningTran();
                    tblitemopeningheaders.Add(objOpeningstockHdr);
                    SaveChanges();
                }
                else
                {
                    var appOrg = tblitemopeningheaders.Find(objOpeningstockHdr.Code);
                    Entry(appOrg).CurrentValues.SetValues(objOpeningstockHdr);
                    SaveChanges();
                    //make all inactive in detail
                    var objOpeningDtl = tblitemopeningdetails.Where(p => p.ItemOpeningCd == objOpeningstockHdr.Code).ToList();
                    objOpeningDtl.ForEach(a => a.ActiveYN = false);
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return 0;
        }


        #region === Get opening stock tranID===
        public string GetOpeningTran()
        {
            string openingtranId = string.Empty;
            string Tempid = string.Empty;
            string prefix = string.Empty;
            string Codeprefix = string.Empty;
            string Outputvalue = string.Empty;
            prefix = Globalmethods.GetPrefixforTransaction(3);
            if (prefix == "Y")
            {
                if (Globalmethods.BranchCD < 10)
                {
                    Codeprefix = "0" + Globalmethods.BranchCD.ToString() + "/" + Globalmethods.FinYr.ToString(); ;
                }
                else
                {
                    Codeprefix = Globalmethods.BranchCD.ToString() + "/" + Globalmethods.FinYr.ToString();
                }
                var TranId = tblitemopeningheaders.Where(x => x.BranchCd == Globalmethods.BranchCD && x.Finyr == Globalmethods.FinYr).Max(i => i.ItemOpeningTranId);
                if (TranId == null)
                {
                    openingtranId = Codeprefix + "/" + "00001";
                }
                else
                {
                    Tempid = TranId.ToString();
                    Tempid = Tempid.Substring(12, 5);
                    int code = Int32.Parse(Tempid);
                    code = code + 1;
                    Outputvalue = String.Format("{0:D5}", code);

                    openingtranId = Codeprefix + "/" + Outputvalue;
                }
            }


            return openingtranId;

        }
        #endregion
        #region Bind Header Grid===
        public void BindList(int BranchID, DataGridView grd)
        {
            try
            {
                var data = (dynamic)null; 
                if (Globalmethods.IsAdmin == true)
                {
                    
                     data = (from p in tblitemopeningheaders
                                //join bomDtl in tblbomdetails on p.Code equals bomDtl.BOM_Cd

                                join gd in tblgodowns on p.GodownCd equals gd.Code
                                join br in tblbranches on p.BranchCd equals br.BranchID
                                orderby br.BranchName, gd.Description
                                select new
                                {
                                    code = p.Code,
                                    Brabchcd = p.BranchCd,
                                    Godowncd = p.GodownCd,
                                    BranchName = br.BranchName,
                                    GodownName = gd.Description,
                                    Description = p.Description,
                                    TranDate = p.TranDate,
                                    TotalValue = p.TotValue,
                                    ActiveYN = p.ActiveYN

                                }
                                ).ToList();
                }

                else
                {
                    data = (from p in tblitemopeningheaders
                            //join bomDtl in tblbomdetails on p.Code equals bomDtl.BOM_Cd

                            join gd in tblgodowns on p.GodownCd equals gd.Code
                            join br in tblbranches on p.BranchCd equals br.BranchID
                            where p.BranchCd==Globalmethods.BranchCD
                            orderby br.BranchName, gd.Description
                            select new
                            {
                                code = p.Code,
                                Brabchcd = p.BranchCd,
                                Godowncd = p.GodownCd,
                                BranchName = br.BranchName,
                                GodownName = gd.Description,
                                Description = p.Description,
                                TranDate = p.TranDate,
                                TotalValue = p.TotValue,
                                ActiveYN = p.ActiveYN

                            }
                               ).ToList();
                }
               // var result = data.ToList();

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

        public List<ItemOpeningStockEL> BindDtlList( int Code)
        {
            //  var Dtl=null;
            try
            {
                List<ItemOpeningStockEL> objOpeningStkEL = new List<ItemOpeningStockEL>();
                objOpeningStkEL = (from OpDtl in tblitemopeningdetails
                           join It in tblitems on OpDtl.itemcd equals It.Code
                              into t1
                           from It in t1.DefaultIfEmpty()
                           join Unt in tblunits on OpDtl.UnitCd equals Unt.Code
                              into t2
                           from Unt in t2.DefaultIfEmpty()
                           where OpDtl.ItemOpeningCd == Code
                           orderby It.Description
                           select new ItemOpeningStockEL()
                           {
                               DCode = OpDtl.Code,
                               ItemCd = OpDtl.itemcd,
                               Item = (It.Description ?? string.Empty),
                               UnitCd = OpDtl.UnitCd,
                               Unit = (Unt.Description ?? string.Empty),
                               ExpiryDt = OpDtl.ExpiryDt.Value, 
                               SubUnitCd = (OpDtl.SubUnitCd ?? 0),
                               SubQty = OpDtl.SubQty,
                               Quantity = OpDtl.Qty,
                               Rate = OpDtl.value,
                               ActiveYN = OpDtl.ActiveYN
                           }
                         ).ToList();


                return objOpeningStkEL;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
        #region Insert  Update detail grid
        public int InsertUpdateBOMdetai(tblitemopeningdetail objItemopeningDtl, tblstock obkStockEntry)
        {
            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    int code = 0;

                    if (objItemopeningDtl.Code == 0)
                    {
                        //====================================

                        var BNValue = tblitemopeningdetails.Max(i => (int?)i.Code).GetValueOrDefault();
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

                        objItemopeningDtl.Code = code;
                        tblitemopeningdetails.Add(objItemopeningDtl);
                        ObjStock.InsertUpdateStock(objItemopeningDtl.ItemOpeningCd, code, obkStockEntry);
                        SaveChanges();
                        dbTran.Commit();
                    }
                    else
                    {

                        var appOrg = tblitemopeningdetails.Find(objItemopeningDtl.Code);
                        Entry(appOrg).CurrentValues.SetValues(objItemopeningDtl);
                        SaveChanges();
                        ObjStock.InsertUpdateStock(objItemopeningDtl.ItemOpeningCd, objItemopeningDtl.Code, obkStockEntry);
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

    }
}
