using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SPAPracticeManagement.AppConstants;
using DataAccessLayer.Repository;
using System.Globalization;
using DataAccessLayer;
using SPAPracticeManagement.Client;
using SPAPracticeManagement.Appointments;

namespace SPAPracticeManagement.CustomControls.Client
{
    public partial class ClientInvoiceTab : UserControl
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        public int PageId = default(int);

        public ClientDAL ObjclientList
        {
            get { return new ClientDAL(); }
        }
        public ClientInvoiceTab(int pageId = 0, int clientId = 0, string clientName = "")
        {
            InitializeComponent();
            PageId = pageId;
            lblClientName.Text = clientName;
            lblClientId.Text = Convert.ToString(clientId);
            BindAccountGrid(clientId);
        }
        /*----------------------Code Added By Sandip Das------------------------------*/
        private void BindAccountGrid(int clientId)
        {
            var query = ObjclientList.GetClientAppointmentListByClientId(clientId, branchID).ToList();
            if (query.Count > 0)
            {
                grdPatientAccount.AutoGenerateColumns = false;
                grdPatientAccount.DataSource = query;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (PageId > 0)
            {
                AddClient ObjAddClient=new AddClient(1,lblClientName.Text.Trim(),Convert.ToInt32(lblClientId.Text.Trim()));
                ObjAddClient.Show();
                this.FindForm().Hide();
            }
            else
            {
                //.......................Code Added by Sam on 06092016...................
                //AddClientTab ObjAddClientTab = new AddClientTab(0);   
                AddClientTab ObjAddClientTab = new AddClientTab(0,0);
                //.......................Code Added by Sam on 06092016...................
                ClientPopUp ObjClientPopUp = new ClientPopUp();
                Panel pnlControl = ObjClientPopUp.Controls["pnlControl"] as Panel;
                pnlControl.Controls.Clear();
                pnlControl.Controls.Add(ObjAddClientTab);
                ObjClientPopUp.Show();
                this.FindForm().Hide();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            
            if (PageId > 0)
            {
                AddClient ObjAddClient = new AddClient(3, lblClientName.Text.Trim(), Convert.ToInt32(lblClientId.Text.Trim()));                
                ObjAddClient.Show();
                this.FindForm().Hide();
            }
            else
            {
                ClientDocument ObjClientDocument = new ClientDocument(0, Convert.ToInt32(lblClientId.Text.Trim()), lblClientName.Text.Trim());
                ClientPopUp ObjClientPopUp = new ClientPopUp();
                Panel pnlControl = ObjClientPopUp.Controls["pnlControl"] as Panel;
                pnlControl.Controls.Clear();
                pnlControl.Controls.Add(ObjClientDocument);
                ObjClientPopUp.Show();
                this.FindForm().Hide();
            }
        }
    }
}
