using DataAccessLayer;
using SPAPracticeManagement.AppConstants;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement;

namespace SPAPracticeManagement.Reports
{
    public partial class AppointmentReport : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
       //public ClientDAL ClientList 
        ReportDAL objReportDAL = new ReportDAL();
        //public ReportDAL AppointmentReportList
        //{
        //    get { return new ReportDAL(); }
        //}
        ClientDAL objClientDAL = new ClientDAL();
        SettingDAL objSettingDAL = new SettingDAL();
        AppointmentDAL ObjAppointmentDAL = new AppointmentDAL();

        public AppointmentReport()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            label7.Visible = false;
            ddlServiceType.Visible = false;
            BindAccountGrid();

            BindServiceType();
            //BindDoctor();

            if (radio_package.Checked)
            {
                ddlServiceType.Enabled = false;
                //drNameDrp.Enabled = true;
            }
            else
            {
                ddlServiceType.Enabled = true;
                //drNameDrp.Enabled = false;
            }
            //BindAccountGrid();
            //BindServiceType();
        }

        #region Methods

        private void BindAccountGrid()
        {
            DateTime? fdt = null;
            DateTime? tdt = null;

            if (txtFromDate.Checked)
            {
                fdt = txtFromDate.Value;
            }
            if (txtToDate.Checked)
            {
                tdt = txtToDate.Value;
            }
            int byselection = 0;
            if (radio_all.Checked == true)
            {
                byselection = 0;
            }
            
            else if (radio_package.Checked == true)
            {
                byselection = 1;
            }
            else if (radio_service.Checked == true)
            {
                byselection = 2;
            }



            //if (radio_package.Checked)
            //{
            //    //ddlServiceType.SelectedValue = 0;
            //}
            //else
            //{
            //    BindServiceType();
            //    //drNameDrp.SelectedValue = 0;
            //}

            int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);
            //if(ddlServiceType.SelectedIndex!=0)
            //{

            //}
            dgApplicantList.AutoGenerateColumns = false;
            dgApplicantList.DataSource = objReportDAL.GetAppointmentReportBySearchCriteria(txtClientName.Text, Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection);

             
        }

        //private void BindAccountGrid()
        //{
        //    dgApplicantList.AutoGenerateColumns = false;
        //    dgApplicantList.DataSource = ClientList.GetAllClientByBranchId(branchID);
        //}

        private void BindServiceType()
        {
            try
            {
                ddlServiceType.DisplayMember = "ServiceName"; // Column Name
                ddlServiceType.ValueMember = "ServiceId";
                ddlServiceType.DataSource = objSettingDAL.GetAllServices(branchID);
            }
            catch (Exception ex)
            {
            }
        }

        private void clearData()
        {
            radio_all.Checked = true;
            txtFromDate.Value = DateTime.Now;
            txtToDate.Value = DateTime.Now;
            txtFromDate.Checked = false;
            txtToDate.Checked = false;
            label7.Visible = false;
            ddlServiceType.Visible = false;
            ddlServiceType.SelectedIndex = 0; 
            //txtFromDate.Checked = false;
            //txtToDate.Checked = false;
            //ddlServiceType.SelectedIndex = 0;
            txtClientName.Text = "";
        }

        #endregion Methods

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindAccountGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindAccountGrid(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }    
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Common.ExportToExcel(dgApplicantList))
            {
                MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radio_service_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_service.Checked == true)
            {
                label7.Visible = true;
                ddlServiceType.Visible = true;
                label7.Text = "Service Type :";
                BindServiceType();
                BindAccountGrid();
            }
        }

        private void radio_package_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_package.Checked == true)
            {
                label7.Visible = true;
                ddlServiceType.Visible = true;
                label7.Text = "Package Type";
                BindPackageName();
                BindAccountGrid();
            } 
        }

        private void BindPackageName()
        {
            try
            {
                ddlServiceType.DataSource = null;
                ddlServiceType.DisplayMember = "Package_Name";
                ddlServiceType.ValueMember = "ID"; 
                ddlServiceType.DataSource = ObjAppointmentDAL.GetAllPackage(branchID);
            }
            catch (Exception ex)
            {
            }
        }

        private void radio_all_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_all.Checked == true)
            {
                label7.Visible = false;
                ddlServiceType.Visible = false;
                BindAccountGrid();
            }
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClientlist = objClientDAL.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);
            //List<PatientEL> objPatientList = ClientList.GetAllClientByClientName(txtPatientName.Text.Trim(), branchID);

            foreach (var item in objClientlist)
            {
                //namesCollection.Add(item.PatientName + " (PatientId: " + item.PatientId + ")");
                namesCollection.Add(item.ClientName);
            }
            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }
    }
}
