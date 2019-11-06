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
        Me.linklabelDesktopEntrySpec = New System.Windows.Forms.LinkLabel()
        Me.labelHeaderInfoText = New System.Windows.Forms.Label()
        Me.labelUrlKey = New System.Windows.Forms.Label()
        Me.labelExecKey = New System.Windows.Forms.Label()
        Me.labelNameKey = New System.Windows.Forms.Label()
        Me.labelTypeKey = New System.Windows.Forms.Label()
        Me.tabpageRawFile = New System.Windows.Forms.TabPage()
        Me.textboxRawFileOutput = New System.Windows.Forms.TextBox()
        Me.openfiledialogDotDesktopFile = New System.Windows.Forms.OpenFileDialog()
        Me.tabpageInterpreterOutput = New System.Windows.Forms.TabPage()
        Me.tablelayoutpanelInterpreter = New System.Windows.Forms.TableLayoutPanel()
        Me.labelInterpreterHeader = New System.Windows.Forms.Label()
        Me.textboxInterpreterOutput = New System.Windows.Forms.TextBox()
        Me.linklabelFDOSpec = New System.Windows.Forms.LinkLabel()
        Me.tablelayoutpanelMainWindow.SuspendLayout()
        Me.tabcontrolFileOutput.SuspendLayout()
        Me.tabpageInterpretation.SuspendLayout()
        Me.tabpageRawFile.SuspendLayout()
        Me.tabpageInterpreterOutput.SuspendLayout()
        Me.tablelayoutpanelInterpreter.SuspendLayout()
        Me.SuspendLayout()
        '
        'menubarMainWindow
        '
        Me.menubarMainWindow.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menubarMainWindow.Location = New System.Drawing.Point(0, 0)
        Me.menubarMainWindow.Name = "menubarMainWindow"
        Me.menubarMainWindow.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.menubarMainWindow.Size = New System.Drawing.Size(478, 24)
        Me.menubarMainWindow.TabIndex = 0
        Me.menubarMainWindow.Text = "MenuStrip1"
        '
        'tablelayoutpanelMainWindow
        '
        Me.tablelayoutpanelMainWindow.ColumnCount = 2
        Me.tablelayoutpanelMainWindow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelMainWindow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.textboxDotDesktopFilePath, 0, 0)
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.buttonBrowse, 1, 0)
        Me.tablelayoutpanelMainWindow.Controls.Add(Me.tabcontrolFileOutput, 0, 1)
        Me.tablelayoutpanelMainWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablelayoutpanelMainWindow.Location = New System.Drawing.Point(0, 24)
        Me.tablelayoutpanelMainWindow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tablelayoutpanelMainWindow.Name = "tablelayoutpanelMainWindow"
        Me.tablelayoutpanelMainWindow.RowCount = 2
        Me.tablelayoutpanelMainWindow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tablelayoutpanelMainWindow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelMainWindow.Size = New System.Drawing.Size(478, 311)
        Me.tablelayoutpanelMainWindow.TabIndex = 1
        '
        'textboxDotDesktopFilePath
        '
        Me.textboxDotDesktopFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxDotDesktopFilePath.Location = New System.Drawing.Point(4, 4)
        Me.textboxDotDesktopFilePath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.textboxDotDesktopFilePath.Name = "textboxDotDesktopFilePath"
        Me.textboxDotDesktopFilePath.ReadOnly = True
        Me.textboxDotDesktopFilePath.Size = New System.Drawing.Size(349, 22)
        Me.textboxDotDesktopFilePath.TabIndex = 0
        '
        'buttonBrowse
        '
        Me.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonBrowse.Location = New System.Drawing.Point(361, 4)
        Me.buttonBrowse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.buttonBrowse.Name = "buttonBrowse"
        Me.buttonBrowse.Size = New System.Drawing.Size(113, 28)
        Me.buttonBrowse.TabIndex = 1
        Me.buttonBrowse.Text = "Browse..."
        Me.buttonBrowse.UseVisualStyleBackColor = True
        '
        'tabcontrolFileOutput
        '
        Me.tablelayoutpanelMainWindow.SetColumnSpan(Me.tabcontrolFileOutput, 2)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageInterpretation)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageInterpreterOutput)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageRawFile)
        Me.tabcontrolFileOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrolFileOutput.Location = New System.Drawing.Point(4, 40)
        Me.tabcontrolFileOutput.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabcontrolFileOutput.Name = "tabcontrolFileOutput"
        Me.tabcontrolFileOutput.SelectedIndex = 0
        Me.tabcontrolFileOutput.Size = New System.Drawing.Size(470, 267)
        Me.tabcontrolFileOutput.TabIndex = 2
        '
        'tabpageInterpretation
        '
        Me.tabpageInterpretation.Controls.Add(Me.linklabelDesktopEntrySpec)
        Me.tabpageInterpretation.Controls.Add(Me.labelHeaderInfoText)
        Me.tabpageInterpretation.Controls.Add(Me.labelUrlKey)
        Me.tabpageInterpretation.Controls.Add(Me.labelExecKey)
        Me.tabpageInterpretation.Controls.Add(Me.labelNameKey)
        Me.tabpageInterpretation.Controls.Add(Me.labelTypeKey)
        Me.tabpageInterpretation.Location = New System.Drawing.Point(4, 25)
        Me.tabpageInterpretation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabpageInterpretation.Name = "tabpageInterpretation"
        Me.tabpageInterpretation.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabpageInterpretation.Size = New System.Drawing.Size(462, 238)
        Me.tabpageInterpretation.TabIndex = 0
        Me.tabpageInterpretation.Text = "File output: Interpretation"
        Me.tabpageInterpretation.UseVisualStyleBackColor = True
        '
        'linklabelDesktopEntrySpec
        '
        Me.linklabelDesktopEntrySpec.AutoSize = True
        Me.linklabelDesktopEntrySpec.Location = New System.Drawing.Point(11, 205)
        Me.linklabelDesktopEntrySpec.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linklabelDesktopEntrySpec.Name = "linklabelDesktopEntrySpec"
        Me.linklabelDesktopEntrySpec.Size = New System.Drawing.Size(294, 17)
        Me.linklabelDesktopEntrySpec.TabIndex = 5
        Me.linklabelDesktopEntrySpec.TabStop = True
        Me.linklabelDesktopEntrySpec.Text = "Latest Freedesktop.org Desktop Entry spec..."
        '
        'labelHeaderInfoText
        '
        Me.labelHeaderInfoText.AutoSize = True
        Me.labelHeaderInfoText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHeaderInfoText.Location = New System.Drawing.Point(11, 9)
        Me.labelHeaderInfoText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelHeaderInfoText.Name = "labelHeaderInfoText"
        Me.labelHeaderInfoText.Size = New System.Drawing.Size(286, 20)
        Me.labelHeaderInfoText.TabIndex = 4
        Me.labelHeaderInfoText.Text = "How libdotdesktop interprets this file:"
        '
        'labelUrlKey
        '
        Me.labelUrlKey.AutoSize = True
        Me.labelUrlKey.Location = New System.Drawing.Point(8, 102)
        Me.labelUrlKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelUrlKey.Name = "labelUrlKey"
        Me.labelUrlKey.Size = New System.Drawing.Size(44, 17)
        Me.labelUrlKey.TabIndex = 3
        Me.labelUrlKey.Text = "URL: "
        '
        'labelExecKey
        '
        Me.labelExecKey.AutoSize = True
        Me.labelExecKey.Location = New System.Drawing.Point(8, 86)
        Me.labelExecKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelExecKey.Name = "labelExecKey"
        Me.labelExecKey.Size = New System.Drawing.Size(46, 17)
        Me.labelExecKey.TabIndex = 2
        Me.labelExecKey.Text = "Exec: "
        '
        'labelNameKey
        '
        Me.labelNameKey.AutoSize = True
        Me.labelNameKey.Location = New System.Drawing.Point(8, 70)
        Me.labelNameKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelNameKey.Name = "labelNameKey"
        Me.labelNameKey.Size = New System.Drawing.Size(53, 17)
        Me.labelNameKey.TabIndex = 1
        Me.labelNameKey.Text = "Name: "
        '
        'labelTypeKey
        '
        Me.labelTypeKey.AutoSize = True
        Me.labelTypeKey.Location = New System.Drawing.Point(8, 54)
        Me.labelTypeKey.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTypeKey.Name = "labelTypeKey"
        Me.labelTypeKey.Size = New System.Drawing.Size(48, 17)
        Me.labelTypeKey.TabIndex = 0
        Me.labelTypeKey.Text = "Type: "
        '
        'tabpageRawFile
        '
        Me.tabpageRawFile.Controls.Add(Me.textboxRawFileOutput)
        Me.tabpageRawFile.Location = New System.Drawing.Point(4, 25)
        Me.tabpageRawFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabpageRawFile.Name = "tabpageRawFile"
        Me.tabpageRawFile.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabpageRawFile.Size = New System.Drawing.Size(462, 238)
        Me.tabpageRawFile.TabIndex = 1
        Me.tabpageRawFile.Text = "File output: Raw"
        Me.tabpageRawFile.UseVisualStyleBackColor = True
        '
        'textboxRawFileOutput
        '
        Me.textboxRawFileOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxRawFileOutput.Location = New System.Drawing.Point(4, 4)
        Me.textboxRawFileOutput.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.textboxRawFileOutput.Multiline = True
        Me.textboxRawFileOutput.Name = "textboxRawFileOutput"
        Me.textboxRawFileOutput.ReadOnly = True
        Me.textboxRawFileOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxRawFileOutput.Size = New System.Drawing.Size(454, 230)
        Me.textboxRawFileOutput.TabIndex = 0
        '
        'openfiledialogDotDesktopFile
        '
        Me.openfiledialogDotDesktopFile.Filter = "Desktop files|*.desktop"
        Me.openfiledialogDotDesktopFile.Title = "Browse for .desktop file"
        '
        'tabpageInterpreterOutput
        '
        Me.tabpageInterpreterOutput.Controls.Add(Me.tablelayoutpanelInterpreter)
        Me.tabpageInterpreterOutput.Location = New System.Drawing.Point(4, 25)
        Me.tabpageInterpreterOutput.Name = "tabpageInterpreterOutput"
        Me.tabpageInterpreterOutput.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageInterpreterOutput.Size = New System.Drawing.Size(462, 238)
        Me.tabpageInterpreterOutput.TabIndex = 2
        Me.tabpageInterpreterOutput.Text = "File output: Interpreter"
        Me.tabpageInterpreterOutput.UseVisualStyleBackColor = True
        '
        'tablelayoutpanelInterpreter
        '
        Me.tablelayoutpanelInterpreter.ColumnCount = 1
        Me.tablelayoutpanelInterpreter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelInterpreter.Controls.Add(Me.linklabelFDOSpec, 0, 2)
        Me.tablelayoutpanelInterpreter.Controls.Add(Me.labelInterpreterHeader, 0, 0)
        Me.tablelayoutpanelInterpreter.Controls.Add(Me.textboxInterpreterOutput, 0, 1)
        Me.tablelayoutpanelInterpreter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablelayoutpanelInterpreter.Location = New System.Drawing.Point(3, 3)
        Me.tablelayoutpanelInterpreter.Name = "tablelayoutpanelInterpreter"
        Me.tablelayoutpanelInterpreter.RowCount = 3
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tablelayoutpanelInterpreter.Size = New System.Drawing.Size(456, 232)
        Me.tablelayoutpanelInterpreter.TabIndex = 0
        '
        'labelInterpreterHeader
        '
        Me.labelInterpreterHeader.AutoSize = True
        Me.labelInterpreterHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInterpreterHeader.Location = New System.Drawing.Point(4, 0)
        Me.labelInterpreterHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelInterpreterHeader.Name = "labelInterpreterHeader"
        Me.labelInterpreterHeader.Size = New System.Drawing.Size(286, 20)
        Me.labelInterpreterHeader.TabIndex = 5
        Me.labelInterpreterHeader.Text = "How libdotdesktop interprets this file:"
        '
        'textboxInterpreterOutput
        '
        Me.textboxInterpreterOutput.BackColor = System.Drawing.SystemColors.Window
        Me.textboxInterpreterOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxInterpreterOutput.Location = New System.Drawing.Point(3, 23)
        Me.textboxInterpreterOutput.Multiline = True
        Me.textboxInterpreterOutput.Name = "textboxInterpreterOutput"
        Me.textboxInterpreterOutput.ReadOnly = True
        Me.textboxInterpreterOutput.Size = New System.Drawing.Size(450, 186)
        Me.textboxInterpreterOutput.TabIndex = 6
        '
        'linklabelFDOSpec
        '
        Me.linklabelFDOSpec.AutoSize = True
        Me.linklabelFDOSpec.Location = New System.Drawing.Point(4, 212)
        Me.linklabelFDOSpec.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linklabelFDOSpec.Name = "linklabelFDOSpec"
        Me.linklabelFDOSpec.Size = New System.Drawing.Size(294, 17)
        Me.linklabelFDOSpec.TabIndex = 7
        Me.linklabelFDOSpec.TabStop = True
        Me.linklabelFDOSpec.Text = "Latest Freedesktop.org Desktop Entry spec..."
        '
        'aaformMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(478, 335)
        Me.Controls.Add(Me.tablelayoutpanelMainWindow)
        Me.Controls.Add(Me.menubarMainWindow)
        Me.MainMenuStrip = Me.menubarMainWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "aaformMainWindow"
        Me.Text = "ViewDotDesktop"
        Me.tablelayoutpanelMainWindow.ResumeLayout(False)
        Me.tablelayoutpanelMainWindow.PerformLayout()
        Me.tabcontrolFileOutput.ResumeLayout(False)
        Me.tabpageInterpretation.ResumeLayout(False)
        Me.tabpageInterpretation.PerformLayout()
        Me.tabpageRawFile.ResumeLayout(False)
        Me.tabpageRawFile.PerformLayout()
        Me.tabpageInterpreterOutput.ResumeLayout(False)
        Me.tablelayoutpanelInterpreter.ResumeLayout(False)
        Me.tablelayoutpanelInterpreter.PerformLayout()
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
    Friend WithEvents labelExecKey As Label
    Friend WithEvents labelNameKey As Label
    Friend WithEvents labelTypeKey As Label
    Friend WithEvents labelUrlKey As Label
    Friend WithEvents labelHeaderInfoText As Label
    Friend WithEvents linklabelDesktopEntrySpec As LinkLabel
    Friend WithEvents tabpageInterpreterOutput As TabPage
    Friend WithEvents tablelayoutpanelInterpreter As TableLayoutPanel
    Friend WithEvents labelInterpreterHeader As Label
    Friend WithEvents textboxInterpreterOutput As TextBox
    Friend WithEvents linklabelFDOSpec As LinkLabel
End Class
