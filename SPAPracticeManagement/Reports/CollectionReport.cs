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
using SPAPracticeManagement;
using DataAccessLayer.Repository;




namespace SPAPracticeManagement.Reports
{
    public partial class CollectionReport : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
        ReportDAL objReportDAL = new ReportDAL();
        public ReportDAL ClientList
        {
            get { return new ReportDAL(); }
        }

        SettingDAL objSettingDAL = new SettingDAL();
        AppointmentDAL ObjAppointmentDAL = new AppointmentDAL();

        public CollectionReport()
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
        }




        #region Methods

        private void BindAccountGrid()
        {
            //DateTime? fdt = null;
            //DateTime? tdt = null;

            //if (txtFromDate.Checked)
            //{
            //    fdt = txtFromDate.Value;
            //}
            //if (txtToDate.Checked)
            //{
            //    tdt = txtToDate.Value;
            //}
            //int byselection = 0;
            //if(radio_all.Checked==true)
            //{
            //    byselection = 0;
            //}
            //else if(radio_service.Checked==true)
            //{
            //    byselection = 1;
            //}
            //else if(radio_package.Checked==true)
            //{
            //    byselection = 2;
            //}

            ////if (radio_package.Checked)
            ////{
            ////    //ddlServiceType.SelectedValue = 0;
            ////}
            ////else
            ////{
            ////    BindServiceType();
            ////    //drNameDrp.SelectedValue = 0;
            ////}

            //int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);
            ////if(ddlServiceType.SelectedIndex!=0)
            ////{

            ////}
            //dgApplicantList.AutoGenerateColumns = false;
            //dgApplicantList.DataSource = ClientList.GetClientListBySearchCriteria(Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection).GroupBy(g=>g.ClientName).Select(s=>s.FirstOrDefault()).ToList();

            //decimal Total = 0;
            //decimal Discount = 0;
            //for (int i = 0; i < dgApplicantList.Rows.Count; i++)
            //{
            //    Total += Convert.ToDecimal(dgApplicantList.Rows[i].Cells["TotalAmount"].Value);
            //    Discount += Convert.ToDecimal(dgApplicantList.Rows[i].Cells["Discount"].Value);
            //}

            ////total_col.Text = (Total - Discount).ToString("0.00");
            //decimal col = Total - Discount;
            //total_col.Text = Math.Abs(col).ToString("0.00");


            DateTime? fdt = null;
            DateTime? tdt = null;
            int? PackageTypeId = null;
            int? ServiceTypeId = null;

            int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);

            if (txtFromDate.Checked)
            {
                fdt = txtFromDate.Value;
            }
            if (txtToDate.Checked)
            {
                tdt = txtToDate.Value;
            }

            if (radio_service.Checked == true)
            {
                ServiceTypeId = ddlvalue;
            }
            else if (radio_package.Checked == true)
            {
                PackageTypeId = ddlvalue;
            }


            dgApplicantList.AutoGenerateColumns = false;
            dgApplicantList.DataSource = ClientList.GetReportListBySearchCriteria(ServiceTypeId, PackageTypeId, fdt, tdt, branchID);

            decimal Total = 0;
            decimal Discount = 0;
            for (int i = 0; i < dgApplicantList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgApplicantList.Rows[i].Cells["TotalAmount"].Value);
                Discount += Convert.ToDecimal(dgApplicantList.Rows[i].Cells["Discount"].Value);
            }

            //total_col.Text = (Total - Discount).ToString("0.00");
            decimal col = Total - Discount;
            total_col.Text = Math.Abs(col).ToString("0.00");
        }

        private void BindServiceType()
        {
            try
            {
                ddlServiceType.DataSource = null;
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
        }

        #endregion Methods

        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindAccountGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindAccountGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Common.ExportToExcel(dgApplicantList))
            {
                MessageBox.Show("Data exported successfully.");
            }
        }

        #endregion

        //private void radio_dr_CheckedChanged(object sender, EventArgs e)
        //{
        //    string result = null;
        //    foreach (Control control in this.group_purpose.Controls)
        //    {
        //        if (control is RadioButton)
        //        {
        //            RadioButton radio = control as RadioButton;
        //            if (radio.Checked)
        //            {
        //                result = radio.Text;
        //            }
        //        }
        //    }

        //    if (result == "Dr. Visit")
        //    {
        //        ddlServiceType.Enabled = false;
        //        //drNameDrp.Enabled = true;
        //    }
        //    else if (result == "Others")
        //    {
        //        ddlServiceType.Enabled = true;
        //        //drNameDrp.Enabled = false;
        //    }
        //}

        private void label3_Click(object sender, EventArgs e)
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
                //ddl_package.ValueMember = "Package_Id";
                //ddl_package.DataSource = objSettingDAL.GetAllPackage(branchID);
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
    }
}
