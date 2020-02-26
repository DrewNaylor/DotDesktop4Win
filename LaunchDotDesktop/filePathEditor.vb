Imports System.Windows.Forms

Public Class filePathEditor

    ' Friend Shared filesInEditor As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub filePathEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'textboxEditStyleManually.Text = filesInEditor
    End Sub

    Private Sub radiobuttonWindowsStyle_Click(sender As Object, e As EventArgs) Handles radiobuttonWindowsStyle.Click
        ' Look at each textbox inside the flow layout panel.
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            ' Check to see if the textbox starts with "/mnt".
            If editBox.Text.StartsWith("/mnt") Then
                ' If it does, then remove "/mnt/" from the text.
                editBox.Text = editBox.Text.Remove(0, 5)
                ' Get the drive letter and capitalize it for later use.
                Dim driveLetter As String = editBox.Text.Substring(0, 1).ToUpperInvariant
                ' Remove the old drive letter since we're going to capitalize it.
                editBox.Text = editBox.Text.Remove(0, 1)
                ' Re-add the drive letter, and add a colon and the rest of the text.
                editBox.Text = driveLetter & ":" & editBox.Text
                ' Replace forward slashes with back slashes.
                editBox.Text = editBox.Text.Replace("/", "\")
            End If
        Next
    End Sub

    Private Sub radiobuttonLinuxStyle_Click(sender As Object, e As EventArgs) Handles radiobuttonLinuxStyle.Click
        ' Look at each textbox inside the flow layout panel.
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            ' Check from the first through the third characters to check that they're
            ' ":\" like the Windows path style without the drive letter.
            If editBox.Text.Substring(1, 2) = ":\" Then
                ' Grab the drive letter and make it lowercase for later use.
                Dim driveLetter As String = editBox.Text.Substring(0, 1).ToLowerInvariant
                ' Remove the drive letter and the colon.
                editBox.Text = editBox.Text.Remove(0, 2)
                ' Prepend "/mnt/" and the drive letter to the textbox text.
                editBox.Text = "/mnt/" & driveLetter & editBox.Text
                ' Replace back slashes with forward slashes.
                editBox.Text = editBox.Text.Replace("\", "/")
            End If
        Next
    End Sub
End Class
