using System;
using System.Web;
using System.Web.UI;

namespace KLM
{

    public partial class test_usr : System.Web.UI.Page
    {
        protected void btnUCreate_Click(object sender, EventArgs e){
            string Name = tbUName.Text;
            string Pass = tbUPass.Text;
            string Login = tbULogin.Text;
            string Email = tbUEmail.Text;
            int Flag = 0;//Convert.ToInt32(tbUFlag.Text);
            //int Id = 0;
            usr U = new usr();
            U.uName = tbUName.Text;
            U.uPassword = tbUPass.Text;
            U.uLogin = tbULogin.Text;
            U.uEmail = tbUEmail.Text;
            U.uFlag = Flag;
            U.SaveNew();
        }
           
    }
}
