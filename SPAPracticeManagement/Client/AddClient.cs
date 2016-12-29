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

namespace SPAPracticeManagement.Client
{
    public partial class AddClient : Dashboard
    {
        public AddClient(int tab = 1, string ClientName = "", int Clientid = 0, int screensize = 0)
        {

            AddClientTab ucClienttab = new AddClientTab(0, Clientid);

            ucClienttab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));

            ClientInvoiceTab ucClientInvoiceTab = new ClientInvoiceTab(1, Clientid, ClientName);

            ucClientInvoiceTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));

            ClientDocument ucClientDocument = new ClientDocument(1, Clientid, ClientName);

            ucClientDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));

            InitializeComponent();

            switch (tab)
            {
                case 1:
                    pnlTabControl.Controls.Add(ucClienttab);
                    break;
                case 2:
                    pnlTabControl.Controls.Add(ucClientInvoiceTab);
                    break;
                case 3:
                    pnlTabControl.Controls.Add(ucClientDocument);
                    break;
            }

            if (screensize <= 0)
            {
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            }


        //     private void button5_Click(object sender, EventArgs e)
        //{
        //    PatientList objApplicantList = new PatientList();
        //    objApplicantList.Show();

        //    this.Hide();
        //}
        }
    }
}
