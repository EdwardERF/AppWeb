<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMAgregarTarjeta.aspx.cs" Inherits="ABMAgregarTarjeta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .calibri {
            font-family: calibri;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
    </style>
</head>
<body class="calibri">
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style1">
            Agregar Tarjeta<br />
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnCredito" runat="server" PostBackUrl="~/ABMAgregarTarjetaCredito.aspx">Crédito</asp:LinkButton>
                </td>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnDebito" runat="server" PostBackUrl="~/ABMAgregarTarjetaDebito.aspx">Débito</asp:LinkButton>
                </td>
            </tr>
        </table>
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        </div>
    </form>
</body>
</html>
