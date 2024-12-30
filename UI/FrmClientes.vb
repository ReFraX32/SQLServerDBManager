Imports PRUEBADEMO.BLL

Public Class FrmClientes
    Private ReadOnly clienteBLL As New ClienteBLL()

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClientes()
    End Sub

    Private Sub LoadClientes()
        DataGridView1.DataSource = clienteBLL.GetClientes()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtCorreo.Text) Then
            MessageBox.Show("Por favor complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        clienteBLL.AddCliente(txtNombre.Text, txtTelefono.Text, txtCorreo.Text)
        MessageBox.Show("¡Cliente agregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadClientes()
        ResetForm()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Por favor ingrese un ID válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim clientRow = clienteBLL.GetClientes().Select($"ID = {id}").FirstOrDefault()
        If clientRow Is Nothing Then
            MessageBox.Show("No se encontró ningún cliente con el ID proporcionado. Por favor verifique e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim clientName As String = clientRow("Cliente").ToString()

        Dim result = MessageBox.Show($"¿Estás seguro de que deseas actualizar el cliente '{clientName}'?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtCorreo.Text) Then
            MessageBox.Show("Por favor complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        clienteBLL.UpdateCliente(id, txtNombre.Text, txtTelefono.Text, txtCorreo.Text)
        MessageBox.Show($"Cliente '{txtNombre.Text}' actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadClientes()
        ResetForm()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Por favor ingrese un ID numérico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim clientRow = clienteBLL.GetClientes().Select($"ID = {id}").FirstOrDefault()
        If clientRow Is Nothing Then
            MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim clientName As String = clientRow("Cliente").ToString()

        Dim result = MessageBox.Show($"¿Está seguro de que desea eliminar al cliente '{clientName}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        clienteBLL.DeleteCliente(id)
        MessageBox.Show($"Cliente '{clientName}' eliminado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadClientes()
        ResetForm()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadClientes()
            Return
        End If

        Dim name As String = txtSearch.Text
        Dim result As DataTable = clienteBLL.SearchClientesByName(name)

        If result.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron clientes con el nombre proporcionado.", "Resultado de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadClientes()
            Return
        End If

        DataGridView1.DataSource = result
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadClientes()
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub ResetForm()
        txtID.Clear()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtSearch.Clear()
    End Sub
End Class