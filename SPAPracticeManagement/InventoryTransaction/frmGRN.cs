using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmGRN : InventoryDashboard
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
        public frmGRN()
        {
            InitializeComponent();
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
        private void frmGRN_Load(object sender, EventArgs e)
        {

        }
    }
}
