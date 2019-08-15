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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Listado de Clientes<div>
                <br />
                <table class="auto-style2">
                    <tr>
                        <td>Totalidad de Clientes</td>
                        <td>
                <asp:GridView ID="gvListadoClientes" runat="server" AutoGenerateColumns="False" Height="197px" Width="456px">
                    <Columns>
                        <asp:BoundField DataField="codart" HeaderText="CI" />
                        <asp:BoundField DataField="nomart" HeaderText="Nombre" />
                        <asp:BoundField DataField="preart" HeaderText="Apellido" />
                        <asp:BoundField HeaderText="Teléfono" />
                    </Columns>
                </asp:GridView>
                            <div>
                                <br />
                                <asp:Button ID="btnSeleccion" runat="server" OnClick="btnSeleccion_Click" Text="Ver Detalles de Cliente" />
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Detalles de un Cliente</td>
                        <td>
                <asp:GridView ID="gvSeleccionCliente" runat="server" AutoGenerateColumns="False" Height="197px" Width="456px">
                    <Columns>
                        <asp:BoundField DataField="codart" HeaderText="Nombre" />
                        <asp:BoundField DataField="nomart" HeaderText="Tarjeta" />
                        <asp:BoundField DataField="preart" HeaderText="Personalizada" />
                        <asp:BoundField HeaderText="F.Vencimiento" />
                    </Columns>
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
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
