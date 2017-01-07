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
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, chkLsFormula);
            objFrmName = "Tax / Charges configuration";
            SirchGridFormat();
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

            CommonCL.PanelControlGotFocus(chkLsFormula, pnlTabControlSearch);
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

            CommonCL.PanelControlGotFocus(chkLsFormula, pnlTabControlSearch);
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

            //TnSname.Enabled = true;
            ddlSTax.Enabled = true;
            ddladdSub.Enabled = true;
            //ddlFormula.Enabled = true;
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

            //TnSname.Text = "";
            ddlSTax.Text = "";
            ddladdSub.Text = "";
            //ddlFormula.Text = "";
            txtPer.Text = "";
            txtVal.Text = "";
            ddlType.Text = "";
            txtActive.Text = "Y";           

        }
        public void SubCtrlClear()
        {
            //TnSname.Text = "";
            ddlSTax.Text = "";
            ddladdSub.Text = "";
            //ddlFormula.Text = "";
            txtPer.Text = "";
            txtVal.Text = "";
            ddlType.Text = "";
            txtActive.Text = "Y";
        }

        public void formCtrlActiveN()
        {
            txtConfigNm.Enabled = true;
            txtHdActiveYN.Enabled = true;

            //TnSname.Enabled = true;
            ddlSTax.Enabled = true;
            ddladdSub.Enabled = true;
            //ddlFormula.Enabled = true;
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
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, chkLsFormula);

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
     
        #region KeybordControl
        private void txtConfigNm_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtHdActiveYN, e);
        }

        private void txtHdActiveYN_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubAdd, e);
        }

        private void btnSubAdd_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtTnSname, e);
        }
        private void txtTnSname_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlSTax, e);
        }
        //private void ddlName_KeyUp(object sender, KeyEventArgs e)
        //{
            
        //}

        private void ddlSTax_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddladdSub, e);
        }

        private void ddladdSub_KeyUp(object ddladdSub, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtTnSname, e);
        }
        //private void txtTnSname_KeyUp(object sender, KeyEventArgs e)
        //{
        //    CommonCL.TextBoxGotFocus(txtPer, e);
        //}
       

        private void txtPer_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtVal, e);
        }

        private void txtVal_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlType, e);
        }

        private void ddlType_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubSave, e);
        }

        private void btnSubSave_KeyUp(object sender, KeyEventArgs e)
        {
            //CommonCL.ComboBoxGotFocus(TnSname , e);
        }

        #endregion

        private void btnSubSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSubForm())
                {
                    //SubSaveUpdate();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private bool ValidateSubForm()
        {

            if (txtHidCode.Text == "")
            {
                txtHidCode.Text = "0";
            }

            //if (TnSname.SelectedValue == null || TnSname.SelectedValue.ToString() == "")
            //{
            //    MessageBox.Show("Please enter Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (ddlSTax.SelectedValue == null || ddlSTax.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter S. Tax.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddladdSub.Text .ToString ()=="")
            {
                MessageBox.Show("Please enter S. Tax.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (ddlFormula.Text.ToString() == "")
            //{
            //    MessageBox.Show("Please enter Formula.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (txtPer.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Qty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (txtVal.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (txtHdActiveYN.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            else
            {
                return true;
            }
        }

        private void grdDtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ChkListLoad()
        {
            int iRowCnt = 0;

            chkListFormula.Items.Clear();

            //foreach (DataRow row_1 in ds.Tables["BookName"].Rows)
            //{
            //    row = row_1;
            //    chkLsFormula.Items.Add(ds.Tables["BookName"].Rows[iRowCnt][1]);
            //    iRowCnt = iRowCnt + 1;
            //}

            //chkLsFormula.l
            //DtGridChkList.Rows.Clear();
            //DtGridChkList.Rows.Add();
            //DtGridChkList["Chk", 0].Value = true;
            //DtGridChkList["slno2", 0].Value = "0e";
            //DtGridChkList["Earnings2", 0].Value = "None";
            //DtGridChkList["ShortName2", 0].Value = "None";


            for (int i = 0; i < grdDtl.Rows.Count; i++)
            {
                //DtGridChkList.Rows.Add();

                //DtGridChkList["slno2", (i + 1)].Value = grdDtl["SlNo", i].Value.ToString();
                //DtGridChkList["Earnings2", (i + 1)].Value = grdDtl["Earnings", i].Value.ToString();
                ////DtGridChkList["ShortName2", (i + 1)].Value = grdDtl["ShortName", i].Value.ToString();
            }
        }



    }
}
