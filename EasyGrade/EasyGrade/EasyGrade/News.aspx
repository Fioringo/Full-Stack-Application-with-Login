<%@ Page Language="C#" Inherits="EasyGrade.News" %>
<!DOCTYPE html>
<html>
    <head runat="server">
    	<title>News</title>
    </head>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript">
        $(window).load(function(){
            console.log("loadFunction");
            for(var i = 0; i < 3; i++){
                var para = document.createElement("div");
                var node = document.createTextNode ("Here go news.");
                para.appendChild(node);
        
                var element = $('#Content');
                element.appendChild(para);
            }
        });
        
    </script>
    <style>
        #things {display:none;}
    </style>
    <body>
    	<form id="form1" runat="server">
                <asp:Label id="things" runat="server" Text="things"></asp:Label>
                <div id="Content"></div>
    	</form>
    </body>
</html>
