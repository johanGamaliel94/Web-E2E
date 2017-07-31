'Imports ADOX.DataTypeEnum
'Imports ADOX.KeyTypeEnum

Public Class uE2E

    Public Shared ws_p As New WebService.Service1

    Public dt_Cliente As Data.DataTable
    Public dt_Empleado As Data.DataTable
    Public dt_Categoria As Data.DataTable
    Public dt_Producto As Data.DataTable
    Public dt_Producto_Partida As Data.DataTable
    Public dt_Producto_Partida_Grupo As New Data.DataTable
    Public dt_Producto_Partida_Detalle As New Data.DataTable

    Public dt_Pedido As Data.DataTable
    Public dt_Pedido_Detalle As Data.DataTable

    Public dt_Pedido_Reimprime As Data.DataTable
    Public dt_Pedido_Detalle_Reimprime As Data.DataTable

    Public dr_Listado_Pedido As DataRow
    Public dt_Listado_Pedido_Detalle As DataTable


    Public dt_Tipo_Cliente As DataTable
    Public dt_Tipo_Cliente_Producto As DataTable

    Public dt_Pais_Estado_Ciudad_Zona As Data.DataTable
    Public dt_Pais As Data.DataTable

    Public dt_Menu As DataTable
    Public dt_Pais_Estado As DataTable
    Public dt_Pais_Estado_Ciudad As DataTable
    Public dt_Geocerca As DataTable

    Public Shared glo_nRegistro_Anterior As Integer
    Public Shared glo_Ultimo_Folio_Pedido As Long
    Public Shared glo_cToken As String = "40D2FF65"
    Public Shared gbl_Resultado As String
    Public Shared gbl_Descripcion As String
    Public Shared gbl_Mensaje As String

    Dim _Resultado As String = ""
    Dim _Clave As String = ""
    Dim _Descripcion As String = ""
    Dim _Mensaje As String = ""


    Public Cli As Struc_Cliente
    Public Emp As Struc_Empleado

    Public Pro As Struc_Producto
    Public Pro_cli() As Struc_Producto

    'Private Det As Struc_Pedido_Detalle

    Public Cat As Struc_Categoria
    Public Cat_cli() As Struc_Categoria

    '===============================

    Public Ped As Struc_Pedido
    Public Ped_Cli() As Struc_Pedido

    '===============================


    Private Zona() As Struc_Zona

    Public ds_Base As New Data.DataSet("Base")


    Public Structure Struc_Empleado
        Dim id_Cliente As String
        Dim id_Empleado As String
        Dim cCelular As String
        Dim nAutoridad As Short
        Dim cNombre As String
        Dim cPaterno As String
        Dim cMaterno As String
        Dim cPassword As String
        Dim bCambia_Password As Boolean
    End Structure

    Public Structure Struc_Cliente
        Dim id_Cliente As Long
        Dim cNombre As String
        Dim cNombre_Comercial As String
        Dim bProducto_Kosher As Boolean
        Dim bServicio_en_Sitio As Boolean
        Dim bEntrega_Domicilio As Boolean
        Dim bEntrega_Ocurre As Boolean
        Dim nTipo_Cobertura_Entrega_Domicilio As Short
        Dim nDistancia_Cobertura As Integer
        Dim nPedido_Minimo As Single
        Dim nPrecio_Envio_Domicilio As Single
        Dim nPorciento_Comision_Envio As Single
        Dim bManeja_E2E_Monedero As Boolean
        Dim bManeja_E2E_Puntos As Boolean
        Dim bManeja_Promocion_Puntos As Boolean
        Dim bManeja_Promocion_Porciento As Boolean
        Dim bManeja_Promocion_Importe As Boolean
        Dim bManeja_Promocion_Producto As Boolean
        Dim bManeja_Monedero As Boolean
        Dim bManeja_Puntos As Boolean
        Dim nPorciento_Puntos As Boolean
        Dim nDias_Vigencia_Saldo_Puntos As Integer
        Dim bEmite_Factura_Fiscal As Boolean
        Dim nDias_Factura_Fiscal As Short
        Dim nPeriodicidad_Envio_GPS As Short
        Dim cPedido_Prefijo As String
        Dim nPedido_Folio As Integer
        Dim nPolitica_Cancelacion As Short
        Dim cContacto As String
        Dim cCalle As String
        Dim cExterior As String
        Dim cInterior As String
        Dim cColonia As String
        Dim cDelegacion As String
        Dim cLocalidad As String
        Dim cEntidad As String
        Dim cCod_Postal As String
        Dim cTele_1 As String
        Dim cTele_2 As String
        Dim cWeb As String
        Dim nLatitud As Single
        Dim nLongitud As Single
        Dim id_Pais As Integer
        Dim cPais_Nombre As String
        Dim id_Estado As Integer
        Dim cEstado_Nombre As String
        Dim id_Ciudad As Integer
        Dim cCiudad_Nombre As String
        Dim id_Zona As Integer
        Dim cHorario_Lunes_Ini As Date
        Dim cHorario_Lunes_Fin As Date
        Dim cHorario_Martes_Ini As Date
        Dim cHorario_Martes_Fin As Date
        Dim cHorario_Miercoles_Ini As Date
        Dim cHorario_Miercoles_Fin As Date
        Dim cHorario_Jueves_Ini As Date
        Dim cHorario_Jueves_Fin As Date
        Dim cHorario_Viernes_Ini As Date
        Dim cHorario_Viernes_Fin As Date
        Dim cHorario_Sabado_Ini As Date
        Dim cHorario_Sabado_Fin As Date
        Dim cHorario_Domingo_Ini As Date
        Dim cHorario_Domingo_Fin As Date
        Dim cCorreo As String
        Dim cHorario_Lunes_Ini_2 As Date
        Dim cHorario_Lunes_Fin_2 As Date
        Dim cHorario_Martes_Ini_2 As Date
        Dim cHorario_Martes_Fin_2 As Date
        Dim cHorario_Miercoles_Ini_2 As Date
        Dim cHorario_Miercoles_Fin_2 As Date
        Dim cHorario_Jueves_Ini_2 As Date
        Dim cHorario_Jueves_Fin_2 As Date
        Dim cHorario_Viernes_Ini_2 As Date
        Dim cHorario_Viernes_Fin_2 As Date
        Dim cHorario_Sabado_Ini_2 As Date
        Dim cHorario_Sabado_Fin_2 As Date
        Dim cHorario_Domingo_Ini_2 As Date
        Dim cHorario_Domingo_Fin_2 As Date
        Dim cStatus As String
        Dim cCorreo_2 As String

    End Structure

    Public Structure Struc_Producto
        Dim id_Cliente As Long
        Dim id_Producto As String
        Dim id_Producto_Clase As Integer
        Dim id_Tipo_Categoria As Integer
        Dim nCalorias As Integer
        Dim bProducto_Dieta As Boolean
        Dim bProducto_Kosher As Boolean
        Dim bProducto_Suspendido As Boolean
        Dim bProducto_Entrega_Domicilio As Boolean
        Dim cNombre As String
        Dim cContenido As String
        Dim id_Unidad_Manejo As Integer
        Dim bSujeto_IVA As Boolean
        Dim nPor_IVA As Single
        Dim nPrecio As Single
        Dim nPrecio_Promocion As Single
        Dim nValor_Puntos As Integer
        Dim bDisponible_Lunes As Boolean
        Dim bDisponible_Martes As Boolean
        Dim bDisponible_Miercoles As Boolean
        Dim bDisponible_Jueves As Boolean
        Dim bDisponible_Viernes As Boolean
        Dim bDisponible_Sabado As Boolean
        Dim bDisponible_Domingo As Boolean
        Dim cImagen As String
        Dim cHorario_Lunes_Ini As String
        Dim cHorario_Lunes_Fin As String
        Dim cHorario_Martes_Ini As String
        Dim cHorario_Martes_Fin As String
        Dim cHorario_Miercoles_Ini As String
        Dim cHorario_Miercoles_Fin As String
        Dim cHorario_Jueves_Ini As String
        Dim cHorario_Jueves_Fin As String
        Dim cHorario_Viernes_Ini As String
        Dim cHorario_Viernes_Fin As String
        Dim cHorario_Sabado_Ini As String
        Dim cHorario_Sabado_Fin As String
        Dim cHorario_Domingo_Ini As String
        Dim cHorario_Domingo_Fin As String

    End Structure

    Public Structure Struc_Categoria
        Dim id_Cliente As Long
        Dim id_Categoria As Integer
        Dim cNombre As String
    End Structure

    Public Structure Struc_Zona
        Dim id_Pais As Integer
        Dim id_Estado As Integer
        Dim id_Ciudad As Integer
        Dim id_Zona As Integer
        Dim cNombre_Pais As String
        Dim cNombre_Estado As String
        Dim cNombre_Ciudad As String
        Dim cNombre_Zona As String
    End Structure


    Public Structure Struc_Pedido
        Dim nFolio_Internet As Long
        Dim id_Cliente As Long
        Dim cPedido_Prefijo As String
        Dim nPedido_Folio As Integer
        Dim cStatus As String
        Dim nTipo_Pedido As Short
        Dim id_Usuario As Long
        Dim nTipo_Pago As Short
        Dim cFolio_Aceptacion_Pago As String
        Dim bPedido_Pagado As Boolean
        Dim bFactura_Fiscal As Boolean
        Dim nPedido_Turno As Short
        Dim nPedido_Dia As Short
        Dim nUsuario_Pedido_Tipo_Entrega As Short
        Dim fUsuario_Pedido_Fecha_Pedido As Date
        Dim fUsuario_Pedido_Fecha_Entrega As Date
        Dim bUsuario_Pedido_Recibido As Boolean
        Dim fUsuario_Pedido_Fecha_Recepcion As Date
        Dim bUsuario_Pedido_Cerrado As Boolean
        Dim nUsuario_Clave_Pedido_Cerrado As Short
        Dim fUsuario_Pedido_Cerrado_Fecha As Date
        Dim cUsuario_Pedido_Cerrado_Comentario As String
        Dim bUsuario_Pedido_Cancelado As Boolean
        Dim fUsuario_Pedido_Cancelado_Fecha As Date
        Dim cUsuario_Pedido_Cancelado_Motivo As String
        Dim nIVA As Single
        Dim nTotal As Single
        Dim nE2E_Puntos_Pedido As Integer
        Dim nCliente_Puntos_Pedido As Integer
        Dim cPromo_Puntos_Cupon As String
        Dim cPromo_Puntos_Puntos As Integer
        Dim cPromo_Puntos_Puntos_I As Single
        Dim cPromo_Porciento_Cupon As String
        Dim cPromo_Porciento_Factor As Single
        Dim cPromo_Porciento_I As Single
        Dim cPromo_Importe_Cupon As String
        Dim cPromo_Importe_I As Single
        Dim cPromo_Produ_Cupon As String
        Dim cPromo_Produ_Clave As String
        Dim nCliente_Puntos_Cant As Integer
        Dim nCliente_Puntos_I As Single
        Dim nCliente_Monedero_I As Single
        Dim nE2E_Puntos_Cant As Integer
        Dim nE2E_Puntos_I As Single
        Dim nE2E_Monedero_I As Single
        Dim nPago_Propina As Single
        Dim nPago_Importe_Total As Single
        Dim nCambio As Single
        Dim cComentario_Calificacion As String
        Dim cComentario_Observaciones As String
        Dim bRequiere_Factura As Boolean
        Dim cFactura_RFC As String
        Dim bRuta_Generada As Boolean
        Dim id_Ruta As Integer
        Dim fRuta_Fecha As Date
        Dim cRuta_Usuario As String
        Dim id_Domicilio_Entrega As String
        Dim cNombre As String
        Dim cCalle As String
        Dim cExterior As String
        Dim cInterior As String
        Dim cColonia As String
        Dim cDelegacion As String
        Dim cLocalidad As String
        Dim cEntidad As String
        Dim cCod_Postal As String
        Dim cTele As String
        Dim nLatitud As Single
        Dim nLongitud As Single
        Dim bYa_Reportado As Boolean
        Dim Detalle() As Struc_Pedido_Detalle
    End Structure

    Public Structure Struc_Pedido_Detalle
        Dim nFolio_Internet As Long
        Dim nConsecutivo As Integer
        Dim id_Producto As String
        Dim cNombre As String
        Dim nCantidad As Single
        Dim nPrecio As Single
        Dim cAdicion As String
        Dim id_Categoria As Integer
        Dim cNombre_Categoria As String
    End Structure


    Public ReadOnly Property a_RD_Clave As Integer
        Get
            Return _Clave
        End Get
    End Property

    Public ReadOnly Property a_RD_Resultado As String
        Get
            Return _Resultado
        End Get
    End Property

    Public ReadOnly Property a_RD_Mensaje As String
        Get
            Return _Mensaje
        End Get
    End Property

    Public ReadOnly Property a_RD_Descripcion As String
        Get
            Return _Descripcion
        End Get
    End Property




    Public ReadOnly Property a_Cliente_DataTable_22 As DataTable
        Get
            Return dt_Cliente
        End Get
    End Property

    Public ReadOnly Property a_Producto_DataTable_22 As DataTable
        Get
            Return dt_Producto
        End Get
    End Property

    Public ReadOnly Property a_Producto_Partida_DataTable_22 As DataTable
        Get
            Return dt_Producto_Partida
        End Get
    End Property

    Public ReadOnly Property a_Categoria_DataTable_22 As DataTable
        Get
            Return dt_Categoria
        End Get

    End Property

    Public ReadOnly Property a_Zona_DataTable_22 As DataTable
        Get
            Return dt_Pais_Estado_Ciudad_Zona
        End Get
    End Property



    ReadOnly Property a_Cli As Struc_Cliente
        Get
            Return Cli
        End Get
    End Property

    ReadOnly Property a_Emp As Struc_Empleado
        Get
            Return Emp
        End Get
    End Property



    Public Sub New()

        fInicializa_DataSet()

    End Sub

    Public Sub fInicializa_DataSet()

        'ds_Base.Tables.Add("db_Cliente")
        'ds_Base.Tables.Add("db_Empleado")
        'ds_Base.Tables.Add("db_Categoria")
        'ds_Base.Tables.Add("db_Producto")
        'ds_Base.Tables.Add("db_Producto_Partida")
        'ds_Base.Tables.Add("db_Pedido")
        'ds_Base.Tables.Add("db_Pedido_Detalle")

        fCrea_DataTable_Cliente()
        fCrea_DataTable_Empleado()
        dt_Categoria = fCrea_DataTable_Categoria()
        fCrea_DataTable_Producto()
        dt_Producto_Partida = fCrea_DataTable_Producto_Partida()
        fCrea_DataTable_Producto_Partida_Grupo()
        fCrea_DataTable_Producto_Partida_Detalle()

        fCrea_DataTable_Pais()
        fCrea_DataTable_Pais_Estado()
        fCrea_DataTable_Pais_Estado_Ciudad()
        fCrea_DataTable_Pais_Estado_Ciudad_Zona()


        fCrea_DataTable_Tipo_Cliente()
        fCrea_DataTable_Tipo_Cliente_Producto()

        fCrea_DataTable_Menu()

        '=================================================

        fCrea_DataTable_Pedido()
        fCrea_DataTable_Pedido_Detalle()


        dt_Pedido_Reimprime = dt_Pedido
        dt_Pedido_Detalle_Reimprime = dt_Pedido_Detalle

        '=================================================

        fCrea_DataTable_Geocerca()

    End Sub



    '==========================================================================================================




    Public Sub fCrea_DataTable_Cliente()

        dt_Cliente = New DataTable

        dt_Cliente.Columns.Add("id_Cliente", Type.GetType("System.Int32"))
        dt_Cliente.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Nombre_Comercial", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Producto_Kosher", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Servicio_en_Sitio", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Entrega_Domicilio", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Entrega_Ocurre", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Tipo_Cobertura_Entrega_Domicilio", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Distancia_Cobertura", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Pedido_Minimo", Type.GetType("System.Single"))
        dt_Cliente.Columns.Add("Precio_Envio_Domicilio", Type.GetType("System.Single"))
        dt_Cliente.Columns.Add("Porciento_Comision_Envio", Type.GetType("System.Single"))
        dt_Cliente.Columns.Add("Maneja_E2E_Monedero", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_E2E_Puntos", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Promocion_Puntos", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Promocion_Porciento", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Promocion_Importe", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Promocion_Producto", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Monedero", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Maneja_Puntos", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Porciento_Puntos", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Dias_Vigencia_Saldo_Puntos", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Emite_Factura_Fiscal", Type.GetType("System.Boolean"))
        dt_Cliente.Columns.Add("Dias_Factura_Fiscal", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Periodicidad_Envio_GPS", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Pedido_Prefijo", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Pedido_Folio", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Politica_Cancelacion", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Contacto", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Calle", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Exterior", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Interior", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Colonia", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Delegacion", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Localidad", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Entidad", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Cod_Postal", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Tele_1", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Tele_2", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Web", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Latitud", Type.GetType("System.Double"))
        dt_Cliente.Columns.Add("Longitud", Type.GetType("System.Double"))
        dt_Cliente.Columns.Add("id_Pais", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Pais_Nombre", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("id_Estado", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Estado_Nombre", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("id_Ciudad", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Ciudad_Nombre", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("id_Zona", Type.GetType("System.Int16"))
        dt_Cliente.Columns.Add("Horario_Lunes_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Lunes_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Martes_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Martes_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Miercoles_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Miercoles_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Jueves_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Jueves_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Viernes_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Viernes_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Sabado_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Sabado_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Domingo_Ini", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Domingo_Fin", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Correo", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Horario_Lunes_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Lunes_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Martes_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Martes_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Miercoles_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Miercoles_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Jueves_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Jueves_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Viernes_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Viernes_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Sabado_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Sabado_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Domingo_Ini_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Horario_Domingo_Fin_2", Type.GetType("System.DateTime"))
        dt_Cliente.Columns.Add("Status", Type.GetType("System.String"))
        dt_Cliente.Columns.Add("Correo_2", Type.GetType("System.String"))


    End Sub

    Public Sub fCrea_DataTable_Empleado()

        dt_Empleado = New DataTable

        dt_Empleado.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Empleado.Columns.Add("id_Empleado", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Celular", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Autoridad", Type.GetType("System.Int16"))
        dt_Empleado.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Paterno", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Materno", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Password", Type.GetType("System.String"))
        dt_Empleado.Columns.Add("Cambia_Password", Type.GetType("System.Boolean"))

    End Sub

    Public Function fCrea_DataTable_Categoria() As DataTable

        dt_Categoria = New DataTable

        dt_Categoria.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Categoria.Columns.Add("id_Categoria", Type.GetType("System.Int32"))
        dt_Categoria.Columns.Add("Nombre", Type.GetType("System.String"))

        Return dt_Categoria

    End Function

    Public Function fCrea_DataTable_Producto() As DataTable

        dt_Producto = New DataTable

        dt_Producto.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Producto.Columns.Add("id_Producto", Type.GetType("System.String"))
        dt_Producto.Columns.Add("id_Producto_Clase", Type.GetType("System.Int32"))
        dt_Producto.Columns.Add("id_Tipo_Categoria", Type.GetType("System.Int32"))
        dt_Producto.Columns.Add("Calorias", Type.GetType("System.Int32"))
        dt_Producto.Columns.Add("Producto_Dieta", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Producto_Kosher", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Producto_Suspendido", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Producto_Entrega_Domicilio", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Contenido", Type.GetType("System.String"))
        dt_Producto.Columns.Add("id_Unidad_Manejo", Type.GetType("System.Int32"))
        dt_Producto.Columns.Add("Sujeto_IVA", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Por_IVA", Type.GetType("System.Single"))
        dt_Producto.Columns.Add("Precio", Type.GetType("System.Single"))
        dt_Producto.Columns.Add("Precio_Promocion", Type.GetType("System.Single"))
        dt_Producto.Columns.Add("Valor_Puntos", Type.GetType("System.Int32"))
        dt_Producto.Columns.Add("Disponible_Lunes", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Martes", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Miercoles", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Jueves", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Viernes", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Sabado", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Disponible_Domingo", Type.GetType("System.Boolean"))
        dt_Producto.Columns.Add("Imagen", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Lunes_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Lunes_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Martes_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Martes_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Miercoles_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Miercoles_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Jueves_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Jueves_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Viernes_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Viernes_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Sabado_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Sabado_Fin", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Domingo_Ini", Type.GetType("System.String"))
        dt_Producto.Columns.Add("Horario_Domingo_Fin", Type.GetType("System.String"))

        Return dt_Producto

    End Function

    Public Function fCrea_DataTable_Producto_Partida() As DataTable

        Dim dt As DataTable = New DataTable

        dt.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt.Columns.Add("id_Producto", Type.GetType("System.String"))
        dt.Columns.Add("Consecutivo", Type.GetType("System.Int16"))
        dt.Columns.Add("Nivel_Grupo", Type.GetType("System.Int16"))
        dt.Columns.Add("Nivel_Producto", Type.GetType("System.Int16"))
        dt.Columns.Add("Nivel_Componente", Type.GetType("System.Int16"))
        dt.Columns.Add("Nombre", Type.GetType("System.String"))
        dt.Columns.Add("Nivel", Type.GetType("System.Int16"))
        dt.Columns.Add("Maximo_Click", Type.GetType("System.Int16"))
        dt.Columns.Add("Precio_Adicional", Type.GetType("System.Single"))

        Return dt

    End Function



    Public Sub fCrea_DataTable_Producto_Partida_Grupo()

        dt_Producto_Partida_Grupo = New DataTable

        dt_Producto_Partida_Grupo.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Producto_Partida_Grupo.Columns.Add("id_Producto", Type.GetType("System.String"))
        dt_Producto_Partida_Grupo.Columns.Add("Consecutivo", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Nivel_Grupo", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Nivel_Producto", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Nivel_Componente", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Producto_Partida_Grupo.Columns.Add("Nivel", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Maximo_Click", Type.GetType("System.Int16"))
        dt_Producto_Partida_Grupo.Columns.Add("Precio_Adicional", Type.GetType("System.Single"))

    End Sub

    Public Sub fCrea_DataTable_Producto_Partida_Detalle()

        dt_Producto_Partida_Detalle = New DataTable

        dt_Producto_Partida_Detalle.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Producto_Partida_Detalle.Columns.Add("id_Producto", Type.GetType("System.String"))
        dt_Producto_Partida_Detalle.Columns.Add("Consecutivo", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Nivel_Grupo", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Nivel_Producto", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Nivel_Componente", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Producto_Partida_Detalle.Columns.Add("Nivel", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Maximo_Click", Type.GetType("System.Int16"))
        dt_Producto_Partida_Detalle.Columns.Add("Precio_Adicional", Type.GetType("System.Single"))

    End Sub



    Public Function fCrea_DataTable_Tipo_Cliente() As DataTable

        Dim dt_Tipo_Cliente As New DataTable

        dt_Tipo_Cliente.Columns.Add("id_Tipo_Cliente", Type.GetType("System.Int16"))
        dt_Tipo_Cliente.Columns.Add("Nombre", Type.GetType("System.String"))

        Return dt_Tipo_Cliente

    End Function

    Public Function fCrea_DataTable_Tipo_Cliente_Producto() As DataTable

        dt_Tipo_Cliente_Producto = New DataTable

        dt_Tipo_Cliente_Producto.Columns.Add("id_Tipo_Cliente", Type.GetType("System.Int16"))
        dt_Tipo_Cliente_Producto.Columns.Add("Nombre", Type.GetType("System.String"))

        Return dt_Tipo_Cliente_Producto

    End Function


    Public Sub fCrea_DataTable_Menu()

        dt_Menu = New DataTable

        dt_Menu.Columns.Add("id_Cliente", Type.GetType("System.Int32"))
        dt_Menu.Columns.Add("Autoridad", Type.GetType("System.Int16"))
        dt_Menu.Columns.Add("Menu_01", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_02", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_03", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_04", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_05", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_06", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_07", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_08", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_09", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_10", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_11", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_12", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_13", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_14", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_15", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_16", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_17", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_18", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_19", Type.GetType("System.Boolean"))
        dt_Menu.Columns.Add("Menu_20", Type.GetType("System.Boolean"))

    End Sub



    Public Sub fCrea_DataTable_Pedido()

        dt_Pedido = New DataTable

        dt_Pedido.Columns.Add("Folio_Internet", Type.GetType("System.Int64"))
        dt_Pedido.Columns.Add("id_Cliente", Type.GetType("System.Int64"))
        dt_Pedido.Columns.Add("Pedido_Prefijo", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Pedido_Folio", Type.GetType("System.Int32"))
        dt_Pedido.Columns.Add("Status", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Tipo_Pedido", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("id_Usuario", Type.GetType("System.Int32"))
        dt_Pedido.Columns.Add("Tipo_Pago", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Folio_Aceptacion_Pago", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Pedido_Pagado", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Factura_Fiscal", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Pedido_Turno", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Pedido_Dia", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Tipo_Entrega", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Fecha_Pedido", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Fecha_Entrega", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Recibido", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Fecha_Recepcion", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cerrado", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Usuario_Clave_Pedido_Cerrado", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cerrado_Fecha", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cerrado_Comentario", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cancelado", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cancelado_Fecha", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Usuario_Pedido_Cancelado_Motivo", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("IVA", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Total", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("E2E_Puntos_Pedido", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Cliente_Puntos_Pedido", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Promo_Puntos_Cupon", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Promo_Puntos_Puntos", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Promo_Puntos_Puntos_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Promo_Porciento_Cupon", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Promo_Porciento_Factor", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Promo_Porciento_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Promo_Importe_Cupon", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Promo_Importe_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Promo_Produ_Cupon", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Promo_Produ_Clave", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Cliente_Puntos_Cant", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Cliente_Puntos_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Cliente_Monedero_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("E2E_Puntos_Cant", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("E2E_Puntos_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("E2E_Monedero_I", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Pago_Propina", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Pago_Importe_Total", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Cambio", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Comentario_Calificacion", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Comentario_Observaciones", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Requiere_Factura", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("Factura_RFC", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Ruta_Generada", Type.GetType("System.Boolean"))
        dt_Pedido.Columns.Add("id_Ruta", Type.GetType("System.Int16"))
        dt_Pedido.Columns.Add("Ruta_Fecha", Type.GetType("System.DateTime"))
        dt_Pedido.Columns.Add("Ruta_Usuario", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("id_Domicilio_Entrega", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Calle", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Exterior", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Interior", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Colonia", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Delegacion", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Localidad", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Entidad", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Cod_Postal", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Tele", Type.GetType("System.String"))
        dt_Pedido.Columns.Add("Latitud", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Longitud", Type.GetType("System.Single"))
        dt_Pedido.Columns.Add("Ya_Reportado", Type.GetType("System.Boolean"))

    End Sub

    Public Sub fCrea_DataTable_Pedido_Detalle()

        dt_Pedido_Detalle = New DataTable

        dt_Pedido_Detalle.Columns.Add("Folio_Internet", Type.GetType("System.Int64"))
        dt_Pedido_Detalle.Columns.Add("Consecutivo", Type.GetType("System.Int16"))
        dt_Pedido_Detalle.Columns.Add("id_Producto", Type.GetType("System.String"))
        dt_Pedido_Detalle.Columns.Add("Nombre", Type.GetType("System.String"))
        dt_Pedido_Detalle.Columns.Add("Cantidad", Type.GetType("System.Int16"))
        dt_Pedido_Detalle.Columns.Add("Precio", Type.GetType("System.Single"))
        dt_Pedido_Detalle.Columns.Add("Adicion", Type.GetType("System.String"))
        dt_Pedido_Detalle.Columns.Add("id_Categoria", Type.GetType("System.Int16"))
        dt_Pedido_Detalle.Columns.Add("Nombre_Categoria", Type.GetType("System.String"))

    End Sub

    Public Function fCrea_DataTable_Geocerca() As DataTable
        Dim dt As DataTable = New DataTable

        dt.Columns.Add("Consecutivo", Type.GetType("System.Int16"))
        dt.Columns.Add("Latitud", Type.GetType("System.Single"))
        dt.Columns.Add("Longitud", Type.GetType("System.Single"))

        Return dt

    End Function


    Public Function fCrea_DataTable_Pais() As DataTable

        dt_Pais = New DataTable

        dt_Pais.Columns.Add("id_Pais", Type.GetType("System.Int16"))
        dt_Pais.Columns.Add("Nombre_Pais", Type.GetType("System.String"))

        Return dt_Pais

    End Function

    Public Function fCrea_DataTable_Pais_Estado() As DataTable

        dt_Pais_Estado = New DataTable

        dt_Pais_Estado.Columns.Add("Nombre_Pais", Type.GetType("System.String"))
        dt_Pais_Estado.Columns.Add("Nombre_Estado", Type.GetType("System.String"))
        dt_Pais_Estado.Columns.Add("id_Pais", Type.GetType("System.Int16"))
        dt_Pais_Estado.Columns.Add("id_Estado", Type.GetType("System.Int16"))

        Return dt_Pais_Estado

    End Function


    Public Function fCrea_DataTable_Pais_Estado_Ciudad() As DataTable

        dt_Pais_Estado_Ciudad = New DataTable

        dt_Pais_Estado_Ciudad.Columns.Add("Nombre_Pais", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad.Columns.Add("Nombre_Estado", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad.Columns.Add("Nombre_Ciudad", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad.Columns.Add("id_Pais", Type.GetType("System.Int16"))
        dt_Pais_Estado_Ciudad.Columns.Add("id_Estado", Type.GetType("System.Int16"))
        dt_Pais_Estado_Ciudad.Columns.Add("id_Ciudad", Type.GetType("System.Int16"))

        Return dt_Pais_Estado_Ciudad

    End Function

    Public Function fCrea_DataTable_Pais_Estado_Ciudad_Zona() As DataTable

        dt_Pais_Estado_Ciudad_Zona = New DataTable

        dt_Pais_Estado_Ciudad_Zona.Columns.Add("Nombre_Pais", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("Nombre_Estado", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("Nombre_Ciudad", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("Nombre_Zona", Type.GetType("System.String"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("id_Pais", Type.GetType("System.Int16"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("id_Estado", Type.GetType("System.Int16"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("id_Ciudad", Type.GetType("System.Int16"))
        dt_Pais_Estado_Ciudad_Zona.Columns.Add("id_Zona", Type.GetType("System.Int16"))

        Return dt_Pais_Estado_Ciudad_Zona

    End Function


    '======================================       Funciones



    Public Function fDesempaca_String_Cliente(ByVal ws_cStr As String,
                                     Optional ByVal lAdiciona_DataTable As Boolean = True) As Boolean

        '        2062|" & glo_cToken & "|55  
        '
        '
        ' OK|0408|*«»*
        '   55|Kleins|Kleins Bosques|1|1|1|1|2|0|0|0|0|0|0|0|0|0|0|0|0|0|60|1|30|0||0|0|||||||||||||0|0|117|México|9|Distrito Federal|1|Lomas de Vista Hermo|0|07:30|20:45|08:30|21:45|08:30|21:45|08:30|21:45|08:30|21:45|08:30|21:45|08:30|21:45|aaa@bbb.com

        If lAdiciona_DataTable = True Then
            fAdiciona_DataTable_Cliente(ws_cStr, 0)
        End If

        Dim aE() As String

        aE = Split(ws_cStr, "|")

        Cli.id_Cliente = Convert.ToInt64(aE(0))
        Cli.cNombre = Trim(aE(1))
        Cli.cNombre_Comercial = Trim(aE(2))
        Cli.bProducto_Kosher = IIf(aE(3) = "1", True, False)
        Cli.bServicio_en_Sitio = IIf(aE(4) = "1", True, False)
        Cli.bEntrega_Domicilio = IIf(aE(5) = "1", True, False)
        Cli.bEntrega_Ocurre = IIf(aE(6) = "1", True, False)
        Cli.nTipo_Cobertura_Entrega_Domicilio = Convert.ToInt16(aE(7))
        Cli.nDistancia_Cobertura = Convert.ToInt32(aE(8))
        Cli.nPedido_Minimo = Convert.ToDecimal(aE(9))
        Cli.nPrecio_Envio_Domicilio = Convert.ToDecimal(aE(10))
        Cli.nPorciento_Comision_Envio = Convert.ToDecimal(aE(11))
        Cli.bManeja_E2E_Monedero = IIf(aE(12) = "1", True, False)
        Cli.bManeja_E2E_Puntos = IIf(aE(13) = "1", True, False)
        Cli.bManeja_Promocion_Puntos = IIf(aE(14) = "1", True, False)
        Cli.bManeja_Promocion_Porciento = IIf(aE(15) = "1", True, False)
        Cli.bManeja_Promocion_Importe = IIf(aE(16) = "1", True, False)
        Cli.bManeja_Promocion_Producto = IIf(aE(17) = "1", True, False)
        Cli.bManeja_Monedero = IIf(aE(18) = "1", True, False)
        Cli.bManeja_Puntos = IIf(aE(19) = "1", True, False)
        Cli.nPorciento_Puntos = Convert.ToDecimal(aE(20))
        Cli.nDias_Vigencia_Saldo_Puntos = Convert.ToInt16(aE(21))
        Cli.bEmite_Factura_Fiscal = IIf(aE(22) = "1", True, False)
        Cli.nDias_Factura_Fiscal = Convert.ToInt16(aE(23))
        Cli.nPeriodicidad_Envio_GPS = Convert.ToInt16(aE(24))
        Cli.cPedido_Prefijo = Trim(aE(25))
        Cli.nPedido_Folio = Convert.ToInt16(aE(26))
        Cli.nPolitica_Cancelacion = Convert.ToInt16(aE(27))
        Cli.cContacto = Trim(aE(28))
        Cli.cCalle = Trim(aE(29))
        Cli.cExterior = Trim(aE(30))
        Cli.cInterior = Trim(aE(31))
        Cli.cColonia = Trim(aE(32))
        Cli.cDelegacion = Trim(aE(33))
        Cli.cLocalidad = Trim(aE(34))
        Cli.cEntidad = Trim(aE(35))
        Cli.cCod_Postal = Trim(aE(36))
        Cli.cTele_1 = Trim(aE(37))
        Cli.cTele_2 = Trim(aE(38))
        Cli.cWeb = Trim(aE(39))
        Cli.nLatitud = Convert.ToDecimal(aE(40))
        Cli.nLongitud = Convert.ToDecimal(aE(41))
        Cli.id_Pais = Convert.ToInt16(aE(42))
        Cli.cPais_Nombre = Trim(aE(43))
        Cli.id_Estado = Convert.ToInt16(aE(44))
        Cli.cEstado_Nombre = Trim(aE(45))
        Cli.id_Ciudad = Convert.ToInt16(aE(46))
        Cli.cCiudad_Nombre = Trim(aE(47))
        Cli.id_Zona = Convert.ToInt16(aE(48))
        Cli.cHorario_Lunes_Ini = Convert.ToDateTime(aE(49))
        Cli.cHorario_Lunes_Fin = Convert.ToDateTime(aE(50))
        Cli.cHorario_Martes_Ini = Convert.ToDateTime(aE(51))
        Cli.cHorario_Martes_Fin = Convert.ToDateTime(aE(52))
        Cli.cHorario_Miercoles_Ini = Convert.ToDateTime(aE(53))
        Cli.cHorario_Miercoles_Fin = Convert.ToDateTime(aE(54))
        Cli.cHorario_Jueves_Ini = Convert.ToDateTime(aE(55))
        Cli.cHorario_Jueves_Fin = Convert.ToDateTime(aE(56))
        Cli.cHorario_Viernes_Ini = Convert.ToDateTime(aE(57))
        Cli.cHorario_Viernes_Fin = Convert.ToDateTime(aE(58))
        Cli.cHorario_Sabado_Ini = Convert.ToDateTime(aE(59))
        Cli.cHorario_Sabado_Fin = Convert.ToDateTime(aE(60))
        Cli.cHorario_Domingo_Ini = Convert.ToDateTime(aE(61))
        Cli.cHorario_Domingo_Fin = Convert.ToDateTime(aE(62))
        Cli.cCorreo = Convert.ToString(aE(63))
        Cli.cHorario_Lunes_Ini_2 = Convert.ToDateTime(aE(64))
        Cli.cHorario_Lunes_Fin_2 = Convert.ToDateTime(aE(65))
        Cli.cHorario_Martes_Ini_2 = Convert.ToDateTime(aE(66))
        Cli.cHorario_Martes_Fin_2 = Convert.ToDateTime(aE(67))
        Cli.cHorario_Miercoles_Ini_2 = Convert.ToDateTime(aE(68))
        Cli.cHorario_Miercoles_Fin_2 = Convert.ToDateTime(aE(69))
        Cli.cHorario_Jueves_Ini_2 = Convert.ToDateTime(aE(70))
        Cli.cHorario_Jueves_Fin_2 = Convert.ToDateTime(aE(71))
        Cli.cHorario_Viernes_Ini_2 = Convert.ToDateTime(aE(72))
        Cli.cHorario_Viernes_Fin_2 = Convert.ToDateTime(aE(73))
        Cli.cHorario_Sabado_Ini_2 = Convert.ToDateTime(aE(74))
        Cli.cHorario_Sabado_Fin_2 = Convert.ToDateTime(aE(75))
        Cli.cHorario_Domingo_Ini_2 = Convert.ToDateTime(aE(76))
        Cli.cHorario_Domingo_Fin_2 = Convert.ToDateTime(aE(77))
        Cli.cStatus = Trim(aE(78))
        Cli.cCorreo_2 = Trim(aE(79))
        Return True

    End Function

    Public Function fDesempaca_String_Empleado(ByVal ws_cStr As String) As Boolean
        '        104|" & glo_cToken & "|123|qq|55|1
        '
        ' OK|0408|*«»*
        '55|123|11-22-33-44|2|Antonio|De Prueba|Test|qq|false«**»
        '55|Kleins|Kleins Bosques|1|1|1|1|2|0|0.00|0.00|0.00|0|0|0|0|0|0|0|0|0|60|1|30|0||0|0|||||||||||||0.00000000|0.00000000|0||0||0||0|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|00:00:00|

        If ws_cStr.Trim = "" Then
            Return True
        End If


        Dim aE() As String


        fAdiciona_DataTable_Empleado(ws_cStr)


        aE = Split(ws_cStr, "|")

        Emp.id_Cliente = Convert.ToString(aE(0))
        Emp.id_Empleado = Convert.ToString(aE(1))
        Emp.cCelular = Convert.ToString(aE(2))
        Emp.nAutoridad = Convert.ToInt16(aE(3))
        Emp.cNombre = Convert.ToString(aE(4))
        Emp.cPaterno = Convert.ToString(aE(5))
        Emp.cMaterno = Convert.ToString(aE(6))
        Emp.cPassword = Convert.ToString(aE(7))
        Emp.bCambia_Password = fConvierte_a_Boleano(aE(8))

        Return True

    End Function

    Public Function fDesempaca_String_Categoria(ByVal ws_cStr As String) As Boolean

        '       55|2|Hot Cakes y Cereales.««
        '       55|4|Frutas.««
        '       55|6|Nuestros huevos clásicos.««
        '       55|8|Huevos y Omelettes.««
        '       55|10|Los Clásicos de la mañana.

        Dim aE() As String
        Dim am() As String

        Dim nReg As Integer
        Dim nI As Integer


        fAdiciona_DataTable_Categoria(ws_cStr)


        aE = Split(ws_cStr, "««")
        nReg = aE.Length

        ReDim Cat_cli(nReg)
        For nI = 0 To nReg - 1

            am = Split(aE(nI), "|")

            Cat_cli(nI).id_Cliente = Convert.ToInt32(am(0))
            Cat_cli(nI).id_Categoria = RTrim(am(1))
            Cat_cli(nI).cNombre = Trim(am(2))

        Next

        Return True

    End Function

    Public Function fDesempaca_String_Producto(ByVal ws_cStr As String) As Boolean
        '
        '   2066|" & glo_cToken & "|<Cliente>
        '
        '           55|p55_0020|0|2|0|0|0|0|0|Hot Cakes Dollar||0|0|0|47|0|0|0|0|0|0|0|0|0««
        '           55|p55_0022|0|2|0|0|0|0|0|Waffles con mantequilla||0|0|0|53|0|0|0|0|0|0|0|0|0««
        '           55|p55_0023|0|2|0|0|0|0|0|Waffles "Robby" con plátano||0|0|0|99|0|0|0|0|0|0|0|0|0

        Dim aE() As String
        Dim am() As String

        Dim nReg As Integer
        Dim nI As Integer


        fAdiciona_DataTable_Producto(ws_cStr, "")


        aE = Split(ws_cStr, "««")
        nReg = aE.Length

        ReDim Pro_cli(nReg)

        For nI = 0 To nReg - 1

            am = Split(aE(nI), "|")

            Pro_cli(nI).id_Cliente = Convert.ToInt32(am(0))
            Pro_cli(nI).id_Producto = RTrim(am(1))
            Pro_cli(nI).id_Producto_Clase = Convert.ToInt16(am(2))
            Pro_cli(nI).id_Tipo_Categoria = Convert.ToInt16(am(3))
            Pro_cli(nI).nCalorias = Convert.ToInt16(am(4))
            Pro_cli(nI).bProducto_Dieta = fConvierte_a_Boleano(am(5))
            Pro_cli(nI).bProducto_Kosher = fConvierte_a_Boleano(am(6))
            Pro_cli(nI).bProducto_Suspendido = fConvierte_a_Boleano(am(7))
            Pro_cli(nI).bProducto_Entrega_Domicilio = fConvierte_a_Boleano(am(8))
            Pro_cli(nI).cNombre = Trim(am(9))
            Pro_cli(nI).cContenido = Trim(am(10))
            Pro_cli(nI).id_Unidad_Manejo = Convert.ToInt16(am(11))
            Pro_cli(nI).bSujeto_IVA = fConvierte_a_Boleano(am(12))
            Pro_cli(nI).nPor_IVA = Convert.ToDecimal(am(13))
            Pro_cli(nI).nPrecio = Convert.ToDecimal(am(14))
            Pro_cli(nI).nPrecio_Promocion = Convert.ToDecimal(am(15))
            Pro_cli(nI).nValor_Puntos = Convert.ToInt16(am(16))
            Pro_cli(nI).bDisponible_Lunes = fConvierte_a_Boleano(am(17))
            Pro_cli(nI).bDisponible_Martes = fConvierte_a_Boleano(am(18))
            Pro_cli(nI).bDisponible_Miercoles = fConvierte_a_Boleano(am(19))
            Pro_cli(nI).bDisponible_Jueves = fConvierte_a_Boleano(am(20))
            Pro_cli(nI).bDisponible_Viernes = fConvierte_a_Boleano(am(21))
            Pro_cli(nI).bDisponible_Sabado = fConvierte_a_Boleano(am(22))
            Pro_cli(nI).bDisponible_Domingo = fConvierte_a_Boleano(am(23))
            Pro_cli(nI).cImagen = Trim(am(24))
            Pro_cli(nI).cHorario_Lunes_Ini = aE(25)
            Pro_cli(nI).cHorario_Lunes_Fin = aE(26)
            Pro_cli(nI).cHorario_Martes_Ini = aE(27)
            Pro_cli(nI).cHorario_Martes_Fin = aE(28)
            Pro_cli(nI).cHorario_Miercoles_Ini = aE(29)
            Pro_cli(nI).cHorario_Miercoles_Fin = aE(30)
            Pro_cli(nI).cHorario_Jueves_Ini = aE(31)
            Pro_cli(nI).cHorario_Jueves_Fin = aE(32)
            Pro_cli(nI).cHorario_Viernes_Ini = aE(33)
            Pro_cli(nI).cHorario_Viernes_Fin = aE(34)
            Pro_cli(nI).cHorario_Sabado_Ini = aE(35)
            Pro_cli(nI).cHorario_Sabado_Fin = aE(36)
            Pro_cli(nI).cHorario_Domingo_Ini = aE(37)
            Pro_cli(nI).cHorario_Domingo_Fin = aE(38)

        Next

        Return True

    End Function

    Public Function fDesempaca_String_Pedido(ByVal ws_cStr As String,
                                    Optional ByVal ws_Reimprime As Boolean = False) As Boolean


        '           OK|0862|Proceso OK|3|85«R»
        '
        '           1|12||75|OK|1|1574|1|0|0|2|6||0|2016-05-13 16:12:00|1900-01-01 00:00:00|0|1900-01-01 00:00:00|0|0|1900-01-01 00:00:00||0|
        '                                                   1900-01-01 00:00:00||0.00|160.00|16|0||0|0.00||0.00|0.00||0.00|||0|0.00|0.00|0|0.00|0.00|0.00|160.00|40.00|0||0|
        '                                                   Sin Factura|0|0|1900-01-01 00:00:00|||||||||||||0.00000000|0.00000000|0«*»
        '                       1|p_12001||40.000|4.00|«R»
        '
        '           2|12||76|OK|1|1574|1|0|0|2|6||0|2016-05-13 16:16:00|1900-01-01 00:00:00|0|1900-01-01 00:00:00|0|0|1900-01-01 00:00:00||0|
        '                                                   1900-01-01 00:00:00||0.00|300.00|30|0||0|0.00||0.00|0.00||0.00|||0|0.00|0.00|0|0.00|0.00|0.00|300.00|0.00|0||0|
        '                                                   Sin Factura|0|0|1900-01-01 00:00:00|||||||||||||0.00000000|0.00000000|0«*»
        '                       1|p_12004||60.000|5.00|«R»
        '
        '           5|12||77|OK|3|1574|0|0|0|2|6||0|2016-05-13 16:41:00|1900-01-01 00:00:00|0|1900-01-01 00:00:00|0|0|1900-01-01 00:00:00||0|
        '                                                   1900-01-01 00:00:00||0.00|1440.00|144|0||0|0.00||0.00|0.00||0.00|||0|0.00|0.00|0|0.00|0.00|0.00|1440.00|0.00|111||0|
        '                                                   Sin Factura|0|0|1900-01-01 00:00:00|||||||||||||0.00000000|0.00000000|0«*»
        '                       1|p_12002||45.000|32.00|    dt_Pedidos_Detalle.NewRow

        Dim ae() As String = Nothing
        Dim am() As String
        Dim ax() As String

        Dim aRegistros() As String

        Dim nFolio As Long = 0
        Dim nReg As Integer
        Dim nReg_Anterior As Integer = glo_nRegistro_Anterior

        Dim cHeader As String
        Dim cEnca As String
        Dim cDeta As String
        Dim cVar As String = ""




        '
        '       NOTA:       el separador «R» diferencia del encabezado y el resto de los registros
        '                   El separador «*»  diferencia el encabezado del pedido y el detalle del pedido
        '

        aRegistros = Split(ws_cStr, "«R»")

        cHeader = aRegistros(0)

        nReg = aRegistros.Length - 1        '       Menos 1 por el encabezado


        For nI As Integer = 1 To aRegistros.Length - 1

            ax = Split(aRegistros(nI), "«*»")

            cEnca = ax(0)
            cDeta = ""
            '
            '   NOTA: Porque así está el Store procedure, se concatenan los elementos de ax  para que se complete el detalle
            '
            For nII As Integer = 1 To ax.Length - 1
                cDeta += ax(nII)
                cDeta += "«*»"
            Next
            cDeta = Mid(cDeta, 1, Len(cDeta) - 3)

            am = Split(cEnca, "|")

            'Ped_Cli(nReg_Anterior + nReg).nFolio_Internet = Convert.ToInt64(am(0))
            nFolio = Convert.ToInt64(am(0))

            If fBusca_Folio(nFolio) = False Then

                glo_Ultimo_Folio_Pedido = Convert.ToInt64(am(0))
                '
                '       Adiciona el pedido a una estructura y una DataTable tanto de pedido como detalle
                '       NOTA: El DataTable de Pedido y Pedido_Detalle, se toman de la variable publica definida en uGeneral
                '
                fAdiciona_DataTable_Pedido(cEnca, glo_Ultimo_Folio_Pedido, ws_Reimprime)
                fAdiciona_DataTable_Pedido_Detalle(cDeta, glo_Ultimo_Folio_Pedido, ws_Reimprime)

                nReg += 1

            End If

            'fAdiciona_Pedido(glo_Ultimo_Folio_Pedido, cEnca, cDeta)

        Next

        glo_nRegistro_Anterior = nReg

        Return True

    End Function

    Public Function fDesempaca_String_Pais_Estado_Ciudad_Zona(ByVal ws_cStr As String) As Boolean

        '       55|2|Hot Cakes y Cereales.««
        '       55|4|Frutas.««
        '       55|6|Nuestros huevos clásicos.««
        '       55|8|Huevos y Omelettes.««
        '       55|10|Los Clásicos de la mañana.

        Dim aE() As String
        Dim am() As String

        Dim nReg As Integer
        Dim nI As Integer


        fAdiciona_DataTable_Categoria(ws_cStr)


        aE = Split(ws_cStr, "««")
        nReg = aE.Length

        ReDim Cat_cli(nReg)
        For nI = 0 To nReg - 1

            am = Split(aE(nI), "|")

            Cat_cli(nI).id_Cliente = Convert.ToInt32(am(0))
            Cat_cli(nI).id_Categoria = RTrim(am(1))
            Cat_cli(nI).cNombre = Trim(am(2))

        Next

        Return True

    End Function

    Public Function fDesempaca_y_Adiciona_DataTable_Geocerca(ByVal cVar As String) As Boolean

        Dim ae() As String

        dt_Geocerca = New DataTable
        dt_Geocerca = fCrea_DataTable_Geocerca()

        Try
            ae = Split(cVar, "««")
            For nI As Integer = 0 To ae.Length - 1

            Next
        Catch ex As Exception

        End Try

        Return True

    End Function



    Public Sub fInicializa_Pedido()

        glo_nRegistro_Anterior = 0
        glo_Ultimo_Folio_Pedido = 0

    End Sub


    Function fDataTable_Filtra_Ordena(ByVal dt As DataTable,
                             Optional ByVal filter As String = "",
                             Optional ByVal sort As String = "") As DataTable

        Dim rows As DataRow()
        Dim dtNew As New DataTable

        dtNew = dt.Clone

        filter = filter.Trim
        rows = dt.Select(filter, sort)

        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        Return dtNew

    End Function


    '   ============================   Rutinas de adicion al DataTable


    Public Sub fAdiciona_DataTable_Cliente(ByVal cVari As String,
                                           ByRef nCliente As Long)

        Dim am() As String = Split(cVari, "|")
        Dim dr_Cli As DataRow

        dr_Cli = dt_Cliente.NewRow

        nCliente = Convert.ToInt32(am(0))

        dr_Cli.Item("id_Cliente") = Convert.ToInt32(am(0))
        dr_Cli.Item("Nombre") = Convert.ToString(am(1))
        dr_Cli.Item("Nombre_Comercial") = Convert.ToString(am(2))
        dr_Cli.Item("Producto_Kosher") = fConvierte_a_Boleano(am(3))
        dr_Cli.Item("Servicio_en_Sitio") = fConvierte_a_Boleano(am(4))
        dr_Cli.Item("Entrega_Domicilio") = fConvierte_a_Boleano(am(5))
        dr_Cli.Item("Entrega_Ocurre") = fConvierte_a_Boleano(am(6))
        dr_Cli.Item("Tipo_Cobertura_Entrega_Domicilio") = Convert.ToInt16(am(7))
        dr_Cli.Item("Distancia_Cobertura") = Convert.ToInt16(am(8))
        dr_Cli.Item("Pedido_Minimo") = Convert.ToSingle(am(9))
        dr_Cli.Item("Precio_Envio_Domicilio") = Convert.ToSingle(am(10))
        dr_Cli.Item("Porciento_Comision_Envio") = Convert.ToSingle(am(11))
        dr_Cli.Item("Maneja_E2E_Monedero") = Me.fConvierte_a_Boleano(am(12))
        dr_Cli.Item("Maneja_E2E_Puntos") = Me.fConvierte_a_Boleano(am(13))
        dr_Cli.Item("Maneja_Promocion_Puntos") = Me.fConvierte_a_Boleano(am(14))
        dr_Cli.Item("Maneja_Promocion_Porciento") = Me.fConvierte_a_Boleano(am(15))
        dr_Cli.Item("Maneja_Promocion_Importe") = Me.fConvierte_a_Boleano(am(16))
        dr_Cli.Item("Maneja_Promocion_Producto") = Me.fConvierte_a_Boleano(am(17))
        dr_Cli.Item("Maneja_Monedero") = Me.fConvierte_a_Boleano(am(18))
        dr_Cli.Item("Maneja_Puntos") = Me.fConvierte_a_Boleano(am(19))
        dr_Cli.Item("Porciento_Puntos") = Convert.ToSingle(am(20))
        dr_Cli.Item("Dias_Vigencia_Saldo_Puntos") = Convert.ToInt16(am(21))
        dr_Cli.Item("Emite_Factura_Fiscal") = Me.fConvierte_a_Boleano(am(22))
        dr_Cli.Item("Dias_Factura_Fiscal") = Convert.ToInt16(am(23))
        dr_Cli.Item("Periodicidad_Envio_GPS") = Convert.ToInt16(am(24))
        dr_Cli.Item("Pedido_Prefijo") = Convert.ToString(am(25))
        dr_Cli.Item("Pedido_Folio") = Convert.ToInt16(am(26))
        dr_Cli.Item("Politica_Cancelacion") = Convert.ToInt16(am(27))
        dr_Cli.Item("Contacto") = Convert.ToString(am(28))
        dr_Cli.Item("Calle") = Convert.ToString(am(29))
        dr_Cli.Item("Exterior") = Convert.ToString(am(30))
        dr_Cli.Item("Interior") = Convert.ToString(am(31))
        dr_Cli.Item("Colonia") = Convert.ToString(am(32))
        dr_Cli.Item("Delegacion") = Convert.ToString(am(33))
        dr_Cli.Item("Localidad") = Convert.ToString(am(34))
        dr_Cli.Item("Entidad") = Convert.ToString(am(35))
        dr_Cli.Item("Cod_Postal") = Convert.ToString(am(36))
        dr_Cli.Item("Tele_1") = Convert.ToString(am(37))
        dr_Cli.Item("Tele_2") = Convert.ToString(am(38))
        dr_Cli.Item("Web") = Convert.ToString(am(39))
        dr_Cli.Item("Latitud") = Convert.ToDouble(am(40))
        dr_Cli.Item("Longitud") = Convert.ToDouble(am(41))
        dr_Cli.Item("id_Pais") = Convert.ToInt16(am(42))
        dr_Cli.Item("Pais_Nombre") = Convert.ToString(am(43))
        dr_Cli.Item("id_Estado") = Convert.ToInt16(am(44))
        dr_Cli.Item("Estado_Nombre") = Convert.ToString(am(45))
        dr_Cli.Item("id_Ciudad") = Convert.ToInt16(am(46))
        dr_Cli.Item("Ciudad_Nombre") = Convert.ToString(am(47))
        dr_Cli.Item("id_Zona") = Convert.ToInt16(am(48))
        dr_Cli.Item("Horario_Lunes_Ini") = Convert.ToDateTime(am(49))
        dr_Cli.Item("Horario_Lunes_Fin") = Convert.ToDateTime(am(50))
        dr_Cli.Item("Horario_Martes_Ini") = Convert.ToDateTime(am(51))
        dr_Cli.Item("Horario_Martes_Fin") = Convert.ToDateTime(am(52))
        dr_Cli.Item("Horario_Miercoles_Ini") = Convert.ToDateTime(am(53))
        dr_Cli.Item("Horario_Miercoles_Fin") = Convert.ToDateTime(am(54))
        dr_Cli.Item("Horario_Jueves_Ini") = Convert.ToDateTime(am(55))
        dr_Cli.Item("Horario_Jueves_Fin") = Convert.ToDateTime(am(56))
        dr_Cli.Item("Horario_Viernes_Ini") = Convert.ToDateTime(am(57))
        dr_Cli.Item("Horario_Viernes_Fin") = Convert.ToDateTime(am(58))
        dr_Cli.Item("Horario_Sabado_Ini") = Convert.ToDateTime(am(59))
        dr_Cli.Item("Horario_Sabado_Fin") = Convert.ToDateTime(am(60))
        dr_Cli.Item("Horario_Domingo_Ini") = Convert.ToDateTime(am(61))
        dr_Cli.Item("Horario_Domingo_Fin") = Convert.ToDateTime(am(62))
        dr_Cli.Item("Correo") = Convert.ToString(am(63))
        dr_Cli.Item("Horario_Lunes_Ini_2") = Convert.ToDateTime(am(64))
        dr_Cli.Item("Horario_Lunes_Fin_2") = Convert.ToDateTime(am(65))
        dr_Cli.Item("Horario_Martes_Ini_2") = Convert.ToDateTime(am(66))
        dr_Cli.Item("Horario_Martes_Fin_2") = Convert.ToDateTime(am(67))
        dr_Cli.Item("Horario_Miercoles_Ini_2") = Convert.ToDateTime(am(68))
        dr_Cli.Item("Horario_Miercoles_Fin_2") = Convert.ToDateTime(am(69))
        dr_Cli.Item("Horario_Jueves_Ini_2") = Convert.ToDateTime(am(70))
        dr_Cli.Item("Horario_Jueves_Fin_2") = Convert.ToDateTime(am(71))
        dr_Cli.Item("Horario_Viernes_Ini_2") = Convert.ToDateTime(am(72))
        dr_Cli.Item("Horario_Viernes_Fin_2") = Convert.ToDateTime(am(73))
        dr_Cli.Item("Horario_Sabado_Ini_2") = Convert.ToDateTime(am(74))
        dr_Cli.Item("Horario_Sabado_Fin_2") = Convert.ToDateTime(am(75))
        dr_Cli.Item("Horario_Domingo_Ini_2") = Convert.ToDateTime(am(76))
        dr_Cli.Item("Horario_Domingo_Fin_2") = Convert.ToDateTime(am(77))
        dr_Cli.Item("Status") = Trim(am(78))
        dr_Cli.Item("Correo_2") = Convert.ToString(am(79))

        dt_Cliente.Rows.Add(dr_Cli)

    End Sub

    Public Sub fAdiciona_DataTable_Empleado(ByVal cVari As String)


        If cVari.Trim = "" Then
            Return
        End If

        Dim am() As String = Split(cVari, "|")
        Dim dr_Emp As DataRow

        dr_Emp = dt_Empleado.NewRow

        dr_Emp.Item("id_Cliente") = Convert.ToInt64(am(0))
        dr_Emp.Item("id_Empleado") = Convert.ToInt32(am(1))
        dr_Emp.Item("Celular") = Convert.ToString(am(2))
        dr_Emp.Item("Autoridad") = Convert.ToInt16(am(3))
        dr_Emp.Item("Nombre") = Convert.ToString(am(4))
        dr_Emp.Item("Paterno") = Convert.ToString(am(5))
        dr_Emp.Item("Materno") = Convert.ToString(am(6))
        dr_Emp.Item("Password") = Convert.ToString(am(7))
        dr_Emp.Item("Cambia_Password") = fConvierte_a_Boleano(am(8))

        dt_Empleado.Rows.Add(dr_Emp)

    End Sub

    Public Sub fAdiciona_DataTable_Categoria(ByVal cVari As String,
                                    Optional ByRef nCategoria As Integer = 0)

        Dim am() As String = Split(cVari, "|")
        Dim dr_Cat As DataRow

        dr_Cat = dt_Categoria.NewRow

        nCategoria = Val(am(1))

        dr_Cat.Item("id_Cliente") = Convert.ToInt64(am(0))
        dr_Cat.Item("id_Categoria") = Convert.ToInt16(am(1))
        dr_Cat.Item("Nombre") = Convert.ToString(am(2))

        dt_Categoria.Rows.Add(dr_Cat)

    End Sub

    Public Sub fAdiciona_DataTable_Producto(ByVal cVari As String,
                                            ByRef cProducto As String)
        Try
            Dim am() As String = Split(cVari, "|")
            Dim dr As DataRow

            dr = dt_Producto.NewRow

            cProducto = Trim(am(1))

            dr.Item("id_Cliente") = Convert.ToInt64(am(0))
            dr.Item("id_Producto") = Convert.ToString(am(1))
            dr.Item("id_Producto_Clase") = Convert.ToInt32(am(2))
            dr.Item("id_Tipo_Categoria") = Convert.ToInt32(am(3))
            dr.Item("Calorias") = Convert.ToInt32(am(4))
            dr.Item("Producto_Dieta") = Me.fConvierte_a_Boleano(am(5))
            dr.Item("Producto_Kosher") = Me.fConvierte_a_Boleano(am(6))
            dr.Item("Producto_Suspendido") = Me.fConvierte_a_Boleano(am(7))
            dr.Item("Producto_Entrega_Domicilio") = Me.fConvierte_a_Boleano(am(8))
            dr.Item("Nombre") = Convert.ToString(am(9))
            dr.Item("Contenido") = Convert.ToString(am(10))
            dr.Item("id_Unidad_Manejo") = Convert.ToInt32(am(11))
            dr.Item("Sujeto_IVA") = Me.fConvierte_a_Boleano(am(12))
            dr.Item("Por_IVA") = Convert.ToSingle(am(13))
            dr.Item("Precio") = Convert.ToSingle(am(14))
            dr.Item("Precio_Promocion") = Convert.ToSingle(am(15))
            dr.Item("Valor_Puntos") = Convert.ToInt32(am(16))
            dr.Item("Disponible_Lunes") = Me.fConvierte_a_Boleano(am(17))
            dr.Item("Disponible_Martes") = Me.fConvierte_a_Boleano(am(18))
            dr.Item("Disponible_Miercoles") = Me.fConvierte_a_Boleano(am(19))
            dr.Item("Disponible_Jueves") = Me.fConvierte_a_Boleano(am(20))
            dr.Item("Disponible_Viernes") = Me.fConvierte_a_Boleano(am(21))
            dr.Item("Disponible_Sabado") = Me.fConvierte_a_Boleano(am(22))
            dr.Item("Disponible_Domingo") = Me.fConvierte_a_Boleano(am(23))
            dr.Item("Imagen") = am(24)
            dr.Item("Horario_Lunes_Ini") = am(25)
            dr.Item("Horario_Lunes_Fin") = am(26)
            dr.Item("Horario_Martes_Ini") = am(27)
            dr.Item("Horario_Martes_Fin") = am(28)
            dr.Item("Horario_Miercoles_Ini") = am(29)
            dr.Item("Horario_Miercoles_Fin") = am(30)
            dr.Item("Horario_Jueves_Ini") = am(31)
            dr.Item("Horario_Jueves_Fin") = am(32)
            dr.Item("Horario_Viernes_Ini") = am(33)
            dr.Item("Horario_Viernes_Fin") = am(34)
            dr.Item("Horario_Sabado_Ini") = am(35)
            dr.Item("Horario_Sabado_Fin") = am(36)
            dr.Item("Horario_Domingo_Ini") = am(37)
            dr.Item("Horario_Domingo_Fin") = am(38)

            dt_Producto.Rows.Add(dr)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub fAdiciona_DataTable_Producto_Partida(ByVal cVari As String,
                                                    ByRef cProducto_Partida As String)
        Try
            Dim am() As String = Split(cVari, "|")
            Dim dr As DataRow

            dr = dt_Producto_Partida.NewRow

            cProducto_Partida = Trim(am(1))

            dr.Item("id_Cliente") = Convert.ToInt64(am(0))
            dr.Item("id_Producto") = Convert.ToString(am(1))
            dr.Item("Consecutivo") = Convert.ToInt32(am(2))
            dr.Item("Nivel_Grupo") = Convert.ToInt32(am(3))
            dr.Item("Nivel_Producto") = Convert.ToInt32(am(4))
            dr.Item("Nivel_Componente") = Convert.ToInt32(am(5))
            dr.Item("Nombre") = Convert.ToString(am(6))
            dr.Item("Nivel") = Convert.ToInt32(am(7))
            dr.Item("Máximo_Click") = Convert.ToInt32(am(8))
            dr.Item("Precio_Adicional") = Convert.ToSingle(am(9))

            dt_Producto_Partida.Rows.Add(dr)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Public Sub fAdiciona_DataTable_Pedido(ByVal cVari As String,
                                          ByRef nPedido As Integer,
                                 Optional ByVal bReimprime As Boolean = False)

        Dim am() As String = Split(cVari, "|")
        Dim dr_Ped As DataRow

        nPedido = Convert.ToInt32(am(0))

        If fBusca_Folio(nPedido) = True Then
            Exit Sub
        End If

        If bReimprime = False Then
            dr_Ped = dt_Pedido.NewRow
        Else
            dr_Ped = dt_Pedido_Reimprime.NewRow
        End If

        dr_Ped.Item("Folio_Internet") = Convert.ToInt64(am(0))
        dr_Ped.Item("id_Cliente") = Convert.ToInt32(am(1))
        dr_Ped.Item("Pedido_Prefijo") = Convert.ToString(am(2))
        dr_Ped.Item("Pedido_Folio") = Convert.ToInt32(am(3))
        dr_Ped.Item("Status") = Convert.ToString(am(4))
        dr_Ped.Item("Tipo_Pedido") = Convert.ToInt16(am(5))
        dr_Ped.Item("id_Usuario") = Convert.ToInt32(am(6))
        dr_Ped.Item("Tipo_Pago") = Convert.ToInt16(am(7))
        dr_Ped.Item("Folio_Aceptacion_Pago") = Convert.ToString(am(8))
        dr_Ped.Item("Pedido_Pagado") = fConvierte_a_Boleano(am(9))
        dr_Ped.Item("Factura_Fiscal") = fConvierte_a_Boleano(am(10))
        dr_Ped.Item("Pedido_Turno") = Convert.ToInt16(am(11))
        dr_Ped.Item("Pedido_Dia") = Convert.ToInt16(am(12))
        dr_Ped.Item("Usuario_Pedido_Tipo_Entrega") = Convert.ToInt16(am(13))
        dr_Ped.Item("Usuario_Pedido_Fecha_Pedido") = Convert.ToDateTime(am(14))
        dr_Ped.Item("Usuario_Pedido_Fecha_Entrega") = Convert.ToDateTime(am(15))
        dr_Ped.Item("Usuario_Pedido_Recibido") = fConvierte_a_Boleano(am(16))
        dr_Ped.Item("Usuario_Pedido_Fecha_Recepcion") = Convert.ToDateTime(am(17))
        dr_Ped.Item("Usuario_Pedido_Cerrado") = fConvierte_a_Boleano(am(18))
        dr_Ped.Item("Usuario_Clave_Pedido_Cerrado") = Convert.ToInt16(am(19))
        dr_Ped.Item("Usuario_Pedido_Cerrado_Fecha") = Convert.ToDateTime(am(20))
        dr_Ped.Item("Usuario_Pedido_Cerrado_Comentario") = Convert.ToString(am(21))
        dr_Ped.Item("Usuario_Pedido_Cancelado") = fConvierte_a_Boleano(am(22))
        dr_Ped.Item("Usuario_Pedido_Cancelado_Fecha") = Convert.ToDateTime(am(23))
        dr_Ped.Item("Usuario_Pedido_Cancelado_Motivo") = Convert.ToString(am(24))
        dr_Ped.Item("IVA") = Convert.ToSingle(am(25))
        dr_Ped.Item("Total") = Convert.ToSingle(am(26))
        dr_Ped.Item("E2E_Puntos_Pedido") = Convert.ToInt32(am(27))
        dr_Ped.Item("Cliente_Puntos_Pedido") = Convert.ToInt32(am(28))
        dr_Ped.Item("Promo_Puntos_Cupon") = Convert.ToString(am(29))
        dr_Ped.Item("Promo_Puntos_Puntos") = Convert.ToString(am(30))
        dr_Ped.Item("Promo_Puntos_Puntos_I") = Convert.ToString(am(31))
        dr_Ped.Item("Promo_Porciento_Cupon") = Convert.ToString(am(32))
        dr_Ped.Item("Promo_Porciento_Factor") = Convert.ToString(am(33))
        dr_Ped.Item("Promo_Porciento_I") = Convert.ToString(am(34))
        dr_Ped.Item("Promo_Importe_Cupon") = Convert.ToString(am(35))
        dr_Ped.Item("Promo_Importe_I") = Convert.ToString(am(36))
        dr_Ped.Item("Promo_Produ_Cupon") = Convert.ToString(am(37))
        dr_Ped.Item("Promo_Produ_Clave") = Convert.ToString(am(38))
        dr_Ped.Item("Cliente_Puntos_Cant") = Convert.ToInt32(am(39))
        dr_Ped.Item("Cliente_Puntos_I") = Convert.ToSingle(am(40))
        dr_Ped.Item("Cliente_Monedero_I") = Convert.ToSingle(am(41))
        dr_Ped.Item("E2E_Puntos_Cant") = Convert.ToInt32(am(42))
        dr_Ped.Item("E2E_Puntos_I") = Convert.ToSingle(am(43))
        dr_Ped.Item("E2E_Monedero_I") = Convert.ToSingle(am(44))
        dr_Ped.Item("Pago_Propina") = Convert.ToSingle(am(45))
        dr_Ped.Item("Pago_Importe_Total") = Convert.ToSingle(am(46))
        dr_Ped.Item("Cambio") = Convert.ToSingle(am(47))
        dr_Ped.Item("Comentario_Calificacion") = Convert.ToString(am(48))
        dr_Ped.Item("Comentario_Observaciones") = Convert.ToString(am(49))
        dr_Ped.Item("Requiere_Factura") = fConvierte_a_Boleano(am(50))
        dr_Ped.Item("Factura_RFC") = Convert.ToString(am(51))
        dr_Ped.Item("Ruta_Generada") = fConvierte_a_Boleano(am(52))
        dr_Ped.Item("id_Ruta") = Convert.ToInt32(am(53))
        dr_Ped.Item("Ruta_Fecha") = Convert.ToDateTime(am(54))
        dr_Ped.Item("Ruta_Usuario") = Convert.ToString(am(55))
        dr_Ped.Item("id_Domicilio_Entrega") = Convert.ToString(am(56))
        dr_Ped.Item("Nombre") = Convert.ToString(am(57))
        dr_Ped.Item("Calle") = Convert.ToString(am(58))
        dr_Ped.Item("Exterior") = Convert.ToString(am(59))
        dr_Ped.Item("Interior") = Convert.ToString(am(60))
        dr_Ped.Item("Colonia") = Convert.ToString(am(61))
        dr_Ped.Item("Delegacion") = Convert.ToString(am(62))
        dr_Ped.Item("Localidad") = Convert.ToString(am(63))
        dr_Ped.Item("Entidad") = Convert.ToString(am(64))
        dr_Ped.Item("Cod_Postal") = Convert.ToString(am(65))
        dr_Ped.Item("Tele") = Convert.ToString(am(66))
        dr_Ped.Item("Latitud") = Convert.ToDouble(am(67))
        dr_Ped.Item("Longitud") = Convert.ToDouble(am(68))
        dr_Ped.Item("Ya_Reportado") = fConvierte_a_Boleano(am(69))

        If bReimprime = False Then
            dt_Pedido.Rows.Add(dr_Ped)
        Else
            dt_Pedido_Reimprime.Rows.Add(dr_Ped)
        End If

    End Sub

    Public Sub fAdiciona_DataTable_Pedido_Detalle(ByVal cVari As String,
                                                  ByRef nPedido As Integer,
                                         Optional ByVal bReimprime As Boolean = False)

        '       404|P5_0002|Servicio primario|1.000|1500.00|Crutones|2|Servicios

        cVari = Replace(cVari, "«A»", "|")

        Dim cVar As String = ""
        Dim ae() As String = Split(cVari, "«*»")
        Dim am() As String

        Dim dr_Det As DataRow

        For nI As Integer = 0 To ae.Length - 1
            cVar = ae(nI)
            am = Split(cVar, "|")

            nPedido = Convert.ToInt32(am(0))

            If bReimprime = False Then
                dr_Det = dt_Pedido_Detalle.NewRow
            Else
                dr_Det = dt_Pedido_Detalle_Reimprime.NewRow
            End If


            dr_Det.Item("Folio_Internet") = Convert.ToInt64(am(0))
            dr_Det.Item("Consecutivo") = nI + 1
            dr_Det.Item("id_Producto") = am(1)
            dr_Det.Item("Nombre") = am(2)
            dr_Det.Item("Cantidad") = Convert.ToInt16(Int(Val(am(3))))
            dr_Det.Item("Precio") = Convert.ToSingle(am(4))
            dr_Det.Item("Adicion") = Convert.ToString(am(5))
            dr_Det.Item("Id_Categoria") = Convert.ToInt16(Int(Val(am(6))))
            dr_Det.Item("Nombre_Categoria") = Convert.ToString(am(7))

            If bReimprime = False Then
                dt_Pedido_Detalle.Rows.Add(dr_Det)
            Else
                dt_Pedido_Detalle_Reimprime.Rows.Add(dr_Det)
            End If

        Next

    End Sub

    Public Sub fAdiciona_DataTable_Tipo_Cliente(ByVal cVari As String)

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Tipo_Cliente.NewRow

            dr.Item("id_Tipo_Cliente") = Convert.ToInt32(am(0))
            dr.Item("Nombre") = Convert.ToString(am(1))

            dt_Tipo_Cliente.Rows.Add(dr)

        Next



    End Sub

    Public Sub fAdiciona_DataTable_Tipo_Cliente_Producto(ByVal cVari As String)

        If cVari = "" Then
            Return
            Exit Sub
        End If

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Tipo_Cliente_Producto.NewRow

            dr.Item("id_Tipo_Cliente") = Convert.ToInt32(am(0))
            dr.Item("Nombre") = Convert.ToString(am(1))

            dt_Tipo_Cliente_Producto.Rows.Add(dr)

        Next



    End Sub



    Public Sub fAdiciona_DataTable_Pais_Estado_Ciudad_Zona(ByVal cVari As String)

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        'Ok|0000|Proceso Correcto«*»
        '               117|9|1|1|México|Distrito Federal|Ciudad de México|Sante Fe - Bosques de las Lomas««
        '               117|9|1|2|México|Distrito Federal|Ciudad de México|Polanco - Anahuac - Anzures - Lomas««
        '               117|9|1|3|México|Distrito Federal|Ciudad de México|Tecamachalco - Interlomas - Herradura««
        '               117|9|1|4|México|Distrito Federal|Ciudad de México|Condesa - Roma««
        '               117|9|1|5|México|Distrito Federal|Ciudad de México|Altavista - San Angel««
        '               117|9|1|6|México|Distrito Federal|Ciudad de México|Del Valle - Nápoles - Narvarte««
        '               117|9|1|7|México|Distrito Federal|Ciudad de México|Satélite-Echegaray-Toreo-Lomas Verdes««
        '               117|9|1|8|México|Distrito Federal|Ciudad de México|Tlalnepantla««
        '               117|9|1|9|México|Distrito Federal|Ciudad de México|Valle Dorado

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Pais_Estado_Ciudad_Zona.NewRow

            dr.Item("id_Pais") = Convert.ToInt32(am(0))
            dr.Item("id_Estado") = Convert.ToInt32(am(1))
            dr.Item("id_Ciudad") = Convert.ToInt32(am(2))
            dr.Item("id_Zona") = Convert.ToInt32(am(3))
            dr.Item("Nombre_Pais") = Convert.ToString(am(4))
            dr.Item("Nombre_Estado") = Convert.ToString(am(5))
            dr.Item("Nombre_Ciudad") = Convert.ToString(am(6))
            dr.Item("Nombre_Zona") = Convert.ToString(am(7))

            dt_Pais_Estado_Ciudad_Zona.Rows.Add(dr)

        Next



    End Sub

    Public Sub fAdiciona_DataTable_Pais_Estado_Ciudad(ByVal cVari As String)

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        '       Ok|0000|Proceso Correcto«*»
        '               117|México|9|Distrito Federal|1|Ciudad de México««
        '               117|México|14|Jalisco|1|Guadalajara

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Pais_Estado_Ciudad.NewRow

            dr.Item("id_Pais") = Convert.ToInt32(am(0))
            dr.Item("id_Estado") = Convert.ToInt32(am(1))
            dr.Item("id_Ciudad") = Convert.ToInt32(am(2))
            dr.Item("Nombre_Pais") = Convert.ToString(am(3))
            dr.Item("Nombre_Estado") = Convert.ToString(am(4))
            dr.Item("Nombre_Ciudad") = Convert.ToString(am(5))

            dt_Pais_Estado_Ciudad.Rows.Add(dr)

        Next

    End Sub

    Public Sub fAdiciona_DataTable_Pais_Estado(ByVal cVari As String)

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        '       Ok|0000|Proceso Correcto«*»
        '               117|México|1|Aguascalientes««
        '               117|México|2|Baja California««
        '               117|México|3|Baja California Sur««
        '               117|México|4|Campeche««
        '               117|México|5|Coahuila««
        '               117|México|6|Colima««
        '               117|México|7|Chiapas««
        '               117|México|8|Chihuahua««
        '               117|México|9|Distrito Federal««
        '               117|México|10|Durango««
        '               117|México|11|Guanajuato           1171.....................



        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Pais_Estado.NewRow

            dr.Item("id_Pais") = Convert.ToInt32(am(0))
            dr.Item("id_Estado") = Convert.ToInt32(am(1))
            dr.Item("Nombre_Pais") = Convert.ToString(am(2))
            dr.Item("Nombre_Estado") = Convert.ToString(am(3))

            dt_Pais_Estado.Rows.Add(dr)

        Next

    End Sub

    Public Sub fAdiciona_DataTable_Pais(ByVal cVari As String)

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        '       Ok|0000|Proceso Correcto«*»
        '               117|México««
        '               117|Estados Unidos««
        '               117|Canada

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Pais.NewRow

            dr.Item("id_Pais") = Convert.ToInt32(am(0))
            dr.Item("Nombre_Pais") = Convert.ToString(am(1))

            dt_Pais.Rows.Add(dr)

        Next

    End Sub


    Public Sub fAdiciona_DataTable_Menu(ByVal cVari As String)


        If cVari.Trim = "" Then
            Exit Sub
        End If

        Dim ae() As String = Split(cVari, "««")
        Dim am() As String

        Dim dr As DataRow

        '       Ok|0000|Proceso Correcto«*»
        '               117|México««
        '               117|Estados Unidos««
        '               117|Canada

        For nI As Integer = 0 To ae.Length - 1

            am = Split(ae(nI), "|")

            dr = dt_Menu.NewRow

            dr.Item("id_Cliente") = Convert.ToInt32(am(0))
            dr.Item("Autoridad") = Convert.ToInt16(am(1))
            dr.Item("Menu_01") = fConvierte_a_Boleano(am(2))
            dr.Item("Menu_02") = fConvierte_a_Boleano(am(3))
            dr.Item("Menu_03") = fConvierte_a_Boleano(am(4))
            dr.Item("Menu_04") = fConvierte_a_Boleano(am(5))
            dr.Item("Menu_05") = fConvierte_a_Boleano(am(6))
            dr.Item("Menu_06") = fConvierte_a_Boleano(am(7))
            dr.Item("Menu_07") = fConvierte_a_Boleano(am(8))
            dr.Item("Menu_08") = fConvierte_a_Boleano(am(9))
            dr.Item("Menu_09") = fConvierte_a_Boleano(am(10))
            dr.Item("Menu_10") = fConvierte_a_Boleano(am(11))
            dr.Item("Menu_11") = fConvierte_a_Boleano(am(12))
            dr.Item("Menu_12") = fConvierte_a_Boleano(am(13))
            dr.Item("Menu_13") = fConvierte_a_Boleano(am(14))
            dr.Item("Menu_14") = fConvierte_a_Boleano(am(15))
            dr.Item("Menu_15") = fConvierte_a_Boleano(am(16))
            dr.Item("Menu_16") = fConvierte_a_Boleano(am(17))
            dr.Item("Menu_17") = fConvierte_a_Boleano(am(18))
            dr.Item("Menu_18") = fConvierte_a_Boleano(am(19))
            dr.Item("Menu_19") = fConvierte_a_Boleano(am(20))
            dr.Item("Menu_20") = fConvierte_a_Boleano(am(21))

            dt_Menu.Rows.Add(dr)

        Next

    End Sub


    Public Sub fAdiciona_DataTable_Geocerca(ByVal cVari As String,
                                            ByRef nRegistros As Integer)

        '   OK|0858|Proceso Correcto|-99.153842926025391 19.42256346067618, -99.154593944549561 19.41507576315681, -99.162726402282715 19.413416280797691, -99.164829254150391 19.420155292889969, -99.153842926025391 19.42256346067618

        Dim nLatitud As Single = 0
        Dim nLongitud As Single = 0
        Dim nConsecutivo As Integer = 0

        Dim ae() As String
        Dim am() As String

        Dim dr As DataRow

        ae = Split(cVari, ",")

        For nInd As Integer = 0 To ae.Length - 1

            dr = dt_Geocerca.NewRow

            am = Split(Trim(ae(nInd)), " ")
            '
            '           NOTA : Primero regresa la longitud y después la latitud
            '
            'nLatitud = Val(Mid(ae(nInd), InStr(ae(nInd), " "), 50))
            'nLongitud = Val(Mid(ae(nInd), 1, InStr(ae(nInd), " ")))

            nLatitud = Val(am(1))
            nLongitud = Val(am(0))

            nConsecutivo += 20
            dr.Item("Consecutivo") = nConsecutivo
            dr.Item("Latitud") = nLatitud
            dr.Item("Longitud") = nLongitud

            dt_Geocerca.Rows.Add(dr)
        Next

    End Sub

    Public Sub fAdiciona_DataTable_Producto_Partida_Det(ByVal cVari As String,
                                                        ByRef cProducto_Partida As String)
        Try
            Dim am() As String = Split(cVari, "|")
            Dim dr_Grupo As DataRow
            Dim dr_Detalle As DataRow
            Dim dr_PP As DataRow

            '================================================================================
            '   Se genera una tabla en donde están todas las partidas del producto seleccionado
            '
            dr_PP = dt_Producto_Partida.NewRow

            cProducto_Partida = Trim(am(1))

            dr_PP.Item("id_Cliente") = Convert.ToInt64(am(0))
            dr_PP.Item("id_Producto") = Convert.ToString(am(1))
            dr_PP.Item("Consecutivo") = Convert.ToInt16(am(2))
            dr_PP.Item("Nivel_Grupo") = Convert.ToInt16(am(3))
            dr_PP.Item("Nivel_Producto") = Convert.ToInt16(am(4))
            dr_PP.Item("Nivel_Componente") = Convert.ToInt16(am(5))
            dr_PP.Item("Nombre") = Convert.ToString(am(6))
            dr_PP.Item("Nivel") = Convert.ToInt16(am(7))
            dr_PP.Item("Maximo_Click") = Convert.ToInt16(am(8))
            dr_PP.Item("Precio_Adicional") = Convert.ToSingle(am(9))

            dt_Producto_Partida.Rows.Add(dr_PP)

            '================================================================================

            dr_Grupo = dt_Producto_Partida_Grupo.NewRow

            If Convert.ToInt16(am(3)) = 1 Then              '       Se registra solamente el grupo

                dr_Grupo.Item("id_Cliente") = Convert.ToInt64(am(0))
                dr_Grupo.Item("id_Producto") = Convert.ToString(am(1))
                dr_Grupo.Item("Consecutivo") = Convert.ToInt16(am(2))
                dr_Grupo.Item("Nivel_Grupo") = Convert.ToInt16(am(3))
                dr_Grupo.Item("Nivel_Producto") = Convert.ToInt16(am(4))
                dr_Grupo.Item("Nivel_Componente") = Convert.ToInt16(am(5))
                dr_Grupo.Item("Nombre") = Convert.ToString(am(6))
                dr_Grupo.Item("Nivel") = Convert.ToInt16(am(7))
                dr_Grupo.Item("Maximo_Click") = Convert.ToInt16(am(8))
                dr_Grupo.Item("Precio_Adicional") = Convert.ToSingle(am(9))

                dt_Producto_Partida_Grupo.Rows.Add(dr_Grupo)
            End If

            If Convert.ToInt16(am(3)) = 2 Then              '       Se registra solamente el detalle del grupo   

                dr_Detalle = dt_Producto_Partida_Detalle.NewRow

                dr_Detalle.Item("id_Cliente") = Convert.ToInt64(am(0))
                dr_Detalle.Item("id_Producto") = Convert.ToString(am(1))
                dr_Detalle.Item("Consecutivo") = Convert.ToInt16(am(2))
                dr_Detalle.Item("Nivel_Grupo") = Convert.ToInt16(am(3))
                dr_Detalle.Item("Nivel_Producto") = Convert.ToInt16(am(4))
                dr_Detalle.Item("Nivel_Componente") = Convert.ToInt16(am(5))
                dr_Detalle.Item("Nombre") = Convert.ToString(am(6))
                dr_Detalle.Item("Nivel") = Convert.ToInt16(am(7))
                dr_Detalle.Item("Maximo_Click") = Convert.ToInt16(am(8))
                dr_Detalle.Item("Precio_Adicional") = Convert.ToSingle(am(9))

                dt_Producto_Partida_Detalle.Rows.Add(dr_Detalle)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




    Public Sub fConvierte_Datatable_a_Estructura_Pedido(dr As DataRow)

        Ped.nFolio_Internet = dr.Item("Folio_Internet")
        Ped.id_Cliente = dr.Item("id_Cliente")
        Ped.cPedido_Prefijo = dr.Item("Pedido_Prefijo")
        Ped.nPedido_Folio = dr.Item("Pedido_Folio")
        Ped.cStatus = dr.Item("Status")
        Ped.nTipo_Pedido = dr.Item("Tipo_Pedido")
        Ped.id_Usuario = dr.Item("id_Usuario")
        Ped.nTipo_Pago = dr.Item("Tipo_Pago")
        Ped.cFolio_Aceptacion_Pago = dr.Item("Folio_Aceptacion_Pago")
        Ped.bPedido_Pagado = dr.Item("Pedido_Pagado")
        Ped.bFactura_Fiscal = dr.Item("Factura_Fiscal")
        Ped.nPedido_Turno = dr.Item("Pedido_Turno")
        Ped.nPedido_Dia = dr.Item("Pedido_Dia")
        Ped.nUsuario_Pedido_Tipo_Entrega = dr.Item("Usuario_Pedido_Tipo_Entrega")
        Ped.fUsuario_Pedido_Fecha_Pedido = dr.Item("Usuario_Pedido_Fecha_Pedido")
        Ped.fUsuario_Pedido_Fecha_Entrega = dr.Item("Usuario_Pedido_Fecha_Entrega")
        Ped.bUsuario_Pedido_Recibido = dr.Item("Usuario_Pedido_Recibido")
        Ped.fUsuario_Pedido_Fecha_Recepcion = dr.Item("Usuario_Pedido_Fecha_Recepcion")
        Ped.bUsuario_Pedido_Cerrado = dr.Item("Usuario_Pedido_Cerrado")
        Ped.nUsuario_Clave_Pedido_Cerrado = dr.Item("Usuario_Clave_Pedido_Cerrado")
        Ped.fUsuario_Pedido_Cerrado_Fecha = dr.Item("Usuario_Pedido_Cerrado_Fecha")
        Ped.cUsuario_Pedido_Cerrado_Comentario = dr.Item("Usuario_Pedido_Cerrado_Comentario")
        Ped.bUsuario_Pedido_Cancelado = dr.Item("Usuario_Pedido_Cancelado")
        Ped.fUsuario_Pedido_Cancelado_Fecha = dr.Item("Usuario_Pedido_Cancelado_Fecha")
        Ped.cUsuario_Pedido_Cancelado_Motivo = dr.Item("Usuario_Pedido_Cancelado_Motivo")
        Ped.nIVA = dr.Item("IVA")
        Ped.nTotal = dr.Item("Total")
        Ped.nE2E_Puntos_Pedido = dr.Item("E2E_Puntos_Pedido")
        Ped.nCliente_Puntos_Pedido = dr.Item("Cliente_Puntos_Pedido")
        Ped.cPromo_Puntos_Cupon = dr.Item("Promo_Puntos_Cupon")
        Ped.cPromo_Puntos_Puntos = dr.Item("Promo_Puntos_Puntos")
        Ped.cPromo_Puntos_Puntos_I = dr.Item("Promo_Puntos_Puntos_I")
        Ped.cPromo_Porciento_Cupon = dr.Item("Promo_Porciento_Cupon")
        Ped.cPromo_Porciento_Factor = dr.Item("Promo_Porciento_Factor")
        Ped.cPromo_Porciento_I = dr.Item("Promo_Porciento_I")
        Ped.cPromo_Importe_Cupon = dr.Item("Promo_Importe_Cupon")
        Ped.cPromo_Importe_I = dr.Item("Promo_Importe_I")
        Ped.cPromo_Produ_Cupon = dr.Item("Promo_Produ_Cupon")
        Ped.cPromo_Produ_Clave = dr.Item("Promo_Produ_Clave")
        Ped.nCliente_Puntos_Cant = dr.Item("Cliente_Puntos_Cant")
        Ped.nCliente_Puntos_I = dr.Item("Cliente_Puntos_I")
        Ped.nCliente_Monedero_I = dr.Item("Cliente_Monedero_I")
        Ped.nE2E_Puntos_Cant = dr.Item("E2E_Puntos_Cant")
        Ped.nE2E_Puntos_I = dr.Item("E2E_Puntos_I")
        Ped.nE2E_Monedero_I = dr.Item("E2E_Monedero_I")
        Ped.nPago_Propina = dr.Item("Pago_Propina")
        Ped.nPago_Importe_Total = dr.Item("Pago_Importe_Total")
        Ped.nCambio = dr.Item("Cambio")
        Ped.cComentario_Calificacion = dr.Item("Comentario_Calificacion")
        Ped.cComentario_Observaciones = dr.Item("Comentario_Observaciones")
        Ped.bRequiere_Factura = dr.Item("Requiere_Factura")
        Ped.cFactura_RFC = dr.Item("Factura_RFC")
        Ped.bRuta_Generada = dr.Item("Ruta_Generada")
        Ped.id_Ruta = dr.Item("id_Ruta")
        Ped.fRuta_Fecha = dr.Item("Ruta_Fecha")
        Ped.cRuta_Usuario = dr.Item("Ruta_Usuario")
        Ped.id_Domicilio_Entrega = dr.Item("id_Domicilio_Entrega")
        Ped.cNombre = dr.Item("Nombre")
        Ped.cCalle = dr.Item("Calle")
        Ped.cExterior = dr.Item("Exterior")
        Ped.cInterior = dr.Item("Interior")
        Ped.cColonia = dr.Item("Colonia")
        Ped.cDelegacion = dr.Item("Delegacion")
        Ped.cLocalidad = dr.Item("Localidad")
        Ped.cEntidad = dr.Item("Entidad")
        Ped.cCod_Postal = dr.Item("Cod_Postal")
        Ped.cTele = dr.Item("Tele")
        Ped.nLatitud = dr.Item("Latitud")
        Ped.nLongitud = dr.Item("Longitud")
        Ped.bYa_Reportado = dr.Item("Ya_Reportado")

    End Sub

    Public Sub fConvierte_Datatable_a_Estructura_Pedido_Detalle(dt As DataTable)

        Dim dRow As DataRow
        Dim nReg As Integer = dt.Rows.Count

        ReDim Ped.Detalle(0 To nReg - 1)

        For nI As Integer = 0 To nReg - 1
            dRow = dt.Rows(nI)

            Ped.Detalle(nI).nFolio_Internet = dRow.Item("Folio_Internet")
            Ped.Detalle(nI).nConsecutivo = dRow.Item("Consecutivo")
            Ped.Detalle(nI).id_Producto = dRow.Item("id_Producto")
            Ped.Detalle(nI).cNombre = dRow.Item("Nombre")
            Ped.Detalle(nI).nCantidad = dRow.Item("Cantidad")
            Ped.Detalle(nI).nPrecio = dRow.Item("Precio")
            Ped.Detalle(nI).cAdicion = dRow.Item("Adicion")
            Ped.Detalle(nI).id_Categoria = dRow.Item("id_Categoria")
            Ped.Detalle(nI).cNombre_Categoria = dRow.Item("Nombre_Categoria")

        Next

    End Sub




    Private Function fBusca_Folio(ByVal nFolio_Internet As Integer) As Boolean

        Dim lRet As Boolean = True

        Dim dr() As DataRow

        dr = dt_Pedido.Select("Folio_Internet = " & nFolio_Internet & "")

        If dr.Length < 1 Then
            lRet = False
        End If

        Return lRet

    End Function

    Public Function fBorra_Folio(ByVal nFolio_Internet As Integer) As Boolean

        Dim lRet As Boolean = True

        Try

            For nI As Integer = 0 To dt_Pedido.Rows.Count - 1

                If dt_Pedido.Rows(nI).Item("Folio_Internet") = nFolio_Internet Then
                    dt_Pedido.Rows(nI).Item("Status") = "PR"
                    '                    dt_Pedido.Rows(nI).Delete()
                End If
            Next

            For nI As Integer = 0 To dt_Pedido_Detalle.Rows.Count - 1

                If dt_Pedido_Detalle.Rows(nI).Item("Folio_Internet") = nFolio_Internet Then
                    dt_Pedido_Detalle.Rows(nI).Delete()
                End If
            Next

        Catch ex As Exception
            _Mensaje = "Error al borrar folio del DataTable"
            _Clave = 9999
            _Resultado = "Error"
            _Descripcion = ex.Message
            lRet = False

        End Try

        Return lRet

    End Function



    '-----    Funciones Obsoletas, retirar  

    Public Function fAdiciona_DataTable_String_Pedido(ByVal nFolio_Internet As Integer,
                                     ByVal cEnca As String,
                                     ByVal cDeta As String) As Boolean
        Dim cVar As String = ""

        '
        '       NOTA: El DataTable de Pedido y Pedido_Detalle, se toman de la variable publica definida en uGeneral
        '
        Dim dr_Ped As DataRow
        dr_Ped = dt_Pedido.NewRow

        Dim am() As String
        Try
            If fBusca_Folio(nFolio_Internet) = False Then        '  Significa que ya está en el directorio local

                am = Split(cEnca, "|")

                nFolio_Internet = Convert.ToInt32(am(0))
                dr_Ped.Item("Folio_Internet") = Convert.ToInt32(am(0))
                dr_Ped.Item("id_Cliente") = Convert.ToInt32(am(1))
                dr_Ped.Item("Pedido_Prefijo") = Convert.ToString(am(2))
                dr_Ped.Item("Pedido_Folio") = Convert.ToInt32(am(3))
                dr_Ped.Item("Status") = Convert.ToString(am(4))
                dr_Ped.Item("Tipo_Pedido") = Convert.ToInt16(am(5))
                dr_Ped.Item("id_Usuario") = Convert.ToInt32(am(6))
                dr_Ped.Item("Tipo_Pago") = Convert.ToInt16(am(7))
                dr_Ped.Item("Folio_Aceptacion_Pago") = Convert.ToString(am(8))
                dr_Ped.Item("Pedido_Pagado") = fConvierte_a_Boleano(am(9))
                dr_Ped.Item("Factura_Fiscal") = fConvierte_a_Boleano(am(10))
                dr_Ped.Item("Pedido_Turno") = Convert.ToInt16(am(11))
                dr_Ped.Item("Pedido_Dia") = Convert.ToInt16(am(12))
                dr_Ped.Item("Usuario_Pedido_Tipo_Entrega") = Convert.ToInt16(am(13))
                dr_Ped.Item("Usuario_Pedido_Fecha_Pedido") = Convert.ToDateTime(am(14))
                dr_Ped.Item("Usuario_Pedido_Fecha_Entrega") = Convert.ToDateTime(am(15))
                dr_Ped.Item("Usuario_Pedido_Recibido") = fConvierte_a_Boleano(am(16))
                dr_Ped.Item("Usuario_Pedido_Fecha_Recepcion") = Convert.ToDateTime(am(17))
                dr_Ped.Item("Usuario_Pedido_Cerrado") = fConvierte_a_Boleano(am(18))
                dr_Ped.Item("Usuario_Clave_Pedido_Cerrado") = Convert.ToInt16(am(19))
                dr_Ped.Item("Usuario_Pedido_Cerrado_Fecha") = Convert.ToDateTime(am(20))
                dr_Ped.Item("Usuario_Pedido_Cerrado_Comentario") = Convert.ToString(am(21))
                dr_Ped.Item("Usuario_Pedido_Cancelado") = fConvierte_a_Boleano(am(22))
                dr_Ped.Item("Usuario_Pedido_Cancelado_Fecha") = Convert.ToDateTime(am(23))
                dr_Ped.Item("Usuario_Pedido_Cancelado_Motivo") = Convert.ToString(am(24))
                dr_Ped.Item("IVA") = Convert.ToSingle(am(25))
                dr_Ped.Item("Total") = Convert.ToSingle(am(26))
                dr_Ped.Item("E2E_Puntos_Pedido") = Convert.ToInt16(am(27))
                dr_Ped.Item("Cliente_Puntos_Pedido") = Convert.ToInt16(am(28))
                dr_Ped.Item("Promo_Puntos_Cupon") = Convert.ToString(am(29))
                dr_Ped.Item("Promo_Puntos_Puntos") = Convert.ToInt16(am(30))
                dr_Ped.Item("Promo_Puntos_Puntos_I") = Convert.ToSingle(am(31))
                dr_Ped.Item("Promo_Porciento_Cupon") = Convert.ToString(am(32))
                dr_Ped.Item("Promo_Porciento_Factor") = Convert.ToSingle(am(33))
                dr_Ped.Item("Promo_Porciento_I") = Convert.ToSingle(am(34))
                dr_Ped.Item("Promo_Importe_Cupon") = Convert.ToString(am(35))
                dr_Ped.Item("Promo_Importe_I") = Convert.ToSingle(am(36))
                dr_Ped.Item("Promo_Produ_Cupon") = Convert.ToString(am(37))
                dr_Ped.Item("Promo_Produ_Clave") = Convert.ToString(am(38))
                dr_Ped.Item("Cliente_Puntos_Cant") = Convert.ToInt16(am(39))
                dr_Ped.Item("Cliente_Puntos_I") = Convert.ToSingle(am(40))
                dr_Ped.Item("Cliente_Monedero_I") = Convert.ToSingle(am(41))
                dr_Ped.Item("E2E_Puntos_Cant") = Convert.ToInt16(am(42))
                dr_Ped.Item("E2E_Puntos_I") = Convert.ToSingle(am(43))
                dr_Ped.Item("E2E_Monedero_I") = Convert.ToSingle(am(44))
                dr_Ped.Item("Pago_Propina") = Convert.ToSingle(am(45))
                dr_Ped.Item("Pago_Importe_Total") = Convert.ToSingle(am(46))
                dr_Ped.Item("Cambio") = Convert.ToSingle(am(47))
                dr_Ped.Item("Comentario_Calificacion") = Convert.ToString(am(48))
                dr_Ped.Item("Comentario_Observaciones") = Convert.ToString(am(49))
                dr_Ped.Item("Requiere_Factura") = fConvierte_a_Boleano(am(50))
                dr_Ped.Item("Factura_RFC") = Convert.ToString(am(51))
                dr_Ped.Item("Ruta_Generada") = fConvierte_a_Boleano(am(52))
                dr_Ped.Item("id_Ruta") = Convert.ToInt16(am(53))
                dr_Ped.Item("Ruta_Fecha") = Convert.ToDateTime(am(54))
                dr_Ped.Item("Ruta_Usuario") = Convert.ToString(am(55))
                dr_Ped.Item("id_Domicilio_Entrega") = Convert.ToString(am(56))
                dr_Ped.Item("Nombre") = Convert.ToString(am(57))
                dr_Ped.Item("Calle") = Convert.ToString(am(58))
                dr_Ped.Item("Exterior") = Convert.ToString(am(59))
                dr_Ped.Item("Interior") = Convert.ToString(am(60))
                dr_Ped.Item("Colonia") = Convert.ToString(am(61))
                dr_Ped.Item("Delegacion") = Convert.ToString(am(62))
                dr_Ped.Item("Localidad") = Convert.ToString(am(63))
                dr_Ped.Item("Entidad") = Convert.ToString(am(64))
                dr_Ped.Item("Cod_Postal") = Convert.ToString(am(65))
                dr_Ped.Item("Tele") = Convert.ToString(am(66))
                dr_Ped.Item("Latitud") = Convert.ToSingle(am(67))
                dr_Ped.Item("Longitud") = Convert.ToSingle(am(68))
                dr_Ped.Item("Ya_Reportado") = fConvierte_a_Boleano(am(69))

                dt_Pedido.Rows.Add(dr_Ped)

                fAdiciona_DataTable_String_Pedido_Detalle(nFolio_Internet, cDeta)        '       El DataT

            End If
        Catch ex As Exception

            Return False

        End Try

        Return True

    End Function

    Public Function fAdiciona_DataTable_String_Pedido_Detalle(ByVal nFolio_Internet As Integer,
                                             ByVal cDeta As String) As Boolean

        Dim dr_Ped_Det As DataRow
        Dim cVar As String = ""


        Dim am() As String
        Dim ae() As String
        Try
            ae = Split(cDeta, "««")

            For nI As Int16 = 0 To ae.Length - 1

                cVar = ae(nI)

                am = Split(cVar, "|")

                '
                '       NOTA: El DataTable de Pedido y Pedido_Detalle, se toman de la variable publica definida en uGeneral
                '
                dr_Ped_Det = dt_Pedido_Detalle.NewRow

                dr_Ped_Det.Item("Folio_Internet") = nFolio_Internet
                dr_Ped_Det.Item("Consecutivo") = Convert.ToInt16(am(0))
                dr_Ped_Det.Item("id_Producto") = Convert.ToString(am(1))
                dr_Ped_Det.Item("Nombre") = Convert.ToString(am(2))
                dr_Ped_Det.Item("Cantidad") = Convert.ToSingle(am(3))
                dr_Ped_Det.Item("Precio") = Convert.ToSingle(am(4))
                dr_Ped_Det.Item("Adicion") = Convert.ToString(am(5))

                dt_Pedido_Detalle.Rows.Add(dr_Ped_Det)

            Next

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    '-----------------------------------------




    Public Function fConvierte_a_Boleano(ByVal ws_Val As String) As Boolean

        Dim lOk As Boolean = False

        If (ws_Val = "Si") Or (ws_Val = "Yes") Or (ws_Val = "We") Or (ws_Val = "1") Or (ws_Val = "Verdadero") Or (ws_Val = "True") Then
            lOk = True
        Else
            lOk = False
        End If

        Return lOk

    End Function



    'Public Function fCarga_Zonas(ByVal id_Pais As Integer,
    '                             ByVal id_Estado As Integer,
    '                             ByVal id_Ciudad As Integer) As Boolean

    '    Dim cParam As String
    '    Dim cMensaje As String = ""

    '    Me.fCrea_DataTable_Pais()
    '    Me.fCrea_DataTable_Pais_Estado()
    '    Me.fCrea_DataTable_Pais_Estado_Ciudad()
    '    Me.fCrea_DataTable_Pais_Estado_Ciudad_Zona()

    '    Try
    '        cParam = "153|" & glo_cToken
    '        cMensaje = ws_p.wmCampo(cParam)

    '        '       uGeneral
    '        fDesempaca_Mensaje(cMensaje, "*«»*")

    '        If gbl_Resultado <> "OK" Then
    '            MsgBox("Problema al cargar País, reportar a E2E")
    '            Return False
    '            Exit Function
    '        End If
    '        Me.fAdiciona_DataTable_Pais(gbl_Descripcion)
    '    Catch ex As Exception
    '        Me.fBitacora_Error("Err 153", ex.Message)
    '        MsgBox("Error al tratar de descargar Catálogo País", MsgBoxStyle.Critical, "Conectar Internet")
    '        Return False
    '        Exit Function
    '    End Try

    '    Try
    '        cParam = "152|" & glo_cToken & "|" & id_Pais.ToString.Trim
    '        cMensaje = ws_p.wmCampo(cParam)

    '        '       uGeneral
    '        fDesempaca_Mensaje(cMensaje, "*«»*")

    '        If gbl_Resultado <> "OK" Then
    '            MsgBox("Problema al cargar Estados, reportar a E2E")
    '            Return False
    '            Exit Function
    '        End If
    '        Me.fAdiciona_DataTable_Pais_Estado(gbl_Descripcion)
    '    Catch ex As Exception
    '        Me.fBitacora_Error("Err 152", ex.Message)
    '        MsgBox("Error al tratar de descargar Catálogo Estado", MsgBoxStyle.Critical, "Conectar Internet")
    '        Return False
    '        Exit Function
    '    End Try

    '    Try
    '        cParam = "151|" & glo_cToken & "|" & id_Pais.ToString.Trim & "|" & id_Estado.ToString.Trim
    '        cMensaje = ws_p.wmCampo(cParam)

    '        '       uGeneral
    '        fDesempaca_Mensaje(cMensaje, "*«»*")

    '        If gbl_Resultado <> "OK" Then
    '            MsgBox("Problema al cargar Ciudades, reportar a E2E")
    '            Return False
    '            Exit Function
    '        End If
    '        Me.fAdiciona_DataTable_Pais_Estado_Ciudad(gbl_Descripcion)
    '    Catch ex As Exception
    '        Me.fBitacora_Error("Err 151", ex.Message)
    '        MsgBox("Error al tratar de descargar Catálogo Ciudad", MsgBoxStyle.Critical, "Conectar Internet")
    '        Return False
    '        Exit Function
    '    End Try

    '    Try
    '        cParam = "150|" & glo_cToken & "|" & id_Pais.ToString.Trim & "|" & id_Estado.ToString.Trim & "|" & id_Ciudad
    '        cMensaje = ws_p.wmCampo(cParam)

    '        '       uGeneral
    '        fDesempaca_Mensaje(cMensaje, "*«»*")

    '        If gbl_Resultado <> "OK" Then
    '            MsgBox("Problema al cargar Zonas, " & gbl_Mensaje)
    '            Return False
    '            Exit Function
    '        End If
    '        Me.fAdiciona_DataTable_Pais_Estado_Ciudad_Zona(gbl_Descripcion)
    '    Catch ex As Exception
    '        fBitacora_Error("Err 150", ex.Message)
    '        MsgBox("Error al tratar de descargar Catálogo Zonas", MsgBoxStyle.Critical, "Conectar Internet")
    '        Return False
    '        Exit Function
    '    End Try

    '    Return True

    'End Function

    Public Function fCarga_Clientes() As Boolean

        Dim cDato As String = ""
        Dim cVar As String = ""
        Dim cParam As String = ""
        Dim lBucle As Boolean = True

        Dim ae() As String

        cParam = "2060|" & glo_cToken & "|0"              '       El cero se refiere al último cliente obtenito, al inicio es cero

        Dim nClientes_por_Recibir As Integer = 0
        Dim nClientes_Recibidos As Integer = 0
        Dim nUltimo_Cliente As Integer = 0
        Dim cMensaje As String = ""

        Dim dt As New DataTable

        dt_Cliente = New DataTable
        Me.fCrea_DataTable_Cliente()

        While lBucle = True
            cParam = "2060|" & glo_cToken & "|" & nUltimo_Cliente.ToString.Trim
            cMensaje = ws_p.wmCampo(cParam)
            ae = Split(cMensaje, "«*»")         '           Se separa el encabazado de los datos
            cVar = ae(0)                        '           Encabezado
            cDato = ae(1)                       '           Datos de Clientes

            ae = Split(cVar, "|")               '           Se separan los datos del encabezado  (Enviados / Por Enviar)

            nClientes_Recibidos = Val(ae(0))
            nClientes_por_Recibir = Val(ae(1))

            If (nClientes_Recibidos < 2) Or (nClientes_por_Recibir < 2) Then
                cVar = cVar
            End If

            If nClientes_Recibidos > 0 Then          '       Se trata del número de registros recibidos
                ae = Split(cDato, "««")
                For nI As Integer = 0 To ae.Length - 1
                    cVar = ae(nI)       '           Se separan los datos de cada registro de cada cliente
                    Me.fAdiciona_DataTable_Cliente(cVar, nUltimo_Cliente)
                    'fAdiciona_DataTable(dt, cVar, nUltimo_Cliente)
                Next
            End If

            If nClientes_por_Recibir < 1 Then
                lBucle = False
            End If

        End While

        Return True

    End Function

    Public Function fCarga_Productos_Cliente() As Boolean

        Dim cParam As String = ""
        Dim cMensaje As String = ""
        Dim cVar As String = ""
        Dim cDato As String = ""

        Dim ae() As String

        Dim nProductos_Recibidos As Integer = 0
        Dim nProductos_Por_Recibir As Integer = 0
        Dim cUltimo_Producto As String = ""

        Dim nCategorias_Recibidos As Integer = 0
        Dim nCategorias_Por_Recibir As Integer = 0
        Dim nUltima_categoria As Integer = 0

        Dim lBucle As Boolean = True

        '==================================================================================================

        While lBucle = True
            cParam = "2066|" & glo_cToken & "|" & Me.a_Cli.id_Cliente & "|" & cUltimo_Producto      ' Productos del Cliente 
            cMensaje = ws_p.wmCampo(cParam)

            If cMensaje.Trim = "" Then
                Exit While
            End If

            ae = Split(cMensaje, "«*»")         '           Se separa el encabazado de los datos
            cVar = ae(0)                        '           Encabezado
            cDato = ae(1)                       '           Datos de Productos del Cliente

            ae = Split(cVar, "|")               '           Se separan los datos del encabezado  (Enviados / Por Enviar)

            nProductos_Recibidos = Val(ae(0))
            nProductos_Por_Recibir = Val(ae(1))

            If nProductos_Recibidos = 0 Then
                cMensaje = ""
                Exit While
            End If

            If nProductos_Recibidos > 0 Then          '       Se trata del número de registros recibidos
                ae = Split(cDato, "««")
                For nIndice As Integer = 0 To ae.Length - 1
                    cVar = ae(nIndice)       '           Se separan los datos de cada registro de cada cliente
                    fAdiciona_DataTable_Producto(cVar, cUltimo_Producto)
                Next
            End If

        End While

        '==================================================================================================

        Dim nInd As Integer = dt_Producto.Rows.Count

        Return True

    End Function




    Public Function fCrea_Directorio() As Boolean
        Dim lOk As Boolean

        Try
            If My.Computer.FileSystem.DirectoryExists("c:\e2e") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e")
            End If

            If My.Computer.FileSystem.DirectoryExists("c:\e2e\audio") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e\audio")
            End If

            If My.Computer.FileSystem.DirectoryExists("c:\e2e\auditoria") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e\auditoria")
            End If

            If My.Computer.FileSystem.DirectoryExists("c:\e2e\bitacora") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e\bitacora")
            End If

            If My.Computer.FileSystem.DirectoryExists("c:\e2e\bd") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e\bd")
            End If

            If My.Computer.FileSystem.DirectoryExists("c:\e2e\Reporte") = False Then
                My.Computer.FileSystem.CreateDirectory("c:\e2e\Reporte")
            End If

        Catch ex As Exception
            lOk = False
        End Try

        Return lOk
    End Function

    Public Sub fBitacora_Error(ByVal ws_Empresa As String,
                               ByVal ws_Mensaje As String,
                      Optional ByVal ws_Mensaje_1 As String = "")

        Dim cParam As String = ""
        'Dim sw As System.IO.StreamWriter
        'Dim fs As System.IO.FileStream
        Dim cVar As String = ws_Empresa.Trim

        If cVar.Length > 15 Then
            cVar = Mid(cVar, 1, 15)
        End If

        cParam = "326|" & glo_cToken & "|2|" & ws_Mensaje & "|" & ws_Mensaje_1
        cVar = ws_p.wmCampo(cParam)


        'If Dir("c:\E2E", FileAttribute.Directory) = "" Then
        '    My.Computer.FileSystem.CreateDirectory("c:\E2E")
        'End If

        'If Dir("c:\E2E\Bitacora", FileAttribute.Directory) = "" Then
        '    My.Computer.FileSystem.CreateDirectory("c:\E2E\Bitacora")
        'End If

        'cVar = "c:\E2E\Bitacora\" & "P_" & cVar & "_" & Format(Now, "yyyy_MM_dd_HH_mm") & ".txt"

        'fs = New System.IO.FileStream(cVar, System.IO.FileMode.Append)
        'sw = New System.IO.StreamWriter(fs)

        'sw.WriteLine(Format(Now, "yyyy_MM_dd_HH_mm") & " ; " & ws_Empresa & " ; " & ws_Mensaje & " ; " & ws_Mensaje_1)
        ''sw.WriteLine(Format(Now, "yyyy_MM_dd_HH_mm") & "-----------------------------------------------")
        'sw.Close()
        'fs.Close()

    End Sub




End Class
