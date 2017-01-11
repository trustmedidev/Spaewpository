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

namespace SPAPracticeManagement.InventoryMaster
{
    public partial class frmBatch : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        BrandDAL objBrandDAL = new BrandDAL();
        ItemDAL objItemDAL = new ItemDAL();
        BatchDAL objBatchDAL = new BatchDAL();
        DataView dv;
        string objFrmName = string.Empty;
        #endregion
        public frmBatch()
        {
            InitializeComponent();
        }

        private void frmBatch_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objFrmName = "Batch";
            objItemDAL.BindDdlItem(ddlItem);
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
                //CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
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
            btnSave.Top = 230;
            btnSave.Left = 245;
            btnClear.Top = 230;
            btnClear.Left = 320;
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
            btnUpdate.Top = 230;
            btnUpdate.Left = 245;
            btnClear.Top = 230;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;

            CommonCL.PanelControlGotFocus(pnlTabControlAdd, pnlTabControlSearch);
            formCtrlActiveY();
        }
        public void EditFormatActiveN()
        {
            lblTag.Text = "Edit " + objFrmName.ToString() + " Detail";
            btnUpdate.Top = 230;
            btnUpdate.Left = 245;
            btnClear.Top = 230;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.ddlItem.Enabled = true;
            this.txtBatchNo.Enabled = true;
            this.txtRate.Enabled = true;
            this.txtDescription.Enabled = true;
            this.DtExpiry.Enabled = true;
            this.txtActive.Enabled = true;

            ActiveControl = ddlItem;
        }

        public void formCtrlClear()
        {
            
            this.ddlItem.Text = "";
            this.txtBatchNo.Text = "";
            this.txtRate.Text = "";
            this.txtDescription.Text = "";
            this.DtExpiry.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            //this.DtExpiry.Value = Convert.ToDateTime(Dt1.Value.ToString("dd/MM/yyyy"));
            this.txtActive.Text = "";
            this.txtActive.Text = "Y";
        }
        public void formCtrlActiveN()
        {
            this.ddlItem.Enabled = false;
            this.txtBatchNo.Enabled = false;
            this.txtRate.Enabled = false;
            this.txtDescription.Enabled = false;
            this.DtExpiry.Enabled = false;
            this.txtActive.Enabled = false;
        }

        public override void SirchGridFormat()
        {
            try
            {
                objBatchDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                //grdSearch.Columns[0].Visible = false;


                //grdSearch.Columns[1].Width = 300;
                //grdSearch.Columns[2].Width = 150;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
        #endregion

        #region KeybordControl
        private void ddlItem_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtBatchNo, e);
        }

        private void txtBatchNo_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtRate, e);
        }

        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtDescription, e);
        }

        private void txtDescription_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.DTPickerGotFocus(DtExpiry, e);
        }

        private void DtExpiry_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                CommonCL.ButtonGotFocus(btnSave, e);
            }
            if (btnUpdate.Enabled == true)
            {
                CommonCL.ButtonGotFocus(btnSave, e);
            }
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

         #endregion

        #region Insert/Update
        private bool ValidateForm()
        {
            if (ddlItem.SelectedValue == null || ddlItem .SelectedValue .ToString ()=="")
            {
                MessageBox.Show("Please enter Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtBatchNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Batch No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtRate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Rate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtActive.Text.Trim() == "")
            {
                MessageBox.Show("Please enter activeYN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            else
            {
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {

                int x = objBatchDAL.Insert(txtBatchNo.Text .ToString (),Convert.ToInt32(ddlItem .SelectedValue .ToString ()),
                    Convert.ToDecimal(txtRate.Text.ToString ()), DtExpiry.Value,txtDescription .Text .ToString (),GlobalCL.UserCD);
                if (x > 0)
                {
                    MessageBox.Show("Saved");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool IsActiveYN = false;

            if (txtActive.Text == "Y")
            {
                IsActiveYN = true;
            }
            if (ValidateForm())
            {
                int bId = 0;

                bId = Convert.ToInt32(txtHidCode.Text.ToString());

                int x = objBatchDAL.Update(bId,txtBatchNo .Text .ToString (),Convert.ToInt32(ddlItem .SelectedValue ),
                    Convert.ToDecimal(txtRate.Text .ToString() ) ,DtExpiry .Value ,txtDescription .Text ,IsActiveYN );
                if (x > 0)
                {
                    MessageBox.Show("Updated");
                }
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
                string ActYN = "N";
                if ((bool)grdSearch["ActiveYN", index5].Value == true)
                {
                    ActYN = "Y";
                }

                if (txtHidCode.Text == "")
                {
                    MessageBox.Show("Please Select Valid date.. !!");
                    return;
                }
                else
                {


                    txtHidCode.Text = (String)grdSearch["Code", index5].Value.ToString();
                    ddlItem.SelectedValue = grdSearch["ItemCd", index5].Value;
                    txtBatchNo.Text = (String)grdSearch["Name", index5].Value.ToString();
                    txtRate.Text = grdSearch["Rate", index5].Value.ToString();
                    txtDescription.Text = (String)grdSearch["Description", index5].Value.ToString();
                    DtExpiry.Value = Convert.ToDateTime(grdSearch["ExpiryDate", index5].Value.ToString ());
                    
                    txtActive.Text = ActYN;
                    EditFormatActiveN();
                    ddlItem .Focus();
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

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive, e);
        }
    }
}
