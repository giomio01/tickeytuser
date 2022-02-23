<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-image: url('pictures/BG.jpg'); font-style:oblique; font-size:large; position:center; padding:15px">
    <h2><%: Title %></h2>
    <p>Our contact page.</p>

    <address>
        Gateway Business Park<br />
        Brgy. Javalera<br />
        Gen. Trias Cavite<br />
        <abbr title="Phone">Local:</abbr>
        1036
    </address>

    <address>
        <strong>Support:</strong><a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
        </div>
</asp:Content>
