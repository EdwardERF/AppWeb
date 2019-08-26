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

            ddlCliente.DataSource = LogicaCliente.ListarClientes();
            ddlCliente.DataTextField = "ci";
            ddlCliente.DataBind();
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
                lblError.Text = "Aun no ha elegido ningun Cliente";
                Session["Lista"] = Logica.LogicaCompra.ListarCompras();
            }
            else
            {
                int oCI = ddlCliente.SelectedIndex;
                gvComprasXCliente.DataSource = LogicaCompra.ListarComprasXCliente(oCI);
                gvComprasXCliente.DataBind();

                if(gvComprasXCliente == null)
                {
                    lblError.Text = "Este Cliente aun no tiene compras";
                }
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Cliente> oLista = new List<Cliente>();

        oLista = LogicaCliente.ListarClientes();

        ddlCliente.DataSource = oLista;
        ddlCliente.DataTextField = "ci";
        ddlCliente.DataValueField = "nombre";
        ddlCliente.DataBind();
    }
}