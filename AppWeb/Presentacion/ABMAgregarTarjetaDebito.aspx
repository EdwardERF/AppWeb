<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMAgregarTarjetaDebito.aspx.cs" Inherits="ABMAgregarTarjetaDebito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .nuevoEstilo1 {
            font-family: calibri;
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
        .auto-style4 {
            height: 33px;
            width: 14px;
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
        .auto-style10 {
            width: 14px;
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
        .auto-style11 {
            width: 14px;
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="nuevoEstilo1">Agregar Tarjeta de Debito</span></div>
        <table align="center" class="auto-style7">
            <tr>
                <td class="auto-style2">Cédula:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Fecha de Vencimiento:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtFechaVencimiento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Personalizada:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtPersonalizada" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Saldo:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtSaldo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Cantidad de Cuentas Asociadas</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtCuentasAsociadas" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style12">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" />
                </td>
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
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style13">
                    <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
