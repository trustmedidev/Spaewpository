using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement.CustomControls.Client;

namespace SPAPracticeManagement.CustomControls.Appointment
{
    public partial class ClienttPopUp : Form
    {
        public ClienttPopUp()
        {
            InitializeComponent();
            AddClientTab ObjAddClientTab = new AddClientTab(0,0);
            pnlControl.Controls.Add(ObjAddClientTab);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
