<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTheme = New Label()
        cboTheme = New ComboBox()
        lblCodeTitle = New Label()
        txtPythonCode = New TextBox()
        btnRunCode = New Button()
        btnClear = New Button()
        lblOutputTitle = New Label()
        txtOutput = New TextBox()
        themePanel = New Panel()
        themePanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTheme
        ' 
        lblTheme.Font = New Font("Segoe UI", 9.0F)
        lblTheme.Location = New Point(10, 5)
        lblTheme.Name = "lblTheme"
        lblTheme.Size = New Size(77, 25)
        lblTheme.TabIndex = 0
        lblTheme.Text = "Theme:"
        lblTheme.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' cboTheme
        ' 
        cboTheme.Font = New Font("Segoe UI", 9.0F)
        cboTheme.Items.AddRange({"Light", "Dark"})
        cboTheme.Location = New Point(93, 2)
        cboTheme.Name = "cboTheme"
        cboTheme.Size = New Size(120, 33)
        cboTheme.TabIndex = 1
        ' 
        ' lblCodeTitle
        ' 
        lblCodeTitle.Dock = DockStyle.Top
        lblCodeTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblCodeTitle.Location = New Point(0, 35)
        lblCodeTitle.Name = "lblCodeTitle"
        lblCodeTitle.Padding = New Padding(10, 0, 0, 0)
        lblCodeTitle.Size = New Size(800, 28)
        lblCodeTitle.TabIndex = 2
        lblCodeTitle.Text = "Python Code Editor"
        ' 
        ' txtPythonCode
        ' 
        txtPythonCode.AcceptsTab = True
        txtPythonCode.Dock = DockStyle.Fill
        txtPythonCode.Font = New Font("Consolas", 10.5F)
        txtPythonCode.Location = New Point(0, 63)
        txtPythonCode.Multiline = True
        txtPythonCode.Name = "txtPythonCode"
        txtPythonCode.ScrollBars = ScrollBars.Both
        txtPythonCode.Size = New Size(800, 283)
        txtPythonCode.TabIndex = 3
        txtPythonCode.WordWrap = False
        ' 
        ' btnRunCode
        ' 
        btnRunCode.BackColor = Color.LightGreen
        btnRunCode.Dock = DockStyle.Left
        btnRunCode.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnRunCode.Location = New Point(0, 346)
        btnRunCode.Name = "btnRunCode"
        btnRunCode.Size = New Size(400, 35)
        btnRunCode.TabIndex = 4
        btnRunCode.Text = "Run Python Code"
        btnRunCode.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.LightSalmon
        btnClear.Dock = DockStyle.Left
        btnClear.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnClear.Location = New Point(400, 346)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(400, 35)
        btnClear.TabIndex = 5
        btnClear.Text = "Clear Output"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblOutputTitle
        ' 
        lblOutputTitle.Dock = DockStyle.Bottom
        lblOutputTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblOutputTitle.Location = New Point(0, 416)
        lblOutputTitle.Name = "lblOutputTitle"
        lblOutputTitle.Padding = New Padding(10, 0, 0, 0)
        lblOutputTitle.Size = New Size(800, 34)
        lblOutputTitle.TabIndex = 6
        lblOutputTitle.Text = "Output"
        ' 
        ' txtOutput
        ' 
        txtOutput.Dock = DockStyle.Bottom
        txtOutput.Font = New Font("Consolas", 10.0F)
        txtOutput.Location = New Point(0, 450)
        txtOutput.Multiline = True
        txtOutput.Name = "txtOutput"
        txtOutput.ReadOnly = True
        txtOutput.ScrollBars = ScrollBars.Both
        txtOutput.Size = New Size(800, 200)
        txtOutput.TabIndex = 7
        txtOutput.WordWrap = False
        ' 
        ' themePanel
        ' 
        themePanel.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        themePanel.BorderStyle = BorderStyle.FixedSingle
        themePanel.Controls.Add(lblTheme)
        themePanel.Controls.Add(cboTheme)
        themePanel.Dock = DockStyle.Top
        themePanel.Location = New Point(0, 0)
        themePanel.Name = "themePanel"
        themePanel.Padding = New Padding(10, 5, 0, 0)
        themePanel.Size = New Size(800, 35)
        themePanel.TabIndex = 8
        ' 
        ' frmMain
        ' 
        BackColor = Color.White
        ClientSize = New Size(800, 900)
        ' Create button panel for horizontal layout
        Dim buttonPanel As New Panel With {.Dock = DockStyle.Bottom, .Size = New Size(800, 35)}
        buttonPanel.Controls.Add(btnClear)
        buttonPanel.Controls.Add(btnRunCode)
        ' Add controls in proper order
        Controls.Add(txtPythonCode)
        Controls.Add(lblCodeTitle)
        Controls.Add(buttonPanel)
        Controls.Add(lblOutputTitle)
        Controls.Add(txtOutput)
        Controls.Add(themePanel)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Python Studio Mini - VB.NET WinForms Code Editor"
        themePanel.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents txtPythonCode As New TextBox()
    Private WithEvents btnRunCode As New Button()
    Private WithEvents txtOutput As New TextBox()
    Private WithEvents lblCodeTitle As New Label()
    Private WithEvents lblOutputTitle As New Label()
    Private WithEvents btnClear As New Button()
    Private WithEvents cboTheme As New ComboBox()
    Private WithEvents lblTheme As New Label()
    Friend WithEvents themePanel As Panel
End Class