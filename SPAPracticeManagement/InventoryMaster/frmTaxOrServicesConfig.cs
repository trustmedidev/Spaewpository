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
        TaxConfigDAL objTaxConfigDAL = new TaxConfigDAL();
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
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objFrmName = "Tax / Charges configuration";
            SirchGridFormat();
            chkListFormula.Items.Clear();
            chkListFormula.Items.Add("Basic");
            
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
            txtTnSname.Text = "";
            ddlSTax.Text = "";
            ddladdSub.Text = "";
            txtPer.Text = "";
            txtVal.Text = "";
            ddlType.Text = "";
            //txtcode.Text = "";
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
                objTaxConfigDAL.BindList(Globalmethods.BranchCD, grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;
                grdSearch.Columns[1].Visible = false;

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
                    SubSaveUpdate();

                    chkListFormula.Items.Clear();
                    chkListFormula.Items.Add("Basic");

                    for (int i = 0; i < grdDtl.Rows.Count; i++)
                    {
                        chkListFormula.Items.Add(grdDtl.Rows[i].Cells["Name"].Value.ToString());
                    }

                    //int a=chkListFormula.Items.Count;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        //private bool ValidateSubForm()
        //{

        //    if (txtHidCode.Text == "")
        //    {
        //        txtHidCode.Text = "0";
        //    }

        //    //if (TnSname.SelectedValue == null || TnSname.SelectedValue.ToString() == "")
        //    //{
        //    //    MessageBox.Show("Please enter Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}
        //    //if (ddlSTax.SelectedValue == null || ddlSTax.SelectedValue.ToString() == "")
        //    //{
        //    //    MessageBox.Show("Please enter S. Tax.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}
        //    if (ddladdSub.Text .ToString ()=="")
        //    {
        //        MessageBox.Show("Please enter S. Tax.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    //if (ddlFormula.Text.ToString() == "")
        //    //{
        //    //    MessageBox.Show("Please enter Formula.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}
        //    //if (txtPer.Text.Trim() == "")
        //    //{
        //    //    MessageBox.Show("Please enter Qty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}
        //    //if (txtVal.Text.Trim() == "")
        //    //{
        //    //    MessageBox.Show("Please enter Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return false;
        //    //}

        //    if (txtHdActiveYN.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }


        //    else
        //    {
        //        return true;
        //    }
        //}

        private void grdDtl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 10)
            {
                txtGrdRowIndex.Text = e.RowIndex.ToString();
                int row = e.RowIndex;

                txtTnSname.Text = grdDtl["Name", row].Value.ToString();
                ddlSTax.Text = grdDtl["STax", row].Value.ToString();
                ddladdSub.Text = grdDtl["AddSub", row].Value.ToString();
                txtFormula.Text = grdDtl["Formula", row].Value.ToString();
                txtPer.Text = grdDtl["TaxPer", row].Value.ToString();
                txtVal.Text = grdDtl["Val", row].Value.ToString();
                ddlType.Text = grdDtl["Type", row].Value.ToString();
                //txtGrdRowIndex.Text = grdDtl["code", row].Value.ToString();
                txtActive.Text = grdDtl["DActiveYN", row].Value.ToString();

            }
            if (e.ColumnIndex == 8)
            {
                removeRecordFormGrid();

            }
        }
        public void removeRecordFormGrid()
        {
            try
            {

                DialogResult reg = MessageBox.Show("Do You want to Remove record...", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == reg)
                {
                    grdDtl.Rows.RemoveAt(grdDtl.CurrentRow.Index);
                    //decimal totQty = 0;
                    //decimal totAmt = 0;
                    ////for (int i = 0; i < grdDtl.Rows.Count; i++)
                    ////{

                    ////    totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
                    ////    totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

                    ////}
                    ////txtTotQty.Text = totQty.ToString();
                    ////txtTotAmount.Text = totAmt.ToString();
                }
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
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

        public void SubSaveUpdate()
        {
            Boolean check_gd = false;
            for (int p = 0; p < grdDtl.Rows.Count; p++)
            {
                string V_Sl = grdDtl["Sl", p].Value.ToString();
                if (txtGrdRowIndex.Text.ToString() == p.ToString())
                {
                    check_gd = true;
                    grdDtl["Sl", p].Value = Convert.ToString(p+1);
                    grdDtl["Name", p].Value = txtTnSname.Text.ToString();
                    grdDtl["STax", p].Value = ddlSTax .Text .ToString();
                    grdDtl["AddSub", p].Value = ddladdSub .Text .ToString();
                    string test=chkListFormula.Text.ToString();
                    grdDtl["Formula", p].Value = "B";

                    grdDtl["TaxPer", p].Value = txtPer.Text .ToString();
                    grdDtl["Val", p].Value = txtVal.Text.ToString();
                    grdDtl["Type", p].Value = ddlType.Text.ToString();
                    grdDtl["code", p].Value = "";
                    grdDtl["DActiveYN", p].Value = txtActive.Text.ToString();

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
                        row = grdDtl.Rows.Count - 1;
                        grdDtl["code", row].Value = "0";

                        //==========================================
                        string ch;
                        txtFormula.Text = "";
                        
                        int a = chkListFormula.Items.Count;
                        
                        for (int i = 0; i < a; i++)
                        {
                            if (i == 0)
                            { txtFormula.Text = "B"; }
                            else
                            {
                                if (chkListFormula.GetItemChecked(i))
                                {

                                    ch = i.ToString();
                                    if (txtFormula.Text.ToString() != "")
                                    {
                                        txtFormula.Text = txtFormula.Text.ToString() + "+" + ch;
                                    }
                                    else
                                    {
                                        txtFormula.Text = txtFormula.Text.ToString() + ch;
                                    }

                                }
                                else
                                {

                                }
                            }
                        }
                        //==========================================
                        grdDtl["Sl", row].Value = Convert.ToString(row + 1);
                        grdDtl["Name", row].Value = txtTnSname.Text.ToString();
                        grdDtl["STax", row].Value = ddlSTax.Text.ToString();
                        grdDtl["AddSub", row].Value = ddladdSub.Text.ToString();
                        string test = chkListFormula.Text.ToString();
                        grdDtl["Formula", row].Value = txtFormula.Text.ToString();//"B";

                        grdDtl["TaxPer", row].Value = txtPer.Text.ToString();
                        grdDtl["Val", row].Value = txtVal.Text.ToString();
                        grdDtl["Type", row].Value = ddlType.Text.ToString();
                        grdDtl["code", row].Value = "";
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();

                        //grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        //grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        //grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        //grdDtl["Unit", row].Value = ddlUnit.Text.ToString();

                        //grdDtl["SecondUnitCd", row].Value = ddlSecoUnit.SelectedValue.ToString();
                        //grdDtl["SecondUnit", row].Value = ddlSecoUnit.Text.ToString();
                        //grdDtl["SecondQty", row].Value = txtSecoQty.Text.ToString();
                        //grdDtl["ExpiryDt", row].Value = DtExp.Value;

                        //grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        //grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();


                        SubCtrlClear();
                        grdDtl.Refresh();
                        btnSubAdd.Focus();
                        return;
                    }
                    else
                    {
                        int row = Convert.ToInt32(txtGrdRowIndex.Text.ToString());

                        //==========================================
                        string ch;
                        txtFormula.Text = "";

                        int a = chkListFormula.Items.Count;

                        for (int i = 0; i < a; i++)
                        {
                            if (i == 0)
                            { txtFormula.Text = "B"; }
                            else
                            {
                                if (chkListFormula.GetItemChecked(i))
                                {

                                    ch = i.ToString();
                                    if (txtFormula.Text.ToString() != "")
                                    {
                                        txtFormula.Text = txtFormula.Text.ToString() + "+" + ch;
                                    }
                                    else
                                    {
                                        txtFormula.Text = txtFormula.Text.ToString() + ch;
                                    }

                                }
                                else
                                {

                                }
                            }
                        }
                        //==========================================
                        grdDtl["Sl", row].Value = Convert.ToString(row + 1);
                        grdDtl["Name", row].Value = txtTnSname.Text.ToString();
                        grdDtl["STax", row].Value = ddlSTax.Text.ToString();
                        grdDtl["AddSub", row].Value = ddladdSub.Text.ToString();
                        string test = chkListFormula.Text.ToString();
                        grdDtl["Formula", row].Value = txtFormula.Text.ToString();

                        grdDtl["TaxPer", row].Value = txtPer.Text.ToString();
                        grdDtl["Val", row].Value = txtVal.Text.ToString();
                        grdDtl["Type", row].Value = ddlType.Text.ToString();
                        grdDtl["code", row].Value = "";
                        grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();

                        //grdDtl["Name", row].Value = txtTnSname.Text.ToString();
                        //grdDtl["STax", row].Value = ddlSTax.Text.ToString();
                        //grdDtl["AddSub", row].Value = ddladdSub.Text.ToString();
                        //string test = chkListFormula.Text.ToString();
                        //grdDtl["Formula", row].Value = "B";

                        //grdDtl["TaxPer", row].Value = txtPer.Text.ToString();
                        //grdDtl["Val", row].Value = txtVal.Text.ToString();
                        //grdDtl["Type", row].Value = ddlType.Text.ToString();
                        //grdDtl["code", row].Value = "";
                        //grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();

                        ////grdDtl["ItemCd", row].Value = ddlItem.SelectedValue.ToString();
                        ////grdDtl["Qty", row].Value = txtQty.Text.ToString();
                        ////grdDtl["UnitCd", row].Value = ddlUnit.SelectedValue.ToString();
                        ////grdDtl["Unit", row].Value = ddlUnit.Text.ToString();

                        ////grdDtl["SecondUnitCd", row].Value = ddlSecoUnit.SelectedValue.ToString();
                        ////grdDtl["SecondUnit", row].Value = ddlSecoUnit.Text.ToString();
                        ////grdDtl["SecondQty", row].Value = txtSecoQty.Text.ToString();
                        ////grdDtl["ExpiryDt", row].Value = DtExp.Value;

                        ////grdDtl["Amount", row].Value = txtAmount.Text.ToString();
                        ////grdDtl["DActiveYN", row].Value = txtActive.Text.ToString();

                        

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
            //decimal totQty = 0;
            //decimal totAmt = 0;
            //for (int i = 0; i < grdDtl.Rows.Count; i++)
            //{

            //    totQty = totQty + Convert.ToDecimal(grdDtl.Rows[i].Cells["Qty"].Value);
            //    totAmt = totAmt + Convert.ToDecimal(grdDtl.Rows[i].Cells["Amount"].Value);

            //}
            //txtTotQty.Text = totQty.ToString();
            //txtTotAmount.Text = totAmt.ToString();
        }
        #region Insert/Update
        private bool ValidateForm()
        {

            if (txtHidCode.Text == "")
            {
                txtHidCode.Text = "0";
            }

            //if (ddlBranch.SelectedValue == null || ddlBranch.SelectedValue.ToString() == "")
            //{
            //    MessageBox.Show("Please enter Branch.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (ddlGodown.SelectedValue == null || ddlGodown.SelectedValue.ToString() == "")
            //{
            //    MessageBox.Show("Please enter Godown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (txtConfigNm.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax Or Services Config Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool ValidateSubForm()
        {

            if (txtHidCode.Text == "")
            {
                txtHidCode.Text = "0";
            }

            if (txtTnSname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Tax Or Services Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddlSTax.SelectedIndex == null || ddlSTax.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Please enter Service Tax.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ddladdSub.SelectedIndex == null || ddladdSub.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Please enter +/-.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (chkListFormula.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Qty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (txtPer.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter (%).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //if (txtVal.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (ddlType.SelectedIndex == null || ddlSTax.SelectedIndex.ToString() == "")
            {
                MessageBox.Show("Please enter Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter ActiveYN.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion

        #region GridFunctions
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = InsertUpdateDelete();

            if (i > 0)
            {
                if (grdDtl.Rows.Count != 0)
                {

                    for (int j = 0; j < grdDtl.Rows.Count; j++)
                    {

                        tbltaxcofigdetail objtbltaxcofigdetail = new tbltaxcofigdetail();
                        //tblstock objtblstock = new tblstock();
                        objtbltaxcofigdetail.TaxConfigHdCd = Convert.ToInt32(i.ToString());
                        //objtbltaxcofigdetail.Code = Convert.ToInt32(grdDtl.Rows[j].Cells["code"].Va
                        objtbltaxcofigdetail.Code = 0;
                        objtbltaxcofigdetail.Name = grdDtl.Rows[j].Cells["Name"].Value.ToString();
                        bool STaxYN = false;
                        if (grdDtl.Rows[j].Cells["STax"].Value.ToString() == "Y")
                        { STaxYN = true; }
                        objtbltaxcofigdetail.TaxYN = STaxYN;
                        objtbltaxcofigdetail.AddSub = grdDtl.Rows[j].Cells["AddSub"].Value.ToString();
                        objtbltaxcofigdetail.CalOn = grdDtl.Rows[j].Cells["Formula"].Value.ToString();
                        objtbltaxcofigdetail.CalPer = Convert.ToDecimal(grdDtl.Rows[j].Cells["TaxPer"].Value.ToString());
                        //objtbltaxcofigdetail.CalVal = Convert.ToDecimal(grdDtl.Rows[j].Cells["Val"].Value.ToString());
                        objtbltaxcofigdetail.CalVal = 0;
                        objtbltaxcofigdetail.TermsType = grdDtl.Rows[j].Cells["Type"].Value.ToString();
                        
                        bool valActiveYN = false;
                        if (grdDtl.Rows[j].Cells["DActiveYN"].Value.ToString() == "Y")
                        { valActiveYN = true; }
                        objtbltaxcofigdetail.ActiveYN = valActiveYN;
                        //objtbltaxcofigdetail.ExpiryDt = Convert.ToDateTime(grdDtl.Rows[j].Cells["ExpiryDt"].Value.ToString());

                        objTaxConfigDAL.InsertUpdateDetai(objtbltaxcofigdetail);
                    }

                }
            }
        }

        public int InsertUpdateDelete()
        {
            int r = 0;

            try
            {
                //int i = default(int);
                //bool IsValid = false;

                tbltaxconfigheader objtbltaxconfigheader = new tbltaxconfigheader();
                tbltaxcofigdetail objtbltaxcofigdetail = new tbltaxcofigdetail();

                if (ValidateForm())
                {


                    objtbltaxconfigheader.Code = Convert.ToInt32(txtHidCode.Text.ToString());
                    objtbltaxconfigheader.Description = txtConfigNm.Text.ToString();
                    objtbltaxconfigheader.BranchCd = Globalmethods.BranchCD;
                    //objtbltaxconfigheader.GodownCd = Convert.ToInt32(ddlGodown.SelectedValue.ToString());
                    //objtbltaxconfigheader.ItemOpeningTranId = txtIndentNo.Text.ToString();
                    //objtbltaxconfigheader.Description = "";
                    //objtblitemopeningheader.TotValue = Convert.ToDecimal(txtTotAmount.Text.ToString());
                    //objtbltaxconfigheader.TotValue = 0;
                    objtbltaxconfigheader.Finyr = Globalmethods.FinYr;
                    objtbltaxconfigheader.ActiveYN = true;
                    objtbltaxconfigheader.EntryDate = DateTime.Now;
                    objtbltaxconfigheader.UserCode = GlobalCL.UserCD;

                    r = objTaxConfigDAL.InsertUpdateHdr(objtbltaxconfigheader, objtbltaxcofigdetail);

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

        #region Search Effect
        public void XGridValueJump()
        {
            try
            {
                int index5 = grdSearch.SelectedCells[0].RowIndex;
                txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                int Rcode = Convert.ToInt32(grdSearch["Code", index5].Value.ToString());
                //=======================Header data bind==========================
                string ActYN = "N";
                if ((bool)grdSearch["HActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }
                txtHdActiveYN.Text = ActYN;
                this.txtConfigNm.Text = grdSearch["Description", index5].Value.ToString();
                //this.ddlBranch.SelectedValue = grdSearch["Brabchcd", index5].Value;
                //=================================================================
                //if (ddlBranch.SelectedValue != null || ddlBranch.SelectedValue.ToString() != "")
                //{
                //    int i = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
                //    objInventoryMasterDAL.BindDdlGodown(i, ddlGodown);
                //    this.ddlGodown.SelectedValue = grdSearch["Godowncd", index5].Value;
                //}
                //=================================================================
                //this.txtIndentNo.Text = grdSearch["ItemOpeningTranId", index5].Value.ToString();
                //=============================End=================================
                //=======================Detail data bind==========================


                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {

                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    Rcode = Convert.ToInt32(txtHidCode.Text.ToString());
                    grdDtl.Rows.Clear();
                    List<TaxConfigurationEL> objTaxConfigurationEL = new List<TaxConfigurationEL>();

                    objTaxConfigurationEL = objTaxConfigDAL.BindDtlList(Rcode);  //  (grdDtl, Rcode);
                    for (var i = 0; i < objTaxConfigurationEL.Count; i++)
                    {
                        grdDtl.Rows.Add();
                        grdDtl.Rows[i].Cells["code"].Value = objTaxConfigurationEL[i].DCode.ToString();
                        grdDtl.Rows[i].Cells["Name"].Value = objTaxConfigurationEL[i].ConfigNm;
                        grdDtl.Rows[i].Cells["STax"].Value = objTaxConfigurationEL[i].STax;
                        grdDtl.Rows[i].Cells["AddSub"].Value = objTaxConfigurationEL[i].addSub;
                        grdDtl.Rows[i].Cells["Formula"].Value = objTaxConfigurationEL[i].CalOn;
                        grdDtl.Rows[i].Cells["TaxPer"].Value = objTaxConfigurationEL[i].CalPer;
                        grdDtl.Rows[i].Cells["Val"].Value = objTaxConfigurationEL[i].CalVal;

                        grdDtl.Rows[i].Cells["Type"].Value = objTaxConfigurationEL[i].TermsType;
                        grdDtl.Rows[i].Cells["DActiveYN"].Value = objTaxConfigurationEL[i].IsActive;                       
                    }


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
    }
}
