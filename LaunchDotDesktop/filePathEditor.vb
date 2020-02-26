' LaunchDotDesktop - Launch .desktop files as parsed by the DotDesktop4Win
' partial implementation of Freedesktop.org's Desktop Entry spec.
' Copyright 2019-2020 Drew Naylor
' (Note that the copyright years include the years left out by the hyphen.)
'
' This file is a part of the DotDesktop4Win project.
' Neither DotDesktop4Win nor Drew Naylor are associated with Freedesktop.org.
'
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.




Imports System.Windows.Forms

Public Class filePathEditor


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub filePathEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure to check the Windows-style radio button and run the code it uses
        ' to enable/disable it and stuff.
        radiobuttonWindowsStyle.Checked = True
        checkedWindowsStyleRadioButton()
    End Sub

    Private Sub checkedWindowsStyleRadioButton()
        ' Look at each textbox inside the flow layout panel.
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            ' Disable textboxes to prevent accidental edits.
            editBox.Enabled = False
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

    Private Sub radiobuttonWindowsStyle_Click(sender As Object, e As EventArgs) Handles radiobuttonWindowsStyle.Click
        ' Moved to its own sub for use elsewhere.
        checkedWindowsStyleRadioButton()
    End Sub

    Private Sub radiobuttonLinuxStyle_Click(sender As Object, e As EventArgs) Handles radiobuttonLinuxStyle.Click
        ' Look at each textbox inside the flow layout panel.
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            ' Disable textboxes to prevent accidental edits.
            editBox.Enabled = False
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

    Private Sub radiobuttonEditStyleManually_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonEditStyleManually.CheckedChanged
        For Each editBox As TextBox In flowlayoutpanelFileList.Controls
            ' Allow textboxes to be edited.
            editBox.Enabled = True
        Next
    End Sub


    ReadOnly Property filePaths As String
        Get
            Dim entireList As String = ""
            For Each editBox As TextBox In flowlayoutpanelFileList.Controls
                entireList = entireList & Chr(34) & editBox.Text & Chr(34) & " "
            Next
            Return entireList
        End Get
    End Property
End Class
