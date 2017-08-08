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
    <div class="col-md-8 col-md-offset-2 no_disp" id="info_ped">
        <div class="panel panel-primary">
            <div class="panel-heading">Detalle del pedido</div>
            <div class="panel-body">
                <label class="control-label">Cliente: </label> <p id="nombre_ped"></p>
                <label class="control-label">Fecha realización: </label> <p id="fecha_ped"></p>
                <label class="control-label">Total: </label> <p id="total_ped"></p>                
            </div>
            
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">Detalle del pedido</div>
                <div class="panel-body">
                    <table class="table table-condensed" id="detalle_pedido">
                        <thead>
                            <tr>
                                <th>Producto</th>
                                <th>Precio</th>
                                <th>Cantidad</th>
                                <th>Adición</th>
                                <th>Precio adición</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
        </div>
    </div>
    <!-- Modal Start here-->
<div class="modal fade bs-example-modal-sm" id="myPleaseWait" role="dialog" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-sm">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">
                    <span class="fa fa-clock-o">
                    </span> Procesando
                 </h4>
            </div>
            <div class="modal-body">
                <div class="col-md-12 text-center">
                    <i class="fa fa-cog fa-spin fa-3x fa-fw"></i>
                    <div class="row">
                        <span class="label label-primary">Espere un momento...</span>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
<!-- Modal ends Here -->
</asp:Content>
