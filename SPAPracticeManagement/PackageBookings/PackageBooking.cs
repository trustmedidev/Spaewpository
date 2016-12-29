using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
using SPAPracticeManagement.AppConstants;
using DataAccessLayer.Repository;
using System.Globalization;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SPAPracticeManagement.Appointments; 
using System.Diagnostics;

namespace SPAPracticeManagement.PackageBookings
//namespace DoctorPracticeManagement.CustomControls.Appointment
{
    public partial class PackageBooking : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        SettingDAL ObjSettingDAL = new SettingDAL();
        tblpackagebooking objtblpackagebooking = new tblpackagebooking();
        PackageBookingDAL objPackageBookingDAL = new PackageBookingDAL();
        #region Propertise
        AppointmentDAL objAppointmentDAL = new AppointmentDAL();
        ClientDAL objClientDAL = new ClientDAL();
        SettingDAL objSettingDAL = new SettingDAL();
       

        public AppointmentDAL Appointment
        {
            get { return new AppointmentDAL(); }
        }

        public ClientDAL ClientList
        {
            get { return new ClientDAL(); }
        }

        #endregion
        public PackageBooking()
        {
            InitializeComponent();

            string dir = Application.StartupPath + @"\Invoice";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

             
            BindPackageName();
            bindPackageItemList();
            BindAppointmentGrid();
            ddl_validity.SelectedIndex = 0;
            this.toolTip1.SetToolTip(btn_CheckAvail, "Add Client");
        }

        #region Methods
         

        private void BindPackageName()
        {
            try
            {
                ddl_package.DisplayMember = "Package_Name";
                ddl_package.ValueMember = "ID"; 
                ddl_package.DataSource = objAppointmentDAL.GetAllPackage(branchID);
            }
            catch (Exception ex)
            {
            }
        } 
        private void bindPackageItemList()
        {
            ObjSettingDAL.GetAllServicesForGrid(branchID);
            tblservice Objtblservice = new tblservice();
            {
                chklst_PackageItem.DataSource = ObjSettingDAL.GetAllServicesForGrid(branchID);
                chklst_PackageItem.DisplayMember = "ServiceName";
                chklst_PackageItem.ValueMember = "ServiceId";

            }
        } 
        private void SaveAppointment()
        {
            tblservice tblsrvc = new tblservice(); 
            Utility ut = new Utility();
            tblclient tp = new tblclient(); 
            tblappointment tap = new tblappointment();
            tblappointment objAppointment = new tblappointment();
            tblpackagebooking objtblpackagebooking = new tblpackagebooking(); 
            int r = 0;

            try
            {
                string startTime = "";
                string endTime = "";
                string time = ""; 
                bool ret = false;
                if (ValidateForm())
                {
                    string s = txtClientName.Text.Trim();
                    //int clientend = s.IndexOf("(")-1;
                    string clientname = s.Substring(0, s.IndexOf("("));
                    // "Sourav Roy (ClientId: 4)"
                    int start = s.IndexOf("(") + 1;
                    int end = s.IndexOf(")", start);
                    if (end < 0)
                    {
                        MessageBox.Show("Invalid Client Name Entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return ;
                    }
                    string mobileno = s.Substring(start, end - start);

                   tblclient objtblclient = objPackageBookingDAL.GetClientIdByClientNameByPhoneNumber(clientname, mobileno, branchID);
                    
                    objtblpackagebooking.Fk_ClientId = objtblclient.ClientId;
                    //`
                    objtblpackagebooking.PkgBookingDate = txtDOB.Value;
                    objtblpackagebooking.ValidityDate = txtDOB.Value.AddMonths(Convert.ToInt32(ddl_validity.SelectedItem.ToString()));
                    objtblpackagebooking.Fk_BranchId = branchID;
                    objtblpackagebooking.IsActive = true;
                    objtblpackagebooking.Fk_PackageId = Convert.ToInt32(ddl_package.SelectedValue);
                    int i = objPackageBookingDAL.InsertUpdatePackageBooking(objtblpackagebooking);
                    if (i > 0)
                    {
                        MessageBox.Show("Package Booked succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occoured. Please enter correct data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
        }

        private bool ValidateForm()
        {
             
            if (txtClientName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Client name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(ddl_package.SelectedIndex==0)
            {
                MessageBox.Show("Please Select a Package.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(ddl_validity.SelectedIndex==0)
            {
                MessageBox.Show("Please Enter Validity in Month.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDOB.Text.Trim() == "")
            {
                MessageBox.Show("Please select an appointment date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //else if (ddlStartTime.Text.Trim() == "" || ddlEndTime.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please select an appointment time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else if (radiobtn_advance.Checked && string.IsNullOrEmpty(txt_advance.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter advanced amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else if ((radiobtn_fullpaid.Checked || radiobtn_advance.Checked) && string.IsNullOrEmpty(txt_AmountReceived.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter received amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            else
            {
                return true;
            }
        }

        private void BindAppointmentGrid()
        {
            int bypackage=1;
            grdPatientAccount.AutoGenerateColumns = false;
            //List<tblappointment> objtblappointment = new List<tblappointment>();

            var objtblappointmentbypackage = objPackageBookingDAL.GetAllPackageBooking(branchID).ToList(); 
            grdPatientAccount.DataSource = objtblappointmentbypackage;
        }

        #endregion

        #region Events 
       

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SaveAppointment();
        } 
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

        } 
        private void ClearForm()
        {
            txtClientName.Text = string.Empty;
            ddl_package.SelectedIndex = 0;
            txt_packageid.Text = string.Empty;
            //ddlStartTime.SelectedIndex = 0;
            //ddlEndTime.SelectedIndex = 0;
            if (chklst_PackageItem.Enabled==false)
            {
                chklst_PackageItem.Enabled = true;
            }
            while (chklst_PackageItem.CheckedIndices.Count > 0)
            {
                chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
            }
            ddl_validity.SelectedIndex = 0;
            //txtCouponID.Text = string.Empty;
            //txtIsValid.Text = string.Empty;
            //totalAmount.Text = string.Empty;
            //txtServiceCharge.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            txtDOB.Text = DateTime.Today.ToShortDateString();
            //txt_advance.Text = string.Empty; ;
            //txt_AmountReceived.Text = string.Empty; ;
        }
        #endregion 
        private void ddl_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (chklst_PackageItem.CheckedIndices.Count > 0)
            {
                chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
            }
            if (ddl_package.SelectedIndex != 0)
            {
                tblpackage objtblpackage=objPackageBookingDAL.GetPackageByPackageId(Convert.ToInt32(ddl_package.SelectedValue),branchID);
                string packageid = objtblpackage.Package_Id;
                txt_packageid.Text = packageid;
                List<tblservice> objtblservice = objAppointmentDAL.GetAllServiceByPackageId(Convert.ToInt32(ddl_package.SelectedValue), branchID);
                if (objtblservice != null)
                {
                    decimal? packageAmt = 0;
                    foreach (tblservice objservice in objtblservice)
                    {
                        packageAmt = packageAmt + objservice.Amount;
                        int i = 0;                         
                        foreach (var itemChecked in chklst_PackageItem.Items)
                        {

                            var row = (itemChecked as tblservice);
                            string serName = (string)row.ServiceName;
                            int serid = (int)row.ServiceId; 
                            if (objservice.ServiceId == serid)
                            {  
                                chklst_PackageItem.SetItemChecked(i, true);
                                break; 
                            }
                            else
                            {
                                i = i + 1;
                            } 
                        }     

                    }

                     
                }
                //chklst_PackageItem.CanSelect = false;
                chklst_PackageItem.Enabled = true;
            }
            else
            {
                txt_packageid.Text = string.Empty;
            }
             
             
        } 
        private void txtClientName_TextChanged_1(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = ClientList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);
            //List<PatientEL> objPatientList = ClientList.GetAllPatientByPatientName(txtPatientName.Text.Trim(),branchID); 
            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (" + item.Mobile + ")");
                //namesCollection.Add(item.ClientName + " (ClientId: " + item.ClientId + ")");
                //namesCollection.Add(item.ClientName + " (Mobile No: " + item.Mobile + ")");
                //namesCollection.Add(item.ClientName + " (ClientId: " + item.ClientId + ")"); 
            }
            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }


        #region Rough Code Start

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = ClientList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);
            //List<PatientEL> objPatientList = ClientList.GetAllPatientByPatientName(txtPatientName.Text.Trim(),branchID);

            foreach (var item in objClintList)
            {
                //namesCollection.Add(item.ClientName + " (ClientId: " + item.ClientId + ")");
                namesCollection.Add(item.ClientName + " (Mobile No: " + item.Mobile + ")");
            }
            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //PatientPopUp objPatient = new PatientPopUp();
            //objPatient.Show();
        }
        private void btn_CheckAvail_Click(object sender, EventArgs e)
        {

            SPAPracticeManagement.Appointments.ClientPopUp objClientPopUp = new ClientPopUp();
            //PatientPopUp objPatient = new PatientPopUp();
            objClientPopUp.Show();
        } 
        private void label3_Click(object sender, EventArgs e)
        {

        } 
        private void chklst_PackageItem_ItemCheck(object sender, ItemCheckEventArgs e)
        { 
            //----------------------------------------------
            //for (int j = 0; j < chklst_PackageItem.Items.Count; j++) 
            //{ if (chklst_PackageItem.GetItemCheckState(j)==CheckState.Checked) 
            //{ string str = (string)chklst_PackageItem.Items[j]; 
            //    MessageBox.Show(str); 
            //} 
            //}



            //          //----------------------------------------------

            //          decimal? totalcharge = 0;
            //          int i = 0;
            //          //var check = false;
            //          tblservice objtblservice = new tblservice();
            //          //foreach (var itemChecked in chklst_PackageItem.CheckedItems)
            //          //for (int ix = 0; ix < chklst_PackageItem.Items.Count; ++ix)
            //          //{
            //          foreach (var itemChecked in chklst_PackageItem.Items)
            //          {
            //              //var row = (itemChecked as tblservice);

            //              //if (itemChecked.GetType().(i))
            //              //{
            //                  var row = (itemChecked as tblservice);
            //                  for (int ix = 0; ix < chklst_PackageItem.Items.Count; ++ix)
            //                  {

            //                      if (chklst_PackageItem.GetItemChecked(ix))
            //                      {
            //                          int id = (int)row.ServiceId;

            //                          objtblservice.ServiceId = (int)id;
            //                          decimal? servicecharge = objAppointmentDAL.GetServiceChargeByServiceId(id, branchID);
            //                          if (servicecharge != null)
            //                          {
            //                              totalcharge = totalcharge + servicecharge;
            //                              txtServiceCharge.Text = Convert.ToString(totalcharge);
            //                          }
            //                          //    break;
            //                      }
            //                  //}

            //              }
            //              //else
            //              //{
            //              //    i = i + 1;
            //              //}
            //                  }

        } 
        private void chklst_PackageItem_Click(object sender, EventArgs e)
        {
            // decimal? totalcharge=0;
            //tblservice objtblservice = new tblservice();
            ////foreach (var itemChecked in chklst_PackageItem.CheckedItems)
            //foreach (var itemChecked in chklst_PackageItem.Items)
            //{
            //     if()
            //    var row = (itemChecked as tblservice);
            //    //string comapnyName = (string)row.ServiceName;
            //    int id = (int)row.ServiceId;

            //    objtblservice.ServiceId = (int)id;
            //    decimal? servicecharge = objAppointmentDAL.GetServiceChargeByServiceId(id, branchID);
            //     if(servicecharge!=null)
            //     {
            //         totalcharge = totalcharge + servicecharge;
            //         txtServiceCharge.Text = Convert.ToString(totalcharge);
            //     }
            //}
        } 
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BookAppointment_Load(object sender, EventArgs e)
        {

        } 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        } 
        private void button_ChkAvl_Click(object sender, EventArgs e)
        {
            //int val = 0;
            //string type = "";
            //if (radio_dr.Checked)
            //{ 
            //    val = Convert.ToInt32(ddl_doctor.SelectedValue);
            //    type = "Doctor";
            //}
            //else
            //{
            //    val = Convert.ToInt32( .SelectedValue);
            //    type = "Service";
            //}
            //AvailabilityPopUp objAvl = new AvailabilityPopUp(val, type);
            //objAvl.Show();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        #endregion Rough Code End
    }
}
