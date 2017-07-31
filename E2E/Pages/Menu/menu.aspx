<%@ Page Title="Menú Principal" Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu.Master" CodeBehind="menu.aspx.vb" Inherits="E2E.menu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 col-md-12 well" id="content">
    <h1>Bienvenido, <label id="usuario_label" runat="server"></label>!</h1>
        <div class="row">
            <label class="control-label">Nombre comercial: <label id="nombre_com_label" runat="server"></label></label>
        </div>
        <div class="row">
            <label class="control-label">Razón social: <label id="razon_soc_label" runat="server"></label></label>
        </div>
        <div class="row">
            <label class="control-label">Nivel de seguridad: <label id="nivel_seguridad_label" runat="server"></label></label>
        </div>
    </div> 
</asp:Content>
