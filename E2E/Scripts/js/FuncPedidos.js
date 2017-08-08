$(document).ready(function () {

    $(".btn-info-ped").on("click", function (e) {
        
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        var importe = $(this).closest('tr').find('.td_total_Ped').text();
        var nombre_cli = $(this).closest('tr').find('.td_nombre_Cli').text();
        $('#fecha_ped').text(fecha);
        $('#total_ped').text("$"+parseFloat(importe).toFixed(2)+" MXN");
        $('#nombre_ped').text(nombre_cli);
        $('#contenido').hide();
        $('#btn_ret').show();
        $('#info_ped').show();
        console.log("folio " + folio + " fecha " + fecha);
        $("#myPleaseWait").modal("show");
        $.post("../Menu/Scripts/DetallePedido.aspx", { "nFolio": folio }, function (response) {
            console.log("Resp: " + response)
            $("#detalle_pedido tbody").empty()
            $("#detalle_pedido tbody").append(response)
            setTimeout(function () { $('#myPleaseWait').modal('hide'); }, 2000);
            
        });
        

    });

    $('#btn_ret').on("click", function (e) {
        $('#btn_ret').hide();
        $('#info_ped').hide();
        $('#contenido').show();
    });



    $(".btn-canc-ped").on("click", function (e) {
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        var row = $(this).closest('tr');

        bootbox.confirm({
            title: "Cancelar pedido con folio "+folio,
            message: "Motivo de cancelación"+
                       "<br><br><div class='form group'><textarea class='container form-control' id='motivo' rows='3' placeholder='Escribe el motivo'></textarea></div>",

            buttons: {
                confirm: {
                    label: "Aceptar <i class='fa fa-check'></i>",
                    className: 'btn-success pull-left'
                },
                cancel: {
                    label: "Cancelar <i class='fa fa-remove'></i>",
                    className: 'btn-danger pull-right'
                }
            },

            callback: function (result) {
                console.log("La acción es " + result + " input " + $('#motivo').val());
                if(result){
                    if ($('#motivo').val().length < 1) {
                        $('#motivo').css('background-color', 'rgba(217, 83, 79, 0.42)');
                        return false;
                    }
                    $('#myPleaseWait').modal('show');
                    $.post("../Menu/Scripts/CancelaPedido.aspx", { "nFolio": folio, "motivo":$('#motivo').val() }, function (res) {

                        console.log("Res: " + res);
                        setTimeout(function () { $('#myPleaseWait').modal('hide'); }, 2000);
                        if (res == "Correcto") {
                            row.hide('slow', function () { row.remove() });
                            console.log("Proceso correcto");
                            return;
                        }
                    });
                    
                    //mostrar mensaje de error
                    console.log('Error')
                    
                    return true;
                }
                
            }

        });
        
    });

    $('.btn-acep-ped').on('click', function (e) {
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        var row = $(this).closest('tr');
        bootbox.confirm({
            title: "Aceptar pedido",
            message: "¿Está seguro de aceptar el pedido con folio " + folio + "?",

            buttons: {
                confirm: {
                    label: "Aceptar <i class='fa fa-check'></i>",
                    className: "btn-success pull-left"
                },
                cancel: {
                    label: "Cancelar <i class='fa fa-remove'></i>",
                    className: "btn-danger pull-right"
                }
            },

            callback: function (result) {
                console.log("La acción es " + result + " asdas")

                if (result) {
                    $('#myPleaseWait').modal('show');
                    $.post("../Menu/Scripts/AceptaPedido.aspx", { "nFolio": folio }, function (res) {
                        
                        console.log("Res: " + res);
                        setTimeout(function () { $('#myPleaseWait').modal('hide'); }, 2000);
                        if (res == "Correcto") {
                            row.hide('slow', function () { row.remove() });
                            return;
                        }
                    });
                    
                    //mostrar mensaje de error
                        console.log('Error')
                    return;
                }
                
                    //mostrar mensaje de cancelado
            }

        });
    });


});