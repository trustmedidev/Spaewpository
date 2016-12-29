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
    public class BrandDAL : SpaPracticeEntities
    {
        #region === insert data in brand
        public int Insert(string description, int UserCode)
        {
            tblbrand bn = new tblbrand();
            try
            {
                int code;
                var BNValue = tblbrands.Max(i => (int?)i.Code).GetValueOrDefault();
                if (BNValue == 0)
                {
                    code = 1;

                }
                else
                {
                    code = Int32.Parse(BNValue.ToString());
                    code = code + 1;
                }
                bn.Code = code;
                bn.Description = description;
                bn.ActiveYN = true;
                bn.EntryDate = DateTime.Now;
                bn.UserCode = UserCode;
                tblbrands.Add(bn);
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

        #region ===update brand
        public int Update(int BnID,  string BnName, bool ActiveYN)
        {
            tblbrand bn = tblbrands.SingleOrDefault(p => p.Code == BnID);
            try
            {
                bn.Code = BnID;
                bn.Description = BnName;
                bn.ActiveYN = ActiveYN;

                SaveChanges();

                return BnID;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region === bind Brand in DataGridView

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblbrands 

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

    }
}
