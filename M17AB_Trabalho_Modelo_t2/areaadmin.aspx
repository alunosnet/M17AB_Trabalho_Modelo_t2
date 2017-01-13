<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="areaadmin.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.areaadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área Admin</h1>
    <div class="btn-group">
        <asp:Button ID="btLivros" runat="server" Text="Gerir Livros" CssClass="btn btn-info" />
        <asp:Button ID="btUtilizadores" runat="server" Text="Gerir Utilizadores" CssClass="btn btn-info" />
        <asp:Button ID="btEmprestimos" runat="server" Text="Gerir Empréstimos" CssClass="btn btn-info" />
    </div>
</asp:Content>
