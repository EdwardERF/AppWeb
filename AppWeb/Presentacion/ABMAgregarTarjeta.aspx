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
        .auto-style3 {
            color: #CCFFFF;
        }
    </style>
</head>
<body bgcolor="#488FCB" class="calibri">
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style1">
            <span class="auto-style3">Agregar Tarjeta</span><br />
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnCredito" runat="server" PostBackUrl="~/ABMAgregarTarjetaCredito.aspx" ForeColor="#E6E7E8">Crédito</asp:LinkButton>
                </td>
                <td class="auto-style1">
                    <asp:LinkButton ID="lbtnDebito" runat="server" PostBackUrl="~/ABMAgregarTarjetaDebito.aspx" ForeColor="#E6E7E8">Débito</asp:LinkButton>
                </td>
            </tr>
        </table>
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx" ForeColor="#E6E7E8">Volver</asp:LinkButton>
        </div>
    </form>
</body>
</html>
