using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Utility
    {
        public bool SendMail(string EmailTo)
        {
            bool ret = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("amitava.awon@indusnet.co.in");
                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                string[] MultiEmail = EmailTo.Split(',');
                foreach (var item in MultiEmail)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.To.Add(new MailAddress(item));
                    }
                }
                mail.Subject = "Appointment Reminder";
              
                mail.Body = " Just to remind you that your appointment has been booked. We look forward for your visit. Stay happy & healthy. Thank You";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["FromEmailPassword"].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }

        public bool SendBirthDayMail(String msg,string EmailTo)
        {
            bool ret = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("amitava.awon@indusnet.co.in");
                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                string[] MultiEmail = EmailTo.Split(',');
                foreach (var item in MultiEmail)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.To.Add(new MailAddress(item));
                    }
                }
                mail.Subject = "Birthday Wish";
                mail.Body = msg;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["FromEmailPassword"].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
        public bool SendMessage(string msg, string mobile)
        {
            try
            {
                // string strUrl =  "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user= Username:Password&senderID=mVaayoo&receipientno=919849558211&msgtxt=This is a test from mVaayoo API&state=4";
                // string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=goutam_rath@yahoo.co.in:APG8ffPE&senderID=TEST SMS&receipientno=918017144645&msgtxt=This is a test from mVaayoo API&state=4"; 
                // Status=0,ins37_14532025639675   // Response after successful compose

                bool ret = false;

                string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=goutam_rath@yahoo.co.in:APG8ffPE&senderID=TSMEDI&receipientno=" + mobile + "&msgtxt=" + msg + "&state=4";
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(strUrl);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();

                if (responseString.Contains("Status=0"))
                {
                    ret = true;
                }
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SendMailForForgotPassword(string EmailTo, string password)
        {
            bool ret = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("amitava.awon@indusnet.co.in");
                string[] MultiEmail = EmailTo.Split(',');
                foreach (var item in MultiEmail)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        mail.To.Add(new MailAddress(item));
                    }
                }
                mail.Subject = "Password Recovery";
                mail.Body = "Your Password is : " + password;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["FromEmailPassword"].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
    }
}
