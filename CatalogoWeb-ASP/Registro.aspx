<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CatalogoWeb_ASP.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center mt-5 shadow-lg p-3 bg-transparent" style="height:400px; border-radius:15px;">
        <div class="col-6">
            <h2 class="text-center">Registrate para ser parte de nosotros🔥</h2>
            <div class="mb-3">
                <asp:Label Text="Email" CssClass="accordion-body border-top form-control-lg " runat="server" />
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Solo formato Email por favor" ControlToValidate="txtEmail" CssClass="blockquote-footer" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Contraseña" CssClass="accordion-body border-top form-control-lg" runat="server" />
                <asp:TextBox ID="txtPass" CssClass="form-control" REQUIRED  TextMode="Password" runat="server" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <asp:Button Text="Cancelar" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click"  runat="server" />
        </div>
    </div>
</asp:Content>
