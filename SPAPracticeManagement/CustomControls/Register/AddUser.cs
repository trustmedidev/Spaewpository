using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DataAccessLayer;
using EntityLayer;
using SPAPracticeManagement.AppConstants;
using System.Text.RegularExpressions;
using DataAccessLayer.Repository;
 
namespace SPAPracticeManagement.Custom_Controls.Register
{
    public partial class AddUser : UserControl
    {
        int? branchID = Convert.ToInt32(ConfigurationManager.AppSettings["BranchID"]);
        UserDAL objUserDAL = new UserDAL();
        UserEL objUserEL = new UserEL();
        Common objCommon = new Common();

        private int _UpdateUserId;
        public int UpdateUserId
        {
            get { return _UpdateUserId; }
            set { _UpdateUserId = value; }
        }
        private int _UpdateRoleId;
        public int UpdateRoleId
        {
            get { return _UpdateRoleId; }
            set { _UpdateRoleId = value; }
        }
        public AddUser()
        {
            InitializeComponent();
            BindUserDropDown(UpdateUserId);
            var query = objUserDAL.GetUserList(branchID).UserList.ToList();
            if (query.Count > 0)
            {
                dgUserList.AutoGenerateColumns = false;
                dgUserList.DataSource = query;
            }
        }
               
        #region Methods

        protected void BindUserDropDown(int userId = 0)
        {
            var Result = objUserDAL.GetRoleList(branchID);
            if (Result != null)
            {
                if (userId > 0)
                {
                    comboRole_.DataSource = Result.RoleList;
                    comboRole_.DisplayMember = "Name";
                    comboRole_.ValueMember = "Id";
                    comboRole_.SelectedIndex = comboRole_.FindString(objUserDAL.GetRoleById(UpdateRoleId));
                }
                else
                {
                    comboRole_.DataSource = Result.RoleList;
                    comboRole_.DisplayMember = "Name";
                    comboRole_.ValueMember = "Id";
                }
            }
        }
        protected bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()) || !Regex.IsMatch(txtEmail.Text, @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*)(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])"))
            {
                MessageBox.Show("Please enter valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Please enter password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            else if (string.IsNullOrEmpty(txtMobile.Text.Trim()) || !Regex.IsMatch(txtMobile.Text, @"(\d*-)?\d{10}"))
            {
                MessageBox.Show("Please enter  valid mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobile.Focus();
                return false;
            }
            else if (comboRole_.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a role", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboRole_.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void EnableDisable(Boolean status, int RoleID)
        {
            txtName.Enabled = status;
            txtEmail.Enabled = status;
            txtPassword.Enabled = status;
            if (RoleID == 1)
            {
                comboRole_.Visible = status;
            }
            else
            {
                comboRole_.Enabled = status;
                comboRole_.Visible = true;
            }
        }
        private void ShowTextValues(int userId = 0)
        {
            var Value = objUserDAL.FetchListOfUsers(userId, Convert.ToInt32(branchID)).FirstOrDefault();
            if (Value != null)
            {
                UpdateUserId = Value.UserId;
                txtEmail.Text = Value.Email.Trim();
                txtMobile.Text = Value.Mobile.Trim();
                //txtMobile.Text = Value.Phone.Trim();
                txtName.Text = Value.Name.Trim();
                txtPassword.Text = objCommon.Decrypt(Value.Password.Trim());
                int roleId = Convert.ToInt32(Value.RoleId);
                //int roleId = Value.FK_RoleId;
                UpdateRoleId = roleId;
            }
            BindUserDropDown(UpdateUserId);
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    int ret = 0;
                    if (UpdateUserId > 0)
                    {
                        string newemail = "";
                        string prevemail = "";
                        bool userchk = false;
                        tbluser tusr = objUserDAL.GetTableUserById(UpdateUserId, branchID);
                        //tbl_user tusr = objUserDAL.GetTableUserById(UpdateUserId, branchID);
                        prevemail = tusr.Email;
                        newemail = txtEmail.Text.Trim();
                        if (prevemail != newemail)
                        {
                            userchk = objUserDAL.CheckUserName(txtEmail.Text.Trim(), branchID);
                        }

                        tusr.Email = txtEmail.Text.Trim();
                        tusr.Mobile = txtMobile.Text.Trim();
                        tusr.Name = txtName.Text.Trim();
                        tusr.UserName = txtEmail.Text.Trim();
                        //tusr.UserName = AppsProperties.UserDetails.UserName;
                        tusr.Password = objCommon.Encrypt(txtPassword.Text.Trim());
                        tusr.FK_RoleId = (int)comboRole_.SelectedValue;
                        tusr.FK_BranchID = branchID;
                        tusr.IsActive = true;

                        //if (userchk)
                        //{
                        //    MessageBox.Show("User already exist");
                        //}
                        //else
                        //{
                        ret = objUserDAL.InsertUpdateUser(tusr);
                        if (ret > 0)
                        {
                            MessageBox.Show("User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EnableDisable(true, (comboRole_.Visible == false ? 1 : 2));
                            txtName.Text = null;
                            txtEmail.Text = null;
                            txtMobile.Text = null;
                            txtPassword.Text = null;
                            comboRole_.SelectedIndex = 0;

                            dgUserList.DataSource = objUserDAL.GetUserList(branchID).UserList.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Error Occoured", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //}
                    }
                    else
                    {
                        tbluser tu = new tbluser();
                        Common objCommon = new Common();
                        tu.Email = txtEmail.Text.Trim();
                        tu.Name = txtName.Text.Trim();
                        tu.UserName = txtEmail.Text.Trim();
                        tu.Password = objCommon.Encrypt(txtPassword.Text.Trim());
                        tu.Mobile = txtMobile.Text.Trim();

                        tu.FK_RoleId = (int)comboRole_.SelectedValue;
                        tu.IsActive = true;
                        tu.FK_BranchID = branchID;

                        bool userchk = objUserDAL.CheckUserName(txtEmail.Text.Trim(), branchID);

                        if (userchk)
                        {
                            MessageBox.Show("User already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ret = objUserDAL.InsertUpdateUser(tu);
                            if (ret > 0)
                            {
                                MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtName.Text = null;
                                txtEmail.Text = null;
                                txtMobile.Text = null;
                                txtPassword.Text = null;
                                comboRole_.SelectedIndex = 0;
                                dgUserList.DataSource = objUserDAL.GetUserList(branchID).UserList.ToList();
                            }
                            else
                            {
                                MessageBox.Show("Error Occoured", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error Occoured", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtEmail.Text = null;
            txtMobile.Text = null;
            txtPassword.Text = null;
            comboRole_.SelectedIndex = 0;
        }
        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txtMobile.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void dgUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                {
                    string UserName = Convert.ToString(dgUserList.Rows[e.RowIndex].Cells[2].Value);

                    int userId = default(int);
                    int.TryParse(Convert.ToString(dgUserList.Rows[e.RowIndex].Cells[0].Value), out userId);
                    if (userId > 0) { ShowTextValues(userId); } else { MessageBox.Show("Data Not Found"); }
                }
                if (e.ColumnIndex == 7 && e.RowIndex >= 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete User", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int userId = default(int);
                        int.TryParse(Convert.ToString(dgUserList.Rows[e.RowIndex].Cells[0].Value), out userId);
                        bool IsDeleted = objUserDAL.DeleteUserById(userId, branchID);
                        if (IsDeleted)
                        {
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgUserList.DataSource = objUserDAL.GetUserList(branchID).UserList.ToList();
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Server error. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ) { }
        }

        #endregion

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
        
    }
}
