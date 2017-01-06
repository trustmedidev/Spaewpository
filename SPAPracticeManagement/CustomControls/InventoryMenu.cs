using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.InventoryMaster;
using SPAPracticeManagement.InventoryTransaction;
using SPAPracticeManagement.Settings;
namespace SPAPracticeManagement.CustomControls
{
    public partial class InventoryMenu : UserControl
    {
        public InventoryMenu()
        {
            InitializeComponent();
        }

        private void godownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGodown objGodown = new frmGodown();
            objGodown.Show();
            this.Parent.FindForm().Hide();
        }

        private void itemMainGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemMainGroup objItemMainGroup = new frmItemMainGroup();
            objItemMainGroup.Show();
            this.Parent.FindForm().Hide();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrand objfrm = new frmBrand();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItem objfrm = new frmItem();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void itemSubGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemSubGroup objfrm = new frmItemSubGroup();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnit objfrm = new frmUnit();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void suppliorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplior objfrm = new frmSupplior();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void batchMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch objfrm = new frmBatch();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void billOfMaterialPackageWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBOM objfrm = new frmBOM();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void itemOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpeningStock objfrm = new frmOpeningStock();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void purchaseOrderRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseRequsition objfrm = new frmPurchaseRequsition();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder objfrm = new frmPurchaseOrder();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void goodReseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGRN objfrm = new frmGRN();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseBill objfrm = new frmPurchaseBill();
            objfrm.Show();
            this.Parent.FindForm().Hide();
        }
    }
}
