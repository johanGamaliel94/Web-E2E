

Public Class Pedidos
    Inherits System.Web.UI.Page

    Dim objE2E As New uE2E

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("empleado") Is Nothing Then
        '    Response.Redirect("../Login/login.aspx")
        'End If

        Dim empleado As uE2E.Struc_Empleado = Session("empleado")
        Dim peticion As String = String.Format("156|{0}|{1}|{2}|PG|{3}", uE2E.glo_cToken, empleado.id_Empleado, empleado.cPassword, empleado.id_Cliente)
        'contenido.InnerText = peticion

        Dim respuesta As String = uE2E.ws_p.wmCampo(peticion)
        objE2E.fDesempaca_String_Pedido(respuesta)
        Session("objE2E") = objE2E 'Guardamos el objeto actual para recuperar el DataTable con los pedidos

        For Each row As DataRow In objE2E.dt_Pedido.Rows
            'contenido.InnerHtml += "<p>" + row("id_Cliente").ToString + " " + row("Nombre").ToString + " " + row("Tipo_Pago").ToString + "</p>"
            tbody_pedidos.InnerHtml += "<tr><td class='td_folio'>" + row("Folio_Internet").ToString + "</td>"
            tbody_pedidos.InnerHtml += "<td class='td_fecha_Ped'>" + row("Usuario_Pedido_Fecha_Pedido").ToString + "</td>"
            tbody_pedidos.InnerHtml += "<td class='td_nombre_Cli'>" + row("Nombre").ToString + "</td>"
            tbody_pedidos.InnerHtml += "<td class='td_total_Ped'>" + row("Total").ToString + "</td>"
            tbody_pedidos.InnerHtml += "<td><button type='button' class='btn btn-info btn-info-ped' data-toggle='tooltip' data-placement='right' title='Ver detalles'><span class='fa fa-info-circle'></span></button></td>"
            tbody_pedidos.InnerHtml += "<td><button type='button' class='btn btn-success btn-acep-ped' data-toggle='tooltip' data-placement='right' title='Aceptar'><span class='fa fa-check'></span></button></td>"
            tbody_pedidos.InnerHtml += "<td><button type='button' class='btn btn-danger btn-canc-ped' data-toggle='tooltip' data-placement='right' title='Cancelar'><span class='fa fa-times'></span></button></td>"

        Next


    End Sub

End Class