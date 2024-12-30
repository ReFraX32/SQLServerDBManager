Imports PRUEBADEMO.BLL

Public Class FrmProductReport
    Private ReadOnly productoBLL As New ProductoBLL()

    Private Sub FrmProductReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductReport()
    End Sub

    Private Sub LoadProductReport()
        Dim productReportTable As DataTable = productoBLL.GetProductReport()
        dgvProductReport.DataSource = productReportTable

        FormatDataGridView()
    End Sub

    Private Sub FormatDataGridView()
        With dgvProductReport
            .Columns("ProductName").HeaderText = "Nombre del Producto"
            .Columns("Month").HeaderText = "Mes"
            .Columns("QuantitySold").HeaderText = "Cantidad Vendida"
            .Columns("TotalRevenue").HeaderText = "Ingresos Totales"
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