<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="practical_final.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>

<form id="form1" runat="server">

    <h2>User Login</h2>

    <label>username:</label>
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br /><br />

    <label>password:</label>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />

    <asp:RegularExpressionValidator 
        ID="revUser"
        runat="server"
        ControlToValidate="txtUser"
        ValidationExpression="^[a-zA-Z0-9]+$"
        ErrorMessage="Usernames can only contain letters or numbers."
        ForeColor="Red" />
    <br />

    
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <br /><br />

    <asp:Button 
        ID="btnLogin"
        runat="server"
        Text="Log in"
        OnClick="btnLogin_Click" />

</form>

</body>
</html>