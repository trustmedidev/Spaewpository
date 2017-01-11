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
    public partial class frmOpeningStock : InventoryDashboard
    {

        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objInventoryMasterDAL = new InventoryMasterDAL();
        ItemDAL objItemDAL = new ItemDAL();
        ItemOpeningstock objItemOpeningstock = new ItemOpeningstock();
        UnitDAL objUnitDAL = new UnitDAL();

        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmOpeningStock()
        {
            InitializeComponent();
        }

        private void frmOpeningStock_Load(object sender, EventArgs e)
        {
            objItemDAL.BindDdlItem(ddlItem);
            objUnitDAL.BindDdlUnitGrp(ddlUnit);
            objUnitDAL.BindDdlUnitGrp(ddlSecoUnit);
            //objInventoryMasterDAL.BindDdlGodown(1,ddlGodown);
            objInventoryMasterDAL.BindBranch(ddlBranch);
            objFrmName = "Opening Stock";
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
            btnSave.Top = 520;
            btnSave.Left = 645;
            btnClear.Top = 520;
            btnClear.Left = 720;
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
            this.StockDt.Enabled = true;
            this.ddlBranch.Enabled = true;
            this.ddlGodown.Enabled = true;
            this.ddlItem.Enabled = true;
            this.ddlUnit.Enabled = true;
            this.txtQty.Enabled = true;
            this.ddlSecoUnit.Enabled = true;
            this.txtSecoQty.Enabled = true;
            this.txtAmount.Enabled = true;
            this.txtActive.Enabled = true;
            this.grdDtl.Enabled = true;
            this.DtExp.Enabled = true;

            ActiveControl = StockDt;
        }

        public void formCtrlClear()
        {
            this.StockDt.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            this.ddlBranch.Text = "";
            this.ddlGodown.Text = "";
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.ddlSecoUnit.Text = "";
            this.txtQty.Text = "";
            this.txtAmount.Text = "";
            this.txtActive.Text = "Y";
            this.DtExp.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            grdDtl.Rows.Clear();

        }
        public void SubCtrlClear()
        {
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.ddlSecoUnit.Text = "";
            this.txtQty.Text = "";
            this.txtSecoQty.Text = "";
            this.txtAmount.Text = "";
            this.txtActive.Text = "Y";
            this.DtExp.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public void formCtrlActiveN()
        {
            this.StockDt.Enabled = false;
            this.ddlBranch.Enabled = false;
            this.ddlGodown.Enabled = false;
            this.ddlItem.Enabled = false;
            this.ddlUnit.Enabled = false;
            this.txtQty.Enabled = false;
            this.ddlSecoUnit.Enabled = false;
            this.txtSecoQty.Enabled = false;
            this.txtAmount.Enabled = false;
            this.txtActive.Enabled = false;
            this.grdDtl.Enabled = false;
            this.DtExp.Enabled = false;

        }

        public override void SirchGridFormat()
        {
            try
            {
                objItemOpeningstock.BindList(Globalmethods.BranchCD,grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;
                grdSearch.Columns[1].Visible = false;
                grdSearch.Columns[2].Visible = false;
                grdSearch.Columns[3].Visible = false;

                grdSearch.Columns[3].Width = 270;
                grdSearch.Columns[4].Width = 150;
                grdSearch.Columns[5].Width = 150;
                grdSearch.Columns[6].Width = 150;
                grdSearch.Columns[7].Width = 100;
                grdSearch.Columns[8].Width = 100;
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
            CommonCL.ComboBoxGotFocus(ddlGodown, e);
        }

        private void ddlGodown_KeyUp(object sender, KeyEventArgs e)
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
            CommonCL.ComboBoxGotFocus(ddlSecoUnit, e);
        }

        private void ddlSecoUnit_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtSecoQty, e);
        }

        private void txtSecoQty_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.DTPickerGotFocus(DtExp,e);
        }
        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubSave, e);
        }

        private void btnSubSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlItem, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            ActiveControl = ddlItem;
        }
        private void DtExp_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtAmount, e);
        }
        #endregion

        #region Validation
        private void ddlBranch_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlBranch, falag);
        }

        private void ddlGodown_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlGodown, falag);
        }

        private void ddlItem_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlItem, falag);
        }

        private void ddlUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlUnit, falag);
        }

        private void ddlBranch_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlSecoUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlSecoUnit, falag);
        }

        private void ddlSecoUnit_Enter(object sender, EventArgs e)
        {
            falag = true;
        }
        private void ddlGodown_Enter(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != null || ddlBranch.SelectedValue.ToString () != "")
            {
                int i = Convert.ToInt32 (ddlBranch.SelectedValue.ToString ());
                objInventoryMasterDAL.BindDdlGodown(i, ddlGodown);
            }
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
            if (txtAmount .Text.Trim() == "")
            {
                MessageBox.Show("Please enter Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public int InsertUpdateDelete()
        {
            int r = 0;

            try
            {
                //int i = default(int);
                //bool IsValid = false;

                tblitemopeningheader objtblitemopeningheader = new tblitemopeningheader();
                tblitemopeningdetail objtblitemopeningdetail = new tblitemopeningdetail();

                if (ValidateForm())
                {


                    objtblitemopeningheader.Code = Convert.ToInt32(txtHidCode.Text.ToString());
                    objtblitemopeningheader.TranDate = StockDt.Value;
                    objtblitemopeningheader.BranchCd = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                    objtblitemopeningheader.GodownCd = Convert.ToInt32(ddlGodown.SelectedValue.ToString());
                    objtblitemopeningheader.ItemOpeningTranId = txtIndentNo.Text.ToString();
                    objtblitemopeningheader.Description = "";
                    //objtblitemopeningheader.TotValue = Convert.ToDecimal(txtTotAmount.Text.ToString());
                    objtblitemopeningheader.TotValue = 0;
                    objtblitemopeningheader.Finyr = Globalmethods.FinYr;
                    objtblitemopeningheader.ActiveYN = true;
                    objtblitemopeningheader.EntryDate = DateTime.Now;
                    objtblitemopeningheader.UserCode = GlobalCL.UserCD;

                    r = objItemOpeningstock.InsertUpdateOpeningstockHdr(objtblitemopeningheader, objtblitemopeningdetail);

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = InsertUpdateDelete();

            if (i > 0)
            {
                if (grdDtl.Rows.Count != 0)
                {

                    for (int j = 0; j < grdDtl.Rows.Count; j++)
                    {
                        tblitemopeningdetail objtblitemopeningdetail = new tblitemopeningdetail();
                        tblstock objtblstock = new tblstock();
                        objtblitemopeningdetail.ItemOpeningCd = Convert.ToInt32(i.ToString());
                        objtblitemopeningdetail.Code = Convert.ToInt32(grdDtl.Rows[j].Cells["code"].Value.ToString());
                        objtblitemopeningdetail.itemcd = Convert.ToInt32(grdDtl.Rows[j].Cells["ItemCd"].Value.ToString());
                        objtblitemopeningdetail.UnitCd = Convert.ToInt32(grdDtl.Rows[j].Cells["UnitCd"].Value.ToString());
                        objtblitemopeningdetail.Qty = Convert.ToDecimal(grdDtl.Rows[j].Cells["Qty"].Value.ToString());
                        objtblitemopeningdetail.SubUnitCd = Convert.ToInt32(grdDtl.Rows[j].Cells["SecondUnitCd"].Value.ToString());
                        objtblitemopeningdetail.SubQty = Convert.ToDecimal(grdDtl.Rows[j].Cells["SecondQty"].Value.ToString());
                        objtblitemopeningdetail.value = Convert.ToDecimal(grdDtl.Rows[j].Cells["Amount"].Value.ToString());
                        bool valActiveYN = false;
                        if (grdDtl.Rows[j].Cells["DActiveYN"].Value.ToString()=="Y")
                        { valActiveYN = true; }
                        objtblitemopeningdetail.ActiveYN = valActiveYN;
                        objtblitemopeningdetail.ExpiryDt = Convert.ToDateTime(grdDtl.Rows[j].Cells["ExpiryDt"].Value.ToString());

                        objItemOpeningstock.InsertUpdateBOMdetai(objtblitemopeningdetail, objtblstock);
                    }

                }
            }
        }


        public void SubSaveUpdate()
        {
            decimal totQty = 0;
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
                    grdDtl["SecondUnitCd", p].Value = ddlSecoUnit.SelectedValue.ToString();
                    grdDtl["SecondUnit", p].Value = ddlSecoUnit.Text.ToString();
                    grdDtl["SecondQty", p].Value = txtSecoQty.Text.ToString();
                    grdDtl["ExpiryDt", p].Value = DtExp.Value;
                    grdDtl["Amount", p].Value = txtAmount.Text.ToString();
                    grdDtl["DActiveYN", p].Value = txtActive.Text.ToString();

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
                        grdDtl["SecondUnitCd", row].Value = ddlSecoUnit.SelectedValue.ToString();
                        grdDtl["SecondUnit", row].Value = ddlSecoUnit.Text.ToString();
                        grdDtl["SecondQty", row].Value = txtSecoQty.Text.ToString();
                        grdDtl["ExpiryDt", row].Value = DtExp.Value;
                        grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();
                       

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
                        grdDtl["SecondUnitCd", row].Value = ddlSecoUnit.SelectedValue.ToString();
                        grdDtl["SecondUnit", row].Value = ddlSecoUnit.Text.ToString();
                        grdDtl["SecondQty", row].Value = txtSecoQty.Text.ToString();
                        grdDtl["ExpiryDt", row].Value = DtExp.Value;
                        grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();


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

                totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
                totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

            }
            txtTotQty.Text = totQty.ToString();
            txtTotAmount.Text = totAmt.ToString();
        }

        private void btnSubSave_Click(object sender, EventArgs e)
        {
            SubSaveUpdate();

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
                ddlSecoUnit.SelectedValue = Convert.ToInt32(grdDtl["SecondUnitCd", row].Value);
                txtSecoQty.Text = grdDtl["SecondQty", row].Value.ToString();
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
                    decimal totQty = 0;
                    decimal totAmt = 0;
                    for (int i = 0; i < grdDtl .Rows.Count; i++)
                    {
                        
                        totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
                        totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);
                        
                    }
                    txtTotQty.Text = totQty.ToString();
                    txtTotAmount.Text = totAmt.ToString();
                }
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        #endregion

        #region Search Effect
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
                this.txtIndentNo.Text = grdSearch["ItemOpeningTranId", index5].Value.ToString();
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
                    List<ItemOpeningStockEL> objItemOpeningStockEL = new List<ItemOpeningStockEL>();

                    objItemOpeningStockEL = objItemOpeningstock.BindDtlList(Rcode);  //  (grdDtl, Rcode);
                    for (var i = 0; i < objItemOpeningStockEL.Count; i++)
                    {
                        grdDtl.Rows.Add();
                        grdDtl.Rows[i].Cells["code"].Value = objItemOpeningStockEL[i].DCode.ToString();
                        grdDtl.Rows[i].Cells["ItemCd"].Value = objItemOpeningStockEL[i].ItemCd;
                        grdDtl.Rows[i].Cells["Item"].Value = objItemOpeningStockEL[i].Item;
                        grdDtl.Rows[i].Cells["Qty"].Value = objItemOpeningStockEL[i].Quantity;
                        grdDtl.Rows[i].Cells["UnitCd"].Value = objItemOpeningStockEL[i].UnitCd;
                        grdDtl.Rows[i].Cells["Unit"].Value = objItemOpeningStockEL[i].Unit;

                        grdDtl.Rows[i].Cells["SecondQty"].Value = objItemOpeningStockEL[i].SubQty;
                        grdDtl.Rows[i].Cells["SecondUnitCd"].Value = objItemOpeningStockEL[i].SubUnitCd;
                        grdDtl.Rows[i].Cells["SecondUnit"].Value = objItemOpeningStockEL[i].SubUnit;

                        grdDtl.Rows[i].Cells["ExpiryDt"].Value = objItemOpeningStockEL[i].ExpiryDt;
                        grdDtl.Rows[i].Cells["Amount"].Value = objItemOpeningStockEL[i].Rate;
                        grdDtl.Rows[i].Cells["DActiveYN"].Value = objItemOpeningStockEL[i].ActiveYN;
                    }


                    //=================================================================

                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void grdSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            XGridValueJump();
            EditFormatActiveN();
        }
        #endregion

    }
}
