Public Class Menu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        razon_soc.InnerText = Session("razon_soc")
        nombre_com.InnerText = Session("nombre_com")
        etiqueta_usuario.InnerText = Session("usuario")
    End Sub

End Class