using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar(string id = "")
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();           
           
            try
            {
                datos.setearConsulta("Select  Codigo, Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria,A.IdMarca,A.IdCategoria, ImagenUrl, Precio,A.Id from ARTICULOS A , MARCAS M ,CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.IdCategoria ");
                if(id != "")
                {
                    datos.setearConsulta("Select  Codigo, Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria,A.IdMarca,A.IdCategoria, ImagenUrl, Precio,A.Id from ARTICULOS A , MARCAS M ,CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.IdCategoria And A.Id = " + id);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = decimal.Parse(string.Format("{0:F2}", datos.Lector["Precio"]));
                  
                    


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
           
           
        }
        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)Values (@Codigo, @Nombre,@Descripcion, @IdMarca,@IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro ("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();

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
        public void modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion,IdMarca = @IdMarca,IdCategoria = @IdCategoria,ImagenUrl = @ImagenUrl,Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo",modificar.Codigo);
                datos.setearParametro("@Nombre",modificar.Nombre);
                datos.setearParametro("@Descripcion",modificar.Descripcion);
                datos.setearParametro("@IdMarca",modificar.Marca.Id);
                datos.setearParametro("@IdCategoria",modificar.Categoria.Id);
                datos.setearParametro("@ImagenUrl",modificar.ImagenUrl);
                datos.setearParametro("@Precio",modificar.Precio);
                datos.setearParametro("@Id",modificar.Id);

                datos.ejecutarAccion();

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
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select  Codigo, Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria,A.IdMarca,A.IdCategoria, ImagenUrl, Precio,A.Id from ARTICULOS A , MARCAS M ,CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
                if(campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Celulares":
                            consulta += "C.Descripcion like 'Celulares'";
                            break;
                        case "Televisores":
                            consulta += "C.Descripcion like 'Televisores'";
                            break;
                        case "Media":
                            consulta += "C.Descripcion like 'Media'";
                            break;
                        default:
                            consulta += "C.Descripcion like 'Audio'";
                            break;
                    }
                }else if(campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Samsung":
                            consulta += "M.Descripcion like 'Samsung'";
                            break;
                        case "Apple":
                            consulta += "M.Descripcion like 'Apple'";
                            break;
                        case "Motorola":
                            consulta += "M.Descripcion like 'Motorola'";
                            break;
                        case "Sony":
                            consulta += "M.Descripcion like 'Sony'";
                            break;
                        default:
                            consulta += "M.Descripcion like 'Huawei'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio =" + filtro;
                            break;
                    }
                }



                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];




                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
