using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Settings
{
    public partial class CompanyDetails : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        public CompanyDetails()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            BindTime();
            ShowTextValues();
           
        }
        public int _UpdCompId;
        public int UpdCompId
        {
            get { return _UpdCompId; }
            set { _UpdCompId = value; }
        }

        public AppointmentDAL Appointment
        {
            get { return new AppointmentDAL(); }
        }
        DashboardDAL dashboard_dal = new DashboardDAL();
        string filename = "";


        public void BindTime()
        {
            List<string> StartTimeSchedule = Appointment.GetCompanyOpeningTime();
            List<string> EndTimeSchedule = Appointment.GetCompanyClosingTime();
            ddl_Openingtime.DataSource = StartTimeSchedule;
            ddl_ClosingTime.DataSource = EndTimeSchedule;
            //ddlStartTime.DataSource = StartTimeSchedule;
            //ddlEndTime.DataSource = EndTimeSchedule;
        }
        public bool ValidateForm()
        {
            if (!Regex.IsMatch(txtEmail.Text, (@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")))
            {
                MessageBox.Show("Please enter valid Email");
                return false;
            }

            else if (!Regex.IsMatch(txtMobile.Text, @"(\d*-)?\d{10}"))
            {
                MessageBox.Show("Please enter  valid mobile number");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearForm()
        {
            txtAddress.Text = "";
            txtCompName.Text = "";
            txtContName.Text = "";
            txtEmail.Text = "";
            txtFrom.Text = "";
            txtMobile.Text = "";
            txtOwnerName.Text = "";
            txtPhone.Text = "";
            txtTo.Text = "";
            txtWebsite.Text = "";
            txtFileName.Text = "";
            pictureBox5.Image = null;
        }
        public void ShowTextValues()
        {
            var Val = dashboard_dal.CompanyDetails();
            if (Val != null)
            {
                txtAddress.Text = Val.Address.Trim();
                txtCompName.Text = Val.CompanyName.Trim();
                txtContName.Text = Val.ContactName.Trim();
                txtEmail.Text = Val.Email.Trim();
                txtFrom.Text = Val.FY_From.Value.ToString().Trim();
                txtTo.Text = Val.FY_To.ToString().Trim();
                txtWebsite.Text = Val.Website.Trim();
                txtPhone.Text = Val.Phone.Trim();
                txtOwnerName.Text = Val.OwnerName.Trim();
                txtMobile.Text = Val.Mobile.Trim();
                UpdCompId = Val.Comp_Id;
                ddl_Openingtime.SelectedItem = Val.Opening_Time;
                ddl_ClosingTime.SelectedItem = Val.Closing_Time;
                //ddl_Openingtime.SelectedItem = Val.Opening_Time;
                //ddl_ClosingTime.SelectedItem = Val.Closing_Time;
                switch (Val.Interval)
                {
                    case 1:
                        ddl_Interval.SelectedItem = "30 Mins";
                        break;
                    case 2:
                        ddl_Interval.SelectedItem = "1 hour";
                        break;
                    case 3:
                        ddl_Interval.SelectedItem = "2 hour";
                        break;
                    default:
                        ddl_Interval.SelectedItem = "3 hour";
                        break;
                }
                //int interval = 1;
                //if (ddl_Interval.SelectedItem == "30 Mins")
                //{
                //    interval = 2;

                //}
                //else if (ddl_Interval.SelectedItem == "1 hour")
                //{
                //    interval = 3;
                //}
                //else if (ddl_Interval.SelectedItem == "2 hour")
                //{
                //    interval = 3;
                //}
                if (!string.IsNullOrEmpty(Val.LogoPath))
                {
                    //tas.LogoPath = Application.StartupPath + @"\Logo\" + tas.LogoPath;
                }
                else
                {
                    //tas.LogoPath = "";
                }
                filename = Val.LogoPath;
                txtFileName.Text = string.Empty;
                //txtFileName.Text = tas.LogoPath;
                if (File.Exists(Application.StartupPath + @"\Logo\" + Val.LogoPath))
                {
                    pictureBox5.Image = Image.FromFile(Application.StartupPath + @"\Logo\" + Val.LogoPath);
                }
                // pictureBox3.ImageLocation = tas.LogoPath == null ? "" : tas.LogoPath;
                this.Refresh();
            }
        }
        private string SaveFiles()
        {
            int count = 0;
            string[] FilenameName;
            string NewFileName = "";
            try
            {
                NewFileName = Guid.NewGuid().ToString();
                string NewPath = Application.StartupPath + @"\Logo\" + NewFileName;
                foreach (string item in openFileDialog1.FileNames)
                {
                    if (item == "openFileDialog1")
                    {
                        return NewFileName = null;
                    }
                    else
                    {
                        string ext = Path.GetExtension(openFileDialog1.FileName);
                        NewPath = NewPath + ext;
                        NewFileName = NewFileName + ext;
                        FilenameName = item.Split('\\');
                        File.Copy(item, NewPath);
                        count++;
                    }
                }
                Image image = Image.FromFile(NewPath);
                pictureBox5.Image = image;
            }
            catch (Exception) { }
            return NewFileName;
        }
        public bool Save()
        {
            int IsAvailable = 0;
            try
            {
                string FilePath = SaveFiles();
                if (ValidateForm())
                {
                    tblcompdetail objtblcompdetail = new tblcompdetail();
                    objtblcompdetail.CompanyName = txtCompName.Text.Trim();
                    objtblcompdetail.ContactName = txtContName.Text.Trim();
                    objtblcompdetail.OwnerName = txtOwnerName.Text.Trim();
                    objtblcompdetail.Address = txtAddress.Text.Trim();
                    objtblcompdetail.Email = txtEmail.Text.Trim();
                    objtblcompdetail.Mobile = txtMobile.Text.Trim();
                    objtblcompdetail.Phone = txtPhone.Text.Trim();
                    objtblcompdetail.Website = txtWebsite.Text.Trim();
                    objtblcompdetail.FY_From = Convert.ToInt32(txtFrom.Text.Trim());
                    objtblcompdetail.FY_To = Convert.ToInt32(txtTo.Text.Trim());
                    objtblcompdetail.Comp_Id = UpdCompId;
                    objtblcompdetail.LogoPath = (FilePath == null ? filename : FilePath);


                    int interval = 1;
                    if (ddl_Interval.SelectedItem == "30 Mins")
                    {
                        interval = 1;

                    }
                    else if (ddl_Interval.SelectedItem == "1 hour")
                    {
                        interval = 2;

                    }
                    else if (ddl_Interval.SelectedItem == "2 hour")
                    {
                        interval = 3;
                    }
                    objtblcompdetail.Opening_Time = Convert.ToString(ddl_Openingtime.SelectedItem);
                    objtblcompdetail.Closing_Time = Convert.ToString(ddl_ClosingTime.SelectedItem);
                    objtblcompdetail.Interval = interval;
                     objtblcompdetail.IsActive=true;
                     objtblcompdetail.FK_BranchId = branchID;
                    if (UpdCompId > 0)
                    {
                        //string FilePath = SaveFiles();
                        //tblcompdetail objtblcompdetail = new tblcompdetail()
                        //{
                            
                        //    CompanyName = txtCompName.Text.Trim(),
                        //    ContactName = txtContName.Text.Trim(),
                        //    OwnerName = txtOwnerName.Text.Trim(),
                        //    Address = txtAddress.Text.Trim(),
                        //    Email = txtEmail.Text.Trim(),
                        //    Mobile = txtMobile.Text.Trim(),
                        //    Phone = txtPhone.Text.Trim(),
                        //    Website = txtWebsite.Text.Trim(),
                        //    FY_From = Convert.ToInt32(txtFrom.Text.Trim()),
                        //    FY_To = Convert.ToInt32(txtTo.Text.Trim()),
                        //    Comp_Id=UpdCompId,
                        //    LogoPath = (FilePath == null ? filename : FilePath),
                        //};

                        //    tblcompdetail objtblcompdetail = new tblcompdetail(); 
                        //    objtblcompdetail.CompanyName = txtCompName.Text.Trim();
                        //    objtblcompdetail.ContactName = txtContName.Text.Trim();
                        //    objtblcompdetail.OwnerName = txtOwnerName.Text.Trim();
                        //    objtblcompdetail.Address = txtAddress.Text.Trim();
                        //    objtblcompdetail.Email = txtEmail.Text.Trim();
                        //    objtblcompdetail.Mobile = txtMobile.Text.Trim();
                        //    objtblcompdetail.Phone = txtPhone.Text.Trim();
                        //    objtblcompdetail.Website = txtWebsite.Text.Trim();
                        //    objtblcompdetail.FY_From = Convert.ToInt32(txtFrom.Text.Trim());
                        //    objtblcompdetail.FY_To = Convert.ToInt32(txtTo.Text.Trim());
                        //    objtblcompdetail.Comp_Id = UpdCompId;
                        //    objtblcompdetail.LogoPath = (FilePath == null ? filename : FilePath);
                       

                        //int interval = 1;
                        //if (ddl_Interval.SelectedItem == "30 Mins")
                        //{
                        //    interval = 1;

                        //}
                        //else if (ddl_Interval.SelectedItem == "1 hour")
                        //{
                        //    interval = 2;

                        //}
                        //else if (ddl_Interval.SelectedItem == "2 hour")
                        //{
                        //    interval = 3;
                        //}
                        //objtblcompdetail.Opening_Time = Convert.ToString(ddl_Openingtime.SelectedItem);
                        //objtblcompdetail.Closing_Time = Convert.ToString(ddl_ClosingTime.SelectedItem);
                        //objtblcompdetail.Interval = interval;
                        IsAvailable = dashboard_dal.InsertUpdateCompDetails(objtblcompdetail);
                        if (IsAvailable > 0)
                        {
                            MessageBox.Show("Updation Successfull");
                            //ClearForm();
                        }
                    }
                    else
                    {
                        //string FilePath = SaveFiles();
                        //tblcompdetail objtblcompdetail = new tblcompdetail()
                        //{
                        //    CompanyName = txtCompName.Text.Trim(),
                        //    ContactName = txtContName.Text.Trim(),
                        //    OwnerName = txtOwnerName.Text.Trim(),
                        //    Address = txtAddress.Text.Trim(),
                        //    Email = txtEmail.Text.Trim(),
                        //    Mobile = txtMobile.Text.Trim(),
                        //    Phone = txtPhone.Text.Trim(),
                        //    Website = txtWebsite.Text.Trim(),
                        //    FY_From = Convert.ToInt32(txtFrom.Text.Trim()),
                        //    FY_To = Convert.ToInt32(txtTo.Text.Trim()),
                        //    LogoPath=(FilePath == null ? filename : FilePath),
                        //    IsActive=true,
                        //    FK_BranchId=branchID,
                        //};
                        IsAvailable = dashboard_dal.InsertUpdateCompDetails(objtblcompdetail);
                        if (IsAvailable > 0)
                        {
                            MessageBox.Show("Insertion Successfull");
                            //ClearForm();
                        }
                    }
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { return false; }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CompanyDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
                                        + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
