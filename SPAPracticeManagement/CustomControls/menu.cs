using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.Client;
using SPAPracticeManagement.Settings;
using SPAPracticeManagement.Appointments;
using SPAPracticeManagement.Reports;
using SPAPracticeManagement.PackageBookings;
 

namespace SPAPracticeManagement.CustomControls
{
    public partial class menu : UserControl
    {
        public menu()
        {
            InitializeComponent();
        }

        private void cLIENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
             AddClient ObjAddClient =new AddClient ();
             ObjAddClient.Show();
             this.Parent.FindForm().Hide();
            //AddPatient objApp = new AddPatient(1);
            //objApp.Show();
            

            //this.Parent.FindForm().Hide();
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRate ObjAddRate = new AddRate();
            ObjAddRate.Show();
            //this.Hide();
            this.Parent.FindForm().Hide();
             
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
            }

            if (e.ClickedItem.ForeColor != Color.Black)
                e.ClickedItem.ForeColor = Color.Black;
        }

        private void packagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Packages ObjPackages = new Packages();
            ObjPackages.Show();
            this.Parent.FindForm().Hide();
        }

        private void giftCouponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiftCoupon ObjGiftCoupon = new GiftCoupon();
            ObjGiftCoupon.Show();
            this.Parent.FindForm().Hide();
        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxConfiguration ObjTaxConfiguration = new TaxConfiguration();
            ObjTaxConfiguration.Show();
            this.Parent.FindForm().Hide();
        }

        private void aPPOINTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking objBooking = new Booking();
            //BookAppointment objBookAppointment = new BookAppointment();
            objBooking.Show();
            this.Parent.FindForm().Hide();
        }

        private void aPPOINTMENTToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            aPPOINTMENTToolStripMenuItem.ForeColor = Color.Black;
        }

        private void aPPOINTMENTToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            aPPOINTMENTToolStripMenuItem.ForeColor = Color.White;
        }

        private void cLIENTToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            cLIENTToolStripMenuItem.ForeColor = Color.Black;
            //cLIENTToolStripMenuItem.BackColor = Color.White;

             
        }

       



        private void cLIENTToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            cLIENTToolStripMenuItem.ForeColor = Color.White;
            //cLIENTToolStripMenuItem.BackColor = Color.Black;
        }

        private void rEPORTSToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            rEPORTSToolStripMenuItem.ForeColor = Color.Black;
        }

        private void rEPORTSToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            rEPORTSToolStripMenuItem.ForeColor = Color.White;
        }

        private void ReportToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            ReportToolStripMenuItem.ForeColor = Color.Black;
        }

        private void ReportToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ReportToolStripMenuItem.ForeColor = Color.White;
        }

        private void SettingToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void SettingToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.White;
        }

        private void helpToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.Black;
        }

        private void helpToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.White;
        }

        private void serviceToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void packagesToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void giftCouponToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void taxMasterToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            SettingToolStripMenuItem.ForeColor = Color.Black;
        }

        private void collectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            CollectionReport ObjCollectionReport = new CollectionReport();
            //BookAppointment objBookAppointment = new BookAppointment();
            ObjCollectionReport.Show();
            this.Parent.FindForm().Hide();
        }

        private void clientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientReport objClientReport = new ClientReport();
            objClientReport.Show();
            this.Parent.FindForm().Hide();
        }

        private void appointmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentReport objAppointmentReport = new AppointmentReport();
            objAppointmentReport.Show();
            this.Parent.FindForm().Hide();
        }

        private void rEPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackageBooking objPackageBooking = new PackageBooking();
            objPackageBooking.Show();
            this.Parent.FindForm().Hide();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInventory objAddInventory = new AddInventory();
            objAddInventory.Show();
            this.Parent.FindForm().Hide();
        }

        private void birthDayReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BirthDayReminder ObjBirthDayWish = new BirthDayReminder();
            ObjBirthDayWish.Show();
            this.Parent.FindForm().Hide();
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSetup ObjPrintSetup = new PrintSetup();
            ObjPrintSetup.Show();
            this.Parent.FindForm().Hide();
        }

        private void therapistReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TherapistReport therapistReport = new TherapistReport();
            therapistReport.Show();
            this.Parent.FindForm().Hide();
        }

        private void dailySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailySalesReport dailySalesReport = new DailySalesReport();
           // SalesReport dailySalesReport = new SalesReport();
            dailySalesReport.Show();
            this.Parent.FindForm().Hide();
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InventoryDashboard dailyInventoryDashboard = new InventoryDashboard();
            // SalesReport dailySalesReport = new SalesReport();
            dailyInventoryDashboard.Show();
            this.Parent.FindForm().Hide();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranch objBranch = new frmBranch();
            // SalesReport dailySalesReport = new SalesReport();
            objBranch.Show();
            this.Parent.FindForm().Hide();
        }  
     
    }
}
