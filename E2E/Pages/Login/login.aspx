<%@ Page Title="Inicio de sesión" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="login.aspx.vb" Inherits="E2E.login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            
    <div class="col-md-6 col-md-offset-3"><!--Pendiente-->
        <div class="panel panel-default">
            <div class="panel panel-heading">Inicia Sesión <span class="fa fa-user" aria-hidden="true"></span></div>
            <div class="panel panel-body">
                <div class="form-group">
                    <label class="control-label col-md-4">Clave del Empleado</label>
                    <input type="text" class="form-control " name="claveEmpl_log" id="claveEmpleadoLog" runat="server"/>
                    <div class="col-md-offset-4"><p class="error" style="color: crimson" runat="server" id="errorClaveCli"></p></div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-4">Clave del Cliente</label>
                    <input type="text" class="form-control " name="claveCli_log" id="claveClienteLog" runat="server"/>
                    <div class="col-md-offset-4"><p class="error" style="color: crimson" runat="server" id="errorClaveUs"></p></div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-4">Contraseña</label>
                    <input type="password" class="form-control " name="contrasenia_log" id="contraseniaLog" runat="server"/>
                    <div class="col-md-offset-4"><p class="error" runat="server" id="pwdUs"></p></div>
                </div>
                
                <div class="form-group">
                    <div class="col-md-offset-4">
                    
                    <asp:Button Text="Iniciar sesión" CssClass="btn btn-success" runat="server" OnClick="Login_Click" />
                    </div>
                    <div class="col-md-6" runat="server" id="errores">

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
