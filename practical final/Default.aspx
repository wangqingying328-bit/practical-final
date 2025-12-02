<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="practical_final.Home" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>El Hotel Paraíso del Sol</title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <div class="header">
        <div class="container">
            <div class="navbar">
                <div class="logo">&nbsp;El Hotel Paraíso </div>
                <ul class="nav-menu">
                <li><a href="Default.aspx">front page</a></li>
                <li><a href="Login.aspx">Log in</a></li>
            </ul>

            </div>
        </div>
    </div>

    <div class="container">
        <form id="form1" runat="server">
            <div class="card">
                <h1>Welcome</h1>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discover an oasis of luxury and tranquility. El Holtel Paraíso is a five-star establishment located in front of the most exclusive beach on the coast.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With over 50 years of history, we combine classic elegance with the most modern comforts to offer you an unforgettable experience. Our facilities include.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Rooms and Suites: Spacious and bright, featuring a private balcony with sea or tropical garden views, high-speed WiFi, and a minibar.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Gastronomy: Two gourmet restaurants (one specializing in Mediterranean cuisine and another in fresh daily catch) and a lobby bar with a panoramic terrace.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Wellness: A full-service spa with thermal treatments, an outdoor heated swimming pool, a fully equipped gym, and direct access to a private beach. </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Events: Versatile function rooms and a tropical garden, perfect for weddings, business meetings, and social events. Our team of professionals is dedicated to attending to every detail with warmth and discretion, ensuring your stay is perfect from the moment you arrive.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp; Ideal for couples, families, and business travelers. Book your perfect escape. </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp; Your personal paradise awaits. </p>
                
                <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hotel Features:</h3>
                <ul>
                    <li>Offers suites with panoramic sea views, five specialized restaurants</li>
                    <li>An infinity pool, a premium category spa </li>
                    <li>A wide variety of water activities</li>
                    <li>Free WiFi</li>
                </ul>
                
                <img src="https://img95.699pic.com/photo/40236/8440.jpg_wh860.jpg" 
                     alt="Hotel Image" style="width:100%; max-width:800px; margin:20px 0;" 
                    style="display:block; margin:20px auto;"/>
                
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Start your journey now and experience our attentive service!</p>
                
                <asp:Button ID="btnLogin" runat="server" Text="Log in now" 
                    CssClass="btn btn-primary" 
                    PostBackUrl="~/Login.aspx" 
                    Height="39px" Width="956px" 
                    style="display:block; margin:20px auto;"/>
            </div>
        </form>
    </div>

    <div class="footer">
        <div class="container">
            <p>© 2025 Hotel Paraíso - All rights reserved</p>
            <p>Contact number: 00-000-0000 | Address: Gandia</p>
        </div>
    </div>
</body>
</html>