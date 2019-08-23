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
            this.LimpioFormulario();
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int oCI = Convert.ToInt32(txtCI.Text);
            Cliente oCli = Logica.LogicaCliente.BuscarCliente(oCI);

            if (oCli == null)
            {
                this.ActivoBotonesA();
                Session["ClienteABM"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["ClienteABM"] = oCli;

                txtNombre.Text = oCli.Nombre;
                txtApellido.Text = oCli.Apellido;
                txtTelefono.Text = oCli.Apellido;
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCli = new Cliente(Convert.ToInt32(txtCI.Text), Convert.ToString(txtNombre.Text), Convert.ToString(txtApellido.Text), Convert.ToInt32(txtTelefono.Text));

            Logica.LogicaCliente.Alta(oCli);
            lblError.Text = "Alta exitosa";

            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCli = (Cliente)Session["ClienteABM"];

            Logica.LogicaCliente.Baja(oCli);

            lblError.Text = "Eliminación exitosa";
            this.LimpioFormulario();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente oCli = (Cliente)Session["ClienteABM"];

            //Modifico el objeto
            oCli.Nombre = txtNombre.Text;
            oCli.Apellido = txtApellido.Text;
            oCli.Telefono = Convert.ToInt32(txtTelefono.Text);

            Logica.LogicaCliente.Modificar(oCli);
            lblError.Text = "Modificación exitosa";
            this.LimpioFormulario();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}