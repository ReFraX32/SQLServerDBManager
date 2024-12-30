Imports PRUEBADEMO.BLL

Public Class FrmVentas
    Private ReadOnly ventaBLL As New VentaBLL()
    Private ReadOnly productoBLL As New ProductoBLL()
    Private ReadOnly clienteBLL As New ClienteBLL()
    Private ReadOnly items As New List(Of VentaItem)
    Private nextItemID As Integer = 1

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClientes()
        LoadProductos()

        lblTotal.Text = "0.00"
        lblTotal.BackColor = Color.LightGray
        lblTotal.ForeColor = Color.Black
        lblTotal.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub LoadClientes()
        Dim dt = clienteBLL.GetClientes()
        cmbClientes.DataSource = dt
        cmbClientes.DisplayMember = "Cliente"
        cmbClientes.ValueMember = "ID"
        cmbClientes.SelectedIndex = -1
    End Sub

    Private Sub LoadProductos()
        Dim dt = productoBLL.GetProductos()
        cmbProductos.DataSource = dt
        cmbProductos.DisplayMember = "Nombre"
        cmbProductos.ValueMember = "ID"
        cmbProductos.SelectedIndex = -1
    End Sub

    Private Sub BtnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If cmbProductos.SelectedItem Is Nothing OrElse Not Decimal.TryParse(txtCantidad.Text, Nothing) Then
            MessageBox.Show("Por favor seleccione un producto e ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedProduct = CType(cmbProductos.SelectedItem, DataRowView)
        Dim item As New VentaItem With {
            .ID = nextItemID,
            .IDProducto = selectedProduct("ID"),
            .Cantidad = Decimal.Parse(txtCantidad.Text),
            .PrecioUnitario = selectedProduct("Precio"),
            .PrecioTotal = Decimal.Parse(txtCantidad.Text) * selectedProduct("Precio")
        }
        items.Add(item)
        nextItemID += 1

        dgvItems.DataSource = Nothing
        dgvItems.DataSource = items

        dgvItems.Columns("ID").HeaderText = "ID del Artículo"
        dgvItems.Columns("IDVenta").Visible = False
        dgvItems.Columns("IDProducto").HeaderText = "ID del Producto"
        dgvItems.Columns("Cantidad").HeaderText = "Cantidad"
        dgvItems.Columns("PrecioUnitario").HeaderText = "Precio Unitario"
        dgvItems.Columns("PrecioTotal").HeaderText = "Precio Total"

        lblTotal.Text = items.Sum(Function(i) i.PrecioTotal).ToString("F2")
    End Sub

    Private Sub BtnSaveSale_Click(sender As Object, e As EventArgs) Handles btnSaveSale.Click
        If items.Count = 0 OrElse cmbClientes.SelectedValue Is Nothing Then
            MessageBox.Show("Por favor agregue productos y seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim ventaID = ventaBLL.AddVenta(CInt(cmbClientes.SelectedValue), dtpSaleDate.Value, items)
        If ventaID > 0 Then
            MessageBox.Show($"Venta guardada exitosamente con IDVenta = {ventaID}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetForm()
        End If
    End Sub

    Private Sub ResetForm()
        items.Clear()
        nextItemID = 1
        dgvItems.DataSource = Nothing
        lblTotal.Text = "0.00"
        txtCantidad.Clear()
        cmbClientes.SelectedIndex = -1
        cmbProductos.SelectedIndex = -1
    End Sub
End Class