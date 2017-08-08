Public Class CancelaPedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nFolio As String = Request.Form("nFolio")
        Dim motivo As String = Request.Form("motivo")
        Dim emp As uE2E.Struc_Empleado = Session("empleado")
        Dim cParam As String = "309|" & uE2E.glo_cToken & "|" & emp.id_Empleado & "|" &
                                   emp.cPassword & "|" &
                                   nFolio & "|" &
                                   emp.id_Cliente & "|" &
                                   motivo
        Dim respuesta As String = uE2E.ws_p.wmCampo(cParam)
        If respuesta.ToLower().Contains("ok") Then
            Response.Write("Correcto")
        Else
            Response.Write("Error")
        End If

    End Sub

End Class