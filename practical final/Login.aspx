<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelSite.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>

<form id="form1" runat="server">

    <h2>用户登录</h2>

    <label>用户名：</label>
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br /><br />

    <label>密码：</label>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />

    <asp:RegularExpressionValidator 
        ID="revUser"
        runat="server"
        ControlToValidate="txtUser"
        ValidationExpression="^[a-zA-Z0-9]+$"
        ErrorMessage="用户名只能包含字母或数字"
        ForeColor="Red" />
    <br />

    <!-- 错误消息标签 -->
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br /><br />

    <asp:Button 
        ID="btnLogin"
        runat="server"
        Text="登录"
        OnClick="btnLogin_Click" />

</form>

</body>
</html>