using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ListadoComprasXCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                Session["Lista"] = Logica.LogicaCompra.ListarCompras();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCliente.SelectedIndex == 0)
            {
                Session["Lista"] = Logica.LogicaCompra.ListarCompras();
            }
            else
            {
                int oCI = ddlCliente.SelectedIndex;
                gvComprasXCliente.DataSource = Logica.LogicaCompra.ListarComprasXCliente(oCI);
                gvComprasXCliente.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCliente.DataSource = Logica.LogicaCliente.ListarClientes();
        ddlCliente.DataTextField = "ci";
        ddlCliente.DataValueField = "ci";
        ddlCliente.DataBind();
    }
}