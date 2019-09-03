' ViewDotDesktop - View .desktop files as parsed by the DotDesktop4Win
' partial implementation of Freedesktop.org's Desktop Entry spec.
' Copyright 2019 Drew Naylor
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
            If System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).StartsWith("[Desktop Entry]") Or
                My.Settings.allowTextBeforeDesktopEntrySection = True And System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).Contains("[Desktop Entry]") Then

                ' First, update titlebar and file path textbox.
                textboxDotDesktopFilePath.Text = openfiledialogDotDesktopFile.FileName
                Me.Text = openfiledialogDotDesktopFile.SafeFileName & " - " & Application.ProductName

                ' Second, update the raw output textbox after replacing Lf with CrLf.
                textboxRawFileOutput.Text = System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).Replace(vbLf, vbCrLf)

                ' Now, pass along the file to the interpretation code in libdotdesktop.
                ' Type key.
                ' Catch NullReferenceExceptions, just in case there are issues in the file.
                Try
                    Me.labelTypeKey.Text = "Type: " & desktopEntryStuff.getInfo(System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName), "Type")

                    ' Name key.
                    Me.labelNameKey.Text = "Name: " & desktopEntryStuff.getInfo(System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName), "Name",
                                                                            openfiledialogDotDesktopFile.SafeFileName.ToString)

                    ' Exec key.
                    Me.labelExecKey.Text = "Exec: " & desktopEntryStuff.getInfo(System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName), "Exec")

                    ' URL key.
                    Me.labelUrlKey.Text = "Url: " & desktopEntryStuff.getInfo(System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName), "URL")

                Catch ex As NullReferenceException
                    ' Show a messagebox for explanation.
                    MessageBox.Show("The .desktop file appears to have issues, likely due to extra characters where they shouldn't be. You can check the File output: Raw tab if you want to see what it could be.")
                End Try

            Else
                ' If it's not a valid Freedesktop.org .desktop file, tell the user.
                MessageBox.Show("This .desktop file doesn't have a valid Desktop Entry header/section, which is required by the Freedesktop.org Desktop Entry spec." &
                                " Please note that for now, this implementation doesn't ignore comments or blank lines at the beginning properly. Work needs to be done for that." &
                                " Set My.Settings.allowTextBeforeDesktopEntrySection to True to allow text before the Desktop Entry section.",
                                "Browse for .desktop file")
            End If
        End If
    End Sub

    Private Sub linklabelDesktopEntrySpec_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklabelDesktopEntrySpec.LinkClicked
        ' Go to the latest version of the Freedesktop.org Desktop Entry spec online.
        Process.Start("https://specifications.freedesktop.org/desktop-entry-spec/desktop-entry-spec-latest.html")
    End Sub
End Class
