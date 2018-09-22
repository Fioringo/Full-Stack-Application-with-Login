using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

namespace KLM
{

    public partial class wucUserSelector : System.Web.UI.UserControl
    {
        private string sqlWHERE = "";
        private string sqlOrderBy = "u_Name";
        //================================================
        private string m_usCaption = "User Selector";
        private string m_usCoID = "0";

        public string usCoID
        {
            get { return m_usCoID; }
            set { m_usCoID = value; }
        }
        public string usCaption
        {
            get { return m_usCaption; }
            set { m_usCaption = value; }

        }
        //=============
        private string m_usWidth = "200px";
        public string usWidth
        {
            get { return m_usWidth; }
            set { m_usWidth = value; tblComponent.Style.Add("width", m_usWidth); }
        }
        //=============
        private string m_usHeight = "300px";
        public string usHeight
        {
            get { return m_usHeight; }
            set
            {
                m_usHeight = value;
                divGridList.Style.Add("height", m_usHeight);
            }
        }
        //==============
        private string m_returnUIdToFunction_UIdIsSelected = "0";
        public string returnUIdToFunction_UIdIsSelected
        {
            get { return m_returnUIdToFunction_UIdIsSelected; }
            set
            {
                m_returnUIdToFunction_UIdIsSelected = value;
            }
        }
        //================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDDLUserTypes();
                createSqlWHERE();
                getRowsNumber("");
            }
            else
            {
                createSqlWHERE();
                getRowsNumber(sqlWHERE);

            }
            //Pager
            string ctrlmame = Request.Params.Get("_EVENTTARGET");
            if (ctrlmame != null && ctrlmame != string.Empty)
            {
                pageCurrIndex = 1;
            }
            else
            {
                pageCurrIndex = int.Parse(hBtnIndSel.Value);
            }
            CreateButtons();
            ReadDB(rowsCurrOffset, pageSize);
            tbSearch.Attributes.Add("onKeyUp", "true;");

