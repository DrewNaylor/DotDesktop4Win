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
Imports libdotdesktop
Imports System.IO
Module LaunchDotDesktop

    Public Sub Main()

        ' Before doing anything, make sure this is a valid .desktop file
        ' with the proper Desktop Entry/KDE Desktop Entry header.
        If My.Application.CommandLineArgs.Count = 1 Then
            If desktopEntryStuff.checkHeader(My.Application.CommandLineArgs(0).ToString) = "Desktop Entry" Or
                desktopEntryStuff.checkHeader(My.Application.CommandLineArgs(0).ToString) = "KDE Desktop Entry" Then

                ' First, update titlebar and output the file path.
                Console.WriteLine(My.Application.CommandLineArgs(0).ToString)
                Console.Title = System.IO.Path.GetFileName(My.Application.CommandLineArgs(0).ToString) & " - " & Application.ProductName

                ' Second, update the console after replacing Lf with CrLf.
                Console.WriteLine(System.IO.File.ReadAllText(My.Application.CommandLineArgs(0).ToString).Replace(vbLf, vbCrLf))

                ' Now, pass along the file to the interpretation code in libdotdesktop.
                ' Catch NullReferenceExceptions, just in case there are issues in the file.
                Try
                    ' Exec key.
                    Dim cleanedExecKey As String
                    ' URL list for apps that allow for URLs to be passed to them.
                    Dim urlList As String = ""

                    ' Check to see if the desktop entry is a link or an application.
                    If desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Type") = "Link" AndAlso
                       desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "URL") IsNot Nothing Then
                        ' If it's a link, grab the URL key if it exists.
                        cleanedExecKey = desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "URL")

                    ElseIf desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Type") = "Link" AndAlso
                       desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "URL") Is Nothing Then
                        ' If the URL key doesn't exist, allow for URL entry.
                        cleanedExecKey = InputBox("Please type or paste a URL:", "URL key missing")

                    ElseIf desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Type") = "Directory" Then
                        ' Directories aren't supported in this program.
                        MessageBox.Show("Directory entries aren't supported by LaunchDotDesktop.", "Unsupported entry type")
                        Exit Try
                    Else
                        ' Otherwise, assume it's an application.
                        cleanedExecKey = desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Exec")
#Region "Clean up Exec key if needed, and allow for choosing files and URLs."

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

                        ' Determine if the application allows for entering a URL,
                        ' and provide a space to type it in.
                        If cleanedExecKey.Contains(" %u") Then
                            ' If there's a %u in the file, open a window to ask for a URL.
                            urlList = InputBox("Please type or paste a URL:", "Single URL input")
                            ' Expand %u to what the user entered.
                            cleanedExecKey = cleanedExecKey.Replace(" %u", " " & urlList)

                        ElseIf cleanedExecKey.Contains(" %U") Then
                            ' If there's a %U in the file, open a window to allow for entering URLs.
                            urlList = InputBox("Please type or paste a list of URLs separated by a space:", "Multiple URL input")
                            ' Expand %U to what the user entered.
                            cleanedExecKey = cleanedExecKey.Replace(" %U", " " & urlList)

                        ElseIf cleanedExecKey.Contains(" %f") Then
                            ' If there's a %f, allow for choosing one file.
                            Dim openFileDialog As New OpenFileDialog()
                            openFileDialog.Filter = "All files (*.*)|*.*"
                            openFileDialog.RestoreDirectory = True

                            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                ' If the user chooses a file, replace %f with the filename and path.
                                cleanedExecKey = cleanedExecKey.Replace(" %f", " " & Chr(34) & openFileDialog.FileName & Chr(34))
                            Else
                                ' If the user cancels, just remove the %f.
                                cleanedExecKey = cleanedExecKey.Replace(" %f", "")
                            End If
                        End If

                        ' Split Exec key's program from the arguments, if necessary.
                        ' Check to see if it starts with double-quotes.
                        ' Get rid of whitespace on the left side.
                        cleanedExecKey = LTrim(cleanedExecKey)

                        ' Check for Chr(34), which is the double-quote character.
                        If cleanedExecKey.StartsWith(Chr(34)) Then
                            ' Copy the original cleaned exec key for later use in the arg variable.
                            Dim originalCleanedExecKey As String = cleanedExecKey
                            ' Create a temp key to be used when splitting out the EXE filename.
                            Dim tempExecKey As String() = cleanedExecKey.Split(Chr(34))
                            ' Trim the exec key out at the second double-quote.
                            cleanedExecKey = tempExecKey(1).Trim
                            ' Assign the arg variable to the copy of the exec key and trim
                            ' the double-quotes before and after and the new exec key 
                            ' from the beginning of the URL list/arg variable.
                            urlList = originalCleanedExecKey.TrimStart(CType(Chr(34) & cleanedExecKey.ToCharArray & Chr(34), Char()))
                        Else
                            ' If there's no double-quotes, assume it's something like
                            ' firefox.exe or another string without spaces.
                            ' We'll need to split this one at the first space character.

                            ' Copy the original cleaned exec key for later use in the arg variable.
                            Dim originalCleanedExecKey As String = cleanedExecKey
                            ' Create a temp key to be used when splitting out the EXE filename.
                            Dim tempExecKey As String() = cleanedExecKey.Split(" "c)
                            ' Trim the exec key out at the first space.
                            cleanedExecKey = tempExecKey(0).Trim
                            ' Assign the arg variable to the copy of the exec key and trim
                            ' out the exec key.
                            urlList = originalCleanedExecKey.TrimStart(cleanedExecKey.ToCharArray)
                        End If
