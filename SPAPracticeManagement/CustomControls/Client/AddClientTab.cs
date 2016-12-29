using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.AppConstants;
using DataAccessLayer.Repository;
using System.Globalization;
using DataAccessLayer;
using SPAPracticeManagement.Client;
using SPAPracticeManagement.Appointments;
using System.Text.RegularExpressions;
using EntityLayer;

namespace SPAPracticeManagement.CustomControls.Client
{
    public partial class AddClientTab : UserControl
    {
        public static string clientname = "";
        public static string booking = "";
        //int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        int branchID =Convert.ToInt32(AppConstants.AppsPropertise.UserDetails.BranchId);

        public int PageId = default(int);
        ClientDAL objClientDAL = new ClientDAL();
        UserDAL objUserDAl = new UserDAL();
        private int _UpdateClientId;
        public int UpdateClientId
        {
            get { return _UpdateClientId; }
            set { _UpdateClientId = value; }
        }
        public AddClientTab(int pageId = 0, int ClientId = 0)
        {
            InitializeComponent();
            PageId = pageId;
            UpdateClientId = ClientId;

            if (pageId > 0)
            {
                btnSaveAndClose.Visible = true;
            }
            else
            {
                btnSaveAndClose.Visible = false;
            }

            if (ClientId > 0)
            {
                BindClientData(ClientId);
            }
        }

        public AddClientTab(int pageId = 0,int ClientId = 0, string booking = "appointment")
        {
            InitializeComponent();
            PageId = pageId;
            UpdateClientId = ClientId;

            if (pageId > 0)
            {
                btnSaveAndClose.Visible = true;
            }
            else
            {
                btnSaveAndClose.Visible = false;
            }

            if (ClientId > 0)
            {
                BindClientData(ClientId);
            }
            booking = "appointment";
        }


        private void BindClientData(int ClientId)
        {
            tblclient Objtblclient = objClientDAL.GetClientByClientId(ClientId, branchID);
             

            txtAddress.Text = Convert.ToString(Objtblclient.Address);
            txtNote.Text = Convert.ToString(Objtblclient.CaseHistory);
            txtDOB.Value = Objtblclient.DateOfBirth.Value.Date;
            txtEmail.Text = Convert.ToString(Objtblclient.Email);
            //chkMediclaim.Checked = Convert.ToBoolean(objPainet.HasMediclaim == null ? false : objPainet.HasMediclaim);
            ddlMaritalStatus.SelectedItem = Convert.ToString(Objtblclient.MaritalStatus);
            ddlSex.SelectedItem = Convert.ToString(Objtblclient.Sex);
            txtMobile.Text = Objtblclient.Mobile == null ? "" : Objtblclient.Mobile;
            txtClientName.Text=Convert.ToString(Objtblclient.ClientName);
            
            txtRefSource.Text = Objtblclient.ReferralSource == null ? "" : Objtblclient.ReferralSource;
            chkEmailNotice.Checked = Convert.ToBoolean(Objtblclient.SendEmail == null ? false : Objtblclient.SendEmail);
            chkSMSNotice.Checked = Convert.ToBoolean(Objtblclient.SendSMS == null ? false : Objtblclient.SendSMS);
            idProofNo_txt.Text = Convert.ToString(Objtblclient.IdentityProofNo);

            if (!string.IsNullOrEmpty(Convert.ToString(Objtblclient.DateOfBirth.Value.Date)))
                //Rev Soumya
                //txtAge.Text = Convert.ToString(DateTime.Now.Year - Convert.ToDateTime(Convert.ToString(objPainet.DateOfBirth.Value.Date), CultureInfo.InvariantCulture).Year);
                txtAge.Text = Convert.ToString(DateTime.Now.Year - Objtblclient.DateOfBirth.Value.Year);
            //End Rev Soumya

        }

        private bool SaveClient()
        {
            if (ValidateForm())
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8]; var random = new Random();
                for (int k = 0; k < stringChars.Length; k++)
                {
                    stringChars[k] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);

