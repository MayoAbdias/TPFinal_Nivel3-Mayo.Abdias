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
    public partial class Favoritos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["User"]))
            {
                Session.Add("error", "Debes ser Admin para agregar articulos a Favoritos");
                Response.Redirect("Error.aspx", false);
            }
            if (!IsPostBack)
            {
                dgvFavoritos.DataSource = Session["Favoritos"];
                dgvFavoritos.DataBind();
            }
        }

        protected void dgvFavoritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Articulos favoritos = new Articulos();
            string id = dgvFavoritos.SelectedDataKey.Value.ToString();
            List<Articulos> lista = (List<Articulos>)Session["Favoritos"];

            lista.RemoveAll(x => x.Id == int.Parse(id));

            dgvFavoritos.DataSource = Session["Favoritos"];
            dgvFavoritos.DataBind();
        }
    }
}