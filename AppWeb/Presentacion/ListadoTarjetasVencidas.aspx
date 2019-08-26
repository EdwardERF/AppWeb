﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoTarjetasVencidas.aspx.cs" Inherits="ListadoTarjetasVencidas" %>

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
            Listado de Tarjetas Vencidas<br />
            Tipo:
            <asp:DropDownList ID="ddlTipoTarjeta" runat="server">
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
            <br />
            <br />
            <asp:GridView ID="gvTarjetasVencidas" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        </div>
    </form>
</body>
</html>
