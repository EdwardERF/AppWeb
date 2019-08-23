using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMAgregarTarjetaCredito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesM()
    {
        btnAlta.Enabled = false;
        txtCI.Enabled = false;
    }

    private void LimpioFormulario()
    {
        txtCI.Enabled = true;
        btnAlta.Enabled = true;

        txtCI.Text = "0";
        txtFechaVencimiento.Text = "";
        txtPersonalizada.Text = "";
        txtCategoria.Text = "";
        txtCreditoDisponible.Text = "";

        lblError.Text = "";
    }


    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}