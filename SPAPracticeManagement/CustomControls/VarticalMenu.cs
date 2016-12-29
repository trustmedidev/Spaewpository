using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.Registration;
using SPAPracticeManagement.Settings;
using SPAPracticeManagement.InventoryMaster;
namespace SPAPracticeManagement.CustomControls
{
    public partial class VarticalMenu : UserControl
    {
        public VarticalMenu()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home objHome = new Home();
            objHome.Show();
            //this.Hide();
            this.Parent.FindForm().Hide();
        }

        private void button_addUser_Click(object sender, EventArgs e)
        {
            UserRegistration objApp = new UserRegistration();
            objApp.Show();
            this.Parent.FindForm().Hide();
            //this.Hide();
        }

        private void btnCompanyDetails_Click(object sender, EventArgs e)
        {
            CompanyDetails objCompanyDetails = new CompanyDetails();
            objCompanyDetails.Show();
            //this.Hide();
            this.Parent.FindForm().Hide();
        }

        private void VarticalMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmItem objCompanyDetails = new frmItem();
            objCompanyDetails.Show();
            //this.Hide();
            this.Parent.FindForm().Hide();
        }
    }
}
