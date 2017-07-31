<%@ Page Title="Pedidos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu.Master" CodeBehind="Pedidos.aspx.vb" Inherits="E2E.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10 col-md-offset-1" id="contenido">
        <table class="table table-hover table-responsive">
            <thead>
                <tr>
                    <th>Folio Pedido</th>
                    <th>Fecha emisión</th>
                    <th>Nombre cliente</th>
                    <th>Importe</th>
                    <th colspan="3"></th>
                </tr>
            </thead>
            <tbody runat="server" id="tbody_pedidos">

            </tbody>
        </table>
    </div>

    <div class="col-md-11" id="div_ret">
        <div class="pull-right">
            <button type="button" class="btn btn-primary no_disp" id="btn_ret">Regresar</button>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3 no_disp" id="info_ped">
        <div class="panel panel-primary">
            <div class="panel-heading">Detalle del pedido</div>
            <div class="panel-body">
                <label class="control-label">Cliente: </label> <p id="nombre_ped"></p>
                <label class="control-label">Fecha realización: </label> <p id="fecha_ped"></p>
                <label class="control-label">Total: </label> <p id="total_ped"></p>
            </div>
        </div>
    </div>
</asp:Content>
