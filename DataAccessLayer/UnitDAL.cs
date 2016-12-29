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
    public class UnitDAL : SpaPracticeEntities
    {
        #region === insert data in Unit
        public int Insert(string description, int UserCode)
        {
            tblunit td = new tblunit();
            try
            {
                int code;
                var CdValue = tblunits.Max(i => (int?)i.Code).GetValueOrDefault();
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
                td.ACTIVEYN = true;
                td.EntryDate = DateTime.Now;
                td.UserCode = UserCode;
                tblunits.Add(td);
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

        #region ===update Unit
        public int Update(int ID, string Name, bool ActiveYN)
        {
            tblunit td = tblunits.SingleOrDefault(p => p.Code == ID);
            try
            {
                td.Code = ID;
                td.Description = Name;
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

        #region === bind Unit in DataGridView

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblunits

                            orderby p.Description
                            select new
                            {
                                code = p.Code,
                                Name = p.Description,
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

        #region === bind Unit
        public void BindDdlUnitGrp(ComboBox ddl)
        {
            try
            {

                var data = (from p in tblunits
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
