<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aaformMainWindow
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
        Me.menubarMainWindow = New System.Windows.Forms.MenuStrip()
        Me.tablelayoutpanelMainWindow = New System.Windows.Forms.TableLayoutPanel()
        Me.textboxDotDesktopFilePath = New System.Windows.Forms.TextBox()
        Me.buttonBrowse = New System.Windows.Forms.Button()
        Me.tabcontrolFileOutput = New System.Windows.Forms.TabControl()
        Me.tabpageInterpretation = New System.Windows.Forms.TabPage()
        Me.tabpageRawFile = New System.Windows.Forms.TabPage()
        Me.textboxRawFileOutput = New System.Windows.Forms.TextBox()
        Me.openfiledialogDotDesktopFile = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tablelayoutpanelMainWindow.SuspendLayout()
        Me.tabcontrolFileOutput.SuspendLayout()
        Me.tabpageInterpretation.SuspendLayout()
        Me.tabpageRawFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'menubarMainWindow
        '
        Me.menubarMainWindow.Location = New System.Drawing.Point(0, 0)
        Me.menubarMainWindow.Name = "menubarMainWindow"
        Me.menubarMainWindow.Size = New System.Drawing.Size(509, 24)
        Me.menubarMainWindow.TabIndex = 0
        Me.menubarMainWindow.Text = "MenuStrip1"
        '
        'tablelayoutpanelMainWindow
        '
        Me.tablelayoutpanelMainWindow.ColumnCount = 2
        Me.tablelayoutpanelMainWindow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelMainWindow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.textboxDotDesktopFilePath, 0, 0)
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.buttonBrowse, 1, 0)
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.tabcontrolFileOutput, 0, 1)
        Me.tablelayoutpanelMainWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablelayoutpanelMainWindow.Location = New System.Drawing.Point(0, 24)
        Me.tablelayoutpanelMainWindow.Name = "tablelayoutpanelMainWindow"
        Me.tablelayoutpanelMainWindow.RowCount = 2
        Me.tablelayoutpanelMainWindow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tablelayoutpanelMainWindow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelMainWindow.Size = New System.Drawing.Size(509, 359)
        Me.tablelayoutpanelMainWindow.TabIndex = 1
        '
        'textboxDotDesktopFilePath
        '
        Me.textboxDotDesktopFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxDotDesktopFilePath.Location = New System.Drawing.Point(3, 3)
        Me.textboxDotDesktopFilePath.Name = "textboxDotDesktopFilePath"
        Me.textboxDotDesktopFilePath.ReadOnly = True
        Me.textboxDotDesktopFilePath.Size = New System.Drawing.Size(406, 20)
        Me.textboxDotDesktopFilePath.TabIndex = 0
        '
        'buttonBrowse
        '
        Me.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonBrowse.Location = New System.Drawing.Point(415, 3)
        Me.buttonBrowse.Name = "buttonBrowse"
        Me.buttonBrowse.Size = New System.Drawing.Size(91, 23)
        Me.buttonBrowse.TabIndex = 1
        Me.buttonBrowse.Text = "Browse..."
        Me.buttonBrowse.UseVisualStyleBackColor = True
        '
        'tabcontrolFileOutput
        '
        Me.tablelayoutpanelMainWindow.SetColumnSpan(Me.tabcontrolFileOutput, 2)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageInterpretation)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageRawFile)
        Me.tabcontrolFileOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrolFileOutput.Location = New System.Drawing.Point(3, 32)
        Me.tabcontrolFileOutput.Name = "tabcontrolFileOutput"
        Me.tabcontrolFileOutput.SelectedIndex = 0
        Me.tabcontrolFileOutput.Size = New System.Drawing.Size(503, 324)
        Me.tabcontrolFileOutput.TabIndex = 2
        '
        'tabpageInterpretation
        '
        Me.tabpageInterpretation.Controls.Add(Me.Label4)
        Me.tabpageInterpretation.Controls.Add(Me.Label3)
        Me.tabpageInterpretation.Controls.Add(Me.Label2)
        Me.tabpageInterpretation.Controls.Add(Me.Label1)
        Me.tabpageInterpretation.Location = New System.Drawing.Point(4, 22)
        Me.tabpageInterpretation.Name = "tabpageInterpretation"
        Me.tabpageInterpretation.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageInterpretation.Size = New System.Drawing.Size(495, 298)
        Me.tabpageInterpretation.TabIndex = 0
        Me.tabpageInterpretation.Text = "File output: Interpretation"
        Me.tabpageInterpretation.UseVisualStyleBackColor = True
        '
        'tabpageRawFile
        '
        Me.tabpageRawFile.Controls.Add(Me.textboxRawFileOutput)
        Me.tabpageRawFile.Location = New System.Drawing.Point(4, 22)
        Me.tabpageRawFile.Name = "tabpageRawFile"
        Me.tabpageRawFile.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRawFile.Size = New System.Drawing.Size(495, 298)
        Me.tabpageRawFile.TabIndex = 1
        Me.tabpageRawFile.Text = "File output: Raw"
        Me.tabpageRawFile.UseVisualStyleBackColor = True
        '
        'textboxRawFileOutput
        '
        Me.textboxRawFileOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxRawFileOutput.Location = New System.Drawing.Point(3, 3)
        Me.textboxRawFileOutput.Multiline = True
        Me.textboxRawFileOutput.Name = "textboxRawFileOutput"
        Me.textboxRawFileOutput.ReadOnly = True
        Me.textboxRawFileOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxRawFileOutput.Size = New System.Drawing.Size(489, 292)
        Me.textboxRawFileOutput.TabIndex = 0
        '
        'openfiledialogDotDesktopFile
        '
        Me.openfiledialogDotDesktopFile.Filter = "Desktop files|*.desktop"
        Me.openfiledialogDotDesktopFile.Title = "Browse for .desktop file"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Exec: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "URL: "
        '
        'aaformMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(509, 383)
        Me.Controls.Add(Me.tablelayoutpanelMainWindow)
        Me.Controls.Add(Me.menubarMainWindow)
        Me.MainMenuStrip = Me.menubarMainWindow
        Me.Name = "aaformMainWindow"
        Me.Text = "ViewDotDesktop"
        Me.tablelayoutpanelMainWindow.ResumeLayout(False)
        Me.tablelayoutpanelMainWindow.PerformLayout()
        Me.tabcontrolFileOutput.ResumeLayout(False)
        Me.tabpageInterpretation.ResumeLayout(False)
        Me.tabpageInterpretation.PerformLayout()
        Me.tabpageRawFile.ResumeLayout(False)
        Me.tabpageRawFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menubarMainWindow As MenuStrip
    Friend WithEvents tablelayoutpanelMainWindow As TableLayoutPanel
    Friend WithEvents textboxDotDesktopFilePath As TextBox
    Friend WithEvents buttonBrowse As Button
    Friend WithEvents tabcontrolFileOutput As TabControl
    Friend WithEvents tabpageInterpretation As TabPage
    Friend WithEvents tabpageRawFile As TabPage
    Friend WithEvents textboxRawFileOutput As TextBox
    Friend WithEvents openfiledialogDotDesktopFile As OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
End Class
