using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace KLM
{
    public static class mail
    {
        public static string SendMail(string FromName, string ToEmailAddress, string Subject, string Body)
        {
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Port = 2525;
                smtpClient.Host = "mail.(YOURDOMAIN).com";
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential MyCredentials = new NetworkCredential("(YOURNETWORKEMAIL)@(YOURDOMAIN).com", "(YOURNETWORKEMAILPASSWORD)");
                smtpClient.Credentials = MyCredentials;
                MailAddress mailFromAddr = new MailAddress("NoReply@(YOURDOMAIN).com");
                ///////////////////////////////////////////////////////////////////
                string[] addresses = ToEmailAddress.Split(',');
                if (addresses.Count() < 1) { return "Error: The 'To' email address is not specified."; }
                MailAddress mailToAddr = new MailAddress(addresses[0]);
                MailMessage MyMessage = new MailMessage(mailFromAddr, mailToAddr);
                if (addresses.Count() > 1)
                {
                    string cc = ToEmailAddress.Substring(ToEmailAddress.IndexOf(',') + 1);
                    MyMessage.CC.Add(cc);
                }
                MyMessage.Subject = Subject;
                MyMessage.Body = Body;
                MyMessage.IsBodyHtml = true;
                smtpClient.Send(MyMessage);
                return "";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message + ": " + ex.InnerException;
            }
        }
    }
}
