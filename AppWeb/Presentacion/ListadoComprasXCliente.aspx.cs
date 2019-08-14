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
            List<Cliente> oCLiente = LogicaCliente.ListarClientes();

            if(oCLiente.Count > 0)
            {
                //codigo para hacer la ddl
                ddlCliente.DataSource = oCLiente;
                ddlCliente.DataTextField = "ci";
                ddlCliente.DataValueField = "nombre";
                ddlCliente.DataBind();
            }
            else
            {
                lblError.Text = "ERROR: Aun no existe ningún cliente";
            }

            //De acuerdo al oCliente.SelectedValue, se declara la GridView de ese Cliente.
        
        

        }
    }
}