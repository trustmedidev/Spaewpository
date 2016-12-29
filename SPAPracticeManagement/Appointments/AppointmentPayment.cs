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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.AppConstants;

namespace SPAPracticeManagement.Appointments
{
    public partial class AppointmentPayment : Dashboard
    {
        private bool IsCalculate = false;
        public void print(string appointmentid)
        {
            Document document = new Document();
            DateTime today = DateTime.Today;

            PaymentDtlEL t = new PaymentDtlEL();
            //tblpaymentdtl t = new tblpaymentdtl();
            //tblappointment t = new tblappointment();
            tblappointmentsetting tas = new tblappointmentsetting();

            //tas = objSettingDAL.GetLogo(1, branchID);
            t = AppointmentsList.GetAllPaymentDtlByID(Convert.ToInt32(appointmentid), branchID);
            //tblclient tp = new tblclient();

            //tp = ClientList.GetClientByClientIdBranchId(Convert.ToInt32(t.FK_ClientId), branchID);

            int age = today.Year - Convert.ToDateTime(t.dateofbirth).Year;

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

            #region pdf

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

            PdfWriter.GetInstance(document, new FileStream(Application.StartupPath + "/Invoice/" + t.ClientName + ".pdf", FileMode.Create));
            document.Open();
            Paragraph pblank = new Paragraph(" ", FontFactory.GetFont(FontFactory.HELVETICA, 8));
            Paragraph p1 = new Paragraph("Appointment No.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
            Paragraph p2 = new Paragraph(":", FontFactory.GetFont(FontFactory.HELVETICA, 8));
            Paragraph p3 = new Paragraph("Client Name", FontFactory.GetFont(FontFactory.HELVETICA, 8));
            Paragraph p4 = new Paragraph("Ref.", FontFactory.GetFont(FontFactory.HELVETICA, 8));
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
            table.AddCell(new Paragraph(Convert.ToString(t.Fk_AppointmentId), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            table.AddCell(" ");
            table.AddCell(p5);
            table.AddCell(p2);
            table.AddCell(new Paragraph(Convert.ToString(DateTime.Now.ToShortDateString()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            //table.AddCell(new Paragraph(Convert.ToString(tp.AddedDate.Value.ToShortDateString()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

            table.AddCell(p3);
            table.AddCell(p2);
            table.AddCell(new Paragraph(t.ClientName.ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            table.AddCell(" ");
            table.AddCell(p6);
            table.AddCell(p2);
            table.AddCell(new Paragraph(Convert.ToString(age) == "0" ? "" : Convert.ToString(age) + "/" + t.Sex == null ? "" : t.Sex.ToUpper(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));


            table.AddCell(p4);
            table.AddCell(p2);
            table.AddCell(new Paragraph(Convert.ToString(t.ReferralSource == null ? "" : t.ReferralSource.ToUpper()), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            table.AddCell(" ");
            table.AddCell(p7);
            table.AddCell(p2);
            table.AddCell(new Paragraph(Convert.ToString(t.Mobile == null ? "" : t.Mobile), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

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
            xtable.AddCell(new Paragraph(Convert.ToString(t.Total_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            xtable.AddCell(" ");
            xtable.AddCell(x5);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Service_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

            /*---------------Code Added By Sandip Das---------------------*/
            xtable.AddCell(x9);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Discount_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            xtable.AddCell(" ");
            xtable.AddCell(x8);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Tax_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

            xtable.AddCell(x3);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph("0.00", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            xtable.AddCell(" ");
            xtable.AddCell(x4);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Discount_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

            xtable.AddCell(x6);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Received_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            xtable.AddCell(" ");
            xtable.AddCell(x7);
            xtable.AddCell(x2);
            xtable.AddCell(new Paragraph(Convert.ToString(t.Balance_Amt), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            /*---------------Code Added By Sandip Das---------------------*/

            //xtable.AddCell(x3);
            //xtable.AddCell(x2);
            //xtable.AddCell(new Paragraph("0.00", FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            //xtable.AddCell(" ");
            //xtable.AddCell(x6);
            //xtable.AddCell(x2);
            //xtable.AddCell(new Paragraph(Convert.ToString(t.ReceivedAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));

            //xtable.AddCell(x4);
            //xtable.AddCell(x2);
            //xtable.AddCell(new Paragraph(Convert.ToString(t.Discount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            //xtable.AddCell(" ");
            //xtable.AddCell(x7);
            //xtable.AddCell(x2);
            //xtable.AddCell(new Paragraph(Convert.ToString(t.BalanceAmount), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
            document.Add(tabheader);
            document.Add(pblank);
            document.Add(table);
            document.Add(xblank);
            document.Add(xtable);
            document.Add(xblank);
            document.Close();

            if (File.Exists(Application.StartupPath + "/Invoice/" + t.ClientName + ".pdf"))
            {
                Process p = new Process();
                p.StartInfo.FileName = Application.StartupPath + "/Invoice/" + t.ClientName + ".pdf";
                p.Start();
            }
            else
            {
                MessageBox.Show("File does not exist in the folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion pdf
        }

        private void gvappdtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            //IsCalculate = false;
            //ClearForm();

            //int appointmentid = Convert.ToInt32(gvappdtl.Rows[e.RowIndex].Cells[0].Value);
            //txt_appointmentID.Text = Convert.ToString(appointmentid);
            //populateAppointmentDtl(appointmentid, branchID);
            //CheckingPaymentDtl(appointmentid, branchID);

        }

        public void CheckingPaymentDtl(int appointmentid, int? branchID)
        {
            tblpaymentdtl objtblpaymentdtl = new tblpaymentdtl();

            objtblpaymentdtl = AppointmentsList.CheckPaymentDtl(appointmentid, branchID);
            if (objtblpaymentdtl != null)
            {
                rd_advance.Checked = true;
                txtdue.Text = Convert.ToString(objtblpaymentdtl.Due_Amt);
            }
            else
            {
                MessageBox.Show("Full Payment has been made", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        protected void SearchMethod(AppointmentEL tblapp)
        {

            txtBankCardNo.Enabled = true; txtBankName.Enabled = true;
            if (tblapp != null)
            {
                txt_Service.Text = Convert.ToString(tblapp.TotalAmount);
                if (tblapp.packageid != null)
                {
                    label7.Visible = true;
                    txt_servicename.Visible = true;
                    txt_servicename.Text = tblapp.ServiceName;
                    BindServiceName(Convert.ToInt32(tblapp.packageid));
                    BindTaxDtlForPaymentByPackageID(Convert.ToInt32(tblapp.packageid));
                }
                else
                {
                    label7.Visible = false;
                    txt_servicename.Visible = false;
                    BindServiceNameByAppointmnetId(Convert.ToInt32(tblapp.AppointmentId));
                    BindTaxDtlForPaymentByServiceID();
                }

                AppointmentId = tblapp.AppointmentId;
                txt_patientname.Text = tblapp.ClientName;
                txt_servicename.Text = tblapp.ServiceName;
                txt_Servicedate.Text = Convert.ToString(tblapp.AppointmentDate.Value.Date.ToShortDateString());
                //txt_paymentstatus.Text = tblapp.paymenttype == null ? "" : tblapp.paymenttype;
                //txt_Service.Text = Convert.ToString(tblapp.TotalAmount);
                //totalAmount.Text = Convert.ToString(tblapp.TotalAmount);
                //totalAmount.Text = Convert.ToString(tblapp.TotalAmount);
                txt_discount.Text = (tblapp.ManualDiscountAmount.HasValue ? tblapp.ManualDiscountAmount.Value : 0).ToString("0.00");
                txt_advance.Text = "0";
                txtdue.Text = (tblapp.DueAmount.HasValue ? Math.Round(tblapp.DueAmount.Value, 2, MidpointRounding.AwayFromZero) : 0).ToString("0.00");
                txt_NetAmt.Text = (tblapp.NetPayableAmount.HasValue ? Math.Round(tblapp.NetPayableAmount.Value, 2, MidpointRounding.AwayFromZero) : 0).ToString("0.00");
                txt_manualDiscountPrcntg.Text = (tblapp.ManualDiscountPercentage.HasValue ? tblapp.ManualDiscountPercentage.Value : 0).ToString("0.00");

                if (tblapp.FK_CouponId.HasValue && tblapp.FK_CouponId.Value > 0)
                {
                    ddl_coupon.SelectedValue = tblapp.FK_CouponId.Value;
                }

                txt_PaidAmount.Text = (tblapp.PaymentDoneAmount.HasValue ? Math.Round(tblapp.PaymentDoneAmount.Value, 2, MidpointRounding.AwayFromZero) : 0).ToString("0.00");

                //txt_AmountReceived.Text = Convert.ToString(tblapp.recievedamount == null ? 0 : tblapp.recievedamount);
                comboBox1.SelectedIndex = 0;
                txtBankCardNo.Text = ""; txtBankName.Text = "";
                //if (comboBox1.SelectedIndex != -1)
                //{
                //    if (comboBox1.SelectedItem.ToString() == "CARD")
                //    {
                //        txtBankCardNo.Text = Convert.ToString(tblapp.BankCardNum);
                //        txtBankName.Text = Convert.ToString(tblapp.BankName);
                //    }
                //    if (txtdue.Text == "0" || txtdue.Text == "0.00")
                //    {
                //        //btn_pay.Enabled = false;
                //        txt_AmountReceived.Enabled = false;
                //        comboBox1.Enabled = false;
                //        txtBankCardNo.Enabled = false;
                //        txtBankName.Enabled = false;
                //    }
                //    else
                //    {
                //        btn_pay.Enabled = true;
                //        txt_AmountReceived.Enabled = true;
                //        comboBox1.Enabled = true;
                //    }
                //}

                txt_manualDiscountPrcntg.ReadOnly = false;

                if (tblapp.IsPaymentComplete.HasValue && tblapp.IsPaymentComplete.Value == true)
                {
                    comboBox1.Enabled = false;
                    txtBankCardNo.Enabled = false;
                    txtBankName.Enabled = false;
                    txt_manualDiscountPrcntg.Enabled = false;
                    rd_advance.Enabled = false;
                    rd_full.Enabled = false;
                    ddl_coupon.Enabled = false;

                    MessageBox.Show("Payment is complete for this appointment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tblapp.IsPaymentProcessStarted.HasValue && tblapp.IsPaymentProcessStarted.Value == true)
                {
                    txt_manualDiscountPrcntg.Enabled = false;
                    ddl_coupon.Enabled = false;
                }
            }
            else
            {
                //ClearField();
                MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void populateAppointmentDtl(int appointmentid, int? branchid)
        {
            AppointmentEL tblapp = new AppointmentEL();
            DateTime? dt = null;
            tblapp = AppointmentsList.GetApppointmentByIDforPayment(appointmentid, branchID);
            IsCalculate = false;
            SearchMethod(tblapp);
            IsCalculate = true;
            AllCalculations();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchKeyPress();
        }

        private void searchKeyPress()
        {
            AppointmentListDAL appointmentlistdal = new AppointmentListDAL();
            try
            {
                AppointmentEL tblapp = new AppointmentEL();

                DateTime? dt = null;
                int? AppointmentId = null;
                int? ClientMainId = null;

                if (dtpApptDate.Checked)
                {
                    dt = dtpApptDate.Value;
                }

                if (!string.IsNullOrWhiteSpace(txt_appointmentID.Text.Trim()) && txt_appointmentID.Text.Trim() != "0")
                {
                    AppointmentId = Convert.ToInt32(txt_appointmentID.Text.Trim());
                }

                if (txtClientName.Text != "")
                {
                    string s = txtClientName.Text.Trim();

                    int start = s.IndexOf(":") + 1;
                    int end = s.IndexOf(")", start);
                    if (end < 0)
                    {
                        MessageBox.Show("Invalid Client Name Entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string result = s.Substring(start, end - start);

                    int ClientId = AppointmentsList.GetClientIdFromMobile(result);

                    if (ClientId > 0)
                    {
                        ClientMainId = ClientId;
                    }
                }


                List<PaymentDtlEL> modellist = AppointmentsList.GetAppointmentPaymentAllDtls(branchID, ClientMainId, dt, AppointmentId);

                grdpayment.DataSource = modellist;

                if ((ClientMainId.HasValue && ClientMainId.Value > 0) || (AppointmentId.HasValue && AppointmentId.Value > 0))
                {
                    gvappdtl.DataSource = AppointmentsList.GetAllUnpaidAppointments(branchID, ClientMainId, AppointmentId);
                }
                else
                {
                    gvappdtl.DataSource = new List<PaymentDtlEL>();
                }

                if (modellist == null || modellist.Count() <= 0)
                {
                    MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                //if (txt_appointmentID.Text.Trim() != "" && txtClientName.Text.Trim() == "" && dt == null)
                //{
                //    populateAppointmentDtl(Convert.ToInt32(txt_appointmentID.Text.Trim()), branchID);
                //    IsCalculate = true;
                //    AllCalculations();
                //    //tblapp = AppointmentsList.GetApppointmentByIDforPayment(Convert.ToInt32(txt_appointmentID.Text.Trim()), branchID);
                //    //SearchMethod(tblapp); 
                //}

                //else if (txtClientName.Text != "" && txt_appointmentID.Text.Trim() == "0" && dt == null)
                //{
                //    /*---------Code Added By Sandip Das on 06-06-2016-------------------------------*/
                //    string s = txtClientName.Text.Trim();

                //    int start = s.IndexOf(":") + 1;
                //    int end = s.IndexOf(")", start);
                //    if (end < 0)
                //    {
                //        MessageBox.Show("Invalid Client Name Entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    string result = s.Substring(start, end - start);

                //    int ClientId = AppointmentsList.GetClientIdFromMobile(result);

                //    List<PaymentDtlEL> objPaymentDtlEL = new List<PaymentDtlEL>();
                //    objPaymentDtlEL = AppointmentsList.GetaoopintmentPaymentDtlByClientID(ClientId, branchID);
                //    gvappdtl.AutoGenerateColumns = false;
                //    gvappdtl.DataSource = objPaymentDtlEL;


                //    /*---------Code Added By Sandip Das on 06-06-2016-------------------------------*/





                //    //tblapp = appointmentlistdal.GetApppointmentByClntNameforPayment(Convert.ToString(txtClientName.Text.Trim()), branchID);
                //    //SearchMethod(tblapp); 

                //    IsCalculate = true;
                //    AllCalculations();
                //}
                //else if (dt != null && txt_appointmentID.Text.Trim() == "0" && txtClientName.Text.Trim() == "")
                //{
                //    tblapp = appointmentlistdal.GetApppointmentByDateforPayment(Convert.ToDateTime(dt), branchID);
                //    SearchMethod(tblapp);
                //    IsCalculate = true;
                //    AllCalculations();
                //}
                //else if (txt_appointmentID.Text.Trim() != "" && txtClientName.Text.Trim() != "" && dt != null || txt_appointmentID.Text.Trim() != "" && txtClientName.Text.Trim() != "" && dt == null
                //    || txt_appointmentID.Text.Trim() == "" && txtClientName.Text.Trim() != "" && dt != null || txt_appointmentID.Text.Trim() != "" && txtClientName.Text.Trim() == "" && dt != null)
                //{
                //    tblapp = appointmentlistdal.GetApppointmentByAllforPayment(Convert.ToInt32(txt_appointmentID.Text.Trim()), Convert.ToString(txtClientName.Text.Trim())
                //        , Convert.ToDateTime(dt), branchID);
                //    SearchMethod(tblapp);
                //    IsCalculate = true;
                //    AllCalculations();
                //}

                //else
                //{
                //    //ClearField();
                //    MessageBox.Show("Please enter appointment id", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    IsCalculate = false;
                //}
            }
            catch (Exception ex)
            {
                IsCalculate = false;
                ClearForm();
                MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateForm()
        {
            if (txt_patientname.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Client Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "")
            {
                MessageBox.Show("Please select payment mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select payment mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            /*-----------------Code Added By Sandip Das---------------------------------------*/
            if (comboBox1.SelectedIndex == 2 && txtBankCardNo.Text == "")
            {
                MessageBox.Show("Please enter Card Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.SelectedIndex == 2 && txtBankName.Text == "")
            {
                MessageBox.Show("Please enter Bank Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rd_advance.Checked && txt_advance.Text == "")
            {
                MessageBox.Show("Please enter Advance Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txt_tenderamt.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter Tender Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (rd_advance.Checked && Convert.ToDecimal(txt_advance.Text) > Convert.ToDecimal(txt_NetAmt.Text))
            {
                MessageBox.Show("Advance Amount can not be greater than net amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (rd_full.Checked && Convert.ToDecimal(txt_tenderamt.Text) < Convert.ToDecimal(txt_AmountReceived.Text))
            //{
            //    MessageBox.Show("Tender Amount can not be less than net amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }

        private int SavePayment()
        {
            int r = 0;

            try
            {
                string startTime = "";
                string endTime = "";
                string time = "";
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
                    //string s = txtClientName.Text.Trim();

                    //int start = s.IndexOf(":") + 1;
                    //int end = s.IndexOf(")", start);
                    //if (end < 0)
                    //{
                    //    MessageBox.Show("Invalid Client Name Entered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return 0;
                    //}
                    //string result = s.Substring(start, end - start);
                    //int ClientId = Convert.ToInt32(result.Trim());

                    tblpaymentdtl objtblpaymentdtl = new tblpaymentdtl();
                    tblappointment objAppointment = new tblappointment();
                    //UpdateClientId = ClientId;
                    //`PaymentID` `Fk_AppointmentId` `Fk_BranchId` `Fk_TaxId` `Net_Amt` `Total_Amt` `Gross_Amt` `Service_Amt`
                    //`Discount_Amt` `Due_Amt` `Payment_Type` `Advance_Amt` `Received_Amt` `Balance_Amt` 
                    //`Tax_Amt` `Payment_Mode` `Bank_CardNo` `Bank_Name` `Fk_CouponID` `IsActive` `CreatedBy` `IsPaymentComplete`

                    //////-------------------------Save Appointment Data---------------------------------

                    objAppointment.AppointmentId = Convert.ToInt32(txt_appointmentID.Text.Trim());
                    objAppointment.TaxAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_TotalTax.Text.Trim()) ? txt_TotalTax.Text.Trim() : "0");
                    objAppointment.CouponDiscountAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_CouponDscnt.Text.Trim()) ? txt_CouponDscnt.Text.Trim() : "0");
                    objAppointment.ManualDiscountPercentage = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_manualDiscountPrcntg.Text.Trim()) ? txt_manualDiscountPrcntg.Text.Trim() : "0");
                    objAppointment.ManualDiscountAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_discount.Text.Trim()) ? txt_discount.Text.Trim() : "0");
                    objAppointment.NetPayableAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_NetAmt.Text.Trim()) ? txt_NetAmt.Text.Trim() : "0");
                    objAppointment.PaymentDoneAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_PaidAmount.Text.Trim()) ? txt_PaidAmount.Text.Trim() : "0") + Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_AmountReceived.Text.Trim()) ? txt_AmountReceived.Text.Trim() : "0"); //previous amount + now recieved amount
                    objAppointment.DueAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txtdue.Text.Trim()) ? txtdue.Text.Trim() : "0");

                    objAppointment.GrossAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_NetAmt.Text.Trim()) ? txt_NetAmt.Text.Trim() : "0");
                    objAppointment.Discount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_discount.Text.Trim()) ? txt_discount.Text.Trim() : "0");

                    objAppointment.TotalTax = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_TotalTax.Text.Trim()) ? txt_TotalTax.Text.Trim() : "0");
                    objAppointment.ReceivedAmount = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_PaidAmount.Text.Trim()) ? txt_PaidAmount.Text.Trim() : "0") + Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_AmountReceived.Text.Trim()) ? txt_AmountReceived.Text.Trim() : "0"); //previous amount + now recieved amount

                    objAppointment.FK_TaxId = null;

                    if (objAppointment.DueAmount <= 0)
                    {
                        objAppointment.IsPaymentComplete = true;
                    }
                    else
                    {
                        objAppointment.IsPaymentComplete = false;
                    }

                    objAppointment.IsPaymentProcessStarted = true;

                    if (ddl_coupon.SelectedIndex != 0)
                    {
                        objAppointment.FK_CouponId = Convert.ToInt32(ddl_coupon.SelectedValue);
                    }

                    //////-------------------------Save Appointment Data---------------------------------


                    /////----------------------------Save PaymentDtlsNewData--------------------------------

                    //Advance amount
                    objtblpaymentdtl.Advance_Amt = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txt_advance.Text.Trim()) ? txt_advance.Text.Trim() : "0");

                    //Due amount
                    objtblpaymentdtl.Due_Amt = Convert.ToDecimal(!string.IsNullOrWhiteSpace(txtdue.Text.Trim()) ? txtdue.Text.Trim() : "0");

                    //Recieved Amount
                    objtblpaymentdtl.Received_Amt = Convert.ToDecimal((!string.IsNullOrWhiteSpace(txt_AmountReceived.Text.Trim())) ? txt_AmountReceived.Text.Trim() : "0");

                    objtblpaymentdtl.Fk_AppointmentId = Convert.ToInt32(txt_appointmentID.Text);
                    objtblpaymentdtl.Fk_BranchId = AppsPropertise.UserDetails.BranchId; ;
                    objtblpaymentdtl.Total_Amt = Convert.ToDecimal(totalAmount.Text.Trim() == "" ? "0" : totalAmount.Text.Trim());
                    objtblpaymentdtl.Net_Amt = Convert.ToDecimal(txt_NetAmt.Text.Trim() == "" ? "0" : txt_NetAmt.Text.Trim());
                    objtblpaymentdtl.Service_Amt = Convert.ToDecimal(txt_Service.Text.Trim() == "" ? "0" : txt_Service.Text.Trim());
                    objtblpaymentdtl.Discount_Amt = Convert.ToDecimal(txt_discount.Text.Trim() == "" ? "0" : txt_discount.Text.Trim());
                    if (rd_advance.Checked)
                    {
                        objtblpaymentdtl.Payment_Type = "Advance";
                    }
                    else
                    {
                        objtblpaymentdtl.Payment_Type = "Full";
                    }

                    objtblpaymentdtl.Tax_Amt = Convert.ToDecimal(txt_TotalTax.Text.Trim() == "" ? "0" : txt_TotalTax.Text.Trim());
                    if (comboBox1.SelectedIndex == 1)
                    {
                        objtblpaymentdtl.Payment_Mode = "Cash";
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        objtblpaymentdtl.Payment_Mode = "Card";
                        objtblpaymentdtl.Bank_CardNo = txtBankCardNo.Text.Trim();
                        objtblpaymentdtl.Bank_Name = txtBankName.Text.Trim();
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        objtblpaymentdtl.Payment_Mode = "Credit";
                    }
                    if (ddl_coupon.SelectedIndex != 0)
                    {
                        objtblpaymentdtl.Fk_CouponID = Convert.ToInt32(ddl_coupon.SelectedValue);
                    }

                    if (objAppointment.DueAmount <= 0)
                    {
                        objtblpaymentdtl.IsPaymentComplete = true;
                    }
                    else
                    {
                        objtblpaymentdtl.IsPaymentComplete = false;
                    }

                    string Message = "";
                    i = AppointmentsList.InsertPaymentDtl(objtblpaymentdtl, objAppointment, out Message);

                    ///*-----------------------------------END---------------------------------*/

                    if (i > 0)
                    {
                        //tp = ClientList.GetClientByClientIdBranchId(ClientId, branchID);
                        //tblsrvc = objSettingDAL.GetAllServicesById(tap.FK_ServiceId, branchID);
                        //if (tp != null & tblsrvc != null)
                        //{
                        //    string msg = "Dear " + tp.ClientName + " , Just to inform you that your appointment for " + (tblsrvc.ServiceName == null ? "" : tblsrvc.ServiceName) + "has been booked on " + objAppointment.AppointmentDate.Value.ToShortDateString() + " at " + objAppointment.AppointmentTime + " . Stay happy & healthy. Thank  You, XXXX ";
                        //    ut.SendMessage(msg, tp.Mobile);
                        //}

                        MessageBox.Show("Payment succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        r = i;

                        IsCalculate = false;
                        ClearForm();
                        gvappdtl.DataSource = new List<PaymentDtlEL>();
                        dtpApptDate.Value = DateTime.Now;
                        grdpayment.DataSource = AppointmentsList.GetAppointmentPaymentAllDtls(branchID, null, DateTime.Now, null);
                    }
                    else
                    {
                        MessageBox.Show("Payment unsuccesful", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        //.................... Code Checked By Sam on 12092016............................

        #region initialization

        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        private int _AppointmentId;
        public int AppointmentId
        {
            get { return _AppointmentId; }
            set { _AppointmentId = value; }
        }

        DashboardDAL dashboard_dal = new DashboardDAL();
        public AppointmentDAL AppointmentsList
        {
            get { return new AppointmentDAL(); }
        }

        public ClientDAL ClientList
        {
            get { return new ClientDAL(); }
        }

        SettingDAL objSettingDAL = new SettingDAL();
        public AppointmentPayment()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            comboBox1.SelectedIndex = 0;

            List<PaymentDtlEL> modellist = AppointmentsList.GetAppointmentPaymentAllDtls(branchID, null, DateTime.Now, null);

            grdpayment.AutoGenerateColumns = false;
            grdpayment.DataSource = modellist;

            gvappdtl.AutoGenerateColumns = false;
            gvappdtl.DataSource = new List<PaymentDtlEL>();

            BindCouponDtl();
            BindCustomerList();

        }

        private void BindCustomerList()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<ClientEL> objClintList = ClientList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.ClientName + " (Mobile: " + item.Mobile + ")");
            }

            txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClientName.AutoCompleteCustomSource = namesCollection;
        }

        #endregion

        #region Service list listbox detail
        private void BindServiceName(int packageid)
        {
            try
            {
                tblservice Objtblservice = new tblservice();
                {
                    lst_servicename.DataSource = null;
                    lst_servicename.DataSource = AppointmentsList.GetAllServicesByPackageIDforPayment(packageid, branchID);
                    lst_servicename.DisplayMember = "ServiceName"; // Column Name
                    lst_servicename.ValueMember = "ServiceId";
                }
                lst_servicename.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }
        public void BindTaxDtlForPaymentByServiceID()
        {
            decimal totaltaxamt = 0;
            List<string> taxid = new List<string>();
            List<tbltaxmaster> objtbltaxmasterList = new List<tbltaxmaster>();
            foreach (tblservice ser in lst_servicename.Items)
            {
                string taxidlst = AppointmentsList.GetTaxDtlByServiceID(ser.ServiceId, branchID);
                if (taxidlst != null && taxidlst != "")
                {
                    string[] splittaxdtl = new string[] { };
                    splittaxdtl = taxidlst.Split(',');
                    foreach (string str in splittaxdtl)
                    {

                        tbltaxmaster objtbltaxmaster = new tbltaxmaster();
                        objtbltaxmaster = AppointmentsList.GetTaxMasterDetail(Convert.ToInt32(str), branchID);
                        if (!taxid.Contains(str))
                        {
                            objtbltaxmasterList.Add(objtbltaxmaster);
                            taxid.Add(str);
                        }
                    }
                }
            }
            tbltaxmaster objtaxmaster = new tbltaxmaster();
            {
                lst_TaxDtl.DisplayMember = "Tax_Name";
                lst_TaxDtl.ValueMember = "Tax_Id";
                lst_TaxDtl.DataSource = objtbltaxmasterList;
            };
            if (txt_Service.Text != "")
            {
                decimal taxpercentage = (Convert.ToDecimal(txt_Service.Text) * totaltaxamt) / 100;
                decimal serviceamt = Convert.ToDecimal(txt_Service.Text);
                txt_TotalTax.Text = Convert.ToString(taxpercentage);
                txt_NetAmt.Text = Convert.ToString(serviceamt + taxpercentage);
                totalAmount.Text = Convert.ToString(serviceamt + taxpercentage);
                //txt_GrossAmount.Text = Convert.ToString(serviceamt + taxpercentage);
            }
        }
        public void BindTaxDtlForPaymentByPackageID(int packageid)
        {
            decimal totaltaxamt = 0;
            List<string> taxid = new List<string>();
            List<tbltaxmaster> objtbltaxmasterList = new List<tbltaxmaster>();

            string taxidlst = AppointmentsList.GetTaxDtlByPackageID(packageid, branchID);
            if (taxidlst != null && taxidlst != "")
            {
                string[] splittaxdtl = new string[] { };
                splittaxdtl = taxidlst.Split(',');
                foreach (string str in splittaxdtl)
                {

                    tbltaxmaster objtbltaxmaster = new tbltaxmaster();
                    objtbltaxmaster = AppointmentsList.GetTaxMasterDetail(Convert.ToInt32(str), branchID);
                    if (!taxid.Contains(str))
                    {
                        totaltaxamt = totaltaxamt + Convert.ToDecimal(objtbltaxmaster.Tax_Rate);
                        objtbltaxmasterList.Add(objtbltaxmaster);

                        taxid.Add(str);
                    }
                }
                tbltaxmaster objtaxmaster = new tbltaxmaster();
                {
                    lst_TaxDtl.DisplayMember = "Tax_Name";
                    lst_TaxDtl.ValueMember = "Tax_Id";
                    lst_TaxDtl.DataSource = objtbltaxmasterList;
                };
                if (txt_Service.Text != "")
                {
                    decimal taxpercentage = Math.Round(((Convert.ToDecimal(txt_Service.Text) * totaltaxamt) / 100), 2);
                    decimal serviceamt = Convert.ToDecimal(txt_Service.Text);
                    txt_TotalTax.Text = Convert.ToString(Math.Round((taxpercentage), 2));
                    txt_NetAmt.Text = Convert.ToString(serviceamt + taxpercentage);
                    totalAmount.Text = Convert.ToString((serviceamt + taxpercentage));
                }
            }
            totaltaxamt = 0;


        }
        private void BindServiceNameByAppointmnetId(int packageid)
        {
            try
            {
                lst_servicename.DataSource = null;
                lst_servicename.DisplayMember = "ServiceName"; // Column Name
                lst_servicename.ValueMember = "ServiceId";
                List<tblservice> objtblservice = new List<tblservice>();
                objtblservice = AppointmentsList.GetAllServicesByAppointmnetIdforPayment(packageid, branchID);
                lst_servicename.DataSource = objtblservice.ToList();
                lst_servicename.Enabled = false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void BindCouponDtl()
        {
            List<tblcoupanmaster> objcoupanmaster = new List<tblcoupanmaster>();

            objcoupanmaster.Insert(0, new tblcoupanmaster() { Id = 0, Coupan_Name = "Select" });
            var cpnlist = AppointmentsList.GetAllValidCouponDtl(branchID);
            if (cpnlist != null)
            {
                foreach (tblcoupanmaster cpn in cpnlist)
                {

                    objcoupanmaster.Add(cpn);
                }
            }
            ddl_coupon.DisplayMember = "Coupan_Name";
            ddl_coupon.ValueMember = "Id";
            ddl_coupon.DataSource = objcoupanmaster;
            ddl_coupon.SelectedIndex = 0;
        }

        #endregion

        #region Text Changed Event

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_manualDiscountPrcntg_TextChanged(object sender, EventArgs e)
        {
            // CalculationAmount();

            /*-------------------Code Added By Sandip Das ----------------------------*/
            //if (!string.IsNullOrEmpty(txt_manualDiscountPrcntg.Text.Trim()))
            //{
            //    if (Convert.ToDecimal(txt_manualDiscountPrcntg.Text.Trim()) > 100)
            //    {

            //        txt_manualDiscountPrcntg.Text = "0";
            //    }
            //    else
            //    {
            //        CalculationAmount();
            //    }
            //}
            //else 
            //{ 
            //    //txt_manualDiscountPrcntg.Text = "0"; 
            //}
            /*--------------------------END ----------------------------*/

            bool stat = AllCalculations();

            if (!stat)
            {
                txt_manualDiscountPrcntg.Text = "";
            }

        }

        private void txt_advance_TextChanged(object sender, EventArgs e)
        {
            //if (txt_advance.Text.Trim() != "")
            //{
            //    decimal value;
            //    decimal grossvalue = Convert.ToDecimal(txt_NetAmt.Text == "" ? "0" : txt_NetAmt.Text);
            //    if (decimal.TryParse(txt_advance.Text, out value))
            //    {
            //        if (value > grossvalue)
            //        {
            //            MessageBox.Show("Advance amount can not be greater than Net Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtdue.Text = "0";
            //            txt_advance.Text = "0";
            //            return;
            //        }
            //        //txt_advance.Text = "0";
            //    }
            //    txtdue.Text = Convert.ToString(grossvalue - Convert.ToDecimal(txt_advance.Text));
            //}
            ///*------------------Code Added By Sandip Das -----------------------*/
            //else
            //{
            //    //txt_AmountReceived.Text = "";
            //    //txt_ReturnAmount.Text = "";
            //    //txt_advance.Text = "0";
            //}
            /*----------------------------------END -----------------------*/

            AllCalculations();
        }

        private void txt_tenderamt_TextChanged(object sender, EventArgs e)
        {
            //if (txt_Service.Text != "")
            //{
            //    if (txt_NetAmt.Text != "")
            //    {
            //        if (txt_tenderamt.Text != "")
            //        {
            //            //if (txt_advance.Text == "" || txt_advance.Text == "0")
            //            //{
            //            //    //if (Convert.ToDecimal(txt_tenderamt.Text) >= Convert.ToDecimal(txt_NetAmt.Text))
            //            //    //{
            //            //    txt_AmountReceived.Text = txt_NetAmt.Text.Trim();
            //            //    //txt_AmountReceived.Text = txt_tenderamt.Text.Trim();
            //            //    decimal ReturnAmount = Convert.ToDecimal(txt_tenderamt.Text) - Convert.ToDecimal(txt_AmountReceived.Text);
            //            //    txt_ReturnAmount.Text = ReturnAmount < 0 ? "0" : Convert.ToString(ReturnAmount);
            //            //    //}
            //            //}
            //            //else
            //            //{
            //            //    txt_AmountReceived.Text = txt_advance.Text.Trim();
            //            //    txt_ReturnAmount.Text = Convert.ToString(Convert.ToDecimal(txt_tenderamt.Text) - Convert.ToDecimal(txt_AmountReceived.Text));
            //            //}
            //            txt_AmountReceived.Text = txt_NetAmt.Text.Trim();
            //            decimal ReturnAmount = Convert.ToDecimal(txt_tenderamt.Text) - Convert.ToDecimal(txt_AmountReceived.Text);
            //            txt_ReturnAmount.Text = ReturnAmount < 0 ? "0" : Convert.ToString(ReturnAmount);
            //        }
            //        else
            //        {
            //            txt_AmountReceived.Text = "";
            //            txt_ReturnAmount.Text = "";
            //        }
            //    }
            //}

            AllCalculations();
        }

        private void txt_AmountReceived_TextChanged(object sender, EventArgs e)
        {
            //if (txt_AmountReceived.Text.Trim() != "")
            //{
            //    txt_PaidAmount.Text = Convert.ToString(Math.Abs(Convert.ToDecimal(txt_AmountReceived.Text == "" ? "0" : txt_AmountReceived.Text) - Convert.ToDecimal(txt_advance.Text == "" ? "0" : txt_advance.Text)).ToString());
            //}
            //else
            //{
            //    txt_PaidAmount.Text = string.Empty;
            //}
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //if (txtDiscount.Text != "")
            //{
            //    totalAmount.Text = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(txtServiceCharge.Text) - Convert.ToDecimal(txtDiscount.Text)), 2).ToString());
            //}
        }

        #endregion

        #region Numeric Field  Detail

        private void txt_appointmentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txt_appointmentID.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void txt_manualDiscountPrcntg_KeyPress(object sender, KeyPressEventArgs e)
      {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void txtBankCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }
        private void txt_advance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void txt_tenderamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void txt_AmountReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(txt_AmountReceived.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        #endregion

        #region Button FUnction
        private void btn_pay_Click(object sender, EventArgs e)
        {
            SavePayment();
        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            if (txt_appointmentID.Text != "" && txt_appointmentID.Text != "0")
            {
                print(txt_appointmentID.Text);
            }
            else
            {
                MessageBox.Show("Please enter Appointment Id.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            IsCalculate = false;
            ClearForm();
        }
        #endregion


        #region Extra Code For Calculation
        private void CalculationAmount()
        {


            string SR_Charge = txt_Service.Text == "" ? "0" : txt_Service.Text;
            string Coupon_Discount = Convert.ToString(txt_CouponDscnt.Text == "" ? "0" : txt_CouponDscnt.Text);
            string MTotal = Convert.ToString(Convert.ToDecimal(SR_Charge) - Convert.ToDecimal(Coupon_Discount));
            string discpuntpercentage = Convert.ToString(txt_manualDiscountPrcntg.Text == "" ? "0" : txt_manualDiscountPrcntg.Text);
            if (totalAmount.Text != "")
            {
                string Manual_Discount = Convert.ToString((Convert.ToDecimal(totalAmount.Text) * Convert.ToDecimal(discpuntpercentage)) / 100);
                txt_discount.Text = Manual_Discount;
                txt_NetAmt.Text = Convert.ToString(Convert.ToDecimal(totalAmount.Text) - (Convert.ToDecimal(Coupon_Discount) + Convert.ToDecimal(Manual_Discount)));
            }
            //totalAmount.Text = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(SR_Charge) - Convert.ToDecimal(Coupon_Discount) - Convert.ToDecimal(Manual_Discount)), 2).ToString());

            //string taxAmount = (txt_TotalTax.Text == "" ? "0" : txt_TotalTax.Text);
            //string netTotal = (totalAmount.Text == "" ? "0" : totalAmount.Text);
            //txt_GrossAmount.Text = Convert.ToString(Math.Round((Convert.ToDecimal(netTotal) + Convert.ToDecimal(taxAmount)), 2));

        }


        #endregion

        #region DropDown Detail
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCardNo.Visible = false; lblBankName.Visible = false;
            txtBankCardNo.Visible = false; txtBankName.Visible = false;

            if (comboBox1.SelectedItem == "CASH")
            {
                lblCardNo.Visible = false; lblBankName.Visible = false;
                txtBankCardNo.Visible = false; txtBankName.Visible = false;
            }
            else if (comboBox1.SelectedItem == "CARD")
            {
                lblCardNo.Visible = true; lblBankName.Visible = true;
                txtBankCardNo.Visible = true; txtBankName.Visible = true;
            }
            else if (comboBox1.SelectedItem == "CREDIT")
            {
                lblCardNo.Visible = false; lblBankName.Visible = false;
                txtBankCardNo.Visible = false; txtBankName.Visible = false;
            }
            else { }
        }

        #endregion

        #region Clear Form
        private void ClearForm()
        {
            txt_appointmentID.Text = string.Empty;
            txtClientName.Text = string.Empty;
            txt_patientname.Text = string.Empty;
            dtpApptDate.Checked = false;
            dtpApptDate.Value = DateTime.Now;
            txt_Servicedate.Text = string.Empty;
            txt_servicename.Text = string.Empty;
            ddl_coupon.SelectedIndex = 0;
            totalAmount.Text = string.Empty;
            lst_servicename.DataSource = null;
            lst_TaxDtl.DataSource = null;
            txt_TotalTax.Text = string.Empty;
            ddl_coupon.SelectedIndex = 0;
            txt_CouponDscnt.Text = string.Empty;
            txt_manualDiscountPrcntg.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            txtBankCardNo.Text = string.Empty;
            txtBankName.Text = string.Empty;
            totalAmount.Text = string.Empty;
            txt_Service.Text = string.Empty;
            txt_NetAmt.Text = string.Empty;
            rd_full.Checked = true;
            txt_discount.Text = string.Empty;
            txt_advance.Text = string.Empty;
            txtdue.Text = string.Empty;
            //txt_tenderamt.Text = string.Empty;
            txt_AmountReceived.Text = string.Empty;
            txt_PaidAmount.Text = string.Empty;
            txt_manualDiscountPrcntg.Enabled = true;
            ddl_coupon.Enabled = true;
        }
        #endregion

        #region Radio Button Detail
        private void rd_full_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_full.Checked)
            {
                txt_advance.Text = "";
                txtdue.Text = "";
                txt_advance.Enabled = false;
                txtdue.Enabled = false;
            }

            AllCalculations();
        }

        private void rd_advance_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_advance.Checked)
            {
                txt_advance.Text = "";
                txtdue.Text = "";
                txt_advance.Enabled = true;
                //txtdue.Enabled = false;
            }
            AllCalculations();
        }

        #endregion



        private void ddl_coupon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_coupon.SelectedIndex != 0)
            {
                decimal? cpamt = AppointmentsList.GetCoupanAmtByCoupanID(Convert.ToInt32(ddl_coupon.SelectedValue), branchID);
                decimal cpnamt = Convert.ToDecimal(cpamt);
                //if (txt_Service.Text != "")
                //{
                //    if (txt_NetAmt.Text != "")
                //    {
                //        if (txt_CouponDscnt.Text != "")
                //        {
                //            txt_NetAmt.Text = Convert.ToString(Convert.ToDecimal(txt_NetAmt.Text) + Convert.ToDecimal(txt_CouponDscnt.Text));
                //            txt_CouponDscnt.Text = "";
                //        }
                //        txt_CouponDscnt.Text = Convert.ToString(cpnamt);
                //        txt_NetAmt.Text = Convert.ToString(Convert.ToDecimal(txt_NetAmt.Text) - cpnamt);
                //    }
                //}
                //cpamt = 0;
                //cpnamt = 0;


                //if (!string.IsNullOrEmpty(txt_manualDiscountPrcntg.Text.Trim()))
                //{
                //    if (Convert.ToDecimal(txt_manualDiscountPrcntg.Text.Trim()) > 100)
                //    {

                //        txt_manualDiscountPrcntg.Text = "0";
                //    }
                //    else
                //    {
                //        CalculationAmount();
                //    }
                //}
                //else { txt_manualDiscountPrcntg.Text = "0"; }

                txt_CouponDscnt.Text = Convert.ToString(cpnamt);

                bool stat = AllCalculations();

                if (!stat)
                {
                    txt_CouponDscnt.Text = "";
                    ddl_coupon.SelectedIndex = 0;
                }
            }
            else
            {
                //if (txt_Service.Text != "")
                //{
                //    if (txt_NetAmt.Text != "")
                //    {
                //        if (txt_CouponDscnt.Text != "")
                //        {
                //            txt_NetAmt.Text = Convert.ToString(Convert.ToDecimal(txt_NetAmt.Text) + Convert.ToDecimal(txt_CouponDscnt.Text));
                //            txt_CouponDscnt.Text = "";
                //        }
                //    }
                //}

                txt_CouponDscnt.Text = "";

                AllCalculations();
            }
        }






        //.................... Code Above Checked By Sam on 12092016............................






        private bool AllCalculations()
        {
            if (IsCalculate)
            {
                //Total Amount
                decimal TotalAmount = 0;
                if (!string.IsNullOrWhiteSpace(totalAmount.Text.Trim()))
                {
                    if (!decimal.TryParse(totalAmount.Text.Trim(), out TotalAmount))
                    {
                        TotalAmount = 0;
                    }
                }
                //Coupon discount
                decimal CouponDiscount = 0;

                if (!string.IsNullOrWhiteSpace(Convert.ToString(txt_CouponDscnt.Text.Trim())))
                {
                    if (!decimal.TryParse(Convert.ToString(txt_CouponDscnt.Text.Trim()), out CouponDiscount))
                    {
                        CouponDiscount = 0;
                    }
                }

                //Manual Discount
                decimal ManulaDiscountAmount = 0;
                decimal ManulaDiscountPercent = 0;
                if (!string.IsNullOrWhiteSpace(txt_manualDiscountPrcntg.Text.Trim()))
                {
                    if (decimal.TryParse(txt_manualDiscountPrcntg.Text.Trim(), out ManulaDiscountPercent))
                    {
                        if (Convert.ToDecimal(txt_manualDiscountPrcntg.Text.Trim()) > 100)
                        {
                            txt_manualDiscountPrcntg.Text = "0";
                            ManulaDiscountPercent = 0;
                        }
                    }
                    else
                    {
                        ManulaDiscountPercent = 0;
                    }
                }
                ManulaDiscountAmount = ((TotalAmount * Convert.ToDecimal(ManulaDiscountPercent)) / 100);


                //Total Discount Amount
                decimal totalDiscountAmount = CouponDiscount + ManulaDiscountAmount;

                if (totalDiscountAmount > TotalAmount)
                {
                    MessageBox.Show("Total discount amount cannot be greater than total amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    txt_discount.Text = (totalDiscountAmount).ToString("0.00");
                    txt_NetAmt.Text = (TotalAmount - totalDiscountAmount).ToString("0.00");

                    //Recived Amount
                    decimal recievedAmount = 0;
                    decimal MainNetAmount = Convert.ToDecimal(txt_NetAmt.Text) - (!string.IsNullOrWhiteSpace(txt_PaidAmount.Text.Trim()) ? Convert.ToDecimal(txt_PaidAmount.Text.Trim()) : 0);

                    if (rd_advance.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(txt_advance.Text.Trim()))
                        {
                            if (!decimal.TryParse(txt_advance.Text.Trim(), out recievedAmount))
                            {
                                recievedAmount = 0;
                            }

                            if (recievedAmount > MainNetAmount)//OR Recieved amount > (Net Amount - Previous amount) if privious amount exists
                            {
                                MessageBox.Show("Advanced amount cannot be greater than net amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_advance.Text = "";
                                recievedAmount = 0;
                            }
                        }
                    }
                    else
                    {
                        recievedAmount = MainNetAmount; //OR (Net Amount - Previous amount) if privious amount exists
                    }

                    txtdue.Text = (MainNetAmount - recievedAmount).ToString("0.00"); //might need to change if there is a previous amount paid.[Net Amount - (Previous amount + Recieved Amount)]
                    txt_AmountReceived.Text = (recievedAmount).ToString("0.00");

                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void gvappdtl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            IsCalculate = false;
            ClearForm();

            int appointmentid = Convert.ToInt32(gvappdtl.Rows[e.RowIndex].Cells[0].Value);
            txt_appointmentID.Text = Convert.ToString(appointmentid);
            populateAppointmentDtl(appointmentid, branchID);
        }

        private void txt_appointmentID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchKeyPress();
            }
        }

        private void txtClientName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchKeyPress();
            }
        }

        private void dtpApptDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchKeyPress();
            }
        }
    }
}




//private void txtCouponID_TextChanged(object sender, EventArgs e)
//       {
//           /////////////////////////////////

//           AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

//           List<tblcoupanmaster> objcoupanmaster = AppointmentsList.GetAllCouponNameByName(txtCouponID.Text.Trim(), branchID);
//           //List<tblcoupanmaster> objcoupanmaster = null;


//           foreach (var item in objcoupanmaster)
//           {
//               namesCollection.Add(item.Coupon_Id);
//           }
//           txtCouponID.AutoCompleteMode = AutoCompleteMode.Suggest;
//           txtCouponID.AutoCompleteSource = AutoCompleteSource.CustomSource;
//           txtCouponID.AutoCompleteCustomSource = namesCollection;

//           if (!string.IsNullOrEmpty(txtCouponID.Text.Trim()))
//           {
//               ///////////////////////////////////
//               //tblcoupanmaster objtblcoupanmaster = AppointmentsList.GetCouponValidity(txtCouponID.Text.Trim(), branchID);
//               tblcoupanmaster objtblcoupanmaster = null;
//               if (objtblcoupanmaster != null)
//               {
//                   DateTime validDate = objtblcoupanmaster.Coupan_SDateVld.Value.AddDays(Convert.ToDouble(objtblcoupanmaster.Coupan_Validity));
//                   DateTime curdt = System.DateTime.Now;
//                   var days = (validDate - curdt).Days;
//                   if ((int)days > 0)
//                   {

//                       txt_CouponDscnt.Text = Convert.ToString(objtblcoupanmaster.Coupon_Amt);
//                       //string discpuntpercentage = Convert.ToString(((objtblcoupanmaster.Coupon_Amt) * 100) / Convert.ToDecimal(txtServiceCharge.Text.Trim()));
//                       string discpuntpercentage = "0";
//                       txtDiscount.Text = discpuntpercentage.Substring(0, discpuntpercentage.IndexOf('.') + 3);

//                       txtIsValid.Text = "YES";
//                       //if (txtServiceCharge.Text.Trim() != "")
//                       //{
//                       //    decimal? servicecharge = Convert.ToDecimal(txtServiceCharge.Text.Trim());
//                       //    decimal? totalamt = servicecharge - objtblcoupanmaster.Coupon_Amt;

//                       //    string discountpercentage = Convert.ToString(txt_manualDiscountPrcntg.Text == "" ? "0" : txt_manualDiscountPrcntg.Text);
//                       //    string discountAmount = Convert.ToString((totalamt * Convert.ToDecimal(discountpercentage)) / 100);
//                       //    totalAmount.Text = Convert.ToString(totalamt - Convert.ToDecimal(discountAmount));

//                       //    CalculationAmount();
//                       //}


//                   }
//                   else
//                   {
//                       txtIsValid.Text = "NO";
//                       txtDiscount.Text = string.Empty;
//                   }

//               }
//               else if (txtDiscount.Text.Trim() != "")
//               {
//                   txtIsValid.Text = "NO";
//                   txtDiscount.Text = string.Empty;
//               }
//               else
//               {
//                   txtIsValid.Text = string.Empty;
//                   txtDiscount.Text = string.Empty;
//               }
//           }
//           else
//           {
//               txtIsValid.Text = "";
//               txtDiscount.Text = "";
//               txt_CouponDscnt.Text = "";
//               CalculationAmount();
//           }


//       }



/// code updated by sam on 13092016.........................
/// 

//bool IsValid = false;
//           decimal? due = default(decimal);
//           int i = default(int);
//           try
//           {
//               if (string.IsNullOrEmpty(txt_AmountReceived.Text.Trim()))
//               {
//                   if (txt_AmountReceived.Text == "0" || txt_AmountReceived.Text == "0.00" || txt_AmountReceived.Text == "")
//                   {
//                       MessageBox.Show("Please enter recevied amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                       return;
//                   }
//               }
//               else
//               {
//                   if (comboBox1.SelectedIndex > 0)
//                   {
//                       if (txt_AmountReceived.Text != "0" && txt_AmountReceived.Text != "0.00")
//                       {
//                           tblappointment tblapp1 = AppointmentsList.GetApppointmentByID(AppointmentId, branchID);

//                           tblapp1.DueAmount = 0;
//                           //tblapp1.AdvanceAmount = Convert.ToDecimal(totalAmount.Text);
//                           //tblapp1.PaymentType = "Full Paid";

//                           //decimal? advance = Convert.ToDecimal(txt_advance.Text.Trim()) + Convert.ToDecimal(txt_AmountReceived.Text.Trim());
//                           //tblapp1.AdvanceAmount = advance;
//                           //txt_advance.Text = Convert.ToString(advance);
//                           //if (txt_paymentstatus.Text == "Advanced Paid")
//                           //{
//                           //    tblapp1.AdvanceAmount += Convert.ToDecimal(txt_AmountReceived.Text);
//                           //    due = Math.Abs(Convert.ToDecimal(txtdue.Text.Trim()) - Convert.ToDecimal(txt_AmountReceived.Text.Trim()));
//                           //}
//                           //tblapp1.DueAmount = due;
//                           //txtdue.Text = Convert.ToString(due);
//                           //decimal? ReceivedAmt = Convert.ToDecimal(tblapp1.ReceivedAmount) + Convert.ToDecimal(txt_AmountReceived.Text.Trim());
//                           //tblapp1.ReceivedAmount = ReceivedAmt;

//                           //tblapp1.ReceivedAmount = Convert.ToDecimal(txt_AmountReceived.Text) + tblapp1.ReceivedAmount;
//                           tblapp1.BalanceAmount = (Convert.ToDecimal(txt_AmountReceived.Text) - Convert.ToDecimal(txtdue.Text)) + tblapp1.BalanceAmount;
//                           if (Convert.ToDecimal(txt_AmountReceived.Text.Trim()) >= Convert.ToDecimal(txtdue.Text.Trim()))
//                           {
//                               txtdue.Text = "0";
//                               tblapp1.DueAmount = Convert.ToDecimal(0);
//                               tblapp1.PaymentType = "Full Paid";
//                               tblapp1.AdvanceAmount = Convert.ToDecimal(totalAmount.Text);
//                           }
//                           else
//                           {
//                               txtdue.Text = Convert.ToString(due);
//                               tblapp1.DueAmount = due;
//                           }

//                           /*----------------------Code Added By Sandip Das on 08-06-2016---------------------*/
//                           if (comboBox1.SelectedItem == "CASH")
//                           {
//                               tblapp1.PaymentMode = Convert.ToString(comboBox1.SelectedItem);
//                               i = AppointmentsList.InsertUpdateAppointment(tblapp1);
//                           }
//                           else if (comboBox1.SelectedItem == "CARD")
//                           {
//                               if (string.IsNullOrEmpty(txtBankCardNo.Text.Trim()))
//                               {
//                                   MessageBox.Show("Please Enter Card No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                                   IsValid = false;
//                               }
//                               else if (string.IsNullOrEmpty(txtBankName.Text.Trim()))
//                               {
//                                   MessageBox.Show("Please Enter Bank Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                                   IsValid = false;
//                               }
//                               else { IsValid = true; }

//                           }
//                           else if (comboBox1.SelectedItem == "CREDIT")
//                           {
//                               tblapp1.PaymentMode = Convert.ToString(comboBox1.SelectedItem);
//                               i = AppointmentsList.InsertUpdateAppointment(tblapp1);
//                           }
//                           else
//                           {
//                               //MessageBox.Show("Payment Failed. Please select a payment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                           }
//                           if (IsValid)
//                           {
//                               tblapp1.PaymentMode = Convert.ToString(comboBox1.SelectedItem);
//                               tblapp1.BankCardNo_ = Convert.ToString(txtBankCardNo.Text.Trim());
//                               tblapp1.BankName = Convert.ToString(txtBankName.Text.Trim());

//                               i = AppointmentsList.InsertUpdateAppointment(tblapp1);
//                           }
//                           else
//                           {
//                               //tblapp1.PaymentMode = Convert.ToString(comboBox1.SelectedValue);
//                               //i = AppointmentsList.InsertUpdateAppointment(tblapp1);
//                           }
//                       }
//                       else
//                       {
//                           MessageBox.Show("Payment Failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                       }
//                   }
//                   /*-----------------------------------END---------------------------------*/
//                   if (i > 0)
//                   {
//                       MessageBox.Show("Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                       ClearField();
//                   }
//                   else
//                   {
//                       MessageBox.Show("Payment Failed. Please select a payment mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                   }
//               }

//           }
//           catch (Exception ex)
//           {
//               MessageBox.Show("Error Occoured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//           }


//



//private void GetTotalAmt()
//{
//    string[] total_items = new string[50];
//    int it = 0;
//    decimal totalamount = 0;
//    decimal prevtax = 0;
//    int? prevTime = 0;
//    txt_TotalTax.Text = "";
//if (lst_servicename.CheckedItems.Count > 0)
//{

//    foreach (tblservice li1 in lst_servicename.CheckedItems)
//    {
//        /*Total Amount Calculation Begin*/
//        string amt = Convert.ToString(li1.ServiceName);
//        int startind = amt.IndexOf(":") + 1;
//        int endind = amt.IndexOf(")", startind);
//        string rs = (amt.Substring(startind, endind - startind)).Trim();
//        totalamount = totalamount + Convert.ToDecimal(rs);
//        txtServiceCharge.Text = Convert.ToString(totalamount);
//        /*Total Amount Calculation End*/

//        /*Total Tax Calculation Begin*/
//        string sId = Convert.ToString(li1.ServiceId);
//        string tax_percentage = (TaxCalculate(Convert.ToInt32(sId)) == "" ? "0" : TaxCalculate(Convert.ToInt32(sId)));
//        prevtax = prevtax + Convert.ToDecimal(txt_TotalTax.Text == "" ? "0" : txt_TotalTax.Text);
//        txt_TotalTax.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(totalamount) * Convert.ToDecimal(tax_percentage)) / 100), 2) + prevtax);
//        /*Total Tax Calculation End*/

//        //int? tTime = TimeExpendeCalculate(Convert.ToInt32(sId));
//        //prevTime = prevTime + tTime;

//        //txt_timeExpende.Text = Convert.ToString(prevTime) + " Minutes";

//        /*---------------Code Added By Sandip Das on 09-06-2016----------------------*/
//        //DateTime stime = Convert.ToDateTime(ddlStartTime.SelectedItem);
//        //string t = stime.ToString("hh:mm tt");
//        //double timeAdd = Convert.ToDouble(prevTime);
//        //DateTime time = stime.AddMinutes(timeAdd);
//        //string t1 = time.ToString("hh:mm tt");
//        //DateTime tt = Convert.ToDateTime(t1);

//        //foreach (string item in ddlEndTime.Items)
//        //{
//        //    DateTime? dt = DateTime.Parse(item);
//        //    string t2 = item;
//        //    if (dt.Value.Ticks >= tt.Ticks)
//        //    {
//        //        //ddlEndTime.SelectedItem = t2;
//        //        ddlEndTime.SelectedIndex = ddlEndTime.FindString(t2);
//        //        break;
//        //    }
//        //}
//        /*----------------------------------END----------------------*/
//        CalculationAmount();
//    }
//}
//else
//{
//    txtServiceCharge.Text = string.Empty;
//    totalAmount.Text = string.Empty;
//    txt_GrossAmount.Text = string.Empty;
//    //txt_timeExpende.Text = string.Empty;
//    /*--------------------Code Added By Sandip Das ------------------------*/
//    //ddlStartTime.SelectedItem = "00:00 AM";
//    //ddlEndTime.SelectedItem = "00:00 AM";
//    txt_manualDiscountPrcntg.Text = "";
//    /*--------------------------END ------------------------*/
//}
//}


//
//else if (Convert.ToDecimal(txt_AmountReceived.Text.Trim()) < Convert.ToDecimal(txt_advance.Text.Trim()))
//{
//    MessageBox.Show("Tender Amount should be more than Advance Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//    txt_AmountReceived.Text = "";
//    return false;
//}
//}
//else if (comboBox1.SelectedItem == "CARD")
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

///*-------------------------------------END---------------------------------------------*/
//else
//{
//    return true;
//}



// private string TaxCalculate(int id)
//{
//    string amount = objSettingDAL.GetTaxToatlAmount(id, branchID);
//    return amount;
//}