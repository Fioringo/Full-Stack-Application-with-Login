<%@ Page Language="C#" Inherits="KLM.emailConfirm" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>emailConfirm</title>
        <script src="js/jquery.js"></script>
        <script type="text/javascript">
            $(document).ready(function(){
                if($("#pResult").text()=="Confirmed") {
                    $("#pResult").css("color", "#0b0");
                    $("#btnOK").attr("disabled", "disabled");
                    opener.emailConfirmationResult("True");
                    setTimeout(function() { window.clos();}, 1000);
                } else {
                    $("pResult").css("color", "#c00");
                }
            });
        </script>
        <style>
            #txtCode {width:60px;}
        </style>
</head>
<body style="margin:0;padding:0;"> 
	<form id="form1" runat="server">
        <div style="width:300px; padding:10px;">
            <div>
                    <span style="margin-leeft:25px;">Email Confirmation</span>
            </div>
            <p>
                    A message with an <b> Email Confirmation Code </b> has been sent to&nbsp;your e-mail address.<br />
                    Please open your inbox. Enter the found code into the txt bow below and click "ok".
            </p>
            <div style="text-align:center;">
                    <asp:TextBox id="txtCode" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button id="btnOK" runat="server" Text="Ok" Enabled="false" OnClick="btnOK_Click" />
            </div>
            <p id="pResult" runat="server"></p>
        </div>
	</form>
</body>
</html>
