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
using EntityLayer;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;



namespace SPAPracticeManagement
{
    public partial class ForgotPassword : Form
    {
        int? branchID = ConfigurationSettings.AppSettings["BranchID"] == null ? 0 : Convert.ToInt32(ConfigurationSettings.AppSettings["BranchID"]);
        public ForgotPassword()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            panel3.Location = new Point(
    this.ClientSize.Width / 2 - panel3.Size.Width / 2,
    this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
        }

        public bool ValidateForm()
        {
            if (txtemail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter email.");
                return false;
            }
            else if (txtemail.Text.Trim() != string.Empty && !Regex.IsMatch(txtemail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
            {
                //if (!Regex.IsMatch(txt_thpemail.Text, @"[\w-]+@([\w-]+\.)+[\w-]+"))
                //{
                MessageBox.Show("Please enter valid Email");
                return false;
                //}
                //else
                //{
                //    return true;
                //}
            }
            
            else
            {
                return true;
            }
        }

        private string Decrypt(string cipherText)
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                UserDAL ud = new UserDAL();
                UserEL ue = new UserEL();
                Utility util = new Utility();
                bool ret = false;
                if (branchID == 0)
                {
                    MessageBox.Show("Branch id is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ue = ud.ForgotPassword(txtemail.Text.Trim(), branchID);
                    if (ue != null)
                    {
                        if (ue.UserId == 1)
                        {
                            ret = util.SendMailForForgotPassword(ue.Email, Decrypt(ue.Password));
                            if (ret)
                            {
                                MessageBox.Show("Password sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtemail.Text = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Error Occoured", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Email id is not registered with us.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btn_SendtoLogin_Click(object sender, EventArgs e)
        {
            Login objLogin = new Login();
            objLogin.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
