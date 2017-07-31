Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Response.Redirect("principal.aspx")
        'Aquí va a ir la validación del inicio de sesión
        'Session("razon_soc") = "Don Wicho S.A de C.V" 'Este valor cambiará dependiendo del usuario que inicie sesión
        'Session("nombre_com") = "Tacos Don Wicho" 'Este valor cambiará dependiendo del usuario que inicie sesión
        Dim claveEmpleado As String = claveEmpleadoLog.Value
        Dim claveCliente As String = claveClienteLog.Value
        Dim contrasenia As String = contraseniaLog.Value

        Dim peticionWS As String = String.Format("104|{0}|{1}|{2}|{3}|0", uE2E.glo_cToken, claveEmpleado, contrasenia, claveCliente)
        'Dim peticionWS As String = "104|40D2FF65|100|qq|5|0"

        If claveCliente.Length > 0 And claveEmpleado.Length > 0 And contrasenia.Length > 0 Then

            Dim respuestaWS As String = uE2E.ws_p.wmCampo(peticionWS)
            If respuestaWS.ToLower().Contains("ok") Then
                Dim datosUsuario() As String = Split(respuestaWS, "|")
                Dim empleado As New uE2E.Struc_Empleado
                empleado.nAutoridad = datosUsuario(5)
                empleado.cPassword = contrasenia
                empleado.id_Cliente = claveCliente
                empleado.id_Empleado = claveEmpleado
                Session("empleado") = empleado

                '5 6 7 8 (Índice de campos en el formato de retorno de la clave 104)
                'Esto se debe modelar en una clase/estructura (Usuario / Cliente)
                Session("nivel_seguridad") = datosUsuario(5)
                Session("usuario") = datosUsuario(6)
                Session("nombre_com") = datosUsuario(7)
                Session("razon_soc") = datosUsuario(8)
                Response.Redirect("../Menu/menu.aspx")
                'errores.InnerHtml = "<p style='color: green;'>Inicio correcto</p>"
                'errores.InnerHtml = respuestaWS
                'errores.InnerHtml = "1 " + datosUsuario(0) + " 2 " + datosUsuario(1) + " 3 " + datosUsuario(2)
                'errores.InnerHtml = "nombre_com " + Session("nombre_com") + " razon soc " + Session("razon_soc") + " usuario " + Session("usuario") + " nivel seguridad " + Session("nivel_seguridad")
            Else
                errores.InnerHtml = "<p style='color: red;'>Datos incorrectos, intente de nuevo</p>"
            End If

        Else
            errores.InnerHtml = "<p style='color: red;'>Debes llenar todos los campos</p>"
        End If

        'Response.Redirect("~/menu.aspx")
        'Response.Redirect(Request.Url.ToString())
    End Sub

End Class