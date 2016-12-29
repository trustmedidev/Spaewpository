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
using EntityLayer;

namespace SPAPracticeManagement.Settings
{
    public partial class TaxConfiguration : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;

        TaxConfigurationDAL ObjTaxConfiguration = new TaxConfigurationDAL();
        public TaxConfiguration()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindAccountGrid();
        }

        #region Propertise

        private int _Taxid;
        public int Taxid
        {
            get { return _Taxid; }
            set { _Taxid = value; }
        }

        #endregion

        #region Bind Method Start
        private void BindAccountGrid()
        {
            grdCoupon.AutoGenerateColumns = false;
            grdCoupon.DataSource = ObjTaxConfiguration.GetAllTaxTypeForGrid(branchID);
        }

        #endregion Bind Method End


        #region Clear Method Start
        private void ClearForm()
        {
            txt_Rate.Text = string.Empty;
            txt_TaxType.Text = string.Empty;
            chk_Active.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }
        #endregion Clear Method End

        #region Control Function Strat
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
        private void grdCoupon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 5 && e.RowIndex >= 0)
                {
                    int id = default(int);
                    DateTime date=default(DateTime);
                    int.TryParse(Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[0].Value), out id);
                    DateTime.TryParse(Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[3].Value), out date);
                    tbltaxmaster Objtbltaxmaster = ObjTaxConfiguration.GetAllTaxTypeById(id, branchID);
                    txt_TaxType.Text = Convert.ToString(Objtbltaxmaster.Tax_Name);
                    //txt_Rate.Text = Convert.ToString(Objtbltaxmaster.Tax_Rate);
                    //dateTimePicker1.Value = Convert.ToDateTime(Objtbltaxmaster.EffectiveDate);
                    if (Objtbltaxmaster.IsActive == true)
                    {
                        chk_Active.Checked = true;
                    }
                    else
                    {
                        chk_Active.Checked = false;
                    }

                    /*----------------------------Rev By Sandip Das on 02-06-2016----------------------*/
                    TaxConfigurationEL objtblmaptax = ObjTaxConfiguration.GetRateAndEfcDateById(id, date);
                    txt_Rate.Text = Convert.ToString(objtblmaptax.Tax_Rate);
                    dateTimePicker1.Value = Convert.ToDateTime(objtblmaptax.EffectiveDate);
                    /*----------------------------Rev By Sandip Das on 02-06-2016----------------------*/

                    Taxid = id;
                }
                else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                {
                    string active=Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[4].Value);
                    if(active=="False")
                    {
                        MessageBox.Show("Tax Detail is already In-Active !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Coupon", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int serviceId = default(int);
                        int.TryParse(Convert.ToString(grdCoupon.Rows[e.RowIndex].Cells[0].Value), out serviceId);
                        bool IsDeleted = ObjTaxConfiguration.DeleteTaxTypeById(serviceId, branchID);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool chkServiceExist = false;
                Boolean nameChk = false;
                int i = 0;
                if (ValidateForm())
                {
                    if (Taxid > 0)
                    {
                        tbltaxmaster Objtbltaxmaster = new tbltaxmaster();
                        Objtbltaxmaster = ObjTaxConfiguration.GetAllTaxTypeById(Taxid, branchID);
                        Objtbltaxmaster.Tax_Name = txt_TaxType.Text.Trim();
                        //Objtbltaxmaster.Tax_Rate = Convert.ToDecimal(txt_Rate.Text.Trim());
                        //Objtbltaxmaster.EffectiveDate = Convert.ToDateTime(dateTimePicker1.Value, CultureInfo.GetCultureInfo("en-US"));
                        if (chk_Active.Checked == true)
                        {
                            Objtbltaxmaster.IsActive = true;
                        }
                        else
                        {
                            Objtbltaxmaster.IsActive = false;
                        }

                        //chkServiceExist = ObjTaxConfiguration.CheckExistingTaxType(txt_TaxType.Text.Trim(), branchID, Taxid);

                        /* -----------------Rev By Sandip Das On 01-06-2016---------------------------*/
                        //nameChk = ObjTaxConfiguration.CheckTaxName(txt_TaxType.Text.Trim(), branchID);
                        //if (nameChk)
                        //{
                        //    MessageBox.Show("Tax Type Already Exist. Cannot continue ...");
                        //}
                        /* -----------------End---------------------------*/

                        //if (chkServiceExist)
                        //{
                        //    MessageBox.Show("Tax Type name already exist");
                        //    return;
                        //}
                        //else
                        //{
                            i = ObjTaxConfiguration.InsertUpdateTaxType(Objtbltaxmaster);
                            /* -----------------Rev By Sandip Das On 01-06-2016---------------------------*/
                            tbltaxlog objtbltaxlog = new tbltaxlog()
                            {
                                FK_TaxID = i,
                                ModifiedOn=Convert.ToDateTime(DateTime.Now.Date, CultureInfo.GetCultureInfo("en-US")),
                                ModifiedBy=AppsPropertise.UserDetails.UserId,
                            };
                            int log = ObjTaxConfiguration.InsertTaxLog(objtbltaxlog);
                            tblmaptax objtbl_maptax = new tblmaptax
                            {
                                FK_TaxId = i,
                                TaxRate = Convert.ToDecimal(txt_Rate.Text.Trim()),
                                EffectiveDate = Convert.ToDateTime(dateTimePicker1.Value, CultureInfo.GetCultureInfo("en-US")),
                            };
                            int m = ObjTaxConfiguration.InsertMapTax(objtbl_maptax);
                            /* -----------------End---------------------------*/
                            if (i > 0)
                            {
                                MessageBox.Show("Tax Detail updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Taxid = 0;
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
                        tbltaxmaster Objtbltaxmaster = new tbltaxmaster()
                       {
                           Tax_Name = txt_TaxType.Text.Trim(),
                           //Tax_Rate = Convert.ToDecimal(txt_Rate.Text.Trim()),
                           IsActive = chk,
                           FK_BranchID = AppsPropertise.UserDetails.BranchId,
                           //EffectiveDate=Convert.ToDateTime(dateTimePicker1.Value, CultureInfo.GetCultureInfo("en-US")),
                       };                       

                        chkServiceExist = ObjTaxConfiguration.CheckExistingTaxType(txt_TaxType.Text.Trim(), branchID, Taxid);
                        if (chkServiceExist)
                        {
                            MessageBox.Show("Tax Type already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            i = ObjTaxConfiguration.InsertUpdateTaxType(Objtbltaxmaster);
                            /* -----------------Rev By Sandip Das On 01-06-2016---------------------------*/
                            tbltaxlog objtbltaxlog = new tbltaxlog()
                        {
                            FK_TaxID=i,
                            CreatedOn=Convert.ToDateTime(DateTime.Now.Date,CultureInfo.GetCultureInfo("en-US")),
                            CreatedBy=AppsPropertise.UserDetails.UserId,
                        };
                            int log = ObjTaxConfiguration.InsertTaxLog(objtbltaxlog);

                            tblmaptax objtbl_maptax = new tblmaptax
                            {
                                FK_TaxId = i,
                                TaxRate = Convert.ToDecimal(txt_Rate.Text.Trim()),
                                EffectiveDate = Convert.ToDateTime(dateTimePicker1.Value, CultureInfo.GetCultureInfo("en-US")),
                            };
                            int m = ObjTaxConfiguration.InsertMapTax(objtbl_maptax);
                            /* -----------------End---------------------------*/
                            if (i > 0)
                            {
                                MessageBox.Show("Tax added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion Control Function End

        #region Form Validation Start
        private bool ValidateForm()
        {
            if (txt_TaxType.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_Rate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }
        #endregion Form Validation End

        #region Extra Code Start
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }
        private void radio_others_CheckedChanged(object sender, EventArgs e)
        {
        }
       /*--------------------------------------Rev By Sandip Das on 02-06-2016-------------------------------------*/
        private void txt_Validity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Rate.Text.Trim()))
                {
                    if (Convert.ToInt32(txt_Rate.Text) > 100)
                    {
                        MessageBox.Show("Rate should be less than 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Rate.Text = string.Empty;
                    }
                }
            }
            catch (Exception) { }
        }
        /*--------------------------------------End Rev By Sandip Das on 02-06-2016-------------------------------------*/
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }



    }
}

































