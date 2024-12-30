Imports PRUEBADEMO.BLL

Public Class FrmSalesReport
    Private ReadOnly ventaBLL As New VentaBLL()

    Private Sub FrmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesReport()
    End Sub

    Private Sub LoadSalesReport()
        Dim salesReportTable As DataTable = ventaBLL.GetSalesReport()
        dgvSalesReport.DataSource = salesReportTable

        FormatDataGridView()
    End Sub

    Private Sub FormatDataGridView()
        With dgvSalesReport
            .Columns("SaleID").HeaderText = "ID de Venta"
            .Columns("ClientName").HeaderText = "Nombre del Cliente"
            .Columns("SaleDate").HeaderText = "Fecha de Venta"
            .Columns("ProductName").HeaderText = "Nombre del Producto"
            .Columns("Quantity").HeaderText = "Cantidad"
            .Columns("UnitPrice").HeaderText = "Precio Unitario"
            .Columns("Subtotal").HeaderText = "Subtotal"
            .Columns("SaleTotal").HeaderText = "Total"
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
    End Sub

End Class