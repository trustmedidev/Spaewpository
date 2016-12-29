using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using SPAPracticeManagement.AppConstants;
using DataAccessLayer;
//using DataAccessLayer.Repository;
//using System.Globalization;
//using EntityLayer;



namespace SPAPracticeManagement.Settings
{
    public partial class frmBranch : Form
    {
        #region === Variables

        BranchDAL objBranchDAL= new BranchDAL();
        DataView dv;

        #endregion

        public frmBranch()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            AddFormat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);            
            SirchGridFormat();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            EditFormatActiveY();
        }

        private void frmBranch_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objBranchDAL.BindList(grdSearch);
            SirchGridFormat(); 
        }


        public void XGridValueJump()
        {
            try
            {


                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["BranchID", index5].Value.ToString();
                

                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {
                    txtBranchCode.Text = (String)grdSearch["BranchCode", index5].Value.ToString();
                    txtBranchName.Text = (String)grdSearch["BranchName", index5].Value.ToString();
                    txtAddress.Text = (String)grdSearch["Address", index5].Value.ToString();
                    txtEmail.Text = (String)grdSearch["Email", index5].Value.ToString();
                    txtContactNo.Text = (String)grdSearch["ContactNo", index5].Value.ToString();
                    EditFormatActiveN();
                    txtBranchCode.Focus();
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public void SirchGridFormat()
        {
            try
            {
                objBranchDAL.BindList(grdSearch);

                txtSearchText.Width = 1050; 

                lblTag.Text = "All Brunches";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;

                grdSearch.Columns[0].Visible = false;


                grdSearch.Columns[1].Width = 100;
                grdSearch.Columns[2].Width = 150;
                grdSearch.Columns[3].Width = 270;
                grdSearch.Columns[4].Width = 150;
                grdSearch.Columns[5].Width = 150;
                grdSearch.Columns[6].Width = 150;
             }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }

        public void AddFormat()
        {
            lblTag.Text = "Add Brunch Detail";
            btnSave.Top = 258;
            btnSave.Left = 225;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            formCtrlClear();
            formCtrlActiveY(); 
        }
        public void EditFormatActiveY()
        {
            lblTag.Text = "Edit Brunch Detail";
            btnUpdate.Top = 258;
            btnUpdate.Left = 225;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit Brunch Detail";
            btnUpdate.Top = 258;
            btnUpdate.Left = 225;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.txtBranchCode.Enabled = true;
            this.txtBranchName.Enabled = true;
            this.txtAddress.Enabled = true;
            this.txtContactNo.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtActive.Enabled = true;
            this.txtIsHeadOffice.Enabled = true;
            ActiveControl = txtBranchCode;
        }

        public void formCtrlClear()
        {
            this.txtBranchCode.Text = "";
            this.txtBranchName.Text = "";
            this.txtAddress.Text = "";
            this.txtContactNo.Text = "";
            this.txtEmail.Text = "";
            this.txtActive.Text = "";
            this.txtIsHeadOffice.Text = "";
        }
        public void formCtrlActiveN()
        {
            this.txtBranchCode.Enabled = false;
            this.txtBranchName.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtContactNo.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtActive.Enabled = false;
            this.txtIsHeadOffice.Enabled = false;
        }

        #region KeybordControl
        private void txtBranchCode_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtBranchName,e);
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtAddress, e);
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtContactNo, e);
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtEmail, e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtIsHeadOffice, e);
        }

        private void txtIsHeadOffice_KeyDown(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }
        #endregion


        #region Insert/Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool IsHeadOffYN=false;
            if (txtIsHeadOffice.Text == "Y")
            {
                IsHeadOffYN = true;
            }
            if (ValidateForm())
            {
                int x = objBranchDAL.BranchInsert(txtBranchCode.Text.ToString(), txtBranchName.Text.ToString(), txtAddress.Text.ToString(), txtContactNo.Text.ToString(), txtEmail.Text.ToString(), IsHeadOffYN);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool IsHeadOffYN = false;
            bool IsActiveYN = false;
            if (txtIsHeadOffice.Text == "Y")
            {
                IsHeadOffYN = true;
            }
            if (txtActive.Text == "Y")
            {
                IsActiveYN = true;
            }
            if (ValidateForm())
            {
                int bId = 0;
                
                bId = Convert.ToInt32(txtHidCode.Text.ToString());
                int x = objBranchDAL.BranchUpdate(bId, txtBranchCode.Text.ToString(), txtBranchName.Text.ToString(), txtAddress.Text.ToString(), txtContactNo.Text.ToString(), txtEmail.Text.ToString(), IsHeadOffYN, IsActiveYN);
                if (x > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }   
       
        private bool ValidateForm()
        {
            if (txtBranchCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter branch code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtBranchCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter branch name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtAddress .Text.Trim() == "")
            {
                MessageBox.Show("Please enter address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter contact no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            
            //if (txtEmail.Text.Trim() != string.Empty && !Regex.IsMatch(txtEmail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
            //{
            //    MessageBox.Show("Please enter valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            

            else
            {
                return true;
            }
        }
        #endregion 

        private void grdSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            XGridValueJump();
            EditFormatActiveN();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                bool x = objBranchDAL.isEmailExist(txtEmail.Text);
                if (x == true)
                {
                    MessageBox.Show("Please enter unik email id");

                }
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.OnlyNumber(txtContactNo, e);
        }

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive, e);
        }

        private void txtIsHeadOffice_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtIsHeadOffice, e);
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            CommonCL.textBoxSearchValidation(txtSearchText, dv);
        }

        

       
    }
}
