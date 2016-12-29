using DataAccessLayer;
using SPAPracticeManagement.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using DataAccessLayer.Repository;
using System.Configuration;
using System.Globalization;

namespace SPAPracticeManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            panel3.Location = new Point(
    this.ClientSize.Width / 2 - panel3.Size.Width / 2,
    this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        }

        #region Methods

        protected bool ValidateForm()
        {

            if (string.IsNullOrEmpty(txtuserName.Text))
            {
                MessageBox.Show("Please enter user name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtuserName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }


        protected void GetUserAuthentication()
        {
            if (ValidateForm())
            {
                int? branchID = Convert.ToInt32(ConfigurationManager.AppSettings["BranchID"]);
                //string branchID = System.Configuration.ConfigurationSettings.AppSettings["BranchID"]);
                branchID = 1;
                UserDAL objUser = new UserDAL();
                string UserName = txtuserName.Text.Trim();
                string password = txtPassword.Text.Trim();

                //AppsPropertise.UserDetails = objUser.CheckUserAuthentication(UserName, password,branchID);
                AppsPropertise.UserDetails = objUser.CheckUserAuthentication(UserName, common.Encrypt(password), branchID);
                if (AppsPropertise.UserDetails != null)
                {
                    //Rev Soumya
                    string R_ID = Convert.ToString(AppsPropertise.UserDetails.RoleId);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    Registration(R_ID);
                    //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                    //End Rev Soumya
                    Home objDashboard = new Home();
                    objDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        Common common = new Common();
        private void Registration(string FK_RollID)
        {
            try
            {

                string dtInstallDateEN, dtLastUsedDateEN;
                string path = Application.StartupPath;
                //string filepath = "" + path + "\\License.ini";
                if (!File.Exists("" + path + "\\License.ini") || !File.Exists("" + path + "\\Install.ini"))
                {
                    MessageBox.Show("License file missing. Cannot continue", "trustmedi");
                    this.Close();
                    return;
                }
                else
                {
                    dtInstallDateEN = System.IO.File.ReadAllText("" + path + "\\Install.ini");
                    dtLastUsedDateEN = System.IO.File.ReadAllText("" + path + "\\License.ini");
                }
                if (dtInstallDateEN == "" || dtLastUsedDateEN == "")
                {
                    MessageBox.Show("License missing. Cannot continue", "trustmedi");
                    this.Close();
                    return;

                }

                string dtLastDateDe = common.Decrypt(dtLastUsedDateEN);
                string[] dtLastDateSplit = dtLastDateDe.Split(',');

                string lstrInstallDate = common.Decrypt(dtInstallDateEN);
                string[] dtInstallDateSplit = lstrInstallDate.Split(',');
                lstrInstallDate = dtInstallDateSplit[0];
                int lintLicenseDays = Convert.ToInt32(dtInstallDateSplit[1]);

                string lstrLastUsedDate = dtLastDateSplit[0];
                int lintDaysLeft = dtLastDateSplit[0] == "" ? lintLicenseDays : Int32.Parse(dtLastDateSplit[1]);
                string lstrEncrypt = common.Encrypt(DateTime.Now.Date.ToString("dd'/'MM'/'yyyy"));

                TimeSpan difference = DateTime.Parse(DateTime.Now.Date.ToString("dd'/'MM'/'yyyy")) - DateTime.Parse((lstrLastUsedDate == "" ? DateTime.Now.Date.ToString("dd'/'MM'/'yyyy") : DateTime.Parse(lstrLastUsedDate).ToString()));

                if (difference.TotalDays != 0)
                {
                    lintDaysLeft -= Math.Abs(Convert.ToInt32(difference.TotalDays));
                }
                string lstrEncryptLi = DateTime.Now.Date.ToString("dd'/'MM'/'yyyy") + "," + lintDaysLeft;
                lstrEncryptLi = common.Encrypt(lstrEncryptLi);

                if (lstrInstallDate != "")
                {
                    TimeSpan difference1 = DateTime.Parse(DateTime.Now.Date.ToString("dd'/'MM'/'yyyy")) - DateTime.Parse(lstrLastUsedDate == "" ? DateTime.Now.Date.ToString("dd'/'MM'/'yyyy") : DateTime.Parse(lstrLastUsedDate).ToString());
                    if (difference1.TotalDays < 0)
                    {
                        MessageBox.Show("Cannot Continue. Please Set Current Date.", "Trustmedi");
                        this.Close();
                        return;
                    }
                    else if (lintDaysLeft > 0 && lintDaysLeft <= 10 && FK_RollID == "1")
                    {
                        MessageBox.Show("Your Registration will expire within " + lintDaysLeft + " day(s)", "Trustmedi");
                    }
                    else if (lintDaysLeft <= 0)
                    {
                        MessageBox.Show("Please Register your product.. ", "Trustmedi");
                        this.Close();
                    }
                }

                if (lstrInstallDate == "")
                    System.IO.File.WriteAllText("" + path + "\\Install.ini", lstrEncrypt);

                System.IO.File.WriteAllText("" + path + "\\License.ini", lstrEncryptLi);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid License File. Please contact to your system administrator", "Error");
                this.Close();
            }
        }
        //private DateTime ConvertToDateTime(string strDateTime)
        //{
        //    DateTime dtFinaldate; string sDateTime;
        //    try { dtFinaldate = Convert.ToDateTime(strDateTime); }
        //    catch (Exception e)
        //    {
        //        string[] sDate = strDateTime.Split('/');
        //        sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
        //        dtFinaldate = Convert.ToDateTime(sDateTime);
        //    }
        //    return dtFinaldate;
        //}
        //protected void GetUserAuthentication()
        //{
        //    if (ValidateForm())
        //    {
        //        UserDAL objUser = new UserDAL();
        //        string UserName = txtuserName.Text.Trim();
        //        string password = txtPassword.Text.Trim();

        //        AppsPropertise.UserDetails = objUser.CheckUserAuthentication(UserName, password);

        //        if (AppsPropertise.UserDetails != null)
        //        {
        //            Home objDashboard = new Home();
        //            objDashboard.Show();
        //            this.Hide();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Username or Password is incorrect.");
        //        }
        //    }
        //}

        #endregion

        #region Events

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            GetUserAuthentication();
        }

        protected void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                GetUserAuthentication();
        }

        #endregion

        private void btn_ForgotPwd_Click(object sender, EventArgs e)
        {
            ForgotPassword obj = new ForgotPassword();
            obj.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
