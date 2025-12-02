<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HotelSite.Home" %>

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
                <div class="logo">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 小型酒店</div>
                <ul class="nav-menu">
                    <li><a href="Home.aspx">首页</a></li>
                    <li><a href="Login.aspx">登录</a></li>
                </ul>
            </div>
        </div>
    </div>

    <div class="container">
        <form id="form1" runat="server">
            <div class="card">
                <h1>Bienvenido</h1>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descubre un oasis de lujo y tranquilidad El Hotel Paraíso del Sol es un establecimiento de 5 estrellas ubicado frente a la playa más exclusiva de la costa. </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Con más de 50 años de historia, combinamos la elegancia clásica con las comodidades más modernas para ofrecerle una experiencia inolvidable. Nuestras instalaciones incluyen: </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Habitaciones y suites: Amplias y luminosas, con balcón privado, vistas al mar o a los jardines tropicales, WiFi de alta velocidad y minibar.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Gastronomía: Dos restaurantes gourmet (uno especializado en cocina mediterránea y otro en pescados frescos del día) y un lobby bar con terraza panorámica.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Bienestar: Spa completo con tratamientos termales, piscina climatizada al aire libre, gimnasio totalmente equipado y acceso directo a la playa privada. </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; •&nbsp; Eventos: Salones versátiles y un jardín tropical perfectos para bodas, reuniones de negocios y eventos sociales. Nuestro equipo de profesionales está dedicado a atender cada detalle con calidez y discreción, asegurando que su estancia sea perfecta desde el momento de su llegada.</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp; Ideal para viajes en pareja, familias y viajeros de negocios. Reserve su escape perfecto. </p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp; Su paraíso personal le espera. </p>
                
                <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 酒店特色：</h3>
                <ul>
                    <li>舒适优雅的客房</li>
                    <li>24小时前台服务</li>
                    <li>免费Wi-Fi</li>
                    <li>便捷的在线预订</li>
                </ul>
                
                <img src="https://img95.699pic.com/photo/40236/8440.jpg_wh860.jpg" 
                     alt="Hotel Image" style="width:100%; max-width:800px; margin:20px 0;" />
                
                <p>现在就开始您的旅程，体验我们贴心的服务！</p>
                
                <asp:Button ID="btnLogin" runat="server" Text="立即登录" 
                    CssClass="btn btn-primary" PostBackUrl="~/Login.aspx" Height="39px" Width="321px" />
            </div>
        </form>
    </div>

    <div class="footer">
        <div class="container">
            <p>© 2025 小型酒店 - 版权所有</p>
            <p>联系电话：123-456-7890 | 地址：某某市某某路123号</p>
        </div>
    </div>
</body>
</html>