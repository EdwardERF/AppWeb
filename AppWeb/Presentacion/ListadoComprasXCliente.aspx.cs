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
            this.CargoDatos();
            this.MostrarCliente();
        }

    }

    protected void CargoDatos()
    {
        try
        {
            List<Cliente> oCLiente = LogicaCliente.ListarComprasXCliente();

            if(oCLiente.Count > 0)
            {
                //codigo para hacer la ddl
                ddlCliente.DataSource = oCLiente;
                ddlCliente.DataTextField = "Cedula";
                ddlCliente.DataValueField = "ci";
                ddlCliente.DataBind();
            }
            else
            {
                lblError.Text = "ERROR: Aun no existe ningún cliente";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void MostrarCliente()
    {
        try
        {
            //no se si de esto se saca el valor de la CI, no estoy seguro
            int seleccion = -1; //Si es distinto a un numero negativo, quiere decir que sí hay un Cliente seleccionado
            seleccion = Convert.ToInt32(ddlCliente.SelectedValue);

            if (seleccion != -1)
            {
                gvComprasXCliente.DataSource = LogicaCompra.ListarCompras(seleccion);
                gvComprasXCliente.DataBind();
            }
            else
            {
                lblError.Text = "Seleccione un cliente y podra ver las compras del mismo.";
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


}