<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CatalogoWeb_ASP.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bg-dark card text-white text-center">Lista de Articulos</h2>
    <hr class="border-4" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar por Nombre" CssClass="accordion-body border-2 border-dark-subtle  border-top form-control-lg " runat="server" />
                <asp:TextBox ID="txtFiltroNombre" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroNombre_TextChanged" runat="server" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-secondary card-img-top" OnClick="btnAtras_Click" runat="server" />
            </div>
        </div>
    </div>

    <%if (chkFiltroAvanzado.Checked)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" CssClass=" accordion-body  border-top form-control-lg" runat="server" />
                <asp:DropDownList CssClass="form-control form-select" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" CssClass=" accordion-body  border-top form-control-lg" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control form-select">
                    <asp:ListItem Text="Samsung" />
                    <asp:ListItem Text="Apple" />
                    <asp:ListItem Text="Motorola" />
                    <asp:ListItem Text="Sony" />
                    <asp:ListItem Text="Huawei" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtrar" CssClass=" accordion-body  border-top form-control-lg" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
            </div>
        </div>        
        <div class="col-3">
            <div class="mb-3 alert form-check-input">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
    </div>


    <% } %>


    <asp:GridView ID="dgvArticulos" CssClass="table table-borderer table-dark" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AllowPaging="true" AutoGenerateColumns="false"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging" PageSize="5" runat="server">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Selección" SelectText="👈" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary text-center">Agregar Nuevo</a>
</asp:Content>
