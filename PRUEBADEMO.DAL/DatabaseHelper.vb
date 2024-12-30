Imports System.Data.SqlClient
Imports System.Configuration

Public Module DatabaseHelper
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("pruebademo").ConnectionString)
    End Function
End Module

Public Class ClienteDAL
    Public Function GetAllClientes() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM clientes"
            Using cmd As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub InsertCliente(nombre As String, telefono As String, correo As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = telefono
                cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = correo
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateCliente(id As Integer, nombre As String, telefono As String, correo As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "UPDATE clientes SET Cliente = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre
                cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = telefono
                cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = correo
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteCliente(id As Integer)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "DELETE FROM clientes WHERE ID = @ID"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchClientesByName(name As String) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM clientes WHERE Cliente LIKE @Name"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "%" & name & "%"
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function
End Class

Public Class ProductoDAL
    Public Function GetAllProductos() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM productos"
            Using cmd As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub InsertProducto(nombre As String, precio As Decimal, categoria As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio
                cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = categoria
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchProductosByName(name As String) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM productos WHERE Nombre LIKE @Name"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "%" & name & "%"
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub UpdateProducto(id As Integer, nombre As String, precio As Decimal, categoria As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "UPDATE productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE ID = @ID"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = nombre
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio
                cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = categoria
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteProducto(id As Integer)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "DELETE FROM productos WHERE ID = @ID"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetProductReport() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "
            SELECT p.Nombre AS ProductName, 
                   CONVERT(VARCHAR(7), v.Fecha, 120) AS Month, 
                   SUM(vi.Cantidad) AS QuantitySold, 
                   SUM(vi.PrecioTotal) AS TotalRevenue
            FROM productos p
            INNER JOIN ventasitems vi ON p.ID = vi.IDProducto
            INNER JOIN ventas v ON vi.IDVenta = v.ID
            GROUP BY p.Nombre, CONVERT(VARCHAR(7), v.Fecha, 120)
            ORDER BY p.Nombre, Month"
            Using cmd As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim productReportTable As New DataTable()
                adapter.Fill(productReportTable)
                Return productReportTable
            End Using
        End Using
    End Function
End Class
Public Class VentaDAL
    Public Function GetAllVentas() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Ventas"
            Dim cmd As New SqlCommand(query, connection)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function

    Public Function InsertVenta(clienteID As Integer, fecha As DateTime, total As Decimal) As Integer
        Dim ventaID As Integer = 0
        Dim query As String = "INSERT INTO Ventas (IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES (@ClienteID, @Fecha, @Total)"

        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ClienteID", clienteID)
                command.Parameters.AddWithValue("@Fecha", fecha)
                command.Parameters.AddWithValue("@Total", total)
                ventaID = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return ventaID
    End Function

    Public Sub InsertVentaItem(ventaID As Integer, productoID As Integer, cantidad As Integer, precioUnitario As Decimal, precioTotal As Decimal)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO VentasItems (IDVenta, IDProducto, Cantidad, PrecioUnitario, PrecioTotal) VALUES (@VentaID, @ProductoID, @Cantidad, @PrecioUnitario, @PrecioTotal)"
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@VentaID", ventaID)
                cmd.Parameters.AddWithValue("@ProductoID", productoID)
                cmd.Parameters.AddWithValue("@Cantidad", cantidad)
                cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario)
                cmd.Parameters.AddWithValue("@PrecioTotal", precioTotal)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchVentas(clientName As String, saleID As Integer?, startDate As DateTime?, endDate As DateTime?) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT v.ID, v.Fecha, v.Total, c.Cliente FROM Ventas v JOIN Clientes c ON v.IDCliente = c.ID WHERE 1=1"

            If Not String.IsNullOrEmpty(clientName) Then query &= " AND c.Cliente LIKE @ClientName"
            If saleID.HasValue Then query &= " AND v.ID = @SaleID"
            If startDate.HasValue AndAlso endDate.HasValue Then query &= " AND v.Fecha BETWEEN @StartDate AND @EndDate"

            Dim cmd As New SqlCommand(query, connection)
            If Not String.IsNullOrEmpty(clientName) Then cmd.Parameters.AddWithValue("@ClientName", "%" & clientName & "%")
            If saleID.HasValue Then cmd.Parameters.AddWithValue("@SaleID", saleID.Value)
            If startDate.HasValue AndAlso endDate.HasValue Then
                cmd.Parameters.AddWithValue("@StartDate", startDate.Value)
                cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
            End If

            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function
    Public Function GetSalesReport() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()

            Dim query As String = "
            SELECT v.ID AS SaleID, c.Cliente AS ClientName, v.Fecha AS SaleDate, 
                   p.Nombre AS ProductName, vi.Cantidad AS Quantity, 
                   vi.PrecioUnitario AS UnitPrice, vi.PrecioTotal AS Subtotal, 
                   v.Total AS SaleTotal
            FROM ventas v
            INNER JOIN clientes c ON v.IDCliente = c.ID
            INNER JOIN ventasitems vi ON v.ID = vi.IDVenta
            INNER JOIN productos p ON vi.IDProducto = p.ID
            ORDER BY v.Fecha, v.ID"
            Dim cmd As New SqlCommand(query, connection)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim salesReportTable As New DataTable()
            adapter.Fill(salesReportTable)
            Return salesReportTable
        End Using
    End Function

End Class

Public Class VentaItemDAL
    Public Function GetAllVentasItems() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM ventasitems"
            Dim cmd As New SqlCommand(query, connection)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function
End Class