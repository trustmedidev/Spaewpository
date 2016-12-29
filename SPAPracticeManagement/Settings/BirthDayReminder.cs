using DataAccessLayer;
using DataAccessLayer.Repository;
using EntityLayer;
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

namespace SPAPracticeManagement.Settings
{
    public partial class BirthDayReminder : Dashboard
    {
        int? branchID = Convert.ToInt32(ConfigurationManager.AppSettings["BranchID"]);
        public AppointmentDAL AppointmentsList
        {
            get { return new AppointmentDAL(); }
        }

        SettingDAL objSettingDAL = new SettingDAL();
        public ClientDAL PatientsList
        {
            get { return new ClientDAL(); }
        }
        public BirthDayReminder()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //txtFromDate.Checked = true;
            //cmb_planType.SelectedIndex = 0;
            BindAccountGrid();
            BindCustomerList();

            //cmb_planType.Items.Insert(0, "select a plan");
        }
        private void BindAccountGrid()
        {
            try
            {
                DateTime? fromdt = null;
                DateTime? todt = null;
                List<ClientEL> ApList = new List<ClientEL>();

                if (txtFromDate.Checked)
                {
                    fromdt = txtFromDate.Value;
                }
                //string planType = default(string);

                //string item = Convert.ToString(cmb_planType.SelectedItem);
                ////if (planType == null)
                //{
                //    planType = null;
                //}
                //if (item == "-- Select Duration Type --")
                //{
                //    planType = null;

                //}

                //else if (item == "Monthly")
                //{
                //    todt = fromdt.Value.AddMonths(1);
                //    //planType = item.Substring(0, 1);
                //}
                //else if (item == "Quaterly")
                //{
                //    todt = fromdt.Value.AddMonths(3);
                //    //planType = item.Substring(0, 1);
                //}
                //else if (item == "Halfyearly")
                //{
                //    todt = fromdt.Value.AddMonths(6);
                //    //planType = item.Substring(0, 1);
                //}

                //else if (item == "Yearly")
                //{
                //    todt = fromdt.Value.AddYears(1);
                //    planType = item.Substring(0, 1);
                //}

                string clientname = null;
                //string clientname = txtPatientName.Text.Trim();
                if (!string.IsNullOrEmpty(txtPatientName.Text.Trim()))
                {
                    clientname = txtPatientName.Text.Split('(')[0].Trim();
                }

                /*-----------------------Code Added By Sandip Das on 08-06-2016----------------*/
                if (!chkBirthdayToday.Checked)
                {
                    //ApList = objSettingDAL.GetAllClientForBirthday(clientname, fromdt, todt, branchID);
                    ApList = objSettingDAL.GetAllClientForBirthday(clientname, fromdt, branchID);

                    if (ApList.Count > 0)
                    {

                        dgApplicantList.AutoGenerateColumns = false;
                        dgApplicantList.DataSource = ApList.GroupBy(g => new { g.ClientName, g.Mobile }).Select(g => g.FirstOrDefault()).ToList();
                    }
                    else
                    {
                        dgApplicantList.AutoGenerateColumns = false;
                        dgApplicantList.DataSource = null;
                        //MessageBox.Show("No Data Found");
                    }
                }
                /*-----------------------END----------------*/
                //else if (txtPatientName.Text.Trim() == "" && !txtFromDate.Checked)
                //{
                //    BindAccountGrid();
                //}
                //else
                //{
                //    dgApplicantList.DataSource = null;
                //}
            }
            catch (Exception ex) { }
            //dgApplicantList.AutoGenerateColumns = false;
            //dgApplicantList.DataSource = AppointmentsList.GetAllClient(branchID).GroupBy(g => g.ClientName).Select(g => g.FirstOrDefault()).ToList();
        }
        private void clearData()
        {
            txtFromDate.Checked = true;
            txtFromDate.Value = DateTime.Today;
            txtFromDate.Checked = false;
            txtPatientName.Text = "";
            cmb_planType.SelectedIndex = 0;
            chkBirthdayToday.Checked = false;
            //BindAccountGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindAccountGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindAccountGrid();
            //try
            //{
            //    DateTime? dt = null;
            //    List<ClientEL> ApList = new List<ClientEL>();

            //    if (txtFromDate.Checked)
            //    {
            //        dt = txtFromDate.Value;
            //    }
            //    string planType = default(string);

            //    string item = Convert.ToString(cmb_planType.SelectedItem);
            //    //if (planType == null)
            //    //{
            //    //    planType = null;
            //    //}
            //    if (item == "-- Select a Plan Type --")
            //    {
            //        planType = null;
            //    }
            //    else
            //    {
            //        planType = item.Substring(0, 1);
            //    } 
            //    ApList = objSettingDAL.GetAllClientForBirthday(txtPatientName.Text.Trim(), dt, planType, branchID);

            //    if (ApList.Count > 0)
            //    {
            //        dgApplicantList.AutoGenerateColumns = false;
            //        dgApplicantList.DataSource = ApList.GroupBy(g => g.ClientName).Select(g => g.FirstOrDefault()).ToList();
            //    }
            //    else if (txtPatientName.Text.Trim() == "" && !txtFromDate.Checked)
            //    {
            //        BindAccountGrid();
            //    }
            //    else
            //    {
            //        dgApplicantList.DataSource = null; 
            //    }
            //}
            //catch (Exception ex) { }
        }

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendBdaySMS_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardDAL dashboard_dal = new DashboardDAL();
                Utility ut = new Utility();
                tblappointment tap = new tblappointment();
                tblclient tc = new tblclient();
                string email = "";
                string mobile = "";
                string companyname = "";
                bool ret = false;
                List<DataGridViewRow> selectedRows = (from row in dgApplicantList.Rows.Cast<DataGridViewRow>()
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
                        string msgemail = "";
                        if (selectedRows.Count > 0)
                        {
                            if (row.Cells["Email"].Value.ToString() != "" || row.Cells["Mobile"].Value != null)
                            {
                                email = row.Cells["Email"].Value.ToString();
                                tc = AppointmentsList.GetAllClientByID(Convert.ToInt32(row.Cells["ClientId"].Value), Convert.ToString(row.Cells["Mobile"].Value), branchID);
                                msgemail += "Dear " + tc.ClientName + System.Environment.NewLine;
                                msgemail += "Wish you a very HAPPY BIRTHDAY." + System.Environment.NewLine;
                                msgemail += "Thank  You," + System.Environment.NewLine;
                                msgemail += companyname;
                                ret = ut.SendBirthDayMail(msgemail, email);
                            }

                            /*--------------------------Code Added By Sandip Das on 08-06-2016--------------------*/
                            if (row.Cells["Mobile"].Value.ToString() != "" || row.Cells["Mobile"].Value != null)
                            {
                                string msgPhone = "";
                                mobile += row.Cells["Mobile"].Value.ToString().Substring(row.Cells["Mobile"].Value.ToString().Length - 10);
                                tc = AppointmentsList.GetAllClientByID(Convert.ToInt32(row.Cells["ClientId"].Value), Convert.ToString(row.Cells["Mobile"].Value), branchID);
                                msgPhone += "Dear " + tc.ClientName;
                                msgPhone += " Many Many Happy Returns Of The Day.";
                                msgPhone += " Thank You, ";
                                msgPhone += companyname;
                                ret = ut.SendMessage(msgPhone, mobile);
                            }
                            /*--------------------------END--------------------*/
                        }
                    }
                    if (ret)
                    {
                        MessageBox.Show("SMS sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SMS sending failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAccountGrid();
        }

        private void chkBirthdayToday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBirthdayToday.Checked)
            {
                var bdaylist = objSettingDAL.ShowTodaysBirthdayList(branchID).GroupBy(g => g.ClientName).Select(s => s.FirstOrDefault()).ToList();
                if (bdaylist.Count > 0)
                {
                    dgApplicantList.AutoGenerateColumns = false;
                    dgApplicantList.DataSource = bdaylist;
                }
                else
                {
                    dgApplicantList.DataSource = null;
                }
            }
            else
            {
                BindAccountGrid();
            }
        }

        private void BindCustomerList()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = PatientsList.GetAllClientByClientName(txtPatientName.Text.Trim(), branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (Mobile: " + item.Mobile + ")");
            }

            txtPatientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPatientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPatientName.AutoCompleteCustomSource = namesCollection;
        }
    }
}
