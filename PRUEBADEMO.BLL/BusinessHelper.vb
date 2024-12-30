Imports PRUEBADEMO.DAL

Public Class Cliente
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Telefono As String
    Public Property Correo As String
End Class
Public Class Venta
    Public Property ID As Integer
    Public Property IDCLiente As Integer
    Public Property Fecha As DateTime
    Public Property Total As Decimal
End Class

Public Class VentaItem
    Public Property ID As Integer
    Public Property IDVenta As Integer
    Public Property IDProducto As Integer
    Public Property PrecioUnitario As Decimal
    Public Property Cantidad As Decimal
    Public Property PrecioTotal As Decimal
End Class

Public Class Producto
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Caregoria As String
End Class

Public Class ClienteBLL
    Private ReadOnly clienteDAL As New ClienteDAL()

    Public Function GetClientes() As DataTable
        Return clienteDAL.GetAllClientes()
    End Function

    Public Sub AddCliente(nombre As String, telefono As String, correo As String)
        clienteDAL.InsertCliente(nombre, telefono, correo)
    End Sub

    Public Sub UpdateCliente(id As Integer, nombre As String, telefono As String, correo As String)
        clienteDAL.UpdateCliente(id, nombre, telefono, correo)
    End Sub

    Public Sub DeleteCliente(id As Integer)
        clienteDAL.DeleteCliente(id)
    End Sub

    Public Function SearchClientesByName(name As String) As DataTable
        Return clienteDAL.SearchClientesByName(name)
    End Function
End Class

Public Class VentaBLL
    Private ReadOnly ventaDAL As New VentaDAL()

    Public Function GetVentas() As DataTable
        Return ventaDAL.GetAllVentas()
    End Function

    Public Function AddVenta(clienteID As Integer, fecha As DateTime, items As List(Of VentaItem)) As Integer
        Dim total As Decimal = items.Sum(Function(i) i.PrecioTotal)
        Dim ventaID As Integer = ventaDAL.InsertVenta(clienteID, fecha, total)

        If ventaID <= 0 Then
            Return -1
        End If

        For Each item In items
            item.IDVenta = ventaID
            ventaDAL.InsertVentaItem(ventaID, item.IDProducto, item.Cantidad, item.PrecioUnitario, item.PrecioTotal)
        Next

        Return ventaID
    End Function

    Public Function SearchVentas(clientName As String, saleID As Integer?, startDate As DateTime?, endDate As DateTime?) As DataTable
        Return ventaDAL.SearchVentas(clientName, saleID, startDate, endDate)
    End Function

    Public Function GetSalesReport() As DataTable
        Return ventaDAL.GetSalesReport()
    End Function
End Class

Public Class VentaItemBLL
    Private ReadOnly ventaitemDAL As New VentaItemDAL()

    Public Function GetVentas() As DataTable
        Return ventaitemDAL.GetAllVentasItems()
    End Function
End Class

Public Class ProductoBLL
    Private ReadOnly productoDAL As New ProductoDAL()

    Public Function GetProductos() As DataTable
        Return productoDAL.GetAllProductos()
    End Function

    Public Sub AddProducto(nombre As String, precio As Decimal, categoria As String)
        productoDAL.InsertProducto(nombre, precio, categoria)
    End Sub

    Public Sub UpdateProducto(id As Integer, nombre As String, precio As Decimal, categoria As String)
        productoDAL.UpdateProducto(id, nombre, precio, categoria)
    End Sub

    Public Sub DeleteProducto(id As Integer)
        productoDAL.DeleteProducto(id)
    End Sub

    Public Function GetProductReport() As DataTable
        Return productoDAL.GetProductReport()
    End Function

    Public Function SearchProductosByName(name As String) As DataTable
        Return productoDAL.SearchProductosByName(name)
    End Function
End Class