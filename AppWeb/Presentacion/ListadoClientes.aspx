<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoClientes.aspx.cs" Inherits="ListadoClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .nuevoEstilo1 {
            font-family: calibri;
        }
        .auto-style1 {
            font-family: calibri;
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            color: #CCFFFF;
        }
    </style>
</head>
<body bgcolor="#488FCB">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="auto-style4">Listado de Clientes</span><div>
                <br />
                <table class="auto-style2">
                    <tr>
                        <td class="auto-style4">Totalidad de Clientes</td>
                        <td>
                <asp:GridView ID="gvListadoClientes" runat="server" Height="197px" Width="456px" AutoGenerateSelectButton="True" ForeColor="#E6E7E8">
                </asp:GridView>
                            <div class="auto-style3">
                                <br />
                                <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Ver detalles" />
                                <br />
                                <br />
                                <span class="auto-style4">Detalles de Cliente:</span>
                                <asp:Label ID="lblCliente" runat="server" ForeColor="#E6E7E8"></asp:Label>
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Detalles de un Cliente</td>
                        <td>
                <asp:GridView ID="gvSeleccionCliente" runat="server" Height="197px" Width="456px" ForeColor="#E6E7E8">
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                <asp:Label ID="lblError" runat="server" ForeColor="#E6E7E8"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx" ForeColor="#E6E7E8">Volver</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
