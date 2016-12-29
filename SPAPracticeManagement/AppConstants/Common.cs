using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Security.Cryptography;


namespace SPAPracticeManagement.AppConstants
{
    public class Common
    {
        public static void ChangeBorderColour(PaintEventArgs e, TextBox textBox1)
        {
            Pen p = new Pen(Color.Red);
            Graphics g = e.Graphics;
            int variance = 3;
            g.DrawRectangle(p, new Rectangle(textBox1.Location.X - variance, textBox1.Location.Y - variance, textBox1.Width + variance, textBox1.Height + variance));
        }

        public static void Cleardata(Form fc)
        {
            foreach (Control item in fc.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox a = (TextBox)item;
                    a.Text = string.Empty;
                }
            }
        }

        public static bool VadidateNumericCharecter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                return true;
            }
            else if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d") && e.KeyChar != (char)Keys.Back)
            {
                return true;
            }
            else if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                return true;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool ExportToExcel(DataGridView dgApplicantList)
        {
            bool IsOkCancel = false;
            if (dgApplicantList.Rows.Count > 0)
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);



                    ////for (int i = 0; i <= dgApplicantList.RowCount - 1; i++)
                    ////{
                    ////    for (int j = 0; j <= dgApplicantList.ColumnCount - 1; j++)
                    ////    {
                    ////        DataGridViewCell cell = dgApplicantList[j, i];
                    ////        xlWorkSheet.Cells[i + 1, j+1] = cell.Value;
                    ////    }
                    ////}


                    ////// storing header part in Excel
                    ////for (int i = 0; i < dgApplicantList.Columns.Count - 1; i++)
                    ////{
                    ////    xlWorkSheet.Cells[1, i+1] = dgApplicantList.Columns[i+1].HeaderText;
                    ////}

                    //for (int i = 0; i <= dgApplicantList.RowCount - 1; i++)
                    //{
                    //    for (int j = 0; j <= dgApplicantList.ColumnCount - 1; j++)
                    //    {
                    //        DataGridViewCell cell = dgApplicantList[j, i];
                    //        xlWorkSheet.Cells[i + 1, j+1] = cell.Value;
                    //    }
                    //}

                    ////// storing Each row and column value to excel sheet
                    ////for (int i = 0; i <=dgApplicantList.Rows.Count - 1; i++)
                    ////{
                    ////    for (int j = 0; j <= dgApplicantList.Columns.Count-1; j++)
                    ////    {
                    ////        xlWorkSheet.Cells[i + 1, j + 1] = dgApplicantList.Rows[i].Cells[j].Value.ToString();
                    ////    }
                    ////}



                    //export header
                    for (int i = 1; i <= dgApplicantList.Columns.Count; i++)
                    {
                        xlWorkSheet.Cells[1, i] = dgApplicantList.Columns[i - 1].HeaderText;
                    }

                    //export data
                    for (int i = 1; i <= dgApplicantList.RowCount; i++)
                    {
                        for (int j = 1; j <= dgApplicantList.Columns.Count; j++)
                        {
                            xlWorkSheet.Cells[i + 1, j] = dgApplicantList.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }

                    System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
                    saveDlg.InitialDirectory = @"C:\";
                    saveDlg.Filter = "Excel files (*.xls)|*.xls";
                    saveDlg.FilterIndex = 0;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.Title = "Export Excel File To";
                    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string path = saveDlg.FileName;
                        xlWorkBook.SaveCopyAs(path);
                        xlWorkBook.Saved = true;
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                    }

                    else
                    {
                        IsOkCancel = true;
                    }
                }
                catch (Exception ex)
                {

                }
                if (IsOkCancel == true) { return false; }
                else { return true; }

                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool ExportToExcel(DataGridView dgApplicantList)
        //{
        //    if (dgApplicantList.Rows.Count > 0)
        //    {
        //        try
        //        {
        //            Excel.Application xlApp;
        //            Excel.Workbook xlWorkBook;
        //            Excel.Worksheet xlWorkSheet;
        //            object misValue = System.Reflection.Missing.Value;
        //            xlApp = new Excel.ApplicationClass();
        //            xlWorkBook = xlApp.Workbooks.Add(misValue);
        //            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //            for (int i = 1; i <= dgApplicantList.Columns.Count; i++)
        //            {
        //                xlWorkSheet.Cells[1, i] = dgApplicantList.Columns[i - 1].HeaderText;
        //            }

        //            for (int i = 0; i <= dgApplicantList.RowCount - 1; i++)
        //            {
        //                for (int j = 0; j <= dgApplicantList.ColumnCount - 1; j++)
        //                {
        //                    DataGridViewCell cell = dgApplicantList[j, i];
        //                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
        //                }
        //            }

        //            System.Windows.Forms.SaveFileDialog saveDlg = new System.Windows.Forms.SaveFileDialog();
        //            saveDlg.InitialDirectory = @"C:\";
        //            saveDlg.Filter = "Excel files (*.xls)|*.xls";
        //            saveDlg.FilterIndex = 0;
        //            saveDlg.RestoreDirectory = true;
        //            saveDlg.Title = "Export Excel File To";
        //            if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //            {
        //                string path = saveDlg.FileName;
        //                xlWorkBook.SaveCopyAs(path);
        //                xlWorkBook.Saved = true;
        //                xlWorkBook.Close(true, misValue, misValue);
        //                xlApp.Quit();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;                   
        //        }

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //Encryption
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //Decryption
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}
