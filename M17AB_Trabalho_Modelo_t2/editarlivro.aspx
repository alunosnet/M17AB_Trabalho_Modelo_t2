<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="editarlivro.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.editarlivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <label for="tbNomeLivro">Nome</label>
        <asp:TextBox ID="tbNomeLivro" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="tbAno">Ano</label>
        <asp:TextBox ID="tbAno" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="tbData">Data de Aquisição</label>
        <asp:TextBox ID="tbData" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="tbPreco">Preço</label>
        <asp:TextBox ID="tbPreco" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Image ID="imgCapa" runat="server" Width="100" /><br />
    <div class="form-group">
        <label for="fuCapa">Capa</label>
        <asp:FileUpload ID="fuCapa" runat="server" CssClass="form-control" />
    </div>
    <asp:Button CssClass="btn btn-danger" ID="btEditarLivro" runat="server" Text="Guardar" OnClick="btEditarLivro_Click" />
    <asp:Button CssClass="btn btn-info" ID="btCancelar" runat="server" Text="Cancelar" OnClick="btCancelar_Click" />
    <asp:Label ID="lbErroLivro" runat="server" Text=""></asp:Label>
</asp:Content>
