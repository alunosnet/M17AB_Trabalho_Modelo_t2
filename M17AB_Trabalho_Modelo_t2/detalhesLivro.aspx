<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="detalhesLivro.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.detalhesLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="imgCapa" runat="server" /><br />
    <asp:Label ID="lbNome" runat="server" /><br />
    <asp:Label ID="lbAno" runat="server" /><br />
    <asp:Label ID="lbPreco" runat="server" /><br />
    <a href="index.aspx">Voltar</a>
</asp:Content>
