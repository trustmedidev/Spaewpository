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
    public partial class frmItemSubGroup : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        ItemMainGrpDAL objItemMainGrpDAL = new ItemMainGrpDAL();
        ItemSubGrpDAL objItemSubGrpDAL = new ItemSubGrpDAL();
        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmItemSubGroup()
        {
            InitializeComponent();
        }

        private void frmItemSubGroup_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objFrmName = "Item Sub Group";
            objItemMainGrpDAL.BindDdlItemMainGrp(ddlMainGrp);
            SirchGridFormat();
        }

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
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
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
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
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
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
            this.ddlMainGrp.Enabled = true;
            this.txtName.Enabled = true;
            this.txtActive.Enabled = true;

            ActiveControl = ddlMainGrp;
        }

        public void formCtrlClear()
        {
            this.ddlMainGrp.Text = "";
            this.txtName.Text = "";
            this.txtActive.Text = "Y";
        }
        public void formCtrlActiveN()
        {
            this.ddlMainGrp.Enabled = false;
            this.txtName.Enabled = false;
            this.txtActive.Enabled = false;
        }

        public override void SirchGridFormat()
        {
            try
            {
                objItemSubGrpDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;
                grdSearch.Columns[1].Visible = false;

                //grdSearch.Columns[1].Width = 100;
                grdSearch.Columns[2].Width = 150;
                grdSearch.Columns[3].Width = 270;
                grdSearch.Columns[4].Width = 250;
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
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtName, e);
        }

        private void ddlMainGrp_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtName, e);
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive, e);
        }

        private void ddlMainGrp_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlMainGrp, falag);
        }

        private void ddlMainGrp_Enter(object sender, EventArgs e)
        {
            falag = true;
        }
        #region Insert/Update
        private bool ValidateForm()
        {
            if (ddlMainGrp.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Item Main Group.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Item Sub Group.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            
            if (ValidateForm())
            {
                int x = objItemSubGrpDAL.Insert(txtName.Text.ToString(), Convert.ToInt32(ddlMainGrp.SelectedValue.ToString()), GlobalCL.UserCD);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            bool IsActiveYN = false;
           
            if (txtActive.Text == "Y")
            {
                IsActiveYN = true;
            }
            if (ValidateForm())
            {
                int bId = 0;

                bId = Convert.ToInt32(txtHidCode.Text.ToString());
                int x = objItemSubGrpDAL.Update(bId, Convert.ToInt32(ddlMainGrp.SelectedValue.ToString()), txtName.Text.ToString(), IsActiveYN);
                if (x > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        #endregion 

        #region Search Effect
        public void XGridValueJump()
        {
            try
            {
                //objItemMainGrpDAL.BindDdlItemMainGrp(ddlMainGrp);

                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
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
                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    ddlMainGrp.SelectedValue = grdSearch["ItemMainGrpCd", index5].Value;
                    txtName.Text = (String)grdSearch["Name", index5].Value.ToString();
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
    }
}
