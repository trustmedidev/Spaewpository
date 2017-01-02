using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.Appointments;
using SPAPracticeManagement.AppConstants;
using DataAccessLayer;
using DataAccessLayer.Repository;
using EntityLayer;

namespace SPAPracticeManagement.Client
{
    public partial class ClientList : Dashboard
    {

        //int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        int branchID = Convert.ToInt32(AppConstants.AppsPropertise.UserDetails.BranchId);
        AppointmentDAL ObjAppointmentDAL = new AppointmentDAL();
        public ClientDAL clientlist
        {
            get { return new ClientDAL(); }
        }
        //public PatientDAL PatientsList
        //{
        //    get { return new PatientDAL(); }
        //}
        public AppointmentDAL AppointmentsList
        {
            get { return new AppointmentDAL(); }
        }
        SettingDAL objSettingDAL = new SettingDAL();
        public ClientList()
        {
            InitializeComponent();            
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            label7.Enabled = false;
            ddlServiceType.Enabled = false;
            //label7.Visible = false;
            //ddlServiceType.Visible = false;
            //BindAccountGrid();
            BindServiceType();
            BindClientListGrid();

            BindCustomerList();

            if (AppsPropertise.UserDetails != null)
            {

                int? role = AppsPropertise.UserDetails.RoleId;
                switch (role)
                {
                    case 1:

                        break;
                    case 2:
                        btnAddClient.Visible = false; 
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    default:
                        break;
                }
            }
        }

