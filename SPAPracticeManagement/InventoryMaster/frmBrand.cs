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
    public partial class frmBrand : InventoryDashboard
    {
        #region === Variables
        Boolean falag = true;
        BrandDAL objBrandDAL = new BrandDAL();
        DataView dv;
        string objFrmName = string.Empty;
        
        #endregion
        public frmBrand()
        {
            InitializeComponent();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);
            objFrmName = "Brand";
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
            btnSave.Top = 130;
            btnSave.Left = 245;
            btnClear.Top = 130;
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
            btnUpdate.Top = 130;
            btnUpdate.Left = 245;
            btnClear.Top = 130;
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
            btnUpdate.Top = 130;
            btnUpdate.Left = 245;
            btnClear.Top = 130;
            btnClear.Left = 320;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            formCtrlActiveN();
        }

        public void formCtrlActiveY()
        {
            this.txtName.Enabled = true;
            this.txtActive.Enabled = true;

            ActiveControl = txtName;
        }

        public void formCtrlClear()
        {
            this.txtName.Text = "";
            this.txtActive.Text = "Y";
        }
        public void formCtrlActiveN()
        {
            this.txtName.Enabled = false;
            this.txtActive.Enabled = false;
        }

        public override void SirchGridFormat()
        {
            try
            {
                objBrandDAL.BindList(grdSearch);

                txtSearchText.Width = 1050;

                lblTag.Text = "All " + objFrmName.ToString() + "";
                grdSearch.Width = 1100;
                grdSearch.Height = 550;
                CommonCL.PanelControlGotFocus(pnlTabControlSearch, pnlTabControlAdd);

                grdSearch.Columns[0].Visible = false;


                grdSearch.Columns[1].Width = 300;
                grdSearch.Columns[2].Width = 150;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


        }
        #endregion

        #region Insert/Update
        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter brand name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int x = objBrandDAL.Insert( txtName.Text.ToString(), GlobalCL.UserCD);
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
                int x = objBrandDAL.Update(bId, txtName.Text.ToString(),  IsActiveYN);
                if (x > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
        }
        #endregion 

        #region KeybordControl
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtActive, e);
        }

        private void txtActive_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnSave, e);
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnUpdate_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.ButtonGotFocus(btnClear, e);
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            CommonCL.TextBoxGotFocus(txtName, e);
        }
        #endregion

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            formCtrlClear();
        }

        private void txtActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonCL.textBoxYNValidation(txtActive,e);
        }

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
                    txtName.Text = (String)grdSearch["Name", index5].Value.ToString();
                    txtActive.Text = ActYN;
                    EditFormatActiveN();
                    txtName.Focus();
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
