<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        #form1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: large;
        }
        .nuevoEstilo1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .nuevoEstilo2 {
            font-family: Calibri;
        }
        .nuevoEstilo3 {
            font-family: calibri;
        }
        .nuevoEstilo4 {
            font-family: Calibri;
        }
        .auto-style4 {
            font-size: large;
            color: #FFFFFF;
        }
        .auto-style5 {
            color: #CCFFFF;
            font-size: x-large;
        }
    </style>
</head>
<body bgcolor="#488FCB">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Img/LogoEmpresa.png" />
            <strong class="nuevoEstilo2"><span class="auto-style2">
            <br />
            <br />
            </span><span>
            <span class="auto-style5">Página Principal</span><br />
            </span><br class="auto-style4" />
            </strong>
        </div>
        <asp:LinkButton ID="lbtnMantenimientoClientes" runat="server" PostBackUrl="~/ABMMantenimientoCliente.aspx" ForeColor="#E6E7E8">Mantenimiento de Clientes</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnAgregarTarjeta" runat="server" PostBackUrl="~/ABMAgregarTarjeta.aspx" ForeColor="#E6E7E8">Agregar Tarjeta</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnRealizarCompra" runat="server" PostBackUrl="~/RealizarCompra.aspx" ForeColor="#E6E7E8">Realizar Compra</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoClientes" runat="server" PostBackUrl="~/ListadoClientes.aspx" ForeColor="#E6E7E8">Listado de Clientes</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoComprasXCliente" runat="server" PostBackUrl="~/ListadoComprasXCliente.aspx" ForeColor="#E6E7E8">Listado de Compras por Cliente</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoTarjetasVencidas" runat="server" PostBackUrl="~/ListadoTarjetasVencidas.aspx" ForeColor="#E6E7E8">Listado de Tarjetas Vencidas</asp:LinkButton>
    </form>
</body>
</html>
