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
    public class ItemSubGrpDAL : SpaPracticeEntities
    {
        #region === insert data in Item Sub Group
        public int Insert(string description,int ItemMainGrpCd, int UserCode)
        {
            tblitemsubgroup td = new tblitemsubgroup();
            try
            {
                int code;
                var CdValue = tblitemsubgroups.Max(i => (int?)i.Code).GetValueOrDefault();
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
                td.ItemMainGrpCd = ItemMainGrpCd;
                td.Description = description;
                td.ActiveYN = true;
                td.EntryDate = DateTime.Now;
                td.UserCode = UserCode;
                tblitemsubgroups.Add(td);
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

        #region ===update Item Sub Group
        public int Update(int ID,int ItemMainGrpCd, string Name, bool ActiveYN)
        {
            tblitemsubgroup td = tblitemsubgroups.SingleOrDefault(p => p.Code == ID);
            try
            {
                td.Code = ID;
                td.ItemMainGrpCd = ItemMainGrpCd;
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

        #region === bind Item Main Group in DataGridView

        //public void BindList(DataGridView grd)
        //{
        //    try
        //    {
        //        var data = (from p in tblitemsubgroups

        //                    orderby p.Description
        //                    select new
        //                    {
        //                        code = p.Code,
        //                        ItemMainGrpCd=p.ItemMainGrpCd,
        //                        //ItemMainGrpNm = p.ItemMainGrpNm,
        //                        Name = p.Description,
        //                        ActiveYN = p.ActiveYN,

        //                    }
        //                    );
        //        var result = data.ToList();

        //        if (result != null)
        //        {
        //            grd.DataSource = null;
        //            grd.DataSource = result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

       

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblitemsubgroups
                            join mg in tblitemmaingroups on p.ItemMainGrpCd equals mg.Code

                             orderby mg.Description,p.Description
                          //  group mg by new { mg.Description, p.ItemMainGrpCd, p.Code, name = p.Description, p.ActiveYN } into g
                            select new
                            {
                                code = p.Code,
                                ItemMainGrpCd = p.ItemMainGrpCd,
                                ItemMainGrpNm = mg.Description,
                                Name = p.Description,
                                ActiveYN = p.ActiveYN

                            }

                            ).ToList();
                //var result = .ToList();

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

        #region === bind Item Sub Grp Main group wise
        public void BindDdlItemSubGrp_ItemMainGrpWise(ComboBox ddl,int ItemMainGrp)
        {
            try
            {

                var data = (from p in tblitemsubgroups
                            where p.ItemMainGrpCd == ItemMainGrp
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
        /// <summary>
        /// check for item sub  group in tblutems
        /// i means has value else 0
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        #region ===Item sub=main grop exists down the line
        public int ChkSubgrp(int ID)
        {
            try
            {
                var data = (from p in tblitems
                            where p.SubGroupCd == ID && p.ActiveYN == true
                            select p).ToList();
                if (data != null || data.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

    }
}
