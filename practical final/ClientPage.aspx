<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="HotelSite.ClientPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>客户页面</title>
</head>

<body>
<form id="form1" runat="server">

    <div style="text-align: right; padding: 10px;">
        欢迎，<asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Text="退出登录" OnClick="btnLogout_Click" />
    </div>

    <h2>您的个人信息</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <asp:GridView 
        ID="gvClient"
        runat="server"
        AutoGenerateColumns="true"
        Width="80%"
        CssClass="table"
        EmptyDataText="未找到个人信息">
    </asp:GridView>

    <br />
    <h2>您的预订信息</h2>

    <asp:GridView 
        ID="gvReservations"
        runat="server"
        AutoGenerateColumns="true"
        Width="80%"
        CssClass="table"
        EmptyDataText="暂无预订记录">
    </asp:GridView>

</form>
</body>
</html>