using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMAgregarTarjetaCredito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesM()
    {
        btnModificar.Enabled = true;

        btnAlta.Enabled = false;
        btnBuscar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnBuscar.Enabled = false;
        btnAlta.Enabled = true;
        btnModificar.Enabled = false;

        txtCI.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnBuscar.Enabled = true;
        txtCI.Enabled = true;

        btnAlta.Enabled = false;
        btnModificar.Enabled = false;

        txtCI.Text = "0";
        txtFechaVencimiento.Text = "";
        txtPersonalizada.Text = "";
        txtCategoria.Text = "";
        txtCreditoDisponible.Text = "";

        lblError.Text = "";
    }
}