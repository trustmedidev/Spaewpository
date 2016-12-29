using SPAPracticeManagement.CustomControls.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Appointments
{
    public partial class ClientPopUp : Form
    {
        public ClientPopUp()
        {
            InitializeComponent();

            AddClientTab objApp = new AddClientTab(1, 0, "appointment");
            pnlControl.Controls.Add(objApp);
        }

        //public ClientPopUp(string clientid="",string clientname="")
        //{
        //    InitializeComponent();
        //    ClientInvoiceTab objclientinvoice = new ClientInvoiceTab(clientid, clientname);
        //    //AddClientTab objApp = new AddClientTab(clientid, clientname);
        //    pnlControl.Controls.Add(objclientinvoice);
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
