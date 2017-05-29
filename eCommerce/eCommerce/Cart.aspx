<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="eCommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link type="text/css" rel="stylesheet" href="/styles/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblCart" runat="server">

        </asp:Table>
        <asp:Button ID="btnHiddenRemove" runat="server" Text="Button" style="visibility: hidden;" OnClick="RemoveItem_Click"/>
        Your total bill will be: $ <asp:Label ID="lblFinalTotal" runat="server" Text="0.00"></asp:Label>
        <br />
        <asp:Button ID="btnReCalculateTotal" runat="server" Text="ReCalculateTotal" OnClick="btnReCalculateTotal_Click" />
    </div>
    </form>
</body>
</html>
