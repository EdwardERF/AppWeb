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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong class="nuevoEstilo2"><span class="auto-style2">Página Principal</span><br class="auto-style2" />
            </strong>
        </div>
        <asp:LinkButton ID="lbtnMantenimientoClientes" runat="server" OnClick="LinkButton1_Click">Mantenimiento de Clientes</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnAgregarTarjeta" runat="server">Agregar Tarjeta</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnRealizarCompra" runat="server">Realizar Compra</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoClientes" runat="server">Listado de Clientes</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoComprasXCliente" runat="server">Listado de Compras por Cliente</asp:LinkButton>
        <span class="nuevoEstilo4">
        <br />
        <br />
        </span>
        <asp:LinkButton ID="lbtnListadoTarjetasVencidas" runat="server">Listado de Tarjetas Vencidas</asp:LinkButton>
    </form>
</body>
</html>