#End Region
                        ' Done figuring out the desktop entry type.
                    End If

                    ' Now, see if urlList has anything in it, and if it does,
                    ' send that URL as an argument to the application.
                    Dim execProgram As New ProcessStartInfo
                    execProgram.FileName = cleanedExecKey
                    execProgram.Arguments = urlList.Trim
                    ' Don't add space if there are no args.
                    If execProgram.Arguments.Length > 0 Then
                        Console.WriteLine("Launching " & execProgram.FileName & " " & execProgram.Arguments & "...")
                    Else
                        Console.WriteLine("Launching " & execProgram.FileName & "...")
                    End If

                    Process.Start(execProgram)

                Catch ex As System.ComponentModel.Win32Exception
                    ' Show a messagebox for explanation.
                    ' If it's a Link, show the URL key.
                    If desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Type") = "Link" Then
                        MessageBox.Show("We couldn't find the address that was listed in the URL key or passed manually. You can check the console output if you want to see what it could be." & vbCrLf &
                            vbCrLf &
                            "URL key value: " & desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "URL"), System.IO.Path.GetFileName(My.Application.CommandLineArgs(0).ToString) & " - " & Application.ProductName)
                    Else
                        ' If it's an application, show the Exec key.
                        MessageBox.Show("Either there are characters where they shouldn't be, or we couldn't find the program specified in the Exec key. You can check the console output if you want to see what it could be." & vbCrLf &
                                                    vbCrLf &
                                                    "Exec key value: " & desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "Exec"), System.IO.Path.GetFileName(My.Application.CommandLineArgs(0).ToString) & " - " & Application.ProductName)
                    End If


                End Try

            Else
                ' If it's not a valid Freedesktop.org .desktop file, tell the user.
                MessageBox.Show("This .desktop file doesn't have a valid Desktop Entry header/section, which is required by the Freedesktop.org Desktop Entry spec.",
                                "Launch .desktop file")
            End If


            ' Add in a pause where the user can hit "Enter" to continue.
            Console.ReadLine()

        Else
            ' If there are no command-line args, then we'll have to show a message instead.
            ' This'll eventually be replaced with a proper window for .desktop launching and
            ' configuration stuff.
            ' TODO: Move the .desktop launching part to its own sub so that it can be run at any time
            ' after starting the program.
            MessageBox.Show("Howdy. This message is being shown to let you know that no .desktop file has been passed to LaunchDotDesktop." &
                            " Please drag-and-drop the file onto the icon, double-click the file after setting LaunchDotDesktop as its default handler," &
                            " or pass it as a command-line argument in CMD or PowerShell. Eventually a real window will be added to allow for browsing" &
                            " and configuration instead of this message box.", "No file passed - LaunchDotDesktop")
        End If
    End Sub

End Module
