using DataAccessLayer;
using DataAccessLayer.Repository;
using EntityLayer;
using SPAPracticeManagement.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPAPracticeManagement;
 

namespace SPAPracticeManagement.Settings
{
    public partial class AddInventory : Dashboard
    {
        int? branchID = Convert.ToInt32(ConfigurationManager.AppSettings["BranchID"]);
        //SettingDAL objInventoryDAL = new SettingDAL();
        InventoryDAL objInventoryDAL = new InventoryDAL();
        SettingDAL objSettingDAL = new SettingDAL();
        private int _updateInventoryId;
        public int updateInventoryId
        {
            get { return _updateInventoryId; }
            set { _updateInventoryId = value; }
            
        }
        public AddInventory()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            BindGrid();
        }

        #region Methods
        private void BindGrid()
        {
            var Result = objInventoryDAL.GetInventoryData(branchID).ToList();
            if (Result.Count > 0)
            {
                dgrid_viewinventory.AutoGenerateColumns = false;
                dgrid_viewinventory.DataSource = Result.ToList();
            }
            else
            {
                MessageBox.Show("Record Does Not Exist !!!");
            }
          //  CreateColumns();
        }
        private void CreateColumns()
        {
            DataGridViewImageColumn imageColumn;
            Bitmap bmpImage = null;
            imageColumn = new DataGridViewImageColumn();
            var Result = objInventoryDAL.GetInventoryData(branchID).ToList();

            foreach (var item in Result)
            {
                byte[] img = (byte[])(Encoding.ASCII.GetBytes(Application.StartupPath + @"\InventoryImages\" + item.Inv_Image.Trim()));
                dgrid_viewinventory.Rows[0].Cells[3].Value = img;
            }
        }
        private string SaveFiles()
        {
            int count = 0;
            string[] FilenameName;
            string NewFileName = "";
            NewFileName = Guid.NewGuid().ToString();
            string NewPath = Application.StartupPath + @"\InventoryImages\" + NewFileName;
            foreach (string item in openFileDialog1.FileNames)
            {
                if (item == "openFileDialog1")
                {
                    return NewFileName = null;
                }
                else
                {
                    string ext = Path.GetExtension(openFileDialog1.FileName);
                    NewPath = NewPath + ext;
                    NewFileName = NewFileName + ext;
                    FilenameName = item.Split('\\');
                    File.Copy(item, NewPath);
                    count++;
                }
            }
            Image image = Image.FromFile(NewPath);
            pictureBox4.Image = resizeImage(259, 188, NewPath);
            return NewFileName;
        }
        public string GenerateId()
        {
            Random r = new Random();
            string value = "INV-0"+r.Next(1,1000).ToString();
            return value;
        }
        protected bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txt_itemname.Text.Trim()))
            {
                MessageBox.Show("Please enter Item Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_itemname.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txt_itemlocation.Text.Trim()))
            {
                MessageBox.Show("Please enter Item Location ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_itemlocation.Focus();
                return false;
            }
            //else if (string.IsNullOrEmpty(txt_itemimage.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter Item Image");
            //    txt_itemimage.Focus();
            //    return false;
            //}
            else if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("Please enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("Please enter Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ShowTextValues(int? Id)
        {
            var Value = objInventoryDAL.GetInventoryData(branchID).Where(x => x.Id == Id).FirstOrDefault();
            updateInventoryId = (int)Id;
            txt_itemname.Text = Value.Inv_Name.Trim();
            txt_itemlocation.Text = Value.Inv_Location.Trim();
            //txt_itemimage.Text = (Value.Inv_Image.ToString() == null ? null : Value.Inv_Image.ToString());
            txtQuantity.Text = Value.Quantity.ToString();
            txtPrice.Text = Value.Price.ToString();
            chk.Checked=(Value.IsActive == true ? true : false);
            //string NewPath = Application.StartupPath + @"\InventoryImages\" + Value.Inv_Image.Trim();
            //Image image = Image.FromFile(NewPath);
            //pictureBox4.Image = resizeImage(259, 188, NewPath);
            if (!string.IsNullOrEmpty(Value.Inv_Image))
            {
                string NewPath = Application.StartupPath + @"\InventoryImages\" + Value.Inv_Image.Trim();
                if (File.Exists(Application.StartupPath + @"\InventoryImages\" + Value.Inv_Image.Trim()))
                {
                    Image image = Image.FromFile(NewPath);
                    pictureBox4.Image = image;
                    //txt_itemimage.Text = Value.Inv_Image.Trim();
                }
            }
            else
            {
                Image image = Image.FromFile(Application.StartupPath + @"\Images\noimage.png");
                pictureBox4.Image = image;
                txt_itemimage.Text = string.Empty;
            }
        }
        public void ClearFields()
        {
            txt_itemimage.Text = "";
            txt_itemlocation.Text = "";
            txt_itemname.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            chk.Checked = false;
            pictureBox4.Image = null;
        }
        public Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (updateInventoryId > 0)
                {
                    string FilePath = SaveFiles();
                    int i = default(int);
                    InventoryEL objInventoryEL = new InventoryEL();
                    objInventoryEL.Id = updateInventoryId;
                    objInventoryEL.FK_BranchId = (int)branchID;
                    objInventoryEL.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    objInventoryEL.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                    objInventoryEL.Inv_Image = (FilePath == null ? txt_itemimage.Text.Trim() : FilePath);
                    objInventoryEL.Inv_Location = txt_itemlocation.Text.Trim();
                    objInventoryEL.Inv_Name = txt_itemname.Text.Trim();
                    objInventoryEL.IsActive = (chk.Checked == true ? true : false);
                    i = objInventoryDAL.InsertUpdateInventory(objInventoryEL);
                    if (i > 0)
                    { MessageBox.Show("Data updated successfully","Updation",MessageBoxButtons.OK,MessageBoxIcon.Information); }
                    else { MessageBox.Show("Data updation failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else
                {
                    string FilePath = SaveFiles();
                    int i = default(int);
                    InventoryEL objInventoryEL = new InventoryEL();
                    objInventoryEL.FK_BranchId = (int)branchID;
                    objInventoryEL.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    objInventoryEL.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                    objInventoryEL.Inv_Image = (FilePath == null ? txt_itemimage.Text.Trim() : FilePath);
                    objInventoryEL.Inv_Location = txt_itemlocation.Text.Trim();
                    objInventoryEL.Inv_Name = txt_itemname.Text.Trim();
                    objInventoryEL.IsActive = (chk.Checked == true ? true : false);
                    i = objInventoryDAL.InsertUpdateInventory(objInventoryEL);
                    if (i > 0)
                    { MessageBox.Show("Data inserted successfully", "Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else { MessageBox.Show("Data insertion failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                ClearFields();
                BindGrid();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    txt_itemimage.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void AddInventory_Load(object sender, EventArgs e)
        {

        }
        private void dgrid_viewinventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                string inventoryName = Convert.ToString(dgrid_viewinventory.Rows[e.RowIndex].Cells[2].Value);

                int inventoryId = default(int);
                int.TryParse(Convert.ToString(dgrid_viewinventory.Rows[e.RowIndex].Cells[0].Value), out inventoryId);
                if (inventoryId > 0) { ShowTextValues(inventoryId); } else { MessageBox.Show("Data Not Found"); }
            }
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                int inventoryId = default(int);
                int.TryParse(Convert.ToString(dgrid_viewinventory.Rows[e.RowIndex].Cells[0].Value), out inventoryId);
                Boolean? status = objSettingDAL.GetStatusOfInventory(inventoryId);
                if (!(Boolean)status)
                {
                    MessageBox.Show("This Inventory Item is already InActive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete User", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool IsDeleted = objInventoryDAL.DeleteInventoryById(inventoryId, Convert.ToInt32(branchID));
                        if (IsDeleted)
                        {
                            MessageBox.Show("Inventory deleted successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); BindGrid(); ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Server error. Please try again.");
                        }
                    }
                }
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }


        #endregion

        private void txtQuantity_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = Common.VadidateNumericCharecter(sender, e);
        }

        
    }
}
