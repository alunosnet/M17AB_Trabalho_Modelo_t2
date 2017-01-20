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
    <div id="divUtilizadores" runat="server">
        <div class="container">
            <h1>Utilizadores</h1>
            <asp:GridView ID="gvUtilizadores" runat="server" CssClass="table table-responsive"></asp:GridView>
            <h1>Adicionar</h1>
            <div class="form-group">
                <label for="tbEmail">Email</label>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbNomeUtilizador">Nome</label>
                <asp:TextBox ID="tbNomeUtilizador" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbMorada">Morada</label>
                <asp:TextBox ID="tbMorada" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbNIF">NIF</label>
                <asp:TextBox ID="tbNIF" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tbPassword">Password</label>
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="cbEstado">Estado</label>
                <asp:CheckBox ID="cbEstado" runat="server" CssClass="form-control"></asp:CheckBox>
            </div>
            <div class="form-group">
                <label for="ddPerfil">Perfil</label>
                <asp:DropDownList ID="ddPerfil" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Administrador</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">Cliente</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btAdicionarUtilizador" runat="server" CssClass="btn btn-info" Text="Adicionar" OnClick="btAdicionarUtilizador_Click" />
            <asp:Label ID="lbErroUtilizador" runat="server"></asp:Label>
        </div>
    </div>
    <div id="divEmprestimos" runat="server"></div>
</asp:Content>
