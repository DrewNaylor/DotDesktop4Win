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



Public Class aaformMainWindow
    Private Sub buttonBrowse_Click(sender As Object, e As EventArgs) Handles buttonBrowse.Click

        ' When the user opens a file from the Browse... dialog, change the text
        ' in the textbox and titlebar, then interpret the .desktop file.
        If openfiledialogDotDesktopFile.ShowDialog() = DialogResult.OK Then

            ' Before doing anything, make sure this is a valid .desktop file
            ' and that it starts with "[Desktop Entry]".
            If System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).StartsWith("[Desktop Entry]") Then

                ' First, update titlebar and file path textbox.
                textboxDotDesktopFilePath.Text = openfiledialogDotDesktopFile.FileName
                Me.Text = openfiledialogDotDesktopFile.SafeFileName & " - " & Application.ProductName

                ' Second, update the raw output textbox after replacing Lf with CrLf.
                textboxRawFileOutput.Text = System.IO.File.ReadAllText(openfiledialogDotDesktopFile.FileName).Replace(vbLf, vbCrLf)

            End If
        End If
    End Sub
End Class
