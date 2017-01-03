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

    public partial class frmBOM : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        BOMentryDAL objBOMentryDAL = new BOMentryDAL();
        ItemDAL objItemDAL = new ItemDAL();
        ServiceDAL objServiceDAL = new ServiceDAL();
        UnitDAL objUnitDAL = new UnitDAL();
        SuppliorDAL objSuppliorDAL = new SuppliorDAL();

        DataView dv;
        string objFrmName = string.Empty;

        #endregion
        public frmBOM()
        {
            InitializeComponent();
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

            objItemDAL.BindDdlItem(ddlItem);
            objUnitDAL.BindDdlUnitGrp(ddlIssUnit);
            objServiceDAL.BindDdlService(ddlService);
            objFrmName = "Bill Of Material";
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

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();

        }
        public override void EditFormatActiveY()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 500;
            btnUpdate.Left = 445;
            btnClear.Top = 500;
            btnClear.Left = 520;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
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
            this.ddlService.Enabled = true;
            this.txtPkgDisc.Enabled = true;
            this.ddlItem.Enabled = true;
            this.ddlIssUnit.Enabled = true;
            this.txtQty.Enabled = true;
            this.txtRate.Enabled = true;
            this.txtActive.Enabled = true;
            this.grdDtl.Enabled = true;

            ActiveControl = ddlService;
        }

        public void formCtrlClear()
        {
            this.ddlService.Text = "";
            this.txtPkgDisc.Text = "";
            this.ddlItem.Text = "";
            this.ddlIssUnit.Text = "";
            this.txtQty.Text = "";
            this.txtRate.Text = "";
            this.txtActive.Text = "Y";

            grdDtl.Rows.Clear();

        }
        public void SubCtrlClear()
        {
            ddlItem.Text = "";
            ddlIssUnit.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
        }

        public void formCtrlActiveN()
        {
            this.ddlService.Enabled = false;
            this.txtPkgDisc.Enabled = false;
            this.ddlItem.Enabled = false;
            this.ddlIssUnit.Enabled = false;
            this.txtQty.Enabled = false;
            this.txtRate.Enabled = false;
            this.grdDtl.Enabled = false;
            this.txtActive.Enabled = false;

        }

        public override void SirchGridFormat()
        {
            try
            {
                objBOMentryDAL.BindList(grdSearch);

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }


        #region KeybordControl
        private void ddlService_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtPkgDisc, e);
        }

        private void txtPkgDisc_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtHdActiveYN, e);
        }

        private void txtHdActiveYN_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubAdd, e);
        }

        private void btnSubAdd_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlItem, e);
        }
        private void ddlItem_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ComboBoxGotFocus(ddlIssUnit, e);
        }

        private void ddlIssUnit_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtQty, e);
        }

       
        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtRate, e);
        }
        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubSave, e);
        }

        private void btnSubSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSubAdd, e);
        }

        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            ActiveControl = ddlItem;
        }
        #endregion

        #region GridFunctions
        private void btnSave_Click(object sender, EventArgs e)
        {

            int i = InsertUpdateDelete();

            if (i > 0)
            {
                if (grdDtl .Rows.Count  != 0)
                {
                    
                    for (int j = 0; j < grdDtl.Rows.Count; j++)
                    {
                        tblbomdetail objtblbomdetail = new tblbomdetail();
                        objtblbomdetail.BOM_Cd = Convert.ToInt32(i.ToString());
                        objtblbomdetail.Code = Convert.ToInt32(grdDtl.Rows[j].Cells["code"].Value.ToString());
                        objtblbomdetail.ItemCd = Convert.ToInt32(grdDtl.Rows[j].Cells["ItemCd"].Value.ToString());
                        objtblbomdetail.UnitCd = Convert.ToInt32(grdDtl.Rows[j].Cells["UnitCd"].Value.ToString());
                        objtblbomdetail.Qty = Convert.ToDecimal(grdDtl.Rows[j].Cells["Qty"].Value.ToString());
                        objtblbomdetail.Rate = Convert.ToDecimal(grdDtl.Rows[j].Cells["Rate"].Value.ToString());
                        objtblbomdetail.ActiveYN = true;
                        objtblbomdetail.EntryDate = DateTime.Now;
                        objtblbomdetail.UserCode = GlobalCL.UserCD;

                        objBOMentryDAL.InsertUpdateBOMdetai(objtblbomdetail);
                    }

                }
            }

        }
        public void SubSaveUpdate()
        {
            Boolean check_gd = false;
            for (int p = 0; p < grdDtl.Rows.Count; p++)
            {
                string V_ItemCd = grdDtl["ItemCd", p].Value.ToString();
                if (ddlItem.SelectedValue.ToString() == V_ItemCd.ToString())
                {
                    check_gd = true;
                    
                    grdDtl["ItemCd", p].Value = ddlItem.SelectedValue.ToString();
                    grdDtl["Qty", p].Value = txtQty.Text .ToString();
                    grdDtl["UnitCd", p].Value = ddlIssUnit.SelectedValue.ToString();
                    grdDtl["Rate", p].Value = txtRate.Text.ToString();
                    grdDtl["Item", p].Value = ddlItem.Text .ToString();
                    grdDtl["Unit", p].Value = ddlIssUnit.Text.ToString();

                    SubCtrlClear();
                    grdDtl.Refresh();
                    btnSubAdd.Focus();
                    return;
                }
                else
                {
                    check_gd = false;
                }
            }
            //==============================================================================================
            if (check_gd == false)
            {
                try
                {
                    if (txtGrdRowIndex.Text == "")
                    {
                        int row = 0;

                        grdDtl.Rows.Add();
                        row = grdDtl.Rows.Count-1;
                        grdDtl["code", row].Value = "0";
                        grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlIssUnit.SelectedValue.ToString();
                        grdDtl["Rate", row].Value = txtRate.Text.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Unit", row].Value = ddlIssUnit.Text.ToString();

                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                        return;
                    }
                    else
                    {
                        int row = Convert.ToInt32(txtGrdRowIndex.Text.ToString());

                        grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        grdDtl["UnitCd", row].Value = ddlIssUnit.SelectedValue.ToString();
                        grdDtl["Rate", row].Value = txtRate.Text.ToString();
                        grdDtl["Item", row].Value = ddlItem.Text.ToString();
                        grdDtl["Unit", row].Value = ddlIssUnit.Text.ToString();

                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                        return;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }


            }
        }

        private void btnSubSave_Click(object sender, EventArgs e)
        {
            SubSaveUpdate();
        }

        #endregion

        #region Insert/Update
        private bool ValidateForm()
        {

            if (txtHidCode.Text  ==  "")
            {
                txtHidCode.Text  ="0";
            }

            if (ddlItem.SelectedValue == null || ddlItem.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPkgDisc.Text.Trim() == "")
            {
                MessageBox.Show("Please enter package description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
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
        public  int InsertUpdateDelete()
        {
            int r = 0;

            try
            {
                //int i = default(int);
                //bool IsValid = false;

                tblbomheader objtblbomheader = new tblbomheader();
                tblbomdetail objtblbomdetail = new tblbomdetail();

                if (ValidateForm())
                {
                   

                    objtblbomheader.Code=Convert.ToInt32(txtHidCode.Text .ToString());
                    objtblbomheader.ServiceCd=Convert.ToInt32(ddlService.SelectedValue.ToString ());
                    objtblbomheader.PackageDescription=txtPkgDisc.Text .ToString ();
                    objtblbomheader.ActiveYN = true;
                    objtblbomheader.EntryDate = DateTime.Now;
                    objtblbomheader.UserCode = GlobalCL.UserCD;

                    //objtblbomdetail.ActiveYN = false;

                    r = objBOMentryDAL.InsertUpdateBOMheader(objtblbomheader,objtblbomdetail);
                    
                }
                return r;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error Occoured. Please enter correct data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion



        private void grdDtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 7 )
            {
                txtGrdRowIndex.Text = e.RowIndex.ToString();
                int row = e.RowIndex;

                ddlItem.SelectedValue = Convert.ToInt32(grdDtl["ItemCd", row].Value) ;
                txtQty.Text = grdDtl["Qty", row].Value.ToString();
                ddlIssUnit.SelectedValue=Convert.ToInt32(grdDtl["UnitCd", row].Value );
                txtRate.Text = grdDtl["Rate", row].Value.ToString();
                
            }
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        #region Search Effect
        public void XGridValueJump()
        {
            try
            {
                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                int Rcode = Convert.ToInt32 (grdSearch["Code", index5].Value.ToString());
                //=======================Header data bind==========================
                string ActYN = "N";
                if ((bool)grdSearch["HActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }
                txtHdActiveYN.Text = ActYN;
                this.txtPkgDisc.Text = (String)grdSearch["PackageDescription", index5].Value.ToString();
                this.ddlService.SelectedValue = grdSearch["ServiceCd", index5].Value;
                //=================================================================
                //=======================Detail data bind==========================
                
                List<BOMEL> objBOMEL = new List<BOMEL>();
                objBOMEL = objBOMentryDAL.BindDtlList(grdDtl, Rcode);
                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {

                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    
                    grdDtl.DataSource = objBOMEL.ToList();

                    grdDtl.Columns["ItemCd"].DataPropertyName = "ItemCd";
                    grdDtl.Columns["UnitCd"].DataPropertyName = "UnitCd";
                    grdDtl.Columns["Item"].DataPropertyName = "Item";
                    grdDtl.Columns["Unit"].DataPropertyName = "Unit";
                    grdDtl.Columns["Qty"].DataPropertyName = "Qty";
                    grdDtl.Columns["Rate"].DataPropertyName = "Rate";
                    grdDtl.Columns["DActiveYN"].DataPropertyName = "DActiveYN";

                    //=================================================================
                    
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void grdSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            XGridValueJump();
            EditFormatActiveN();
        }
        #endregion

        #region Validation
        private void ddlService_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlService, falag);
        }

        private void ddlItem_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlItem, falag);
        }

        private void ddlService_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlItem_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlIssUnit_Enter(object sender, EventArgs e)
        {
            falag = true;
        }

        private void ddlIssUnit_Validated(object sender, EventArgs e)
        {
            CommonCL.cmbValidated(ddlIssUnit, falag);
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHdActiveYN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CommonCL.textBoxYNValidation(txtHdActiveYN, false);
        }

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CommonCL.textBoxYNValidation(txtActive ,false);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CommonCL.OnlyNumeric(txtRate, falag);
        }

        #endregion



    }     
}
