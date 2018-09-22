using System;
using System.Web;
using System.Web.UI;

namespace KLM
{
    public partial class Default : System.Web.UI.Page
    {
        public void button1Clicked(object sender, EventArgs args)
        {
        }
        public void btnSendEmail_Click(object sender, EventArgs args)
        {
            /*
            spR.InnerText = "";
            string FromName = "KLM Email Testing";
            string ToEmailAddress = emailTo.Text;
            string Subject = emailSubject.Text;
            string Body = emailBody.Text;
            string r = mail.SendMail(FromName, ToEmailAddress, Subject, Body);
            if(r==""){
                spR.InnerText = "Email sent!";

            } else {
                spR.InnerText = r;

            }
            */
        }
    }
}
