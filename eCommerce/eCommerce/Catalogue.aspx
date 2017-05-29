<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="eCommerce.Catalogue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogue</title>
    <link href="/styles/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblBooks" runat="server" BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CellPadding="5" CellSpacing="0">
            <asp:TableHeaderRow CssClass="TableHeader">
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>Product #</asp:TableCell>
                <asp:TableCell>Manufacture ID: </asp:TableCell>
                 <asp:TableCell>Name</asp:TableCell>
                 <asp:TableCell>Price</asp:TableCell>
                 <asp:TableCell></asp:TableCell>
             </asp:TableHeaderRow>
        </asp:Table>
        <asp:button ID="btnAddBookToCart" runat="server" text="Add To Cart" style="visibility: hidden;" OnClick="btnAddBookToCart_Click" />
        <asp:label ID="lblOutput" runat="server"></asp:label>
    </div>
    </form>
</body>
</html>
