<%@ Page Title="M17AB" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_login" runat="server" class="pull-right col-md-3 table-bordered text-center">
        Email<asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" ></asp:TextBox><br />
        Password<asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password" /><br />
        <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
        <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
