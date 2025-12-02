<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistPage.aspx.cs" Inherits="HotelSite.ReceptionistPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>前台管理页面</title>
</head>

<body>
<form id="form1" runat="server">

    <div style="text-align: right; padding: 10px; background-color: #f0f0f0;">
        <asp:Label ID="lblWelcome" runat="server" Font-Bold="true"></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Text="退出登录" OnClick="btnLogout_Click" />
    </div>

    <h2>客户管理</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

    <!-- 隐藏的ClientID字段 -->
    <asp:HiddenField ID="txtClientID" runat="server" />
    
    <table style="width: 80%;">
        <tr>
            <td style="width: 100px;">姓名：</td>
            <td><asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>出生日期：</td>
            <td><asp:TextBox ID="txtDOB" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>地址：</td>
            <td><asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>手机号：</td>
            <td><asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
    </table>
    
    <br />
    <asp:Button ID="btnAddClient" runat="server" Text="添加客户" OnClick="btnAddClient_Click" CssClass="btn" />
    <asp:Button ID="btnUpdateClient" runat="server" Text="修改客户" OnClick="btnUpdateClient_Click" CssClass="btn" />
    <asp:Button ID="btnDeleteClient" runat="server" Text="删除客户" OnClick="btnDeleteClient_Click" CssClass="btn" />
    
    <br /><br />
    <h3>客户列表</h3>
    <asp:GridView 
        ID="gvClients"
        runat="server"
        AutoGenerateColumns="false"
        Width="90%"
        CssClass="table"
        DataKeyNames="ClientID"
        OnSelectedIndexChanged="gvClients_SelectedIndexChanged"
        EmptyDataText="暂无客户数据">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="选择" />
            <asp:BoundField DataField="ClientID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="DOB" HeaderText="出生日期" />
            <asp:BoundField DataField="Address" HeaderText="地址" />
            <asp:BoundField DataField="Mobile" HeaderText="手机号" />
        </Columns>
    </asp:GridView>

    <hr />

    <h2>预订管理</h2>
    <asp:Label ID="lblResMessage" runat="server" ForeColor="Green"></asp:Label>
    
    <!-- 隐藏的ReservationID字段 -->
    <asp:HiddenField ID="txtReservationID" runat="server" />
    
    <table style="width: 80%;">
        <tr>
            <td style="width: 100px;">客户：</td>
            <td><asp:DropDownList ID="ddlClient" runat="server" Width="200px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>入住日期：</td>
            <td><asp:TextBox ID="txtArrival" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>离开日期：</td>
            <td><asp:TextBox ID="txtDeparture" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>房间类型：</td>
            <td><asp:TextBox ID="txtRoomType" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
    </table>
    
    <br />
    <asp:Button ID="btnAddRes" runat="server" Text="添加预订" OnClick="btnAddRes_Click" CssClass="btn" />
    <asp:Button ID="btnUpdateRes" runat="server" Text="修改预订" OnClick="btnUpdateRes_Click" CssClass="btn" />
    <asp:Button ID="btnDeleteRes" runat="server" Text="删除预订" OnClick="btnDeleteRes_Click" CssClass="btn" />
    
    <br /><br />
    <h3>预订列表</h3>
    <asp:GridView 
        ID="gvReservations"
        runat="server"
        AutoGenerateColumns="false"
        Width="90%"
        CssClass="table"
        DataKeyNames="ReservationID"
        OnSelectedIndexChanged="gvReservations_SelectedIndexChanged"
        EmptyDataText="暂无预订数据">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="选择" />
            <asp:BoundField DataField="ReservationID" HeaderText="预订ID" />
            <asp:BoundField DataField="ClientName" HeaderText="客户姓名" />
            <asp:BoundField DataField="Arrival" HeaderText="入住日期" />
            <asp:BoundField DataField="Departure" HeaderText="离开日期" />
            <asp:BoundField DataField="RoomType" HeaderText="房间类型" />
        </Columns>
    </asp:GridView>

    <hr />

    <h2>搜索客户</h2>
    <asp:TextBox ID="txtSearch" runat="server" Width="300px" placeholder="输入姓名或手机号"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" CssClass="btn" />
    
    <br /><br />
    <asp:GridView 
        ID="gvSearch"
        runat="server"
        AutoGenerateColumns="true"
        Width="90%"
        CssClass="table"
        EmptyDataText="未找到相关客户">
    </asp:GridView>

</form>
</body>
</html>