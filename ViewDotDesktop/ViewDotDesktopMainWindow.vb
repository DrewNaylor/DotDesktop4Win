' ViewDotDesktop - View .desktop files as parsed by the DotDesktop4Win
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


Imports libdotdesktop
Public Class aaformMainWindow
    Private Sub buttonBrowse_Click(sender As Object, e As EventArgs) Handles buttonBrowse.Click

        ' When the user opens a file from the Browse... dialog, change the text
        ' in the textbox and titlebar, then interpret the .desktop file.
        If openfiledialogDotDesktopFile.ShowDialog() = DialogResult.OK Then

            ' Before doing anything, make sure this is a valid .desktop file
            ' and that it starts with "[Desktop Entry]" if no text before the
            ' section is allowed.
            ' If text is allowed, just ignore it.
            If desktopEntryStuff.checkHeader(openfiledialogDotDesktopFile.FileName) = "Desktop Entry" Or
                desktopEntryStuff.checkHeader(openfiledialogDotDesktopFile.FileName) = "KDE Desktop Entry" Then

                ' First, update titlebar and file path textbox.
                textboxDotDesktopFilePath.Text = openfiledialogDotDesktopFile.FileName
                Me.Text = openfiledialogDotDesktopFile.SafeFileName & " - " & Application.ProductName

                ' Second, update the raw output textbox after replacing Lf with CrLf.
                textboxRawFileOutput.Text = System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).Replace(vbLf, vbCrLf)

                ' Empty the interpreter output textbox.
                textboxInterpreterOutput.Clear()

                ' Now, pass along the file to the interpretation code in libdotdesktop.                
                ' Catch NullReferenceExceptions, just in case there are issues in the file.
                Try

                    ' Type key.
                    textboxInterpreterOutput.Text = "Type: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Type")

                    ' Version key.
                    If desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Version") IsNot Nothing Then
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "Version: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Version")
                    End If

                    ' Name key.
                    textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "Name: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Name",
                                                                            openfiledialogDotDesktopFile.SafeFileName.ToString)

                    ' Comment key.
                    If desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Comment") IsNot Nothing Then
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "Comment: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Comment")
                    End If

                    ' Exec key.
                    If desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Exec") IsNot Nothing Then
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "Exec: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Exec")
                    End If

                    ' Path key.
                    If desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Path") IsNot Nothing Then
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "Path: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Path")
                    End If

                    ' URL key.
                    ' If the desktop entry is of "Link" type, this is required, so check to see if it's there.
                    If desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "URL") IsNot Nothing AndAlso
                        desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Type") = "Link" Then
                        ' If the URL key exists, get it.
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "URL: " & desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "URL")

                    ElseIf desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "URL") Is Nothing AndAlso
                        desktopEntryStuff.getInfo(openfiledialogDotDesktopFile.FileName, "Type") = "Link" Then
                        ' Return a message that the URL key is missing.
                        textboxInterpreterOutput.Text = textboxInterpreterOutput.Text & vbCrLf & "URL: (Required URL key for Link desktop entries is missing)"
                    End If

                Catch ex As NullReferenceException
                    ' Show a messagebox for explanation.
                    MessageBox.Show("The .desktop file appears to have issues, likely due to extra characters where they shouldn't be. You can check the File output: Raw tab if you want to see what it could be.")
                    ' Now reset labels to their defaults.
                    ' TODO: add the code here.
                End Try

            Else
                ' If it's not a valid Freedesktop.org .desktop file, tell the user.
                MessageBox.Show("This .desktop file doesn't have a valid Desktop Entry header/section, which is required by the Freedesktop.org Desktop Entry spec.",
                                "Browse for .desktop file")
            End If
        End If
    End Sub

    Private Sub linklabelFDOSpec_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklabelFDOSpec.LinkClicked
        ' Go to the latest version of the Freedesktop.org Desktop Entry spec online.
        Process.Start("https://specifications.freedesktop.org/desktop-entry-spec/desktop-entry-spec-latest.html")
    End Sub

    Private Sub menuitemExitItem_Click(sender As Object, e As EventArgs) Handles menuitemExitItem.Click
        ' Exit application.
        Application.Exit()
    End Sub
End Class
