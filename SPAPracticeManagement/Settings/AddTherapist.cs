using DataAccessLayer;
using DataAccessLayer.Repository;
using SPAPracticeManagement.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Settings
{
    public partial class AddTherapist : Dashboard
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        public AddTherapist()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //BindTime();
            BindGrid();

            BindTimings();
        }
        public int? _UpdateThId;
        public int? UpdateThId
        {
            get { return _UpdateThId; }
            set { _UpdateThId = value; }
        }
        public void ClearForm()
        {
            txt_thpadd.Text = "";
            txt_thpamt.Text = "";
            txt_thpemail.Text = "";
            txt_thpmob.Text = "";
            txt_thpname.Text = "";
            txt_thpspc.Text = "";
            //ddlStartTime.SelectedItem = "00:00 AM";
            //ddlEndTime.SelectedItem = "00:00 AM";
            //if (chkLeave.Checked)
            //{
            //    chkLeave.Checked = false;
            //}
            int count = chkDays.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chkDays.CheckedItems.Count > 0)
                {
                    chkDays.SetItemChecked(i, false);
                }
            }

            cmb_MST.SelectedIndex = 0; cmb_MET.SelectedIndex = 0; cmb_MST.Enabled = false; cmb_MET.Enabled = false;
            cmb_TST.SelectedIndex = 0; cmb_TET.SelectedIndex = 0; cmb_TST.Enabled = false; cmb_TET.Enabled = false;
            cmb_WST.SelectedIndex = 0; cmb_WET.SelectedIndex = 0; cmb_WST.Enabled = false; cmb_WET.Enabled = false;
            cmb_THST.SelectedIndex = 0; cmb_THET.SelectedIndex = 0; cmb_THST.Enabled = false; cmb_THET.Enabled = false;
            cmb_FST.SelectedIndex = 0; cmb_FET.SelectedIndex = 0; cmb_FST.Enabled = false; cmb_FET.Enabled = false;
            cmb_SST.SelectedIndex = 0; cmb_SET.SelectedIndex = 0; cmb_SST.Enabled = false; cmb_SET.Enabled = false;
            cmb_SUST.SelectedIndex = 0; cmb_SUET.SelectedIndex = 0; cmb_SUST.Enabled = false; cmb_SUET.Enabled = false;

            chk_MFD.Checked = false; chk_MHD.Checked = false; chk_MFD.Enabled = false; chk_MHD.Enabled = false;
            chk_TFD.Checked = false; chk_THD.Checked = false; chk_TFD.Enabled = false; chk_THD.Enabled = false;
            chk_WFD.Checked = false; chk_WHD.Checked = false; chk_WFD.Enabled = false; chk_WHD.Enabled = false;
            chk_THFD.Checked = false; chk_THHD.Checked = false; chk_THFD.Enabled = false; chk_THHD.Enabled = false;
            chk_FFD.Checked = false; chk_FHD.Checked = false; chk_FFD.Enabled = false; chk_FHD.Enabled = false;
            chk_SFD.Checked = false; chk_SHD.Checked = false; chk_SFD.Enabled = false; chk_SHD.Enabled = false;
            chk_SUFD.Checked = false; chk_SUHD.Checked = false; chk_SUFD.Enabled = false; chk_SUHD.Enabled = false;
        }
        public bool ValidateForm()
        {
            if (txt_thpname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter therapist Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_thpmob.Text.Trim() == "")
            {
                MessageBox.Show("Please enter mobile.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_thpemail.Text.Trim() != string.Empty && !Regex.IsMatch(txt_thpemail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
            {
                //if (!Regex.IsMatch(txt_thpemail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
                //{
                MessageBox.Show("Please enter valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
                //}
                //else
                //{
                //    return true;
                //}
            }
            else if (!Regex.IsMatch(txt_thpmob.Text, @"(\d*-)?\d{10}"))
            {
                MessageBox.Show("Please enter  valid mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txt_thpamt.Text.Trim() == "")
            {
                MessageBox.Show("Please enter commission.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (chkDays.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select days", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
                // cmb_MST.Text.Trim() == "00:00 AM" || cmb_MET.Text.Trim() == "00:00 AM" || cmb_TST.Text.Trim() == "00:00 AM" || cmb_TET.Text.Trim() == "00:00 AM" ||
                //cmb_WST.Text.Trim() == "00:00 AM" || cmb_WET.Text.Trim() == "00:00 AM" || cmb_THST.Text.Trim() == "00:00 AM" || cmb_THET.Text.Trim() == "00:00 AM" ||
               // cmb_FST.Text.Trim() == "00:00 AM" || cmb_FET.Text.Trim() == "00:00 AM" || cmb_SST.Text.Trim() == "00:00 AM" || cmb_SET.Text.Trim() == "00:00 AM" ||
              //  cmb_SUST.Text.Trim() == "00:00 AM" || cmb_SUET.Text.Trim() == "00:00 AM"
            else if (chkDays.CheckedItems.Count > 0)
            {                
                //string[] dys = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                //int count = chkDays.Items.Count;
                //for (int i = 0; i < count-1; i++)
                //{
                //    foreach (string item in dys)
                //    {
                //        if (chkDays.CheckedItems[i].ToString().Contains(item))
                //        {
                //            if (item == "Monday")
                //            {
                //                if (cmb_MST.SelectedIndex == 0 || cmb_MET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Monday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Tuesday")
                //            {
                //                if (cmb_TST.SelectedIndex == 0 || cmb_TET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Tuesday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Wednesday")
                //            {
                //                if (cmb_WST.SelectedIndex == 0 || cmb_WET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Wednesday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Thursday")
                //            {
                //                if (cmb_THST.SelectedIndex == 0 || cmb_THET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Thursday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Friday")
                //            {
                //                if (cmb_FST.SelectedIndex == 0 || cmb_FET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Friday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Saturday")
                //            {
                //                if (cmb_SST.SelectedIndex == 0 || cmb_SET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Saturday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //            else if (item == "Sunday")
                //            {
                //                if (cmb_SUST.SelectedIndex == 0 || cmb_SUET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Sunday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                //            }
                //        }
                //    }
                //}
                //}                
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool TimingValidation()
        {
            try
            {
                foreach (var itemChecked in chkDays.CheckedItems)
                {
                    if (chkDays.GetItemText(itemChecked) == "Monday")
                    {
                        if (cmb_MST.SelectedIndex == 0 || cmb_MET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Monday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Tuesday")
                    {
                        if (cmb_TST.SelectedIndex == 0 || cmb_TET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Tuesday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Wednesday")
                    {
                        if (cmb_WST.SelectedIndex == 0 || cmb_WET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Wednesday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Thursday")
                    {
                        if (cmb_THST.SelectedIndex == 0 || cmb_THET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Thursday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Friday")
                    {
                        if (cmb_FST.SelectedIndex == 0 || cmb_FET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Friday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Saturday")
                    {
                        if (cmb_SST.SelectedIndex == 0 || cmb_SET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Saturday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else if (chkDays.GetItemText(itemChecked) == "Sunday")
                    {
                        if (cmb_SUST.SelectedIndex == 0 || cmb_SUET.SelectedIndex == 0) { MessageBox.Show("Please select timings of Sunday.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
                    }
                    else { return true; }
                }
                return true;
            }
            catch (Exception ex) { return false; }
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
        
        private void ShowTextValues(int? ThpId)
        {
            //cmb_MST.SelectedIndex = 0; cmb_MET.SelectedIndex = 0; 
            //cmb_TST.SelectedIndex = 0; cmb_TET.SelectedIndex = 0; 
            //cmb_WST.SelectedIndex = 0; cmb_WET.SelectedIndex = 0; 
            //cmb_THST.SelectedIndex = 0; cmb_THET.SelectedIndex = 0; 
            //cmb_FST.SelectedIndex = 0; cmb_FET.SelectedIndex = 0; 
            //cmb_SST.SelectedIndex = 0; cmb_SET.SelectedIndex = 0;
            //cmb_SUST.SelectedIndex = 0; cmb_SUET.SelectedIndex = 0;

            cmb_MST.Enabled = false; cmb_MET.Enabled = false;
            cmb_TST.Enabled = false; cmb_TET.Enabled = false;
            cmb_WST.Enabled = false; cmb_WET.Enabled = false;
            cmb_THST.Enabled = false; cmb_THET.Enabled = false;
            cmb_FST.Enabled = false; cmb_FET.Enabled = false;
            cmb_SST.Enabled = false; cmb_SET.Enabled = false;
            cmb_SUST.Enabled = false; cmb_SUET.Enabled = false;

            chk_MFD.Checked = false; chk_MHD.Checked = false; chk_MFD.Enabled = false; chk_MHD.Enabled = false;
            chk_TFD.Checked = false; chk_THD.Checked = false; chk_TFD.Enabled = false; chk_THD.Enabled = false;
            chk_WFD.Checked = false; chk_WHD.Checked = false; chk_WFD.Enabled = false; chk_WHD.Enabled = false;
            chk_THFD.Checked = false; chk_THHD.Checked = false; chk_THFD.Enabled = false; chk_THHD.Enabled = false;
            chk_FFD.Checked = false; chk_FHD.Checked = false; chk_FFD.Enabled = false; chk_FHD.Enabled = false;
            chk_SFD.Checked = false; chk_SHD.Checked = false; chk_SFD.Enabled = false; chk_SHD.Enabled = false;
            chk_SUFD.Checked = false; chk_SUHD.Checked = false; chk_SUFD.Enabled = false; chk_SUHD.Enabled = false;

            var Value = settingdal.TherapistById(ThpId, branchID);
            if (Value != null)
            {
                txt_thpname.Text = Value.Name.Trim();
                txt_thpadd.Text = Value.Address.Trim();
                txt_thpspc.Text = Value.Specialist.Trim();
                txt_thpmob.Text = Value.Mobile.Trim();
                txt_thpemail.Text = Value.Email.Trim();
                txt_thpamt.Text = Value.Commission.Value.ToString().Trim();
                List<string> time = new List<string>();
                if (Value.Availability != null)
                {
                    var query = Value.Availability.Trim();
                    string[] split = query.Split('-');
                    //ddlStartTime.SelectedItem = split[0].ToString();
                    //ddlEndTime.SelectedItem = split[1];
                }
                UpdateThId = ThpId;
                //chkLeave.Checked = Value.Leave == true ? true : false;
                int count = chkDays.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (chkDays.CheckedItems.Count > 0)
                    {
                        chkDays.SetItemChecked(i, false);
                    }
                }
                string bindays = Value.Days.Trim() == "" ? Convert.ToString(null) : Value.Days.Trim();

                if (bindays != null)
                {
                    string[] splitt = bindays.Split(',');
                    if (chkDays.Items.Count > 0)
                    {
                        foreach (var item in splitt)
                        {
                            for (int n = 0; n < chkDays.Items.Count; n++)
                            {
                                if (chkDays.Items[n].ToString().Contains(item))
                                {
                                    chkDays.SetItemChecked(n, true);
                                }
                            }
                        }
                    }
                }
                if (Value.Timings != null)
                {
                    var s = Value.Timings.Trim();
                    string[] split = s.Split(',');
                    foreach (string sp in split)
                    {
                        if (sp.Substring(0,2).ToUpper() == "MO") 
                        {                            
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_MST.Enabled = true; cmb_MET.Enabled = true;
                            chk_MFD.Enabled = true; chk_MHD.Enabled = true;
                            cmb_MST.SelectedItem = spl[0];
                            cmb_MET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "TU")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_TST.Enabled = true; cmb_TET.Enabled = true;
                            chk_TFD.Enabled = true; chk_THD.Enabled = true;
                            cmb_TST.SelectedItem = spl[0];
                            cmb_TET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "WE")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_WST.Enabled = true; cmb_WET.Enabled = true;
                            chk_WFD.Enabled = true; chk_WHD.Enabled = true;
                            cmb_WST.SelectedItem = spl[0];
                            cmb_WET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "TH")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_THST.Enabled = true; cmb_THET.Enabled = true;
                            chk_THFD.Enabled = true; chk_THHD.Enabled = true;
                            cmb_THST.SelectedItem = spl[0];
                            cmb_THET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "FR")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_FST.Enabled = true; cmb_FET.Enabled = true;
                            chk_FFD.Enabled = true; chk_FHD.Enabled = true;
                            cmb_FST.SelectedItem = spl[0];
                            cmb_FET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "SA")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_SST.Enabled = true; cmb_SET.Enabled = true;
                            chk_SFD.Enabled = true; chk_SHD.Enabled = true;
                            cmb_SST.SelectedItem = spl[0];
                            cmb_SET.SelectedItem = spl[1];
                            spl = null;
                        }
                        if (sp.Substring(0, 2).ToUpper() == "SU")
                        {
                            string[] spl = sp.Substring(5).Split('-');
                            cmb_SUST.Enabled = true; cmb_SUET.Enabled = true;
                            chk_SUFD.Enabled = true; chk_SUHD.Enabled = true;
                            cmb_SUST.SelectedItem = spl[0];
                            cmb_SUET.SelectedItem = spl[1];
                            spl = null;
                        }
                    }
                }
                if (Value.TherapistLeave != null)
                {
                    var ss = Value.TherapistLeave.Trim();
                    string[] splits = ss.Split(',');
                    foreach (string sp in splits)
                    {
                        if (sp.Substring(0, 2).ToUpper() == "MO")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_MFD.Checked = true; }
                            else { chk_MHD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "TU")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_TFD.Checked = true; }
                            else { chk_THD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "WE")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_WFD.Checked = true; }
                            else { chk_WHD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "TH")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_THFD.Checked = true; }
                            else { chk_THHD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "FR")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_FFD.Checked = true; }
                            else { chk_FHD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "SA")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_SFD.Checked = true; }
                            else { chk_SHD.Checked = true; }
                        }
                        if (sp.Substring(0, 2).ToUpper() == "SU")
                        {
                            if (sp.Substring(5) == "Full Day") { chk_SUFD.Checked = true; }
                            else { chk_SUHD.Checked = true; }
                        }
                    }
                }
            }
        }
        public void BindGrid()
        {
            var thpList = settingdal.TherapistList(branchID).ToList();
            if (thpList.Count > 0)
            {
                grdtherapist.AutoGenerateColumns = false;
                grdtherapist.DataSource = thpList;
            }
            else
            {
                grdtherapist.AutoGenerateColumns = false;
                grdtherapist.DataSource = null;
            }
        }
        SettingDAL settingdal = new SettingDAL();
        AppointmentDAL Appointment = new AppointmentDAL();
        public void BindTime()
        {
            List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            List<string> EndTimeSchedule = Appointment.GetAppointmentScheduleTime();

            //ddlStartTime.DataSource = StartTimeSchedule;
            //ddlEndTime.DataSource = EndTimeSchedule;
        }
        public void BindTimings()
        {
            cmb_MST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_MET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_TST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_TET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_WST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_WET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_THST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_THET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_FST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_FET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_SST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_SET.DataSource = Appointment.GetAppointmentScheduleTime();
            cmb_SUST.DataSource = Appointment.GetAppointmentScheduleTime(); cmb_SUET.DataSource = Appointment.GetAppointmentScheduleTime();
        }
        public bool SaveTherapist()
        {
            int IsAvailable = 0;
            try
            {
                if (ValidateForm())
                {
                    string days = "";
                    string timings = "";
                    string leaves = "";
                    List<string> time = new List<string>();
                    List<string> leave = new List<string>();

                    if (TimingValidation())
                    {
                        time.Clear(); leave.Clear();
                        foreach (var itemChecked in chkDays.CheckedItems)
                        {
                            //days += chkDays.GetItemText(itemChecked) + ",";

                            if (chkDays.GetItemText(itemChecked) == "Monday")
                            {
                                //timings = "MO ->" + cmb_MST.SelectedItem + "-" + cmb_MET.SelectedItem; time.Add(timings);
                                if (chk_MFD.Checked) { leaves = "MO ->" + chk_MFD.Text; leave.Add(leaves); }
                                else if (chk_MHD.Checked) { leaves = "MO ->" + chk_MHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Mo ->" + cmb_MST.SelectedItem + "-" + cmb_MET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Tuesday")
                            {
                                //timings = "TU ->" + cmb_TST.SelectedItem + "-" + cmb_TET.SelectedItem; time.Add(timings);
                                if (chk_TFD.Checked) { leaves = "TU ->" + chk_TFD.Text; leave.Add(leaves); }
                                else if (chk_THD.Checked) { leaves = "TU ->" + chk_THD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Tu ->" + cmb_TST.SelectedItem + "-" + cmb_TET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Wednesday")
                            {
                                //timings = "WE ->" + cmb_WST.SelectedItem + "-" + cmb_WET.SelectedItem; time.Add(timings);
                                if (chk_WFD.Checked) { leaves = "WE ->" + chk_WFD.Text; leave.Add(leaves); }
                                else if (chk_WHD.Checked) { leaves = "WE ->" + chk_WHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "We ->" + cmb_WST.SelectedItem + "-" + cmb_WET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Thursday")
                            {
                                //timings = "TH ->" + cmb_THST.SelectedItem + "-" + cmb_THET.SelectedItem; time.Add(timings);
                                if (chk_THFD.Checked) { leaves = "TH ->" + chk_THFD.Text; leave.Add(leaves); }
                                else if (chk_THHD.Checked) { leaves = "TH ->" + chk_THHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Th ->" + cmb_THST.SelectedItem + "-" + cmb_THET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Friday")
                            {
                                //timings = "FR ->" + cmb_FST.SelectedItem + "-" + cmb_FET.SelectedItem; time.Add(timings);
                                if (chk_FFD.Checked) { leaves = "FR ->" + chk_FFD.Text; leave.Add(leaves); }
                                else if (chk_FHD.Checked) { leaves = "FR ->" + chk_FHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Fr ->" + cmb_FST.SelectedItem + "-" + cmb_FET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Saturday")
                            {
                                //timings = "SA ->" + cmb_SST.SelectedItem + "-" + cmb_SET.SelectedItem; time.Add(timings);
                                if (chk_SFD.Checked) { leaves = "SA ->" + chk_SFD.Text; leave.Add(leaves); }
                                else if (chk_SHD.Checked) { leaves = "SA ->" + chk_SHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Sa ->" + cmb_SST.SelectedItem + "-" + cmb_SET.SelectedItem; time.Add(timings);
                                }
                            }
                            else if (chkDays.GetItemText(itemChecked) == "Sunday")
                            {
                                //timings = "SU ->" + cmb_SUST.SelectedItem + "-" + cmb_SUET.SelectedItem; time.Add(timings);
                                if (chk_SUFD.Checked) { leaves = "SU ->" + chk_SUFD.Text; leave.Add(leaves); }
                                else if (chk_SUHD.Checked) { leaves = "SU ->" + chk_SUHD.Text; leave.Add(leaves); }
                                else
                                {
                                    days += chkDays.GetItemText(itemChecked) + ",";
                                    timings = "Su ->" + cmb_SUST.SelectedItem + "-" + cmb_SUET.SelectedItem; time.Add(timings);
                                }
                            }
                        }


                        string st = "";
                        string l = "";
                        foreach (var t in time)
                        {
                            st += t + ",";
                        }
                        foreach (var le in leave)
                        {
                            l += le + ',';
                        }

                        if (UpdateThId > 0)
                        {
                            tbltherapist objtbltherapist = new tbltherapist()
                            {
                                TherapistId = Convert.ToInt32(UpdateThId),
                                Name = Convert.ToString(txt_thpname.Text.Trim()),
                                Address = Convert.ToString(txt_thpadd.Text.Trim()),
                                Specialist = Convert.ToString(txt_thpspc.Text.Trim()),
                                Mobile = Convert.ToString(txt_thpmob.Text.Trim()),
                                Email = Convert.ToString(txt_thpemail.Text.Trim()),
                                Commission = Convert.ToDecimal(txt_thpamt.Text.Trim()),
                                //Availability = Convert.ToString(ddlStartTime.SelectedItem + "-" + ddlEndTime.SelectedItem),
                                Days = days.TrimEnd(','),
                                //Leave = chkLeave.Checked == true ? true : false,
                                FK_BranchId = branchID,
                                IsActive = true,
                                Timings = st.TrimEnd(','),
                                TherapistLeave = l.TrimEnd(','),
                            };
                            IsAvailable = settingdal.InsertUpdateTherapist(objtbltherapist);
                            if (IsAvailable > 0)
                            {
                                MessageBox.Show("Data updated successfully", "Updation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGrid();
                                ClearForm();
                            }
                        }
                        else
                        {
                            if (settingdal.GetAllMobileClient((int)branchID).ToList().Contains(txt_thpmob.Text.Trim()))
                            {
                                MessageBox.Show("This mobile no. already exist. Please use different mobile no.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt_thpmob.Text = string.Empty;
                                return false;
                            }
                            else
                            {
                                tbltherapist objtbltherapist = new tbltherapist()
                                {
                                    Name = Convert.ToString(txt_thpname.Text.Trim()),
                                    Address = Convert.ToString(txt_thpadd.Text.Trim()),
                                    Specialist = Convert.ToString(txt_thpspc.Text.Trim()),
                                    Mobile = Convert.ToString(txt_thpmob.Text.Trim()),
                                    Email = Convert.ToString(txt_thpemail.Text.Trim()),
                                    Commission = txt_thpamt.Text.Trim() == "" ? Convert.ToDecimal(null) : Convert.ToDecimal(txt_thpamt.Text.Trim()),
                                    FK_BranchId = branchID,
                                    //Availability = Convert.ToString(ddlStartTime.SelectedItem + "-" + ddlEndTime.SelectedItem),
                                    Days = days.TrimEnd(','),
                                    //Leave = chkLeave.Checked == true ? true : false,                                
                                    IsActive = true,
                                    Timings = st.TrimEnd(','),
                                    TherapistLeave = l.TrimEnd(','),
                                };
                                IsAvailable = settingdal.InsertUpdateTherapist(objtbltherapist);
                                if (IsAvailable > 0)
                                {
                                    MessageBox.Show("Data inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BindGrid();
                                    ClearForm();
                                }
                                return true;
                            }
                        }
                    }
                    return true;
                }
                else { return false; }
            }
            //catch (Exception) { return false; }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTherapist();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txt_thpamt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_thpamt.Text.Trim()))
                {
                    if (Convert.ToInt32(txt_thpamt.Text) > 100)
                    {
                        MessageBox.Show("Commission should be less than 100", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_thpamt.Text = string.Empty;
                    }
                }
            }
            catch (Exception) { }
        }

        private void txt_thpamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void grdtherapist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean IsDeleted = false;
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.ColumnIndex == 11 && e.RowIndex >= 0)
                {
                    string ThpName = Convert.ToString(grdtherapist.Rows[e.RowIndex].Cells[1].Value);

                    int ThpId = default(int);
                    int.TryParse(Convert.ToString(grdtherapist.Rows[e.RowIndex].Cells[0].Value), out ThpId);
                    if (ThpId > 0) { ShowTextValues(ThpId); } else { MessageBox.Show("Data Not Found"); }
                }
                if (e.ColumnIndex == 12 && e.RowIndex >= 0)
                {
                    int ThpId = default(int);
                    int.TryParse(Convert.ToString(grdtherapist.Rows[e.RowIndex].Cells[0].Value), out ThpId);
                    Boolean? status = settingdal.GetStatusOfTherapist(ThpId);
                    if (!(Boolean)status)
                    {
                        MessageBox.Show("This Therapist is already InActive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            IsDeleted = settingdal.DeleteTherapist(ThpId, branchID);
                            if (IsDeleted)
                            {
                                MessageBox.Show("Therapist deleted successfully.", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information); BindGrid();
                            }
                            else
                            {
                                MessageBox.Show("Sorry! Server error. Please try again");
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void txt_thpadd_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTherapist_Load(object sender, EventArgs e)
        {

        }
        DateTime start = Convert.ToDateTime(null);
        DateTime end = Convert.ToDateTime(null);
        DateTime startTime = default(DateTime);
        //private void ddlStartTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlStartTime.SelectedIndex > 0 && ddlEndTime.SelectedIndex > 0)
        //        {
        //            DateTime time = Convert.ToDateTime(ddlStartTime.SelectedValue.ToString());
        //            startTime = time;
        //            if (end != null)
        //            {
        //                if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
        //                {
        //                    MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ddlStartTime.SelectedIndex = 0;
        //                }
        //                else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
        //                {
        //                    MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ddlStartTime.SelectedIndex = 0;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception) { }
        //}

        //private void ddlEndTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlEndTime.SelectedIndex > 0 && ddlStartTime.SelectedIndex > 0)
        //        {
        //            start = Convert.ToDateTime(ddlStartTime.SelectedValue.ToString());
        //            end = Convert.ToDateTime(ddlEndTime.SelectedValue.ToString());
        //            if (start != null && end != null)
        //            {
        //                if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
        //                {
        //                    MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ddlEndTime.SelectedIndex = 0;
        //                }
        //                else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
        //                {
        //                    MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ddlEndTime.SelectedIndex = 0;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception) { }
        //}

        private void txt_thpspc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txt_thpmob_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void chkDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            count = chkDays.Items.Count;

            for (int i = 0; i < count; i++)
            {
                if (chkDays.Items[i].ToString() == "Monday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_MST.Enabled = true; cmb_MET.Enabled = true; chk_MFD.Enabled = true; chk_MHD.Enabled = true; }
                    else { cmb_MST.SelectedIndex = 0; cmb_MET.SelectedIndex = 0; chk_MFD.Checked = false; chk_MHD.Checked = false; cmb_MST.Enabled = false; cmb_MET.Enabled = false; chk_MFD.Enabled = false; chk_MHD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Tuesday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_TST.Enabled = true; cmb_TET.Enabled = true; chk_TFD.Enabled = true; chk_THD.Enabled = true; }
                    else { cmb_TST.SelectedIndex = 0; cmb_TET.SelectedIndex = 0; chk_TFD.Checked = false; chk_THD.Checked = false; cmb_TST.Enabled = false; cmb_TET.Enabled = false; chk_TFD.Enabled = false; chk_THD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Wednesday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_WST.Enabled = true; cmb_WET.Enabled = true; chk_WFD.Enabled = true; chk_WHD.Enabled = true; }
                    else { cmb_WST.SelectedIndex = 0; cmb_WET.SelectedIndex = 0; chk_WFD.Checked = false; chk_WHD.Checked = false; cmb_WST.Enabled = false; cmb_WET.Enabled = false; chk_WFD.Enabled = false; chk_WHD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Thursday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_THST.Enabled = true; cmb_THET.Enabled = true; chk_THFD.Enabled = true; chk_THHD.Enabled = true; }
                    else { cmb_THST.SelectedIndex = 0; cmb_THET.SelectedIndex = 0; chk_THFD.Checked = false; chk_THHD.Checked = false; cmb_THST.Enabled = false; cmb_THET.Enabled = false; chk_THFD.Enabled = false; chk_THHD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Friday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_FST.Enabled = true; cmb_FET.Enabled = true; chk_FFD.Enabled = true; chk_FHD.Enabled = true; }
                    else { cmb_FST.SelectedIndex = 0; cmb_FET.SelectedIndex = 0; chk_FFD.Checked = false; chk_FHD.Checked = false; cmb_FST.Enabled = false; cmb_FET.Enabled = false; chk_FFD.Enabled = false; chk_FHD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Saturday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_SST.Enabled = true; cmb_SET.Enabled = true; chk_SFD.Enabled = true; chk_SHD.Enabled = true; }
                    else { cmb_SST.SelectedIndex = 0; cmb_SET.SelectedIndex = 0; chk_SFD.Checked = false; chk_SHD.Checked = false; cmb_SST.Enabled = false; cmb_SET.Enabled = false; chk_SFD.Enabled = false; chk_SHD.Enabled = false; }
                }
                if (chkDays.Items[i].ToString() == "Sunday")
                {
                    if (chkDays.GetItemCheckState(i).ToString() == "Checked") { cmb_SUST.Enabled = true; cmb_SUET.Enabled = true; chk_SUFD.Enabled = true; chk_SUHD.Enabled = true; }
                    else { cmb_SUST.SelectedIndex = 0; cmb_SUET.SelectedIndex = 0; chk_SUFD.Checked = false; chk_SUHD.Checked = false; cmb_SUST.Enabled = false; cmb_SUET.Enabled = false; chk_SUFD.Enabled = false; chk_SUHD.Enabled = false; }
                }
            }
        }


        #region ------------------ Dropdown And Checkbox Validation ----------------------------

        private void cmb_MST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_MST.SelectedIndex > 0 && cmb_MET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_MST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_MST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_MST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }      
        private void cmb_MET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_MET.SelectedIndex > 0 && cmb_MST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_MST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_MET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_MET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_MET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_TST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_TST.SelectedIndex > 0 && cmb_TET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_TST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_TST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_TST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_TET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_TET.SelectedIndex > 0 && cmb_TST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_TST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_TET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_TET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_TET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_WST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_WST.SelectedIndex > 0 && cmb_WET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_WST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_WST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_WST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_WET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_WET.SelectedIndex > 0 && cmb_WST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_WST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_WET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_WET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_WET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_THST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_THST.SelectedIndex > 0 && cmb_THET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_THST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_THST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_THST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_THET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_THET.SelectedIndex > 0 && cmb_THST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_THST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_THET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_THET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_THET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }        
        private void cmb_FST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_FST.SelectedIndex > 0 && cmb_FET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_FST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_FST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_FST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_FET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_FET.SelectedIndex > 0 && cmb_FST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_FST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_FET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_FET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_FET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }        
        private void cmb_SST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_SST.SelectedIndex > 0 && cmb_SET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_SST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_SET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_SET.SelectedIndex > 0 && cmb_SST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_SST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_SET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }       
        private void cmb_SUST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_SUST.SelectedIndex > 0 && cmb_SUET.SelectedIndex > 0)
                {
                    DateTime time = Convert.ToDateTime(cmb_SUST.SelectedValue.ToString());
                    startTime = time;
                    if (end != null)
                    {
                        if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SUST.SelectedIndex = 0;
                        }
                        else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SUST.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cmb_SUET_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_SUET.SelectedIndex > 0 && cmb_SUST.SelectedIndex > 0)
                {
                    start = Convert.ToDateTime(cmb_SUST.SelectedValue.ToString());
                    end = Convert.ToDateTime(cmb_SUET.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less than End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SUET.SelectedIndex = 0;
                        }
                        else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_SUET.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        
        
        
        private void chk_MFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MFD.Checked == true)
            {
                chk_MHD.Checked = false;
                //if (chk_MHD.Checked == true)
                //{
                //    MessageBox.Show("Select only 1 leave - Half Day/Full Day", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //chk_MHD.Checked = false;
                //}
            }
        }
        private void chk_MHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MHD.Checked == true)
            {
                chk_MFD.Checked = false;
                //if (chk_MFD.Checked == true)
                //{
                //    MessageBox.Show("Select only 1 leave - Half Day/Full Day", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //chk_MHD.Checked = false;
                //}             
            }
        }
        private void chk_TFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_TFD.Checked == true)
            {
                chk_THD.Checked = false;
            }
        }
        private void chk_THD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_THD.Checked == true)
            {
                chk_TFD.Checked = false;
            }
        }
        private void chk_WFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_WFD.Checked == true)
            {
                chk_WHD.Checked = false;
            }
        }
        private void chk_WHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_WHD.Checked == true)
            {
                chk_WFD.Checked = false;
            }
        }
        private void chk_THFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_THFD.Checked == true)
            {
                chk_THHD.Checked = false;
            }
        }
        private void chk_THHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_THHD.Checked == true)
            {
                chk_THFD.Checked = false;
            }
        }
        private void chk_FFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FFD.Checked == true)
            {
                chk_FHD.Checked = false;
            }
        }
        private void chk_FHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FHD.Checked == true)
            {
                chk_FFD.Checked = false;
            }
        }
        private void chk_SFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SFD.Checked == true)
            {
                chk_SHD.Checked = false;
            }
        }
        private void chk_SHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SHD.Checked == true)
            {
                chk_SFD.Checked = false;
            }
        }
        private void chk_SUFD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SUFD.Checked == true)
            {
                chk_SUHD.Checked = false;
            }
        }                
        private void chk_SUHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SUHD.Checked == true)
            {
                chk_SUFD.Checked = false;
            }
        }

        #endregion

    }
}












