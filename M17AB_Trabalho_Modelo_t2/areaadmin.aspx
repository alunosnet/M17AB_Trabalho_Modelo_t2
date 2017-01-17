<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="areaadmin.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.areaadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área Admin</h1>
    <div class="btn-group">
        <asp:Button ID="btLivros" runat="server" Text="Gerir Livros" CssClass="btn btn-info" OnClick="btLivros_Click" />
        <asp:Button ID="btUtilizadores" runat="server" Text="Gerir Utilizadores" CssClass="btn btn-info" OnClick="btUtilizadores_Click" />
        <asp:Button ID="btEmprestimos" runat="server" Text="Gerir Empréstimos" CssClass="btn btn-info" OnClick="btEmprestimos_Click" />
    </div>
    <div id="divLivros" runat="server">
        <div class="container">
            <h1>Livros</h1>
            <asp:GridView ID="gvLivros" runat="server" CssClass="table table-responsive"></asp:GridView>
            <h1>Adicionar</h1>
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
            <div class="form-group">
                <label for="fuCapa">Capa</label>
                <asp:FileUpload ID="fuCapa" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btAdicionarLivro" runat="server" Text="Adicionar" OnClick="btAdicionarLivro_Click" />
            <asp:Label ID="lbErroLivro" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div id="divUtilizadores" runat="server"></div>
    <div id="divEmprestimos" runat="server"></div>
</asp:Content>
