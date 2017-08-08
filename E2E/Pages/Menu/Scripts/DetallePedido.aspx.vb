Public Class DetallePedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objuE2E As uE2E = Session("objE2E")
        Dim nFolio As String = Request.Form("nFolio")
        Dim dt_Pedido As DataTable = objuE2E.dt_Pedido
        'Dim dr_Pedido_Detalle As DataRow = objuE2E.fDataTable_Filtra_Ordena(dt_Pedido, "Folio_Internet = '" & nFolio & "' And Status = 'PG'", "Folio_Internet").Rows(0)
        Dim dt_Listado_Pedido_Detalle As DataTable = objuE2E.fDataTable_Filtra_Ordena(objuE2E.dt_Pedido_Detalle, "Folio_Internet = '" & nFolio & "'", "Consecutivo")

        'Dim rowA As DataRow = dt_Listado_Pedido_Detalle.Rows(0)

        For Each row As DataRow In dt_Listado_Pedido_Detalle.Rows
            Response.Write("<tr><td>")
            Response.Write(row("Nombre"))
            Response.Write("</td><td>$")
            Dim precio_Adicion As String = row("Precio") + ".00"
            Response.Write(precio_Adicion)
            Response.Write(".00")
            Response.Write("</td><td>")
            Response.Write(row("Cantidad"))
            Response.Write("</td>")

            Dim adiciones() As String = Split(row("adicion"), "«+»")

            Dim contador As Integer = 0
            Dim ad As String = ""
            Dim ad_precio As String = ""

            For contador = LBound(adiciones) To UBound(adiciones)
                If adiciones(contador).Length > 0 Then
                    Dim adicion() As String = Split(adiciones(contador), "««")
                    ad += adicion(0) + "<br>"
                    ad_precio += "$" + adicion(1) + "<br>"
                End If
            Next
            Response.Write("<td>")
            Response.Write(ad)
            Response.Write("</td><td>")
            Response.Write(ad_precio)
            Response.Write("</td></tr>")
        Next

    End Sub

End Class