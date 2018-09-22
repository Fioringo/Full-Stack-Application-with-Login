using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace KLM
{
    public class DBFc
    {
        public DBFc() {}
        //======================================================================
        public static string doNonQuerySql(string sql, string cnn){
            string r = "";
            SqlConnection oConn = new SqlConnection(cnn);
            if (OpenConnection(oConn)) {
                r = "Cannot open DB Connection.";
                goto ee;
            }
            try {
                SqlCommand cmd = new SqlCommand(sql, oConn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exp) {
                r = "DBF: " + exp.Message;
            } finally {
                ConnectionClose(oConn);
            }
            ee: return r;
        }
        //================================================
        private static void ConnectionClose(SqlConnection Conn){
            if(Conn.State == ConnectionState.Open) {
                Conn.Close();
                Conn.Dispose();
            }
        }
        //================================================
        public static DataTable getDataTableAndReturnValue(string sqlToCallStoredProc, out int n, string cnn) {
            n = -1;
            string r = "";
            DataTable dt = null;
            SqlConnection oConn = new SqlConnection(cnn);
            if(OpenConnection(oConn)){
                r = "Cannot open DB Connection.";
                goto ee;
            } try {
                SqlCommand cmd = new SqlCommand(sqlToCallStoredProc, oConn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dt = ds.Tables[0];
                n = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            } catch (Exception exp) {
                r = "DBF: " + exp.Message;
            } finally {
                ConnectionClose(oConn); 
            }
            ee: return dt;
        }
        //================================================
        public static DataSet getDataSet(string sql, string cnn){
            return getDataSet(sql, "t", cnn);
        }
        //================================================
        public static DataSet getDataSet(string sql, string tblName, string cnn){
            string r = "";
            DataSet ds = null;
            SqlConnection oConn = new SqlConnection(cnn);
            if(OpenConnection(oConn)){
                r = "Cannot open DB Connection.";
                goto ee;
            }
            try {
                SqlCommand cmd = new SqlCommand(sql, oConn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, tblName);
            }
            catch (Exception exp){
                r = "DBF: " + exp.Message;
            }
            finally {
                ConnectionClose(oConn);
            }
            ee: return ds;
        }
        //================================================
        public static DataTable getDataTable(string sql, string cnn, out string result){
            return getDataTable(sql, "t", cnn, out result);
        }
        //================================================
        public static DataTable getDataTable(string sql, string tblName, string cnn, out string result){
            string r = "";
            DataTable dt = null;
            SqlConnection oConn = new SqlConnection(cnn);
            if(OpenConnection(oConn)){
                r = "Cannot open DB Connection.";
                goto ee;
            }
            try{
                SqlCommand cmd = new SqlCommand(sql, oConn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds, tblName);
                dt = ds.Tables[tblName];
            }
            catch(Exception exp){
                r = "DBF: " + exp.Message;
            }
            finally{
                ConnectionClose(oConn);
            }
        ee:
            result = r;
            return dt;
        }
        //================================================
        public static SqlDataReader getDataReader(string sql, string cnn){
            SqlDataReader DR = null;
            SqlConnection oConn = new SqlConnection(cnn);
            if(OpenConnection(oConn)){
                goto ee;
            }
            try{
                SqlCommand cmd = new SqlCommand(sql, oConn);
                DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch{}
        ee: return DR;
        }
        //================================================
        public static string[] getArrayOfValues(string SQL, string cnn){
            List<string> L = new List<string> { };
            SqlDataReader DR = getDataReader(SQL, cnn);
            if(DR!=null){
                try{
                    while(DR.Read()){
                        L.Add(DR[0].ToString());
                    }
                }
                finally{
                    DR.Close();
                    DR.Dispose();
                }
            }
            string[] r = new string[L.Count];
            L.CopyTo(r);
            return r;
        }
        //================================================
        public static string doSqlWithResultReturn(string sql, string cnn){
            string r = "Fail";
            SqlDataReader DR = null;
            SqlConnection oConn = new SqlConnection(cnn);
            if(OpenConnection(oConn)){
                goto ee;
            }
            try{
                SqlCommand cmd = new SqlCommand(sql, oConn);
                //DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DR = cmd.ExecuteReader();
                if (DR.HasRows) DR.Read();
                r = DR.GetValue(0).ToString();
                DR.Close();
            }
            catch(Exception e){
                r = "*DBFc: " + e.Message;
            }
            finally{
                ConnectionClose(oConn);
            }
        ee: return r;
        }
        //================================================
        public static Hashtable getDataHashtable(string sql, string cnn){
            SqlConnection oConn = new SqlConnection(cnn);
            Hashtable HT = null;
            if(OpenConnection(oConn)){
                goto ee;
            }
            try{
                SqlCommand cmd = new SqlCommand(sql, oConn);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows){
                    dr.Read();
                    HT = HashTableFromCurrentSqlDataReaderRow(dr);
                }
                dr.Close();
            }
            catch{}
            finally{
                ConnectionClose(oConn);
            }
            ee: return HT;
        }
        //================================================
        public static Hashtable HashTableFromCurrentSqlDataReaderRow(SqlDataReader dr){
            Hashtable HT = new Hashtable();
            for (int i = 0; i < dr.FieldCount;i++){
                HT.Add(dr.GetName(i), dr.GetValue(i));
            }
            return HT;
        }
        //================================================
        public static bool OpenConnection(SqlConnection oConn){
            bool r = false;
            try{
                oConn.Open();
            }
            catch(Exception exp){
                r = true;
            }
            return r;
        }
        //================================================
        //================================================
	}
}