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
    public partial class AddRate : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;

        SettingDAL objSettingDAL = new SettingDAL();
        public AddRate()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindTax();
            BindAccountGrid();
        }


        #region Propertise

        private int _ServiceId;
        public int ServiceId
        {
            get { return _ServiceId; }
            set { _ServiceId = value; }
        }

        #endregion


        #region Methods
        private void ClearForm()
        {
            txtRate.Text = string.Empty;
            txtServiceType.Text = string.Empty;
            dt_effective.Value = DateTime.Today;
            txtTimeExpende.Text = string.Empty;
            if (chkAllActive.Checked)
            {
                chkAllActive.Checked = false;
            }
            if (chk_Active.Checked)
            {
                chk_Active.Checked = false;
            }
            int count = chkTaxList.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chkTaxList.CheckedItems.Count > 0)
                {
                    chkTaxList.SetItemChecked(i, false);
                }
            }
        }
        private void BindTax()
        {
            chkTaxList.DataSource = objSettingDAL.GetAllTaxTypeForListbox(branchID);
            chkTaxList.DisplayMember = "Tax_Name";
            chkTaxList.ValueMember = "Tax_Id";
        }
        private bool ValidateForm()
        {
            if (txtServiceType.Text.Trim() == "")
            {
                MessageBox.Show("Please enter service Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtRate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter service rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtTimeExpende.Text.Trim() == "")
            {
                MessageBox.Show("Please enter time expende.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void BindAccountGrid()
        {
            grdServiceTypeList.AutoGenerateColumns = false;
            grdServiceTypeList.DataSource = objSettingDAL.GetAllServicesForServiceAndRateGrid(branchID);
            //grdServiceTypeList.DataSource = objSettingDAL.GetAllServiceByEfcDate(branchID);
        }
        #endregion

        #region Control Event Events
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
        private void grdServiceTypeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                {
                    int serviceId = default(int);
                    int.TryParse(Convert.ToString(grdServiceTypeList.Rows[e.RowIndex].Cells[0].Value), out serviceId);
                    DateTime date = default(DateTime);
                    DateTime.TryParse(Convert.ToString(grdServiceTypeList.Rows[e.RowIndex].Cells[3].Value), out date);
                    tblservice objService = objSettingDAL.GetAllServicesById(serviceId, branchID);
                    txtServiceType.Text = objService.ServiceName;
                    //txtRate.Text = objService.Amount.ToString();
                    //dt_effective.Value = Convert.ToDateTime(objService.Effective_Date);
                    if (Convert.ToBoolean(objService.IsActive))
                    {
                        chk_Active.Checked = true;
                    }
                    else
                    {
                        chk_Active.Checked = false;
                    }
                    /*----------------------------Rev By Sandip Das on 02-06-2016----------------------*/
                    txtTimeExpende.Text = Convert.ToString(objService.TimeExpende);
                    List<ServiceEL> objtblmapservice = objSettingDAL.GetRateAndEfcDateById(serviceId, date).ToList();
                    if (objtblmapservice.Count > 0)
                    {
                        txtRate.Text = Convert.ToString(objtblmapservice.FirstOrDefault().Amount);
                        dt_effective.Value = objtblmapservice.FirstOrDefault().Effective_Date == null ? Convert.ToDateTime(null) : Convert.ToDateTime(objtblmapservice.FirstOrDefault().Effective_Date);
                    }
                    int count = chkTaxList.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (chkTaxList.CheckedItems.Count > 0)
                        {
                            chkTaxList.SetItemChecked(i, false);
                        }
                    }
                    chkAllActive.Checked = false;

                    string[] searchId = (objService.TaxID == null ? null : objService.TaxID.Split(','));

                    if (searchId != null)
                    {
                        if (chkTaxList.Items.Count > 0)
                        {
                            for (int n = 0; n < chkTaxList.Items.Count; n++)
                            {
                                var row = chkTaxList.Items[n] as tbltaxmaster;
                                int Id = (int)row.Tax_Id;
                                //string name = (string)row.ServiceName;
                                if (searchId.Contains(Id.ToString()))
                                {
                                    chkTaxList.SetItemChecked(n, true);
                                }
                            }
                        }
                        if (chkTaxList.CheckedItems.Count == chkTaxList.Items.Count)
                        {
                            chkAllActive.Checked = true;
                        }
                    }

                    /*----------------------------End Rev By Sandip Das on 02-06-2016----------------------*/

                    ServiceId = serviceId;
                }
                else if (e.ColumnIndex == 7 && e.RowIndex >= 0)
                {
                    int serviceId = default(int);
                    int.TryParse(Convert.ToString(grdServiceTypeList.Rows[e.RowIndex].Cells[0].Value), out serviceId);
                    Boolean? status = objSettingDAL.GetStatusOfService(serviceId);
                    if (!(Boolean)status)
                    {
                        MessageBox.Show("This Service is already InActive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Service", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            bool IsDeleted = objSettingDAL.DeleteServicesById(serviceId, branchID);
                            if (IsDeleted)
                            {
                                MessageBox.Show("Deleted Successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                BindAccountGrid();
                            }
                            else
                            {
                                MessageBox.Show("Sorry! Server error. Please try again.");
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
        string tax = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool chkServiceExist = false;
                bool chkdrService = false;
                Boolean nameChk = false;
                tblservice ts = new tblservice();
                int i = 0;
                if (ValidateForm())
                {
                    if (ServiceId > 0)
                    {
                        /* -----------------Rev By Sandip Das On 01-06-2016---------------------------*/
                        tblservice objService = objSettingDAL.GetAllServicesById(ServiceId, branchID);

                        /* -----------------End---------------------------*/
                        objService.ServiceName = txtServiceType.Text.Trim();

                        if (chk_Active.Checked)
                        {
                            objService.IsActive = true;
                        }
                        else
                        {
                            objService.IsActive = false;
                        }
                        objService.TimeExpende = txtTimeExpende.Text.Trim() == "" ? Convert.ToInt32(null) : Convert.ToInt32(txtTimeExpende.Text.Trim());
                        if (chkAllActive.Checked)
                        {
                            List<string> TaxIdList = new List<string>();
                            tax = "";
                            foreach (var itemChecked in chkTaxList.CheckedItems)
                            {
                                var row = (itemChecked as tbltaxmaster);
                                int taxId = (int)row.Tax_Id;
                                tax += taxId + ",";
                            }
                            objService.TaxID = tax.TrimEnd(',');
                        }
                        else
                        {
                            List<string> TaxIdList = new List<string>();
                            tax = "";
                            foreach (var itemChecked in chkTaxList.CheckedItems)
                            {
                                var row = (itemChecked as tbltaxmaster);
                                int taxId = (int)row.Tax_Id;
                                tax += taxId + ",";
                            }
                            objService.TaxID = tax.TrimEnd(',');
                        }

                        /* -----------------Rev By Sandip Das On 01-06-2016---------------------------*/
                        nameChk = objSettingDAL.CheckServiceName(txtServiceType.Text.Trim(), branchID);
                        if (nameChk)
                        {
                            MessageBox.Show("Service Type Already Exist. Cannot continue ...");
                        }
                        /* -----------------End---------------------------*/
                        else
                        {
                            i = objSettingDAL.InsertUpdateSerivceAndRate(objService);

                            /*-----------------Rev By Sandip Das On 01-06-2016--------------------------*/
                            tblservicelog objtblservicelog = new tblservicelog()
                            {
                                FK_ServiceId = i,
                                ModifiedOn = Convert.ToDateTime(DateTime.Now.Date, CultureInfo.GetCultureInfo("en-US")),
                                ModifiedBy = AppsPropertise.UserDetails.UserId,
                            };
                            int l = objSettingDAL.InsertServiceLog(objtblservicelog);
                            tblmapservice objtblmapservice = new tblmapservice()
                            {
                                FK_ServiceId = i,
                                Amount = Convert.ToDecimal(txtRate.Text.Trim()),
                                EffectiveDate = Convert.ToDateTime(dt_effective.Value, CultureInfo.InvariantCulture),
                                FK_BranchId = branchID,
                            };
                            int m = objSettingDAL.InsertMapService(objtblmapservice);

                            /*-----------------End--------------------------*/

                            if (i > 0)
                            {
                                MessageBox.Show("Service updated successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ServiceId = 0;
                                BindAccountGrid();
                                ClearForm();
                            }
                        }
                    }
                    else
                    {
                        tblservice objService = new tblservice();
                        objService.ServiceName = txtServiceType.Text.Trim();
                        if (chk_Active.Checked)
                        {
                            objService.IsActive = true;
                        }
                        else
                        {
                            objService.IsActive = false;
                        }

                        objService.TimeExpende = txtTimeExpende.Text.Trim() == "" ? Convert.ToInt32(null) : Convert.ToInt32(txtTimeExpende.Text.Trim());
                        objService.FK_BranchID = AppsPropertise.UserDetails.BranchId;

                        if (chkAllActive.Checked)
                        {
                            List<string> TaxIdList = new List<string>();
                            tax = "";
                            foreach (var itemChecked in chkTaxList.CheckedItems)
                            {
                                var row = (itemChecked as tbltaxmaster);
                                int taxId = (int)row.Tax_Id;
                                tax += taxId + ",";
                            }
                            objService.TaxID = tax.TrimEnd(',');
                        }
                        else
                        {
                            List<string> TaxIdList = new List<string>();
                            tax = "";
                            foreach (var itemChecked in chkTaxList.CheckedItems)
                            {
                                var row = (itemChecked as tbltaxmaster);
                                int taxId = (int)row.Tax_Id;
                                tax += taxId + ",";
                            }
                            objService.TaxID = tax.TrimEnd(',');
                        }

                        chkServiceExist = objSettingDAL.CheckExistingService(txtServiceType.Text.Trim(), branchID, ServiceId);

                        if (objService.ServiceId > 0)
                        {
                            tblservice objService1 = objSettingDAL.GetAllServicesById(objService.ServiceId, branchID);
                            objService1.ServiceName = txtServiceType.Text.Trim();
                            if (chk_Active.Checked)
                            {
                                objService1.IsActive = true;
                            }
                            else
                            {
                                objService1.IsActive = false;
                            }
                            objService1.TimeExpende = Convert.ToInt32(txtTimeExpende.Text.Trim());
                            objService1.FK_UserId = AppsPropertise.UserDetails.UserId; ;
                            objService1.FK_BranchID = AppsPropertise.UserDetails.BranchId;
                            i = objSettingDAL.InsertUpdateSerivceAndRate(objService1);
                        }
                        else
                        {
                            i = objSettingDAL.InsertUpdateSerivceAndRate(objService);
                        }

                        /*-----------------Rev By Sandip Das On 01-06-2016-------------------------*/
                        tblservicelog objtblservicelog = new tblservicelog()
                        {
                            FK_ServiceId = i,
                            CreatedOn = Convert.ToDateTime(DateTime.Now.Date, CultureInfo.GetCultureInfo("en-US")),
                            CreatedBy = AppsPropertise.UserDetails.UserId,
                        };
                        int l = objSettingDAL.InsertServiceLog(objtblservicelog);
                        tblmapservice objtblmapservice = new tblmapservice()
                        {
                            FK_ServiceId = i,
                            Amount = Convert.ToDecimal(txtRate.Text.Trim()),
                            EffectiveDate = Convert.ToDateTime(dt_effective.Value, CultureInfo.InvariantCulture),
                            FK_BranchId = branchID,
                        };
                        int m = objSettingDAL.InsertMapService(objtblmapservice);
                        /*-----------------End--------------------------*/


                        if (i > 0 && l > 0 && m > 0)
                        {
                            MessageBox.Show("Service added successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            BindAccountGrid();
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        #endregion

        #region Extra Code Start
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddRate_Load(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void radio_others_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion Extra Code End

        private void chkTaxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkTaxList.CheckedItems.Count == chkTaxList.Items.Count)
            {
                chkAllActive.Checked = true;
            }
            else
            {
                chkAllActive.Checked = false;
            }
        }

        private void chkAllActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllActive.Checked)
            {
                tax = "";
                for (int n = 0; n < chkTaxList.Items.Count; n++)
                {
                    chkTaxList.SetItemChecked(n, true);
                }
            }
            else
            {
                if (chkTaxList.CheckedItems.Count < chkTaxList.Items.Count)
                {
                    chkAllActive.Checked = false;
                }
                else
                {
                    tax = "";
                    for (int n = 0; n < chkTaxList.Items.Count; n++)
                    {
                        chkTaxList.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void txtTimeExpende_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void btnImportService_Click(object sender, EventArgs e)
        {
            ImportService importService = new ImportService();
            importService.Show();
        }

        private void dt_effective_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dt_effective.Value.Date < DateTime.Today.Date)
            //    {
            //        MessageBox.Show("Date should not be less than todays date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dt_effective.Value = DateTime.Today.Date;
            //    }
            //}
            //catch (Exception) { }
        }
    }
}

































