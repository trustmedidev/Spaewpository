using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer; 
using System.Windows.Forms.DataVisualization.Charting;
using DataAccessLayer.Repository;
using System.IO;

namespace SPAPracticeManagement
{
    public partial class Home : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        #region Properties
        public DashboardDAL objDashboardDAL
        {
            get { return new DashboardDAL(); }
        }

        #endregion
        public Home()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            /*--------------Code Added By Sandip Das on 07-06-2016----------------*/

            string dirLogo = Application.StartupPath + @"\Logo";

            if (!Directory.Exists(dirLogo))
            {
                Directory.CreateDirectory(dirLogo);
            }

            string dirCReport = Application.StartupPath + @"\ClientReport";

            if (!Directory.Exists(dirCReport))
            {
                Directory.CreateDirectory(dirCReport);
            }

            string dirCDocument = Application.StartupPath + @"\ClientDocuments";

            if (!Directory.Exists(dirCDocument))
            {
                Directory.CreateDirectory(dirCDocument);
            }

            string dirInvoice = Application.StartupPath + @"\Invoice";

            if (!Directory.Exists(dirInvoice))
            {
                Directory.CreateDirectory(dirInvoice);
            }

            string dirMImage = Application.StartupPath + @"\MemberImage";

            if (!Directory.Exists(dirMImage))
            {
                Directory.CreateDirectory(dirMImage);
            }

            string dirInvImage = Application.StartupPath + @"\InventoryImages";

            if (!Directory.Exists(dirInvImage))
            {
                Directory.CreateDirectory(dirInvImage);
            }
            /*--------------END----------------*/

            DashboardEL objDashboard = objDashboardDAL.GetApppointmentCountBydate(branchID);
            List<MonthPatientChartByService> objchart = new List<MonthPatientChartByService>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            int bypackage = 1;
            List<AppointmentEL> app = new List<AppointmentEL>();
            app = objDashboardDAL.GetAppointByDay(branchID, bypackage);
            bypackage = 0;
            List<AppointmentEL> appoint = new List<AppointmentEL>();
            appoint = objDashboardDAL.GetAppointByDay(branchID, bypackage);

            List<AppointmentEL> appointment = new List<AppointmentEL>();
            appointment = app.Union(appoint).ToList();
            AppointSchedule(appointment);

            
            int w = panel5.Width;
            
            
            //chartNoclientMonthly.Width = w / 2 - 10;
            //chartMonthlycollection.Width = w / 2 - 10;
            //var charts = chartMonthlycollection.Location;
            //charts.X = w / 2;

            Title patientchartCol = chartMonthlycollection.Titles.Add("Monthly Collection");
            patientchartCol.Font = new System.Drawing.Font("Arial", 14f, FontStyle.Bold);
            patientchartCol.ForeColor = System.Drawing.Color.FromName("White");
            patientchartCol.BackColor = System.Drawing.Color.FromArgb(145, 20, 58);
           

            Title patientchartSr = chartNoclientMonthly.Titles.Add("No of Clients Monthly (2016)");
            patientchartSr.Font = new System.Drawing.Font("Arial", 14f, FontStyle.Bold);
            patientchartSr.ForeColor = System.Drawing.Color.FromName("White"); 
            patientchartSr.BackColor = System.Drawing.Color.FromArgb(145, 20, 58);

            DashboardEL d = new DashboardEL();
            objchart = objDashboardDAL.GetMonthlyClientChartByService(branchID);
            if (objchart.Count == 0)
            {
                MonthPatientChartByService LCS = new MonthPatientChartByService();
                LCS.ServiceName = "No Data Found";
                LCS.Month1 = 0;
                LCS.Month2 = 0;
                LCS.Month3 = 0;
                objchart.Add(LCS);
            }

            dt = objDashboardDAL.ToDataTable(objchart);
            LoadChartDataService(dt);

            List<MonthPatientChartByCollection> objchart1 = new List<MonthPatientChartByCollection>();
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            objchart1 = objDashboardDAL.GetMonthlyClientChartByCollection(branchID);

            if (objchart1.Count == 0)
            {
                MonthPatientChartByCollection MCS = new MonthPatientChartByCollection();
                MCS.ServiceName = "No Data Found";
                MCS.Month1 = 0;
                MCS.Month2 = 0;
                MCS.Month3 = 0;
                objchart1.Add(MCS);
            }

