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
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Data.Entity.Core.Objects;
using SPAPracticeManagement.Custom_Controls;
using SPAPracticeManagement.CustomControls.Client;

namespace SPAPracticeManagement.Appointments
{
    public partial class Booking : Dashboard
    {
        
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        SettingDAL ObjSettingDAL = new SettingDAL();

        DashboardDAL dashboard_dal = new DashboardDAL();
        #region Propertise
        AppointmentDAL objAppointmentDAL = new AppointmentDAL();
        ClientDAL objClientDAL = new ClientDAL();
        SettingDAL objSettingDAL = new SettingDAL();
        string startTime = "";
        string endTime = "";
        string time = "";
        public AppointmentDAL Appointment
        {
            get { return new AppointmentDAL(); }
        }

        public ClientDAL ClientList
        {
            get { return new ClientDAL(); }
        }

        private int _UpdateClientId;
        public int UpdateClientId
        {
            get { return _UpdateClientId; }
            set { _UpdateClientId = value; }
        }

        #endregion

        #region Calendar Detail

        //.............. Code Updated for Calender By Sam on 07092016.........................

        private void Generate()
        {
            string Name = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string daynm = txtDOB.Value.DayOfWeek.ToString();
            List<tbltherapist> objtbltherapist = Appointment.GetTherepistNameforAppointmentSchedule(branchID);
            List<string> therepistTimeSchedule = Appointment.GetAppointmentScheduleTimeforTherepist();
            int colIndex = 0;
            var index = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i <= objtbltherapist.Count; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                if (i == 0)
                {
                    col.HeaderText = "Time";
                    colIndex = dataGridView1.Columns.Add(col);
                    dataGridView1.Columns[i].Width = 120;
                    for (int j = 0; j < therepistTimeSchedule.Count; j++)
                    {
                        index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.LightPink;
                        dataGridView1.Rows[index].Cells[0].Value = therepistTimeSchedule[j].ToString();
                    }
                }
                else
                {
                    List<int> totalindex = new List<int>();
                    List<int> avindex = new List<int>();
                    index = 0;
                    colIndex = dataGridView1.Columns.Add(col);
                    col.HeaderText = objtbltherapist[i - 1].Name.ToString();
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    List<tblappointment> objtblappointment = Appointment.GetAppointmentdetailByTherapistId(objtbltherapist[i - 1].TherapistId, Convert.ToDateTime(txtDOB.Value), branchID);
                    if (objtblappointment.Count > 0)
                    {
                        foreach (tblappointment tap in objtblappointment)
                        {
                            string[] aptime = tap.AppointmentTime.Split('-');
                            TimeSpan frtime = TimeSpan.Parse(aptime[0].Substring(0, 5));
                            TimeSpan totime = TimeSpan.Parse(aptime[1].Substring(0, 6));
                            for (int j = 0; j < therepistTimeSchedule.Count; j++)
                            {
                                string slottime = therepistTimeSchedule[j];
                                string[] slottimedtl = slottime.Split('-');
                                TimeSpan slotfromtime = TimeSpan.Parse(slottimedtl[0].Substring(0, 5));
                                TimeSpan slottotime = TimeSpan.Parse(slottimedtl[1].Substring(0, 5));
                                //................... code added by sam............................. 
                                string[] splt = objtbltherapist[i - 1].Timings.Split(',');
                                foreach (var tl in splt)
                                {
                                    if (tl.Contains(daynm.Substring(0, 2)))
                                    {
                                        string[] split = tl.Substring(5).Split('-');
                                        string st = split[0].Trim();
                                        TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
                                        TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));
                                        if (fdt >= slotfromtime && fdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        if (fdt > slotfromtime && fdt >= slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt >= slottotime && slottotime != TimeSpan.Parse("00:00"))
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt >= slottotime && slottotime == TimeSpan.Parse("00:00"))
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                        else if (tdt > slotfromtime && tdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        }
                                        else if (tdt < slotfromtime && tdt > slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                    }
                                }
                                if (frtime >= slotfromtime && frtime < slottotime)
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                }
                                else if (slotfromtime > frtime && slottotime <= totime && slottotime != TimeSpan.Parse("00:00"))
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                }
                                else if (totime > slotfromtime && totime <= slottotime)
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < therepistTimeSchedule.Count; j++)
                        {
                            string slottime = therepistTimeSchedule[j];
                            string[] slottimedtl = slottime.Split('-');
                            TimeSpan slotfromtime = TimeSpan.Parse(slottimedtl[0].Substring(0, 5));
                            TimeSpan slottotime = TimeSpan.Parse(slottimedtl[1].Substring(0, 5));
                            string[] splt = objtbltherapist[i - 1].Timings.Split(',');
                            foreach (var tl in splt)
                            {
                                if (tl.Contains(daynm.Substring(0, 2)))
                                {
                                    string[] split = tl.Substring(5).Split('-');
                                    string st = split[0].Trim();
                                    TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
                                    TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));
                                    if (fdt >= slotfromtime && fdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    if (fdt > slotfromtime && fdt >= slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt >= slottotime && slottotime != TimeSpan.Parse("00:00"))
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt >= slottotime && slottotime == TimeSpan.Parse("00:00"))
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                    else if (tdt > slotfromtime && tdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                    }

                                    else if (tdt < slotfromtime && tdt > slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                }
                            }
                        }







                        //for (int j = 0; j < therepistTimeSchedule.Count; j++)
                        //{
                        //    index = dataGridView1.Rows.Add();
                        //    dataGridView1.Rows[index].Cells[0].Value = therepistTimeSchedule[j].ToString();
                        //}
                    }

                    //List<tbltherapist> objtblcompdetail = Appointment.GetTherepistDetail(branchID);
                    //foreach(tbltherapist item in objtblcompdetail)
                    //{
                    //    if (col.HeaderText == item.Name)
                    //    {
                    //        if (!item.Days.Contains(Name))
                    //        {
                    //            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    //            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    //            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);
                    //            //dataGridView1.EnableHeadersVisualStyles = false;
                    //            //int colIndex = dataGridView1.Columns.Add(col);
                    //            colIndex = dataGridView1.Columns.Add(col);
                    //            dataGridView1.Columns[i].Width = 120;
                    //            dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Gray;
                    //            //var index = dataGridView1.Rows.Add();
                    //            index = dataGridView1.Rows.Add();
                    //            dataGridView1.Rows[index].Cells[0].Value = therepistTimeSchedule[i].ToString();
                    //            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.SteelBlue;
                    //            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                    //            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);
                    //            if (i == StartTimeSchedule.Count - 1)
                    //            {
                    //                int j = i;
                    //                //for(i=j;i<therepistTimeSchedule.Count-1;i++)
                    //                for (j = i + 1; j < therepistTimeSchedule.Count; j++)
                    //                {
                    //                    var index1 = dataGridView1.Rows.Add();
                    //                    dataGridView1.Rows[index1].Cells[0].Value = therepistTimeSchedule[j].ToString();
                    //                    dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.SteelBlue;
                    //                    dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                    //                    dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);

                    //                }
                    //            }
                    //        }
                    //        else
                    //        {

                    //            colIndex = dataGridView1.Columns.Add(col);
                    //            dataGridView1.Columns[i].Width = 120;
                    //            dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Green;
                    //            index = dataGridView1.Rows.Add();
                    //            dataGridView1.Rows[index].Cells[0].Value = therepistTimeSchedule[i].ToString();
                    //            List<string> appointmenttiming = Appointment.GetAppointmenttimeByTherepistidAndAppointmentdate(item.TherapistId, DateTime.Now, branchID);
                    //            //dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.SteelBlue;
                    //            //dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                    //            //dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);
                    //            if (i == StartTimeSchedule.Count - 1)
                    //            {
                    //                int j = i;
                    //                //for(i=j;i<therepistTimeSchedule.Count-1;i++)
                    //                for (j = i + 1; j < therepistTimeSchedule.Count; j++)
                    //                {
                    //                    var index1 = dataGridView1.Rows.Add();
                    //                    dataGridView1.Rows[index1].Cells[0].Value = therepistTimeSchedule[j].ToString();
                    //                    dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.SteelBlue;
                    //                    dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                    //                    dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Arial", 7.75F, FontStyle.Bold);

