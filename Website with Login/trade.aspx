<%@ Page Language="C#" Inherits="KLM.trade" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>trade</title>
</head>
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript">
        var ctx;
        var heightMax;
        function drawLine(){
            alert($('#hXList').val());
            var data = $('#hXList').val().split(",");
            var yMin = data[1];
            var yMax = data[1];
            var n = data[0];
            for(var i=2;i <= n;i++){
                if(data[i] < yMin){yMin = data[i];}
                if(data[i] > yMax){yMax = data[i];}
            }
            //alert(data);
            var can1 = $('#can1')[0];
            can1.height = 450;
            can1.width = 1020;
            //ctx.clear();
            ctx = can1.getContext('2d');
            for(var i=1 ; i < n; i++){
                draw(i,i+1,data[i],data[i+1]);
            }

        }

        function draw(x1,x2,y1,y2){
            y1 = y1*100+125;
            y2 = y2*100+125;
            ctx.beginPath();
            ctx.moveTo(x1,y1);
            ctx.lineTo(x2,y2);
            ctx.stroke();
            ctx.closePath();
        }
</script>
<style>
    .hXList {display:none;}
    .box {float:left;}
    .txb {width:50px;height:15px;margin-right:10px;}
    .btn {width:50px;height:15px;background-color:"abc"}
    #can1 {width:1020px;height:450px;border:1px solid #aaa;position:absolute;top:30px;left:2px;}
</style>
<body>
	<form id="form1" runat="server">
            <div>
                <div class="box">
                    <asp:Label>xMin</asp:Label>
                    <asp:TextBox id="txbxMin" class="txb" runat="server">0.50</asp:TextBox>
                </div>
                <div class="box">
                    <asp:Label>xMax</asp:Label>
                    <asp:TextBox id="txbxMax" class="txb" runat="server">1.50</asp:TextBox>
                </div>
                <div class="box">
                    <asp:Label>yMin</asp:Label>
                    <asp:TextBox id="txbyMin" class="txb" runat="server">0</asp:TextBox>
                </div>
                <div class="box">
                    <asp:Label>yMax</asp:Label>
                    <asp:TextBox id="txbyMax" class="txb" runat="server">1000</asp:TextBox>
                </div>
                <div class="box">
                    <asp:Button clas="btn" id="btngo" Text="ok" OnClick="btngo_Click" runat="server"></asp:Button>
                    <input type="button" id="goButton" value="Draw" onclick="drawLine();" />
                </div>
            </div>
            <canvas id="can1"></canvas>
            <asp:HiddenField runat="server" id="hXList"></asp:HiddenField>
	</form>
</body>
</html>