            //compCaption.innerHTML = usCaption;

        }
        //====================================================================================
        private void fillDDLUserTypes()
        {
            DDLUserTypes.Items.Clear();
            DDLUserTypes.Items.Add(new ListItem("All", "0,1024"));
            DDLUserTypes.Items.Add(new ListItem("User", "0,1408"));
            DDLUserTypes.Items.Add(new ListItem("Moderator", "128,1024"));
            DDLUserTypes.Items.Add(new ListItem("Administrator", "256,1024"));
            DDLUserTypes.Items.Add(new ListItem("Canceled user", "1024"));

        }
        //=============================
        private string createSqlWHERE()
        {
            string s = " WHERE 1=1 ";
            if (DDLUserTypes.SelectedItem != null && DDLUserTypes.SelectedItem.Value != "")
            {
                string flagsOn = DDLUserTypes.SelectedValue.Split(',')[0];
                string flagsOff = "0";
                if (DDLUserTypes.SelectedValue.Split(',').Length > 1) {flagsOff = DDLUserTypes.SelectedValue.Split(',')[1]; }
                //s += " AND ((u_Type & " + flagsOn + " = " + flagsOn + " AND u_Type & " + flagsOff + " = 0) "
                //    + " OR (u_Type = " + flagsOn + " AND u_Type & " + flagsOff + " =0))";
            }
            if (tbSearch.Text != "")
            {
                s += " AND CharIndex(UPPER(N'" + tbSearch.Text.Replace("'", "''") + "'),UPPER(";
                s += "u_Name+'|'+";
                s += "u_Login+'|'+u_Email+'|'+";
                s += "u_Comments";
                s += "))>0";
            }
            this.sqlWHERE = s;
            return s;
        }
        //============================================================================================
        private void getRowsNumber(string sqlWhere)
        {
            int r = 0;
            r = Convert.ToInt32(DBFc.doSqlWithResultReturn("SELECT count(*) FROM Users " + sqlWhere, Glob.cnn));
            lblRows.Text = r.ToString();
            rowsTotal = r;
        }
        //============================================================================================
        private void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseup"] = "javascript:refreshUserData(this);";
            }
            e.Row.Cells[2].CssClass = "dnone";
        }
        //==========
        protected void ReadDB(int rowsCurrOffset, int pageSize)
        {
            string s =
                "WITH  numbered_Users AS (SELECT ROW_NUMBER() OVER (ORDER BY " + sqlOrderBy + ") AS [#]"
                + ", u_Name as [Name]"
                + ", uID as [ID] FROM Users ";
            s += sqlWHERE + ") ";
            s += "SELECT * FROM numbered_USers WHERE [#] BETWEEN "
                + (rowsCurrOffset + 1).ToString() + " AND " + (rowsCurrOffset + pageSize).ToString();
            UsersSource.ConnectionString = Glob.cnn;
            UsersSource.SelectCommand = s;
            grdUsers.DataBind();
        }
        //===========
        protected void DDLUserTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //============
        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        //========== PAGER ==============
        private int m_pageSize = 100;
        public int pageSize
        {
            get { return m_pageSize; }
            set
            {
                if (value > 0)
                {
                    m_pageSize = value;
                    CalcPageMaxIndex();
                    pageCurrIndex = 1;
                }
            }

        }
        //================
        private int m_rowsTotal = 0;
        protected int rowsTotal
        {
            get { return m_rowsTotal; }
            set
            {
                m_rowsTotal = value;
                CalcPageMaxIndex();
            }
        }
        //========================
        protected void CalcPageMaxIndex()
        {
            pageMaxIndex = m_rowsTotal / m_pageSize;
            if (m_pageSize * pageMaxIndex < m_rowsTotal) { pageMaxIndex++;  }
        }
        //==========================
        private int m_pageCurrIndex = 1;
        protected int pageCurrIndex
        {
            get { return m_pageCurrIndex; }
            set
            {
                m_pageCurrIndex = value;
                if (m_pageCurrIndex > pageMaxIndex) { m_pageCurrIndex = pageMaxIndex++; }
                if (m_pageCurrIndex < 1) { m_pageCurrIndex = 1; }
                rowsCurrOffset = m_pageSize * (pageCurrIndex - 1);
            }
        }
        //==========================
        private int m_pagePickLen = 15;
        public int pagePickLen
        {
            get { return m_pagePickLen; }
            set { m_pagePickLen = value; }
        }
        //==========================
        private int rowsCurrOffset = 0;
        private int pageMaxIndex = 0;
        //==========================
        private string m_toFirstText = "<<";
        public string toFirstPageButtonText { get { return m_toFirstText; } set { m_toFirstText = value; } }
        private string m_toPrevText = "...";
        public string toPrevPageButtonText { get { return m_toPrevText; } set { m_toPrevText = value; } }
        private string m_toNextText = "...";
        public string toNextPageButtonText { get { return m_toNextText; } set { m_toNextText = value; } }
        private string m_toLastText = ">>";
        public string toLastPageButtonText { get { return m_toLastText; } set { m_toLastText = value; } }
        //=========================
        public void CreateButtons()
        {
            buttonsPP.Controls.Clear();
            buttonsPP.Attributes.Add("class","PagerBtn");
            if (pageMaxIndex < 2) { buttonsPP.InnerHtml = "&nbsp; "; goto ee; }
            string hID = FindControl("hBtnIndSel").ClientID;
            Button btnPP = new Button();
            btnPP.ID = "btnPPm4";
            btnPP.Text = toFirstPageButtonText;
            btnPP.Attributes.Add("OnClick", hID + ".value='1';");
            btnPP.CssClass = "PagerBtn";
            buttonsPP.Controls.Add(btnPP);
            btnPP = new Button();
            btnPP.ID = "btnPPm3";
            btnPP.Text = toPrevPageButtonText;
            btnPP.Attributes.Add("OnClick",hID + ".value='" + (pageCurrIndex == 1 ? 1 : pageCurrIndex - 1).ToString() + "';");
            btnPP.CssClass = "PagerBtn";
            buttonsPP.Controls.Add(btnPP);

            int k1 = pageCurrIndex - pagePickLen / 2; if (k1 < 1) { k1 = 1; }
            int k2 = k1 + pagePickLen - 1;
            if(k2 > pageMaxIndex){
                k2 = pageMaxIndex;
                k1=k2-pagePickLen + 1;  if (k1 < 1) { k1 = 1; }}
            for (int k = k1; k <= k2;k++){
                btnPP = new Button();
                btnPP.ID = "btnPP" + k.ToString();
                btnPP.Text = k.ToString();
                btnPP.Attributes.Add("OnClick", "document.getElementById('" + hID + "').value='" + k.ToString() + "';");
                btnPP.CssClass = "PagerBtn";
                buttonsPP.Controls.Add(btnPP);
                if (k == pageCurrIndex) btnPP.Style.Add("Color", "#DD3333");
            }
            btnPP = new Button();
            btnPP.ID = "btnPPm2";
            btnPP.Text = toNextPageButtonText;
            btnPP.Attributes.Add("OnClick", hID + ".value='" + (pageCurrIndex == pageMaxIndex ? pageMaxIndex : pageCurrIndex + 1).ToString() + "';");
            btnPP.CssClass = "PagerBtn";
            buttonsPP.Controls.Add(btnPP);
            btnPP = new Button();
            btnPP.ID = "btnPPm1";
            btnPP.Text = toLastPageButtonText;
            btnPP.Attributes.Add("OnClick", hID + ".value='" + pageMaxIndex.ToString() + "';");
            btnPP.CssClass = "PagerBtn";
            buttonsPP.Controls.Add(btnPP);
        ee:;
        }
    }
}
