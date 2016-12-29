using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Repository;
using EntityLayer;
using SPAPracticeManagement;
using SPAPracticeManagement.AppConstants;


//namespace DoctorPracticeManagement.Reports
namespace SPAPracticeManagement.Reports
{
    public partial class MyCalender : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
        SettingDAL objSettingDAL = new SettingDAL();
        ClientDAL objClient = new ClientDAL();
        //PatientDAL objClient = new PatientDAL();
        public DashboardDAL objDashboardDAL
        {
            get { return new DashboardDAL(); }
        }

        public AppointmentDAL Appointment
        {
            get { return new AppointmentDAL(); }
        }
        public ClientDAL clientList
        {
            get { return new ClientDAL(); }
        }
       
        public MyCalender()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindServiceType();
            //BindPatientName();
            BindClientName();

            this.ddlServiceCharge.SelectedIndexChanged += new EventHandler(ddmServiceCharge_SelectedIndexChanged);
            this.clientNameDrp.SelectedIndexChanged += new EventHandler(patientNameDrp_SelectedIndexChanged);
            Generate();
            GridFilterByDate();
        }

        private void Generate()
        {
            List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            for (int i = 0; i < StartTimeSchedule.Count; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                if (i == 0)
                {
                    col.HeaderText = "Time";
                }
                else
                {
                    col.HeaderText = StartTimeSchedule[i].ToString();
                }
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);
                dataGridView1.EnableHeadersVisualStyles = false;
                int colIndex = dataGridView1.Columns.Add(col);
                dataGridView1.Columns[i].Width = 80;

                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = StartTimeSchedule[i].ToString();
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.SteelBlue;
                dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);
            }
            dataGridView1.ClearSelection();
            dataGridView1.Columns[0].Frozen = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            GridFilterByDate();
        }

        private void GridFilterByDate()
        {
            //Generate();
            List<AppointmentEL> apppkg = new List<AppointmentEL>();
            List<AppointmentEL> appser = new List<AppointmentEL>();
            List<AppointmentEL> app = new List<AppointmentEL>();
            List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            string startTime = "";
            string endTime = "";
            string time = "";
            string s = txtPatientName.Text.Trim();
            int ClientId = 0;
            // "Sourav Roy (PatientId: 4)"
            if (!string.IsNullOrEmpty(s))
            {
                int start = s.IndexOf(":") + 1;
                int end = s.IndexOf(")", start);
                string result = s.Substring(start, end - start);
                ClientId = Convert.ToInt32(result.Trim());
            }
           // app = objDashboardDAL.SearchAppointmentByDate(dt);
           // app = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddmServiceCharge.SelectedValue.ToString()), Convert.ToInt32(patientNameDrp.SelectedValue.ToString()));
            apppkg = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddlServiceCharge.SelectedValue.ToString()), ClientId, branchID,1);
            appser = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddlServiceCharge.SelectedValue.ToString()), ClientId, branchID,0);
            app = apppkg.Union(appser).ToList();
            foreach (var item in app)
            {
                if (!string.IsNullOrEmpty(item.AppointmentTime))
                {
                    time = item.AppointmentTime;
                    string[] arr = time.Split('-');
                    startTime = arr[0].Trim();
                    endTime = arr[1].Trim();

                    int startindex = 1;
                    int endindex = 1;
                    startindex = StartTimeSchedule.IndexOf(startTime);
                    endindex = StartTimeSchedule.IndexOf(endTime);

                    if (startindex > 0 && endindex > 0)
                    {
                        dataGridView1.Rows[startindex].Cells[endindex].Style.BackColor = Color.Red;
                    }

                }
            }
        }

        

       

       

        



        //......................... Code Checked by Sam on 07092016.........................

        private void BindServiceType()
        {
            try
            {
                ddlServiceCharge.DisplayMember = "ServiceName";
                ddlServiceCharge.ValueMember = "ServiceId";
                ddlServiceCharge.DataSource = objSettingDAL.GetAllServices(branchID);
            }
            catch (Exception ex)
            {
            }
        }

        //private void BindPatientName()
        private void BindClientName()
        {
            try
            {
                clientNameDrp.DisplayMember = "ClientName";
                clientNameDrp.ValueMember = "ClientId";
                clientNameDrp.DataSource = objClient.GetAllClientByBranchId(branchID);
            }
            catch (Exception ex)
            {
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = DateTime.Today;
            ddlServiceCharge.SelectedIndex = 0;
            txtPatientName.Text = "";
            GridFilterByDate();
        }

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> ObjclientList = clientList.GetAllClientByClientName(txtPatientName.Text.Trim(), branchID);

            //List<PatientEL> objClientList = PatientsList.GetAllPatientByPatientName(txtPatientName.Text.Trim(),branchID);

            foreach (var item in ObjclientList)
            {
                namesCollection.Add(item.ClientName + " (ClientId: " + item.ClientId + ")");
            }
            txtPatientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPatientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPatientName.AutoCompleteCustomSource = namesCollection;


        }

        private void ddmServiceCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Generate();
            //List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            //string startTime = "";
            //string endTime = "";
            //string time = "";
            //dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //dataGridView1.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            //List<AppointmentEL> app = new List<AppointmentEL>();
            //// app = objDashboardDAL.SearchAppointmentByDateAndService(monthCalendar1.SelectionStart,Convert.ToInt32(ddmServiceCharge.SelectedValue.ToString()));
            // app = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddmServiceCharge.SelectedValue.ToString()), Convert.ToInt32(patientNameDrp.SelectedValue.ToString()));

            // foreach (var item in app)
            // {
            //     if (!string.IsNullOrEmpty(item.AppointmentTime))
            //     {
            //         time = item.AppointmentTime;

            //         string[] arr = time.Split('-');
            //         startTime = arr[0].Trim();
            //         endTime = arr[1].Trim();

            //         int startindex = 1;
            //         int endindex = 1;
            //         startindex = StartTimeSchedule.IndexOf(startTime);
            //         endindex = StartTimeSchedule.IndexOf(endTime);

            //         if (startindex > 0 && endindex > 0)
            //         {
            //             dataGridView1.Rows[startindex].Cells[endindex].Style.BackColor = Color.Red;
            //         }
            //     }
            // }

        }

        private void patientNameDrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Generate();
            //List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            //string startTime = "";
            //string endTime = "";
            //string time = "";
            //dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //dataGridView1.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            //List<AppointmentEL> app = new List<AppointmentEL>();
            //app = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddmServiceCharge.SelectedValue.ToString()), Convert.ToInt32(patientNameDrp.SelectedValue.ToString()));

            //foreach (var item in app)
            //{
            //    if (!string.IsNullOrEmpty(item.AppointmentTime))
            //    {

            //        time = item.AppointmentTime;

            //        string[] arr = time.Split('-');
            //        startTime = arr[0].Trim();
            //        endTime = arr[1].Trim();

            //        int startindex = 1;
            //        int endindex = 1;
            //        startindex = StartTimeSchedule.IndexOf(startTime);
            //        endindex = StartTimeSchedule.IndexOf(endTime);

            //        if (startindex > 0 && endindex > 0)
            //        {
            //            dataGridView1.Rows[startindex].Cells[endindex].Style.BackColor = Color.Red;
            //        }

            //    }
            //}
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

            string s = txtPatientName.Text.Trim();
            int ClientId = 0;
            // "Sourav Roy (PatientId: 4)"
            if (!string.IsNullOrEmpty(s))
            {
                int start = s.IndexOf(":") + 1;
                int end = s.IndexOf(")", start);
                string result = s.Substring(start, end - start);
                ClientId = Convert.ToInt32(result.Trim());
            }

            Generate();
            List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            string startTime = "";
            string endTime = "";
            string time = "";
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            List<AppointmentEL> apppkg = new List<AppointmentEL>();
            List<AppointmentEL> appsvc = new List<AppointmentEL>();
            List<AppointmentEL> app = new List<AppointmentEL>();
            apppkg = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddlServiceCharge.SelectedValue.ToString()), ClientId, branchID, 1);
            appsvc = objDashboardDAL.SearchAppointmentByDateAndServiceAndName(monthCalendar1.SelectionStart, Convert.ToInt32(ddlServiceCharge.SelectedValue.ToString()), ClientId, branchID, 0);
            app = apppkg.Union(appsvc).ToList();
            foreach (var item in app)
            {
                if (!string.IsNullOrEmpty(item.AppointmentTime))
                {

                    time = item.AppointmentTime;

                    string[] arr = time.Split('-');
                    startTime = arr[0].Trim();
                    endTime = arr[1].Trim();

                    int startindex = 1;
                    int endindex = 1;
                    startindex = StartTimeSchedule.IndexOf(startTime);
                    endindex = StartTimeSchedule.IndexOf(endTime);

                    if (startindex > 0 && endindex > 0)
                    {
                        dataGridView1.Rows[startindex].Cells[endindex].Style.BackColor = Color.Red;
                    }

                }
            }
        }

        //......................... Code Above Checked by Sam on 07092016.........................
    }
}
