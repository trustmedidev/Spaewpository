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
    public class PurchaseBillDAL : SpaPracticeEntities
    {
        StockDAL ObjStock = new StockDAL();
        bool GRNYN = false;
        #region === Get tranID===
        public string GetTranId()
        {
           
            string tranId = string.Empty;
            string Tempid = string.Empty;
            string prefix = string.Empty;
            string Codeprefix = string.Empty;
            string Outputvalue = string.Empty;
            prefix = Globalmethods.GetPurchaseBillPrefixforTran(3);
            

            if (prefix != "N")
            {
                if (Globalmethods.BranchCD < 10)
                {
                    Codeprefix = "0" + Globalmethods.BranchCD.ToString() + "/" + Globalmethods.FinYr.ToString();
                }
                else
                {
                    Codeprefix = Globalmethods.BranchCD.ToString() + "/" + Globalmethods.FinYr.ToString();
                }
                var TranId = tblpurchasehdrs.Where(x => x.BranchCd == Globalmethods.BranchCD && x.FinYr == Globalmethods.FinYr).Max(i => i.PurchaseTranID);
                if (TranId == null)
                {
                    tranId = Codeprefix + "/" + "00001";
                }
                else
                {
                    Tempid = TranId.ToString();
                    Tempid = Tempid.Substring(12, 5);
                    int code = Int32.Parse(Tempid);
                    code = code + 1;
                    Outputvalue = String.Format("{0:D5}", code);

                    tranId = Codeprefix + "/" + Outputvalue;
                }
            }


            return tranId;

        }
        #endregion

        public int InsertUpdateHdr(tblpurchasehdr objOtblpurchasehdr, tblpurchasedtl objtblpurchasedtl)
        {

            try
            {

                int code;
                var BNValue = tblpurchasehdrs.Max(i => (int?)i.Code).GetValueOrDefault();
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
                if (objOtblpurchasehdr.Code == 0)
                {
                    objOtblpurchasehdr.Code = code;
                    objOtblpurchasehdr.PurchaseTranID = GetTranId();
                    tblpurchasehdrs.Add(objOtblpurchasehdr);
                    SaveChanges();
                    return code;
                }
                else
                {
                    var appOrg = tblpurchasehdrs.Find(objOtblpurchasehdr.Code);
                    Entry(appOrg).CurrentValues.SetValues(objOtblpurchasehdr);
                    SaveChanges();

                    //make all inactive in detail
                    var objOpeningDtl = tblpurchasedtls.Where(p => p.PurchaseCd == objOtblpurchasehdr.Code).ToList();
                    objOpeningDtl.ForEach(a => a.ActiveYN = false);
                    SaveChanges();
                    return objOtblpurchasehdr.Code;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

            return 0;
        }


        #region Bind Header Grid===
        public void BindList(int BranchID, DataGridView grd)
        {
            try
            {
                var data = (dynamic)null;
                if (Globalmethods.IsAdmin == true)
                {

                    data = (from p in tblpurchasehdrs
                            //join bomDtl in tblbomdetails on p.Code equals bomDtl.BOM_Cd

                            join gd in tblgodowns on p.GodownCd equals gd.Code
                            join br in tblbranches on p.BranchCd equals br.BranchID
                            join supp in tblsuppliors on p.SupplierCd equals supp.Code
                            orderby br.BranchName, gd.Description, supp.Description
                            select new
                            {
                                code = p.Code,
                                PurchaseTranID = p.PurchaseTranID,
                                Brabchcd = p.BranchCd,
                                Godowncd = p.GodownCd,
                                BranchName = br.BranchName,
                                GodownName = gd.Description,
                                SupplierCd=p.SupplierCd,
                                SupplierNM = supp.Description,
                                //Description = p.Description,
                                TranId=p.TaxConfigCd,
                                TranDate = p.TranDate,
                                TotBasicValue=p.TotBasicValue,
                                TotVal=p.TotVal,
                                TotDisc=p.TotDisc,
                                TotValue=p.TotValue,
                                TotalValue = p.TotValue,
                                HActiveYN = p.AcgtiveYN


                            }
                               ).ToList();
                }

                else
                {
                    data = (from p in tblpurchasehdrs
                            //join bomDtl in tblbomdetails on p.Code equals bomDtl.BOM_Cd

                            join gd in tblgodowns on p.GodownCd equals gd.Code
                            join br in tblbranches on p.BranchCd equals br.BranchID
                            join supp in tblsuppliors on p.SupplierCd equals supp.Code                            
                            where p.BranchCd == Globalmethods.BranchCD
                            orderby br.BranchName, gd.Description, supp.Description
                            select new
                            {
                                code = p.Code,
                                Brabchcd = p.BranchCd,
                                Godowncd = p.GodownCd,
                                BranchName = br.BranchName,
                                GodownName = gd.Description,
                                SupplierCd = p.SupplierCd,
                                SupplierNM = supp.Description,
                                //Description = p.Description,
                                TranDate = p.TranDate,
                                TotalValue = p.TotValue,
                                ActiveYN = p.AcgtiveYN

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

        #region Insert  Update detail grid
        public int InsertUpdateDetai(tblpurchasedtl objtblpurchasedtl, tblstock obkStockEntry)
        {
            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    int code = 0;

                    if (objtblpurchasedtl.Code == 0)
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

                        objtblpurchasedtl.Code = code;
                        tblpurchasedtls.Add(objtblpurchasedtl);
                        ObjStock.InsertUpdateStock(objtblpurchasedtl.PurchaseCd, code, obkStockEntry);
                        SaveChanges();
                        dbTran.Commit();
                    }
                    else
                    {

                        var appOrg = tblitemopeningdetails.Find(objtblpurchasedtl.Code, objtblpurchasedtl.PurchaseCd);
                        Entry(appOrg).CurrentValues.SetValues(objtblpurchasedtl);
                        SaveChanges();
                        ObjStock.InsertUpdateStock(objtblpurchasedtl.PurchaseCd, objtblpurchasedtl.Code, obkStockEntry);
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



        }

        #endregion

        #region === bind GRN No
        public void BindDdlGRNNo(ComboBox ddl)
        {
            try
            {
                GRNYN = false;
                GRNYN = Globalmethods.GetGRNYN(3);
                if (GRNYN == true)
                {
                    var data = (from p in tblgrnhdrs
                                where p.ActiveYN == true
                                select new
                                {
                                    Code = p.Code,
                                    Name = p.Description
                                });
                    var servicelist = data.ToList();
                    if (servicelist != null)
                    {
                        ddl.DataSource = null;
                        ddl.Items.Clear();

                        ddl.ValueMember = "Code";
                        ddl.DisplayMember = "Name";
                        ddl.DataSource = servicelist;
                        ddl.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Bind detail grid

        public List<PurchaceBillEL> BindDtlList(int Code)
        {
            //  var Dtl=null;
            try
            {
                List<PurchaceBillEL> objPurchaceBillEL = new List<PurchaceBillEL>();
                objPurchaceBillEL = (from OpDtl in tblpurchasedtls
                                   join It in tblitems on OpDtl.ItemCd equals It.Code
                                      into t1
                                   from It in t1.DefaultIfEmpty()
                                   join Unt in tblunits on OpDtl.UnitCd equals Unt.Code
                                      into t2
                                   from Unt in t2.DefaultIfEmpty()
                                     join btch in tblbatches on OpDtl.BatchCd equals btch.Code
                                        into t3
                                     from btch in t3.DefaultIfEmpty()
                                   where OpDtl.PurchaseCd == Code
                                   orderby It.Description
                                     select new PurchaceBillEL()
                                   {
                                       //Code
                                       // PurchaseCd
                                       // ItemCd
                                       // BatchCd
                                       // Qty
                                       // UnitCd
                                       // Rate
                                       // VatPer
                                       // VatVal
                                       // DiscPer
                                       // Value
                                       // ExpiryDt
                                       // ActiveYN

                                       DCode = OpDtl.Code,
                                       ItemCd = OpDtl.ItemCd,
                                       Item = (It.Description ?? string.Empty),
                                       UnitCd = OpDtl.UnitCd,
                                       Unit = (Unt.Description ?? string.Empty),
                                       BatchCd = OpDtl.BatchCd,
                                       BatchNo=(btch.BatchNo ?? string.Empty),
                                       Qty = OpDtl.Qty,
                                       Rate = OpDtl.Rate,
                                       ExpiryDt = OpDtl.ExpiryDt,
                                       //SubUnitCd = (OpDtl.SubUnitCd ?? 0),
                                       //SubUnit = (Unt1.Description ?? string.Empty),
                                       //Qty = OpDtl.SubQty,
                                      
                                       //Rate = OpDtl.Value,
                                       ActiveYN = OpDtl.ActiveYN
                                   }
                         ).ToList();


                return objPurchaceBillEL;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
