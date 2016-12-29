using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Settings
{
    public partial class PrintSetup : Dashboard
    {
        SettingDAL ObjSettingDAL = new SettingDAL();

        public int _UpdPrintId;
        public int UpdPrintId
        {
            get { return _UpdPrintId; }
            set { _UpdPrintId = value; }
        }
        public PrintSetup()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            ShowTextValues();

            pbPageSize.Image = Image.FromFile(Application.StartupPath +@"\Images\Image.jpg");
        }
        public bool ValidateForm()
        {
            if (Convert.ToString(comboBox_pagesize.SelectedItem) == "")
            {
                MessageBox.Show("Please select a page size.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Save()
        {
            int IsAvailable = 0;
            try
            {
                if (ValidateForm())
                {
                    if (UpdPrintId > 0)
                    {
                        tblprintsetup objtblcompdetail = new tblprintsetup()
                        {
                            Id = UpdPrintId,
                            PageSize=comboBox_pagesize.SelectedItem.ToString(),
                            IsLetterHead=(chk_ActiveLetterHead.Checked==true?true:false)
                        };
                        IsAvailable = ObjSettingDAL.InsertPrintSetup(objtblcompdetail); ;
                        if (IsAvailable > 0)
                        {
                            MessageBox.Show("Updation Successfull");
                           
                        }
                    }
                    else
                    {
                        tblprintsetup objtblcompdetail = new tblprintsetup()
                        {
                            PageSize = comboBox_pagesize.SelectedItem.ToString(),
                            IsLetterHead = (chk_ActiveLetterHead.Checked == true ? true : false)
                        };
                        IsAvailable = ObjSettingDAL.InsertPrintSetup(objtblcompdetail);
                        if (IsAvailable > 0)
                        {
                            MessageBox.Show("Insertion Successfull");
                        }
                    }
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { return false; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ShowTextValues()
        {
            var ValPrint = ObjSettingDAL.PrintDetails();
            if (ValPrint != null)
            {
                UpdPrintId = ValPrint.Id;
                comboBox_pagesize.SelectedItem = ValPrint.PageSize;
                if (ValPrint.IsLetterHead==true)
                {
                    chk_ActiveLetterHead.Checked = true;
                    
                }
                else
                {
                    chk_ActiveLetterHead.Checked = false;
                }
               
            }
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
        private void comboBox_pagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pagesize = comboBox_pagesize.SelectedItem.ToString();
            string loc=Application.StartupPath + @"\Images\Image.jpg";
            pbPageSize.Image = null;

            switch (pagesize)
            {
                case "A1":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 2384/10;
                    pbPageSize.Width = 1684/10;
                    lblPage.Text = "Width (1684) X Height (2384)";
                    break;
                case "A2":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 1684/10;
                    pbPageSize.Width = 1191/10;
                    lblPage.Text = "Width (1191) X Height (1684)";
                    break;
                case "A3":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 1191/10;
                    pbPageSize.Width = 842/10;
                    lblPage.Text = "Width (842) X Height (1191)";
                    break;
                case "A4":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 842/10;
                    pbPageSize.Width = 595/10;
                    lblPage.Text = "Width (595) X Height (842)";
                    break;
                case "A5":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 595/10;
                    pbPageSize.Width = 420/10;
                    lblPage.Text = "Width (420) X Height (595)";
                    break;
                case "B1":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 2835/10;
                    pbPageSize.Width = 2004/10;
                    lblPage.Text = "Width (2004) X Height (2835)";
                    break;
                case "B2":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 2004/10;
                    pbPageSize.Width = 1417/10;
                    lblPage.Text = "Width (1417) X Height (2004)";
                    break;
                case "B3":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 1417/10;
                    pbPageSize.Width = 1001/10;
                    lblPage.Text = "Width (1001) X Height (1417)";
                    break;
                case "B4":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 1001/10;
                    pbPageSize.Width = 709/10;
                    lblPage.Text = "Width (709) X Height (1001)";
                    break;
                case "B5":
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 709/10;
                    pbPageSize.Width = 499/10;
                    lblPage.Text = "Width (499) X Height (709)";
                    break;
                default:
                    pbPageSize.Image = Image.FromFile(loc);
                    pbPageSize.Height = 842/10;
                    pbPageSize.Width = 595/10;
                    lblPage.Text = "Width (1684) X Height (2384)";
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox_pagesize.SelectedItem = "A4";
            chk_ActiveLetterHead.Checked = false;
        }
    }
}
