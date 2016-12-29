using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class ItemMainGrpDAL : SpaPracticeEntities
    {
        #region === insert data in Item Main Group
        public int Insert(string description, int UserCode)
        {
            tblitemmaingroup td = new tblitemmaingroup();
            try
            {
                int code;
                var CdValue = tblitemmaingroups.Max(i => (int?)i.Code).GetValueOrDefault();
                if (CdValue == 0)
                {
                    code = 1;

                }
                else
                {
                    code = Int32.Parse(CdValue.ToString());
                    code = code + 1;
                }
                td.Code = code;
                td.Description = description;
                td.ActiveYN = true;
                td.EntryDate = DateTime.Now;
                td.UserCode = UserCode;
                tblitemmaingroups.Add(td);
                SaveChanges();
                return code;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region ===update Item Main Group
        public int Update(int ID, string Name, bool ActiveYN)
        {
            tblitemmaingroup td = tblitemmaingroups.SingleOrDefault(p => p.Code == ID);
            try
            {
                td.Code = ID;
                td.Description = Name;
                td.ActiveYN = ActiveYN;

                SaveChanges();

                return ID;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region === bind Item Main Grp 
            public void BindDdlItemMainGrp(ComboBox ddl)
            {
                try
                {
              
                    var data = (from p in tblitemmaingroups
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            #endregion

        #region === bind Item Main Group in DataGridView

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblitemmaingroups
                            
                            orderby p.Description
                            select new
                            {
                                code = p.Code,
                                Name = p.Description,
                                ActiveYN = p.ActiveYN

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

        /// <summary>
        /// check for item main group in subgroup
        /// i means has value else 0
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        #region ===Item main grop exists down the line 
        public int ChkMaingrp(int ID)
        {
            try
            {
                    var data = (from p in tblitemsubgroups
                            where p.ItemMainGrpCd==ID && p.ActiveYN==true
                            select p).ToList();
                    if (data !=null || data.Count>0)
                    {
                        return 1;
                    }
                else
                    {
                        return 0;
                    }
                           
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        #endregion


    }
}
