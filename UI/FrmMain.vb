Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm(New FrmClientes())
    End Sub

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        LoadForm(New FrmClientes())
    End Sub

    Private Sub BtnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        LoadForm(New FrmProductos())
    End Sub

    Private Sub BtnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        LoadForm(New FrmVentas())
    End Sub

    Private Sub BtnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        LoadForm(New FrmSalesReport())
    End Sub

    Private Sub BtnProductReport_Click(sender As Object, e As EventArgs) Handles btnProductReport.Click
        LoadForm(New FrmProductReport())
    End Sub

    Private Sub BtnSearchVentas_Click(sender As Object, e As EventArgs) Handles btnSearchVentas.Click
        LoadForm(New FrmSearchVentas())
    End Sub

    Private Sub LoadForm(form As Form)
        pnlContent.Controls.Clear()
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        pnlContent.Controls.Add(form)
        form.Show()
    End Sub
End Class