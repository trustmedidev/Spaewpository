using DataAccessLayer;
using DataAccessLayer.Repository;
using SPAPracticeManagement.CustomControls.Appointment;
using EntityLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Appointments
{
    public partial class AppointmentList : Dashboard
    {

        #region initialized Class
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        AppointmentListDAL objAppointmentListDAL = new AppointmentListDAL();
        DashboardDAL dashboard_dal = new DashboardDAL();
        AppointmentDAL ObjAppointmentDAL = new AppointmentDAL();
        public AppointmentDAL AppointmentsList
        {
            get { return new AppointmentDAL(); }
        } 
        public ClientDAL clientlist
        {
            get { return new ClientDAL(); }
        }
        SettingDAL objSettingDAL = new SettingDAL();

        #endregion initialized Class
        public AppointmentList()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            label7.Visible = false;
            ddlServiceType.Visible = false;
            BindServiceType();
            //BindAccountGrid();
            BindAppointmentGrid();
            BindCustomerList();
        }

        private void BindCustomerList()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = clientlist.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (Mobile: " + item.Mobile + ")");
            }

            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        private void BindServiceType()
        {
            try
            {
                ddlServiceType.DataSource = null;
                ddlServiceType.DisplayMember = "ServiceName"; // Column Name
                ddlServiceType.ValueMember = "ServiceId";
                ddlServiceType.DataSource = objSettingDAL.GetAllServices(branchID);
            }
            catch (Exception ex)
            {
            }
        }


        private void BindAppointmentGrid()
        {
            //DateTime? fdt = null;
            //DateTime? tdt = null;

            //if (txtFromDate.Checked)
            //{
            //    fdt = txtFromDate.Value;
            //}
            //if (txtToDate.Checked)
            //{
            //    tdt = txtToDate.Value;
            //}
            //int byselection = 0;
            //if (radio_all.Checked == true)
            //{
            //    byselection = 0;
            //}
            //else if (radio_service.Checked == true)
            //{
            //    byselection = 1;
            //}
            //else if (radio_package.Checked == true)
            //{
            //    byselection = 2;
            //}
            
             

            //string clientname = "";
            //if (txtClientName.Text == "")
            //{
            //    clientname = null;
            //}
            //else
            //{
            //    clientname = txtClientName.Text.Substring(0, txtClientName.Text.IndexOf("(")).Trim();
            //}

            //int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);
            //grdClientAccount.AutoGenerateColumns = false;
            
            //grdClientAccount.DataSource = objAppointmentListDAL.GetClientListBySearchCriteria(clientname, Convert.ToInt32(ddlServiceType.SelectedValue), fdt, tdt, branchID, byselection).ToList();




            DateTime? fdt = null;
            DateTime? tdt = null;
            int? PackageTypeId = null;
            int? ServiceTypeId = null;

            int ddlvalue = Convert.ToInt32(ddlServiceType.SelectedValue);

            if (txtFromDate.Checked)
            {
                fdt = txtFromDate.Value;
            }
            if (txtToDate.Checked)
            {
                tdt = txtToDate.Value;
            }
            
            if (radio_service.Checked == true)
            {
                ServiceTypeId = ddlvalue;
            }
            else if (radio_package.Checked == true)
            {
                PackageTypeId = ddlvalue;
            }



            string clientname = "";
            if (txtClientName.Text == "")
            {
                clientname = null;
            }
            else
            {
                try
                {
                    clientname = txtClientName.Text.Substring(0, txtClientName.Text.IndexOf("(")).Trim();
                }
                catch
                {
                    clientname = null;
                }
            }

            
            grdClientAccount.AutoGenerateColumns = false;

            grdClientAccount.DataSource = objAppointmentListDAL.GetListBySearchCriteria(clientname, ServiceTypeId, PackageTypeId, fdt, tdt, branchID);


        }

        // ..................Code added By Sandip on 19042016............................
        private void BindPackageName()
        {
            try
            {
                 
                ddlServiceType.DataSource = null;
                ddlServiceType.DisplayMember = "Package_Name";
                ddlServiceType.ValueMember = "ID";
                ddlServiceType.DataSource = ObjAppointmentDAL.GetAllPackage(branchID);
            }
            catch (Exception ex)
            {
            }
        }  
        private void radio_all_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_all.Checked == true)
            {
                label7.Visible = false;
                ddlServiceType.Visible = false;
                BindAppointmentGrid();
            }
        } 
        private void radio_service_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_service.Checked == true)
            {
                label7.Visible = true;
                ddlServiceType.Visible = true;
                label7.Text = "Service Type :";
                BindServiceType();
                BindAppointmentGrid();
            }
        }
        private void radio_package_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_package.Checked == true)
            {
                label7.Visible = true;
                ddlServiceType.Visible = true;
                label7.Text = "Package Type";
                BindPackageName();
                BindAppointmentGrid();
            }

        }
        // ..................Code added By Sandip on 19042016............................

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            Utility ut = new Utility();
            tblappointment tap = new tblappointment();
            //string msg = "Appointment Cancel";
            string msg = "";
            string mobile = "";
            string AppId = "";
            string companyname = "";
            string service = "";

            List<DataGridViewRow> selectedRows = (from row in grdClientAccount.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["Select"].Value) == true
                                                  select row).ToList();
            if (selectedRows.Count > 0)
            {
                var Val = dashboard_dal.CompanyDetails();
                if (Val != null)
                {
                    companyname = Val.CompanyName;
                }
                foreach (DataGridViewRow row in selectedRows)
                {
                    //row.Cells["CustomerId"].Value)
                    if (selectedRows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(row.Cells["Mobile"].Value)))
                        {
                            //mobile += row.Cells["Mobile"].Value + ",";
                            mobile = row.Cells["Mobile"].Value.ToString();
                            AppId += row.Cells["AppointmentId"].Value + ",";

                            tap = AppointmentsList.GetAllApppointmentByID(Convert.ToInt32(row.Cells["AppointmentId"].Value), branchID);
                            //service = objAppointmentListDAL.FetchServiceById(Convert.ToInt32(row.Cells["AppointmentId"].Value), branchID);

                            //msg += "Dear " + tap.tblclient.ClientName;
                            //msg += "Just to inform you that your appointment for"+ service + "has been cancelled on " + tap.AppointmentDate.Value.ToShortDateString() + "due to unavailability.";
                            //msg += "Stay happy & healthy.";
                            //msg += "Thank  You,";
                            //msg += companyname;

                            //ut.SendMessage(msg, mobile);
                        }
                        else
                        {
                            AppId += row.Cells["AppointmentId"].Value + ",";
                        }
                    }
                }
                // AppointmentsList.

                AppId = AppId.Substring(0, AppId.Length - 1);
                AppointmentsList.CancelAppointment(AppId, false, branchID);

                MessageBox.Show("Appointment's cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindAppointmentGrid();
            }
            else
            {
                MessageBox.Show("Please select an appointment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindAppointmentGrid();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindAppointmentGrid();
        }

        private void clearData()
        {
            radio_all.Checked = true;
            txtFromDate.Value = DateTime.Now;
            txtToDate.Value = DateTime.Now;
            txtFromDate.Checked = false;
            txtToDate.Checked = false;
            label7.Visible = false;
            ddlServiceType.Visible = false;
            ddlServiceType.SelectedIndex = 0;
            txtClientName.Text = "";

           
        } 
        private void grdClientAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (e.ColumnIndex == 11 && e.RowIndex >= 0)
            {            

                int appointmentId = default(int);
                int.TryParse(Convert.ToString(grdClientAccount.Rows[e.RowIndex].Cells[3].Value), out appointmentId);

                PrintInvoice(appointmentId);
            }
        } 
        private void PrintInvoice(int AppId)
        {
            Document document = new Document(PageSize.A4,10,10,120,10);
            tblappointment t = new tblappointment();
            tblclient tp = new tblclient();
            
            tblappointmentsetting tas = new tblappointmentsetting();
            try
            {

                DateTime today = DateTime.Today;
                //tas = objSettingDAL.GetLogo(1,branchID);
                t = AppointmentsList.GetAllApppointmentByID(AppId, branchID);
                tp = clientlist.GetClientByClientId(Convert.ToInt32(t.FK_ClientId), branchID);                
            
                int age = today.Year - Convert.ToDateTime(tp.DateOfBirth).Year;
                string age_sex = age + "/" + (tp.Sex == null ? "" : tp.Sex.ToUpper());

               // document.SetPageSize(PageSize.A4);

                string pagesize = "A4";
                bool? isPredefined = false;

                var ValPrint = objSettingDAL.PrintDetails();
                if (ValPrint != null)
                {
                    pagesize = ValPrint.PageSize;
                    isPredefined = ValPrint.IsLetterHead;
                }
                float margintop = 0;
                if (isPredefined == true)
                {
                    margintop = 120;
                }
                else
                {
                    margintop = 0;
                }



                switch (pagesize)
                {
                    case "A1":
                        document = new Document(PageSize.A1, 1, 10, margintop, 10);
                        break;
                    case "A2":
                        document = new Document(PageSize.A2, 1, 10, margintop, 10);
                        break;
                    case "A3":
                        document = new Document(PageSize.A3, 1, 10, margintop, 10);
                        break;
                    case "A4":
                        document = new Document(PageSize.A4, 1, 10, margintop, 10);
                        break;
                    case "A5":
                        document = new Document(PageSize.A5, 1, 10, margintop, 10);
                        break;
                    case "B1":
                        document = new Document(PageSize.B1, 1, 10, margintop, 10);
                        break;
                    case "B2":
                        document = new Document(PageSize.B2, 1, 10, margintop, 10);
                        break;
                    case "B3":
                        document = new Document(PageSize.B3, 1, 10, margintop, 10);
                        break;
                    case "B4":
                        document = new Document(PageSize.B4, 1, 10, margintop, 10);
                        break;
                    case "B5":
                        document = new Document(PageSize.B5, 1, 10, margintop, 10);
                        break;
                    default:
                        document = new Document(PageSize.A4, 1, 10, margintop, 10);
                        break;
                }

                PdfWriter.GetInstance(document, new FileStream(Application.StartupPath + "/Invoice/" + t.tblclient.ClientName + ".pdf", FileMode.Create));
                document.Open();
               
                Paragraph pblank = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p1 = new Paragraph("Appointment No.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p3 = new Paragraph("Client Name", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p4 = new Paragraph("Any Ref.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p5 = new Paragraph("Visit Date", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p6 = new Paragraph("Age/Sex", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph p7 = new Paragraph("Client Mob.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                PdfPTable table = new PdfPTable(7);
                float[] width = new float[] { 5f, 2f, 8f, 10f, 5f, 2f, 8f };
                table.SetWidths(width);
                table.WidthPercentage = 100;
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                table.AddCell(p1);
                table.AddCell(p2);
                table.AddCell(new Paragraph(Convert.ToString(AppId), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                table.AddCell(" ");
                table.AddCell(p5);
                table.AddCell(p2);
                table.AddCell(new Paragraph(Convert.ToString(tp.AddedDate.Value.ToShortDateString()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                table.AddCell(p3);
                table.AddCell(p2);
                table.AddCell(new Paragraph(t.tblclient.ClientName.ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                table.AddCell(" ");
                table.AddCell(p6);
                table.AddCell(p2);
                table.AddCell(new Paragraph(age_sex, FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                table.AddCell(p4);
                table.AddCell(p2);
                table.AddCell(new Paragraph(Convert.ToString(tp.ReferralSource == null ? "" : tp.ReferralSource.ToUpper()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                table.AddCell(" ");
                table.AddCell(p7);
                table.AddCell(p2);
                table.AddCell(new Paragraph(Convert.ToString(tp.Mobile == null ? "" : tp.Mobile), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                PdfPTable tabheader = new PdfPTable(2);
                float[] widthheader = new float[] { 20f, 80f };
                tabheader.SetWidths(widthheader);
                tabheader.WidthPercentage = 100;
                string img = "";
                string companyname = "";
                string companyAddress = "";
                string companyEmail = "";
                string companyPhone = "";

                PdfPCell c1 = new PdfPCell();
                PdfPCell c2 = new PdfPCell();

                if (isPredefined == false)
                {
                    var Val = dashboard_dal.CompanyDetails();
                    if (Val != null)
                    {
                        img = Application.StartupPath + @"\Logo\" + Val.LogoPath;
                        if (!File.Exists(img))
                        {
                            img = Application.StartupPath + @"\Images\Logo.jpg";
                        }
                        companyname = Val.CompanyName == null ? "" : Val.CompanyName;
                        companyAddress = Val.Address == null ? "" : Val.Address;
                        companyEmail = Val.Email == null ? "" : Val.Email;
                        companyPhone = Val.Phone == null ? "" : Val.Phone;
                    }


                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(img);
                    image.ScaleAbsolute(60f, 60f);
                    c1.HorizontalAlignment = Element.ALIGN_LEFT;
                    c1.AddElement(image);
                    c2.HorizontalAlignment = Element.ALIGN_LEFT;
                    c2.AddElement(new Paragraph(companyname, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                    c2.AddElement(new Paragraph(companyAddress + ", Phone-" + companyPhone + ",Email-" + companyEmail, FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                    c2.AddElement(new Paragraph("BILL/REPORT COLLECTION SLIP(RCS)", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                    tabheader.AddCell(c1);
                    tabheader.AddCell(c2);
                }

                //PdfPTable tabheader = new PdfPTable(2);
                //float[] widthheader = new float[] { 20f,80f };
                //tabheader.SetWidths(widthheader);
                //tabheader.WidthPercentage = 100;
                // Rev By Sandip Das

                //string img = "";
                //if (tas == null)
                //{
                //   img=Application.StartupPath + @"\Images\Logo.jpg";
             
                //}
                //else
                //{
                //    if (tas.LogoPath == null)
                //    {
                //        img = Application.StartupPath + @"\Images\Logo.jpg";
                //    }
                //    else
                //    {
                //        if (File.Exists(Application.StartupPath + @"\Logo\" + tas.LogoPath))
                //        {
                //            img = Application.StartupPath + @"\Logo\" + tas.LogoPath;
                //        }
                //        else
                //        {
                //            img = Application.StartupPath + @"\Images\Logo.jpg";
                //        }
                //    }
                //}
                
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(img);
                //image.ScaleAbsolute(60f, 60f);

                //PdfPCell c1 = new PdfPCell();
                //c1.HorizontalAlignment = Element.ALIGN_LEFT;
                //c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //c1.AddElement(image);


                //PdfPCell c2 = new PdfPCell();
                //c2.HorizontalAlignment = Element.ALIGN_LEFT;


                //c2.AddElement(new Paragraph("XXXXX-XXXXX", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                //c2.AddElement(new Paragraph("XXXXX XXXXX:75 SARAT BOSE ROAD,KOLKATA-700 026, PHONE-xxxxxxxxxx", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                //c2.AddElement(new Paragraph("BILL/REPORT COLLECTION SLIP(RCS)", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                //tabheader.AddCell(c1);
                //tabheader.AddCell(c2);

                // End Rev

                Paragraph xblank = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x1 = new Paragraph("Total Amount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x3 = new Paragraph("Other Charges", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x4 = new Paragraph("Less", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x5 = new Paragraph("Final Amount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x6 = new Paragraph("Amount Received", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x7 = new Paragraph("Balance", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                /**/
                Paragraph x8 = new Paragraph("Total Tax(Rs)", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                Paragraph x9 = new Paragraph("Discount", FontFactory.GetFont(FontFactory.HELVETICA, 8));
                /**/                
                
                PdfPTable xtable = new PdfPTable(7);
                float[] width_x = new float[] { 5f, 2f, 8f, 10f, 5f, 2f, 8f };
                xtable.SetWidths(width_x);
                xtable.WidthPercentage = 100;
                xtable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                xtable.AddCell(x1);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.Total), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                xtable.AddCell(" ");
                xtable.AddCell(x5);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.GrossAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                //xtable.AddCell(x3);
                //xtable.AddCell(x2);
                //xtable.AddCell(new Paragraph("0.00", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                xtable.AddCell(x9);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                xtable.AddCell(" ");
                xtable.AddCell(x8);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.TotalTax), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                xtable.AddCell(x3);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph("0.00", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                xtable.AddCell(" ");
                xtable.AddCell(x4);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                

                //xtable.AddCell(x6);
                //xtable.AddCell(x2);
                //xtable.AddCell(new Paragraph(Convert.ToString(t.ReceivedAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                //xtable.AddCell(x4);
                //xtable.AddCell(x2);
                //xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                //xtable.AddCell(" ");
                //xtable.AddCell(x9);
                //xtable.AddCell(x2);
                //xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                //xtable.AddCell(x7);
                //xtable.AddCell(x2);
                //xtable.AddCell(new Paragraph(Convert.ToString(t.BalanceAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

                xtable.AddCell(x6);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.ReceivedAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                xtable.AddCell(" ");
                xtable.AddCell(x7);
                xtable.AddCell(x2);
                xtable.AddCell(new Paragraph(Convert.ToString(t.BalanceAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));



                //Paragraph u1 = new Paragraph("User ID", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8));
                //Paragraph u2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8));
                //Paragraph u3 = new Paragraph("Password", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8));
                PdfPTable utable = new PdfPTable(7);
                float[] width_u = new float[] { 5f, 2f, 8f, 10f, 5f, 2f, 8f };
                utable.SetWidths(width_u);
              
                utable.WidthPercentage = 100;
                utable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //utable.AddCell(u1);
                //utable.AddCell(u2);
                //utable.AddCell(new Paragraph(Convert.ToString(tp.tbluser.UserName == null ? "" : tp.tbluser.UserName), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));
                utable.AddCell(" ");
                //utable.AddCell(u3);
                //utable.AddCell(u2);
                //utable.AddCell(new Paragraph(Convert.ToString(tp.tbluser.Password == null ? "" : tp.tbluser.Password), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));


                document.Add(tabheader);
                document.Add(pblank);
                document.Add(table);
                document.Add(xblank);
                document.Add(xtable);
                document.Add(xblank);
                //document.Add(xblank);
                document.Add(utable);
                document.Close();


                MessageBox.Show("Invoice generated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (File.Exists(Application.StartupPath + "/Invoice/" + t.tblclient.ClientName + ".pdf"))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Application.StartupPath + "/Invoice/" + t.tblclient.ClientName + ".pdf";
                    p.Start();
                }
                else
                {
                    MessageBox.Show("File does not exist in the folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               

            }
            catch (Exception)
            {
                document.Close();
                MessageBox.Show("An error occoured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
