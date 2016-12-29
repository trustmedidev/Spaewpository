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
    public class ServiceDAL : SpaPracticeEntities
    {
        List<int> r = new List<int>();
        public void InsertImportSerivceAndTime(List<tblservice> objService)
        {
            try
            {
                SpaPracticeEntities context = new SpaPracticeEntities();

                foreach (tblservice tls in objService)
                {
                    context.tblservices.Add(tls);
                    context.SaveChanges();
                    r.Add(tls.ServiceId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void InsertImportRateAndEffectiveDate(List<tblmapservice> objMapService)
        {
            try
            {
                SpaPracticeEntities context = new SpaPracticeEntities();

                    int i=0;
                    foreach (tblmapservice tls in objMapService)
                    {
                        while (i < r.Count)
                        {
                            tls.FK_ServiceId = (r[i] == 0 ? 0 : r[i]);
                            context.tblmapservices.Add(tls);
                            context.SaveChanges();
                            break;
                        }
                        i++;
                    }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region === bind Service
        public void BindDdlService(ComboBox ddl)
        {
            try
            {

                var data = (from p in tblservices
                            select new
                            {
                                Code = p.ServiceId,
                                Name = p.ServiceName


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
