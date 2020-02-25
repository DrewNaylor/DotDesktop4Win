<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class filePathEditor
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
        Me.tablelayoutpanelOkCancel = New System.Windows.Forms.TableLayoutPanel()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.labelEditFileList = New System.Windows.Forms.Label()
        Me.textboxEditStyleManually = New System.Windows.Forms.TextBox()
        Me.radiobuttonWindowsStyle = New System.Windows.Forms.RadioButton()
        Me.radiobuttonLinuxStyle = New System.Windows.Forms.RadioButton()
        Me.radiobuttonEditStyleManually = New System.Windows.Forms.RadioButton()
        Me.tablelayoutpanelOkCancel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tablelayoutpanelOkCancel
        '
        Me.tablelayoutpanelOkCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tablelayoutpanelOkCancel.ColumnCount = 2
        Me.tablelayoutpanelOkCancel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tablelayoutpanelOkCancel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tablelayoutpanelOkCancel.Controls.Add(Me.buttonOK, 0, 0)
        Me.tablelayoutpanelOkCancel.Controls.Add(Me.buttonCancel, 1, 0)
        Me.tablelayoutpanelOkCancel.Location = New System.Drawing.Point(415, 151)
        Me.tablelayoutpanelOkCancel.Name = "tablelayoutpanelOkCancel"
        Me.tablelayoutpanelOkCancel.RowCount = 1
        Me.tablelayoutpanelOkCancel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tablelayoutpanelOkCancel.Size = New System.Drawing.Size(146, 29)
        Me.tablelayoutpanelOkCancel.TabIndex = 0
        '
        'buttonOK
        '
        Me.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.buttonOK.Location = New System.Drawing.Point(3, 3)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(67, 23)
        Me.buttonOK.TabIndex = 0
        Me.buttonOK.Text = "OK"
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(76, 3)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(67, 23)
        Me.buttonCancel.TabIndex = 1
        Me.buttonCancel.Text = "Cancel"
        '
        'labelEditFileList
        '
        Me.labelEditFileList.AutoSize = True
        Me.labelEditFileList.Location = New System.Drawing.Point(13, 13)
        Me.labelEditFileList.Name = "labelEditFileList"
        Me.labelEditFileList.Size = New System.Drawing.Size(556, 26)
        Me.labelEditFileList.TabIndex = 1
        Me.labelEditFileList.Text = "Once you've made your changes to the file list (if any), please click OK." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you" &
    "'re editing the file list for WSL, please use single quotes instead of double qu" &
    "otes if there are spaces in the path."
        '
        'textboxEditStyleManually
        '
        Me.textboxEditStyleManually.Location = New System.Drawing.Point(16, 125)
        Me.textboxEditStyleManually.Name = "textboxEditStyleManually"
        Me.textboxEditStyleManually.Size = New System.Drawing.Size(548, 20)
        Me.textboxEditStyleManually.TabIndex = 2
        '
        'radiobuttonWindowsStyle
        '
        Me.radiobuttonWindowsStyle.AutoSize = True
        Me.radiobuttonWindowsStyle.Location = New System.Drawing.Point(16, 43)
        Me.radiobuttonWindowsStyle.Name = "radiobuttonWindowsStyle"
        Me.radiobuttonWindowsStyle.Size = New System.Drawing.Size(93, 17)
        Me.radiobuttonWindowsStyle.TabIndex = 3
        Me.radiobuttonWindowsStyle.TabStop = True
        Me.radiobuttonWindowsStyle.Text = "Windows-style"
        Me.radiobuttonWindowsStyle.UseVisualStyleBackColor = True
        '
        'radiobuttonLinuxStyle
        '
        Me.radiobuttonLinuxStyle.AutoSize = True
        Me.radiobuttonLinuxStyle.Location = New System.Drawing.Point(16, 67)
        Me.radiobuttonLinuxStyle.Name = "radiobuttonLinuxStyle"
        Me.radiobuttonLinuxStyle.Size = New System.Drawing.Size(74, 17)
        Me.radiobuttonLinuxStyle.TabIndex = 4
        Me.radiobuttonLinuxStyle.TabStop = True
        Me.radiobuttonLinuxStyle.Text = "Linux-style"
        Me.radiobuttonLinuxStyle.UseVisualStyleBackColor = True
        '
        'radiobuttonEditStyleManually
        '
        Me.radiobuttonEditStyleManually.AutoSize = True
        Me.radiobuttonEditStyleManually.Location = New System.Drawing.Point(16, 91)
        Me.radiobuttonEditStyleManually.Name = "radiobuttonEditStyleManually"
        Me.radiobuttonEditStyleManually.Size = New System.Drawing.Size(87, 17)
        Me.radiobuttonEditStyleManually.TabIndex = 5
        Me.radiobuttonEditStyleManually.TabStop = True
        Me.radiobuttonEditStyleManually.Text = "Edit manually"
        Me.radiobuttonEditStyleManually.UseVisualStyleBackColor = True
        '
        'filePathEditor
        '
        Me.AcceptButton = Me.buttonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(573, 192)
        Me.Controls.Add(Me.radiobuttonEditStyleManually)
        Me.Controls.Add(Me.radiobuttonLinuxStyle)
        Me.Controls.Add(Me.radiobuttonWindowsStyle)
        Me.Controls.Add(Me.textboxEditStyleManually)
        Me.Controls.Add(Me.labelEditFileList)
        Me.Controls.Add(Me.tablelayoutpanelOkCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "filePathEditor"
        Me.ShowInTaskbar = False
        Me.Text = "Edit file list"
        Me.tablelayoutpanelOkCancel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tablelayoutpanelOkCancel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents buttonOK As System.Windows.Forms.Button
    Friend WithEvents buttonCancel As System.Windows.Forms.Button
    Friend WithEvents labelEditFileList As Windows.Forms.Label
    Friend WithEvents textboxEditStyleManually As Windows.Forms.TextBox
    Friend WithEvents radiobuttonWindowsStyle As Windows.Forms.RadioButton
    Friend WithEvents radiobuttonLinuxStyle As Windows.Forms.RadioButton
    Friend WithEvents radiobuttonEditStyleManually As Windows.Forms.RadioButton
End Class
