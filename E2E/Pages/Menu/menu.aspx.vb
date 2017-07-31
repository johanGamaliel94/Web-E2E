Public Class menu1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Esto es cuando los elementos de abajo no están en el WebForm
        usuario_label.InnerText = Session("usuario")
        razon_soc_label.InnerText = Session("razon_soc")
        nombre_com_label.InnerText = Session("nombre_com")
        nivel_seguridad_label.InnerText = Session("nivel_seguridad")

    End Sub

End Class