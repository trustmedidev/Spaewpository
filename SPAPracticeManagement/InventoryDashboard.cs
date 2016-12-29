using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SPAPracticeManagement
{
    public partial class InventoryDashboard : Form
    {
        public InventoryDashboard()
        {
            InitializeComponent();
           
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //////this.toolTip1.SetToolTip(btnHomeIcon, "Go to home");
            //////this.toolTip1.SetToolTip(btnHome, "Go to home");
            ////////this.toolTip1.SetToolTip(btnPatient, "Add patient");
            //////this.toolTip1.SetToolTip(btnPatientList, "View patient list");
            //////this.toolTip1.SetToolTip(btnMyCalender, "View my calender");
            ////////this.toolTip1.SetToolTip(btnPatientLists, "View patient List");
            //////this.toolTip1.SetToolTip(btnChangePassword, "Change password");
            ////////this.toolTip1.SetToolTip(btnPatientReport, "View patient report");
            //////this.toolTip1.SetToolTip(btnPatientList, "Client list");
            //////this.toolTip1.SetToolTip(btnAppointmentList, "View appointment list");
            //if (Convert.ToString(AppsPropertise.UserDetails.UserName) != "")
            //{
            //    lblLoginName.Text = Convert.ToString(AppsPropertise.UserDetails.UserName);
            //}
            //GetLogoPath();
        }

        private void InventoryDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnHomeIcon_Click(object sender, EventArgs e)
        {
            Home objHome = new Home();
            objHome.Show();
            this.Hide();
        }

        private void varticalMenu1_Load(object sender, EventArgs e)
        {

        }       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFormat();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            EditFormatActiveY();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

            SirchGridFormat();
        }
        public virtual void AddFormat()
        {
           
        }
        public virtual void EditFormatActiveY()
        {
        }
        public virtual  void SirchGridFormat()
        {

        }
    }
}
