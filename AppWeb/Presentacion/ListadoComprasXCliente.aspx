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
        .auto-style2 {
            text-align: center;
            color: #CCFFFF;
        }
    </style>
</head>
<body bgcolor="#488FCB">
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style2">
            Listado de Compras por Cliente</div>
            <asp:DropDownList ID="ddlCliente" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
            <br />
            <div>
            <asp:GridView ID="gvComprasXCliente" runat="server" Height="197px" Width="456px" ForeColor="#E6E7E8" >
            </asp:GridView>
            </div>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="#E6E7E8"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Default.aspx" ForeColor="#E6E7E8">Volver</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>
