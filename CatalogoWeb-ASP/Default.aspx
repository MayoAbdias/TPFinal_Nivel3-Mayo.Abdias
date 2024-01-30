<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb_ASP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="card text-bg-dark text-center " >Bienvenido a <strong>Tu Tienda Virtual</strong> </h2>
    <hr />
    <h3 class="text-center">Aca encontraras <strong>TODO</strong> sobre las nuevas <strong>TECNOLOGIAS 👇</strong></h3>
     
     <div class="row row-cols-1 row-cols-md-4 row-cols-lg-3 g-4 mt-3 mb-5"  style="display: flex; justify-content: center; align-items: center;">
        <asp:Repeater ID="repetidor" runat="server">
            <ItemTemplate>
                <div class="card m-4" style="width: 18rem; display: flex; justify-content: center; align-items: center; border-radius: 10px;" >
                    <div class="imgProduct">
                         <img src="<%#Eval("imagenUrl") %>" class="card-img-top" style="height:350px; width:250px" alt="Imagen de producto" onerror="this.onerror=null; this.src= 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ28WA2ZQREgEZ1jva2HNK6hzzNLXtnkxGhG2eCg1bAuw&s'">
                    </div>
                   
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Precio") %></p>
                        <a href="DetallesArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalles</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
     </div>

</asp:Content>
