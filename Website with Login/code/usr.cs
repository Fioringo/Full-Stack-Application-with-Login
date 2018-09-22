using System;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
namespace KLM
{
    [Serializable]
    public class usr
    {
        public int id = 0;
        public string uName = "";
        public string uLogin = "";
        public string uEmail = "";
        public string uPassword = "";

        public int uFlag = 0;
        public enum Flags : int {
            Guest = 0,
            RegisteredUser = 1,
            CanceledByUser = 128,
            CanceledByAdmin = 256,
            Admin = 1024
        }
        public usr()
        {
            init();
        }
        private void init(){
            this.id = 0;
            this.uFlag = 0;
            this.uName = "";
            this.uLogin = "";
            this.uPassword = "";
        }
        //========================================================
        public usr(int id){
            if (id == 0) { init(); }
            else {
                Hashtable HT = DBFc.getDataHashtable(
                    "SELECT * FROM dbo.Users WHERE u_ID='" + id.ToString() + "'", Glob.cnn);
                this.id = id;
                this.uFlag = Convert.ToInt32(HT["u_flags"]);
                this.uName = HT["u_Name"].ToString();
                this.uLogin = HT["u_Login"].ToString();
                this.uPassword = HT["u_Password"].ToString();
            }
        }
        //========================================================
        // This is for User Login
        public usr(string Login, string Psw){
            Hashtable HT = DBFc.getDataHashtable("dbo.Users_getByLoginAndPassword@uLogin='" + Login + "', @u_Password='" + Psw + "', @u_Flags", Glob.cnn);
            if(HT != null){
                this.id = Convert.ToInt32(HT["id"]);
                this.uFlag = Convert.ToInt32(HT["u_flags"]);
                this.uName = HT["u_Name"].ToString();
                this.uLogin = HT["u_Login"].ToString();
                this.uEmail = HT["u_Email"].ToString();
                this.uPassword = Psw;
            }
        }
        //======================================================== not used
        private void getUserData()
        {
            string sql = "";
            sql = sql + "SELECT * FROM Users WHERE";
            if (uLogin != "")
            {
                sql += "u_Login = '" + uLogin + "'";
            }
            else if (uEmail != "")
            {
                sql += "u_Email = '" + uEmail + "'";
            }
            Hashtable HT = DBFc.getDataHashtable(sql, Glob.cnn);

        }
        //========================================================
        public string SaveNew(){
            string sql = "dbo.Users_AddNew @uName = N'"
                + this.uName + "', @uLogin = N'"
                + this.uLogin + "', @uPassword = N'"
                + this.uPassword + "', @uEmail = N'"
                + this.uEmail + "', @uAddress = N'No address provided', @uIP = N'0.0.0.0'";
            string r = DBFc.doSqlWithResultReturn(sql, Glob.cnn);
            if (r == "Fail") {
                r = "Error on creating a new DataBase record.";
            } else {
                this.id = Convert.ToInt32(r);
                r = "";
            }
            return r;
        }
        //========================================================
        public string Update(){
            string sql = "dbo.Users_Update @u_id=" + this.id.ToString()
                 + ", @u_Name = N'" + this.uName.Replace("'", "''")
                 + "', @u_Login = N'" + this.uLogin.Replace("'", "''")
                 + "', @u_Password = N'" + this.uPassword.Replace("'", "''") + "'";
            return DBFc.doSqlWithResultReturn(sql, Glob.cnn);
        }
        //========================================================
        public bool isAdmin()
        {
            return (this.uFlag & (int)Flags.Admin) > 0;
        }
        //========================================================
        public bool isGuest(){
            return (this.uFlag & (int)Flags.Guest) == 0;
        }
        //========================================================
        public string getUserType(){
            string r = "";
            if(this.isGuest()) {
                r = "Guest";
            } else if ((this.uFlag & (int)Flags.Guest) > 0) {
                r = "Guest";
            } else if (this.isAdmin()) {
                r = "Admin";
            }
            return r;
        }
    }
}
