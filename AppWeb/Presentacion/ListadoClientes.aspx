﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoClientes.aspx.cs" Inherits="ListadoClientes" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Listado de Clientes<div>
                <asp:GridView ID="gvListadoClientes" runat="server" AutoGenerateColumns="False" Height="197px" Width="456px">
                    <Columns>
                        <asp:BoundField DataField="codart" HeaderText="CI" />
                        <asp:BoundField DataField="nomart" HeaderText="Nombre" />
                        <asp:BoundField DataField="preart" HeaderText="Apellido" />
                        <asp:BoundField HeaderText="Teléfono" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