                if (UpdateClientId > 0)
                {
                    tblclient Objtblclient = objClientDAL.GetClientByClientId(UpdateClientId, branchID);
                    Objtblclient.ClientName = txtClientName.Text.Trim();
                    Objtblclient.IdentityProofNo = idProofNo_txt.Text.Trim();
                    Objtblclient.Address = txtAddress.Text.Trim();
                    Objtblclient.CaseHistory = txtNote.Text.Trim();
                    Objtblclient.ReferralSource = txtRefSource.Text.Trim();
                    Objtblclient.DateOfBirth = Convert.ToDateTime(txtDOB.Value, CultureInfo.InvariantCulture);
                    Objtblclient.Email = txtEmail.Text.Trim();
                    //Objtblclient.HasMediclaim = chkMediclaim.Checked;
                    Objtblclient.IsActive = true;
                    if (ddlMaritalStatus.SelectedIndex != -1)
                    {
                        Objtblclient.MaritalStatus = ddlMaritalStatus.SelectedItem.ToString();
                    }
                    if (ddlSex.SelectedIndex != -1)
                    {
                        Objtblclient.Sex = ddlSex.SelectedItem.ToString();
                    }
                    //Objtblclient.MaritalStatus = ddlMaritalStatus.SelectedItem.ToString();
                    //Objtblclient.Sex = ddlSex.SelectedItem.ToString();
                    Objtblclient.Mobile = txtMobile.Text.Trim();
                    Objtblclient.SendEmail = chkEmailNotice.Checked;
                    Objtblclient.SendSMS = chkSMSNotice.Checked;
                    Objtblclient.FK_BranchID = AppsPropertise.UserDetails.BranchId;

                    tbluser tuser = objUserDAl.GetTableUserById(Objtblclient.FK_UserId, branchID);
                    tuser.Email = txtEmail.Text.Trim();
                    tuser.Name = txtClientName.Text.Trim();
                    tuser.Mobile = txtMobile.Text.Trim();
                    tuser.FK_BranchID = AppsPropertise.UserDetails.BranchId;

                    int ret = objClientDAL.InsertUpdateClientInUSerTable(tuser);

                    int i = objClientDAL.InsertUpdateClient(Objtblclient);
                    if (i > 0)
                    {


                        MessageBox.Show("Client update succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (PageId <= 0)
                        {
                            AddClient ObjAddClient = new AddClient(2, txtClientName.Text.Trim(), Objtblclient.ClientId);
                            //AddPatient objApp = new AddPatient(2, txtClientName.Text.Trim(), tblpatnt.PatientId);
                            ObjAddClient.Show();
                            this.FindForm().Hide();
                        }
                        else
                        {
                            ClientInvoiceTab ObjClientInvoiceTab = new ClientInvoiceTab(0, Objtblclient.ClientId, txtClientName.Text.Trim());
                            //PatientInvoiceTab objPatientInvoice = new PatientInvoiceTab(0, tblpatnt.PatientId, txtPatientName.Text.Trim());
                            ClientPopUp objClientPopUp = new ClientPopUp();

                            //PatientPopUp objApp = new PatientPopUp();
                            Panel pnlControl = objClientPopUp.Controls["pnlControl"] as Panel;
                            pnlControl.Controls.Clear();
                            pnlControl.Controls.Add(ObjClientInvoiceTab);
                            objClientPopUp.Show();
                            this.FindForm().Hide();
                        }
                    }
                }
                else
                {
                    int clientcnt = objClientDAL.GetClientbyClientNamebyMobileno(txtClientName.Text.Trim(), txtMobile.Text.Trim(), branchID);
                    if (clientcnt > 0)
                    {
                        MessageBox.Show("Client with this mobile number already exists!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        tbluser tu = new tbluser();
                        tu.FK_BranchID = AppsPropertise.UserDetails.BranchId;
                        tu.UserName = finalString;
                        tu.Password = finalString;
                        tu.Name = txtClientName.Text.Trim();
                        tu.Email = txtEmail.Text.Trim();

                        tu.Mobile = txtMobile.Text.Trim();




                        //tblUser tu = new tblUser();
                        //tu.Email = txtEmail.Text.Trim();
                        //tu.Name = txtClientName.Text.Trim();
                        //tu.UserName = finalString;
                        //tu.Password = finalString;
                        tu.FK_RoleId = 6;
                        tu.IsActive = true;
                        //tu.FK_BranchID = AppsPropertise.UserDetails.BranchId;
                        int ret = objClientDAL.InsertUpdateClientInUSerTable(tu);
                        string db = "";
                        if(txtDOB.Text!="")
                        {
                            db = txtDOB.Text;
                        }

                        tblclient objClient = new tblclient();
                        objClient.AddedDate=DateTime.Now;
                        objClient.Address=txtAddress.Text.Trim();
                            objClient.CaseHistory= txtNote.Text.Trim();
                        if(txtDOB.Text!="")
                        {
                            objClient.DateOfBirth=Convert.ToDateTime(txtDOB.Value);
                        }
                            
                            objClient.Email=txtEmail.Text.Trim();
                            objClient.IsActive=true;
                        if(ddlMaritalStatus.SelectedIndex!=-1)
                        {
                            objClient.MaritalStatus=ddlMaritalStatus.SelectedItem.ToString();
                        }
                          if(ddlSex.SelectedIndex!=-1)  
                          {
                            objClient.Sex=ddlSex.SelectedItem.ToString();
                          }
                            
                            objClient.Mobile=txtMobile.Text.Trim();
                            objClient.ClientName=txtClientName.Text.Trim();
                            objClient.ReferralSource=txtRefSource.Text.Trim();
                            objClient.SendEmail=chkEmailNotice.Checked;
                            objClient.SendSMS=chkSMSNotice.Checked;
                            objClient.FK_BranchID=AppsPropertise.UserDetails.BranchId;
                            objClient.FK_UserId=ret;
                            objClient.IdentityProofNo = idProofNo_txt.Text.Trim();

                        //tblClient objClient = new tblClient()
                        //{
                            //AddedDate = DateTime.Now,
                            //Address = txtAddress.Text.Trim(),
                            //CaseHistory = txtNote.Text.Trim(),
                            //DateOfBirth = Convert.ToDateTime(txtDOB.Text, CultureInfo.InvariantCulture),

                            //DateOfBirth = Convert.ToDateTime(txtDOB.Text, CultureInfo.InvariantCulture),
                            //Email = txtEmail.Text.Trim(),
                            //IsActive = true,
                            //MaritalStatus = ddlMaritalStatus.SelectedItem.ToString(),
                            //Sex = ddlSex.SelectedItem.ToString(),
                            //Mobile = txtMobile.Text.Trim(),
                            //ClientName = txtClientName.Text.Trim(),
                            //ReferralSource = txtRefSource.Text.Trim(),
                            //SendEmail = chkEmailNotice.Checked,
                            //SendSMS = chkSMSNotice.Checked,
                            //AddedDate=Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd 00:00:00"),
                            //FK_BranchID = AppsPropertise.UserDetails.BranchId,
                        //    FK_UserId = ret,
                        //    IdentityProofNo = idProofNo_txt.Text.Trim()
                        //};

                        int i = objClientDAL.InsertUpdateClient(objClient);

                        if (i > 0)
                        {


                            MessageBox.Show("Client added succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (PageId <= 0)
                            {
                                AddClient objApp = new AddClient(2, txtClientName.Text.Trim(), objClient.ClientId);
                                objApp.Show();
                                this.FindForm().Hide();
                            }
                            else
                            {
                                ClientInvoiceTab objClientInvoice = new ClientInvoiceTab(0, objClient.ClientId, txtClientName.Text.Trim());
                                ClientPopUp objApp = new ClientPopUp();
                                Panel pnlControl = objApp.Controls["pnlControl"] as Panel;
                                pnlControl.Controls.Clear();
                                pnlControl.Controls.Add(objClientInvoice);
                                objApp.Show();
                                this.FindForm().Hide();
                                
                                //if (booking == "appointment")
                                //{
                                    tblclient objclient = new tblclient();
                                    //ClientEL objclient=new ClientEL();
                                    objclient = objClientDAL.GetClientByClientId(i, branchID);
                                    //BookAppointment fm = null;
                                //if(fm.Visible)
                                //{
                                //    fm.Close();
                                //}
                                    //clientname = objclient.ClientName + " (Mobile: " + objclient.Mobile + ")";
                                    Booking fc = Application.OpenForms["Booking"] != null ? (Booking)Application.OpenForms["Booking"] : null;
                                    if (fc != null)
                                    {
                                        //fc.Controls.Find()
                                        fc.Close();
                                        Booking objBooking = new Booking(objclient.ClientId, objclient.ClientName, objclient.Mobile);
                                        objBooking.Show();
                                    } 
                                //}
                            }

                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateForm()
        {
            if (txtClientName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter client name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //else if (idProofNo_txt.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Identity Proof No.");
            //    return false;
            //}
            //else if (ddlMaritalStatus.Text == "")
            //{
            //    MessageBox.Show("Please select marital status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else if (ddlSex.Text == "")
            //{
            //    MessageBox.Show("Please select gender.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else if (txtAge.Text == "0")
            //{
            //    MessageBox.Show("Please enter age.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
           //.......................Code Added by Sandip on 17032016..........................
            //else if (txtEmail.Text.Trim() != "" && ValidateEmailId(txtEmail.Text.Trim()) == 0)
            //{
            //    MessageBox.Show("Please enter valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            else if (txtMobile.Text.Trim() == "")
            {
                MessageBox.Show("Please enter mobile", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtMobile.Text.Trim() != "" && !phone(txtMobile.Text.Trim()))
            {
                MessageBox.Show("Please enter valid mobile no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           //.......................Code Added by Sandip on 17032016..........................
            else if (txtEmail.Text.Trim() != string.Empty && !Regex.IsMatch(txtEmail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
            {
                MessageBox.Show("Please enter valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //else if (chkEmailNotice.Checked == true && txtEmail.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter email id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            else if (chkSMSNotice.Checked == true && txtMobile.Text.Trim() == "")
            {
                MessageBox.Show("Please enter mobile", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else
            {
                return true;
            }
        }



        public int ValidateEmailId(string emailId)
        {
            /*Regular Expressions for email id*/
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (emailId.Length > 0)
            {
                if (!rEMail.IsMatch(emailId))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 2;
        }

        public bool phone(string no)
        {
            if (no.Length == 10)
            {
                return true;
            }
            else return false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtClientName.Text = string.Empty;
                idProofNo_txt.Text = string.Empty;
                txtDOB.Value = System.DateTime.Now;
                txtAge.Text = "0";
                ddlMaritalStatus.SelectedIndex = 0;
                ddlSex.SelectedIndex = 0;
                txtRefSource.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtNote.Text = string.Empty;
                txtMobile.Text = string.Empty;
                chkEmailNotice.Checked = false;
                chkSMSNotice.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                SaveClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtDOB.Text.Trim()))
                //Rev Soumya
                //txtAge.Text = Convert.ToString(DateTime.Now.Year - Convert.ToDateTime(txtDOB.Text, CultureInfo.InvariantCulture).Year);
                txtAge.Text = Convert.ToString(DateTime.Now.Year - txtDOB.Value.Year);
            //End Rev Soumya
            //txtAge.Text = Convert.ToString(DateTime.Now.Year - Convert.ToDateTime(txtDOB.Text, CultureInfo.InvariantCulture).Year);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveClient();
            //this.FindForm().Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
