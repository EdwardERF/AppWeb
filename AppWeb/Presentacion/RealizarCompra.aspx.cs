using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class RealizarCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    protected void LimpioFormulario()
    {
        txtNroTarjeta.Enabled = true;
        CalFechaCompra.Enabled = true;
        txtImporte.Enabled = true;

        btnComprar.Enabled = true;

        txtNroTarjeta.Text = "";
        txtImporte.Text = "";
    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {
        try
        {
            Compra oCompra = new Compra(Convert.ToInt32(txtNroTarjeta.Text), Convert.ToInt32(txtImporte.Text), CalFechaCompra.SelectedDate);

            Logica.LogicaCompra.Alta(oCompra);
            lblError.Text = "Compra registrada exitosamente";

            this.LimpioFormulario();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}