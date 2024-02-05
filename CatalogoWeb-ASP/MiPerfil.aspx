<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CatalogoWeb_ASP.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class=" text-center card text-bg-dark"> Mi Perfil</h2>
    <div class="row justify-content-center mt-5 shadow-lg p-3 bg-transparent text-lg-center">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="accordion-body border-top border-dark-subtle border-2 form-control-lg">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" REQUIRED  runat="server" />
            </div>
            <div class="mb-3">
                <label class="accordion-body border-top border-dark-subtle border-2 form-control-lg">Nombre</label>  
                <asp:TextBox ID="txtNombre" CssClass="form-control" REQUIRED  runat="server" />
            </div>
            <div class="mb-3">
                <label  class="accordion-body border-top border-dark-subtle border-2 form-control-lg">Apellido</label>               
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
            </div>           
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="accordion-body border-top border-dark-subtle border-2 form-control-lg">Imagen Perfil</label>
                <input type="file" runat="server" id="txtImagenPerfil" class="form-control" />
            </div>
            <asp:Image ID="imagenNuevaPerfil" ImageUrl="https://th.bing.com/th/id/OIP.FjLkalx51D8xJcpixUGJywHaE8?w=262&h=180&c=7&r=0&o=5&pid=1.7"
                cssclass="img-fluid mb-3" runat="server" />
        </div>
    </div>
    <div class="row text-end">
        <div class="col-7">
            <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
            <asp:Button Text="Regresar" ID="btnRegresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" runat="server" />
        </div>
    </div>
</asp:Content>
