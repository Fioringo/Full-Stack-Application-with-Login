using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections;

namespace KLM
{

    public partial class trade : System.Web.UI.Page
    {
		protected void btngo_Click(object sender, EventArgs e){
			readDataBase();
        }
		private void readDataBase(){
			string result = "";
			string sql = "SELECT TOP 1000 r_Rate FROM dbo.Rate";
			DataTable DT = DBFc.getDataTable(sql, Glob.cnn, out result);
			hXList.Value = DT.Rows.Count.ToString();
			for (int i = 0; i < 1000;i++){
				hXList.Value += ',' + DT.Rows[i]["r_Rate"].ToString();
			}
        }
    }
}
