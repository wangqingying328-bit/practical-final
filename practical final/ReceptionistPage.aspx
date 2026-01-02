<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistPage.aspx.cs" Inherits="practical_final.ReceptionistPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Receptionist Management</title>
</head>

<body>
<form id="form1" runat="server">

    <div style="text-align:right;padding:10px;background:#f0f0f0">
        <asp:Label ID="lblWelcome" runat="server" Font-Bold="true"></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Text="Log out" OnClick="btnLogout_Click" />
    </div>

    <h2>Customer management</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

    <asp:HiddenField ID="txtClientID" runat="server" />

    <table style="width:80%;">
        <tr>
            <td style="width:120px;">Name:</td>
            <td><asp:TextBox ID="txtName" runat="server" Width="200px" /></td>
        </tr>
        <tr>
            <td>Birthdate:</td>
            <td><asp:TextBox ID="txtDOB" runat="server" Width="200px" /></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td><asp:TextBox ID="txtAddress" runat="server" Width="300px" /></td>
        </tr>
        <tr>
            <td>Phone number:</td>
            <td><asp:TextBox ID="txtMobile" runat="server" Width="200px" /></td>
        </tr>
    </table>

    <br />
    <asp:Button ID="btnAddClient" runat="server" Text="Add customers"
        OnClick="btnAddClient_Click" />
    <asp:Button ID="btnUpdateClient" runat="server" Text="Modify client"
        OnClick="btnUpdateClient_Click" />
    <asp:Button ID="btnDeleteClient" runat="server" Text="Delete client"
        OnClick="btnDeleteClient_Click" />

    <br /><br />
    <h2>Customer list</h2>

    <asp:GridView 
        ID="gvClients" 
        runat="server" 
        AutoGenerateColumns="False"
        DataKeyNames="ClientID"
        OnSelectedIndexChanged="gvClients_SelectedIndexChanged">

        <Columns>
            <asp:ButtonField Text="choose" CommandName="Select" />
            <asp:BoundField DataField="ClientID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="DOB" HeaderText="Birthdate" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Mobile" HeaderText="Phone number" />
        </Columns>
    </asp:GridView>

    <hr />

    <h2>Reservations management</h2>
    <asp:Label ID="lblResMessage" runat="server" ForeColor="Green"></asp:Label>

    <asp:HiddenField ID="txtReservationID" runat="server" />

    <table style="width:80%;">
        <tr>
            <td style="width:120px;">Client:</td>
            <td><asp:DropDownList ID="ddlClient" runat="server" Width="200px" /></td>
        </tr>
        <tr>
            <td>Check-in date:</td>
            <td><asp:TextBox ID="txtArrival" runat="server" Width="200px" /></td>
        </tr>
        <tr>
            <td>Check-out date:</td>
            <td><asp:TextBox ID="txtDeparture" runat="server" Width="200px" /></td>
        </tr>
        <tr>
            <td>Room type:</td>
            <td><asp:TextBox ID="txtRoomType" runat="server" Width="200px" /></td>
        </tr>
    </table>

    <br />
    <asp:Button ID="btnAddRes" runat="server" Text="Add reservation"
        OnClick="btnAddRes_Click" />
    <asp:Button ID="btnUpdateRes" runat="server" Text="Modify reservation"
        OnClick="btnUpdateRes_Click" />
    <asp:Button ID="btnDeleteRes" runat="server" Text="Cancel reservation"
        OnClick="btnDeleteRes_Click" />

    <br /><br />
    <h3>Booking list</h3>

    <asp:GridView 
        ID="gvReservations"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="ReservationID"
        OnSelectedIndexChanged="gvReservations_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="choose" />
            <asp:BoundField DataField="ReservationID" HeaderText="Reservation ID" />
            <asp:BoundField DataField="ClientName" HeaderText="Customer Name" />
            <asp:BoundField DataField="Arrival" HeaderText="Check-in date" />
            <asp:BoundField DataField="Departure" HeaderText="Departure date" />
            <asp:BoundField DataField="RoomType" HeaderText="Room type" />
        </Columns>
    </asp:GridView>

    <hr />

    <h2>Search customers</h2>
    <asp:TextBox ID="txtSearch" runat="server" Width="300px"
                 placeholder="Enter name or phone" />
    <asp:Button ID="btnSearch" runat="server" Text="Search"
                OnClick="btnSearch_Click" />

    <br /><br />
    <asp:GridView 
        ID="gvSearch"
        runat="server"
        AutoGenerateColumns="True"
        Width="90%"
        EmptyDataText="No customers found" />

</form>
</body>
</html>
