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
    public class BatchDAL : SpaPracticeEntities
    {

        #region === insert data in Batch
        public int Insert(string BatchNo, int ItemCd, decimal Rate, DateTime ExpiryDate, string description, int UserCode)
        {
            tblbatch dt = new tblbatch();
            try
            {
                int code;
                var BNValue = tblbatches.Max(i => (int?)i.Code).GetValueOrDefault();
                if (BNValue == 0)
                {
                    code = 1;

                }
                else
                {
                    code = Int32.Parse(BNValue.ToString());
                    code = code + 1;
                }
                dt.Code = code;
                dt.BatchNo = BatchNo;
                dt.ItemCd = ItemCd;
                dt.Rate = Rate;
                dt.ExpiryDate = ExpiryDate;
                dt.Description = description;
                dt.ActiveYN = true;
                dt.EntryDate = DateTime.Now;
                dt.UserCode = UserCode;
                tblbatches.Add(dt);
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

        #region ===update batch
        public int Update(int BnID, string BatchNo, int ItemCd, decimal Rate, DateTime ExpiryDate, string description, bool ActiveYN)
        {
            tblbatch dt = tblbatches.SingleOrDefault(p => p.Code == BnID);
            try
            {
                dt.Code = BnID;
                dt.BatchNo = BatchNo;
                dt.ItemCd = ItemCd;
                dt.Rate = Rate;
                dt.ExpiryDate = ExpiryDate;
                dt.Description = description;
                dt.ActiveYN = ActiveYN;

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

        #region === bind batch in DataGridView

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblbatches
                            join it in tblitems on p.ItemCd equals it.Code
                            orderby it.Description, p.ExpiryDate
                            select new
                            {
                                code = p.Code,
                                ItemName = it.Description,
                                BatchNo = p.BatchNo,
                                ItemCd = p.ItemCd,
                                Rate = p.Rate,
                                ExpiryDate = p.ExpiryDate,
                                description = p.Description,
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

        //public void BindList(DataGridView grd)
        //{
        //    try
        //    {
        //        var data = (from p in tblbatches

        //                    orderby p.Description
        //                    select new
        //                    {
        //                        code = p.Code,
        //                        BatchNo=p.BatchNo,
        //                        ItemCd=p.ItemCd,
        //                        Rate=p.Rate,
        //                        ExpiryDate=p.ExpiryDate,
        //                        description=p.Description,
        //                        Name = p.Description,
        //                        ActiveYN = p.ActiveYN

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

        #endregion
    }
}
