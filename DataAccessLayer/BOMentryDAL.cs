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
    public class BOMentryDAL : SpaPracticeEntities
    {
        #region === insert data in Item
        public int InsertUpdateBOMheader(tblbomheader objBOMheader, tblbomdetail objBOMdetai)
        {
            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    int code;
                    var BNValue = tblbomheaders.Max(i => (int?)i.Code).GetValueOrDefault();
                    if (BNValue == 0)
                    {
                        code = 1;

                    }
                    else
                    {
                        code = Int32.Parse(BNValue.ToString());
                        code = code + 1;
                    }
                    if (objBOMheader.Code == 0)
                    {
                        objBOMheader.Code = code;
                        tblbomheaders.Add(objBOMheader);
                        SaveChanges();
                        dbTran.Commit();
                    }
                    else
                    {
                        var appOrg = tblbomheaders.Find(objBOMheader.Code);
                        Entry(appOrg).CurrentValues.SetValues(objBOMheader);
                        SaveChanges();
                        //cannot be used if the entire model is empty
                        //var appOrgDtl = tblbomdetails.Find(objBOMdetai.BOM_Cd);
                        //Entry(appOrgDtl).CurrentValues.SetValues(objBOMdetai);
                        //SaveChanges();
                        // updatwe tblBOmdtl & set activeyn to tblbomdetail
                        var objBOMdtl = tblbomdetails.Where(p => p.BOM_Cd == objBOMheader.Code).ToList();
                        objBOMdtl.ForEach(a => a.ActiveYN = false);
                        SaveChanges();
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

        public int InsertUpdateBOMdetai(tblbomdetail objBOMdetai)
        {
            using (var dbTran = Database.BeginTransaction())
            {
                try
                {
                    int code=0; 

                    if (objBOMdetai.Code == 0)
                    {
                        //====================================
                        
                        var BNValue = tblbomdetails.Max(i => (int?)i.Code).GetValueOrDefault();
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

                        objBOMdetai.Code = code;
                        tblbomdetails.Add(objBOMdetai);
                        SaveChanges();
                        dbTran.Commit();
                    }
                    else
                    {

                        var appOrg = tblbomdetails.Find(objBOMdetai.Code);
                        Entry(appOrg).CurrentValues.SetValues(objBOMdetai);
                        SaveChanges();
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

        #region === bind Item in DataGridView

        // item bind

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblbomheaders
                            //join bomDtl in tblbomdetails on p.Code equals bomDtl.BOM_Cd
                            
                            join Serv in tblservices on p.ServiceCd equals Serv.ServiceId
                            into s1
                            from Serv in s1.DefaultIfEmpty()
                            orderby Serv.ServiceName
                            select new
                            {
                                code = p.Code,
                                ServiceCd = p.ServiceCd,
                                ServiceName = Serv.ServiceName,
                                PackageDescription=p.PackageDescription,
                                HActiveYN = p.ActiveYN,
                            }
                            );
                var result = data.ToList();

                if (result != null)
                {
                    grd.DataSource = null;
                    grd.DataSource = result;
                }
            }
            catch (Exception ex)
            {

            }
        }

    

        #endregion

        #region === bind Item in DataGridView

        // item bind

        public List<BOMEL> BindDtlList(DataGridView grd, int Code)
        {
            try
            {
                List<BOMEL> objBOMEL=new List<BOMEL>();
                objBOMEL = (from bomDtl in tblbomdetails
                            join It in tblitems on bomDtl.ItemCd equals It.Code
                            into t1
                            from It in t1.DefaultIfEmpty()
                            join Unt in tblunits on bomDtl.UnitCd equals Unt.Code
                            into t2
                            from Unt in t2.DefaultIfEmpty()
                            where bomDtl.BOM_Cd == Code
                            orderby It.Description
                            select new BOMEL()
                            {
                                DCode=bomDtl.Code,
                                ItemCd = bomDtl.ItemCd,
                                Item = (It.Description ?? string.Empty),
                                UnitCd = bomDtl.UnitCd,
                                Unit = (Unt.Description ?? string.Empty),
                                Qty = (bomDtl.Qty ?? 0),
                                Rate = (bomDtl.Rate ?? 0),
                                DActiveYN = (bomDtl.ActiveYN ?? false),
                            }
                            ).ToList();
                //objBOMEL = data.ToList();

                return objBOMEL;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }



        #endregion
    }
}

