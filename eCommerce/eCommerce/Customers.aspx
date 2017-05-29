<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="eCommerce.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Create the customer panel and the features that will be placed inside-->
        <asp:Panel ID="pnlCustomer" runat="server" CssClass="Panels">
            <asp:Label ID="lblCustomerID" runat="server" Text="Customer ID:"></asp:Label>
            <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblProvince" runat="server" Text="Province: "></asp:Label>
            <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code: "></asp:Label>
            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblPhone" runat="server" Text="Telephone Number: "></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />

            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
            <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnFind" runat="server" Text="Find Customer" OnClick="btnFind_Click" />
            <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

        </asp:Panel>
    </div>
    </form>
</body>
</html>
