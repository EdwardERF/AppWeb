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
        if(!IsPostBack)
        {
            try
            {
                ddlCliente.DataSource = LogicaCliente.ListarClientes();
                ddlCliente.DataTextField = "ci";
                ddlCliente.DataValueField = "ci";
                ddlCliente.DataBind();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            int oCI = Convert.ToInt32(ddlCliente.SelectedValue);
            gvComprasXCliente.DataSource = LogicaCompra.ListarComprasXCliente(oCI);
            gvComprasXCliente.DataBind();

            lblError.Text = Convert.ToString(oCI);

            if(gvComprasXCliente == null)
            {
                lblError.Text = "Este Cliente aun no tiene compras";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}