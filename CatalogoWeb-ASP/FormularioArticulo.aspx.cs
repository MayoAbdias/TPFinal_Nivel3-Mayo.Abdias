using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb_ASP
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        
        public bool confirmaEliminacion { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmaEliminacion = false;
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNeg = new MarcaNegocio();
                    CategoriaNegocio categoriaNeg = new CategoriaNegocio();
                    List<Categorias> listaCategoria = categoriaNeg.listar();
                    List<Marcas> listaMarca = marcaNeg.listar();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulos seleccionado = negocio.listar(id)[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlimagen.Text = seleccionado.ImagenUrl;

                    txtUrlimagen_TextChanged(sender, e);

                }




            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }


        protected void txtUrlimagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlimagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = Decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtUrlimagen.Text;


              

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }
                Response.Redirect("ListaArticulos.aspx",false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

      

       
        protected void confirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx",false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }    
    }
}