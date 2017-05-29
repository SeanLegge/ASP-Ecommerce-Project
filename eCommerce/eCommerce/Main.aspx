<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="eCommerce.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sean's Book Store</title>
    <link href="/styles/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblGreeting" runat="server" Text="Hello and welcome to Sean's book shop."></asp:Label>
        <br />
        <br />

        <asp:Label ID="lblSummary" runat="server" Text=" We carry a wide variaty of books, from classic literature to comics and manga. Head to out Catalogue page to check out what's available."></asp:Label>
         <!--Create the Iframe that allows for the transition between the different frames-->
        <iframe id="mainFrame" name="Main" src="Catalogue.aspx" runat="server" style="background-color: white;"></iframe>
        <!--Create the radiobuttons that transition between the different frames-->
        <asp:RadioButtonList ID="rdlFrames" runat="server" OnSelectedIndexChanged="rdlFrames_SelectedIndexChanged" AutoPostBack ="True">
            <asp:ListItem Value="Customers.aspx">Customer</asp:ListItem>
            <asp:ListItem Value="Products.aspx">Products</asp:ListItem>
            <asp:ListItem Value="Catalogue.aspx">Catalogue</asp:ListItem>
            <asp:ListItem Value="Cart.aspx">Cart</asp:ListItem>
        </asp:RadioButtonList>
        
    </div>
    </form>
</body>
</html>
