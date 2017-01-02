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
    public class BranchDAL : SpaPracticeEntities
    {

        #region === insert data in branch
        public int BranchInsert(string BrCode,string BrName,string BRAdress,string BrCnctno, string BrEmail,bool Headoffice)
        {
            tblbranch br = new tblbranch();
            try
            {
                int code;
                 var BRValue=   tblbranches.Max(i => i.BranchID);
                 if (BRValue == 0)
                 {
                     code = 1;

                 }
                 else
                 {
                     code = Int32.Parse(BRValue.ToString());
                     code = code + 1;
                 }
                br.BranchID = code;
                br.BranchCode = BrCode;
                br.BranchName = BrName;
                br.Address = BRAdress;
                br.ContactNo = BrCnctno;
                br.Email = BrEmail;
                br.ActiveYN = true;
                br.HeadOfficeYN = true;
                tblbranches.Add(br);
                SaveChanges();
                return code;
            }

            catch (Exception ex)
            {
                return 0;
            }
           
        }
        #endregion

        #region ===update branchbramch
        public int BranchUpdate(int BrID, string BrCode, string BrName, string BRAdress, string BrCnctno, string BrEmail, bool headoffice, bool ActiveYN)
        {
            tblbranch br = tblbranches.SingleOrDefault(p => p.BranchID == BrID);
            try
            {
                br.BranchCode = BrCode;
                br.BranchName = BrName;
                br.Address = BRAdress;
                br.ContactNo = BrCnctno;
                br.Email = BrEmail;
                br.ActiveYN = ActiveYN;
                //tblbranches.Add(br);

                SaveChanges();

                return BrID;

            }

            catch (Exception ex)
            {
                return 0;
            }
            
        }
        #endregion

        #region === bind Branch in DataGridView

        public void BindList(DataGridView grdBranch)
        {
            try
            {

                //List<tblbranch> servicelist = new List<tblbranch>();
                var data = (from p in tblbranches

                            orderby p.BranchName
                            select new
                            {
                                BranchId = p.BranchID,
                                Branchcode = p.BranchCode,
                                BranchName = p.BranchName,
                                Name = p.BranchName,
                                Address = p.Address,
                                ContactNo = p.ContactNo,
                                Email = p.Email,
                                Headoffice = p.HeadOfficeYN,
                                ActiveYN = p.ActiveYN

                            }
                            );
                var result = data.ToList();

                if (result != null)
                {
                    grdBranch.DataSource = null;
                    grdBranch.DataSource = result;
                }
            }
            catch (Exception ex)
            {

            }
        }
        //public void BindList(DataGridView grdBranch)
        //{
        //    try
        //    {


        //        var data = (from p in tblbranches
        //                    orderby p.BranchName
        //                    select p
        //                   );

        //        List<tblbranch> servicelist = data.ToList();

        //        if (servicelist != null)
        //        {
        //            grdBranch.DataSource = null;
        //            grdBranch.DataSource = servicelist;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        #endregion

        #region === Validation
        public bool isEmailExist(string Email)
        {
            var EmailDetails = tblbranches.Where(x => x.Email.Trim().ToUpper() == Email).FirstOrDefault();

            if (EmailDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region === Bind bBranch in checkboxlist
        public void BindBranch(ListBox chkBranch)
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
                if (servicelist != null)
                {
                    //chkBranch.Items.Clear();
                    chkBranch.DataSource = servicelist;
                    chkBranch.DisplayMember = "BranchName";
                    chkBranch.ValueMember = "BranchCode";
                   
                   
                   // chkBranch.SelectedIndex = -1;
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
