<%@ Page Language="C#" Inherits="KLM.test_usr" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>test_usr</title>
</head>
<body>
	<form id="form1" runat="server">
            <table>
                <tr><td>id</td><td><asp:TextBox id="tbUid" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td>Login</td><td><asp:TextBox id="tbULogin" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td>Email</td><td><asp:TextBox id="tbUEmail" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td>Name</td><td><asp:TextBox id="tbUName" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td>Password</td><td><asp:TextBox id="tbUPass" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td>Flag</td><td><asp:TextBox id="tbUFlag" runat="server"></asp:TextBox></td><td></td></tr>
                <tr><td><asp:Button id="btnUCreate" runat="server" Text="Create" OnClick="btnUCreate_Click"></asp:Button></td><td><asp:Button id="btnUpdate" runat="server" Text="Update"></asp:Button></td><td><asp:Button id="btnUread" runat="server" Text="Read"></asp:Button></td></tr>
            </table>
     </form>
</body>
</html>
