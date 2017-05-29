<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="eCommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <asp:Panel ID="pnlProduct" runat="server">
            <asp:Label ID="lblProductID" runat="server" Text="Product ID:"></asp:Label>
            <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblManuCode" runat="server" Text="Manufacturers Code: "></asp:Label>
            <asp:TextBox ID="txtManuCode" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPicture" runat="server" Text="Picture: "></asp:Label>
            <asp:FileUpload ID="fuImage" runat="server" />
            <br />
            <asp:Image ID="imgProduct" runat="server" />
            <br />
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity available: "></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnFind" runat="server" Text="FindProduct" OnClick="btnFind_Click" />
            <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

        </asp:Panel>
    </div>
    </form>
</body>
</html>