            dt1 = objDashboardDAL.ToDataTable(objchart1);
            LoadChartDataCollection(dt1);
             
        }

        private void LoadChartDataService(DataTable initialDataSource)
        {
            int currmonth = DateTime.Today.Month;

            for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                Series series = new Series();

                string monthname = "";
                switch (currmonth)
                {
                    case 1:
                        monthname = "Jan";
                        currmonth = 12;
                        break;
                    case 2:
                        monthname = "Feb";
                        currmonth = 1;
                        break;
                    case 3:
                        monthname = "Mar";
                        currmonth = 2;
                        break;
                    case 4:
                        monthname = "Apr";
                        currmonth = 3;
                        break;
                    case 5:
                        monthname = "May";
                        currmonth = 4;
                        break;
                    case 6:
                        monthname = "Jun";
                        currmonth = 5;
                        break;
                    case 7:
                        monthname = "Jul";
                        currmonth = 6;
                        break;
                    case 8:
                        monthname = "Aug";
                        currmonth = 7;
                        break;
                    case 9:
                        monthname = "Sep";
                        currmonth = 8;
                        break;
                    case 10:
                        monthname = "Oct";
                        currmonth = 9;
                        break;
                    case 11:
                        monthname = "Nov";
                        currmonth = 10;
                        break;
                    case 12:
                        monthname = "Dec";
                        currmonth = 11;
                        break;
                    default:
                        monthname = "";
                        break;
                }

                foreach (DataRow dr in initialDataSource.Rows)
                {
                    int y = 0;
                    string x = "";
                    y = Convert.ToInt32(dr[i]);
                    x = dr["ServiceName"].ToString();
                    series.Points.AddXY(x, y);
                }
                //series.Name = initialDataSource.Columns[i].Caption;
                series.Name = monthname;
                chartNoclientMonthly.Series.Add(series);
            }
        }

        private void LoadChartDataCollection(DataTable initialDataSource)
        {
            int currmonth = DateTime.Today.Month;
            for (int i = 1; i < initialDataSource.Columns.Count; i++)
            {
                Series series = new Series();

                string monthname = "";
                switch (currmonth)
                {
                    case 1:
                        monthname = "Jan";
                        currmonth = 12;
                        break;
                    case 2:
                        monthname = "Feb";
                        currmonth = 1;
                        break;
                    case 3:
                        monthname = "Mar";
                        currmonth = 2;
                        break;
                    case 4:
                        monthname = "Apr";
                        currmonth = 3;
                        break;
                    case 5:
                        monthname = "May";
                        currmonth = 4;
                        break;
                    case 6:
                        monthname = "Jun";
                        currmonth = 5;
                        break;
                    case 7:
                        monthname = "Jul";
                        currmonth = 6;
                        break;
                    case 8:
                        monthname = "Aug";
                        currmonth = 7;
                        break;
                    case 9:
                        monthname = "Sep";
                        currmonth = 8;
                        break;
                    case 10:
                        monthname = "Oct";
                        currmonth = 9;
                        break;
                    case 11:
                        monthname = "Nov";
                        currmonth = 10;
                        break;
                    case 12:
                        monthname = "Dec";
                        currmonth = 11;
                        break;
                    default:
                        monthname = "";
                        break;
                }

                foreach (DataRow dr in initialDataSource.Rows)
                {
                    decimal y = 0;
                    string x = "";
                    y = Convert.ToDecimal(dr[i]);
                    x = dr["ServiceName"].ToString();
                    series.Points.AddXY(x, y);
                }
                //series.Name = initialDataSource.Columns[i].Caption;
                series.Name = monthname;
                chartMonthlycollection.Series.Add(series);
            }
        }

        private void AppointSchedule(List<AppointmentEL> tblap)
        {

            string pName = string.Empty;
            int y = 5;
            foreach (var item in tblap)
            {
                Label label = new Label();
                int count = appoint_panel.Controls.OfType<Label>().ToList().Count;

                if (count > 5 && count < 12)
                {
                    y = 60;
                    count = count - 6;

                }
                else if (count > 11)
                {
                    y = 60;
                    count = count - 6;
                    //y = 100;
                    //count = count - 12;
                    //appoint_panel.Height = 150;
                    chartNoclientMonthly.Location = new Point(0, 165);
                    chartMonthlycollection.Location = new Point(chartMonthlycollection.Location.X, 165);
                }

                label.Location = new Point((180 * count) + 20, y);

                string name = "";
                if (!string.IsNullOrEmpty(item.Service) && !string.IsNullOrEmpty(item.DoctorName))
                {
                    name = "Doctor Name : " + item.DoctorName;
                }
                else
                {
                    name = "Service Name : " + item.Service;
                }


                label.Size = new Size(160, 50);
                label.Name = "label_" + (count + 1);
                label.Text = name + Environment.NewLine + item.ClientName + Environment.NewLine + item.AppointmentTime;
                label.Font = new Font("Arial", 8, FontStyle.Regular);
                label.ForeColor = Color.SteelBlue;
                label.Margin = new Padding(1);
                label.BorderStyle = BorderStyle.FixedSingle;
                label.TextAlign = ContentAlignment.MiddleCenter;
                appoint_panel.Controls.Add(label);




            }
        }

        private void chartMonthlycollection_Click(object sender, EventArgs e)
        {

        }
    }
}
