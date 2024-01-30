<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="CatalogoWeb_ASP.DetallesArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="card text-bg-dark  text-center ">Detalles del Articulo</h2>
    <hr />
    <div class="container shadow-sm p-3 bg-light ">
        <div class="mb-3">
            <div class="row g-0 aling-items-center">
                <div class="col-md-6 text-center">
                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s" ID="imgDetalles" CssClass="img-fuid" style="height:360px; width:250px" onerror="this.onerror=null; this.src= 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'" runat="server" />
                </div>
                <div class="col-md-6">
                    <div class="card-body">
                        <h3 class="text-center">
                            <asp:Label Text="" CssClass=" badge bg-black card-img-bottom form-label " ID="lblNombreTitulo" runat="server" />
                        </h3>
                    </div>
                    <p>
                        <asp:Label Text="Codigo:" CssClass="accordion-body border-top border-2 form-control-lg" runat="server" />
                        <asp:Label Text="" CssClass="form-label form-control-lg" ID="lblCodigo" runat="server" />
                    </p>
                    <hr />
                    <p>
                        <asp:Label Text="Descripcion:" CssClass="accordion-body border-top border-2 form-control-lg" runat="server" />
                        <asp:Label Text="" CssClass="form-label form-control-lg" ID="lblDescripcion" runat="server" />
                    </p>
                    <hr />
                    <p>
                        <asp:Label Text="Marca:" CssClass="accordion-body border-top border-2 form-control-lg" runat="server" />
                        <asp:Label Text="" CssClass="form-label form-control-lg" ID="lblMarca" runat="server" />
                    </p>
                    <hr />
                    <p>
                        <asp:Label Text="Categoria:" CssClass="accordion-body border-top border-2 form-control-lg" runat="server" />
                        <asp:Label Text="" CssClass="form-label form-control-lg" ID="lblCategoria" runat="server" />
                    </p>
                    <hr />
                    <p>
                        <asp:Label Text="Precio:" CssClass="accordion-body border-top border-2 form-control-lg" runat="server" />
                        <asp:Label Text="" CssClass="form-label form-control-lg" ID="lblPrecio" runat="server" />
                    </p>
                    <hr />
                </div>
            </div>
            <div class=" d-flex gap-3  justify-content-center mb-4 text-center ">
                <asp:Button Text="Agrear a Favoritos" ID="btnFavoritos" CssClass="btn btn-primary" OnClick="btnFavoritos_Click" runat="server" />
                <a href="Default.aspx" class="btn btn-secondary">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
