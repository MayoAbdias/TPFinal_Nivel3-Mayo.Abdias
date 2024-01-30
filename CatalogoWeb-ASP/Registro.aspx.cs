using Dominio;
using Negocio;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb_ASP
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Users usuario = new Users();
                UserNegocio negocio = new UserNegocio();
                EmailServices emailServices = new EmailServices();

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;

                usuario.Id = negocio.insertarNuevo(usuario);
                Session.Add("User", usuario);

                emailServices.armarCorreo(usuario.Email,"Bienvenido A Tu Tienda","Te damos la bienvenida a nuestra App");
                emailServices.enviarEmail();

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}