//time.Clear(); leave.Clear();
//                        foreach (var itemChecked in chkDays.CheckedItems)
//                        {
//                            days += chkDays.GetItemText(itemChecked) + ",";

//                            if (chkDays.GetItemText(itemChecked) == "Monday")
//                            {
//                                timings = "MO ->" + cmb_MST.SelectedItem + "-" + cmb_MET.SelectedItem; time.Add(timings);
//                                if (chk_MFD.Checked) { leaves = "MO ->" + chk_MFD.Text; leave.Add(leaves); }
//                                else if (chk_MHD.Checked) { leaves = "MO ->" + chk_MHD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Tuesday")
//                            {
//                                timings = "TU ->" + cmb_TST.SelectedItem + "-" + cmb_TET.SelectedItem; time.Add(timings);
//                                if (chk_TFD.Checked) { leaves = "TU ->" + chk_TFD.Text; leave.Add(leaves); }
//                                else if (chk_THD.Checked) { leaves = "TU ->" + chk_THD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Wednesday")
//                            {
//                                timings = "WE ->" + cmb_WST.SelectedItem + "-" + cmb_WET.SelectedItem; time.Add(timings);
//                                if (chk_WFD.Checked) { leaves = "WE ->" + chk_WFD.Text; leave.Add(leaves); }
//                                else if (chk_WHD.Checked) { leaves = "WE ->" + chk_WHD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Thursday")
//                            {
//                                timings = "TH ->" + cmb_THST.SelectedItem + "-" + cmb_THET.SelectedItem; time.Add(timings);
//                                if (chk_THFD.Checked) { leaves = "TH ->" + chk_THFD.Text; leave.Add(leaves); }
//                                else if (chk_THHD.Checked) { leaves = "TH ->" + chk_THHD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Friday")
//                            {
//                                timings = "FR ->" + cmb_FST.SelectedItem + "-" + cmb_FET.SelectedItem; time.Add(timings);
//                                if (chk_FFD.Checked) { leaves = "FR ->" + chk_FFD.Text; leave.Add(leaves); }
//                                else if (chk_FHD.Checked) { leaves = "FR ->" + chk_FHD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Saturday")
//                            {
//                                timings = "SA ->" + cmb_SST.SelectedItem + "-" + cmb_SET.SelectedItem; time.Add(timings);
//                                if (chk_SFD.Checked) { leaves = "SA ->" + chk_SFD.Text; leave.Add(leaves); }
//                                else if (chk_SHD.Checked) { leaves = "SA ->" + chk_SHD.Text; leave.Add(leaves); }
//                            }
//                            else if (chkDays.GetItemText(itemChecked) == "Sunday")
//                            {
//                                timings = "SU ->" + cmb_SUST.SelectedItem + "-" + cmb_SUET.SelectedItem; time.Add(timings);
//                                if (chk_SUFD.Checked) { leaves = "SU ->" + chk_SUFD.Text; leave.Add(leaves); }
//                                else if (chk_SUHD.Checked) { leaves = "SU ->" + chk_SUHD.Text; leave.Add(leaves); }
//                            }
//                        }
