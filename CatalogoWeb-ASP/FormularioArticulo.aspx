<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="CatalogoWeb_ASP.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bg-black card text-white text-center">Formulario de Articulos</h2>
    <hr class="form-control bg-black"/>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Codigo</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" REQUIRED  runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" REQUIRED  runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" REQUIRED  CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Solo se permiten números" ControlToValidate="txtPrecio"
                     ValidationExpression="^[0-9]*$" Display="Dynamic" CssClass="blockquote-footer link-danger form-switch" runat="server" />
            </div>

        </div>


        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server" />
            </div>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlimagen" class="accordion-body border-2 border-dark-subtle border-top form-control-lg">Url Imagen</label>
                        <asp:TextBox ID="txtUrlimagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlimagen_TextChanged" runat="server" />
                    </div>

                    <asp:Image ImageUrl="https://th.bing.com/th?id=OIP.FjLkalx51D8xJcpixUGJywHaE8&w=306&h=204&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2" ID="imgArticulo" style="height:350px; width:250px;" onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'" runat="server" />
                    <hr />
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                        <a href="ListaArticulos.aspx" class="btn btn-secondary">Cancelar</a>                       
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="Button1" OnClick="btnEliminar_Click" runat="server" />
                    </div>
                    <%if (confirmaEliminacion)
                        { %>
                        <div class="mb-3 text-center">
                            <asp:CheckBox Text="Confirmar eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="eliminar" ID="Button2" CssClass="btn btn-outline-danger" OnClick="confirmarEliminacion_Click" runat="server" />
                        </div>
                    <%} %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
   
</asp:Content>
