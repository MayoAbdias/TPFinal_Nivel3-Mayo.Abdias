<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CatalogoWeb_ASP.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <hr />
    <%if (Session["Favoritos"] == null)
            {%>
      <h3 class="card text-bg-dark  text-center ">¡Todavia no agregaste ningun articulo a tus Favoritos!🔥
            <strong>¿Que estas esperando?</strong>

      </h3>
     <div class="text-center">
        <a href="Default.aspx" class="btn btn-secondary ">Regresar al Home</a>
     </div>
     

           <% } %>
    <%else
            {%>

         
    <h2 class="card text-bg-dark text-center">Aca estan tus articulos <strong>Favoritos</strong></h2>
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="dgvFavoritos" CssClass="table table-border table-dark" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvFavoritos_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="Accion" SelectText="Eliminar❌" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="text-center">
        <a href="Default.aspx" class="btn btn-secondary">Regresar al Home</a>
    </div>
      <% }%>

</asp:Content>
