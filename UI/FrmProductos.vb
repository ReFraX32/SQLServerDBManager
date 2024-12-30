Imports PRUEBADEMO.BLL

Public Class FrmProductos
    Private ReadOnly productoBLL As New ProductoBLL()

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductos()
    End Sub

    Private Sub LoadProductos()
        DataGridView1.DataSource = productoBLL.GetProductos()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrecio.Text) OrElse
           String.IsNullOrWhiteSpace(txtCategoria.Text) Then
            MessageBox.Show("Por favor complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim precio As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, precio) OrElse precio <= 0 Then
            MessageBox.Show("Por favor ingrese un precio positivo válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        productoBLL.AddProducto(txtNombre.Text, precio, txtCategoria.Text)
        MessageBox.Show("¡Producto agregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadProductos()
        ResetForm()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Por favor ingrese un ID numérico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productRow = productoBLL.GetProductos().Select($"ID = {id}").FirstOrDefault()
        If productRow Is Nothing Then
            MessageBox.Show("No se encontró ningún producto con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim productName As String = productRow("Nombre").ToString()

        Dim result = MessageBox.Show($"¿Está seguro de que desea actualizar el producto '{productName}'?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrecio.Text) OrElse
           String.IsNullOrWhiteSpace(txtCategoria.Text) Then
            MessageBox.Show("Por favor complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim precio As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, precio) OrElse precio <= 0 Then
            MessageBox.Show("Por favor ingrese un precio positivo válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        productoBLL.UpdateProducto(id, txtNombre.Text, precio, txtCategoria.Text)
        MessageBox.Show($"¡Producto '{txtNombre.Text}' actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadProductos()
        ResetForm()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Por favor ingrese un ID numérico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productRow = productoBLL.GetProductos().Select($"ID = {id}").FirstOrDefault()
        If productRow Is Nothing Then
            MessageBox.Show("No se encontró ningún producto con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim productName As String = productRow("Nombre").ToString()

        Dim result = MessageBox.Show($"¿Está seguro de que desea eliminar el producto '{productName}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        productoBLL.DeleteProducto(id)
        MessageBox.Show($"¡Producto '{productName}' eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadProductos()
        ResetForm()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadProductos()
            Return
        End If

        Dim name As String = txtSearch.Text
        Dim result As DataTable = productoBLL.SearchProductosByName(name)

        If result.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron productos con el nombre proporcionado.", "Resultado de la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProductos()
            Return
        End If

        DataGridView1.DataSource = result
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadProductos()
        End If
    End Sub

    Private Sub ResetForm()
        txtID.Clear()
        txtNombre.Clear()
        txtPrecio.Clear()
        txtCategoria.Clear()
        txtSearch.Clear()
    End Sub
End Class