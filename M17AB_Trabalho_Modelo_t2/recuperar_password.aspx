<%@ Page Title="" Language="C#" MasterPageFile="~/mp.Master" AutoEventWireup="true" CodeBehind="recuperar_password.aspx.cs" Inherits="M17AB_Trabalho_Modelo_t2.recuperar_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-control">
        <label for="tbPassword">Nova Password</label>
        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" />
        <asp:Button runat="server" ID="btPassword" Text="Atualizar" OnClick="btPassword_Click" />
        <asp:Label ID="lbErro" runat="server" />
    </div>
</asp:Content>
