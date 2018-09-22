<%@ Page Language="C#" Inherits="KLM.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Login</title>
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type="text/javascript">
            $(document).ready(function(){
            //alert($("#lblMessage").text());
                if($("#lblMessage").text()=="Logged in"){
                //alert($("#huName").val());
                opener.loggedIn($("#huName").val());
                window.close();
            }
            });
            function forgotPassword(){
                //alert(123);
                document.getElementById('trLogin').style.display = "none";
                document.getElementById('trLoginBtn').style.display = "none";
                document.getElementById('trPassword').style.display = "none";
                document.getElementById('btnFogPass').setAttribute("disabled", 'disabled');
                document.getElementById('trEmail').style.display = "block";
                document.getElementById('trEmailOk').style.display = "block";
                document.getElementById('fogPassBtn').style.display = "none";
                document.getElementById('trFogPass').style.display = "block";
            }
            function fpcb(){
                var e = document.getElementById('tbEmail');
                if(e.value!=""){
                    var email = e.value;
                    window.open('emailConfirm.aspx?E=' + email);
                } else {
                    alert("no email entered");
                }
            }
            function loginClick(){
                
            }
        </script>
        <style>
            #btnFogPass {border:none;text-decoration:underline;}
            #trEmail {display:none;}
            #trFogPass {display:none; text-decoration:underline; border:none;}
            #trEmailOk {display:none;}
        </style>
</head>
<body>
	<form id="form1" runat="server">
            <table>
                <tr id="trLogin">
                <td>Login: </td><td><asp:TextBox id="tblogin" runat="server"></asp:TextBox></td>
                </tr>
                <tr id="trPassword">
                    <td>Password</td><td><input type="password" id="tbPass" runat="server" /></td>
                </tr>
                <tr id="trLoginBtn">
                    <td colspan=2><asp:Button id="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button></td>
                </tr>
                <tr id="fogPassBtn">
                    <td colspan=2><button id="btnFogPass" onclick="forgotPassword(); return false;">Forgot your password?</button></td>
                </tr>
                <tr id="trFogPass">
                    <td colspan=2><div id="divFogPass">Forgot Password.</div></td>
                </tr>
                <tr id="trEmail">
                    <td>Email:</td><td><asp:TextBox id="tbEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr id="trEmailOk">
                    <td colspan=2><button id="btnEmailOk" onclick="fpcb(); return false;">Submit</button></td>
                </tr>
           </table>
           <asp:Label id="lblMessage" runat="server"></asp:Label>
           <asp:HiddenField id="huName" runat="server"></asp:HiddenField>
	</form>
</body>
</html>
