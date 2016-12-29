using DataAccessLayer;
using DataAccessLayer.Repository;
using SPAPracticeManagement.AppConstants;
using SPAPracticeManagement.CustomControls.Appointment;
using EntityLayer;
using MySql;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Windows.Forms;
using SPAPracticeManagement;



namespace SPAPracticeManagement.Reports
{
    public partial class ClientReportUpload : Dashboard
    {
        ReportDAL objReportDAL = new ReportDAL();
        int? branchID = AppsPropertise.UserDetails.BranchId;
        private int _UpdatedReportId;
        public int UpdatedReportId
        {
            get { return _UpdatedReportId; }
            set { _UpdatedReportId = value; }
        }
        public AppointmentDAL AppointmentsList
        {
            get { return new AppointmentDAL(); }
        }

        public ClientDAL ClientsList        //public PatientDAL ClientsList
        {
            get { return new ClientDAL(); }
        }
        SettingDAL objSettingDAL = new SettingDAL();
        UserDAL objUserDal = new UserDAL();
        public ClientReportUpload()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            string dir = Application.StartupPath + @"\ClientReport";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            GetReport();
        }


        #region Control Function Strat
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateForm())
                {

                    string FilePath = SaveFiles();
                    int i = 0;
                    if (UpdatedReportId > 0)
                    {
                        i = UpdateReportData(UpdatedReportId, txtDocName.Text.Trim(), txtDescription.Text.Trim(), FilePath);
                    }
                    else
                    {
                        string s = txtClientName.Text.Trim();
                        string clientname = s.Substring(0, s.IndexOf("(")).Trim();
                        int start = s.IndexOf("(") + 1;
                        int end = s.IndexOf(")", start);
                        string result = s.Substring(start, end - start);
                        string mobile = result.Trim();

                        ClientEL objclientel = objReportDAL.GetClientIdByClientnameByMobileNumber(clientname, mobile, branchID);
                        int clientid = Convert.ToInt32(objclientel.ClientId);
                        string pName = s.Substring(0, s.IndexOf("("));
                        string username = "";
                        string password = "";
                        string BranchCode = "";
                        string BranchName = "";

                        UserEL uel = new UserEL();
                        uel = objUserDal.GetUserDetailsByPatientId(clientid, branchID);
                        if (uel != null)
                        {
                            username = uel.UserName;
                            password = uel.Password;
                            BranchCode = uel.BranchCode;
                            BranchName = uel.BranchName;
                        }
                        tblreport objtblreport = new tblreport();
                        objtblreport.ClientId = clientid;
                        objtblreport.ReportName = txtDocName.Text.Trim();
                        objtblreport.ReportDescription = txtDescription.Text.Trim();
                        objtblreport.ReportPath = FilePath;
                        objtblreport.ClientName = clientname;
                        objtblreport.UserName = username;
                        objtblreport.Passwords = password;
                        objtblreport.BranchCode = BranchCode;
                        objtblreport.BranchName = BranchName;
                        objtblreport.IsActive = true;
                        objtblreport.Fk_BranchID = branchID;
                        i = objReportDAL.InsertUpdateClientReportUpload(objtblreport);
                    }
                    if (i > 0)
                    {
                        if (i > 0)
                        {
                            MessageBox.Show("Document Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        clearData();
                        GetReport();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report uploading failed.");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();

        }
        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClientList = ClientsList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);
            foreach (var item in objClientList)
            {
                namesCollection.Add(item.ClientName + " (" + item.Mobile + ")");
            }
            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    txtFileName.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion Control Function End
        private int UpdateReportData(int ReportId, string ReportName, string ReportDescription, string ReportPath)
        {
            int i = 0;
            try
            {
                tblreport objtblreport = new tblreport();
                objtblreport.ReportId = ReportId;
                objtblreport.ReportName = ReportName;
                objtblreport.ReportDescription = ReportDescription;
                objtblreport.ReportPath = ReportPath;
                i = objReportDAL.InsertUpdateClientReportUpload(objtblreport);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report uploading failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {



            }
            return i;
        }




        private void clearData()
        {
            txtClientName.Enabled = true;
            txtClientName.Text = "";
            txtFileName.Text = "";
            txtDocName.Text = "";
            txtDescription.Text = "";
            UpdatedReportId = 0;
        }



        #region Form Validation Start

        private bool ValidateForm()
        {
            if (txtClientName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Client name.");
                txtClientName.Focus();
                return false;
            }
            else if (txtFileName.Text.Trim() == "")
            {
                MessageBox.Show("Please select a file.");
                return false;
            }
            else if (txtDocName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter document name.");
                txtDocName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Form Validation End



        #region Get Function Start
        private void GetReport()
        {
            List<tblreport> objtblreport = objReportDAL.GetClientUploadReportByBranchId(branchID);
            ClientUploadReportGrid.AutoGenerateColumns = false;
            ClientUploadReportGrid.DataSource = objtblreport;

        }

        private DataTable GetReportDataByReportId(int ReportId)
        {
            string cs = @"port=3306;server=10.10.10.57;user id=root;password=admin;database=doctorpractice;";
            //MySqlConnection con = null;
            DataSet ptDataset = new DataSet();
            //try
            //{
            //    //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //    using (con = new MySqlConnection(cs))
            //    {
            //        using (MySqlCommand cmd = new MySqlCommand("GetReportDataByReportId", con))
            //        {

            //            con.Open();
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("p_ReportId", ReportId);
            //            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //            da.Fill(ptDataset);
            //            PatientReportGrid.DataSource = ptDataset.Tables[0];

            //        }
            //    }
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show("Error in fetching data.");
            //}
            //finally
            //{
            //    if (con != null)
            //    {
            //        con.Close();
            //    }
            //}
            return ptDataset.Tables[0];
        }

        private string SaveFiles()
        {
            int count = 0;
            string[] FilenameName;
            string NewFileName = "";
            NewFileName = Guid.NewGuid().ToString();
            string NewPath = Application.StartupPath + @"\ClientReport\" + NewFileName;
            //string NewPath = Application.StartupPath + @"\PatientReport\" + NewFileName;
            foreach (string item in openFileDialog1.FileNames)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                NewPath = NewPath + ext;
                NewFileName = NewFileName + ext;
                FilenameName = item.Split('\\');
                File.Copy(item, NewPath);
                count++;
            }

            return NewFileName;
        }


        #endregion Get Function End




        private int DeleteReportData(int ReportId)
        {
            int ret = 0;
            bool delete = objReportDAL.DeleteClientUploadReportById(ReportId, branchID);
            if (delete)
            {

                //MessageBox.Show("Client Report Deleted SuccessFully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ret = 1;
                return ret;
            }
            else
            {
                return ret;
            }
        }

        private void ClientUploadReportGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                {
                    if (File.Exists(Application.StartupPath + @"\ClientReport\" + Convert.ToString(ClientUploadReportGrid.Rows[e.RowIndex].Cells["ReportPath"].Value)))
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = Application.StartupPath + @"\ClientReport\" + Convert.ToString(ClientUploadReportGrid.Rows[e.RowIndex].Cells["ReportPath"].Value);
                        p.Start();
                    }
                    else
                    {
                        MessageBox.Show("File does not exist in the folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else if (e.ColumnIndex == 7 && e.RowIndex >= 0)
                {
                    int reportId = default(int);
                    int.TryParse(Convert.ToString(ClientUploadReportGrid.Rows[e.RowIndex].Cells["ReportId"].Value), out reportId);

                    ReportDataEL rde = new ReportDataEL();
                    DataTable dt = new DataTable();
                    tblreport objtblreport = new tblreport();
                    objtblreport = objReportDAL.GetReportDataByReportId(reportId, branchID);

                    rde.ReportId = Convert.ToInt32(objtblreport.ReportId);
                    rde.clientId = Convert.ToInt32(objtblreport.ClientId);
                    rde.clientName = Convert.ToString(objtblreport.ClientName);
                    rde.ReportName = Convert.ToString(objtblreport.ReportName);
                    rde.ReportDescription = Convert.ToString(objtblreport.ReportDescription);
                    rde.ReportPath = Application.StartupPath + @"\ClientReport\" + Convert.ToString(objtblreport.ReportPath);


                    UpdatedReportId = rde.ReportId;
                    txtClientName.Text = rde.clientName;
                    txtFileName.Text = Application.StartupPath + @"\ClientReport\" + rde.ReportPath;
                    txtDocName.Text = rde.ReportName;
                    txtDescription.Text = rde.ReportDescription;

                    txtClientName.Enabled = false;
                    GetReport();
                }
                else if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Report", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int reportId = default(int);
                        int.TryParse(Convert.ToString(ClientUploadReportGrid.Rows[e.RowIndex].Cells["ReportId"].Value), out reportId);


                        int IsDeleted = DeleteReportData(reportId); ;
                        if (IsDeleted > 0)
                        {
                            MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetReport();
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Server error. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Sorry! Server error. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
