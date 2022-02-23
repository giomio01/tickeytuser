<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style ="background-color:lightskyblue; font-size:xx-large" align="center">
    MIS Ticketing Services
    <script type="text/javascript">
        function ValidNumeric() {

            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode >= 48 && charCode <= 57) { return true; }
            else { return false; }
        }
    </script>
</div>
<br/>
<div style="background-image: url('pictures/BG.jpg'); font-style:oblique; font-size:large; padding:15px">

    <table class="nav-justified">
        <tr>
            <td style="width: 520px;">
                <asp:Label ID="Label1" runat="server" Text="Please Input Emp No:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" onkeypress="return ValidNumeric()" OnTextChanged="TextBox1_TextChanged" Height="20px" Width="203px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                </td>
            <td style="width: 596px">
                <img class="modal-sm" src="pictures/e24f6405-8cf3-4463-b12a-e32db966be6b.jpg" style="height: 113px; width: 390px" /></td>
        </tr>
        <tr>
            <td style="width: 520px; height: 19px;"></td>
            <td style="width: 596px; height: 19px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px">Employee Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" Enabled="False" style="margin-left: 4px"></asp:TextBox>
            </td>
            <td style="width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px; height: 20px">Department:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" Enabled="False" Width="116px" style="margin-left: 2px"></asp:TextBox>
            </td>
            <td style="width: 596px; height: 20px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px; height: 25px">Station:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" Enabled="False" style="margin-left: 0px" Width="115px"></asp:TextBox>
            </td>
            <td style="width: 596px; height: 25px;"></td>
        </tr>
        <tr>
            <td style="width: 520px"></td>
            <td style="width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px;">Type of Request:&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="Black">
                    <asp:ListItem>Network:Telephone or CCTV or Biometrics or Access Door</asp:ListItem>
                    <asp:ListItem>Mail</asp:ListItem>
                    <asp:ListItem>Hardware Desktop/Laptop/Server</asp:ListItem>
                    <asp:ListItem>Software HDF/QDN/Office/OS/DCC/Updates</asp:ListItem>
                    <asp:ListItem>Printer Office</asp:ListItem>
                    <asp:ListItem>Printer Prod ADLT MULTIBIZ or ECOLASER</asp:ListItem>
                    <asp:ListItem>Printer Prod ADGT MULTIBIZ or ECOLASER</asp:ListItem>
                    <asp:ListItem>Printer Prod ADLT BOXING or BAL</asp:ListItem>
                    <asp:ListItem>Printer Prod ADGT BOXING or BAL</asp:ListItem>
                    <asp:ListItem>Promis Terminal-all peripherals or MIPS and UBS system or WIP</asp:ListItem>
                    <asp:ListItem>Copier ADLT</asp:ListItem>
                    <asp:ListItem>Copier ADGT</asp:ListItem>
                    <asp:ListItem>Promis Account(creation, password reset, modification)</asp:ListItem>
                    <asp:ListItem>Assist Supplier or Vendor</asp:ListItem>
                    <asp:ListItem>Sound system  laptop, projector, microphone, TV </asp:ListItem>
                    <asp:ListItem>Others Virus scanning and transfer </asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px">
                <br />
                <br />
                Issues/Initial Action Taken:</td>
            <td style="width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td>
            <asp:TextBox ID="TextBox2" align="left" runat="server" Height="262px" Width="560px" TextMode="MultiLine" style="margin-left: 0" ViewStateMode="Enabled"></asp:TextBox>
            </td>
            <td style="width: 596px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px">&nbsp;</td>
            <td style="width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 520px">
                <asp:Button ID="Button1" runat="server" Height="74px" Text="GENERATE TICKET" Width="278px" Font-Bold="True" BorderColor="White" BorderStyle="Outset" BorderWidth="10px" />
            </td>
            <td style="height: 20px; width: 596px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 520px">
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td style="width: 596px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center"; style="width: 520px">
                &nbsp;</td>
            <td align="center"; style="width: 596px">
                &nbsp;</td>
        </tr>
    </table>

</div>
</asp:Content>

