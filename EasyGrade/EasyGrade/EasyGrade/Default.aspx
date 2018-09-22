<%@ Page Language="C#" Inherits="EasyGrade.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<style>
        body {margin:0;}
        
        #logo {position:absolute; width:100%; left:2px; top:2px; font-size:34px; text-align:center;}
        
        #login_btn {position:absolute; right:2px; background-color:black; color:white; border:none;}
        #login_btn:hover {background-color:grey;}
        
        #menu {position:absolute; width:100%; top:50px; background-color:grey; color:white;}
        
        #home_btn {background-color:grey; color:white; border:none;}
        #home_btn:hover {background-color:black; color:white; border:none;}
        
        #classes_btn {background-color:grey; color:white; border:none; display:none;}
        #classes_btn:hover {background-color:black; color:white; border:none;}
        
        #grades_btn {background-color:grey; color:white; border:none; display:none;}
        #grades_btn:hover {background-color:black; color:white; border:none;}
        
        #settings_btn {background-color:grey; color:white; border:none;}
        #settings_btn:hover {background-color:black; color:white; border:none;}
        
        #ifr {position:absolute; width:100%; top:90px; border:none;}
</style>
<body>
	<form id="form1" runat="server">
		<div id="logo"> Easy Grade </div>
        <div id="menu">
                <tr>
                    <tb>
                        <asp:Button id="home_btn" runat="server" Text="Home"></asp:Button>
                    </tb>
                    <tb>
                        <asp:Button id="classes_btn" runat="server" Text="Classes"></asp:Button>
                    </tb>
                    <tb>
                        <asp:Button id="grades_btn" runat="server" Text="Grades"></asp:Button>
                    </tb>
                    <tb>
                        <asp:Button id="settings_btn" runat="server" Text="Settings"></asp:Button>
                    </tb>
                    <tb>
                        <asp:Button id="login_btn" runat="server" Text="Login"></asp:Button>
                    </tb>
                </tr>
        </div>
        <iframe id="ifr" src="News.aspx"></iframe>
    </form>
</body>
</html>
