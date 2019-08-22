using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMMantenimientoCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //this.LimpioFormulario();
        }

    }

    protected void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnBaja.Enabled = true;

        btnAlta.Enabled = false;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    protected void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;

        btnAlta.Enabled = true;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;

    }

    protected void LimpioFormulario()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;

        btnBuscar.Enabled = true;

        txtCI.Enabled = true;

        txtCI.Text = "0";
        txtNombre.Text = "";

        lblError.Text = "";
    }
}