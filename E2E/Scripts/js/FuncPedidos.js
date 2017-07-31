$(document).ready(function () {

    $(".btn-info-ped").on("click", function (e) {
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        var importe = $(this).closest('tr').find('.td_total_Ped').text();
        var nombre_cli = $(this).closest('tr').find('.td_nombre_Cli').text();
        $('#fecha_ped').text(fecha);
        $('#total_ped').text(parseFloat(importe).toFixed(2)+" MXN");
        $('#nombre_ped').text(nombre_cli);
        $('#contenido').hide();
        $('#btn_ret').show();
        $('#info_ped').show();
        console.log("folio " + folio + " fecha " + fecha);

    });

    $('#btn_ret').on("click", function (e) {
        $('#btn_ret').hide();
        $('#info_ped').hide();
        $('#contenido').show();
    });



    $(".btn-canc-ped").on("click", function (e) {
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        bootbox.confirm({
            title: "Cancelar pedido",
            message: "¿Está seguro de cancelar el pedido con folio " + folio + " ?",

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
                console.log("La acción es " + result)
            }

        });
        
    });

    $('.btn-acep-ped').on('click', function (e) {
        var folio = $(this).closest('tr').find('.td_folio').text();
        var fecha = $(this).closest('tr').find('.td_fecha_Ped').text();
        bootbox.confirm({
            title: "Aceptar pedido",
            message: "¿Está seguro de aceptar el pedido con folio " + folio + " ?",

            buttons: {
                confirm: {
                    label: "Aceptar <i class='fa fa-check'></i>"
                },
                cancel: {
                    label: "Cancelar <i class='fa fa-remove'></i>"
                }
            },

            callback: function (result) {
                console.log("La acción es " + result)
            }

        });
    });


});