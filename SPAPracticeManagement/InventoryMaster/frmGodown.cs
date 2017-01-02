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
    public partial class frmGodown : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objGodownDAL = new InventoryMasterDAL();
        DataView dv;

        #endregion
        public frmGodown()
        {
            InitializeComponent();
        }

        private void frmGodown_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objGodownDAL.BindBranch(ddlBranch );
            SirchGridFormat(); 
        }

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add Godown Detail";
            btnSave.Top = 130;
            btnSave.Left = 245;
            btnClear.Top = 130;
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
            lblTag.Text = "Edit Godown Detail";
            btnUpdate.Top = 130;
            btnUpdate.Left = 245;
            btnClear.Top = 130;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit Godown Detail";
            btnUpdate.Top = 130;
            btnUpdate.Left = 245;
            btnClear.Top = 130;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.txtName.Enabled = true;
            this.txtActive.Enabled = true;
            this.txtIsMainGodown.Enabled = true;
            ActiveControl = ddlBranch;
        }

        public void formCtrlClear()
        {
            this.txtName.Text = "";
            this.txtActive.Text = "Y";
            this.txtIsMainGodown.Text = "Y";
        }
        public void formCtrlActiveN()
        {
            this.txtName.Enabled = false;
            this.txtActive.Enabled = false;
            this.txtIsMainGodown.Enabled = false;
        }

        public override void SirchGridFormat()
        {
            try
            {
                //objGodownDAL.BindList(grdSearch, GlobalCL.BranchCD, GlobalCL.IsAdmin);
                objGodownDAL.BindList(grdSearch);
                txtSearchText.Width = 1050;

                lblTag.Text = "All Godown";
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

        private void txtHidCode_TextChanged(object sender, EventArgs e)
        {

        }

        #region KeybordControl
        private void ddlBranch_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtName, e);
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtIsMainGodown, e);
        }

        private void txtIsMainGodown_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlBranch,e);
        }
        #endregion

        #region Insert/Update
        private bool ValidateForm()
        {
            if (txtName .Text.Trim() == "")
            {
                MessageBox.Show("Please enter godown name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddlBranch.Text.Trim() == "")
            {
                MessageBox.Show("Please enter branch name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (txtIsMainGodown.Text.Trim() == "")
            {
                MessageBox.Show("Please enter contact no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            bool IsMainGodownYN = false;
            if (txtIsMainGodown .Text.ToUpper() == "Y")
            {
                IsMainGodownYN = true;
            }
            if (ValidateForm())
            {
                int x = objGodownDAL.InsertGodown(Convert.ToInt32(ddlBranch.SelectedIndex.ToString()), txtName.Text.ToString(), IsMainGodownYN, GlobalCL.UserCD);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool IsMainGodownYN = false;
            bool IsActiveYN = false;
            if (txtIsMainGodown .Text == "Y")
            {
                IsMainGodownYN = true;
            }
            if (txtActive.Text == "Y")
            {
                IsActiveYN = true;
            }
            if (ValidateForm())
            {
                int bId = 0;

                bId = Convert.ToInt32(txtHidCode.Text.ToString());
                int x = objGodownDAL.UpdateGodown(bId, Convert.ToInt32 (ddlBranch.SelectedIndex.ToString()), txtName.Text.ToString(), IsMainGodownYN, GlobalCL.UserCD, IsActiveYN);
                if (x > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        #endregion 
        private void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlBranch_Validated(object sender, EventArgs e)
        {
            CommonCL .cmbValidated(ddlBranch , falag);
        }

        private void ddlBranch_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

        private void txtActive_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtIsMainGodown_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive, e);
        }

        private void txtIsMainGodown_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive, e);
        }

        #region Search Effect
        public void XGridValueJump()
        {
            try
            {
                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["GodownCd", index5].Value.ToString();
                string ActYN = "N";
                if ((bool)grdSearch["ActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }

                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {
                    this.ddlBranch.SelectedValue = (Int32)grdSearch["BranchCd", index5].Value;
                    txtHidCode.Text = (String)grdSearch["GodownCd", index5].Value.ToString();
                    txtName.Text = (String)grdSearch["GodownNm", index5].Value.ToString();
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
            objGodownDAL.BindBranch(ddlBranch);
            XGridValueJump();
            EditFormatActiveN();
        }

        #endregion



    }
}
