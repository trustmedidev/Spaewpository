using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccessLayer;
using DataAccessLayer.Repository;
using System.Data.Entity;
using EntityLayer;
namespace SPAPracticeManagement.InventoryTransaction
{
    public partial class frmPurchaseOrder : InventoryDashboard
    {

        #region === Variables
        Boolean falag = true;
        InventoryMasterDAL objInventoryMasterDAL = new InventoryMasterDAL();
        ItemDAL objItemDAL = new ItemDAL();
        UnitDAL objUnitDAL = new UnitDAL();
        UserDAL objUserDAL = new UserDAL();
        DataView dv;
        string objFrmName = string.Empty;

        #endregion

        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            objItemDAL.BindDdlItem(ddlItem);
            objUnitDAL.BindDdlUnitGrp(ddlUnit);
            objUserDAL.BindDdlAllUser(ddlUser);

            objInventoryMasterDAL.BindBranch(ddlBranch);
            objFrmName = "Purchase Order";
            SirchGridFormat();
        }

        #region Set Shortcut
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                falag = false;
                return true;
            }
            if (keyData == Keys.F1)
            {
                AddFormat();
                return true;
            }
            if (keyData == Keys.F2)
            {
                EditFormatActiveY();
                return true;
            }
            if (keyData == Keys.F3)
            {
                SirchGridFormat();
                return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                AddFormat();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.A))
            {
                AddFormat();
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                EditFormatActiveY();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.E))
            {
                EditFormatActiveY();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                falag = false;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
            btnSave.Top = 540;
            btnSave.Left = 1000;
            btnClear.Top = 540;
            btnClear.Left = 1080;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            formCtrlClear();

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();

        }
        public override void EditFormatActiveY()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 520;
            btnUpdate.Left = 645;
            btnClear.Top = 520;
            btnClear.Left = 720;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 520;
            btnUpdate.Left = 645;
            btnClear.Top = 520;
            btnClear.Left = 720;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.StockDt.Enabled = true;
            this.ddlBranch.Enabled = true;
            this.ddlUser.Enabled = true;
            this.ddlItem.Enabled = true;
            this.ddlUnit.Enabled = true;
            this.txtQty.Enabled = true;
            this.txtActive.Enabled = true;
            this.grdDtl.Enabled = true;


            ActiveControl = StockDt;
        }

        public void formCtrlClear()
        {
            this.StockDt.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            this.ddlBranch.Text = "";
            this.ddlSupplier.Text = "";
            this.ddlItem.Text = "";
            this.ddlUnit.Text = "";
            this.txtQty.Text = "";
            this.txtActive.Text = "Y";
            grdDtl.Rows.Clear();

        }
        public void SubCtrlClear()
        {
            ddlItem.Text = "";
            //ddlIssUnit.Text = "";
            txtQty.Text = "";
            //txtRate.Text = "";
        }

        public void formCtrlActiveN()
        {
            this.StockDt.Enabled = false;
            this.ddlBranch.Enabled = false;
            this.ddlUser.Enabled = false;
            this.ddlItem.Enabled = false;
            this.ddlUnit.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtActive.Enabled = false;
            this.grdDtl.Enabled = false;


        }

        public override void SirchGridFormat()
        {
            try
            {
                ////objBOMentryDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                //grdSearch.Columns[0].Visible = false;


                //grdSearch.Columns[1].Width = 100;
                //grdSearch.Columns[2].Width = 150;
                //grdSearch.Columns[3].Width = 270;
                //grdSearch.Columns[4].Width = 150;
                //grdSearch.Columns[5].Width = 150;
                //grdSearch.Columns[6].Width = 150;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
        #endregion       
    }
}
