using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.AppConstants;
using DataAccessLayer.Repository;
using System.Globalization;
using DataAccessLayer;
using SPAPracticeManagement.Client;
using SPAPracticeManagement.Appointments;

namespace SPAPracticeManagement.Settings
{
    public partial class GiftCoupon : Dashboard
    {
      int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        CouponDAL ObjCoupanDAL = new CouponDAL();
        public GiftCoupon()
        {
            InitializeComponent();
            string couponid = "CPN-" + DateTime.Now.ToString("yyMMdd-HHMMss");
            txt_CouponId.Text = couponid;
            txt_CouponId.Enabled = false;
             this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindAccountGrid();
        }


        #region Propertise
        private int _CouponId;
        public int CouponId
        {
            get { return _CouponId; }
            set { _CouponId = value; }
        }
        #endregion 

        #region Bind Methods Start

        private void BindAccountGrid()
        {
            grdCoupon.AutoGenerateColumns = false;
            grdCoupon.DataSource = ObjCoupanDAL.GetAllCouponForGrid(branchID);
        } 

        #endregion Bind Method End

        #region Control Event Start
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                bool chkServiceExist = false;
                bool chkdrService = false;
                int i = 0;
                if (ValidateForm())
                {
                    if (CouponId > 0)
                    {

                        tblcoupanmaster Objtblcoupanmaster = new tblcoupanmaster();
                        Objtblcoupanmaster = ObjCoupanDAL.GetAllCouponById(CouponId, branchID);
                        Objtblcoupanmaster.Coupan_Name = txt_CouponName.Text.Trim();
                        Objtblcoupanmaster.Coupon_Amt = Convert.ToDecimal(txt_CouponAmt.Text.Trim());
                        Objtblcoupanmaster.Coupan_SDateVld = Convert.ToDateTime(dateTimePicker3.Value, CultureInfo.InvariantCulture);
                        //Objtblcoupanmaster.Coupan_SDateVld = Convert.ToDateTime(dateTimePicker3.Value);
                        Objtblcoupanmaster.Coupan_NoOfUser = Convert.ToInt32(txt_UserNo.Text.Trim());
                        if (chk_Active.Checked == true)
                        {
                            Objtblcoupanmaster.IsActive = true;
                        }
                        else
                        {
                            Objtblcoupanmaster.IsActive = false;
                        }

                        //chkServiceExist = ObjCoupanDAL.CheckExistingCoupon(txt_CouponName.Text.Trim(), branchID, CouponId);

                        //if (chkServiceExist)
                        //{
                        //    MessageBox.Show("Coupon name already exist","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        //    return;
                        //}
                        //else
                        //{
                            i = ObjCoupanDAL.InsertUpdateCoupon(Objtblcoupanmaster);

                            if (i > 0)
                            {
                                MessageBox.Show("Coupon Detail updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CouponId = 0;
                                BindAccountGrid();
                                ClearForm();
                            }
                        //}
                    }
                    else
                    {
                        bool chk = false;
                        if (chk_Active.Checked == true)
                        {
                            chk = true;
                        }
                        else
                        {
                            chk = false;
                        }
                        tblcoupanmaster Objtblcoupanmaster = new tblcoupanmaster()
                        {

                            Coupon_Id = txt_CouponId.Text.Trim(),
                            Coupan_Name = txt_CouponName.Text.Trim(),
                            Coupon_Amt = Convert.ToDecimal(txt_CouponAmt.Text.Trim()),
                            Coupan_Validity = Convert.ToInt32(txt_Validity.Text.Trim()),
                            Coupan_SDateVld = Convert.ToDateTime(dateTimePicker3.Value, CultureInfo.InvariantCulture),
                            Coupan_NoOfUser = Convert.ToInt32(txt_UserNo.Text.Trim()),
                            IsActive = chk,
                            FK_BranchID = AppsPropertise.UserDetails.BranchId
                        };

                        chkServiceExist = ObjCoupanDAL.CheckExistingCoupon(txt_CouponName.Text.Trim(), branchID, CouponId);
                        //}
                        if (chkServiceExist)
                        {
                            MessageBox.Show("Coupon name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            i = ObjCoupanDAL.InsertUpdateCoupon(Objtblcoupanmaster);
                            if (i > 0)
                            {
                                MessageBox.Show("Coupon added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindAccountGrid();
                                ClearForm();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void grdCoupon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {
                    int couponId = default(int);
                    int.TryParse(Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[0].Value), out couponId);
                    tblcoupanmaster Objtblcoupanmaster = ObjCoupanDAL.GetAllCouponById(couponId, branchID);
                    txt_CouponId.Text = Objtblcoupanmaster.Coupon_Id;
                    txt_CouponName.Text = Objtblcoupanmaster.Coupan_Name;
                    int amt = Convert.ToInt32(Objtblcoupanmaster.Coupon_Amt);
                    txt_CouponAmt.Text = Convert.ToString(amt);
                    txt_Validity.Text = Convert.ToString(Objtblcoupanmaster.Coupan_Validity);
                    dateTimePicker3.Text = Convert.ToString(Objtblcoupanmaster.Coupan_SDateVld.Value.Date);
                    txt_UserNo.Text = Convert.ToString(Objtblcoupanmaster.Coupan_NoOfUser);
                    if (Objtblcoupanmaster.IsActive == true)
                    {
                        chk_Active.Checked = true;
                    }
                    else
                    {
                        chk_Active.Checked = false;
                    }


                    CouponId = couponId;
                }
                else if (e.ColumnIndex == 9 && e.RowIndex >= 0)
                {
                    string active=Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[7].Value);
                    if(active=="False")
                    {
                        //MessageBox.Show("Coupon is already blocked");
                        MessageBox.Show("This Coupon Is Already In-Active !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Coupon", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int serviceId = default(int);
                        int.TryParse(Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[0].Value), out serviceId);
                        bool IsDeleted = ObjCoupanDAL.DeleteCouponsById(serviceId, branchID);
                        if (IsDeleted)
                        {
                            MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindAccountGrid();
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Server error. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion Control Event Start

        #region Clear Form Start 
        private void ClearForm()
        { 
            string couponid = "CPN-" + DateTime.Now.ToString("yyMMdd-HHMMss");
            txt_CouponId.Text = couponid;
            txt_CouponId.Enabled = false;
            txt_CouponAmt.Text = string.Empty;
            txt_Validity.Text = string.Empty;
            dateTimePicker3.Text = DateTime.Today.ToShortDateString();
            txt_CouponName.Text = string.Empty;
            txt_UserNo.Text = string.Empty;
            chk_Active.Checked = false;
        }

        #endregion Clear Form Start 

        #region Validation Form Start

        private bool ValidateForm()
        { 
            if (txt_CouponName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Coupon Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (txt_CouponAmt.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Coupon Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_Validity.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Days Validity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (txt_UserNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Number of Use.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void txt_Validity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        } 
        private void txt_UserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        } 
        private void txt_CouponAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        } 
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        #endregion Validation Form End 

        #region Extra Code Start
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        } 
        private void radio_others_CheckedChanged(object sender, EventArgs e)
        {

        } 
        private void txt_Validity_TextChanged(object sender, EventArgs e)
        { 
        } 
        private void txt_UserNo_TextChanged(object sender, EventArgs e)
        { 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        } 
        private void AddRate_Load(object sender, EventArgs e)
        {

        } 
        private void label5_Click(object sender, EventArgs e)
        {

        }
        #endregion Extra Code End



    }
}




 
          
        
        

      
       

       


       

        

       
         

       

      

        

        

        

        
