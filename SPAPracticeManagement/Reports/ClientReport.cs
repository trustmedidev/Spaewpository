using DataAccessLayer;
using SPAPracticeManagement.AppConstants;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement;
using DataAccessLayer.Repository;

namespace SPAPracticeManagement.Reports
{
    public partial class ClientReport : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
        //public ClientDAL ClientList 
        public ClientDAL ClientList
        {
            get { return new ClientDAL(); }
        }

        string name = "";

        int? billsno = 0;
        string pmode = "";
        string cname = "";
        string type = "";

        List<bool> SelTypeList = new List<bool>();
        List<int> billsList = new List<int>();
        List<string> PaymentMode = new List<string>();
        List<string> ClientsList = new List<string>();

        List<ClientEL> result = new List<ClientEL>();

        SettingDAL objSettingDAL = new SettingDAL();
        AppointmentDAL ObjAppointmentDAL = new AppointmentDAL();

        public ClientReport()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //label7.Visible = false;
            //ddlServiceType.Visible = false;
            BindAccountGrid();

            BindServiceType();
            //BindDoctor();
            BindClients();
            BindBills();

            //if (radio_package.Checked)
            //{
            //    ddlServiceType.Enabled = false;
            //    //drNameDrp.Enabled = true;
            //}
            //else
            //{
            //    ddlServiceType.Enabled = true;
            //    //drNameDrp.Enabled = false;
            //}
            //BindAccountGrid();
            //BindServiceType();
            //cmb_paymode.SelectedIndex = 0;
        }

        #region Methods
        private void BindClients()
        {
            List<ClientEL> result = ClientList.GetAllClient(branchID).GroupBy(g=>g.ClientName).Select(s=>s.FirstOrDefault()).ToList();
            if (result.Count > 0)
            {
                chk_clients.DataSource = result;
                chk_clients.DisplayMember = "ClientName";
                chk_clients.ValueMember = "ClientId";
            }
        }
        private void BindBills()
        {
            List<ClientEL> result = ClientList.GetAllAppointmentId(branchID).ToList();
            if (result.Count > 0)
            {
                chk_billsno.DataSource = result;
                chk_billsno.DisplayMember = "AppId";
                chk_billsno.ValueMember = "AppId";
            }
        }

        private void BindGridByFilter()
        {
            DateTime? fdt = null;
            DateTime? tdt = null;

            if (txtFromDate.Checked)
            {
                fdt = txtFromDate.Value;
            }
            if (txtToDate.Checked)
            {
                tdt = txtToDate.Value;
            }

            var ret = ClientList.GetReportByParam(branchID, fdt, tdt, SelTypeList, ClientsList, PaymentMode, billsList).ToList();

            if (ret.Count > 0)
            {
                dgApplicantList.AutoGenerateColumns = false;

                if(chk_clear.Checked == true && chk_due.Checked == false && chk_discount.Checked == false)    
                {
                    dgApplicantList.DataSource = ret.Where(w=>w.Due == 0).ToList();
                }
                else if(chk_clear.Checked == false && chk_due.Checked == true && chk_discount.Checked == false)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Due != 0).ToList();
                }
                else if (chk_clear.Checked == false && chk_due.Checked == false && chk_discount.Checked == true)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Discount != 0).ToList();
                }
                else if (chk_clear.Checked == true && chk_due.Checked == true && chk_discount.Checked == true)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Discount != 0).ToList();
                }
                else if (chk_clear.Checked == true && chk_due.Checked == false && chk_discount.Checked == true)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Discount != 0 && w.Due == 0).ToList();
                }
                else if (chk_clear.Checked == true && chk_due.Checked == false && chk_discount.Checked == true)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Discount != 0).ToList();
                }
                else if (chk_clear.Checked == true && chk_due.Checked == true && chk_discount.Checked == false)
                {
                    dgApplicantList.DataSource = ret.ToList();
                }
                else if (chk_clear.Checked == false && chk_due.Checked == true && chk_discount.Checked == true)
                {
                    dgApplicantList.DataSource = ret.Where(w => w.Discount != 0 && w.Due != 0).ToList();
                }
                else
                {
                    dgApplicantList.DataSource = ret;
                }
            }
            else { dgApplicantList.DataSource = null; }            
            
            int? billcount = 0;
            decimal? amount = default(decimal);
            decimal? due = default(decimal);
            decimal? discount = default(decimal);

            decimal? cash = default(decimal);
            decimal? card = default(decimal);
            decimal? credit = default(decimal);

            for (int i = 0; i < dgApplicantList.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgApplicantList.Rows[i].Cells["BillNo"].Value) != 0)
                {
                    billcount++;
                }
                
                amount += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                due += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Due"].Value);
                discount += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Discount"].Value);

                if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value) == "CASH")
                {
                    cash += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
                else if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value) == "CARD")
                {
                    card += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
                else if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value) == "CREDIT")
                {
                    credit += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
            }

            lbl_billno.Text = Convert.ToString(billcount);
            lbl_amount.Text = Convert.ToString(amount);
            lbl_due.Text = Convert.ToString(due);
            lbl_discount.Text = Convert.ToString(discount);

            lbl_cash.Text = Convert.ToString(cash);
            lbl_card.Text = Convert.ToString(card);
            lbl_credit.Text = Convert.ToString(credit);
        }
        private void BindAccountGrid()
        {
            result = ClientList.GetAllClientReport(branchID).ToList();
            if (result.Count > 0)
            {
                dgApplicantList.AutoGenerateColumns = false;
                dgApplicantList.DataSource = result;
            }

            
            int? billcount = 0;
            decimal? amount = default(decimal);
            decimal? due = default(decimal);
            decimal? discount = default(decimal);

            decimal? cash = default(decimal);
            decimal? card = default(decimal);
            decimal? credit = default(decimal);

            for (int i = 0; i < dgApplicantList.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgApplicantList.Rows[i].Cells["BillNo"].Value) != 0)
                {
                    billcount++;
                }
                
                amount += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                due += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Due"].Value);
                discount += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Discount"].Value);

                if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value).ToUpper() == "CASH")
                {
                    cash += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
                else if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value).ToUpper() == "CARD")
                {
                    card += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
                else if (Convert.ToString(dgApplicantList.Rows[i].Cells["ModeOfPayment"].Value).ToUpper() == "CREDIT")
                {
                    credit += Convert.ToInt32(dgApplicantList.Rows[i].Cells["Amount"].Value);
                }
            }

            lbl_billno.Text = Convert.ToString(billcount);
            lbl_amount.Text = Convert.ToString(amount);
            lbl_due.Text = Convert.ToString(due);
            lbl_discount.Text = Convert.ToString(discount);

            lbl_cash.Text = Convert.ToString(cash);
            lbl_card.Text = Convert.ToString(card);
            lbl_credit.Text = Convert.ToString(credit);
        }

        //private void BindAccountGrid()
        //{
        //    dgApplicantList.AutoGenerateColumns = false;
        //    dgApplicantList.DataSource = ClientList.GetAllClientByBranchId(branchID);
        //}

        private void BindServiceType()
        {
            try
            {
                //ddlServiceType.DataSource = null;
                //ddlServiceType.DisplayMember = "ServiceName"; // Column Name
                //ddlServiceType.ValueMember = "ServiceId";
                //ddlServiceType.DataSource = objSettingDAL.GetAllServices(branchID);
            }
            catch (Exception ex)
            {
            }
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

            if (chk_allclients.Checked == true)
            {
                chk_allclients.Checked = false;
            }
            count = chk_clients.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_clients.CheckedItems.Count > 0)
                {
                    chk_clients.SetItemChecked(i, false);
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

            if (checkBox5.Checked == true)
            {
                checkBox5.Checked = false;
            }
            count = chk_billsno.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (chk_billsno.CheckedItems.Count > 0)
                {
                    chk_billsno.SetItemChecked(i, false);
                }
            }
            if (chk_all.Checked == true)
            {
                chk_all.Checked = false;
            }
            if (chk_due.Checked == true)
            {
                chk_due.Checked = false;
            }
            if (chk_discount.Checked == true)
            {
                chk_discount.Checked = false;
            }
            if (chk_bill.Checked == true)
            {
                chk_bill.Checked = false;
            }
        }

        #endregion Methods

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            BindAccountGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridByFilter();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Common.ExportToExcel(dgApplicantList))
            {
                MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radio_service_CheckedChanged(object sender, EventArgs e)
        {
            //if (radio_service.Checked == true)
            //{
            //    label7.Visible = true;
            //    ddlServiceType.Visible = true;
            //    label7.Text = "Service Type :";
            //    BindServiceType();
            //    BindAccountGrid();
            //}
        }

        private void radio_package_CheckedChanged(object sender, EventArgs e)
        {
            //if (radio_package.Checked == true)
            //{
            //    label7.Visible = true;
            //    ddlServiceType.Visible = true;
            //    label7.Text = "Package Type";
            //    BindPackageName();
            //    BindAccountGrid();
            //}
        }

        public void BindPackageName()
        {
            try
            {
                List<tblpackage> objtblpackage = new List<tblpackage>();
                objtblpackage.Insert(0, new tblpackage() { Id = 0, Package_Name = "Select Package" });

                var pkglist = ObjAppointmentDAL.GetAllPackage(branchID);
                if (pkglist != null)
                {
                    foreach (tblpackage pkg in pkglist)
                    {
                        objtblpackage.Add(pkg);
                    }
                }
                //ddlServiceType.DataSource = null;
                //ddlServiceType.DisplayMember = "Package_Name";
                //ddlServiceType.ValueMember = "Id";
                //ddlServiceType.DataSource = objtblpackage;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void radio_all_CheckedChanged(object sender, EventArgs e)
        {
            //if (radio_all.Checked == true)
            //{
            //    label7.Visible = false;
            //    ddlServiceType.Visible = false;
            //    BindAccountGrid();
            //}
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            //AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //List<ClientEL> objClientlist = ClientList.GetAllClientByClientName(txtClientName.Text.Trim(), branchID);
            ////List<PatientEL> objPatientList = ClientList.GetAllClientByClientName(txtPatientName.Text.Trim(), branchID);

            //foreach (var item in objClientlist)
            //{
            //    //namesCollection.Add(item.PatientName + " (PatientId: " + item.PatientId + ")");
            //    namesCollection.Add(item.ClientName);
            //}
            //txtClientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtClientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtClientName.AutoCompleteCustomSource = namesCollection;
        }
       
        private void chk_allsel_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allsel.Checked)
            {
                name = "";
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
                    name = "";
                    for (int n = 0; n < chk_seltype.Items.Count; n++)
                    {
                        chk_seltype.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_allclients_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allclients.Checked)
            {
                name = "";
                for (int n = 0; n < chk_clients.Items.Count; n++)
                {
                    chk_clients.SetItemChecked(n, true);
                }
                ClientsList.Clear();
                string cname = "";
                foreach (var itemchecked in chk_clients.CheckedItems)
                {
                    var row = (itemchecked as ClientEL);
                    cname = (string)row.ClientName;
                    ClientsList.Add(cname);
                }
            }
            else
            {
                ClientsList.Clear();
                if (chk_clients.CheckedItems.Count < chk_clients.Items.Count)
                {
                    chk_allclients.Checked = false;
                }
                else
                {
                    name = "";
                    for (int n = 0; n < chk_clients.Items.Count; n++)
                    {
                        chk_clients.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_allpayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_allpayment.Checked)
            {
                name = "";
                for (int n = 0; n < chk_paymentmode.Items.Count; n++)
                {
                    chk_paymentmode.SetItemChecked(n, true);
                }
                PaymentMode.Clear();
                string pmode = "";
                foreach (var itemchecked in chk_paymentmode.CheckedItems)
                {
                    pmode = (string)itemchecked;
                    PaymentMode.Add(pmode.Substring(3));
                }
            }
            else
            {
                PaymentMode.Clear();
                if (chk_paymentmode.CheckedItems.Count < chk_paymentmode.Items.Count)
                {
                    chk_allpayment.Checked = false;
                }
                else
                {
                    name = "";
                    for (int n = 0; n < chk_paymentmode.Items.Count; n++)
                    {
                        chk_paymentmode.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                name = "";
                for (int n = 0; n < chk_billsno.Items.Count; n++)
                {
                    chk_billsno.SetItemChecked(n, true);
                }
                billsList.Clear();
                int billsno = 0;
                foreach (var itemchecked in chk_billsno.CheckedItems)
                {
                    var row = (itemchecked as ClientEL);
                    billsno = Convert.ToInt32(row.AppId);
                    billsList.Add(billsno);
                }
            }
            else
            {
                billsList.Clear();
                if (chk_billsno.CheckedItems.Count < chk_billsno.Items.Count)
                {
                    checkBox5.Checked = false;
                }
                else
                {
                    name = "";
                    for (int n = 0; n < chk_billsno.Items.Count; n++)
                    {
                        chk_billsno.SetItemChecked(n, false);
                    }
                }
            }
        }

        private void chk_seltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelTypeList.Clear();
            bool type = default(bool);
            foreach (var itemchecked in chk_seltype.CheckedItems)
            {
                //type = (string)itemchecked;
                if (itemchecked.ToString().Substring(3) == "Service")
                {
                    type = false;
                }
                else { type = true; }
                SelTypeList.Add(type);
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

        private void chk_clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientsList.Clear();
            string cname = "";
            foreach (var itemchecked in chk_clients.CheckedItems)
            {
                var row = (itemchecked as ClientEL);
                cname = (string)row.ClientName;
                ClientsList.Add(cname);
            }

            if (chk_clients.CheckedItems.Count == chk_clients.Items.Count)
            {
                chk_allclients.Checked = true;
            }
            else
            {
                chk_allclients.Checked = false;
            }
        }

        private void chk_paymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentMode.Clear();
            string pmode = "";
            foreach (var itemchecked in chk_paymentmode.CheckedItems)
            {
                pmode = (string)itemchecked;
                PaymentMode.Add(pmode.Substring(3));
            }
            if (chk_paymentmode.CheckedItems.Count == chk_paymentmode.Items.Count)
            {
                chk_allpayment.Checked = true;
            }
            else
            {
                chk_allpayment.Checked = false;
            }
        }

        private void chk_billsno_SelectedIndexChanged(object sender, EventArgs e)
        {
            billsList.Clear();
            int billsno = 0;
            foreach (var itemchecked in chk_billsno.CheckedItems)
            {
                var row = (itemchecked as ClientEL);
                billsno = Convert.ToInt32(row.AppId);
                billsList.Add(billsno);
            }
            if (chk_billsno.CheckedItems.Count == chk_billsno.Items.Count)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all.Checked == true)
            {
                chk_clear.Checked = true;
                chk_due.Checked = true;
                dgApplicantList.DataSource = result.ToList();
            }
        }

        private void chk_clear_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_due_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_discount_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_bill_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
