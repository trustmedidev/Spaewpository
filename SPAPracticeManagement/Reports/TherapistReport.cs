using DataAccessLayer;
using EntityLayer;
using SPAPracticeManagement.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Reports
{
    public partial class TherapistReport : Dashboard
    {
        int? branchID = AppsPropertise.UserDetails.BranchId;
        ReportDAL reportDAL = new ReportDAL();
        public TherapistReport()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            GetTherapist();
            BindGrid();
        }
        private void BindGrid()
        {
            var query = reportDAL.GetTherapistList(branchID);
            if (query.Count > 0)
            {
                dgThpList.AutoGenerateColumns = false;
                dgThpList.DataSource = query;
            }
            else
            {
                dgThpList.DataSource = null;
            }

            decimal Total = 0;
            decimal Commission = 0;
            for (int i = 0; i < dgThpList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgThpList.Rows[i].Cells["TotalAmount"].Value);
                Commission += Convert.ToDecimal(dgThpList.Rows[i].Cells["TherapistAmount"].Value);
            }

            lblTotAmt.Text = Convert.ToString(Math.Round(Total,2));
            lblThpAmt.Text = Convert.ToString(Math.Round(Commission,2));
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Common.ExportToExcel(dgThpList))
            {
                MessageBox.Show("Data exported successfully.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFromDate.Value = DateTime.Now;
            txtToDate.Value = DateTime.Now;
            txtFromDate.Checked = false;
            txtToDate.Checked = false;
            txtThpName.Text = string.Empty;
            //lblTotAmt.Text = string.Empty;
            //lblThpAmt.Text = string.Empty;
            //lblTotAmt.Visible = false;
            //lblThpAmt.Visible = false;
            BindGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            string thpname = txtThpName.Text.Trim();

            var query = reportDAL.SearchTherapist(thpname, fdt, tdt, branchID).ToList();
            if (query.Count > 0)
            {
                dgThpList.AutoGenerateColumns = false;
                dgThpList.DataSource = query;
            }
            else
            {
                dgThpList.DataSource = null;
            }

            decimal Total = 0;
            decimal Commission = 0;
            for (int i = 0; i < dgThpList.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgThpList.Rows[i].Cells["TotalAmount"].Value);
                Commission += Convert.ToDecimal(dgThpList.Rows[i].Cells["TherapistAmount"].Value);
            }

            lblTotAmt.Text = Convert.ToString(Math.Round(Total, 2));
            lblThpAmt.Text = Convert.ToString(Math.Round(Commission, 2));
        }

        private void txtThpName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void GetTherapist() {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<TherapistEL> objClintList = reportDAL.GetThpNameList(txtThpName.Text.Trim(), branchID);
            //List<PatientEL> objPatientList = ClientList.GetAllPatientByPatientName(txtPatientName.Text.Trim(),branchID);

            foreach (var item in objClintList)
            {
                namesCollection.Add(item.Name);
            }
            txtThpName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtThpName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtThpName.AutoCompleteCustomSource = namesCollection;
        }
    }
}