                    //                }
                    //            }
                    //        }
                    //        break;
                    //    }
                    //}
                }

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
            Generate1();

        }

        private void Generate1()
        {
            string Name = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(monthCalendar1.SelectionStart.DayOfWeek);
            string daynm = monthCalendar1.SelectionStart.DayOfWeek.ToString();
            List<tbltherapist> objtbltherapist = Appointment.GetTherepistNameforAppointmentSchedule(branchID);
            List<string> therepistTimeSchedule = Appointment.GetAppointmentScheduleTimeforTherepist();
            int colIndex = 0;
            var index = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i <= objtbltherapist.Count; i++)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                if (i == 0)
                {
                    col.HeaderText = "Time";
                    colIndex = dataGridView1.Columns.Add(col);
                    dataGridView1.Columns[i].Width = 120;
                    for (int j = 0; j < therepistTimeSchedule.Count; j++)
                    {
                        index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.LightPink;
                        dataGridView1.Rows[index].Cells[0].Value = therepistTimeSchedule[j].ToString();
                    }
                }
                else
                {
                    List<int> totalindex = new List<int>();
                    List<int> avindex = new List<int>();
                    index = 0;
                    colIndex = dataGridView1.Columns.Add(col);

                    col.HeaderText = objtbltherapist[i - 1].Name.ToString();
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    List<tblappointment> objtblappointment = Appointment.GetAppointmentdetailByTherapistId(objtbltherapist[i - 1].TherapistId, Convert.ToDateTime(monthCalendar1.SelectionStart), branchID);

                    if (objtblappointment.Count > 0)
                    {

                        foreach (tblappointment tap in objtblappointment)
                        {

                            string[] aptime = tap.AppointmentTime.Split('-');
                            TimeSpan frtime = TimeSpan.Parse(aptime[0].Substring(0, 5));
                            TimeSpan totime = TimeSpan.Parse(aptime[1].Substring(0, 5));
                            for (int j = 0; j < therepistTimeSchedule.Count; j++)
                            {
                                string slottime = therepistTimeSchedule[j];
                                string[] slottimedtl = slottime.Split('-');
                                TimeSpan slotfromtime = TimeSpan.Parse(slottimedtl[0].Substring(0, 5));
                                TimeSpan slottotime = TimeSpan.Parse(slottimedtl[1].Substring(0, 5));
                                //................... code added by sam.............................

                                string[] splt = objtbltherapist[i - 1].Timings.Split(',');
                                foreach (var tl in splt)
                                {
                                    if (tl.Contains(daynm.Substring(0, 2)))
                                    {
                                        string[] split = tl.Substring(5).Split('-');
                                        string st = split[0].Trim();
                                        TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
                                        TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));

                                        if (fdt >= slotfromtime && fdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        if (fdt > slotfromtime && fdt >= slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt >= slottotime && slottotime != TimeSpan.Parse("00:00"))
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt >= slottotime && slottotime == TimeSpan.Parse("00:00"))
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                        else if (tdt > slotfromtime && tdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                            avindex.Add(j);
                                        }
                                        else if (fdt < slotfromtime && tdt < slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        }
                                        else if (tdt < slotfromtime && tdt > slottotime)
                                        {
                                            dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                            avindex.Add(j);
                                        }
                                    }
                                }


                                if (frtime >= slotfromtime && frtime < slottotime)
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                    //naindex.Add(j);
                                }
                                else if (slotfromtime > frtime && slottotime <= totime && slottotime != TimeSpan.Parse("00:00"))
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                }
                                else if (totime > slotfromtime && totime <= slottotime)
                                {
                                    dataGridView1.Rows[j].Cells[colIndex].Value = "Booked";
                                    dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Red;
                                    totalindex.Add(j);
                                }




                                //if (!totalindex.Contains(j))
                                //    {
                                //        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                //    }
                                //}



                                //idlist = objAppointmentDAL.GetThpIdFromTime(day).ToList();




                                //................... code above added by sam.........................



                            }
                        }
                    }
                    else
                    {

                        //dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.DarkGray;

                        for (int j = 0; j < therepistTimeSchedule.Count; j++)
                        {
                            string slottime = therepistTimeSchedule[j];
                            string[] slottimedtl = slottime.Split('-');
                            TimeSpan slotfromtime = TimeSpan.Parse(slottimedtl[0].Substring(0, 5));
                            TimeSpan slottotime = TimeSpan.Parse(slottimedtl[1].Substring(0, 5));
                            //................... code added by sam.............................

                            string[] splt = objtbltherapist[i - 1].Timings.Split(',');
                            foreach (var tl in splt)
                            {
                                if (tl.Contains(daynm.Substring(0, 2)))
                                {
                                    string[] split = tl.Substring(5).Split('-');
                                    string st = split[0].Trim();
                                    TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
                                    TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));

                                    if (fdt >= slotfromtime && fdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    if (fdt > slotfromtime && fdt >= slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt >= slottotime && slottotime != TimeSpan.Parse("00:00"))
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt >= slottotime && slottotime == TimeSpan.Parse("00:00"))
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                    else if (tdt > slotfromtime && tdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.Green;
                                        avindex.Add(j);
                                    }
                                    else if (fdt < slotfromtime && tdt < slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                    }
                                    else if (tdt < slotfromtime && tdt > slottotime)
                                    {
                                        dataGridView1.Rows[j].Cells[colIndex].Style.BackColor = Color.DarkGray;
                                        avindex.Add(j);
                                    }
                                }
                            }
                        }
                    }


                }

            }
            dataGridView1.ClearSelection();
            dataGridView1.Columns[0].Frozen = true;
        }



        //............... Code Above updated by sam on 07092016.................................... 

        #endregion Calendar

        private void ddl_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_package.SelectedIndex != 0)
            {
                decimal pkgAm = 0;
                string pkgid = ddl_package.SelectedValue.ToString();
                if (pkgid != "0")
                {
                    pkgAm = objSettingDAL.GetPackageAmount(Convert.ToInt32(pkgid), branchID);
                    txt_totalamt.Text = Convert.ToString(pkgAm);
                }
                else
                {
                    //txt_TotalTax.Text = string.Empty;
                }
                while (chklst_PackageItem.CheckedIndices.Count > 0)
                {
                    chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
                }
                if (ddl_package.SelectedIndex != 0)
                {
                    List<tblservice> objtblservice = objAppointmentDAL.GetAllServiceByPackageId(Convert.ToInt32(ddl_package.SelectedValue), branchID);
                    if (objtblservice != null)
                    {
                        decimal? packageAmt = 0;
                        int? prevTime = 0;
                        int indexno = 0;
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
                                    int? tTime = TimeExpendeCalculate(Convert.ToInt32(serid));
                                    prevTime = prevTime + tTime;


                                    break;
                                }
                                else
                                {
                                    i = i + 1;
                                }
                            }


                        }
                        if (prevTime > 0)
                        {
                            decimal cnt = (Convert.ToDecimal(prevTime) / Convert.ToDecimal(15));
                            indexno = Convert.ToInt32(cnt) + 1;
                        }

                        txt_timeExpende.Text = Convert.ToString(prevTime) + " Minutes";
                        ddlEndTime.SelectedIndex = ddlStartTime.SelectedIndex + indexno;

                        /*---------------Code Added By Sandip Das on 09-06-2016----------------------*/
                        DateTime stime = Convert.ToDateTime(ddlStartTime.SelectedItem);
                        string t = stime.ToString("hh:mm tt");
                        double timeAdd = Convert.ToDouble(prevTime);
                        DateTime time = stime.AddMinutes(timeAdd);
                        string t1 = time.ToString("hh:mm tt");
                        DateTime tt = Convert.ToDateTime(t1);

                        foreach (string item in ddlEndTime.Items)
                        {
                            DateTime? dt = DateTime.Parse(item);
                            string t2 = item;
                            if (dt.Value.Ticks >= tt.Ticks)
                            {
                                //ddlEndTime.SelectedItem = t2;
                                ddlEndTime.SelectedIndex = ddlEndTime.FindString(t2);
                                break;
                            }
                        }
                        /*----------------------------------END----------------------*/

                        //decimal? discountcoupon = 0;
                        //txtServiceCharge.Text = Convert.ToString(pkgAm);
                        //if (txtDiscount.Text.Trim() != "")
                        //{
                        //    totalAmount.Text = Convert.ToString(packageAmt - discountcoupon);

                        //}
                        //else
                        //{
                        //    totalAmount.Text = Convert.ToString(packageAmt);
                        //}

                        /*Total Tax Calculation Begin*/
                        //string sId = Convert.ToString(li1.ServiceId);

                        // string amount = objSettingDAL.GetTaxToatlAmountByPackageId(id, branchID);
                        //string tax_percentage = TaxCalculate(Convert.ToInt32(sId));
                        //string tax_percentage = objSettingDAL.GetTaxTotalAmountByPackageId(Convert.ToInt32(ddl_package.SelectedValue), branchID);
                        //txt_TotalTax.Text = Convert.ToString(Math.Round((Convert.ToDecimal(txtServiceCharge.Text) * Convert.ToDecimal(tax_percentage)), 2) / 100);
                        /*Total Tax Calculation End*/

                        //................ code added by sam on 06092016..............................
                        //CalculationAmount();

                        //................ code above added by sam on 06092016..............................
                    }
                    //else if (txtServiceCharge.Text.Trim() != "")
                    //{
                    //    txtServiceCharge.Text = string.Empty;
                    //    totalAmount.Text = string.Empty;
                    //    txt_GrossAmount.Text = string.Empty;
                    //    txt_timeExpende.Text = string.Empty;
                    //}
                    chklst_PackageItem.Enabled = false;
                }
            }
            else
            {
                chklst_PackageItem.Enabled = true;
                while (chklst_PackageItem.CheckedIndices.Count > 0)
                {
                    chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
                }
                txt_timeExpende.Text = "";
                txt_totalamt.Text = "";
            }
            //else if (txtServiceCharge.Text.Trim() != "")
            //{
            //    txtServiceCharge.Text = string.Empty;
            //    totalAmount.Text = string.Empty;
            //    chklst_PackageItem.Enabled = true;
            //    txt_GrossAmount.Text = string.Empty;
            //    txt_timeExpende.Text = string.Empty;
            //}

        }
        private int SaveAppointment()
        {
            int r = 0;

            try
            {
                //string startTime = "";
                //string endTime = "";
                //string time = "";
                int i = default(int);
                bool IsValid = false;

                tblavailablity tblavl = new tblavailablity();
                tblservice tblsrvc = new tblservice();

                Utility ut = new Utility();
                tblclient tp = new tblclient();

                tblappointment tap = new tblappointment();
                decimal? totalamt = 0;
                bool ret = false;
                if (ValidateForm())
                {
                    string s = txtClientName.Text.Trim();

                    int start = s.IndexOf(":") + 1;
                    int end = s.IndexOf(")", start);
                    if (end < 0)
                    {
                        MessageBox.Show("Invalid Client Name Entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                    string result = s.Substring(start, end - start);
                    //int ClientId = Convert.ToInt32(result.Trim());
                    int ClientId = objAppointmentDAL.GetClientIdFromMobile(result);

                    string pName = s.Substring(0, s.IndexOf("("));

                    tblappointment objAppointment = new tblappointment();
                    if (Convert.ToString(ddl_package.SelectedValue) != "0")
                    {
                        objAppointment.ByPackage = true;

                    }
                    else
                    {
                        objAppointment.ByPackage = false;

                    }

                    objAppointment.FK_ClientId = ClientId;
                    UpdateClientId = ClientId;
                    objAppointment.AppointmentDate = Convert.ToDateTime(txtDOB.Text, CultureInfo.InvariantCulture);
                    objAppointment.AppointmentTime = ddlStartTime.Text + " - " + ddlEndTime.Text;

                    objAppointment.FK_TherapistId = Convert.ToInt32(therapist_combo.SelectedValue);
                    objAppointment.IsActive = true;
                    objAppointment.FK_BranchID = AppsPropertise.UserDetails.BranchId;
                    if (txt_totalamt.Text != "")
                    {
                        objAppointment.Total = Convert.ToDecimal(txt_totalamt.Text);
                    }
                    //objAppointment.Total = Convert.ToDecimal(txtServiceCharge.Text.Trim() == "" ? "0" : txtServiceCharge.Text.Trim());
                    //objAppointment.NetTotal = Convert.ToDecimal(totalAmount.Text.Trim() == "" ? "0" : totalAmount.Text.Trim());
                    //objAppointment.TotalTax = Convert.ToDecimal(txt_TotalTax.Text.Trim() == "" ? "0" : txt_TotalTax.Text.Trim());
                    //objAppointment.GrossAmount = Convert.ToDecimal(txt_GrossAmount.Text.Trim() == "" ? "0" : txt_GrossAmount.Text.Trim());
                    //objAppointment.AdvanceAmount = Convert.ToDecimal(txt_advance.Text.Trim() == "" ? "0" : txt_advance.Text.Trim());
                    //objAppointment.DueAmount = Convert.ToDecimal(txt_due.Text.Trim() == "" ? "0" : txt_due.Text.Trim());
                    //objAppointment.ReceivedAmount = Convert.ToDecimal(txt_AmountReceived.Text.Trim() == "" ? "0" : txt_AmountReceived.Text.Trim());
                    //objAppointment.BalanceAmount = Math.Abs(Convert.ToDecimal(txt_ReturnAmount.Text.Trim() == "" ? "0" : txt_ReturnAmount.Text.Trim()));
                    //objAppointment.PaymentMode = comboBox_payment.SelectedItem.ToString();
                    //objAppointment.Discount = Math.Abs((objAppointment.NetTotal - objAppointment.Total).Value);
                    //if (!string.IsNullOrEmpty(txtCouponID.Text.Trim()) && txtIsValid.Text.Trim().ToString() == "YES")
                    //{
                    //    var res = objAppointmentDAL.GetIdByName(txtCouponID.Text.Trim(), branchID);
                    //    if (res != 0) { objAppointment.FK_CouponId = res; }
                    //}


                    //if (objAppointment.GrossAmount == objAppointment.AdvanceAmount)
                    //{
                    //    objAppointment.PaymentType = "Full Paid";
                    //}
                    //else if (objAppointment.GrossAmount > objAppointment.AdvanceAmount)
                    //{
                    //    objAppointment.PaymentType = "Advanced Paid";
                    //}




                    //if (comboBox_payment.SelectedItem == "CASH")
                    //{
                    //    objAppointment.PaymentMode = Convert.ToString(comboBox_payment.SelectedItem);
                    //}

                    //else if (comboBox_payment.SelectedItem == "CREDIT")
                    //{
                    //    objAppointment.PaymentMode = Convert.ToString(comboBox_payment.SelectedItem);
                    //}
                    //else { }

                    i = objAppointmentDAL.InsertUpdateAppointment(objAppointment);



                    if (i > 0)
                    {
                        if (Convert.ToString(ddl_package.SelectedValue) != "0")
                        {
                            tblappointmentpackagepping objtblappointmentpackagepping = new tblappointmentpackagepping();
                            objtblappointmentpackagepping.FK_BranchID = branchID;
                            objtblappointmentpackagepping.FK_AppointmentId = i;
                            objtblappointmentpackagepping.FK_PackageId = Convert.ToInt32(ddl_package.SelectedValue);
                            int j = objAppointmentDAL.InsertUpdateappointmentpackagepping(objtblappointmentpackagepping);
                        }
                        else
                        {
                            tblappointmentservicemapping objtblappointmentservicemapping = new tblappointmentservicemapping();
                            objtblappointmentservicemapping.FK_BranchID = branchID;
                            objtblappointmentservicemapping.FK_AppointmentId = i;
                            foreach (var Checkeditem in chklst_PackageItem.CheckedItems)
                            {
                                var rownum = (Checkeditem as tblservice);
                                int? ServiceId = (int)rownum.ServiceId;
                                objtblappointmentservicemapping.FK_ServiceId = (int)ServiceId;
                                objAppointmentDAL.InsertUpdateappointmentservice(objtblappointmentservicemapping);
                            }
                        }


                        tp = ClientList.GetClientByClientIdBranchId(ClientId, branchID);
                        tblsrvc = objSettingDAL.GetAllServicesById(tap.FK_ServiceId, branchID);
                        if (tp != null & tblsrvc != null)
                        {
                            string msg = "Dear " + tp.ClientName + " , Just to inform you that your appointment for " + (tblsrvc.ServiceName == null ? "" : tblsrvc.ServiceName) + "has been booked on " + objAppointment.AppointmentDate.Value.ToShortDateString() + " at " + objAppointment.AppointmentTime + " . Stay happy & healthy. Thank  You, XXXX ";
                            ut.SendMessage(msg, tp.Mobile);
                        }

                        MessageBox.Show("Appointment added succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        r = i;
                        BindAppointmentGrid();
                        ClearForm();

                    }
                    else
                    {
                        MessageBox.Show("Appointment not available", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return r;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occoured. Please enter correct data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return r;
            }
        }

        #region Events
       
        private void BindCustomerList()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = ClientList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (Mobile: " + item.Mobile + ")");
                UpdateClientId = (int)item.ClientId;
            }

            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        #endregion

        // ....................................Code Checked By Sam on 06092016........................................

        public Booking()
        {
            InitializeComponent();

            string dir = Application.StartupPath + @"\Invoice";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            BindCustomerList();
            BindPackageName();
            bindPackageItemList();
            BindTime();
            BindTherapist();
            Generate();

            BindAppointmentGrid();
            this.toolTip1.SetToolTip(btn_CheckAvail, "Add Client");
        }


        public Booking(int clientid = 0, string clientname = "", string mobno = "")
        {
            InitializeComponent();

            string dir = Application.StartupPath + @"\Invoice";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            BindCustomerList();
            BindPackageName();
            bindPackageItemList();
            BindTime();
            BindTherapist();
            Generate();
            if (clientname != "")
            {
                txtClientName.Text = clientname + " (Mobile: " + mobno + ")";
            }
            BindAppointmentGrid();
            this.toolTip1.SetToolTip(btn_CheckAvail, "Add Client");
        }
        private void BookAppointment_Load(object sender, EventArgs e)
        {

        }

        #region Methods
        public void BindTime()
        {
            List<string> StartTimeSchedule = Appointment.GetAppointmentScheduleTime();
            List<string> EndTimeSchedule = Appointment.GetAppointmentScheduleTime();

            ddlStartTime.DataSource = StartTimeSchedule;
            ddlEndTime.DataSource = EndTimeSchedule;
        }

        private void BindPackageName()
        {
            try
            {
                List<tblpackage> pkgList = new List<tblpackage>();
                pkgList.Insert(0, new tblpackage() { Id = 0, Package_Name = "Select Package" });
                var Packagelist = objAppointmentDAL.GetAllPackage(branchID);
                if (Packagelist != null)
                {
                    foreach (tblpackage s in Packagelist)
                    {
                        pkgList.Add(s);
                    }
                }
                ddl_package.DisplayMember = "Package_Name";
                ddl_package.ValueMember = "ID";
                ddl_package.DataSource = pkgList;
            }
            catch (Exception ex)
            {
            }
        }

        /*-----------------------------Code Added By Sandip Das----------------------*/
        private void BindTherapist()
        {
            List<TherapistEL> ThName = new List<TherapistEL>();
            List<TherapistEL> therapistlist = new List<TherapistEL>();
            //ThName.Insert(0, new TherapistEL() { TherapistId = 0, Name = "Select Therapist" });
            List<string> timelist = new List<string>();
            List<int> idlist = new List<int>();
            string dayname = txtDOB.Value.DayOfWeek.ToString();
            // Here, I am fetching the list of column 'Availability' from table 'Therapist'
            //var query = objAppointmentDAL.Availability(branchID).ToList();
            var query = objAppointmentDAL.Availability(dayname, branchID).ToList();
            TimeSpan SelectedTime = TimeSpan.Parse(ddlStartTime.SelectedItem.ToString().Substring(0, 5));
            string day = txtDOB.Value.DayOfWeek.ToString();
            foreach (var item in query)
            {
                string[] splt = item.Availability.Split(',');
                foreach (var tl in splt)
                {
                    if (tl.Contains(day.Substring(0, 2)))
                    {
                        string[] split = tl.Substring(5).Split('-');
                        string st = split[0].Trim();
                        TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
                        TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));

                        if (SelectedTime >= fdt && SelectedTime < tdt)
                        {
                            ThName.Add(item);
                            //idlist = objAppointmentDAL.GetThpIdFromTime(day).ToList();
                        }
                    }
                }
            }
            List<string> appointmenttiming = new List<string>();
            int cnt = 0;
            foreach (TherapistEL th in ThName)
            {
                cnt = 0;
                List<tblappointment> app = objAppointmentDAL.GetAppointmentdetailByTherapistId(th.TherapistId, Convert.ToDateTime(txtDOB.Value), branchID);
                foreach (tblappointment ap in app)
                {
                    appointmenttiming.Add(ap.AppointmentTime);
                    foreach (string str in appointmenttiming)
                    {
                        string[] aptimingsplit = str.Split('-');
                        TimeSpan apfdt = TimeSpan.Parse(aptimingsplit[0].Substring(0, 5));
                        TimeSpan aptdt = TimeSpan.Parse(aptimingsplit[1].Substring(0, 6));
                        if (SelectedTime >= apfdt && SelectedTime < aptdt)
                        {
                            cnt = 1;
                        }
                    }
                    appointmenttiming.Clear();
                }
                if (cnt != 1)
                {
                    therapistlist.Add(th);

                }
            }
            therapistlist.Insert(0, new TherapistEL() { TherapistId = 0, Name = "Select Therapist" });
            //foreach (var l in idlist)
            //{
            //    var v = objAppointmentDAL.GetTherapistName(l, Convert.ToDateTime(txtDOB.Value), SelectedTime, day).FirstOrDefault();
            //    ThName.Add(v);
            //}
            //foreach (var d in splt)
            //{
            //    if (d.Contains("WE"))
            //    {
            //        string t = d;
            //        //idlist.Add(item.TherapistId);
            //        timelist.Add(t);
            //    }
            //}
            //foreach (var tt in timelist)
            //{
            //    string[] split = tt.Substring(5).Split('-');

            //    TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
            //    TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));

            //    TimeSpan SelectedTime = TimeSpan.Parse(ddlStartTime.SelectedItem.ToString().Substring(0, 5));
            // Here, I am checking, if the 'SelectedTime' lies between 'fdt' and 'tdt' of column 'Availability' from table 'Therapist'
            // foreach (var ii in idlist)
            // {
            //if (SelectedTime >= fdt && SelectedTime < tdt)
            //{   
            //        var v = objAppointmentDAL.GetTherapistName(item.TherapistId, Convert.ToDateTime(txtDOB.Value), SelectedTime).FirstOrDefault();
            //        ThName.Add(v);                        
            //}
            //}
            // }

            //string[] split = item.Availability.Split('-');

            //TimeSpan fdt = TimeSpan.Parse(split[0].Substring(0, 5));
            //TimeSpan tdt = TimeSpan.Parse(split[1].Substring(0, 5));

            //TimeSpan SelectedTime = TimeSpan.Parse(ddlStartTime.SelectedItem.ToString().Substring(0, 5));
            //// Here, I am checking, if the 'SelectedTime' lies between 'fdt' and 'tdt' of column 'Availability' from table 'Therapist'
            //if (SelectedTime >= fdt && SelectedTime < tdt)
            //{
            //    var v = objAppointmentDAL.GetTherapistName(item.TherapistId, Convert.ToDateTime(txtDOB.Value), SelectedTime).FirstOrDefault();
            //    ThName.Add(v);
            //}
            //}            

            therapist_combo.DisplayMember = "Name";
            therapist_combo.ValueMember = "TherapistId";
            therapist_combo.DataSource = therapistlist;
        }
        /*------------------------------------END--------------------------------------*/
        private void bindPackageItemList()
        {
            tblservice Objtblservice = new tblservice();
            {
                chklst_PackageItem.DataSource = ObjSettingDAL.GetAllServicesForGrid(branchID);
                chklst_PackageItem.DisplayMember = "ServiceName";
                chklst_PackageItem.ValueMember = "ServiceId";

            }
        }





        private bool ValidateForm()
        {
            int cnt = chklst_PackageItem.CheckedItems.Count;

            if (txtClientName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Client Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtDOB.Text.Trim() == "")
            {
                MessageBox.Show("Please select an appointment date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ddlStartTime.Text.Trim() == "" || ddlEndTime.Text.Trim() == "")
            {
                MessageBox.Show("Please select an appointment time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ddlStartTime.Text.Trim() == "00:00 AM")
            {
                MessageBox.Show("Please select an appointment time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ddlEndTime.Text.Trim() == "00:00 AM")
            {
                MessageBox.Show("Please select an appointment time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ddl_package.SelectedIndex == 0 && cnt == 0)
            {
                MessageBox.Show("Please select a Package or Service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToString(therapist_combo.SelectedValue) == "0")
            {
                MessageBox.Show("Please select a Therapist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //else if (Convert.ToString(comboBox_payment.SelectedItem) == "")
            //{
            //    MessageBox.Show("Please select payment mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            ///*-----------------Code Added By Sandip Das---------------------------------------*/
            //else if (comboBox_payment.SelectedItem == "CASH")
            //{
            //    if (txt_advance.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter advanced amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (txt_AmountReceived.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter tender amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (Convert.ToDecimal(txt_AmountReceived.Text.Trim()) < Convert.ToDecimal(txt_advance.Text.Trim()))
            //    {
            //        MessageBox.Show("Tender Amount should be more than Advance Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txt_AmountReceived.Text = "";
            //        return false;
            //    }
            //}
            //else if (comboBox_payment.SelectedItem == "CARD")
            //{
            //    if (txt_advance.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter advanced amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (txt_AmountReceived.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Please enter tender amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (Convert.ToDecimal(txt_AmountReceived.Text.Trim()) < Convert.ToDecimal(txt_advance.Text.Trim()))
            //    {
            //        MessageBox.Show("Tender Amount should be more than Advance Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txt_AmountReceived.Text = "";
            //        return false;
            //    }
            //    else if (string.IsNullOrEmpty(txtBankCardNo.Text.Trim()))
            //    {
            //        MessageBox.Show("Please Enter Card No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else if (string.IsNullOrEmpty(txtBankName.Text.Trim()))
            //    {
            //        MessageBox.Show("Please Enter Bank Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //    else { return true; }
            //}

            /*-------------------------------------END---------------------------------------------*/
            else
            {
                return true;
            }
            //return true;
        }

        private void BindAppointmentGrid()
        {
            int bypackage = 1;
            grdClientAccount.AutoGenerateColumns = false;


            var objtblappointmentbypackage = Appointment.GetAllApppointmentNewFortest(branchID, bypackage);
            bypackage = 0;
            var objtblappointmentbyService = Appointment.GetAllApppointmentNewFortest(branchID, bypackage);
            var objtblappointmentbyServicebyPackage = objtblappointmentbypackage.Union(objtblappointmentbyService).ToList();
            grdClientAccount.DataSource = objtblappointmentbyServicebyPackage;

            //...................... Code Commented by Sam 26052016...................
            //var objtblappointmentbypackage = Appointment.GetAllApppointment(branchID, bypackage);
            //bypackage = 0;
            //var objtblappointmentbyService = Appointment.GetAllApppointment(branchID, bypackage);
            //var objtblappointmentbyServicebyPackage = objtblappointmentbypackage.Union(objtblappointmentbyService).ToList();
            //grdPatientAccount.DataSource = objtblappointmentbyServicebyPackage;

            //...................... Code Commented by Sam 26052016...................

        }

        #endregion

        private void button_ChkAvl_Click(object sender, EventArgs e)
        {

        }

        private void ddlEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEndTime.SelectedIndex > 0 && ddlEndTime.SelectedIndex > 0)
                {
                    DateTime start = Convert.ToDateTime(ddlStartTime.SelectedValue.ToString());
                    DateTime end = Convert.ToDateTime(ddlEndTime.SelectedValue.ToString());
                    if (start != null && end != null)
                    {
                        if (start.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                        {
                            //MessageBox.Show("Start Time will be less then End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ddlEndTime.SelectedIndex = 0;
                        }
                        //else if (start.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                        //{
                        //    MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    ddlEndTime.SelectedIndex = 0;
                        //}
                    }
                }
            }
            catch (Exception) { }
        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDOB.Value.Date < DateTime.Today.Date)
                {
                    MessageBox.Show("Date should not be less than todays date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDOB.Value = DateTime.Today.Date;
                }
            }
            catch (Exception) { }
        }

        private void btn_CheckAvail_Click(object sender, EventArgs e)
        {
            ClientPopUp clientPopUp = new ClientPopUp();
            clientPopUp.Show();
        }

        private void ddlStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStartTime.SelectedIndex > 0 && ddlEndTime.SelectedIndex > 0)
                {
                    //DateTime time1 = Convert.ToDateTime(ddlStartTime.SelectedValue.ToString());
                    //startTime = time1;
                    //if (end != null)
                    //{
                    //    if (startTime.TimeOfDay.Ticks > end.TimeOfDay.Ticks)
                    //    {
                    //        //MessageBox.Show("Start Time will be less then End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        //ddlStartTime.SelectedIndex = 0;
                    //    }
                    //    //else if (startTime.TimeOfDay.Ticks == end.TimeOfDay.Ticks)
                    //    //{
                    //    //    MessageBox.Show("Start Time cannot be equal to End Time", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //    ddlStartTime.SelectedIndex = 0;
                    //    //}
                    //}
                }
                therapist_combo.DataSource = null;
                /*-------------------Code Added By Sandip Das on 10-06-2016 -------------------------*/
                //ddlEndTime.SelectedItem = "00:00 AM";
                int? prevTime = 0;


                DateTime stime = Convert.ToDateTime(ddlStartTime.SelectedItem);
                string t = stime.ToString("hh:mm tt");

                prevTime = (txt_timeExpende.Text.Trim() == "" ? 0 : Convert.ToInt32(txt_timeExpende.Text.Trim().Substring(0, 3)));

                double timeAdd = Convert.ToDouble(prevTime);
                DateTime time = stime.AddMinutes(timeAdd);
                string t1 = time.ToString("hh:mm tt");
                DateTime tt = Convert.ToDateTime(t1);

                foreach (string item in ddlEndTime.Items)
                {
                    DateTime? dt = DateTime.Parse(item);
                    string t2 = item;
                    if (dt.Value.Ticks >= tt.Ticks)
                    {
                        //ddlEndTime.SelectedItem = t2;
                        ddlEndTime.SelectedIndex = ddlEndTime.FindString(t2);
                        break;
                    }
                }
                therapist_combo.SelectedIndexChanged -= therapist_combo_SelectedIndexChanged;
                BindTherapist();
                therapist_combo.SelectedIndexChanged += therapist_combo_SelectedIndexChanged;
                //BindTherapist();
                /*---------------------------------------END -------------------------*/
            }
            catch (Exception) { }
        }



        private void therapist_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TherapistEL row = (TherapistEL)therapist_combo.SelectedItem;
            //if (therapist_combo.SelectedIndex != 0)
            //{
            //    if (row != null)
            //    {
            //        string s = row.Name.ToString().Substring(row.Name.LastIndexOf('('));
            //        if (s == "(Not Available)")
            //        {
            //            MessageBox.Show("This Therapist is not available. Please select another !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            therapist_combo.SelectedIndex = 0;
            //        }
            //    }
            //}
        }

        private int? TimeExpendeCalculate(int id)
        {
            int? totalTime = objSettingDAL.GetTotalTime(id, branchID);
            // decimal prevtax = Convert.ToDecimal(txt_TotalTax.Text == "" ? "0" : txt_TotalTax.Text);
            // txt_TotalTax.Text =Convert.ToString(prevtax+Convert.ToDecimal(amount));
            return totalTime;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SaveAppointment();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        private void print_btn_Click(object sender, EventArgs e)
        {
        }

        private void chklst_PackageItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexno = 0;
            int prevTime = 0;
            if (chklst_PackageItem.CheckedItems.Count > 0)
            {
                decimal totalamount = 0;
                decimal cnt = 0;
                foreach (tblservice li1 in chklst_PackageItem.CheckedItems)
                {
                    int? tTime = 0;
                    /*Total Amount Calculation Begin*/
                    string amt = Convert.ToString(li1.ServiceName);
                    int startind = amt.IndexOf(":") + 1;
                    int endind = amt.IndexOf(")", startind);
                    string rs = (amt.Substring(startind, endind - startind)).Trim();
                    totalamount = totalamount + Convert.ToDecimal(rs);

                    /*Total Amount Calculation End*/

                    string sId = Convert.ToString(li1.ServiceId);
                    tTime = TimeExpendeCalculate(Convert.ToInt32(sId));
                    prevTime = prevTime + Convert.ToInt32(tTime);

                    //txt_timeExpende.Text = Convert.ToString(prevTime) + " Minutes";
                    /*----------------------------------END----------------------*/
                    //CalculationAmount();
                }
                if (prevTime > 0)
                {
                    cnt = (Convert.ToDecimal(prevTime) / Convert.ToDecimal(15));
                    indexno = Convert.ToInt32(cnt) + 1;
                }
                txt_totalamt.Text = Convert.ToString(totalamount);
                txt_timeExpende.Text = Convert.ToString(prevTime) + " Minutes";
                ddlEndTime.SelectedIndex = ddlStartTime.SelectedIndex + indexno;
            }
            else
            {
                txt_timeExpende.Text = "";
                txt_totalamt.Text = "";
                prevTime = 0;
            }
        }

        private void ClearForm()
        {
            txtClientName.Text = string.Empty;
            ddl_package.SelectedIndex = 0;
            ddlStartTime.SelectedIndex = 0;
            ddlEndTime.SelectedIndex = 0;

            if (chklst_PackageItem.Enabled == false)
            {
                chklst_PackageItem.Enabled = true;
            }
            while (chklst_PackageItem.CheckedIndices.Count > 0)
            {
                chklst_PackageItem.SetItemChecked(chklst_PackageItem.CheckedIndices[0], false);
            }
            //txtCouponID.Text = string.Empty;
            //txtIsValid.Text = string.Empty;
            //totalAmount.Text = string.Empty;
            //txtServiceCharge.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            //txtDOB.Text = DateTime.Today.ToShortDateString();
            //txt_advance.Text = string.Empty; ;
            //txt_AmountReceived.Text = string.Empty;
            //txt_GrossAmount.Text = string.Empty;
            //txt_timeExpende.Text = string.Empty;

            //txt_CouponDscnt.Text = string.Empty;
            //txt_TotalTax.Text = string.Empty;
            //txt_due.Text = string.Empty;
            //comboBox_payment.SelectedIndex = 0;
            //therapist_combo.SelectedIndex = 0;
            //txt_manualDiscountPrcntg.Text = string.Empty;
        }

        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }






        // ....................................Code Above Checked By Sam on 06092016........................................








        //............................trash code by Sam on 06092016............................
        //private void print_btn_Click(object sender, EventArgs e)
        //{
        //    int ret = SaveAppointment();
        //    if (ret > 0)
        //    {
        //        Document document = new Document();
        //        DateTime today = DateTime.Today;


        //        tblappointment t = new tblappointment();
        //        tblappointmentsetting tas = new tblappointmentsetting();

        //        //tas = objSettingDAL.GetLogo(1, branchID);
        //        t = objAppointmentDAL.GetAllApppointmentByID(ret, branchID);
        //        tblclient tp = new tblclient();

        //        tp = ClientList.GetClientByClientIdBranchId(Convert.ToInt32(t.FK_ClientId), branchID);
        //        int age = today.Year - Convert.ToDateTime(tp.DateOfBirth).Year;

        //        string pagesize = "A4";
        //        bool? isPredefined = false;


        //        var ValPrint = ObjSettingDAL.PrintDetails();
        //        if (ValPrint != null)
        //        {
        //            pagesize = ValPrint.PageSize;
        //            isPredefined = ValPrint.IsLetterHead;
        //        }
        //        float margintop = 0;
        //        if (isPredefined == true)
        //        {
        //            margintop = 120;
        //        }
        //        else
        //        {
        //            margintop = 0;
        //        }



        //        switch (pagesize)
        //        {
        //            case "A1":
        //                document = new Document(PageSize.A1, 1, 10, margintop, 10);
        //                break;
        //            case "A2":
        //                document = new Document(PageSize.A2, 1, 10, margintop, 10);
        //                break;
        //            case "A3":
        //                document = new Document(PageSize.A3, 1, 10, margintop, 10);
        //                break;
        //            case "A4":
        //                document = new Document(PageSize.A4, 1, 10, margintop, 10);
        //                break;
        //            case "A5":
        //                document = new Document(PageSize.A5, 1, 10, margintop, 10);
        //                break;
        //            case "B1":
        //                document = new Document(PageSize.B1, 1, 10, margintop, 10);
        //                break;
        //            case "B2":
        //                document = new Document(PageSize.B2, 1, 10, margintop, 10);
        //                break;
        //            case "B3":
        //                document = new Document(PageSize.B3, 1, 10, margintop, 10);
        //                break;
        //            case "B4":
        //                document = new Document(PageSize.B4, 1, 10, margintop, 10);
        //                break;
        //            case "B5":
        //                document = new Document(PageSize.B5, 1, 10, margintop, 10);
        //                break;
        //            default:
        //                document = new Document(PageSize.A4, 1, 10, margintop, 10);
        //                break;
        //        }

        //        PdfWriter.GetInstance(document, new FileStream(Application.StartupPath + "/Invoice/" + tp.ClientName + ".pdf", FileMode.Create));
        //        document.Open();
        //        Paragraph pblank = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p1 = new Paragraph("Appointment No.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p3 = new Paragraph("Client Name", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p4 = new Paragraph("Ref.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p5 = new Paragraph("Visit Date", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p6 = new Paragraph("Age/Sex", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph p7 = new Paragraph("Client Mob.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        PdfPTable table = new PdfPTable(7);
        //        float[] width = new float[] { 5f, 2f, 8f, 10f, 5f, 2f, 8f };
        //        table.SetWidths(width);
        //        table.WidthPercentage = 100;
        //        table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

        //        table.AddCell(p1);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(Convert.ToString(ret), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        table.AddCell(" ");
        //        table.AddCell(p5);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(Convert.ToString(tp.AddedDate.Value.ToShortDateString()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        table.AddCell(p3);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(tp.ClientName.ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        table.AddCell(" ");
        //        table.AddCell(p6);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(Convert.ToString(age) + "/" + tp.Sex == null ? "" : tp.Sex.ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        table.AddCell(p4);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(Convert.ToString(tp.ReferralSource == null ? "" : tp.ReferralSource.ToUpper()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        table.AddCell(" ");
        //        table.AddCell(p7);
        //        table.AddCell(p2);
        //        table.AddCell(new Paragraph(Convert.ToString(tp.Mobile == null ? "" : tp.Mobile), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        PdfPTable tabheader = new PdfPTable(2);
        //        float[] widthheader = new float[] { 20f, 80f };
        //        tabheader.SetWidths(widthheader);
        //        tabheader.WidthPercentage = 100;
        //        string img = "";
        //        string companyname = "";
        //        string companyAddress = "";
        //        string companyEmail = "";
        //        string companyPhone = "";

        //        PdfPCell c1 = new PdfPCell();
        //        PdfPCell c2 = new PdfPCell();

        //        if (isPredefined == false)
        //        {
        //            var Val = dashboard_dal.CompanyDetails();
        //            if (Val != null)
        //            {
        //                img = Application.StartupPath + @"\Logo\" + Val.LogoPath;
        //                if (!File.Exists(img))
        //                {
        //                    img = Application.StartupPath + @"\Images\Logo.jpg";
        //                }
        //                companyname = Val.CompanyName == null ? "" : Val.CompanyName;
        //                companyAddress = Val.Address == null ? "" : Val.Address;
        //                companyEmail = Val.Email == null ? "" : Val.Email;
        //                companyPhone = Val.Phone == null ? "" : Val.Phone;
        //            }


        //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(img);
        //            image.ScaleAbsolute(60f, 60f);
        //            c1.HorizontalAlignment = Element.ALIGN_LEFT;
        //            c1.AddElement(image);
        //            c2.HorizontalAlignment = Element.ALIGN_LEFT;
        //            c2.AddElement(new Paragraph(companyname, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
        //            c2.AddElement(new Paragraph(companyAddress + ", Phone-" + companyPhone + ",Email-" + companyEmail, FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //            c2.AddElement(new Paragraph("BILL/REPORT COLLECTION SLIP(RCS)", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
        //            tabheader.AddCell(c1);
        //            tabheader.AddCell(c2);
        //        }
        //        Paragraph xblank = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x1 = new Paragraph("Total Amount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x3 = new Paragraph("Other Charges", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x4 = new Paragraph("Less", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x5 = new Paragraph("Final Amount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x6 = new Paragraph("Amount Received", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x7 = new Paragraph("Balance", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        /**/
        //        Paragraph x8 = new Paragraph("Total Tax(Rs)", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        Paragraph x9 = new Paragraph("Discount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
        //        /**/
        //        PdfPTable xtable = new PdfPTable(7);
        //        float[] width_x = new float[] { 5f, 2f, 8f, 10f, 5f, 2f, 8f };
        //        xtable.SetWidths(width_x);
        //        xtable.WidthPercentage = 100;
        //        xtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

        //        xtable.AddCell(x1);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.Total), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        xtable.AddCell(" ");
        //        xtable.AddCell(x5);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.GrossAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        /*---------------Code Added By Sandip Das---------------------*/
        //        xtable.AddCell(x9);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        xtable.AddCell(" ");
        //        xtable.AddCell(x8);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.TotalTax), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        xtable.AddCell(x3);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph("0.00", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        xtable.AddCell(" ");
        //        xtable.AddCell(x4);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

        //        xtable.AddCell(x6);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.ReceivedAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        xtable.AddCell(" ");
        //        xtable.AddCell(x7);
        //        xtable.AddCell(x2);
        //        xtable.AddCell(new Paragraph(Convert.ToString(t.BalanceAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
        //        /*---------------Code Added By Sandip Das---------------------*/


        //        document.Add(tabheader);
        //        document.Add(pblank);
        //        document.Add(table);
        //        document.Add(xblank);
        //        document.Add(xtable);
        //        document.Add(xblank);
        //        document.Close();

        //        if (File.Exists(Application.StartupPath + "/Invoice/" + tp.ClientName + ".pdf"))
        //        {
        //            Process p = new Process();
        //            p.StartInfo.FileName = Application.StartupPath + "/Invoice/" + tp.ClientName + ".pdf";
        //            p.Start();
        //        }
        //        else
        //        {
        //            MessageBox.Show("File does not exist in the folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        //private void txt_advance_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar))
        //    {
        //        if (Regex.IsMatch(txt_advance.Text, "\\D+"))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    else
        //    {
        //        e.Handled = e.KeyChar != (char)Keys.Back;
        //    }
        //}

        //private void txt_AmountReceived_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar))
        //    {
        //        if (Regex.IsMatch(txt_AmountReceived.Text, "\\D+"))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    else
        //    {
        //        e.Handled = e.KeyChar != (char)Keys.Back;
        //    }
        //}
        //private void txtCouponID_TextChanged(object sender, EventArgs e)
        //{
        //    /////////////////////////////////

        //    AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

        //    List<tblcoupanmaster> objcoupanmaster = objAppointmentDAL.GetAllCouponNameByName(txtCouponID.Text.Trim(), branchID);


        //    foreach (var item in objcoupanmaster)
        //    {
        //        namesCollection.Add(item.Coupon_Id);
        //    }
        //    txtCouponID.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    txtCouponID.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtCouponID.AutoCompleteCustomSource = namesCollection;

        //    if (!string.IsNullOrEmpty(txtCouponID.Text.Trim()))
        //    {
        //        ///////////////////////////////////
        //        tblcoupanmaster objtblcoupanmaster = objAppointmentDAL.GetCouponValidity(txtCouponID.Text.Trim(), branchID);
        //        if (objtblcoupanmaster != null)
        //        {
        //            DateTime validDate = objtblcoupanmaster.Coupan_SDateVld.Value.AddDays(Convert.ToDouble(objtblcoupanmaster.Coupan_Validity));
        //            DateTime curdt = System.DateTime.Now;
        //            var days = (validDate - curdt).Days;
        //            if ((int)days > 0)
        //            {

        //                txt_CouponDscnt.Text = Convert.ToString(objtblcoupanmaster.Coupon_Amt);
        //                string discpuntpercentage = Convert.ToString(((objtblcoupanmaster.Coupon_Amt) * 100) / Convert.ToDecimal(txtServiceCharge.Text.Trim()));

        //                txtDiscount.Text = discpuntpercentage.Substring(0, discpuntpercentage.IndexOf('.') + 3);

        //                txtIsValid.Text = "YES";
        //                if (txtServiceCharge.Text.Trim() != "")
        //                {
        //                    decimal? servicecharge = Convert.ToDecimal(txtServiceCharge.Text.Trim());
        //                    decimal? totalamt = servicecharge - objtblcoupanmaster.Coupon_Amt;

        //                    string discountpercentage = Convert.ToString(txt_manualDiscountPrcntg.Text == "" ? "0" : txt_manualDiscountPrcntg.Text);
        //                    string discountAmount = Convert.ToString((totalamt * Convert.ToDecimal(discountpercentage)) / 100);
        //                    totalAmount.Text = Convert.ToString(totalamt - Convert.ToDecimal(discountAmount));         

        //                    CalculationAmount();
        //                }


        //            }
        //            else
        //            {
        //                txtIsValid.Text = "NO";
        //                txtDiscount.Text = string.Empty;
        //            }

        //        }
        //        else if (txtDiscount.Text.Trim() != "")
        //        {
        //            txtIsValid.Text = "NO";
        //            txtDiscount.Text = string.Empty;
        //        }
        //        else
        //        {
        //            txtIsValid.Text = string.Empty;
        //            txtDiscount.Text = string.Empty;
        //        }
        //    }
        //    else
        //    {
        //        txtIsValid.Text = "";
        //        txtDiscount.Text = "";
        //        txt_CouponDscnt.Text = "";
        //        CalculationAmount();
        //    }


        //} 

        //private void chklst_PackageItem_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetTotalAmt();
        //}

        //private void GetTotalAmt()
        //{
        //    string[] total_items = new string[50];
        //    int it = 0;
        //    decimal totalamount = 0;
        //    decimal prevtax = 0;
        //    int? prevTime = 0;
        //    txt_TotalTax.Text = "";
        //    if (chklst_PackageItem.CheckedItems.Count > 0)
        //    {

        //        foreach (tblservice li1 in chklst_PackageItem.CheckedItems)
        //        {
        //            /*Total Amount Calculation Begin*/
        //            string amt = Convert.ToString(li1.ServiceName);
        //            int startind = amt.IndexOf(":") + 1;
        //            int endind = amt.IndexOf(")", startind);
        //            string rs = (amt.Substring(startind, endind - startind)).Trim();
        //            totalamount = totalamount + Convert.ToDecimal(rs);
        //            txtServiceCharge.Text = Convert.ToString(totalamount);
        //            /*Total Amount Calculation End*/

        //            /*Total Tax Calculation Begin*/
        //            string sId = Convert.ToString(li1.ServiceId);
        //            string tax_percentage = (TaxCalculate(Convert.ToInt32(sId)) == "" ? "0" : TaxCalculate(Convert.ToInt32(sId)));
        //            prevtax = prevtax + Convert.ToDecimal(txt_TotalTax.Text == "" ? "0" : txt_TotalTax.Text); 
        //            txt_TotalTax.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(totalamount) * Convert.ToDecimal(tax_percentage)) / 100), 2) + prevtax);
        //            /*Total Tax Calculation End*/

        //            int? tTime = TimeExpendeCalculate(Convert.ToInt32(sId));
        //            prevTime = prevTime + tTime;

        //            txt_timeExpende.Text = Convert.ToString(prevTime) + " Minutes";

        //            /*---------------Code Added By Sandip Das on 09-06-2016----------------------*/
        //            DateTime stime = Convert.ToDateTime(ddlStartTime.SelectedItem);
        //            string t = stime.ToString("hh:mm tt");
        //            double timeAdd = Convert.ToDouble(prevTime);
        //            DateTime time = stime.AddMinutes(timeAdd);
        //            string t1 = time.ToString("hh:mm tt");
        //            DateTime tt = Convert.ToDateTime(t1);

        //            foreach (string item in ddlEndTime.Items)
        //            {
        //                DateTime? dt = DateTime.Parse(item);
        //                string t2 = item;
        //                if (dt.Value.Ticks >= tt.Ticks)
        //                {
        //                    //ddlEndTime.SelectedItem = t2;
        //                    ddlEndTime.SelectedIndex = ddlEndTime.FindString(t2);
        //                    break;
        //                }
        //            }
        //            /*----------------------------------END----------------------*/
        //            CalculationAmount();
        //        }
        //    }
        //    else
        //    {
        //        txtServiceCharge.Text = string.Empty;
        //        totalAmount.Text = string.Empty;
        //        txt_GrossAmount.Text = string.Empty;
        //        txt_timeExpende.Text = string.Empty;
        //        /*--------------------Code Added By Sandip Das ------------------------*/
        //        //ddlStartTime.SelectedItem = "00:00 AM";
        //        ddlEndTime.SelectedItem = "00:00 AM";
        //        txt_manualDiscountPrcntg.Text = "";
        //        /*--------------------------END ------------------------*/
        //    }
        //}

        //private string TaxCalculate(int id)
        //{
        //    string amount = objSettingDAL.GetTaxToatlAmount(id, branchID); 
        //    return amount;
        //}

        //private void txt_manualDiscountPrcntg_TextChanged(object sender, EventArgs e)
        //{
        //    // CalculationAmount();

        //    /*-------------------Code Added By Sandip Das ----------------------------*/
        //    if (!string.IsNullOrEmpty(txt_manualDiscountPrcntg.Text.Trim()))
        //    {
        //        if (Convert.ToDecimal(txt_manualDiscountPrcntg.Text.Trim()) > 100)
        //        {
        //            txt_manualDiscountPrcntg.Text = "0";
        //        }
        //        else
        //        {
        //            CalculationAmount();
        //        }
        //    }
        //    else { txt_manualDiscountPrcntg.Text = "0"; }
        //    /*--------------------------END ----------------------------*/
        //}

        //private void CalculationAmount()
        //{
        //    string SR_Charge = txtServiceCharge.Text == "" ? "0" : txtServiceCharge.Text;
        //    string Coupon_Discount = Convert.ToString(txt_CouponDscnt.Text == "" ? "0" : txt_CouponDscnt.Text);
        //    string MTotal = Convert.ToString(Convert.ToDecimal(SR_Charge) - Convert.ToDecimal(Coupon_Discount));
        //    string discpuntpercentage = Convert.ToString(txt_manualDiscountPrcntg.Text == "" ? "0" : txt_manualDiscountPrcntg.Text);
        //    string Manual_Discount = Convert.ToString((Convert.ToDecimal(MTotal) * Convert.ToDecimal(discpuntpercentage)) / 100);
        //    totalAmount.Text = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(SR_Charge) - Convert.ToDecimal(Coupon_Discount) - Convert.ToDecimal(Manual_Discount)), 2).ToString());

        //    string taxAmount = (txt_TotalTax.Text == "" ? "0" : txt_TotalTax.Text);
        //    string netTotal = (totalAmount.Text == "" ? "0" : totalAmount.Text);
        //    txt_GrossAmount.Text = Convert.ToString(Math.Round((Convert.ToDecimal(netTotal) + Convert.ToDecimal(taxAmount)), 2));

        //}

        //private void txt_advance_TextChanged(object sender, EventArgs e)
        //{
        //    if (txt_advance.Text.Trim() != "")
        //    {
        //        decimal value;
        //        decimal grossvalue = Convert.ToDecimal(txt_GrossAmount.Text == "" ? "0" : txt_GrossAmount.Text);
        //        if (decimal.TryParse(txt_advance.Text, out value))
        //        {
        //            if (value > grossvalue)
        //                txt_advance.Text = "0";
        //        }
        //        txt_due.Text = Convert.ToString(grossvalue - Convert.ToDecimal(txt_advance.Text));
        //    }
        //    /*------------------Code Added By Sandip Das -----------------------*/
        //    else
        //    {
        //        txt_AmountReceived.Text = "";
        //        txt_ReturnAmount.Text = "";
        //        txt_advance.Text = "0";
        //    }
        //    /*----------------------------------END -----------------------*/
        //}

        //private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (char.IsNumber(e.KeyChar))
        //    {
        //        if (Regex.IsMatch(txtDiscount.Text, "\\D+"))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //    else
        //    {
        //        e.Handled = e.KeyChar != (char)Keys.Back;
        //    }


        //}

        //private void txtDiscount_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtDiscount.Text != "")
        //    {
        //        totalAmount.Text = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(txtServiceCharge.Text) - Convert.ToDecimal(txtDiscount.Text)), 2).ToString());
        //    }
        //}


        //private void txt_advance_KeyPress_1(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = Common.VadidateNumericCharecter(sender, e);
        //}

        //private void txt_manualDiscountPrcntg_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = Common.VadidateNumericCharecter(sender, e);
        //}

        //DateTime start = Convert.ToDateTime(null);
        //DateTime end = Convert.ToDateTime(null);
        //DateTime startTime = default(DateTime);


        //private void txt_AmountReceived_TextChanged(object sender, EventArgs e)
        //        {
        //            if (txt_AmountReceived.Text.Trim() != "")
        //            {
        //                txt_ReturnAmount.Text = Convert.ToString(Math.Abs(Convert.ToDecimal(txt_AmountReceived.Text == "" ? "0" : txt_AmountReceived.Text) - Convert.ToDecimal(txt_advance.Text == "" ? "0" : txt_advance.Text)).ToString());
        //            }
        //            else
        //            {
        //                txt_ReturnAmount.Text = string.Empty;
        //            }
        //        }

        //        private void txtBankCardNo_KeyPress(object sender, KeyPressEventArgs e)
        //        {
        //            e.Handled = Common.VadidateNumericCharecter(sender, e);
        //        }


        //private void comboBox_payment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox_payment.SelectedItem == "CASH")
        //    {
        //        txt_advance.ReadOnly = false;
        //        txt_due.ReadOnly = true;
        //        txt_AmountReceived.ReadOnly = false;
        //        txt_ReturnAmount.ReadOnly = true;
        //        lblCardNo.Visible = false; lblBankName.Visible = false;
        //        txtBankCardNo.Visible = false; txtBankName.Visible = false;
        //    }
        //    else if (comboBox_payment.SelectedItem == "CARD")
        //    {
        //        txt_advance.ReadOnly = false;
        //        txt_due.ReadOnly = true;
        //        txt_AmountReceived.ReadOnly = false;
        //        txt_ReturnAmount.ReadOnly = true;
        //        lblCardNo.Visible = true; lblBankName.Visible = true;
        //        txtBankCardNo.Visible = true; txtBankName.Visible = true;
        //    }
        //    else if (comboBox_payment.SelectedItem == "CREDIT")
        //    {
        //        txt_advance.ReadOnly = true;
        //        txt_due.ReadOnly = true;
        //        txt_AmountReceived.ReadOnly = true;
        //        txt_ReturnAmount.ReadOnly = true;
        //        /*----------------------------Code Adeded By Sandip Das--------------------*/
        //        lblCardNo.Visible = false; lblBankName.Visible = false;
        //        txtBankCardNo.Visible = false; txtBankName.Visible = false;
        //        txtBankCardNo.Text = ""; txtBankName.Text = "";
        //        txt_AmountReceived.Text = "";
        //        txt_ReturnAmount.Text = "";
        //        /*----------------------------End Code Adeded By Sandip Das---------------*/

        //        txt_advance.Text = "0";
        //        txt_due.Text = Convert.ToString(Convert.ToDecimal(txt_GrossAmount.Text == "" ? "0" : txt_GrossAmount.Text) - Convert.ToDecimal(txt_advance.Text));
        //    }
        //    else
        //    {
        //        txt_advance.ReadOnly = false;
        //        txt_due.ReadOnly = true;
        //        txt_AmountReceived.ReadOnly = false;
        //        txt_ReturnAmount.ReadOnly = true;
        //    }
        //}
    }
}
