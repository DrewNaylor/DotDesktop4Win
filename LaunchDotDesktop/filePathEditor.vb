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
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            If editBox.Text.StartsWith("/mnt") Then
                editBox.Text = editBox.Text.Remove(0, 5)
                Dim driveLetter As String = editBox.Text.Substring(0, 1).ToUpperInvariant
                editBox.Text = editBox.Text.Remove(0, 1)
                editBox.Text = driveLetter & ":" & editBox.Text
                editBox.Text = editBox.Text.Replace("/", "\")
            End If
        Next
    End Sub

    Private Sub radiobuttonLinuxStyle_Click(sender As Object, e As EventArgs) Handles radiobuttonLinuxStyle.Click
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            If editBox.Text.Remove(0, 1).StartsWith(":\") Then
                editBox.Text = editBox.Text.Remove(0, 5)
                Dim driveLetter As String = editBox.Text.Substring(0, 1).ToUpperInvariant
                editBox.Text = editBox.Text.Remove(0, 1)
                editBox.Text = driveLetter & ":" & editBox.Text
                editBox.Text = editBox.Text.Replace("/", "\")
            End If
        Next
    End Sub
End Class
