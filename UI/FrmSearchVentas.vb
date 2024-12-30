Imports PRUEBADEMO.BLL

Public Class FrmSearchVentas
    Private ReadOnly ventaBLL As New VentaBLL()

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim clientName As String = txtClientName.Text.Trim()
        Dim saleID As Integer? = If(String.IsNullOrEmpty(txtSaleID.Text), CType(Nothing, Integer?), Convert.ToInt32(txtSaleID.Text))
        Dim startDate As DateTime? = If(chkUseDateRange.Checked, dtpStartDate.Value.Date, CType(Nothing, DateTime?))
        Dim endDate As DateTime? = If(chkUseDateRange.Checked, dtpEndDate.Value.Date.AddDays(1).AddTicks(-1), CType(Nothing, DateTime?))

        If String.IsNullOrEmpty(clientName) AndAlso Not saleID.HasValue AndAlso Not chkUseDateRange.Checked Then
            LoadAllSales()
            Return
        End If

        Dim salesTable As DataTable = ventaBLL.SearchVentas(clientName, saleID, startDate, endDate)

        dgvSales.DataSource = salesTable
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtClientName.Clear()
        txtSaleID.Clear()
        chkUseDateRange.Checked = False
        dgvSales.DataSource = Nothing
        LoadAllSales()
    End Sub

    Private Sub ChkUseDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDateRange.CheckedChanged
        dtpStartDate.Enabled = chkUseDateRange.Checked
        dtpEndDate.Enabled = chkUseDateRange.Checked
    End Sub

    Private Sub FrmSearchVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStartDate.Enabled = False
        dtpEndDate.Enabled = False

        LoadAllSales()
    End Sub

    Private Sub LoadAllSales()
        Try
            Dim salesTable As DataTable = ventaBLL.SearchVentas("", Nothing, Nothing, Nothing)

            dgvSales.DataSource = salesTable
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cargar los datos de ventas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
    End Sub
End Class