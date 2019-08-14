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
        if(!IsPostBack)
        {
            Session["_ListaTotal"] = LogicaCliente.ListarClientes();
            Session["_ListaSeleccion"] = new List<Cliente>();

            gvListadoClientes.DataSource = (List<Cliente>)Session["_ListaTotal"];
            gvListadoClientes.DataBind();

            gvSeleccionCliente.DataSource = (List<Cliente>)Session["_ListaSeleccion"];
            gvSeleccionCliente.DataBind();
        }
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



    protected void btnSeleccion_Click(object sender, EventArgs e)
    {
        Cliente oCli = null;
        List<Cliente> _ListaSeleccion = (List<Cliente>)Session["_ListaSeleccion"];

        //verifico que haya linea seleccionada
        if(gvListadoClientes.SelectedRow != null)
        {
            try
            {
                int pCI = Convert.ToInt32(gvListadoClientes.SelectedRow.Cells[0].Text);
                oCli = LogicaCliente.BuscarCliente(pCI);
                _ListaSeleccion.Add(oCli);

                gvSeleccionCliente.DataSource = _ListaSeleccion;
                gvSeleccionCliente.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}