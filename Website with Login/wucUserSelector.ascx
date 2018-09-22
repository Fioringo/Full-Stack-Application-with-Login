<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucUserSelector.ascx.cs"
Inherits="KLM.wucUserSelector" %>

<script type="text/javascript">
    function refreshUserData(tr) {
        var u = tr.cells[2].innerHTML;
        $(".gridRowSelected").removeClass("gridRowSelected").addClass("gridRowUnSelected");
        $(tr).removeClass("gridRowUnSelected").addClass("gridRowSelected");

        if ('<%=returnUIdToFunction_UIdIsSelected %>' != '0')
        {
            if (typeof UIdIsSelected == "function") { UIdIsSelected (u); }
        }
        else
        {
            var palette = getParameterByName("palette");
            frmDoIt.action = "UserReg.aspx?palette="+ palette +"&H=no&uID=" +u;
            frmDoIt.submit();
        }
    }
    </script>
    <style>
    .divGridList { overflow-y:auto; margin-top:10px}
    .gridHeader th {text-align:center}
    .gridRow {cursor: pointer;}
    .gridRow td:first-child {text-align:right}
    </style>

<table id="tblComponent" runat="server" style="position:relative; width:300px">
            <tr><td> class="CompCaption">User Selector</td></tr>
            <tr style="vertical-align:top;">
            <td>
                <table style="width:100%" >
                        <tr style="vertical-align:middle">
                            <td><img src="pic/filter.jpg" width="16" height="16" alt="" /></td>
                            <td colspan = "2"> User Type <asp:DropDownList id="DDLUserTypes" runat="server" 
                                    AutoPostBack="true" OnSelectedIndexChanged="DDLUserTypes_SelectedIndexChanged">
                                </asp:DropDownList> </td>
                        </tr>
                        <tr style="vertical-align:middle">
                            <td><img src="pic/lupa.jpg" width="16" height="16" alt="" /></td>
                            <td style="width:100%">
                             <asp:TextBox id="tbSearch" runat="server" Width="100%" ></asp:TextBox>
                            </td>
                            <td><asp:Button id="btnSearch" runat="server" Text="Go" /></td>
                        </tr>
                        <tr>
                         <td colspan="3" class="techInfo">Total records found:
                                <asp:Label id="lblRows" runat="server" Text="0" CssClass="techInfo"></asp:Label>
                                </td>
                        </tr>
                        <tr><td colspan="3">
                            <div id="divGridList" class="divGridList" runat="server">
                            <asp:GridView id="grdUsers" runat="server" DataSourceID="UsersSource" Width="100%"
                                    OnRowDataBound="grdUsers_RowDataBound1"
                                    HeaderStyle-CssClass="gridHeader"
                                    RowStyle-CssClass = "gridRow gridRowUnselected"
                                    AutoGenerateColumns="true" EnableViewState="false"></asp:GridView>
                            </div>    
                            <asp:HiddenField id="hBtnIndSel" runat="server" EnableViewState="true" Value="1" />
                            <div id="buttonsPP" runat="server" enableviewstate="false"></div>
                        </td>
                        </tr>
                </table>
            </td>
        </tr>
    </table>
<asp:SqlDataSource id="UsersSource" runat="server"></asp:SqlDataSource>
        <script type="text/javascript">
            if(typeof (UsersSelectorUserControlIsLoaded) != 'undefined'){
                try{
                Sys.Application.add_load(function () {UserSelectorUserControlIsLoaded(); });
                }
                catch (ex) { }
            }
        </script>
