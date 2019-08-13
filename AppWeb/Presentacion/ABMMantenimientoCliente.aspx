<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMMantenimientoCliente.aspx.cs" Inherits="ABMMantenimientoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .Titulo {
            font-family: calibri;
        }
        .calibri {
            font-family: calibri;
        }
        .auto-style2 {
            font-family: calibri;
            width: 114px;
            height: 33px;
            text-align: center;
        }
        .auto-style3 {
            width: 114px;
            text-align: center;
        }
        .auto-style4 {
            height: 33px;
            width: 14px;
            text-align: center;
        }
        .calibri {
            font-family: calibri;
        }
        .auto-style5 {
            height: 33px;
            width: 527px;
            text-align: center;
        }
        .auto-style7 {
            font-family: calibri;
            width: 61%;
        }
        .auto-style8 {
            width: 114px;
            height: 35px;
            text-align: center;
        }
        .auto-style10 {
            width: 14px;
            text-align: center;
        }
        .auto-style11 {
            width: 14px;
            height: 35px;
        }
        .auto-style12 {
            width: 527px;
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
            <span class="Titulo">Mantenimiento de Clientes</span></div>
        <table align="center" class="auto-style7">
            <tr>
                <td class="auto-style2">Cédula:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Apellido/s:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtApellido" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Teléfono:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" />
                </td>
                <td class="auto-style12">
                    <asp:Button ID="btnBaja" runat="server" Text="Baja" />
                </td>
                <td class="auto-style10">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style13">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style11"></td>
            </tr>
        </table>
    </form>
</body>
</html>
