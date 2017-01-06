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
namespace SPAPracticeManagement.InventoryMaster
{     
    public partial class frmTaxOrServicesConfig : InventoryDashboard
    {

        #region === Variables
        Boolean falag = true;
        //BOMentryDAL objBOMentryDAL = new BOMentryDAL();
        //ItemDAL objItemDAL = new ItemDAL();
        //ServiceDAL objServiceDAL = new ServiceDAL();
        //UnitDAL objUnitDAL = new UnitDAL();
        //SuppliorDAL objSuppliorDAL = new SuppliorDAL();

        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmTaxOrServicesConfig()
        {
            InitializeComponent();
        }

        private void frmTaxOrServicesConfig_Load(object sender, EventArgs e)
        {

        }

        #region Form Format

        public override void AddFormat()
        {
            lblTag.Text = "Add " + objFrmName.ToString() + " Detail";
            btnSave.Top = 500;
            btnSave.Left = 445;
            btnClear.Top = 500;
            btnClear.Left = 520;
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
            //btnUpdate.Top = 500;
            //btnUpdate.Left = 445;
            btnSave.Top = 500;
            btnSave.Left = 445;
            btnClear.Top = 500;
            btnClear.Left = 520;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 500;
            btnUpdate.Left = 445;
            btnClear.Top = 500;
            btnClear.Left = 520;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            txtConfigNm.Enabled = true;
            txtHdActiveYN.Enabled = true;

            ddlName.Enabled = true;
            ddlSTax.Enabled = true;
            ddladdSub.Enabled = true;
            ddlFormula.Enabled = true;
            txtPer.Enabled = true;
            txtVal.Enabled = true;
            ddlType.Enabled = true;
            txtActive.Enabled = true;

            //this.ddlService.Enabled = true;
            //this.txtPkgDisc.Enabled = true;
            //this.ddlItem.Enabled = true;
            //this.ddlIssUnit.Enabled = true;
            //this.txtQty.Enabled = true;
            //this.txtRate.Enabled = true;
            //this.txtActive.Enabled = true;
            this.grdDtl.Enabled = true;
            this.txtHdActiveYN.Enabled = true;
            ActiveControl = txtConfigNm;
        }

        public void formCtrlClear()
        {
            txtConfigNm.Text = "";
            txtHdActiveYN.Text = "Y";

            ddlName.Text = "";
            ddlSTax.Text = "";
            ddladdSub.Text = "";
            ddlFormula.Text = "";
            txtPer.Text = "";
            txtVal.Text = "";
            ddlType.Text = "";
            txtActive.Text = "Y";           

        }
        public void SubCtrlClear()
        {
            ddlName.Text = "";
            ddlSTax.Text = "";
            ddladdSub.Text = "";
            ddlFormula.Text = "";
            txtPer.Text = "";
            txtVal.Text = "";
            ddlType.Text = "";
            txtActive.Text = "Y";
        }

        public void formCtrlActiveN()
        {
            txtConfigNm.Enabled = true;
            txtHdActiveYN.Enabled = true;

            ddlName.Enabled = true;
            ddlSTax.Enabled = true;
            ddladdSub.Enabled = true;
            ddlFormula.Enabled = true;
            txtPer.Enabled = true;
            txtVal.Enabled = true;
            ddlType.Enabled = true;
            txtActive.Enabled = true;

            //this.ddlService.Enabled = false;
            //this.txtPkgDisc.Enabled = false;
            //this.ddlItem.Enabled = false;
            //this.ddlIssUnit.Enabled = false;
            //this.txtQty.Enabled = false;
            //this.txtRate.Enabled = false;
            this.grdDtl.Enabled = false;
            this.txtHdActiveYN.Enabled = false;
            this.txtActive.Enabled = false;

        }

        public override void SirchGridFormat()
        {
            try
            {
                //objBOMentryDAL.BindList(grdSearch);

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
