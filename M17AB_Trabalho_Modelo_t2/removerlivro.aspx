<%@ Page Title="Remover Livro" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="removerlivro.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.removerlivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Remover Livro</h1>
    Nome:<asp:Label ID="lbNome" runat="server" Text="Label"></asp:Label><br/>
    Ano:<asp:Label ID="lbAno" runat="server" Text="Label"></asp:Label><br/>
    Data Aquisição:<asp:Label ID="lbData" runat="server" Text="Label"></asp:Label><br/>
    Preço:<asp:Label ID="lbPreco" runat="server" Text="Label"></asp:Label><br/>
    Estado:<asp:Label ID="lbEstado" runat="server" Text="Label"></asp:Label><br/>
    <asp:Image ID="imgCapa" runat="server" Width="100"/><br/>
    <asp:Button ID="Button1" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="Button1_Click"/><br/>
    <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-info" OnClick="Button2_Click" />
</asp:Content>
