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
        DataView dv;
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
            objFrmName = "Purchase Bill";
            //AddFormat();
            SirchGridFormat();
        }

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
            btnUpdate.Top = 520;
            btnUpdate.Left = 645;
            btnClear.Top = 520;
            btnClear.Left = 720;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 520;
            btnUpdate.Left = 645;
            btnClear.Top = 520;
            btnClear.Left = 720;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            //=====================================================
            this.txtIndentNo.Enabled = true;
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
            this.txtActive.Text = "";
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
            this.txtIndentNo.Enabled = false;
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
                //objItemOpeningstock.BindList(Globalmethods.BranchCD, grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                //grdSearch.Columns[0].Visible = false;
                //grdSearch.Columns[1].Visible = false;
                //grdSearch.Columns[2].Visible = false;
                //grdSearch.Columns[3].Visible = false;

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
            CommonCL.TextBoxGotFocus(txtIndentNo, e);
        }

        private void txtIndentNo_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlGodown, e);
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
                    objtblpurchasehdr.BranchCd = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                    objtblpurchasehdr.GodownCd = Convert.ToInt32(ddlGodown.SelectedValue.ToString());
                    objtblpurchasehdr.PurchaseTranID = txtIndentNo.Text.ToString();
                    objtblpurchasehdr.Description = "";
                    objtblpurchasehdr.TotValue = 0;
                    objtblpurchasehdr.FinYr = Globalmethods.FinYr;
                    objtblpurchasehdr.AcgtiveYN = true;
                    objtblpurchasehdr.EntryDate = DateTime.Now;
                    objtblpurchasehdr.UserCode = GlobalCL.UserCD;

                    //r = objItemOpeningstock.InsertUpdateOpeningstockHdr(objtblpurchasehdr, objtblitemopeningdetail);

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

            for (int i = 0; i < grdDtl.Rows.Count; i++)
            {

                totTaxVal = totTaxVal + Convert.ToDecimal(grdDtl.Rows[i].Cells["ItTaxVal"].Value);
                totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

            }
            txtTotItTax.Text = totTaxVal.ToString();
            txtTotAmount.Text = totAmt.ToString();
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
                        objtblpurchasedtl.Rate = Convert.ToInt32(grdDtl.Rows[j].Cells["Rate"].Value.ToString());
                        objtblpurchasedtl.Value = Convert.ToDecimal(grdDtl.Rows[j].Cells["Amount"].Value.ToString());
                        objtblpurchasedtl.VatPer = Convert.ToDecimal(grdDtl.Rows[j].Cells["ItTaxPer"].Value.ToString());

                        objtblpurchasedtl.VatVal = Convert.ToDecimal(grdDtl.Rows[j].Cells["ItTaxVal"].Value.ToString());
                        bool valActiveYN = false;
                        if (grdDtl.Rows[j].Cells["DActiveYN"].Value.ToString() == "Y")
                        { valActiveYN = true; }
                        objtblpurchasedtl.ActiveYN = valActiveYN;
                        objtblpurchasedtl.ExpiryDt = Convert.ToDateTime(grdDtl.Rows[j].Cells["ExpiryDt"].Value.ToString());

                        //objItemOpeningstock.InsertUpdateBOMdetai(objtblitemopeningdetail, objtblstock);
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
    }
}
