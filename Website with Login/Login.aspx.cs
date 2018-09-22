using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KLM
{
    public partial class Login : System.Web.UI.Page
    {
        public string emailAddr = "";
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login = tblogin.Text;
            string pass = tbPass.Value;
            string sql = "SELECT * FROM Users WHERE u_Login = '" + login + "' AND u_Password = '" + pass + "'";
            Hashtable HT = DBFc.getDataHashtable(sql, Glob.cnn);
            if(HT != null){
                usr U = new usr();
                U.uLogin = HT["u_Login"].ToString();
                U.uEmail = HT["u_Email"].ToString();
                U.id = Convert.ToInt32(HT["u_ID"]);
                Session["usr"] = U;
                lblMessage.Text = "Logged in";
                huName.Value = HT["u_Name"].ToString();
            } else {
                lblMessage.Text = "Wrong login or password.";
            }
        }
    }
}
