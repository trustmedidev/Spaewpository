using DataAccessLayer;
using SPAPracticeManagement.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement
{
    public partial class ChangePassword : Dashboard
    {
        int? branchID = Convert.ToInt32(ConfigurationManager.AppSettings["BranchID"]);
        Common objCommon = new Common();
        public ChangePassword()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        protected bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter old password","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter new password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtConfirmNewPassword.Text.Trim()))
            {
                MessageBox.Show("Please re-enter new password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmNewPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpassword = txtOldPassword.Text.Trim();
                string newpassword = txtNewPassword.Text.Trim();
                string typenewpassword = txtConfirmNewPassword.Text.Trim();

                if (ValidateForm())
                {
                    if (newpassword != typenewpassword)
                    {
                        MessageBox.Show("Passwords dont match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        UserDAL objUser = new UserDAL();
                        oldpassword = objCommon.Encrypt(txtOldPassword.Text.Trim());
                        var Ret = objUser.ChangePassword(oldpassword, newpassword, typenewpassword, branchID);
                        if (Ret != null)
                        {
                            MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Old Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPassword.Text = null;
            txtNewPassword.Text = null;
            txtConfirmNewPassword.Text = null;
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {

        }        
    }
}
