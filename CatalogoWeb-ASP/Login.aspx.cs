using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb_ASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Users usuario = new Users();
            UserNegocio negocio = new UserNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                if (negocio.loguear(usuario))
                {
                    Session.Add("User", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrecta");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}