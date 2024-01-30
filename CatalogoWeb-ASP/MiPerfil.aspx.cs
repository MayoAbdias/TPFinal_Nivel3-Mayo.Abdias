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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                   
                    if (Seguridad.sesionActiva(Session["User"]))
                    {
                        Users usuario = (Users)Session["User"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;

                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                        {
                            imagenNuevaPerfil.ImageUrl = "~/images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        }
                    }
                    else
                    {
                        Session.Add("error", "Debes estar logueado para ingresar a esta pagina");
                        Response.Redirect("Error.aspx", false);
                    }
                }
               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UserNegocio negocio = new UserNegocio();
                Users usuario = (Users)Session["User"];

                if(txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./images/");

                    txtImagenPerfil.PostedFile.SaveAs(ruta + "Perfil_User-" + usuario.Id + ".jpg");
                    usuario.ImagenPerfil = "Perfil_User-" + usuario.Id + ".jpg";
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                

                negocio.Actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                imagenNuevaPerfil.ImageUrl = "~/images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                Response.Redirect("Default.aspx", false);
               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",false);
        }
    }
}