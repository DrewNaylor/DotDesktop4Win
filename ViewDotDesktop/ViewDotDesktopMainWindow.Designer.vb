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
        Me.menuitemFileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemOpenItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemHelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemAboutItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tablelayoutpanelMainWindow = New System.Windows.Forms.TableLayoutPanel()
        Me.textboxDotDesktopFilePath = New System.Windows.Forms.TextBox()
        Me.buttonBrowse = New System.Windows.Forms.Button()
        Me.tabcontrolFileOutput = New System.Windows.Forms.TabControl()
        Me.tabpageInterpreterOutput = New System.Windows.Forms.TabPage()
        Me.tablelayoutpanelInterpreter = New System.Windows.Forms.TableLayoutPanel()
        Me.linklabelFDOSpec = New System.Windows.Forms.LinkLabel()
        Me.labelInterpreterHeader = New System.Windows.Forms.Label()
        Me.textboxInterpreterOutput = New System.Windows.Forms.TextBox()
        Me.tabpageRawFile = New System.Windows.Forms.TabPage()
        Me.textboxRawFileOutput = New System.Windows.Forms.TextBox()
        Me.openfiledialogDotDesktopFile = New System.Windows.Forms.OpenFileDialog()
        Me.menubarMainWindow.SuspendLayout()
        Me.tablelayoutpanelMainWindow.SuspendLayout()
        Me.tabcontrolFileOutput.SuspendLayout()
        Me.tabpageInterpreterOutput.SuspendLayout()
        Me.tablelayoutpanelInterpreter.SuspendLayout()
        Me.tabpageRawFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'menubarMainWindow
        '
        Me.menubarMainWindow.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menubarMainWindow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemFileMenu, Me.menuitemHelpMenu})
        Me.menubarMainWindow.Location = New System.Drawing.Point(0, 0)
        Me.menubarMainWindow.Name = "menubarMainWindow"
        Me.menubarMainWindow.Size = New System.Drawing.Size(382, 24)
        Me.menubarMainWindow.TabIndex = 0
        Me.menubarMainWindow.Text = "MenuStrip1"
        '
        'menuitemFileMenu
        '
        Me.menuitemFileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemOpenItem, Me.menuitemExitItem})
        Me.menuitemFileMenu.Name = "menuitemFileMenu"
        Me.menuitemFileMenu.Size = New System.Drawing.Size(37, 20)
        Me.menuitemFileMenu.Text = "&File"
        '
        'menuitemOpenItem
        '
        Me.menuitemOpenItem.Name = "menuitemOpenItem"
        Me.menuitemOpenItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.menuitemOpenItem.Size = New System.Drawing.Size(174, 22)
        Me.menuitemOpenItem.Text = "&Open file..."
        '
        'menuitemExitItem
        '
        Me.menuitemExitItem.Name = "menuitemExitItem"
        Me.menuitemExitItem.Size = New System.Drawing.Size(174, 22)
        Me.menuitemExitItem.Text = "E&xit"
        '
        'menuitemHelpMenu
        '
        Me.menuitemHelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemAboutItem})
        Me.menuitemHelpMenu.Name = "menuitemHelpMenu"
        Me.menuitemHelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.menuitemHelpMenu.Text = "&Help"
        '
        'menuitemAboutItem
        '
        Me.menuitemAboutItem.Name = "menuitemAboutItem"
        Me.menuitemAboutItem.Size = New System.Drawing.Size(152, 22)
        Me.menuitemAboutItem.Text = "&About"
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
        Me.tablelayoutpanelMainWindow.Size = New System.Drawing.Size(382, 244)
        Me.tablelayoutpanelMainWindow.TabIndex = 1
        '
        'textboxDotDesktopFilePath
        '
        Me.textboxDotDesktopFilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxDotDesktopFilePath.Location = New System.Drawing.Point(3, 3)
        Me.textboxDotDesktopFilePath.Name = "textboxDotDesktopFilePath"
        Me.textboxDotDesktopFilePath.ReadOnly = True
        Me.textboxDotDesktopFilePath.Size = New System.Drawing.Size(279, 20)
        Me.textboxDotDesktopFilePath.TabIndex = 0
        '
        'buttonBrowse
        '
        Me.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonBrowse.Location = New System.Drawing.Point(288, 3)
        Me.buttonBrowse.Name = "buttonBrowse"
        Me.buttonBrowse.Size = New System.Drawing.Size(91, 23)
        Me.buttonBrowse.TabIndex = 1
        Me.buttonBrowse.Text = "Browse..."
        Me.buttonBrowse.UseVisualStyleBackColor = True
        '
        'tabcontrolFileOutput
        '
        Me.tablelayoutpanelMainWindow.SetColumnSpan(Me.tabcontrolFileOutput, 2)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageInterpreterOutput)
        Me.tabcontrolFileOutput.Controls.Add(Me.tabpageRawFile)
        Me.tabcontrolFileOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrolFileOutput.Location = New System.Drawing.Point(3, 32)
        Me.tabcontrolFileOutput.Name = "tabcontrolFileOutput"
        Me.tabcontrolFileOutput.SelectedIndex = 0
        Me.tabcontrolFileOutput.Size = New System.Drawing.Size(376, 209)
        Me.tabcontrolFileOutput.TabIndex = 2
        '
        'tabpageInterpreterOutput
        '
        Me.tabpageInterpreterOutput.Controls.Add(Me.tablelayoutpanelInterpreter)
        Me.tabpageInterpreterOutput.Location = New System.Drawing.Point(4, 22)
        Me.tabpageInterpreterOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.tabpageInterpreterOutput.Name = "tabpageInterpreterOutput"
        Me.tabpageInterpreterOutput.Padding = New System.Windows.Forms.Padding(2)
        Me.tabpageInterpreterOutput.Size = New System.Drawing.Size(368, 183)
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
        Me.tablelayoutpanelInterpreter.Location = New System.Drawing.Point(2, 2)
        Me.tablelayoutpanelInterpreter.Margin = New System.Windows.Forms.Padding(2)
        Me.tablelayoutpanelInterpreter.Name = "tablelayoutpanelInterpreter"
        Me.tablelayoutpanelInterpreter.RowCount = 3
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tablelayoutpanelInterpreter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tablelayoutpanelInterpreter.Size = New System.Drawing.Size(364, 179)
        Me.tablelayoutpanelInterpreter.TabIndex = 0
        '
        'linklabelFDOSpec
        '
        Me.linklabelFDOSpec.AutoSize = True
        Me.linklabelFDOSpec.Location = New System.Drawing.Point(3, 163)
        Me.linklabelFDOSpec.Name = "linklabelFDOSpec"
        Me.linklabelFDOSpec.Size = New System.Drawing.Size(221, 13)
        Me.linklabelFDOSpec.TabIndex = 7
        Me.linklabelFDOSpec.TabStop = True
        Me.linklabelFDOSpec.Text = "Latest Freedesktop.org Desktop Entry spec..."
        '
        'labelInterpreterHeader
        '
        Me.labelInterpreterHeader.AutoSize = True
        Me.labelInterpreterHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInterpreterHeader.Location = New System.Drawing.Point(3, 0)
        Me.labelInterpreterHeader.Name = "labelInterpreterHeader"
        Me.labelInterpreterHeader.Size = New System.Drawing.Size(224, 16)
        Me.labelInterpreterHeader.TabIndex = 5
        Me.labelInterpreterHeader.Text = "How libdotdesktop interprets this file:"
        '
        'textboxInterpreterOutput
        '
        Me.textboxInterpreterOutput.BackColor = System.Drawing.SystemColors.Window
        Me.textboxInterpreterOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textboxInterpreterOutput.Location = New System.Drawing.Point(2, 18)
        Me.textboxInterpreterOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.textboxInterpreterOutput.Multiline = True
        Me.textboxInterpreterOutput.Name = "textboxInterpreterOutput"
        Me.textboxInterpreterOutput.ReadOnly = True
        Me.textboxInterpreterOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxInterpreterOutput.Size = New System.Drawing.Size(360, 143)
        Me.textboxInterpreterOutput.TabIndex = 6
        '
        'tabpageRawFile
        '
        Me.tabpageRawFile.Controls.Add(Me.textboxRawFileOutput)
        Me.tabpageRawFile.Location = New System.Drawing.Point(4, 22)
        Me.tabpageRawFile.Name = "tabpageRawFile"
        Me.tabpageRawFile.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRawFile.Size = New System.Drawing.Size(368, 183)
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
        Me.textboxRawFileOutput.Size = New System.Drawing.Size(362, 177)
        Me.textboxRawFileOutput.TabIndex = 0
        '
        'openfiledialogDotDesktopFile
        '
        Me.openfiledialogDotDesktopFile.Filter = "Desktop files|*.desktop"
        Me.openfiledialogDotDesktopFile.Title = "Browse for .desktop file"
        '
        'aaformMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(382, 268)
        Me.Controls.Add(Me.tablelayoutpanelMainWindow)
        Me.Controls.Add(Me.menubarMainWindow)
        Me.MainMenuStrip = Me.menubarMainWindow
        Me.Name = "aaformMainWindow"
        Me.Text = "ViewDotDesktop"
        Me.menubarMainWindow.ResumeLayout(False)
        Me.menubarMainWindow.PerformLayout()
        Me.tablelayoutpanelMainWindow.ResumeLayout(False)
        Me.tablelayoutpanelMainWindow.PerformLayout()
        Me.tabcontrolFileOutput.ResumeLayout(False)
        Me.tabpageInterpreterOutput.ResumeLayout(False)
        Me.tablelayoutpanelInterpreter.ResumeLayout(False)
        Me.tablelayoutpanelInterpreter.PerformLayout()
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
    Friend WithEvents tabpageRawFile As TabPage
    Friend WithEvents textboxRawFileOutput As TextBox
    Friend WithEvents openfiledialogDotDesktopFile As OpenFileDialog
    Friend WithEvents tabpageInterpreterOutput As TabPage
    Friend WithEvents tablelayoutpanelInterpreter As TableLayoutPanel
    Friend WithEvents labelInterpreterHeader As Label
    Friend WithEvents textboxInterpreterOutput As TextBox
    Friend WithEvents linklabelFDOSpec As LinkLabel
    Friend WithEvents menuitemFileMenu As ToolStripMenuItem
    Friend WithEvents menuitemExitItem As ToolStripMenuItem
    Friend WithEvents menuitemHelpMenu As ToolStripMenuItem
    Friend WithEvents menuitemAboutItem As ToolStripMenuItem
    Friend WithEvents menuitemOpenItem As ToolStripMenuItem
End Class
