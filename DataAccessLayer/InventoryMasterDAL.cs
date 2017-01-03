using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using EntityLayer;
using System.Data.Entity.Core.Objects;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;
namespace DataAccessLayer
{
    public class InventoryMasterDAL : SpaPracticeEntities
    {

        /// <summary>
        /// For performing godown operations
        /// </summary>
        /// <param name="ddlBranch"></param>
        #region === bind branch
        public void BindBranch(ComboBox ddlBranch)
        {
            try
            {
                //List<tblbranch> servicelist = new List<tblbranch>();
                var data = (from p in tblbranches
                            select new
                            {
                                BranchCode = p.BranchID,
                                BranchName = p.BranchName


                            });
                var servicelist = data.ToList();
                if (servicelist != null  )
                {
                    //ddlBranch.Items.Clear();
                    ddlBranch.DataSource = null;
                    ddlBranch.ValueMember = "BranchCode";
                    ddlBranch.DisplayMember = "BranchName";
                    ddlBranch.DataSource = servicelist;
                    ddlBranch.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region insert operation in godown
        public int InsertGodown(int BranchCode,string description, bool MainGodown,int UserCode)
        {
            tblgodown gd = new tblgodown();

            try
            {
                int code;
                var CodeValue = tblgodowns.Max(i => (int?)i.Code).GetValueOrDefault();
                if (CodeValue == 0)
                {
                    code = 1;

                }
                else
                {
                    code = Int32.Parse(CodeValue.ToString());
                    code = code + 1;
                }
                gd.Code = code;
                gd.BranchCd = BranchCode;
                gd.Description = description;
                gd.MainGodown = MainGodown;
                gd.ACTIVEYN = true;
                gd.EntryDate = DateTime.Now;
                gd.UserCode = UserCode;
                tblgodowns.Add(gd);
                SaveChanges();
                return gd.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region === update godown
        public int UpdateGodown(int Code,int BranchCode, string description, bool MainGodown, int UserCode,bool Activeyn)
        {
           // tblgodown gd = new Repository.tblgodown();
            tblgodown gd = tblgodowns.SingleOrDefault(p => p.Code == Code);
            try
            {

               
                gd.BranchCd = BranchCode;
                gd.Description = description;
                gd.MainGodown = MainGodown;
                gd.ACTIVEYN = Activeyn;
                gd.EntryDate = DateTime.Now;
                gd.UserCode = UserCode;
              
                SaveChanges();
                return gd.Code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            


        }
        #endregion

        #region === bind godown in datagrid
        //public void BindList(DataGrid grdGodown, int BranchID,bool ISAdmin)
        //{
        //    try
        //    {
        //        List<tblgodown> servicelist = new List<tblgodown>();
        //        if (!ISAdmin)
        //        {
        //            var data = (from p in tblgodowns.Where(p => p.BranchCd == BranchID)
        //                        orderby p.Description
        //                        select p
        //                       ).ToList();
        //        }
        //        else
        //        {
        //            var data = (from p in tblgodowns
        //                        orderby p.Description
        //                        select p
        //                       ).ToList();
        //        }
        //        if (servicelist != null)
        //        {
        //            grdGodown.DataSource = null;
        //            grdGodown.DataSource = servicelist;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        #endregion

        #region === bind Branch in DataGridView

        public void BindList(DataGridView grdGodown)
        {
            try
            {
                var data = (from p in tblgodowns
                            join Bn in tblbranches on p.BranchCd equals Bn.BranchID
                            into B1
                            from Bn in B1.DefaultIfEmpty()
                            orderby Bn.BranchName,p.Description
                            select new
                            {
                                GodownCd = p.Code,
                                GodownNm = p.Description,
                                BranchCd=p.BranchCd,
                                BranchNm=Bn.BranchName,
                                ActiveYN = p.ACTIVEYN

                            }
                            );
                var result = data.ToList();

                if (result != null)
                {
                    grdGodown.DataSource = null;
                    grdGodown.DataSource = result;
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        #endregion
        #region === bind Item Main Grp
        public void BindDdlGodown(ComboBox ddl)
        {
            try
            {

                var data = (from p in tblgodowns 
                            where p.ACTIVEYN == true
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

    }
}
