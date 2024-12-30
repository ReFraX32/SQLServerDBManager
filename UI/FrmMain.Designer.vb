<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnSearchVentas = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.btnSalesReport = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnProductReport = New System.Windows.Forms.Button()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlSidebar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.Label6)
        Me.pnlSidebar.Controls.Add(Me.PictureBox1)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 450)
        Me.pnlSidebar.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Aqua
        Me.Label6.Location = New System.Drawing.Point(51, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Selector de Servicios"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UI.My.Resources.Resources.Main_Screen
        Me.PictureBox1.Location = New System.Drawing.Point(36, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(122, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnClientes)
        Me.Panel1.Controls.Add(Me.btnSearchVentas)
        Me.Panel1.Controls.Add(Me.btnProductos)
        Me.Panel1.Controls.Add(Me.btnSalesReport)
        Me.Panel1.Controls.Add(Me.btnVentas)
        Me.Panel1.Controls.Add(Me.btnProductReport)
        Me.Panel1.Location = New System.Drawing.Point(3, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 305)
        Me.Panel1.TabIndex = 7
        '
        'btnClientes
        '
        Me.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClientes.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnClientes.Location = New System.Drawing.Point(0, 3)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnClientes.Size = New System.Drawing.Size(194, 41)
        Me.btnClientes.TabIndex = 0
        Me.btnClientes.Text = "Gestor de Clientes"
        Me.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnSearchVentas
        '
        Me.btnSearchVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVentas.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnSearchVentas.Location = New System.Drawing.Point(0, 252)
        Me.btnSearchVentas.Name = "btnSearchVentas"
        Me.btnSearchVentas.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnSearchVentas.Size = New System.Drawing.Size(194, 45)
        Me.btnSearchVentas.TabIndex = 5
        Me.btnSearchVentas.Text = "Búsqueda de Ventas"
        Me.btnSearchVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearchVentas.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductos.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnProductos.Location = New System.Drawing.Point(-1, 41)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnProductos.Size = New System.Drawing.Size(194, 45)
        Me.btnProductos.TabIndex = 1
        Me.btnProductos.Text = "Gestor de Productos"
        Me.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnSalesReport
        '
        Me.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesReport.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnSalesReport.Location = New System.Drawing.Point(-1, 143)
        Me.btnSalesReport.Name = "btnSalesReport"
        Me.btnSalesReport.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnSalesReport.Size = New System.Drawing.Size(194, 45)
        Me.btnSalesReport.TabIndex = 3
        Me.btnSalesReport.Text = "Reporte de Ventas"
        Me.btnSalesReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesReport.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVentas.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnVentas.Location = New System.Drawing.Point(-1, 92)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnVentas.Size = New System.Drawing.Size(194, 45)
        Me.btnVentas.TabIndex = 2
        Me.btnVentas.Text = "Gestor de Ventas"
        Me.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnProductReport
        '
        Me.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductReport.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnProductReport.Location = New System.Drawing.Point(-1, 201)
        Me.btnProductReport.Name = "btnProductReport"
        Me.btnProductReport.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnProductReport.Size = New System.Drawing.Size(194, 45)
        Me.btnProductReport.TabIndex = 4
        Me.btnProductReport.Text = "Reporte de Productos"
        Me.btnProductReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductReport.UseVisualStyleBackColor = True
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(200, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(600, 450)
        Me.pnlContent.TabIndex = 1
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSidebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "Gestor de Negocio y Base de Datos"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents btnSearchVentas As Button
    Friend WithEvents btnProductReport As Button
    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnVentas As Button
    Friend WithEvents btnProductos As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
End Class
