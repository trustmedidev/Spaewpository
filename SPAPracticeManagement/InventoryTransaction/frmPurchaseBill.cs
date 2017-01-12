using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccessLayer;
using DataAccessLayer.Repository;
using System.Data.Entity;
using EntityLayer;

namespace SPAPracticeManagement.InventoryTransaction
{
    public partial class frmPurchaseBill : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objInventoryMasterDAL = new InventoryMasterDAL();
        ItemDAL objItemDAL = new ItemDAL();
        SuppliorDAL objSuppliorDAL = new SuppliorDAL();
        UnitDAL objUnitDAL = new UnitDAL();
        TaxConfigurationDAL objTaxConfigurationDAL = new TaxConfigurationDAL();
        PurchaseBillDAL objPurchaseBillDAL = new PurchaseBillDAL();
        TaxConfigDAL objTaxConfigDAL = new TaxConfigDAL();
        DataView dv;
        bool GRNYN = false;
        string objFrmName = string.Empty;

        #endregion

        public frmPurchaseBill()
        {
            InitializeComponent();
        }

        private void frmPurchaseBill_Load(object sender, EventArgs e)
        {
            objItemDAL.BindDdlItem(ddlItem);
            objUnitDAL.BindDdlUnitGrp(ddlUnit);
            objSuppliorDAL.BindDdlSupplior(ddlSupplier);
            objInventoryMasterDAL.BindDdlGodown(Globalmethods.BranchCD, ddlGodown);
            objInventoryMasterDAL.BindBranch(ddlBranch);
            objTaxConfigurationDAL.BindDdl(ddlTaxTerm);
            objPurchaseBillDAL.BindDdlGRNNo(ddlGrnNo);
            
            GRNYN = Globalmethods.GetGRNYN(3);
            if (GRNYN==true)
            { ddlGrnNo.Enabled = true; }
            else
            { ddlGrnNo.Enabled = false; }

            objFrmName = "Purchase Bill";
            //AddFormat();
            SirchGridFormat();
        }

