' LaunchDotDesktop - Launch .desktop files as parsed by the DotDesktop4Win
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


Imports System.Windows.Forms
Imports libdotdesktop
Imports System.IO
Module LaunchDotDesktop

    Public Sub Main()

        ' Before doing anything, make sure this is a valid .desktop file
        ' and that it starts with "[Desktop Entry]" if no text before the
        ' section is allowed.
        ' If text is allowed, just ignore it if possible.
        If System.IO.File.ReadAllText(My.Application.CommandLineArgs(0).ToString).StartsWith("[Desktop Entry]") Or
                My.Settings.allowTextBeforeDesktopEntrySection = True And System.IO.File.ReadAllText(My.Application.CommandLineArgs(0).ToString).Contains("[Desktop Entry]") Then

            ' First, update titlebar and output the file path.
            Console.WriteLine(My.Application.CommandLineArgs(0).ToString)
            Console.Title = System.IO.Path.GetFileName(My.Application.CommandLineArgs(0).ToString) & " - " & Application.ProductName

            ' Second, update the console after replacing Lf with CrLf.
            Console.WriteLine(System.IO.File.ReadAllText(My.Application.CommandLineArgs(0).ToString).Replace(vbLf, vbCrLf))

            ' Now, pass along the file to the interpretation code in libdotdesktop.
            ' Catch NullReferenceExceptions, just in case there are issues in the file.
            Try
                ' Exec key.

#Region "Clean up Exec key if needed, and allow for choosing files and URLs."
                Dim cleanedExecKey As String = desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Exec")
                ' %d is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %d", "")
                ' %D is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %D", "")
                ' %n is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %n", "")
                ' %N is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %N", "")
                ' %v is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %v", "")
                ' %m is deprecated.
                cleanedExecKey = cleanedExecKey.Replace(" %m", "")

                ' If there's a %u in the file, open a window to ask for a URL.
                Dim singleUrl As String = Nothing
                If cleanedExecKey.Contains(" %u") Then
                    singleUrl = InputBox("Please type or paste a URL:", "URL input", "")
                    cleanedExecKey = cleanedExecKey.Replace(" %u", "")
                End If
#End Region

                ' Now, see if singleUrl has anything in it, and if it does,
                ' send that URL as an argument to the application.
                Dim execProgram As New ProcessStartInfo
                execProgram.FileName = cleanedExecKey
                execProgram.Arguments = singleUrl
                Console.WriteLine("Launching " & cleanedExecKey &
                                "...")
                Process.Start(execProgram)


            Catch ex As System.ComponentModel.Win32Exception
                ' Show a messagebox for explanation.
                MessageBox.Show("Either there are characters where they shouldn't be, or we couldn't find the program specified in the Exec key. You can check the console output if you want to see what it could be." & vbCrLf &
                                vbCrLf &
                                "Exec key value: " & desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Exec"), System.IO.Path.GetFileName(My.Application.CommandLineArgs(0).ToString) & " - " & Application.ProductName)

            End Try

        Else
            ' If it's not a valid Freedesktop.org .desktop file, tell the user.
            MessageBox.Show("This .desktop file doesn't have a valid Desktop Entry header/section, which is required by the Freedesktop.org Desktop Entry spec." &
                                " Please note that for now, this implementation doesn't ignore comments or blank lines at the beginning properly. Work needs to be done for that." &
                                " Set My.Settings.allowTextBeforeDesktopEntrySection to True to allow text before the Desktop Entry section.",
                                "Launch .desktop file")
        End If


        ' Add in a pause where the user can hit "Enter" to continue.
        Console.ReadLine()
    End Sub

End Module
