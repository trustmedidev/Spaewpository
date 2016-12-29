﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;
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
                        
                        var appOrgDtl = tblbomdetails.Find(objBOMdetai.BOM_Cd);
                        Entry(appOrgDtl).CurrentValues.SetValues(objBOMdetai);
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
    }
}

