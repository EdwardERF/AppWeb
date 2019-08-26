using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ListadoTarjetasVencidas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ddlTipoTarjeta.Items.Insert(0, "Todas");
                ddlTipoTarjeta.Items.Insert(1, "Credito");
                ddlTipoTarjeta.Items.Insert(2, "Debito");
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        int Tipo;

        string Variable = ddlTipoTarjeta.SelectedValue;

        if (Variable == "Todas")
            Tipo = 0;
        else if (Variable == "Credito")
            Tipo = 1;
        else if (Variable == "Debito")
            Tipo = 2;
        else
            Tipo = 2;

        if (Tipo == 0)
        {
            gvTarjetasVencidas.DataSource = LogicaTarjeta.ListarVencidas();
            gvTarjetasVencidas.DataBind();
            lblError.Text = "";

            if (gvTarjetasVencidas.PageCount == 0)
            {
                lblError.Text = "No existen tarjetas vencidas";
            }
        }
        else if(Tipo == 1)
        {
            gvTarjetasVencidas.DataSource = Logica.LogicaTarjeta.ListarVencidasCredito();
            gvTarjetasVencidas.DataBind();
            lblError.Text = "";

            if (gvTarjetasVencidas.PageCount == 0)
            {
                lblError.Text = "No existen tarjetas de credito vencidas";
            }
        }
        else if(Tipo == 2)
        {
            gvTarjetasVencidas.DataSource = Logica.LogicaTarjeta.ListarVencidasDebito();
            gvTarjetasVencidas.DataBind();
            lblError.Text = "";

            if (gvTarjetasVencidas.PageCount == 0)
            {
                lblError.Text = "No existen tarjetas de debito vencidas";
            }
        }
    }
}