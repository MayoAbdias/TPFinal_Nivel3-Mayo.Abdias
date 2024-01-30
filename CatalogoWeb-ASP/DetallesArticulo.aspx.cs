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
    public partial class DetallesArticulo : System.Web.UI.Page
    {
        public List<Articulos> Favoritos
        {
            get
            {
                if (Session["Favoritos"] == null)
                {
                    Session["Favoritos"] = new List<Articulos>();
                }
                return (List<Articulos>)Session["Favoritos"];
            }
            set
            {
                Session["Favoritos"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();

            try
            {
                if (!Seguridad.sesionActiva(Session["User"]))
                {
                    Session.Add("error", "Debes loguearte para ingresar a esta pagina");
                    Response.Redirect("Error.aspx", false);
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id != "")
                {
                    Articulos seleccionado = artNegocio.listar(id)[0];

                    imgDetalles.ImageUrl = seleccionado.ImagenUrl;

                    lblCodigo.Text = seleccionado.Codigo;
                    lblNombreTitulo.Text = seleccionado.Nombre;
                    lblDescripcion.Text = seleccionado.Descripcion;
                    lblMarca.Text = seleccionado.Marca.Descripcion;
                    lblCategoria.Text = seleccionado.Categoria.Descripcion;
                    lblPrecio.Text = seleccionado.Precio.ToString();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulos> listaFav = negocio.listar(id);
                Favoritos.Add(listaFav[0]);
                Response.Redirect("Favoritos.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
           
        }
    }
}