using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntidadesCompartidas;
using Logica;


public partial class ListadoClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<Cliente> oCliente = LogicaCliente.ListarClientes();

            gvListadoClientes.DataSource = oCliente;
            gvListadoClientes.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvListadoClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Cliente oCli = Logica.LogicaCliente.BuscarCliente(Convert.ToInt32(gvListadoClientes.SelectedRow.Cells[1].Text));

            if(oCli != null)
            {
                lblCliente.Text = oCli.ToString();

                //Obtengo detalles de tarjetas del cliente
                List<EntidadesCompartidas.Tarjeta> oLista = Logica.LogicaTarjeta.TarjetasXCliente(oCli.CI);

                gvSeleccionCliente.DataSource = oLista;
                gvSeleccionCliente.DataBind();
            }
            else
            {
                lblCliente.Text = "";
                gvSeleccionCliente.DataSource = null;
                gvSeleccionCliente.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}