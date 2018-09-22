<%@ Page Language="C#" Inherits="KLM.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
        <script type="text/javascript" src="/js/jquery.js"></script>
		<script type="text/javascript">
			function openUsers(){
                window.open('Users.aspx', 'ifr', '', true);
			}
            function emailConfirmationClick(){
                window.open('emailConfirm.aspx?E=email');
            }
            function loginClick(){
                //document.getElementById("ifr").setAttribute("src","Login.aspx");
                window.open('Login.aspx', 'ifr', '', true);
            }
            function testUsrClick(){
                window.open('test_usr.aspx', 'ifr', '', true);
            }
            function loggedIn(uName){
                document.getElementById('labal').style.display = "block";
                $("#labal").text("Hello, " + uName);
                document.getElementById('btnLogin').style.display = "none";
                document.getElementById('btnRegister').style.display = "none";
                document.getElementById('btnLogOut').style.display = "block";
                window.open('startPage.aspx', 'ifr', '', true);
                //alert(uName);
            }
            function registerClick(){
                window.open('test_usr.aspx', 'ifr', '', true);
            }
            function tradeClick(){
                window.open('trade.aspx', 'ifr', '', true);
            }
		</script>
</head>
    <style>
        body {margin:0;}
        #divHeader {position:absolute; height:70px; width:100%; background-color:#eef;}
            #btnLogin {position:absolute; right:10px; top:2px;}
            #btnRegister {position:absolute; right:10px; top:20px;}
            #labal {display:none; position:absolute; right:10px; top:2px;}
            #btnLogOut {display:none; position:absolute; right:10px; top:20px;}
        #divMenu {position:absolute; top:70px; height:20px; width:100%; background-color:#eff;}
        #divNav {position:absolute; top:90px; height:500px; left:0px; width:15%; background-color:#ef2;}
        #divContent {position:absolute; top:90px; left:200px; height:500px; width:85%; background-color:#eee;}
            #ifr {width:100%; height:100%; border:none;}
     </style>
<body>
	<form id="form1" runat="server">
        <div>
            <div id='divHeader'>
                    <span id="labal"></span>
                    <button id="btnLogin" onclick="loginClick(); return false;">Login</button>
                    <br/>
                    <button id="btnRegister" onclick="registerClick(); return false;">Register</button>
                    <button id="btnLogOut" onclick="logOutClick(); return false;">Log Out</button>
<!--                    <iframe id="ifrLogin" name="ifrLogin" src="Login.aspx"/>-->
            </div>
            <div id='divMenu'>
                    <button id="btnTrade" onclick="tradeClick(); return false;">Trade thing</button>
            </div>    
            <div id='divNav'>
                    
            </div>
            <div id='divContent'>
                    <iframe id="ifr" name="ifr" src=""/>
            </div>




            <!--
        <button id="btnUsers" runat="server" onclick="openUsers();">open users</button>
            <br/>
        <asp:TextBox id="emailTo" runat="server" placeholder="Email adress"></asp:TextBox>
            <br/>
        <asp:TextBox id="emailSubject" runat="server" placeholder="Subject"></asp:TextBox>
            <br/>
        <asp:TextBox id="emailBody" runat="server" placeholder="Body"></asp:TextBox>
            <br/>
        <asp:Button id="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send eMail"></asp:Button>
            <br/>
            <span id="spR" runat="server" style="color:red"></span>
            <br/>
        <asp:Button id="emailConfirmation" runat="server" OnClientClick="emailConfirmationClick();" Text="Open email confirmation"></asp:Button>
      
        <button id="testusr" onclick="testUsrClick();">Test usr.cs</button>
            <br/>

            /-->
        </div>
          
	</form>
   </body>
</html>
