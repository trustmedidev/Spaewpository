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
    public class SuppliorDAL : SpaPracticeEntities
    {
        #region === insert data in Supplior
        public int Insert(string description, string Address, string Mobile, string Email, string CaseHistory, int UserCode)
        {
            tblsupplior  td = new tblsupplior();
            try
            {
                int code;
                var CdValue = tblsuppliors.Max(i => (int?)i.Code).GetValueOrDefault();
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
                td.Address= Address;
                td.Mobile = Mobile;
                td.Email = Email;
                td.CaseHistory = CaseHistory;
                td.ACTIVEYN = true;
                td.EntryDate = DateTime.Now;
                td.UserCode = UserCode;
                tblsuppliors.Add(td);
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

        #region ===update Supplior
        public int Update(int ID, string Name, string Address, string Mobile, string Email, string CaseHistory, bool ActiveYN)
        {
            tblsupplior  td = tblsuppliors.SingleOrDefault(p => p.Code == ID);
            try
            {
                td.Code = ID;
                td.Description = Name;
                td.Address = Address;
                td.Mobile = Mobile;
                td.Email = Email;
                td.CaseHistory = CaseHistory;
                td.ACTIVEYN = ActiveYN;

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

        #region === bind Supplior in DataGridView

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblsuppliors

                            orderby p.Description
                            select new
                            {
                                code = p.Code,
                                Name = p.Description,
                                Address = p.Address,
                                Mobile = p.Mobile,
                                Email = p.Email,
                                CaseHistory = p.CaseHistory,
                                ActiveYN = p.ACTIVEYN

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

        #region === bind Supplior
        public void BindDdlSupplior(ComboBox ddl)
        {
            try
            {

                var data = (from p in tblsuppliors
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
