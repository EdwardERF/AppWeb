using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMAgregarTarjetaDebito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    protected void LimpioFormulario()
    {
        txtCI.Enabled = true;
        btnAlta.Enabled = true;

        txtCI.Text = "0";
        txtFechaVencimiento.Text = "";
        txtPersonalizada.Text = "";
        txtSaldo.Text = "";
        txtCuentasAsociadas.Text = "";

        lblError.Text = "";
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Debito oDebito = new Debito(Convert.ToInt32(txtCI.Text), Convert.ToDateTime(txtFechaVencimiento.Text), Convert.ToBoolean(txtPersonalizada.Text), 
                Convert.ToInt32(txtSaldo.Text), Convert.ToInt32(txtCuentasAsociadas.Text));

            lblError.Text = "Alta exitosa";

            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}