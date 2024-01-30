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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is Registro || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["User"]))
                    Response.Redirect("Login.aspx",false);
                else
                {
                    Users usuario = (Users)Session["User"];
                    lblUser.Text = usuario.Nombre;
                    if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                }
                   
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx",false);
        }
    }
}