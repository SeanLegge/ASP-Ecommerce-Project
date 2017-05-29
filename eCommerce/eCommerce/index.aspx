<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="eCommerce.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <link href="/styles/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <!--Create the Iframe that allows for the transition between the different frames-->
        <iframe id="generalFrame" name="General" src="Customers.aspx" runat="server" style="background-color: white;"></iframe>
        <!--Create the radiobuttons that transition between the different frames-->
        <asp:RadioButtonList ID="rdlFrames" runat="server" OnSelectedIndexChanged="rdlFrames_SelectedIndexChanged" AutoPostBack ="True">
            <asp:ListItem Value="Customers.aspx">Customer</asp:ListItem>
            <asp:ListItem Value="Products.aspx">Products</asp:ListItem>
            <asp:ListItem Value="Catalogue.aspx">Catalogue</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    </form>
</body>
</html>
