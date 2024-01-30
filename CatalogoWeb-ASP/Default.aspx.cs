using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb_ASP
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();

                if (!IsPostBack)
                {
                    repetidor.DataSource = listaArticulos;
                    repetidor.DataBind();
                       
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