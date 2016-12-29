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
    public partial class frmSupplior : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        SuppliorDAL objSuppliorDAL = new SuppliorDAL();
        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmSupplior()
        {
            InitializeComponent();
        }

        private void frmSupplior_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objSuppliorDAL.BindList(grdSearch);
            SirchGridFormat();
        }

        #region KeybordControl
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtAddress, e);
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtContactNo, e);
        }

        private void txtContactNo_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtEmail, e);
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtCaseHistory, e);
        }

        private void txtCaseHistory_KeyUp(object sender, KeyEventArgs e)
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
         #endregion

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
            btnSave.Top = 230;
            btnSave.Left = 245;
            btnClear.Top = 230;
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
            btnUpdate.Top = 230;
            btnUpdate.Left = 245;
            btnClear.Top = 230;
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
            btnUpdate.Top = 230;
            btnUpdate.Left = 245;
            btnClear.Top = 230;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.txtName.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtContactNo.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtCaseHistory.Enabled = true;
            this.txtActive.Enabled = true;

            ActiveControl = txtName;
        }

        public void formCtrlClear()
        {
            this.txtName.Text = "";
            this.txtAddress.Text = "";
            this.txtContactNo.Text = "";
            this.txtEmail.Text = "";
            this.txtCaseHistory.Text = "";
            this.txtActive.Text = "Y";
        }
        public void formCtrlActiveN()
        {
            this.txtName.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtContactNo.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtCaseHistory.Enabled = false;
            this.txtActive.Enabled = false;
        }

        public override void SirchGridFormat()
        {
            try
            {
                objSuppliorDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;


                //grdSearch.Columns[1].Width = 300;
                //grdSearch.Columns[2].Width = 150;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
        #endregion

        #region Insert/Update
        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter supplior name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please enter address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter contact no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (txtCaseHistory.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Case History.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCaseHistory.Focus();
                return false;
            }
            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActive.Focus();
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
                int x = objSuppliorDAL.Insert(txtName.Text.ToString(),txtAddress.Text .ToString (),txtContactNo.Text .ToString (),txtEmail .Text .ToString (),txtCaseHistory.Text .ToString (), GlobalCL.UserCD);
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
                int x = objSuppliorDAL.Update(bId, txtName.Text.ToString(), txtAddress.Text.ToString(), txtContactNo.Text.ToString(), txtEmail.Text.ToString(), txtCaseHistory.Text.ToString(), IsActiveYN);
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
                    txtName.Text = (String)grdSearch["Name", index5].Value.ToString();
                    txtAddress.Text = (String)grdSearch["Address", index5].Value.ToString();
                    txtContactNo.Text = (String)grdSearch["Mobile", index5].Value.ToString();
                    txtEmail.Text = (String)grdSearch["Email", index5].Value.ToString();
                    txtCaseHistory.Text = (String)grdSearch["CaseHistory", index5].Value.ToString();
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
