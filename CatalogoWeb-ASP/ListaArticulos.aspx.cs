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
    public partial class ListaArticulos : System.Web.UI.Page
    {
		public bool filtroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!Seguridad.esAdmin(Session["User"]))
				{
					Session.Add("error", "Debes ser Admin para poder ingresar a esta pagina..");
					Response.Redirect("Error.aspx", false);
				}


				ArticuloNegocio negocio = new ArticuloNegocio();
				Session.Add("listaArticulos",negocio.listar());
				dgvArticulos.DataSource = Session["listaArticulos"];
				dgvArticulos.DataBind();
			}
			catch (Exception ex)
			{

				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
			var id = dgvArticulos.SelectedDataKey.Value.ToString();
			Response.Redirect("FormularioArticulo.aspx?Id=" + id);

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
			dgvArticulos.PageIndex = e.NewPageIndex;
			dgvArticulos.DataBind();
        }
		//Filtro sin ir a la base de datos↓↓
        protected void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
			List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
			List<Articulos> listaNombres = lista.FindAll(x => x.Nombre.ToLower().Contains(txtFiltroNombre.Text.ToLower()));
			dgvArticulos.DataSource = listaNombres;
			dgvArticulos.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
			filtroAvanzado = chkFiltroAvanzado.Checked;
			txtFiltroNombre.Enabled = !filtroAvanzado;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
			try
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				Session.Add("cargarGrilla", negocio.listar());
				dgvArticulos.DataSource = Session["cargarGrilla"];
				txtFiltroNombre.Text = "";
				dgvArticulos.DataBind();
			}
			catch (Exception ex)
			{

				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
			try
			{
				ArticuloNegocio negocio = new ArticuloNegocio();
				dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
					ddlCriterio.SelectedItem.ToString(),txtFiltroAvanzado.Text);
				dgvArticulos.DataBind();
			}
			catch (Exception ex)
			{

				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
			try
			{
				ddlCriterio.Items.Clear();
				if(ddlCampo.SelectedItem.ToString() == "Marca")
				{
					ddlCriterio.Items.Add("Samsung");
					ddlCriterio.Items.Add("Apple");
					ddlCriterio.Items.Add("Motorola");
					ddlCriterio.Items.Add("Sony");
					ddlCriterio.Items.Add("Huawei");
				}else if(ddlCampo.SelectedItem.ToString() == "Categoria")
				{
					ddlCriterio.Items.Add("Celulares");
					ddlCriterio.Items.Add("Televisores");
					ddlCriterio.Items.Add("Media");
					ddlCriterio.Items.Add("Audio");

				}
				else
				{
					ddlCriterio.Items.Add("Mayor a");
					ddlCriterio.Items.Add("Menor a");
					ddlCriterio.Items.Add("igual a");
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