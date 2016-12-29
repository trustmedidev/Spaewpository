using DataAccessLayer;
using DataAccessLayer.Repository;
using EntityLayer;
using SPAPracticeManagement.AppConstants;
using System;
using System.Windows.Forms;
using System.Globalization;
using EntityLayer;
using System.Linq;
using System.Collections.Generic;

namespace SPAPracticeManagement.Settings
{
    public partial class Packages : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        SettingDAL ObjSettingDAL = new SettingDAL();
        PackageDAL ObjPackageDAL = new PackageDAL();
        PackageEL objPackageEL = new PackageEL();
        private int _UpdatePackageId;
        public int UpdatePackageID
        {
            get { return _UpdatePackageId; }
            set { _UpdatePackageId = value; }
        }
        public Packages()
        {
            InitializeComponent();
            txt_PackageId.Text = "";
            string packageid = "PKG-" + DateTime.Now.ToString("yyMMdd-HHMMss");
            txt_PackageId.Text = packageid;
            txt_PackageId.Enabled = false;
            bindPackageItemList();
            BindPackageGrid();
            BindTax();
        }

        #region Bind Method Start
        private void bindPackageItemList()
        {
            ObjSettingDAL.GetAllServicesForGrid(branchID);
            tblservice Objtblservice = new tblservice();
            {
                chklst_PackageItem.DataSource = ObjSettingDAL.GetAllServicesForGrid(branchID); ;
                chklst_PackageItem.DisplayMember = "ServiceName";
                chklst_PackageItem.ValueMember = "ServiceId";

            }
        }
        private void BindPackageGrid()
        { 
            gvPackageList.AutoGenerateColumns = false;
            gvPackageList.DataSource = ObjPackageDAL.GetListOfPackages(branchID); 
        }

        #endregion Bind Method End

