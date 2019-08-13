<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealizarCompra.aspx.cs" Inherits="RealizarCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .Calibri {
            font-family: Calibri;
        }
        .auto-style1 {
            font-family: Calibri;
            text-align: center;
        }
        .auto-style7 {
            font-family: calibri;
            width: 61%;
        }
        .auto-style2 {
            font-family: calibri;
            width: 114px;
            height: 33px;
            text-align: center;
        }
        .auto-style5 {
            height: 33px;
            width: 527px;
            text-align: center;
        }
        .auto-style3 {
            width: 114px;
            text-align: center;
        }
        .auto-style12 {
            width: 527px;
            text-align: center;
        }
        .auto-style8 {
            width: 114px;
            height: 35px;
            text-align: center;
        }
        .auto-style13 {
            width: 527px;
            height: 35px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Realizar Compra</div>
        <table align="center" class="auto-style7">
            <tr>
                <td class="auto-style2">N° Tarjeta:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNroTarjeta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Importe:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Fecha</td>
                <td class="auto-style12">
                    <asp:Calendar ID="CalFechaCompra" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">
                    <asp:Button ID="btnComprar" runat="server" Text="Comprar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style13">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
