using SPAPracticeManagement.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.AppConstants;
using SPAPracticeManagement;
using SPAPracticeManagement.Reports;
using SPAPracticeManagement.Appointments;
using SPAPracticeManagement.Settings;
using System.IO;
using DataAccessLayer;
using DataAccessLayer.Repository;
using SPAPracticeManagement.Registration;

namespace SPAPracticeManagement
{
    public partial class Dashboard : Form
    {
        //int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        int? branchID = 1;
        public Dashboard()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.toolTip1.SetToolTip(btnHomeIcon, "Go to home");
            this.toolTip1.SetToolTip(btnHome, "Go to home");
            //this.toolTip1.SetToolTip(btnPatient, "Add patient");
            this.toolTip1.SetToolTip(btnPatientList, "View patient list");
            this.toolTip1.SetToolTip(btnMyCalender, "View my calender");
            //this.toolTip1.SetToolTip(btnPatientLists, "View patient List");
            this.toolTip1.SetToolTip(btnChangePassword, "Change password");
            //this.toolTip1.SetToolTip(btnPatientReport, "View patient report");
            this.toolTip1.SetToolTip(btnPatientList, "Client list");
            this.toolTip1.SetToolTip(btnAppointmentList, "View appointment list");
            //if (Convert.ToString(AppsPropertise.UserDetails.UserName) != "")
            //{
            //    lblLoginName.Text = Convert.ToString(AppsPropertise.UserDetails.UserName);
            //}
            //GetLogoPath();
            
        }

        private void button_addUser_Click(object sender, EventArgs e)
        {
            UserRegistration objApp = new UserRegistration();
            objApp.Show();

            this.Hide();
        }
        public void GetLogoPath()
        {
            tblcompdetail tas = new tblcompdetail();
            SettingDAL objSettingDAL = new SettingDAL();
            tas = objSettingDAL.GetLogo(1, branchID);
            if (tas == null)
            {
                pictureBox1.ImageLocation = Application.StartupPath + @"\Images\Logo.jpg";
            }
            else
            {
                if (string.IsNullOrEmpty(tas.LogoPath))
                {
                    pictureBox1.ImageLocation = Application.StartupPath + @"\Images\Logo.jpg";
                }
                else
                {
                    if (File.Exists(Application.StartupPath + @"\Logo\" + tas.LogoPath))
                    {
                        pictureBox1.ImageLocation = Application.StartupPath + @"\Logo\" + tas.LogoPath;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Application.StartupPath + @"\Images\Logo.jpg";
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            AddClient objApp = new AddClient();
            objApp.Show();
            this.Hide();
        }       

        private void btnClientList_Click(object sender, EventArgs e)
        {
            ClientList Objclientlist = new ClientList();
            Objclientlist.Show();
            this.Hide();
        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.Black;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.White;
        }

        private void btnAppointmentList_MouseHover(object sender, EventArgs e)
        {
            btnAppointmentList.ForeColor = Color.Black;
        }

        private void btnAppointmentList_MouseLeave(object sender, EventArgs e)
        {
            btnAppointmentList.ForeColor = Color.White;
        }

        private void btnPatientList_MouseHover(object sender, EventArgs e)
        {
            btnPatientList.ForeColor = Color.Black;
        }

        private void btnPatientList_MouseLeave(object sender, EventArgs e)
        {
            btnPatientList.ForeColor = Color.White;
        }

        private void btnClientReport_MouseHover(object sender, EventArgs e)
        {
            //btnClientReport.ForeColor = Color.Black;
        }

        private void btnClientReport_MouseLeave(object sender, EventArgs e)
        {
            //btnClientReport.ForeColor = Color.White;
        }

        private void btnChangePassword_MouseHover(object sender, EventArgs e)
        {
            btnChangePassword.ForeColor = Color.Black;
        }

        private void btnChangePassword_MouseLeave(object sender, EventArgs e)
        {
            btnChangePassword.ForeColor = Color.White;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblLoginName_Click(object sender, EventArgs e)
        {

        }

        private void btnHomeIcon_Click(object sender, EventArgs e)
        {

            Home objHome = new Home();
            objHome.Show();
            this.Hide();
        }

        private void btnMyCalender_Click(object sender, EventArgs e)
        {
            
            MyCalender objMyCalender = new MyCalender();
            objMyCalender.Show();
            this.Hide();
        }

        private void btnClientReport_Click(object sender, EventArgs e)
        {
            ClientReportUpload objClientReportUpload = new ClientReportUpload();
            objClientReportUpload.Show();
            this.Hide();
        }

        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            AppointmentList objAppointmentList = new AppointmentList();
            objAppointmentList.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            AppointmentPayment objAppointmentPayment = new AppointmentPayment();
            objAppointmentPayment.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home objHome = new Home();
            objHome.Show();
            this.Hide();
        }

        private void btnClientList_Click_1(object sender, EventArgs e)
        {
            ClientList objClientList = new ClientList();
            objClientList.Show();
            this.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword objChangePassword = new ChangePassword();
            objChangePassword.Show();
            this.Hide();
        }

        private void btnCompanyDetails_Click(object sender, EventArgs e)
        {
            CompanyDetails objCompanyDetails = new CompanyDetails();
            objCompanyDetails.Show();
            this.Hide();
        }

        private void btnTherapist_Click(object sender, EventArgs e)
        {
            AddTherapist objAddTherapist = new AddTherapist();
            objAddTherapist.Show();
            this.Hide();
        }

        private void btnCompanyDetails_MouseHover(object sender, EventArgs e)
        {
            btnCompanyDetails.ForeColor = Color.Black;
        }

        private void btnCompanyDetails_MouseLeave(object sender, EventArgs e)
        {
            btnCompanyDetails.ForeColor = Color.White;
        }

        private void btnTherapist_MouseHover(object sender, EventArgs e)
        {
            btnTherapist.ForeColor = Color.Black;
        }

        private void btnTherapist_MouseLeave(object sender, EventArgs e)
        {
            btnTherapist.ForeColor = Color.White;
        }

        private void btnPayment_MouseHover(object sender, EventArgs e)
        {
            btnPayment.ForeColor = Color.Black;
        }

        private void btnPayment_MouseLeave(object sender, EventArgs e)
        {
            btnPayment.ForeColor = Color.White;
        }
    }
}
