using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KLM
{
    public partial class emailConfirm : System.Web.UI.Page
    {
        public string emailAddr = "";
        public string code = "";
        public bool bReturnPassword = false;
        protected void Page_Load(object sender, EventArgs e){
            emailAddr = (string)Request.Params["E"];
            if(emailAddr==null||emailAddr==""){
                pResult.InnerHtml = "Error: email Address is not set.";
            } else {
                if(!IsPostBack){
                    Random rn = new Random();
                    string code = rn.Next(100000, 999999).ToString();
                    Session["EmailConfCode"] = code;
                    string body = "Your Email Confirmation Code is " + code + " have fun :P";
                    string subject = "Email Confirmation Code";
                    mail.SendMail("Email Confirmation", emailAddr, subject, body);
                    btnOK.Enabled = true;
                }
            }
        }
        //================================
        protected void btnOK_Click(object sender, EventArgs e){
            if(txtCode.Text == Session["EmailConfCode"].ToString()) {
                pResult.InnerText = "Confirmed";
                Session.Remove("EmailConfCode");
            } else {
                pResult.InnerText = "Error: Wrong code entered.";
            }
        }
    }
}
