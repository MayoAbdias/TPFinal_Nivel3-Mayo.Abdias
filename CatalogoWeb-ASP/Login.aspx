<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb_ASP.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">¿Ya sos usuario?<strong>Logueate..</strong></h2>
    <div class="row justify-content-center mt-5 shadow-lg p-3 bg-transparent text-lg-center ">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Email" CssClass="accordion-body border-top form-control-lg" runat="server" />
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Solo formato Email por favor" ControlToValidate="txtEmail" CssClass="blockquote-footer" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Contraseña" CssClass="accordion-body border-top form-control-lg" runat="server" />
                <asp:TextBox ID="txtPass" CssClass="form-control" REQUIRED  TextMode="Password" runat="server" />
            </div>
            <div class="justify-content-center gap-3 mb-4">
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" />
                <a href="/" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
