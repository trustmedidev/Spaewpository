using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using System.IO;
using EntityLayer;
using SPAPracticeManagement.Client;
using SPAPracticeManagement.Appointments;
using DataAccessLayer;
using DataAccessLayer.Repository;
using SPAPracticeManagement.AppConstants;

namespace SPAPracticeManagement.CustomControls.Client
{
    public partial class ClientDocument : UserControl
    {
        int? branchID = AppConstants.AppsPropertise.UserDetails.BranchId;
        ClientDAL objClientDAL = new ClientDAL();
        public int PageId = default(int);
        int UpdateDocId = 0;
        public ClientDocument(int pageId = 0, int clientId = 0, string clientName = "")
        {
            InitializeComponent();
            string dir = Application.StartupPath + @"\ClientDocuments";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            PageId = pageId;
            lbl_ClientName.Text = clientName;
            lbl_ClientID.Text = Convert.ToString(clientId);
            BindDocumentList(clientId);
        }

        private string SaveFiles()
        {
            int count = 0;
            string[] FilenameName;
            string NewFileName = "";
            string NewPath = Application.StartupPath + @"\ClientDocuments\" + Guid.NewGuid();
            foreach (string item in openFileDialog1.FileNames)
            {
                /*---------Code Added By Sandip Das------*/
                if (item == "openFileDialog1")
                {
                    return NewFileName = null;
                }
                else
                {
                    /*----------------END----------------*/
                    string ext = Path.GetExtension(openFileDialog1.FileName);
                    NewPath = NewPath + ext;
                    FilenameName = item.Split('\\');
                    File.Copy(item, NewPath);
                    count++;
                }
            }

            return NewPath;
        }

        private void BindDocumentList(int clientId)
        {
            grdPatientDoc.AutoGenerateColumns = false;
            grdPatientDoc.DataSource = objClientDAL.GetAllDocumentsByClientId(clientId);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageId > 0)
                {
                    AddClient ObjAddClient = new AddClient(0, lbl_ClientName.Text.Trim(), Convert.ToInt32(lbl_ClientID.Text.Trim()));
                    ObjAddClient.Show();
                    this.FindForm().Hide();
                }
                else
                {
                    ClientInvoiceTab ObjClientInvoiceTab = new ClientInvoiceTab();
                    ClientPopUp ObjClientPopUp = new ClientPopUp();
                    Panel pnlControl = ObjClientPopUp.Controls["pnlControl"] as Panel;
                    pnlControl.Controls.Clear();
                    pnlControl.Controls.Add(ObjClientInvoiceTab);
                    ObjClientPopUp.Show();
                    this.FindForm().Hide();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = SaveFiles();
                
                tbldocument objDoc = new tbldocument()
                {
                    AddedDate = DateTime.Now,
                    DecumentDesc = txtDescription.Text.Trim(),
                    DocumentName = txtDocName.Text.Trim(),
                    //FilePath = FilePath,
                    /*---------------Code Added By Sandip Das ---------------*/
                    FilePath = (FilePath == null ? txtFileName.Text.Trim() : FilePath),
                    /*-------------------END---------------------------*/
                    FK_ClientId = Convert.ToInt32(lbl_ClientID.Text),                     
                    IsActive = true,
                    FK_BranchID = AppsPropertise.UserDetails.BranchId,
                    DocumentId=UpdateDocId,
                };

                int i = objClientDAL.InsertUpdateClientDocument(objDoc);
                if (i > 0)
                {
                    MessageBox.Show("Document Uploaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (PageId > 0)
                    {
                        AddClient ObjAddClient = new AddClient(3,lbl_ClientName.Text.Trim(),Convert.ToInt32(lbl_ClientID.Text.Trim()));
                        ObjAddClient.Show();
                        this.FindForm().Hide();
                    }
                    else
                    {
                        this.FindForm().Hide();
                    }
                }

                BindDocumentList(Convert.ToInt32(lbl_ClientID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    txtFileName.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageId > 0)
                {
                    AddClient ObjAddClient = new AddClient(2, lbl_ClientName.Text.Trim(), Convert.ToInt32(lbl_ClientID.Text.Trim()));
                    ObjAddClient.Show();
                    this.FindForm().Hide();
                }
                else
                {
                    ClientInvoiceTab ObjClientInvoiceTab = new ClientInvoiceTab();
                    ClientPopUp ObjClientPopUp = new ClientPopUp();
                    Panel pnlControl = ObjClientPopUp.Controls["pnlControl"] as Panel;
                    pnlControl.Controls.Clear();
                    pnlControl.Controls.Add(ObjClientInvoiceTab);
                    ObjClientPopUp.Show();
                    this.FindForm().Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void grdPatientDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    string DocName = Convert.ToString(grdPatientDoc.Rows[e.RowIndex].Cells[1].Value);

                    int DocId = default(int);
                    int.TryParse(Convert.ToString(grdPatientDoc.Rows[e.RowIndex].Cells[0].Value), out DocId);
                    int ClientId = Convert.ToInt32(objClientDAL.GetClientIdByDocId(DocId).ClientId.Value);

                    var FetchDocument = objClientDAL.GetAllDocumentsByDocId(DocId).FirstOrDefault();
                    txtDocName.Text = FetchDocument.DocumentName;
                    txtDescription.Text = FetchDocument.DecumentDesc;
                    txtFileName.Text = FetchDocument.FilePath;
                    UpdateDocId = DocId;

                }
                if (e.ColumnIndex == 5 && e.RowIndex >= 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete User", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int DocId = default(int);
                        int.TryParse(Convert.ToString(grdPatientDoc.Rows[e.RowIndex].Cells[0].Value), out DocId);
                        int ClientId = Convert.ToInt32(objClientDAL.GetClientIdByDocId(DocId).ClientId.Value);
                        bool IsDeleted = objClientDAL.DeleteDocumentById(DocId);
                        if (IsDeleted)
                        {
                            MessageBox.Show("Document deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); BindDocumentList(ClientId);
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Server error. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

    }
}
