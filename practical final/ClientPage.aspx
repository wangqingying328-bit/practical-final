<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="practical_final.ClientPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Customer Page</title>
</head>

<body>
<form id="form1" runat="server">

    <div style="text-align: right; padding: 10px;">
        welcome，<asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_Click" />
    </div>

    <h2>Your personal information</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <asp:GridView 
        ID="gvClient"
        runat="server"
        AutoGenerateColumns="true"
        Width="80%"
        CssClass="table"
        EmptyDataText="No personal information found">
    </asp:GridView>

    <br />
    <h2>Your booking information</h2>

    <asp:GridView 
        ID="gvReservations"
        runat="server"
        AutoGenerateColumns="true"
        Width="80%"
        CssClass="table"
        EmptyDataText="No booking records yet">
    </asp:GridView>

</form>
</body>
</html>