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

    Private Sub radiobuttonWindowsStyle_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonWindowsStyle.CheckedChanged
        For Each textbox As TextBox In flowlayoutpanelFileList.Controls
            If textbox.Text.StartsWith("/mnt") Then
                textbox.Text = textbox.Text.Remove(0, 4)
                Dim driveLetter As String = textbox.Text.Substring(0, 1).ToUpperInvariant
                textbox.Text = textbox.Text.Remove(0, 1)
                textbox.Text = driveLetter & ":" & textbox.Text
                textbox.Text = textbox.Text.Replace("/", "\")
            End If
        Next
    End Sub
End Class
