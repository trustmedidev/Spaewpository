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
    public partial class frmPurchaseRequsition : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objInventoryMasterDAL = new InventoryMasterDAL();
        ItemDAL objItemDAL = new ItemDAL();
        UnitDAL objUnitDAL = new UnitDAL();
        UserDAL objUserDAL = new UserDAL();
        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmPurchaseRequsition()
        {
            InitializeComponent();
        }

        private void frmPurchaseRequsition_Load(object sender, EventArgs e)
        {
            objItemDAL.BindDdlItem(ddlItem);
            objUnitDAL.BindDdlUnitGrp(ddlUnit);
            objUserDAL.BindDdlAllUser(ddlUser);
            
            objInventoryMasterDAL.BindBranch(ddlBranch);
            objFrmName = "Purchase requsition";
            SirchGridFormat();
        }

        private void ddlUser_Enter(object sender, EventArgs e)
        {
            falag = true;
            if (ddlBranch.SelectedValue.ToString() != "" || ddlBranch.SelectedValue != null)
            {
                objUserDAL.BindDdlUser(ddlUser, Convert.ToInt32(ddlBranch.SelectedValue));
            }
            else
            {
                objUserDAL.BindDdlAllUser(ddlUser);
            }
        }

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
            this.ddlUser .Enabled = true;
            this.ddlItem.Enabled = true;
            this.ddlUnit.Enabled = true;
            this.txtQty.Enabled = true;            
            this.txtActive.Enabled = true;
            this.grdDtl.Enabled = true;


            ActiveControl = StockDt;
        }

        public void formCtrlClear()
        {
            this.StockDt.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            this.ddlBranch.Text = "";
            this.ddlUser.Text = "";
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.txtQty.Text = "";
            this.txtActive.Text = "Y";
            grdDtl.Rows.Clear();

        }
        public void SubCtrlClear()
        {
            ddlItem.Text = "";
            //ddlIssUnit.Text = "";
            txtQty.Text = "";
            //txtRate.Text = "";
        }

        public void formCtrlActiveN()
        {
            this.StockDt.Enabled = false;
            this.ddlBranch.Enabled = false;
            this.ddlUser.Enabled = false;
            this.ddlItem.Enabled = false;
            this.ddlUnit.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtActive.Enabled = false;
            this.grdDtl.Enabled = false;


        }

        public override void SirchGridFormat()
        {
            try
            {
                ////objBOMentryDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                //grdSearch.Columns[0].Visible = false;


                //grdSearch.Columns[1].Width = 100;
                //grdSearch.Columns[2].Width = 150;
                //grdSearch.Columns[3].Width = 270;
                //grdSearch.Columns[4].Width = 150;
                //grdSearch.Columns[5].Width = 150;
                //grdSearch.Columns[6].Width = 150;
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
            CommonCL.ComboBoxGotFocus(ddlUser, e);
        }
        
        private void ddlUser_KeyUp(object sender, KeyEventArgs e)
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
        #endregion

        #region Validation
        private void ddlBranch_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlBranch, falag);
        }

        private void ddlUser_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlUser, falag);
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

            if (ddlUser.SelectedValue == null || ddlUser.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter User.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                tblitemopeningdetail objtblbomheader = new tblitemopeningdetail();
                tblbomdetail objtblbomdetail = new tblbomdetail();

                if (ValidateForm())
                {
                    objtblbomheader.Code = Convert.ToInt32(txtHidCode.Text.ToString());
                    //objtblbomheader.ServiceCd = Convert.ToInt32(ddlService.SelectedValue.ToString());
                    //objtblbomheader.PackageDescription = txtPkgDisc.Text.ToString();
                    objtblbomheader.ActiveYN = true;
                    //objtblbomheader.EntryDate = DateTime.Now;
                    //objtblbomheader.UserCode = GlobalCL.UserCD;

                    //r = objBOMentryDAL.InsertUpdateBOMheader(objtblbomheader, objtblbomdetail);

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
                        tblbomdetail objtblbomdetail = new tblbomdetail();
                        objtblbomdetail.BOM_Cd = Convert.ToInt32(i.ToString());
                        objtblbomdetail.Code = Convert.ToInt32(grdDtl.Rows[j].Cells["code"].Value.ToString());
                        objtblbomdetail.ItemCd = Convert.ToInt32(grdDtl.Rows[j].Cells["ItemCd"].Value.ToString());
                        objtblbomdetail.UnitCd = Convert.ToInt32(grdDtl.Rows[j].Cells["UnitCd"].Value.ToString());
                        objtblbomdetail.Qty = Convert.ToDecimal(grdDtl.Rows[j].Cells["Qty"].Value.ToString());
                        objtblbomdetail.Rate = Convert.ToDecimal(grdDtl.Rows[j].Cells["Rate"].Value.ToString());
                        objtblbomdetail.ActiveYN = true;
                        objtblbomdetail.EntryDate = DateTime.Now;
                        objtblbomdetail.UserCode = GlobalCL.UserCD;

                        //objBOMentryDAL.InsertUpdateBOMdetai(objtblbomdetail);
                    }

                }
            }
        }

        public void SubSaveUpdate()
        {
            Boolean check_gd = false;
            for (int p = 0; p < grdDtl.Rows.Count; p++)
            {
                string V_ItemCd = grdDtl["ItemCd", p].Value.ToString();
                if (ddlItem.SelectedValue.ToString() == V_ItemCd.ToString())
                {
                    check_gd = true;

                    grdDtl["ItemCd", p].Value = ddlItem.SelectedValue.ToString();
                    grdDtl["Qty", p].Value = txtQty.Text.ToString();
                    grdDtl["UnitCd", p].Value = ddlUnit.SelectedValue.ToString();
                    //grdDtl["Amount", p].Value = txtAmount.Text.ToString();
                    grdDtl["Item", p].Value = ddlItem.Text.ToString();
                    grdDtl["Unit", p].Value = ddlUnit.Text.ToString();

                    SubCtrlClear();
                    grdDtl.Refresh();
                    btnSubAdd.Focus();
                    return;
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
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        //grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Unit", row].Value = ddlUnit.Text.ToString();

                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                        return;
                    }
                    else
                    {
                        int row = Convert.ToInt32(txtGrdRowIndex.Text.ToString());

                        grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        //grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Unit", row].Value = ddlUnit.Text.ToString();

                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                        return;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }


            }
            decimal totQty = 0;
            for (int i = 0; i < grdDtl.Rows.Count; i++)
            {
                totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
            }
            txtTotQty.Text = totQty.ToString();
        }

        private void btnSubSave_Click(object sender, EventArgs e)
        {
            SubSaveUpdate();
        }

        private void grdDtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 6)
            {
                txtGrdRowIndex.Text = e.RowIndex.ToString();
                int row = e.RowIndex;

                ddlItem.SelectedValue = Convert.ToInt32(grdDtl["ItemCd", row].Value);
                txtQty.Text = grdDtl["Qty", row].Value.ToString();
                ddlUnit.SelectedValue = Convert.ToInt32(grdDtl["UnitCd", row].Value);

            }
            if (e.ColumnIndex == 7)
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
                    for (int i = 0; i < grdDtl.Rows.Count; i++)
                    {
                        totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
                    }
                    txtTotQty.Text = totQty.ToString();
                    
                }
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        #endregion

    }
}