        private void BindCustomerList()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = clientlist.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (Mobile: " + item.Mobile + ")");
            }

            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        private void BindPackageName()
        {
            try
            {
                List<tblpackage> objtblpackage = new List<tblpackage>();
                objtblpackage.Insert(0, new tblpackage { Id = 0, Package_Name = "Select Package" });
                var PackageList = ObjAppointmentDAL.GetAllPackage(branchID);

                if (PackageList != null && PackageList.Count() > 0)
                {
                    foreach (var pkg in PackageList)
                    {
                        objtblpackage.Add(pkg);
                    }
                }

                ddlServiceType.DataSource = null;
                ddlServiceType.DisplayMember = "Package_Name";
                ddlServiceType.ValueMember = "ID";
                //ddl_package.ValueMember = "Package_Id";
                //ddl_package.DataSource = objSettingDAL.GetAllPackage(branchID);
                ddlServiceType.DataSource = objtblpackage;
            }
            catch (Exception ex)
            {
            }
        }
        private void radio_all_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_all.Checked == true)
            {
                txtClientName.Text = string.Empty;
                label7.Enabled = false;
                ddlServiceType.Enabled = false;
                //label7.Visible = false;
                //ddlServiceType.Visible = false;
                BindClientListGrid();
                //BindAppointmentGrid();
                //BindAccountGrid();
            }
        }
        private void radio_service_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_service.Checked == true)
            {
                txtClientName.Text = string.Empty;
                label7.Enabled = true;
                ddlServiceType.Enabled = true;
                //label7.Visible = true;
                //ddlServiceType.Visible = true;
                label7.Text = "Service Type :";
                BindServiceType();
                BindClientListGrid();
                //BindAppointmentGrid();
                //BindAccountGrid();
            }
        }
        private void radio_package_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_package.Checked == true)
            {
                txtClientName.Text = string.Empty;
                label7.Enabled = true;
                ddlServiceType.Enabled = true;
                //label7.Visible = true;
                //ddlServiceType.Visible = true;
                label7.Text = "Package Type";
                BindPackageName();
                BindClientListGrid();
                //BindAppointmentGrid();
                //BindAccountGrid();
            }

        }

        private void BindClientListGrid()
        {
            try
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
                else if (radio_service.Checked == true)
                {
                    byselection = 1;
                }
                else if (radio_package.Checked == true)
                {
                    byselection = 2;
                }



                string clientname = "";
                if (txtClientName.Text == "")
                {
                    clientname = null;
                }
                else
                {
                    clientname = txtClientName.Text.Substring(0, txtClientName.Text.IndexOf("(")).Trim();
                }

                string mobile = "";
                if (txtClientName.Text == "")
                {
                    mobile = null;
                }
                else
                {
                    int startindex = 0;
                    int endindex = 0;
                    startindex = txtClientName.Text.IndexOf("(") + 1;
                    endindex = txtClientName.Text.IndexOf(")") - 1;

                    mobile = txtClientName.Text.Substring(startindex, endindex - startindex);
                }




                int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);
                //if(ddlServiceType.SelectedIndex!=0)
                //{

                //}
                
                List<ClientEL> objClientEL = new List<ClientEL>();
                objClientEL = clientlist.GetClientListBySearchCriteriaNewForGrid(clientname,mobile, Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection);
                //objClientEL = clientlist.GetClientListBySearchCriteria(clientname, Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection);
                dgClientList.AutoGenerateColumns = false;
                dgClientList.DataSource = objClientEL.GroupBy(x => new { x.ClientId, x.ClientName, x.Sex, x.Address, x.DateOfBirth, x.Email, x.Mobile }).Select(x => x.FirstOrDefault()).ToList();
                //dgClientList.DataSource = clientlist.GetClientListBySearchCriteria(clientname, Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }

        }

        #region Methods

        private void BindAccountGrid()
        {

            dgClientList.AutoGenerateColumns = false;
            dgClientList.DataSource = clientlist.GetClientByBranchId(branchID);
            //dgApplicantList.DataSource = PatientsList.GetAllPatient(branchID);
        }

        private void BindServiceType()
        {
            try
            {
                List<tblservice> objtblservice = new List<tblservice>();
                objtblservice.Insert(0, new tblservice { ServiceId = 0, ServiceName = "Select Service" });
                var servicelist = objSettingDAL.GetAllServices(branchID);
                if(servicelist!=null && servicelist.Count()>0)
                {
                    foreach (var ser in servicelist)
                    {
                        objtblservice.Add(ser);
                    }
                }
               
                ddlServiceType.DataSource = null;
                ddlServiceType.DisplayMember = "ServiceName"; // Column Name
                ddlServiceType.ValueMember = "ServiceId";
                ddlServiceType.DataSource = objtblservice;
            }
            catch (Exception ex)
            {
            }
        }

        private void clearData()
        {
            radio_all.Checked = true;
            txtFromDate.Checked = false;
            txtToDate.Checked = false;
            ddlServiceType.SelectedIndex = 0;
            ddlServiceType.Enabled = false;
            txtClientName.Text = "";
        }

        #endregion Methods


        #region Events

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindClientListGrid();
            //BindAccountGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindClientListGrid();
                //PatientsList.GetAllPatientBySearchCriteria(txtClientName.Text, 0, DateTime.Now, DateTime.Now);
                // txtFromDate.Checked ;
                // txtToDate.Checked = false;
            //    DateTime? fdt = null;
            //    DateTime? tdt = null;

            //    if (txtFromDate.Checked)
            //    {
            //        fdt = txtFromDate.Value;
            //    }
            //    if (txtToDate.Checked)
            //    {
            //        tdt = txtToDate.Value;
            //    }
                
            //    dgClientList.AutoGenerateColumns = false;
            //    dgClientList.DataSource = clientlist.GetAllClientBySearchCriteria(txtClientName.Text.Trim(), Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID);
            //
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
           
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    PatientPopUp objPatient = new PatientPopUp();
        //    objPatient.Show();
        //}

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgApplicantList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                string ClientName = Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[2].Value);

                int clientid = default(int);
                int.TryParse(Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[0].Value), out clientid);
                AddClient objAddClient = new AddClient(1, ClientName, clientid);
                objAddClient.Show();

                this.Hide();

            }
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Client", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    int patientId = default(int);
                    int.TryParse(Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[0].Value), out patientId);
                    bool IsDeleted = clientlist.DeleteClienttById(patientId, branchID);
                    if (IsDeleted)
                    {
                        MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindAccountGrid();
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Server error. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            ClientPopUp objClientPopUp = new ClientPopUp();
            objClientPopUp.Show();
        }

        private void txtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgApplicantList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                string ClientName = Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[3].Value);

                int clientid = default(int);
                int.TryParse(Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[2].Value), out clientid);
                AddClient objAddClient = new AddClient(1, ClientName, clientid);
                objAddClient.Show();

                this.Hide();

            }
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Client", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    int clientId = default(int);
                    int.TryParse(Convert.ToString(dgClientList.Rows[e.RowIndex].Cells[2].Value), out clientId);
                    bool IsDeleted = clientlist.DeleteClienttById(clientId, branchID);
                    if (IsDeleted)
                    {
                        MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindAccountGrid();
                    }
                    else
                    {
                        MessageBox.Show("Sorry! Server error. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                BindClientListGrid();
            //    //PatientsList.GetAllPatientBySearchCriteria(txtClientName.Text, 0, DateTime.Now, DateTime.Now);
            //    // txtFromDate.Checked ;
            //    // txtToDate.Checked = false;
            //    string fromdt = null;
            //    string todt = null;
                
            //    DateTime? fdt = null;
            //    DateTime? tdt = null;

            //    if (txtFromDate.Checked)
            //    {
                    
            //        //fromdt = Convert.ToDateTime(txtFromDate.Value).ToString("yyyy-MM-dd");
            //        //fdt = Convert.ToDateTime(fromdt);

            //        fdt = txtFromDate.Value.Date;

            //    }
            //    if (txtToDate.Checked)
            //    {
            //        //todt = Convert.ToDateTime(txtFromDate.Value).ToString("yyyy-MM-dd");
            //        //tdt = Convert.ToDateTime(todt);
            //        tdt = txtToDate.Value;
            //    }

            //    dgClientList.AutoGenerateColumns = false;
            //    dgClientList.DataSource = clientlist.GetClientListBySearchCriteria(txtClientName.Text.Trim(), Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID);
            //
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearData();
            //BindAccountGrid();
        }

        private void btnSendSMS_Click_1(object sender, EventArgs e)
        {
            try
            {
                Utility ut = new Utility();
                DashboardDAL dashboard_dal = new DashboardDAL();
                tblappointment tap = new tblappointment();
                //string msg = "This is a reminder that you have an appointment with us and we look forward to see you then.";
                string msg = "";
                //string mobile = "";
                bool ret = false;
                string companyname = "";
                List<DataGridViewRow> selectedRows = (from row in dgClientList.Rows.Cast<DataGridViewRow>()
                                                      where Convert.ToBoolean(row.Cells["Select"].Value) == true
                                                      select row).ToList();
                if (selectedRows.Count > 0)
                {
                    var Val = dashboard_dal.CompanyDetails();
                    if (Val != null)
                    {
                        companyname = Val.CompanyName;
                    }
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        string mobile = "";
                        //row.Cells["CustomerId"].Value)
                        if (selectedRows.Count > 0)
                        {
                            if (row.Cells["Mobile"].Value.ToString() != "" || row.Cells["Mobile"].Value != null)
                            {
                                //mobile += row.Cells["Mobile"].Value + ",";
                                mobile = row.Cells["Mobile"].Value.ToString();
                                //int clientid = Convert.ToInt32(row.Cells["Client ID"].Value.ToString());

                                int clientid = Convert.ToInt32(row.Cells["ClientId"].Value.ToString());
                                tap = AppointmentsList.GetAllApppointmentByClientid(clientid,mobile, branchID);

                                //tap = AppointmentsList.GetAllApppointmentByID(Convert.ToInt32(row.Cells["AppointmentId"].Value), branchID);

                                
                                //msg += "Dear " + tap.tblclient.ClientName
                                //msg += "Just to remind you that your appointment has been booked"  + System.Environment.NewLine;
                                //msg += "Just to remind you that your appointment for " + tap.tblservice.ServiceName + "has been booked on " + tap.AppointmentDate.Value.ToShortDateString() + System.Environment.NewLine;
                                //msg += "Dear " + tap.tblclient.ClientName;
                                //msg += "Just to inform you that your appointment for" + tap.tblservice.ServiceName + "has been booked on"+ tap.AppointmentDate.Value.ToShortDateString() +"at XXXX  ";
                                //msg += "Stay happy & healthy.";
                                //msg += "Thank  You,";
                                //msg += companyname;
                                msg = "Dear XXXX , Just to inform you that your appointment for XXXX  has been booked on XXXX  at XXXX . Stay happy & healthy. Thank  You, XXXX";

                                ret = ut.SendMessage(msg, mobile);

                            }

                        }

                    }

                    // mobile = mobile.Substring(0, mobile.Length - 1);
                    // bool ret = ut.SendMessage(msg, mobile);
                    if (ret)
                    {
                        MessageBox.Show("Reminder sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Message sending failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void btnSendEmail_Click_1(object sender, EventArgs e)
        {
            try
            {
                //mail sending function
                bool msg = false;
                Utility ut = new Utility();
                string usres = "";
                List<DataGridViewRow> selectedRows = (from row in dgClientList.Rows.Cast<DataGridViewRow>()
                                                      where Convert.ToBoolean(row.Cells["Select"].Value) == true
                                                      select row).ToList();
                if (selectedRows.Count > 0)
                {

                    foreach (DataGridViewRow row in selectedRows)
                    {
                        if (selectedRows.Count > 0)
                        {
                            if (row.Cells["Email"].Value != null)
                            {
                                usres += row.Cells["Email"].Value + ",";
                            }

                        }
                    }

                    msg = ut.SendMail(usres);
                    if (msg)
                    {
                        MessageBox.Show("Successfully Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sending Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ClientList_Load(object sender, EventArgs e)
        {

        }





    }
}
