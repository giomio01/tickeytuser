<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="confirm.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<div style="background-image: url('pictures/BG.jpg'); font-style:oblique; font-size:large; padding:15px">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        YOUR TICKET NUMBER IS:&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="64px" Text="OK" Width="171px" BorderStyle="Inset" />
    </form>
</body>
</html>
    </div>
