<%@ Page Title="M17AB" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="div_login" runat="server" class="pull-right col-md-3 table-bordered text-center">
        Email<asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
        Password<asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" /><br />
        <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        <asp:Button CssClass="btn" ID="btRecuperarPass" runat="server" Text="Recuperar Password" OnClick="btRecuperarPass_Click" />
        <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    </div>
    <div class="pull-left col-md-4 col-sm-4 input-group">
        <asp:TextBox runat="server" ID="tbPesquisa" CssClass="form-control" />
        <span class="input-group-btn">
            <asp:Button ID="btPesquisa" runat="server" Text="Pesquisar" CssClass="btn btn-info" OnClick="btPesquisa_Click" />
        </span>
    </div>
    <div id="div_livros" class="pull-left col-md-9" runat="server"></div>

</asp:Content>
