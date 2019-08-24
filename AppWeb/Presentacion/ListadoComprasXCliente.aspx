<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoComprasXCliente.aspx.cs" Inherits="ListadoComprasXCliente" %>

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
            text-align: center;
        }
    </style>
</head>
<body class="nuevoEstilo1">
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style1">
            Listado de Compras por Cliente</div>
            <asp:DropDownList ID="ddlCliente" runat="server" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
            <br />
            <div>
            <asp:GridView ID="gvComprasXCliente" runat="server" Height="197px" Width="456px">
                <Columns>
                    <asp:BoundField DataField="codart" HeaderText="Cliente" />
                </Columns>
            </asp:GridView>
            </div>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
