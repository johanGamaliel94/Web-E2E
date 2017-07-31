$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();/*Activa pequeños mensajes informativos en todo tipo de campos*/

    var CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyzñ-_.,/;:()áéíóú0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZÑÁÉÍÓÚ@";
    ///[a-z]+@[a-z]+\.[a-z]+/.test( value )
    $(".side-nav .collapse").on("hide.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-right").addClass("fa-angle-down");
    });
    $('.side-nav .collapse').on("show.bs.collapse", function () {
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-down").addClass("fa-angle-right");
    });

    $(".datosUs").on("keyup", function (e) {
        
        console.log("datos pres " + $(this).val());
        var car = "";
        var noPerm = "";
        for (i = 0; i < $(this).val().length; i++) {
            car = $(this).val().charAt(i);
            if (CaracteresPermitidos.indexOf(car) < 0) {
                if (noPerm.indexOf(car) < 0) {
                    noPerm += car;
                }
            }

        }
        $(this).parent(".form-group").find(".error").css("color", "red");
        $(this).parent(".form-group").find(".error").text("Los caracteres " + noPerm + " no están permitidos");
        console.log("No perm " + noPerm);
    });

    function validaRegistro() {

    }

    $("#ver_prod").on("click", function () {
        console.log("Ver produc");
        $.post("Productos.aspx", function (res) {
            $("#main").html(res);
        });
    });

    $(".btn-reports").on("click", function () {

    });
});
