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
namespace SPAPracticeManagement.InventoryMaster
{
    public partial class frmItem : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objGodownDAL = new InventoryMasterDAL();
        ItemDAL objItemDAL = new ItemDAL();
        ItemMainGrpDAL objItemMainGrpDAL = new ItemMainGrpDAL();
        ItemSubGrpDAL objItemSubGrpDAL = new ItemSubGrpDAL();
        UnitDAL objUnitDAL = new UnitDAL();
        SuppliorDAL objSuppliorDAL = new SuppliorDAL();

        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objItemMainGrpDAL.BindDdlItemMainGrp(ddlItemMainGrp);
            objUnitDAL.BindDdlUnitGrp(ddlPurUnit);
            objUnitDAL.BindDdlUnitGrp(ddlIssUnit);
            objSuppliorDAL.BindDdlSupplior(ddlSupplior);
            
            objFrmName = "Item";
            SirchGridFormat();
        }
        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
            btnSave.Top = 380;
            btnSave.Left = 245;
            btnClear.Top = 380;
            btnClear.Left = 320;
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
            btnUpdate.Top = 380;
            btnUpdate.Left = 245;
            btnClear.Top = 380;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 380;
            btnUpdate.Left = 245;
            btnClear.Top = 380;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.txtName.Enabled = true;
            this.txtShName.Enabled = true;
            this.ddlItemMainGrp.Enabled = true;
            this.ddlItemSubGrp.Enabled = true;
            this.ddlPurUnit.Enabled = true;
            this.ddlIssUnit.Enabled = true;
            this.txtFactor.Enabled = true;
            this.txtReorder.Enabled = true;
            this.txtVatPer.Enabled = true;
            this.txtVatVal.Enabled = true;
            this.txtDiscPer.Enabled = true;
            this.txtDiscVal.Enabled = true;
            this.txtLastPerRate.Enabled = true;
            this.ddlSupplior.Enabled = true;
            this.txtPerishableYN.Enabled = true;
            this.txtSaleableYN.Enabled = true;
            this.txtActive.Enabled = true;

            ActiveControl = txtName;
        }

        public void formCtrlClear()
        {
            this.txtName.Text = "";
            this.txtShName.Text = "";
            this.ddlItemMainGrp.Text = "";
            this.ddlItemSubGrp.Text = "";
            this.ddlPurUnit.Text = "";
            this.ddlIssUnit.Text = "";
            this.txtFactor.Text = "";
            this.txtReorder.Text = "";
            this.txtVatPer.Text = "";
            this.txtVatVal.Text = "";
            this.txtDiscPer.Text = "";
            this.txtDiscVal.Text = "";
            this.txtLastPerRate.Text = "";
            this.ddlSupplior.Text = "";
            this.txtPerishableYN.Text = "Y";
            this.txtSaleableYN.Text = "Y";
            this.txtActive.Text = "Y";

        }
        public void formCtrlActiveN()
        {
            this.txtName.Enabled = false;
            this.txtShName.Enabled = false;
            this.ddlItemMainGrp.Enabled = false;
            this.ddlItemSubGrp.Enabled = false;
            this.ddlPurUnit.Enabled = false;
            this.ddlIssUnit.Enabled = false;
            this.txtFactor.Enabled = false;
            this.txtReorder.Enabled = false;
            this.txtVatPer.Enabled = false;
            this.txtVatVal.Enabled = false;
            this.txtDiscPer.Enabled = false;
            this.txtDiscVal.Enabled = false;
            this.txtLastPerRate.Enabled = false;
            this.ddlSupplior.Enabled = false;
            this.txtPerishableYN.Enabled = false;
            this.txtSaleableYN.Enabled = false;
            this.txtActive.Enabled = false;
            
        }

        public override void SirchGridFormat()
        {
            try
            {
                objItemDAL.BindList(grdSearch);

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

        #region Insert/Update
        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter brand name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            bool PerishableYN = false;
            bool SaleableYN = false;

            if (txtPerishableYN.Text == "Y")
            {
                PerishableYN = true;
            }

            
           
            if (txtPerishableYN.Text == "Y")
            {
                SaleableYN = true;
            }
           
            if (ValidateForm())
            {
                int x = objItemDAL.Insert(txtName.Text.ToString(), txtShName.Text.ToString(), Convert.ToInt32(ddlItemMainGrp.SelectedValue.ToString()),
                    Convert.ToInt32(ddlItemSubGrp.SelectedValue.ToString()), Convert.ToInt32(ddlPurUnit.SelectedValue.ToString()),
                    Convert.ToInt32(ddlIssUnit.SelectedValue.ToString()), Convert.ToDecimal(txtFactor.Text.ToString()),
                    Convert.ToDecimal(txtReorder.Text.ToString()), Convert.ToDecimal(txtVatPer.Text.ToString()), 
                    Convert.ToDecimal(txtVatVal.Text.ToString()), Convert.ToDecimal(txtDiscPer.Text.ToString()),
                    Convert.ToDecimal(txtDiscVal.Text.ToString()), Convert.ToDecimal(txtLastPerRate.Text.ToString()),
                    Convert.ToInt32(ddlSupplior.SelectedValue.ToString()), PerishableYN, SaleableYN, GlobalCL.UserCD);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool IsActiveYN = false;
            bool PerishableYN = false;
            bool SaleableYN = false;

            if (txtActive.Text == "Y")
            {
                IsActiveYN = true;
            }

            if (txtPerishableYN.Text == "Y")
            {
                PerishableYN = true;
            }
            if (txtSaleableYN.Text == "Y")
            {
                SaleableYN = true;
            }
            if (ValidateForm())
            {
                int bId = 0;

                bId = Convert.ToInt32(txtHidCode.Text.ToString());
                int i = objItemDAL.ChkItemInBOM(bId);
                if (i == 1)
                {
                    int x = objItemDAL.Update(bId, txtName.Text.ToString(), txtShName.Text.ToString(), Convert.ToInt32(ddlItemMainGrp.SelectedIndex.ToString()),
                        Convert.ToInt32(ddlItemSubGrp.SelectedIndex.ToString()), Convert.ToInt32(ddlPurUnit.SelectedIndex.ToString()),
                        Convert.ToInt32(ddlIssUnit.SelectedIndex.ToString()), Convert.ToDecimal(txtFactor.Text.ToString()),
                        Convert.ToDecimal(txtReorder.Text.ToString()), Convert.ToDecimal(txtVatPer.Text.ToString()),
                        Convert.ToDecimal(txtVatVal.Text.ToString()), Convert.ToDecimal(txtDiscPer.Text.ToString()),
                        Convert.ToDecimal(txtDiscVal.Text.ToString()), Convert.ToDecimal(txtLastPerRate.Text.ToString()),
                        Convert.ToInt32(ddlSupplior.SelectedValue.ToString()), PerishableYN, SaleableYN, IsActiveYN);
                    if (x > 0)
                    {
                        MessageBox.Show("Updated");
                    }
                }
                else
                {
                    MessageBox.Show("This Item tagged with Bill Of Material. So delete not possible."); 
                }
            }
        }

        #endregion


        #region KeybordControl
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtShName, e);
        }

        private void txtShName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlItemMainGrp, e);
        }

        private void ddlItemMainGrp_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlItemSubGrp, e);
        }

        private void ddlItemSubGrp_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlPurUnit, e);
        }

        private void ddlPurUnit_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlIssUnit, e);
        }
        private void ddlIssUnit_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtFactor, e);
        }
        
        private void txtFactor_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtReorder, e);
        }

        private void txtReorder_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtVatPer, e);
        }

        private void txtVatPer_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtVatVal, e);
        }

        private void txtVatVal_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtDiscPer, e);
        }

        private void txtDiscPer_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtDiscVal, e);
        }

        private void txtDiscVal_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtLastPerRate, e);
        }

        private void txtLastPerRate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlSupplior, e);
        }

        private void ddlSupplior_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtPerishableYN, e);
        }

        private void txtPerishableYN_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtSaleableYN, e);
        }

        private void txtSaleableYN_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtName, e);
        }

        #endregion

        
        #region Validation
        private void ddlItemMainGrp_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlItemMainGrp, falag);
        }

        private void ddlItemMainGrp_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlItemSubGrp_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlItemSubGrp, falag);
        }

        private void ddlItemSubGrp_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlPurUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlPurUnit, falag);
        }

        private void ddlPurUnit_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void txtIssUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlIssUnit, falag);
        }

        private void txtIssUnit_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        

        private void ddlSupplior_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlSupplior, falag);
        }

        private void ddlSupplior_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        #endregion

        private void ddlItemMainGrp_DropDownClosed(object sender, EventArgs e)
        {
            if (ddlItemMainGrp.SelectedValue != null || ddlItemMainGrp.SelectedValue.ToString() == "")
            {
                objItemSubGrpDAL.BindDdlItemSubGrp_ItemMainGrpWise(ddlItemSubGrp, Convert.ToInt32(ddlItemMainGrp.SelectedValue));
            }
        }

        #region Search Effect
        public void XGridValueJump()
        {
            try
            {
                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                string ActYN = "N";
                if ((bool)grdSearch["ActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }
                string PerishableYN = "N";
                if ((bool)grdSearch["PerishableYN", index5].Value == true)
                {
                    PerishableYN = "Y";
                }
                string SaleableYN = "N";
                if ((bool)grdSearch["SaleableYN", index5].Value == true)
                {
                    SaleableYN = "Y";
                }
                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {

                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    this.txtName.Text = (String)grdSearch["Name", index5].Value.ToString();
                    this.txtShName.Text = (String)grdSearch["ShName", index5].Value.ToString();
                    this.ddlItemMainGrp.SelectedValue = grdSearch["ItemMainGrpCd", index5].Value;
                    //===========================================================================
                    if (ddlItemMainGrp.SelectedValue != null || ddlItemMainGrp.SelectedValue.ToString() != "")
                    {
                        objItemSubGrpDAL.BindDdlItemSubGrp_ItemMainGrpWise(ddlItemSubGrp, Convert.ToInt32(ddlItemMainGrp.SelectedValue));
                    }
                    //===========================================================================
                    this.ddlItemSubGrp.SelectedValue = grdSearch["ItemSubGrpCd", index5].Value;
                    this.ddlPurUnit.SelectedValue = grdSearch["PurUnitCd", index5].Value;
                    this.ddlIssUnit.SelectedValue = grdSearch["IssUnitCd", index5].Value;
                    this.txtFactor.Text = (String)grdSearch["Factor", index5].Value.ToString();
                    this.txtReorder.Text = (String)grdSearch["Reorder", index5].Value.ToString();
                    this.txtVatPer.Text = (String)grdSearch["VatPer", index5].Value.ToString();
                    this.txtVatVal.Text = (String)grdSearch["VatVal", index5].Value.ToString();
                    this.txtDiscPer.Text = (String)grdSearch["DiscPer", index5].Value.ToString();
                    this.txtDiscVal.Text = (String)grdSearch["DiscVal", index5].Value.ToString();
                    this.txtLastPerRate.Text = (String)grdSearch["LastPerRate", index5].Value.ToString();
                    this.ddlSupplior.SelectedValue = grdSearch["Supplior", index5].Value;
                    this.txtPerishableYN.Text = PerishableYN;
                    this.txtSaleableYN.Text = SaleableYN;
                    
                    txtActive.Text = ActYN;
                    EditFormatActiveN();
                    txtName.Focus();
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








        //private void btnUpdate_Click(object sender, EventArgs e)
        //{

        //    bool IsActiveYN = false;

        //    if (txtActive.Text == "Y")
        //    {
        //        IsActiveYN = true;
        //    }
        //    if (ValidateForm())
        //    {
        //        int bId = 0;

        //        bId = Convert.ToInt32(txtHidCode.Text.ToString());
        //        int x = objBrandDAL.Update(bId, txtName.Text.ToString(), IsActiveYN);
        //        if (x > 0)
        //        {
        //            MessageBox.Show("Updated");
        //        }
        //    }
        //}
       
    }
}
