<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CatalogoWeb_ASP.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">❌Se ha Producido un Error❌ </h1>
   
    <div class="row justify-content-center mt-5 shadow-lg p-3 bg-transparent text-lg-center">
        <div class="col-6">
            <div class="mb-3">
                 <asp:Label Text="text" CssClass="form-control-lg border-bottom border-3" ID="lblMensaje" runat="server" />                
            </div>
              <a href="Default.aspx" class="btn btn-secondary">Regresar</a>
        </div>
    </div>
   

</asp:Content>
