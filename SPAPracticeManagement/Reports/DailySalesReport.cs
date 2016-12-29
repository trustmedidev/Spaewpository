using DataAccessLayer;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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

namespace SPAPracticeManagement.Reports
{
    public partial class DailySalesReport : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
        string loginName = AppsPropertise.UserDetails.UserName + " (" + DateTime.Now + ")";
        ReportDAL reportDAL = new ReportDAL();
        public DailySalesReport()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindTherapist();
            
        }

        private void DailySalesReport_Load(object sender, EventArgs e)
        {

        }

        private void DailySalesReport_Load_1(object sender, EventArgs e)
        {
        }

        private void DailySalesReport_Load_2(object sender, EventArgs e)
        {
            try
            {                
                // TODO: This line of code loads data into the 'spamanagementDataSet1.DailySalesReport' table. You can move, or remove it, as needed.
                StringBuilder sb = new StringBuilder();
                sb.Append(@" GROUP BY ta.AppointmentId");
                string stt = sb.ToString();
                ReportParameter p1 = new ReportParameter("serviceType", stt);
                ReportParameter p2 = new ReportParameter("loginUser", loginName);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                this.dailySalesReportTableAdapter.Fill(this.spamanagementDataSet1.DailySalesReport, stt, loginName);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private DataSet SalesReportData()
        {
            DataSet ds = new DataSet();
            // MySqlDataAdapter da = new MySqlDataAdapter();
            // string cs = @"server=localhost;userid=user12; password=34klq*;database=mydb";
            string cs = @"port=3306;server=localhost;user id=root;password=admin;database=spamanagement;";
            MySqlConnection con = null;
            try
            {
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (con = new MySqlConnection(cs))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DailySalesReport", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(ds);



                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Report uploading failed.");

            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }

            }
            return ds;
        }

        private void chk_allsel_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allsel.Checked)
            {

                for (int n = 0; n < chk_seltype.Items.Count; n++)
                {
                    chk_seltype.SetItemChecked(n, true);
                }
            }
            else
            {
                if (chk_seltype.CheckedItems.Count < chk_seltype.Items.Count)
                {
                    chk_allsel.Checked = false;
                }
                else
                {

                    for (int n = 0; n < chk_seltype.Items.Count; n++)
                    {
                        chk_seltype.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_seltype_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool type = default(bool);
            foreach (var itemchecked in chk_seltype.CheckedItems)
            {
                //type = (string)itemchecked;
                if (itemchecked.ToString().Substring(3) == "Service")
                {
                    type = false;
                }
                else { type = true; }

            }
            if (chk_seltype.CheckedItems.Count == chk_seltype.Items.Count)
            {
                chk_allsel.Checked = true;
            }
            else
            {
                chk_allsel.Checked = false;
            }
        }

        private void chk_paymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_paymentmode.CheckedItems.Count == chk_paymentmode.Items.Count)
            {
                chk_allpayment.Checked = true;
            }
            else
            {
                chk_allpayment.Checked = false;
            }
        }
        private void chk_allpayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allpayment.Checked)
            {

                for (int n = 0; n < chk_paymentmode.Items.Count; n++)
                {
                    chk_paymentmode.SetItemChecked(n, true);
                }

            }
            else
            {

                if (chk_paymentmode.CheckedItems.Count < chk_paymentmode.Items.Count)
                {
                    chk_allpayment.Checked = false;
                }
                else
                {

                    for (int n = 0; n < chk_paymentmode.Items.Count; n++)
                    {
                        chk_paymentmode.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_alltax_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_alltax.Checked)
            {

                for (int n = 0; n < chk_taxtype.Items.Count; n++)
                {
                    chk_taxtype.SetItemChecked(n, true);
                }

            }
            else
            {

                if (chk_taxtype.CheckedItems.Count < chk_taxtype.Items.Count)
                {
                    chk_alltax.Checked = false;
                }
                else
                {

                    for (int n = 0; n < chk_taxtype.Items.Count; n++)
                    {
                        chk_taxtype.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_taxtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_taxtype.CheckedItems.Count == chk_taxtype.Items.Count)
            {
                chk_alltax.Checked = true;
            }
            else
            {
                chk_alltax.Checked = false;
            }
        }

        private void chk_therapist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_therapist.CheckedItems.Count == chk_therapist.Items.Count)
            {
                chk_alltherapist.Checked = true;
            }
            else
            {
                chk_alltherapist.Checked = false;
            }
        }

        private void chk_alltherapist_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_alltherapist.Checked)
            {

                for (int n = 0; n < chk_therapist.Items.Count; n++)
                {
                    chk_therapist.SetItemChecked(n, true);
                }

            }
            else
            {

                if (chk_therapist.CheckedItems.Count < chk_therapist.Items.Count)
                {
                    chk_alltherapist.Checked = false;
                }
                else
                {

                    for (int n = 0; n < chk_therapist.Items.Count; n++)
                    {
                        chk_therapist.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void BindTherapist()
        {
            List<TherapistEL> result = reportDAL.GetAllTherapistNameID(branchID);

            if (result.Count > 0)
            {
                chk_therapist.DataSource = result;
                chk_therapist.DisplayMember = "Name";
                chk_therapist.ValueMember = "TherapistId";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            StringBuilder sb = new StringBuilder();
            sb.Append(@" GROUP BY ta.AppointmentId");
            string stt = sb.ToString();
            ReportParameter p1 = new ReportParameter("serviceType", stt);
            ReportParameter p2 = new ReportParameter("loginUser", loginName);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.dailySalesReportTableAdapter.Fill(this.spamanagementDataSet1.DailySalesReport, stt, loginName);
            this.reportViewer1.RefreshReport();
        }

        private void clearData()
        {
            int count = 0;
            txtFromDate.Value = DateTime.Now;
            txtToDate.Value = DateTime.Now;
            txtFromDate.Checked = false;
            txtToDate.Checked = false;

            if (chk_allsel.Checked == true)
            {
                chk_allsel.Checked = false;
            }
            count = chk_seltype.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_seltype.CheckedItems.Count > 0)
                {
                    chk_seltype.SetItemChecked(i, false);
                }
            }

            if (chk_alltherapist.Checked == true)
            {
                chk_alltherapist.Checked = false;
            }
            count = chk_therapist.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_therapist.CheckedItems.Count > 0)
                {
                    chk_therapist.SetItemChecked(i, false);
                }
            }

            if (chk_allpayment.Checked == true)
            {
                chk_allpayment.Checked = false;
            }
            count = chk_paymentmode.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_paymentmode.CheckedItems.Count > 0)
                {
                    chk_paymentmode.SetItemChecked(i, false);
                }
            }

            if (chk_alltax.Checked == true)
            {
                chk_alltax.Checked = false;
            }
            count = chk_taxtype.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_taxtype.CheckedItems.Count > 0)
                {
                    chk_taxtype.SetItemChecked(i, false);
                }
            }


        }

        private void GenerateReport()
        {
            string servicetypechk = "";
            string servicetypeVal = "";
            if (chk_allsel.Checked)
            {
                servicetypeVal = "";
            }
            else
            {
                foreach (var itemchecked in chk_seltype.CheckedItems)
                {
                    if (chk_seltype.CheckedItems.Count > 1)
                    {
                        servicetypeVal = "";
                    }
                    else
                    {
                        servicetypechk = (string)itemchecked;
                        if (servicetypechk == "By Service")
                        {
                            servicetypeVal = "N/A";
                        }
                        else if (servicetypechk == "By Package")
                        {
                            servicetypeVal = "N/A";
                        }
                    }
                }
            }

            string paychk = "";
            string paychkresult = "";
            string finalPay = "";
            if (chk_allpayment.Checked)
            {
                paychk = "'CASH','CREDIT','CARD'";
                finalPay = "";
            }
            else
            {
                foreach (var itemchecked in chk_paymentmode.CheckedItems)
                {
                    paychk = (string)itemchecked;
                    paychk = "'" + paychk.Substring(3).ToUpper() + "',";
                    paychkresult = paychkresult + paychk;
                }
                if (chk_paymentmode.CheckedItems.Count > 0)
                {
                    finalPay = paychkresult.TrimEnd(',');
                }
            }

            string taxtOpt = "";
            if (chk_alltax.Checked)
            {
                taxtOpt = "";
            }
            else
            {
                foreach (var itemchecked in chk_taxtype.CheckedItems)
                {
                    taxtOpt = (string)itemchecked;
                }
            }


            int ThID;
            string TherapistList = "";
            string FinalTherapistList = "";
            foreach (var itemchecked in chk_therapist.CheckedItems)
            {
                var row = (itemchecked as TherapistEL);
                ThID = (int)row.TherapistId;
                TherapistList = TherapistList + ThID + ",";
            }
            if (chk_therapist.CheckedItems.Count > 0)
            {
                FinalTherapistList = TherapistList.TrimEnd(',');
            }


            DateTime? fdt = null;
            DateTime? tdt = null;
            string stdate = "";
            string enddate = "";
            if (txtFromDate.Checked)
            {
                fdt = txtFromDate.Value.Date;
                stdate = Convert.ToDateTime(fdt).ToString("yyyy-MM-dd");
            }
            if (txtToDate.Checked)
            {
                tdt = txtToDate.Value.Date;
                enddate = Convert.ToDateTime(tdt).ToString("yyyy-MM-dd");
            }





            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(servicetypeVal))
            {
                if (servicetypechk == "By Service")
                {
                    sb.Append(@" AND ");
                    sb.Append(@"ta.`ByPackage`=FALSE ");
                }
                else if (servicetypechk == "By Package")
                {
                    sb.Append(@" AND ");
                    sb.Append(@"ta.`ByPackage`=TRUE ");
                }
            }

            if (!string.IsNullOrEmpty(finalPay))
            {
                sb.Append(@"AND ");
                sb.Append(@"ta.PaymentMode IN(" + finalPay + ") ");
            }

            if (!string.IsNullOrEmpty(taxtOpt))
            {
                if (taxtOpt == "By Taxable")
                {
                    sb.Append(@"AND ");
                    sb.Append(@"ta.TotalTax <>0 ");
                }
                else if (taxtOpt == "By Non Taxable")
                {
                    sb.Append(@"AND ");
                    sb.Append(@"ta.TotalTax =0 ");
                }

            }

            if (!string.IsNullOrEmpty(FinalTherapistList))
            {
                sb.Append(@"AND ");
                sb.Append(@"th.TherapistId IN(" + FinalTherapistList + ") ");
            }

            if (fdt != null && tdt != null)
            {
                sb.Append(@"AND ");
                sb.Append(@"ta.AppointmentDate BETWEEN '" + stdate + "' AND '" + enddate + "'");

            }
            else if (fdt != null && tdt == null)
            {
                sb.Append(@"AND ");
                sb.Append(@"ta.AppointmentDate >= '" + stdate + "'");
            }
            else if (tdt != null && fdt == null)
            {
                sb.Append(@"AND ");
                sb.Append(@"ta.AppointmentDate <= '" + enddate + "'");
            }

            sb.Append(@" GROUP BY ta.AppointmentId");
            string st = sb.ToString();
            ReportParameter p1 = new ReportParameter("serviceType", st);
            ReportParameter p2 = new ReportParameter("loginUser", loginName);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.dailySalesReportTableAdapter.Fill(this.spamanagementDataSet1.DailySalesReport, st, loginName);
            this.reportViewer1.RefreshReport();
        }
    }
}
