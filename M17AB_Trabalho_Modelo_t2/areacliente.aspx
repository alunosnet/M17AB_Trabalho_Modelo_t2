<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="areacliente.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.areacliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área Cliente</h1>
    <div class="btn-group">
        <asp:Button ID="btEmprestimo" runat="server" Text="Fazer empréstimo" CssClass="btn btn-info" OnClick="btEmprestimo_Click" />
        <asp:Button ID="btDevolve" runat="server" Text="Devolução" CssClass="btn btn-info" OnClick="btDevolve_Click" />
        <asp:Button ID="btHistorico" runat="server" Text="Histórico" CssClass="btn btn-info" OnClick="btHistorico_Click" />
    </div>
    <div id="divEmprestimo" runat="server">
        <h2>Livros para emprestar</h2>
        <asp:GridView ID="gvLivrosEmprestar" runat="server" CssClass="table table-responsive"></asp:GridView>
    </div>
    <div id="divDevolver" runat="server">
        <h2>Devolver livros</h2>
        <asp:GridView ID="gvLivrosEmprestados" runat="server" CssClass="table table-responsive"></asp:GridView>
    </div>
    <div id="divHistorico" runat="server">
        <h2>Histórico</h2>
        <asp:GridView ID="gvHistorico" runat="server" CssClass="table table-responsive"></asp:GridView>
    </div>
</asp:Content>
