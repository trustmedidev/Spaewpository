using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Settings
{
    public partial class ImportService : Form
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        public ImportService()
        {
            InitializeComponent();

            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = Application.StartupPath + @"\Service\DemoFormatServiceRate.xlsx";
            linkLabel_Demoformat.Links.Add(link);
        }
        private void btn_dialog_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx";

                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txt_filename.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ReadExcelFile(string Path)
        {
            try
            {
                ServiceDAL sd = new ServiceDAL();
                List<tblservice> LSI = new List<tblservice>();
                List<tblmapservice> MapSI = new List<tblmapservice>();

                string sqlquery = "Select * From [Sheet1$]";
                DataSet ds = new DataSet();
                string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
                OleDbConnection con = new OleDbConnection(constring + "");
                OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                List<int> res = null;

                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(row[0].ToString()))
                    {
                        tblservice SI = new tblservice();
                        tblmapservice MSI = new tblmapservice();

                        SI.FK_BranchID = branchID;
                        MSI.FK_BranchId = branchID;
                        SI.ServiceName = row[0].ToString();
                        MSI.Amount = Convert.ToDecimal(row[1].ToString() == "" ? "0.00" : row[1].ToString());
                        MSI.EffectiveDate = Convert.ToDateTime((row[2].ToString() == "" ? DateTime.Now.Date.ToString() : row[2].ToString()), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        SI.TimeExpende = Convert.ToInt32(row[3].ToString());
                        SI.IsActive = true;
                        LSI.Add(SI);
                        MapSI.Add(MSI);
                    }
                }

                sd.InsertImportSerivceAndTime(LSI);
                sd.InsertImportRateAndEffectiveDate(MapSI);

                MessageBox.Show("File imported successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("File not supported");
            }

        }

        private void button_ImportData_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = txt_filename.Text;
                ReadExcelFile(filename);
            }
            catch (Exception)
            {
                MessageBox.Show("File not supported");
            }
            finally
            {
                this.Hide();
            }
        }

        private void linkLabel_Demoformat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
