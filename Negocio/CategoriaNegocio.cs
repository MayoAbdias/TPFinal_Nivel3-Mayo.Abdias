using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> listar()
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias categoria = new Categorias();
                    categoria.Id = (int)datos.Lector["Id"];
                    categoria.Descripcion = (string)datos.Lector["Descripcion"];

                    listaCategorias.Add(categoria);
                }
                return listaCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