        #region Set Shortcut
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                falag = false;
                return true;
            }
            if (keyData == Keys.F1)
            {
                AddFormat();
                return true;
            }
            if (keyData == Keys.F2)
            {
                EditFormatActiveY();
                return true;
            }
            if (keyData == Keys.F3)
            {
                SirchGridFormat();
                return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                AddFormat();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.A))
            {
                AddFormat();
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                EditFormatActiveY();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.E))
            {
                EditFormatActiveY();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                falag = false;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
            btnSave.Top = 603;
            btnSave.Left = 745;
            btnClear.Top = 603;
            btnClear.Left = 820;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            formCtrlClear();

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();

        }
        public override void EditFormatActiveY()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnSave.Top = 603;
            btnSave.Left = 745;
            btnClear.Top = 603;
            btnClear.Left = 820;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnSave.Top = 603;
            btnSave.Left = 745;
            btnClear.Top = 603;
            btnClear.Left = 820;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            //=====================================================
            //this.txtIndentNo.Enabled = true;
            this.StockDt.Enabled = true;
            this.ddlBranch.Enabled = true;
            this.ddlSupplier.Enabled = true;
            this.ddlGodown.Enabled = true;
            this.ddlTaxTerm.Enabled = true;
            this.txtHdActiveYN.Enabled = true;


            this.ddlItem.Enabled = true;
            this.ddlUnit.Enabled = true;
            this.txtQty.Enabled = true;
            this.txtQty.Enabled = true;
            this.txtRate.Enabled = true;
            this.txtAmount.Enabled = true;
            this.txtItTaxPer.Enabled = true;
            this.txtItTaxVal.Enabled = true;
            this.txtActive.Enabled = true;

            this.txtTotAmount.Enabled = true;
            this.txtTotItTax.Enabled = true;

            this.ddlBillType.Enabled = true;

            this.txtGrossAmount.Enabled = true;
            this.txtTaxTotal.Enabled = true;
            this.txtNetTotal.Enabled = true;
            this.grdDtl.Enabled = true;
            //=====================================================



            ActiveControl = StockDt;
        }

        public void formCtrlClear()
        {
            //=====================================================
            this.txtIndentNo.Text = "";
            this.StockDt.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            this.ddlBranch.Text = "";
            this.ddlSupplier.Text = "";
            this.ddlGodown.Text = "";
            this.ddlTaxTerm.Text = "";
            this.txtHdActiveYN.Text = "Y";
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.txtQty.Text = "";
            this.txtQty.Text = "";
            this.txtRate.Text = "";
            this.txtAmount.Text = "";
            this.txtItTaxPer.Text = "";
            this.txtItTaxVal.Text = "";
            this.txtActive.Text = "Y";
            this.txtTotAmount.Text = "";
            this.txtTotItTax.Text = "";
            this.ddlBillType.Text = "";
            this.txtGrossAmount.Text = "";
            this.txtTaxTotal.Text = "";
            this.txtNetTotal.Text = "";            
            //=====================================================

            grdDtl.Rows.Clear();

        }
        public void SubCtrlClear()
        {
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.txtQty.Text = "";
            this.txtQty.Text = "";
            this.txtRate.Text = "";
            this.txtAmount.Text = "";
            this.txtItTaxPer.Text = "";
            this.txtItTaxVal.Text = "";
            this.txtActive.Text = "Y";
        }

        public void formCtrlActiveN()
        {
            //=====================================================
            //this.txtIndentNo.Enabled = false;
            this.StockDt.Enabled = false;
            this.ddlBranch.Enabled = false;
            this.ddlSupplier.Enabled = false;
            this.ddlGodown.Enabled = false;
            this.ddlTaxTerm.Enabled = false;
            this.txtHdActiveYN.Enabled = false;

            this.ddlItem.Enabled = false;
            this.ddlUnit.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtRate.Enabled = false;
            this.txtAmount.Enabled = false;
            this.txtItTaxPer.Enabled = false;
            this.txtItTaxVal.Enabled = false;
            this.txtActive.Enabled = false;

            this.txtTotAmount.Enabled = false;
            this.txtTotItTax.Enabled = false;

            this.ddlBillType.Enabled = false;

            this.txtGrossAmount.Enabled = false;
            this.txtTaxTotal.Enabled = false;
            this.txtNetTotal.Enabled = false;
            this.grdDtl.Enabled = false;
            //=====================================================

        }

        public override void SirchGridFormat()
        {
            try
            {
                objPurchaseBillDAL.BindList(Globalmethods.BranchCD, grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;
                grdSearch.Columns[2].Visible = false;
                grdSearch.Columns[3].Visible = false;
                grdSearch.Columns[6].Visible = false;
                grdSearch.Columns[8].Visible = false;

                //grdSearch.Columns[3].Width = 270;
                //grdSearch.Columns[4].Width = 150;
                //grdSearch.Columns[5].Width = 150;
                //grdSearch.Columns[6].Width = 150;
                //grdSearch.Columns[7].Width = 100;
                //grdSearch.Columns[8].Width = 100;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
        #endregion       

        #region KeybordControl
        private void StockDt_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlBranch, e);
        }

        private void ddlBranch_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlSupplier, e);
        }

        private void ddlSupplier_KeyUp(object sender, KeyEventArgs e)
        {
            if (GRNYN == true)
            { CommonCL.ComboBoxGotFocus(ddlGrnNo, e); }
            else
            {
                //CommonCL.TextBoxGotFocus(txtIndentNo, e);
                CommonCL.ComboBoxGotFocus(ddlGodown, e);
            }
        }

        private void txtIndentNo_KeyUp(object sender, KeyEventArgs e)
        {
            //CommonCL.ComboBoxGotFocus(ddlGodown, e);
        }

        private void ddlGodown_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlTaxTerm, e);
        }

        private void ddlTaxTerm_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtHdActiveYN, e);
        }

        private void txtHdActiveYN_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubAdd, e);
        }

        private void btnSubAdd_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlItem, e);
        }

        private void ddlItem_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlUnit, e);
        }

        private void ddlUnit_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtQty, e);
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtRate, e);
        }

        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtAmount, e);
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtItTaxPer, e);
        }

        private void txtItTaxPer_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtItTaxVal, e);
        }

        private void txtItTaxVal_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubSave, e);
        }

        private void btnSubSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }
        #endregion

        #region Validation
        private void ddlBranch_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlSupplier_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlGodown_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlTaxTerm_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlItem_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlUnit_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlBillType_Enter(object sender, EventArgs e)
        {
            falag = true;
        }
        private void ddlGrnNo_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlGrnNo, falag);
        }

        private void ddlGrnNo_Enter(object sender, EventArgs e)
        {
            falag = true;
        }
        private void ddlBranch_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlBranch, falag);
        }

        private void ddlSupplier_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlSupplier, falag);
        }

        private void ddlGodown_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlGodown, falag);
        }

        private void ddlTaxTerm_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlTaxTerm, falag);
        }

        private void ddlItem_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlItem, falag);
        }

        private void ddlUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlUnit, falag);
        }

        private void ddlBillType_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlBillType, falag);
        }
        #endregion

        #region Insert/Update
        private bool ValidateForm()
        {

            if (txtHidCode.Text == "")
            {
                txtHidCode.Text = "0";
            }

            if (ddlBranch.SelectedValue == null || ddlBranch.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Branch.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ddlGodown.SelectedValue == null || ddlGodown.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Godown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddlSupplier.SelectedValue == null || ddlSupplier.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Supplier.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddlTaxTerm.SelectedValue == null || ddlTaxTerm.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Tax Term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            

            if (txtHdActiveYN.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateSubForm()
        {

            if (txtHidCode.Text == "")
            {
                txtHidCode.Text = "0";
            }

            if (ddlItem.SelectedValue == null || ddlItem.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddlUnit.SelectedValue == null || ddlUnit.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Unit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Qty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtRate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtItTaxPer.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax (%).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtItTaxVal.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax Value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            else
            {
                return true;
            }
        }

        public int InsertUpdateDelete()
        {
            int r = 0;

            try
            {

                tblpurchasehdr objtblpurchasehdr = new tblpurchasehdr();
                tblpurchasedtl objtblpurchasedtl = new tblpurchasedtl();

                if (ValidateForm())
                {
                    objtblpurchasehdr.Code = Convert.ToInt32(txtHidCode.Text.ToString());
                    objtblpurchasehdr.TranDate = StockDt.Value;
                    // check is it GRN or Order
                    if (GRNYN == true)
                    {
                        objtblpurchasehdr.OrderYN = GRNYN;
                        objtblpurchasehdr.OrderCd = Convert.ToInt32(ddlGrnNo.SelectedValue.ToString());
                    }
                    else
                    {
                        objtblpurchasehdr.OrderYN = GRNYN;
                        objtblpurchasehdr.OrderCd = Convert.ToInt32("0");

                    }
                    //=====================================
                    objtblpurchasehdr.BranchCd = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                    objtblpurchasehdr.GodownCd = Convert.ToInt32(ddlGodown.SelectedValue.ToString());
                    objtblpurchasehdr.SupplierCd = Convert.ToInt32(ddlSupplier.SelectedValue.ToString());
                    objtblpurchasehdr.TaxConfigCd = Convert.ToInt32(ddlTaxTerm.SelectedValue.ToString());
                    objtblpurchasehdr.PurchaseTranID = txtIndentNo.Text.ToString();
                    objtblpurchasehdr.TotBasicValue=Convert.ToDecimal(txtGrossAmount.Text.ToString());
                    objtblpurchasehdr.TotVal = Convert.ToDecimal(txtTaxTotal.Text.ToString());
                    //objtblpurchasehdr.TotDisc = Convert.ToDecimal(txtGrossAmount.Text.ToString());
                    objtblpurchasehdr.TotValue = Convert.ToDecimal(txtNetTotal.Text.ToString());
                    objtblpurchasehdr.Description = "";
                    //objtblpurchasehdr.TotValue = 0;
                    objtblpurchasehdr.FinYr = Globalmethods.FinYr;
                    objtblpurchasehdr.AcgtiveYN = true;
                    objtblpurchasehdr.EntryDate = DateTime.Now;
                    objtblpurchasehdr.UserCode = GlobalCL.UserCD;

                    r = objPurchaseBillDAL.InsertUpdateHdr(objtblpurchasehdr, objtblpurchasedtl);

                }
                return r;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Occoured. Please enter correct data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region GridFunctions
        private void btnSubSave_Click(object sender, EventArgs e)
        {
            SubSaveUpdate();
        }
        public void SubSaveUpdate()
        {
            decimal totTaxVal = 0;
            decimal totAmt = 0;
            if (ValidateSubForm())
            {

            }
            else
            {
                return;
            }

            Boolean check_gd = false;
            for (int p = 0; p < grdDtl.Rows.Count; p++)
            {
                string V_ItemCd = grdDtl["ItemCd", p].Value.ToString();

                if (txtGrdRowIndex.Text.ToString() == p.ToString())
                {
                    check_gd = true;
                    grdDtl["ItemCd", p].Value = ddlItem.SelectedValue.ToString();
                    grdDtl["Item", p].Value = ddlItem.Text.ToString();
                    grdDtl["Qty", p].Value = txtQty.Text.ToString();
                    grdDtl["UnitCd", p].Value = ddlUnit.SelectedValue.ToString();
                    grdDtl["Unit", p].Value = ddlUnit.Text.ToString();
                    grdDtl["Rate", p].Value = txtRate .Text .ToString();
                    grdDtl["Amount", p].Value = txtAmount.Text.ToString();
                    grdDtl["ItTaxPer", p].Value = txtItTaxPer.Text.ToString();
                    grdDtl["ItTaxVal", p].Value = txtItTaxVal.Text.ToString();
                    grdDtl["DActiveYN", p].Value = txtActive.Text.ToString();
                    grdDtl["ExpiryDt", p].Value = DtExp.Value;
                    //grdDtl["code", p].Value = DtExp.Value;
                    SubCtrlClear();
                    grdDtl.Refresh();
                    btnSubAdd.Focus();

                    //return;
                }
                else
                {
                    check_gd = false;
                }
            }
            //==============================================================================================
            if (check_gd == false)
            {
                try
                {
                    if (txtGrdRowIndex.Text == "")
                    {
                        int row = 0;

                        grdDtl.Rows.Add();
                        row = grdDtl.Rows.Count - 1;
                        grdDtl["code", row].Value = "0";

                        grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        grdDtl["Unit", row].Value = ddlUnit.Text.ToString();
                        grdDtl["Rate", row].Value = txtRate.Text.ToString();
                        grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["ItTaxPer", row].Value = txtItTaxPer.Text.ToString();
                        grdDtl["ItTaxVal", row].Value = txtItTaxVal.Text.ToString();
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();
                        grdDtl["ExpiryDt", row].Value = DtExp.Value;
                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                    }
                    else
                    {
                        int row = Convert.ToInt32(txtGrdRowIndex.Text.ToString());

                        grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        grdDtl["Unit", row].Value = ddlUnit.Text.ToString();
                        grdDtl["Rate", row].Value = txtRate.Text.ToString();
                        grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["ItTaxPer", row].Value = txtItTaxPer.Text.ToString();
                        grdDtl["ItTaxVal", row].Value = txtItTaxVal.Text.ToString();
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();
                        grdDtl["ExpiryDt", row].Value = DtExp.Value;
                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                    }
                    ////========================================================================

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                    return;
                }


            }
            txtTotItTax.Text = "0";
            txtTotAmount.Text = "0d";
            for (int i = 0; i < grdDtl.Rows.Count; i++)
            {

                totTaxVal = totTaxVal + Convert.ToDecimal(grdDtl.Rows[i].Cells["ItTaxVal"].Value);
                totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

            }
            txtTotItTax.Text = totTaxVal.ToString();
            txtTotAmount.Text = totAmt.ToString();

            txtGrossAmount.Text = Convert.ToString(Convert.ToDecimal(txtTotItTax.Text.ToString()) + Convert.ToDecimal(txtTotAmount.Text.ToString()));
            if (txtTaxTotal.Text == "")
            {
                txtTaxTotal.Text = "0";
            }
            txtNetTotal.Text = Convert.ToString(Convert.ToDecimal(txtGrossAmount.Text.ToString()) + Convert.ToDecimal(txtTaxTotal.Text.ToString()));
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = InsertUpdateDelete();

            if (i > 0)
            {
                if (grdDtl.Rows.Count != 0)
                {

                    for (int j = 0; j < grdDtl.Rows.Count; j++)
                    {
                       
                        tblpurchasedtl objtblpurchasedtl = new tblpurchasedtl();
                        tblstock objtblstock = new tblstock();
                        objtblpurchasedtl.PurchaseCd = Convert.ToInt32(i.ToString());
                        objtblpurchasedtl.Code = Convert.ToInt32(grdDtl.Rows[j].Cells["code"].Value.ToString());
                        objtblpurchasedtl.ItemCd = Convert.ToInt32(grdDtl.Rows[j].Cells["ItemCd"].Value.ToString());
                        objtblpurchasedtl.UnitCd = Convert.ToInt32(grdDtl.Rows[j].Cells["UnitCd"].Value.ToString());
                        objtblpurchasedtl.Qty = Convert.ToDecimal(grdDtl.Rows[j].Cells["Qty"].Value.ToString());
                        objtblpurchasedtl.Rate = Convert.ToDecimal(grdDtl.Rows[j].Cells["Rate"].Value.ToString());
                        objtblpurchasedtl.Value = Convert.ToDecimal(grdDtl.Rows[j].Cells["Amount"].Value.ToString());
                        objtblpurchasedtl.VatPer = Convert.ToDecimal(grdDtl.Rows[j].Cells["ItTaxPer"].Value.ToString());

                        objtblpurchasedtl.VatVal = Convert.ToDecimal(grdDtl.Rows[j].Cells["ItTaxVal"].Value.ToString());
                        bool valActiveYN = false;
                        if (grdDtl.Rows[j].Cells["DActiveYN"].Value.ToString() == "Y")
                        { valActiveYN = true; }
                        objtblpurchasedtl.ActiveYN = valActiveYN;
                        objtblpurchasedtl.ExpiryDt = Convert.ToDateTime(grdDtl.Rows[j].Cells["ExpiryDt"].Value.ToString());

                        objPurchaseBillDAL.InsertUpdateDetai(objtblpurchasedtl, objtblstock);
                    
                    }

                }
            }
        }
        

        private void grdDtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 11)
            {
                txtGrdRowIndex.Text = e.RowIndex.ToString();
                int row = e.RowIndex;

                ddlItem.SelectedValue = Convert.ToInt32(grdDtl["ItemCd", row].Value);
                txtQty.Text = grdDtl["Qty", row].Value.ToString();
                ddlUnit.SelectedValue = Convert.ToInt32(grdDtl["UnitCd", row].Value);
                txtAmount.Text = grdDtl["Amount", row].Value.ToString();
                txtItTaxPer.Text = grdDtl["ItTaxPer", row].Value.ToString();
                txtItTaxVal.Text = grdDtl["ItTaxVal", row].Value.ToString();
                txtRate.Text = grdDtl["Rate", row].Value.ToString();
                DtExp.Value = Convert.ToDateTime(grdDtl["ExpiryDt", row].Value.ToString());
                
                txtAmount.Text = grdDtl["Amount", row].Value.ToString();

            }
            if (e.ColumnIndex == 12)
            {
                removeRecordFormGrid();

            }
        }
        public void removeRecordFormGrid()
        {
            try
            {

                DialogResult reg = MessageBox.Show("Do You want to Remove record...", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == reg)
                {
                    grdDtl.Rows.RemoveAt(grdDtl.CurrentRow.Index);
                    decimal TotItTax = 0;
                    decimal totAmt = 0;
                    for (int i = 0; i < grdDtl.Rows.Count; i++)
                    {

                        TotItTax = TotItTax + Convert.ToDecimal(grdDtl.Rows[i].Cells["ItTaxVal"].Value);
                        totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

                    }
                    txtTotItTax.Text = TotItTax.ToString();
                    txtTotAmount.Text = totAmt.ToString();
                }
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        #endregion

        private void lblTag_Click(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "" && txtQty .Text !="")
            {
                txtAmount .Text =Convert.ToString (Convert.ToDecimal (txtQty .Text .ToString ())*Convert.ToDecimal (txtRate .Text .ToString ()));
            }
        }

        private void txtItTaxPer_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text != "" && txtItTaxPer.Text != "")
            {
                txtItTaxVal.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text.ToString()) * Convert.ToDecimal(txtItTaxPer.Text.ToString())/100);
            }
        }

        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            SubCtrlClear();
            ActiveControl = ddlItem;
        }

        #region Search Effect
        private void grdSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            XGridValueJump();
            EditFormatActiveN();
        }
        public void XGridValueJump()
        {
            try
            {
                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                int Rcode = Convert.ToInt32(grdSearch["Code", index5].Value.ToString());
                //=======================Header data bind==========================
                string ActYN = "N";
                if ((bool)grdSearch["HActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }
                txtHdActiveYN.Text = ActYN;
                this.ddlBranch.SelectedValue = grdSearch["Brabchcd", index5].Value;
                //=================================================================
                if (ddlBranch.SelectedValue != null || ddlBranch.SelectedValue.ToString() != "")
                {
                    int i = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                    objInventoryMasterDAL.BindDdlGodown(i, ddlGodown);
                    this.ddlGodown.SelectedValue = grdSearch["Godowncd", index5].Value;
                }
                //=================================================================
                this.txtIndentNo.Text = grdSearch["PurchaseTranID", index5].Value.ToString();
                this.ddlSupplier.SelectedValue = grdSearch["SupplierCd", index5].Value;
                this.ddlTaxTerm.SelectedValue = grdSearch["TranId", index5].Value;
                this.txtIndentNo.Text = grdSearch["TranId", index5].Value.ToString();
                this.StockDt.Value = Convert.ToDateTime(grdSearch["TranDate", index5].Value);
                this.txtGrossAmount.Text = grdSearch["TotBasicValue", index5].Value.ToString();
                this.txtTaxTotal.Text = grdSearch["TotVal", index5].Value.ToString();
                //this.txtIndentNo.Text = grdSearch["TotDisc", index5].Value.ToString();
                this.txtNetTotal.Text = grdSearch["TotValue", index5].Value.ToString();
                //=============================End=================================
                //=======================Detail data bind==========================


                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {

                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    Rcode = Convert.ToInt32(txtHidCode.Text.ToString());
                    grdDtl.Rows.Clear();
                    List<PurchaceBillEL> objPurchaceBillEL = new List<PurchaceBillEL>();

                    objPurchaceBillEL = objPurchaseBillDAL.BindDtlList(Rcode);  //  (grdDtl, Rcode);
                    for (var i = 0; i < objPurchaceBillEL.Count; i++)
                    {
                        grdDtl.Rows.Add();
                        grdDtl.Rows[i].Cells["code"].Value = objPurchaceBillEL[i].DCode.ToString();
                        grdDtl.Rows[i].Cells["ItemCd"].Value = objPurchaceBillEL[i].ItemCd;
                        grdDtl.Rows[i].Cells["Item"].Value = objPurchaceBillEL[i].Item;
                        grdDtl.Rows[i].Cells["Qty"].Value = objPurchaceBillEL[i].Qty;
                        grdDtl.Rows[i].Cells["UnitCd"].Value = objPurchaceBillEL[i].UnitCd;
                        grdDtl.Rows[i].Cells["Unit"].Value = objPurchaceBillEL[i].Unit;
                        
                        grdDtl.Rows[i].Cells["Rate"].Value = objPurchaceBillEL[i].Rate;
                        grdDtl.Rows[i].Cells["Amount"].Value = objPurchaceBillEL[i].Amount;
                        grdDtl.Rows[i].Cells["ItTaxPer"].Value = objPurchaceBillEL[i].TaxPer;

                        grdDtl.Rows[i].Cells["ItTaxVal"].Value = objPurchaceBillEL[i].TaxVal;
                        grdDtl.Rows[i].Cells["ExpiryDt"].Value = objPurchaceBillEL[i].ExpiryDt;
                        grdDtl.Rows[i].Cells["DActiveYN"].Value = objPurchaceBillEL[i].ActiveYN;

                        grdDtl.Rows[i].Cells["ExpiryDt"].Value = objPurchaceBillEL[i].ExpiryDt;
                        grdDtl.Rows[i].Cells["Amount"].Value = objPurchaceBillEL[i].Rate;
                        grdDtl.Rows[i].Cells["DActiveYN"].Value = objPurchaceBillEL[i].ActiveYN;
                    }


                    //=================================================================

                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        #endregion

        #region  turm related code=======================
        public double billingTermCalculate()
        {
            double result1 = 0;
            double result2 = 0;
            double result3 = 0;
            if (Convert.ToDouble(txtGrossAmount.Text.ToString()) > 0)
            {
                for (int i = 0; i < grdTaxTerm.Rows.Count; i++)
                {
                    result1 = billingTermCalculatePart2(i, result2);
                    grdTaxTerm.Rows[i].Cells["TaxAmount"].Value = result1.ToString();
                }
                for (int i = 0; i < grdTaxTerm.Rows.Count; i++)
                {
                    if (grdTaxTerm.Rows[i].Cells["AddOrSub"].Value.ToString() == "+")
                    {
                        result3 = result3 + Convert.ToDouble(grdTaxTerm.Rows[i].Cells["TaxAmount"].Value);
                    }
                    if (grdTaxTerm.Rows[i].Cells["AddOrSub"].Value.ToString() == "-")
                    {
                        result3 = result3 - Convert.ToDouble(grdTaxTerm.Rows[i].Cells["TaxAmount"].Value);
                    }
                }
            }
            if (Convert.ToDouble(txtGrossAmount.Text.ToString()) <= 0)
            {
                for (int i = 0; i < grdTaxTerm.Rows.Count; i++)
                {
                    result1 = 0;
                    grdTaxTerm.Rows[i].Cells["TaxAmount"].Value = result1.ToString();
                }
            }
            return result3;

        }
        //============================test===================================
        public double billingTermCalculatePart2(int i, double result2)
        {
            string BillingFormulaVal = "";
            double subTotal = 0;
            BillingFormulaVal = grdTaxTerm.Rows[i].Cells["Formula"].Value.ToString();
            string[] Formulas = BillingFormulaVal.Split('+');
            for (int p = 0; p <= Formulas.Length - 1; p++)
            {
                if (Formulas[p] == "B")
                {
                    subTotal = subTotal + Convert.ToDouble(txtGrossAmount.Text);
                }
                else
                {

                    int x = Convert.ToInt32(Formulas[p]) - 1;
                    BillingFormulaVal = "";
                    BillingFormulaVal = grdTaxTerm.Rows[x].Cells["Formula"].Value.ToString();
                    if (BillingFormulaVal.Length > 0)
                    {
                        if (grdTaxTerm.Rows[x].Cells["AddOrSub"].Value.ToString() == "+")
                        {
                            subTotal = subTotal + Convert.ToDouble(grdTaxTerm.Rows[x].Cells["TaxAmount"].Value.ToString());
                        }
                        if (grdTaxTerm.Rows[x].Cells["AddOrSub"].Value.ToString() == "-")
                        {
                            subTotal = subTotal - Convert.ToDouble(grdTaxTerm.Rows[x].Cells["TaxAmount"].Value.ToString());
                        }

                    }
                }

            }
            if (Convert.ToDouble(grdTaxTerm.Rows[i].Cells["TaxPer"].Value.ToString()) > 0)
            {
                result2 = subTotal * Convert.ToDouble(grdTaxTerm.Rows[i].Cells["TaxPer"].Value.ToString()) / 100;
            }
            else
            {
                result2 = Convert.ToDouble(grdTaxTerm.Rows[i].Cells["Amount"].Value.ToString());
            }
            return result2;
        }


        //===================================================================
        private void ddlTaxTerm_Leave(object sender, EventArgs e)
        {
            LodeBillingTerm();
        }
        public void LodeBillingTerm()
        {
            if (ddlTaxTerm.Text != "")
            {
                if (ddlTaxTerm.SelectedValue != null)
                {
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    if (ddlTaxTerm.Text != "")
                    {
                        int Rcode = Convert.ToInt32(ddlTaxTerm.SelectedValue.ToString());
                        grdTaxTerm.Rows.Clear();
                        List<TaxConfigurationEL> objTaxConfigurationEL = new List<TaxConfigurationEL>();

                        objTaxConfigurationEL = objTaxConfigDAL.BindDtlList(Rcode);
                        for (var i = 0; i < objTaxConfigurationEL.Count; i++)
                        {
                            grdTaxTerm.Rows.Add();
                            grdTaxTerm.Rows[i].Cells["slCode"].Value = objTaxConfigurationEL[i].DCode.ToString();
                            grdTaxTerm.Rows[i].Cells["TaxNm"].Value = objTaxConfigurationEL[i].ConfigNm;
                            grdTaxTerm.Rows[i].Cells["STax"].Value = objTaxConfigurationEL[i].STax;
                            grdTaxTerm.Rows[i].Cells["AddOrSub"].Value = objTaxConfigurationEL[i].addSub;
                            grdTaxTerm.Rows[i].Cells["Formula"].Value = objTaxConfigurationEL[i].CalOn;
                            grdTaxTerm.Rows[i].Cells["TaxPer"].Value = objTaxConfigurationEL[i].CalPer;
                            grdTaxTerm.Rows[i].Cells["trnTaxVal"].Value = objTaxConfigurationEL[i].CalVal;

                            grdTaxTerm.Rows[i].Cells["Type"].Value = objTaxConfigurationEL[i].TermsType;
                        }
                    }
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                }
            }
        }

        private void txtGrossAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtGrossAmount.Text.ToString() != "")
            {
                //Convert.ToDouble(txtGrossAmount.Text.ToString()) != 0
                double TaxTermTot = billingTermCalculate();
                txtTaxTotal.Text = TaxTermTot.ToString();
            }
        }

        private void ddlTaxTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LodeBillingTerm();
        }
        //=======================================================
        #endregion
    }
}
