using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListadoTarjetasVencidas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                lbTarjetas.DataSource = null;
                lbTarjetas.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void ddlTipoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoTarjeta.SelectedIndex == 0)
        {
            lbTarjetas.DataSource = null;
            lbTarjetas.DataBind();
        }
        else if(ddlTipoTarjeta.SelectedIndex == 1)
        {
            lbTarjetas.DataSource = Logica.LogicaTarjeta.ListarVencidasCredito();
            lbTarjetas.DataBind();
        }
        else if(ddlTipoTarjeta.SelectedIndex == 2)
        {
            lbTarjetas.DataSource = Logica.LogicaTarjeta.ListarVencidasDebito();
            lbTarjetas.DataBind();
        }
        else
        {
            lbTarjetas.DataSource = Logica.LogicaTarjeta.ListarVencidas();
            lbTarjetas.DataBind();
        }
    }
}