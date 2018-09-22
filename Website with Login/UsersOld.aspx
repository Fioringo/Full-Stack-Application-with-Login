<%@ Page Language="C#" Inherits="Users" %>
<%@ Register src="~/wucUserSelector.ascx" tagname="wucUserSelector" tagprefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Users</title>
	<style>
			#divList {width:380px;height:600px;position:absolute;top:70px;left:10px;border:1px solid #aaaaff}
			#divAccount {width:600px;height:600px;position:absolute;top:70px;left:400px;border:1px solid #ffaaaa}
	</style>
    <script type="text/javascript">
       
    </script>
</head>
<body>
	<form id="form1" runat="server">
            <div id="divUserSelector" class="workPanel rounded">
            <uc1:wucUserSelector ID="USelector" runat="server" usCaption=""
                usWidth="250px" usHeight="384px" />
            </div>
			<h1>Users</h1>
			<div id="divList">
				<uc1:userList id="uSelector" runat="server"></uc1:userList>
			</div>
			<div id="divAccount">
			</div>
			
	</form>
    </body>
</html>