        #region Clear Method Start
        private void clearData()
        {
            txt_PackageId.Text = string.Empty;
            string packageid = "PKG-" + DateTime.Now.ToString("yyMMdd-HHMMss");
            txt_PackageId.Text = packageid;
            txt_PackageId.Enabled = false;
            txt_PackageName.Text = string.Empty;
            dt_validity.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //txt_Validity.Text = string.Empty;
            txt_Rate.Text = string.Empty;
            bindPackageItemList();
            BindPackageGrid();
            while (chklst_PackageItem.CheckedIndices.Count > 0)
            {
                chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
            }
            lbl_totalamount.Text = "Total Amount: ";
            if(chk_Active.Checked)
            {
                chk_Active.Checked = false;
            }
            if (chkAllActive.Checked)
            {
                chkAllActive.Checked = false;
            }
            if(btnPackage.Text=="Update")
            {
                btnPackage.Text = "Save";
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

        #endregion Clear Method End

        #region  crud operation Start
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
        private void btnPackage_Click(object sender, EventArgs e)
        {
            SaveClient();
        }


        //string dateString = "20/5/2015";
        //DateTime date = Convert.ToDateTime(dateString, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
        private bool SaveClient()
        {
            if (ValidateForm())
            {
                tblpackage Objtblpackage = new tblpackage();
                string dt = Convert.ToString(DateTime.Today);

                //if (UpdatePackageID != 0)
                if (btnPackage.Text == "Update")
                {
                    bool IsExist = ObjPackageDAL.IsExistedPackageID(Convert.ToString(txt_PackageId.Text.Trim()), txt_PackageName.Text.Trim(), branchID);
                    if (IsExist)
                    {
                        txt_PackageName.Text = string.Empty;
                        MessageBox.Show("Package Name can not be Duplicate!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    Objtblpackage = ObjPackageDAL.GetPackageByPackageId(UpdatePackageID, branchID);
                    Objtblpackage.Package_Name = Convert.ToString(txt_PackageName.Text.Trim());
                    Objtblpackage.Starting_Date = Convert.ToDateTime(dt);
                    Objtblpackage.Validity_Date = Convert.ToDateTime(dt_validity.Value);
                    //Objtblpackage.Starting_Date = Convert.ToDateTime(dt, CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                    //Objtblpackage.Validity_Date =Convert.ToDateTime(dt_validity.Value, CultureInfo.GetCultureInfo("en-US").DateTimeFormat);  

                    Objtblpackage.Package_Rate = Convert.ToDecimal(txt_Rate.Text.Trim());
                    if(chk_Active.Checked)
                    {
                        Objtblpackage.IsActive = true;
                    }
                    else
                    {
                        Objtblpackage.IsActive = false;
                    }
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
                        Objtblpackage.TaxID = tax.TrimEnd(',');
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
                        Objtblpackage.TaxID = tax.TrimEnd(',');
                    }
                    
                    int i = ObjPackageDAL.InsertUpdatePackage(Objtblpackage);
                    ObjPackageDAL.DeletePackageDtlByPackageServiceID(i);

                    tblpackagedtl Objtblpackagedtl = new tblpackagedtl();
                    Objtblpackagedtl.Package_Id = i;
                    foreach (var itemChecked in chklst_PackageItem.CheckedItems)
                    {
                        var row = (itemChecked as tblservice);
                        int? id = (int)row.ServiceId;
                        Objtblpackagedtl.ServiceId = (int)id;
                        ObjPackageDAL.InsertUpdatePackage(Objtblpackagedtl);
                    }
                    MessageBox.Show("Package updated succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    BindPackageGrid();
                    btnPackage.Text = "Save";
                }
                else
                {
                    bool IsExist = ObjPackageDAL.IsExistedPackageName(txt_PackageName.Text.Trim(), branchID);
                    if (IsExist)
                    {
                        //txt_PackageName.Text = string.Empty;
                        MessageBox.Show("Package Name can not be Duplicate!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    Objtblpackage.Package_Id = Convert.ToString(txt_PackageId.Text.Trim());
                    Objtblpackage.Package_Name = Convert.ToString(txt_PackageName.Text.Trim());
                    Objtblpackage.Starting_Date = Convert.ToDateTime(dt);
                    Objtblpackage.Validity_Date = Convert.ToDateTime(dt_validity.Value);
                    //Objtblpackage.Starting_Date = Convert.ToDateTime(dt, CultureInfo.GetCultureInfo("en-US").DateTimeFormat);
                    //Objtblpackage.Validity_Date = Convert.ToDateTime(dt_validity.Text, CultureInfo.GetCultureInfo("en-US").DateTimeFormat);  

                    //Objtblpackage.Starting_Date = Convert.ToDateTime(dt, CultureInfo.InvariantCulture);
                    //Objtblpackage.Validity_Date = Convert.ToDateTime(dt_validity.Text, CultureInfo.InvariantCulture);  
                    //Objtblpackage.Package_Validity = Convert.ToInt32(txt_Validity.Text.Trim());
                    Objtblpackage.Package_Rate = Convert.ToDecimal(txt_Rate.Text.Trim());
                    Objtblpackage.Package_Name = Convert.ToString(txt_PackageName.Text.Trim());
                    Objtblpackage.fk_BranchID = branchID;
                    if (chk_Active.Checked)
                    {
                        Objtblpackage.IsActive = true;
                    }
                    else
                    {
                        Objtblpackage.IsActive = false;
                    }
                    //Objtblpackage.IsActive = true;
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
                        Objtblpackage.TaxID = tax.TrimEnd(',');
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
                        Objtblpackage.TaxID = tax.TrimEnd(',');
                    }
                    int i = ObjPackageDAL.InsertUpdatePackage(Objtblpackage);
                    ObjPackageDAL.DeletePackageDtlByPackageServiceID(i);
                    tblpackagedtl Objtblpackagedtl = new tblpackagedtl();
                    Objtblpackagedtl.Package_Id = i;

                    foreach (var itemChecked in chklst_PackageItem.CheckedItems)
                    {
                        var row = (itemChecked as tblservice);
                        string comapnyName = (string)row.ServiceName;
                        Objtblpackagedtl.ServiceId = (int)row.ServiceId;

                        ObjPackageDAL.InsertUpdatePackage(Objtblpackagedtl);

                    }
                    MessageBox.Show("Package added succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindPackageGrid();
                    clearData();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void gvPackageList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnPackage.Text = "Update";
                int serviceId = 0;
                int packageid = default(int);
                packageid = (Convert.ToInt32(gvPackageList.Rows[e.RowIndex].Cells[0].Value));
                string ServiceName = (Convert.ToString(gvPackageList.Rows[e.RowIndex].Cells[11].Value));
                string[] servName = ServiceName.Split(',');

                //int serviceId = default(int);
                //int.TryParse(Convert.ToString(gvPackageList.Rows[e.RowIndex].Cells[9].Value), out serviceId);
                int i = 0;
                if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {
                    //PackageEL ObjPackageEL = ObjPackageDAL.GetAllPackageDtlById(packageid, serviceId, branchID);
                    PackageEL ObjPackageEL = ObjPackageDAL.GetAllPackageDtlByPackageId(packageid, branchID);
                    if (ObjPackageEL != null)
                    {
                        txt_PackageId.Text = Convert.ToString(ObjPackageEL.Package_Id);
                        txt_PackageId.Enabled = false;
                        txt_PackageName.Text = Convert.ToString(ObjPackageEL.Package_Name);
                        dt_validity.Value = Convert.ToDateTime(ObjPackageEL.Validity_Date);
                        string active = Convert.ToString(ObjPackageEL.isActive);
                        if (active == "True")
                        {
                            chk_Active.Checked = true;
                        }
                        else
                        {
                            chk_Active.Checked = false;
                        }
                        //txt_Validity.Text = Convert.ToString(ObjPackageEL.Package_Validity);
                        decimal amt = Convert.ToDecimal(ObjPackageEL.Package_Rate);
                        txt_Rate.Text = Convert.ToString(amt);
                        UpdatePackageID = packageid;

                        while (chklst_PackageItem.CheckedIndices.Count > 0)
                        {
                            chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
                        }

                        //foreach (var item in servName)
                        //{
                        //    i = 0;
                        //    serviceId = ObjPackageDAL.GetServiceIdByServiceName(Convert.ToString(item), branchID);
                        //    foreach (object item1 in chklst_PackageItem.Items)
                        //    {

                        //        var row = (item1 as tblservice);
                        //        string service = (string)row.ServiceName;
                        //        int serid = (int)row.ServiceId;
                        //        if (serviceId == serid)
                        //        {
                        //            chklst_PackageItem.SetItemChecked(i, true);
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            i = i + 1;
                        //        }
                        //    }
                        //}
                        /*--------------------Added by Sandip Das on 03-06-2016------------------------*/
                        string[] searchId = ObjPackageEL.TaxId.Split(',');
                        if (chkTaxList.Items.Count > 0)
                        {
                            for (int n = 0; n < chkTaxList.Items.Count; n++)
                            {
                                var row = chkTaxList.Items[n] as tbltaxmaster;
                                int? Id = (int)row.Tax_Id;
                                //string name = (string)row.ServiceName;
                                if (searchId.Contains(Id.ToString()))
                                {
                                    chkTaxList.SetItemChecked(n, true);
                                }
                            }
                        }
                        decimal amnt = default(decimal);
                        string s = ObjPackageDAL.ServiceByPkgId(packageid);
                        string[] servId = s.Split(',');
                        if (chklst_PackageItem.Items.Count > 0)
                        {
                            for (int n = 0; n < chklst_PackageItem.Items.Count; n++)
                            {
                                var row = chklst_PackageItem.Items[n] as tblservice;
                                int? Id = (int)row.ServiceId;
                                decimal amount = ObjPackageDAL.AmtByServId(Id);
                                //amnt += amount;
                                //string name = (string)row.ServiceName;
                                if (servId.Contains(Id.ToString()))
                                {
                                    chklst_PackageItem.SetItemChecked(n, true);
                                    amnt += amount;
                                }
                            }
                        }
                        lbl_totalamount.Text = "Total Amount :" + Convert.ToString(amnt);
                        if (chkTaxList.CheckedItems.Count == chkTaxList.Items.Count)
                        {
                            chkAllActive.Checked = true;
                        }
                    }
                    /*--------------------End------------------------*/
                    //GetTotalAmt();
                }
                else if (e.ColumnIndex == 9 && e.RowIndex >= 0)
                {
                    string active =Convert.ToString(gvPackageList.Rows[e.RowIndex].Cells[7].Value);
                    if(active=="False")
                    {
                        //MessageBox.Show("Package is already Blocked!!!");
                        MessageBox.Show("This Package is Already In-Active !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Service", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //bool IsDeleted = ObjPackageDAL.DeleteServicesById(packageid, serviceId);
                        bool IsDeleted = ObjPackageDAL.DeletePackageByPackageId(packageid, branchID);
                        if (IsDeleted)
                        {
                            MessageBox.Show("Deleted Successfully.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            BindPackageGrid();
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

        #endregion crud Operation End

        #region Validation Start
        private bool ValidateForm()
        {
            int cnt = 0;

            DateTime startingdt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime validitydt = Convert.ToDateTime(dt_validity.Value.ToShortDateString());

            foreach (object view in chklst_PackageItem.CheckedItems)
            {

                cnt = cnt + 1;

            }
            if (txt_PackageName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Package Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_Rate.Text == "")
            {
                MessageBox.Show("Please Enter Package Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //else if (startingdt >= validitydt)
            //{
            //    MessageBox.Show("Please Select Package Validity.");
            //    return false;
            //}
            else if (cnt == 0)
            {
                MessageBox.Show("Please check service(s) in package list", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }

            //else if (txt_Validity.Text == "")
            //{
            //    MessageBox.Show("Please enter validity in days.");
            //    return false;
            //}

           
        }
        private void txt_Validity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }
        private void txt_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }
        private void txt_PackageName_TextChanged(object sender, EventArgs e)
        {
            if (txt_PackageName.Text != "")
            {

            }
        }

        #endregion Validation End

        #region Extra Code
        private void Packages_Load(object sender, EventArgs e)
        {

        }
        private void BindClientData(string packageID)
        {


            //tblclient Objtblclient = objClientDAL.GetClientByClientId(packageID, branchID);


            //txtAddress.Text = Convert.ToString(Objtblclient.Address);
            //txtNote.Text = Convert.ToString(Objtblclient.CaseHistory);
            //txtDOB.Text = Convert.ToString(Objtblclient.DateOfBirth.Value.Date);
            //txtEmail.Text = Convert.ToString(Objtblclient.Email);
            ////chkMediclaim.Checked = Convert.ToBoolean(objPainet.HasMediclaim == null ? false : objPainet.HasMediclaim);
            //ddlMaritalStatus.SelectedItem = Convert.ToString(Objtblclient.MaritalStatus);
            //ddlSex.SelectedItem = Convert.ToString(Objtblclient.Sex);
            //txtMobile.Text = Objtblclient.Mobile == null ? "" : Objtblclient.Mobile;
            //txtClientName.Text = Convert.ToString(Objtblclient.ClientName);

            //txtRefSource.Text = Objtblclient.ReferralSource == null ? "" : Objtblclient.ReferralSource;
            //chkEmailNotice.Checked = Convert.ToBoolean(Objtblclient.SendEmail == null ? false : Objtblclient.SendEmail);
            //chkSMSNotice.Checked = Convert.ToBoolean(Objtblclient.SendSMS == null ? false : Objtblclient.SendSMS);
            //idProofNo_txt.Text = Convert.ToString(Objtblclient.IdentityProofNo);

            //if (!string.IsNullOrEmpty(Convert.ToString(Objtblclient.DateOfBirth.Value.Date)))
            //    //Rev Soumya
            //    //txtAge.Text = Convert.ToString(DateTime.Now.Year - Convert.ToDateTime(Convert.ToString(objPainet.DateOfBirth.Value.Date), CultureInfo.InvariantCulture).Year);
            //    txtAge.Text = Convert.ToString(DateTime.Now.Year - Objtblclient.DateOfBirth.Value.Year);
            ////End Rev Soumya

        }

        private void GetTotalAmt()
        {
            string[] total_items = new string[50];
            int it = 0;
            decimal totalamount = 0;

            foreach (tblservice li1 in chklst_PackageItem.CheckedItems)
            {

                string amt = Convert.ToString(li1.ServiceName);
                int startind = amt.IndexOf(":") + 1;
                int endind = amt.IndexOf(")", startind);
                string rs = (amt.Substring(startind, endind - startind)).Trim();
                totalamount = totalamount + Convert.ToDecimal(rs);
                //decimal? rs = (amt.Substring(startind, endind));
                lbl_totalamount.Text = "Total Amount: " + Convert.ToString(totalamount);
                //txtServiceCharge.Text = Convert.ToString(totalamount);
                //totalAmount.Text = Convert.ToString(totalamount);
                //total_items[it] = Convert.ToString(li1.ServiceName);
                //it++;
            }
            if (chklst_PackageItem.CheckedItems.Count == 0)
            {
                lbl_totalamount.Text = "Total Amount: ";
            }
            //for (int j = 0; j < chklst_PackageItem.Items.Count; j++)
            //{
            //    if (chklst_PackageItem.GetItemCheckState(j) == CheckState.Checked)
            //    {
            //        string str = (string)chklst_PackageItem.Items[j];
            //        MessageBox.Show("a");
            //    }
            //}
        }
        string serv = "";
        private void chklst_PackageItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetTotalAmt();
            try
            {
                decimal? serviceAmt = default(decimal);
                int serviceId = default(int);
                serv = default(string);
                foreach (var itemChecked in chklst_PackageItem.CheckedItems)
                {
                    var row = (itemChecked as tblservice);
                    serviceId = (int)row.ServiceId;
                    decimal? amount = ObjPackageDAL.GetAmtFromServiceId(serviceId);
                    serviceAmt += amount;
                    serv += serviceId + ",";
                }
                lbl_totalamount.Text = "Total Amount : " + Convert.ToString(serviceAmt);
                if (chklst_PackageItem.CheckedItems.Count == 0)
                {
                    lbl_totalamount.Text = "Total Amount : ";
                }
            }
            catch (Exception) { }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        #endregion Extra Code

        
        /*------------------------------------------Rev By Sandip Das on 03-06-2016------------------------------*/
        SettingDAL objSettingDAL = new SettingDAL();
        private void BindTax()
        {
            chkTaxList.DataSource = objSettingDAL.GetAllTaxTypeForListbox(branchID);
            chkTaxList.DisplayMember = "Tax_Name";
            chkTaxList.ValueMember = "Tax_Id";
        }
        
        string tax = "";
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
        /*------------------------------------------Rev By Sandip Das on 03-06-2016------------------------------*/
    }
}
