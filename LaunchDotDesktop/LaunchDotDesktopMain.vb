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
Imports System.Text.RegularExpressions

Module LaunchDotDesktop

    Public Sub Main()

        ' Display program info, like name, version, and copyright.
        Console.WriteLine(My.Application.Info.Title & " Version " & My.Application.Info.Version.ToString)
        Console.WriteLine(My.Application.Info.Copyright)
        Console.WriteLine("You may obtain a copy of the License at <http://www.apache.org/licenses/LICENSE-2.0>.")

        ' Before doing anything, make sure this is a valid .desktop file
        ' with the proper Desktop Entry/KDE Desktop Entry header.
        If My.Application.CommandLineArgs.Count = 1 Then
            If desktopEntryStuff.checkHeader(My.Application.CommandLineArgs(0).ToString) = "Desktop Entry" Or
                desktopEntryStuff.checkHeader(My.Application.CommandLineArgs(0).ToString) = "KDE Desktop Entry" Then

                ' First, update titlebar and output the file path.
                Console.WriteLine()
                Console.WriteLine("Input file: " & My.Application.CommandLineArgs(0).ToString)
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
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%d", "")
                        ' %D is deprecated.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%D", "")
                        ' %n is deprecated.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%n", "")
                        ' %N is deprecated.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%N", "")
                        ' %v is deprecated.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%v", "")
                        ' %m is deprecated.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%m", "")

                        ' Determine if the application allows for entering a URL,
                        ' and provide a space to type it in.
                        If regexCheckFlags(cleanedExecKey, "%u") Then
                            ' If there's a %u in the file, open a window to ask for a URL.
                            urlList = InputBox("Please type or paste a URL:", "Single URL input")
                            ' Expand %u to what the user entered.
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", " " & urlList)
                            ' Clean up unused flags.
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")


                        ElseIf regexCheckFlags(cleanedExecKey, "%U") Then
                            ' If there's a %U in the file, open a window to allow for entering URLs.
                            urlList = InputBox("Please type or paste a list of URLs separated by a space:", "Multiple URL input")
                            ' Expand %U to what the user entered.
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", " " & urlList)
                            ' Clean up unused flags.
                            cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")

                        ElseIf regexCheckFlags(cleanedExecKey, "%f") Then
                            ' If there's a %f, allow for choosing one file.
                            Dim openFileDialog As New OpenFileDialog()
                            openFileDialog.Filter = "All files (*.*)|*.*"
                            openFileDialog.RestoreDirectory = True

                            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                ' If the user chooses a file, replace %f with the filename and path.
                                Dim fileName As String = openFileDialog.FileName
                                Dim quoteForFilePaths As String = Chr(34)
                                ' If the .desktop file requests it, switch the paths to be Linux-style.
                                If desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "X-DotDesktop4Win-UseWSLFilePaths") = "true" Then

                                    ' Convert the filename/file path to what WSL distros expect.
                                    fileName = convertPathsStyleToWSL(fileName)
                                    ' Set quote used in file paths to a single quote.
                                    quoteForFilePaths = "'"

                                Else
                                    ' Remove the double-quotes on the end of the filename.
                                    fileName = fileName.TrimEnd(Chr(34))
                                End If

                                ' Update cleanedExecKey with the fileName, which may or may not have been modified
                                ' to be Linux-style if the desktop entry file wanted it or not.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", " " & quoteForFilePaths & fileName & quoteForFilePaths)
                                ' Clean up unused flags.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")
                            Else
                                ' If the user cancels, just remove the %f.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
                                ' Clean up unused flags.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")

                                ' TODO: Remove any instances of %u, %U, and %F
                                ' after merging back into master.
                                ' Actually, this will probably require using Regex.
                                ' The developer of WinYourDesktop appears to have done
                                ' the same thing where they used Regex to replace variables,
                                ' and it looks like a good way to do this to make sure the correct
                                ' variables are replaced.
                                ' Maybe what should be done is to have this code
                                ' in a function so that it's reusable, kinda like what's done in WinYourDesktop.
                                ' This tutorial on Regex in VB.Net looks pretty good:
                                ' https://www.tutorialspoint.com/vb.net/vb.net_regular_expressions.htm
                            End If

                        ElseIf regexCheckFlags(cleanedExecKey, "%F") Then
                            ' If there's a %F, allow for choosing multiple files.
                            Dim openFileDialog As New OpenFileDialog()
                            openFileDialog.Filter = "All files (*.*)|*.*"
                            openFileDialog.RestoreDirectory = True
                            openFileDialog.Multiselect = True

                            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                ' If the user chooses files, replace %F with the filename and paths.
                                ' Get a file name list array as a string from the open file dialog.
                                Dim fileNameList As String() = openFileDialog.FileNames

                                ' Define a path list to store the filenames into.
                                Dim entirePathList As New List(Of String)
                                ' Define a quote character for putting at the beginning
                                ' and end of filenames. This can be changed if necessary,
                                ' such as if a desktop entry file wants to use a Linux-style
                                ' path instead of Windows-style.
                                Dim quoteForFilePaths As String = Chr(34)
                                For Each fileName As String In fileNameList
                                    ' If the .desktop file requests it, switch the paths to be Linux-style.
                                    If desktopEntryStuff.getInfo(My.Application.CommandLineArgs(0).ToString, "X-DotDesktop4Win-UseWSLFilePaths") = "true" Then

                                        ' Set quote used in file paths to a single quote.
                                        quoteForFilePaths = "'"
                                        ' Add the newly-modified filename to the path list.

                                        ' Put a question mark at the end of the filename
                                        ' for later use when joining the string.
                                        ' It may be a good idea to allow this to be a configurable option
                                        ' in case the user runs into issues on other filesystems that allow
                                        ' the question mark to be in a filename.

                                        ' Convert the filename/file path to what WSL distros expect.
                                        entirePathList.Add(quoteForFilePaths & convertPathsStyleToWSL(fileName) & quoteForFilePaths & " ?")

                                    Else
                                        ' Remove the double-quotes on the end of the filename.
                                        fileName = fileName.TrimEnd(Chr(34))
                                        ' Add the filename to the path list.

                                        ' Put a question mark at the end of the filename
                                        ' for later use when joining the string.
                                        ' It may be a good idea to allow this to be a configurable option
                                        ' in case the user runs into issues on other filesystems that allow
                                        ' the question mark to be in a filename.
                                        entirePathList.Add(quoteForFilePaths & fileName & quoteForFilePaths & " ?")
                                    End If

                                Next
                                ' Make a new string that joins the file name list into one string.
                                Dim filesList As String = String.Join("?", entirePathList)
                                ' Replace the joiner character with an empty string.
                                filesList = filesList.Replace("?", "")

                                ' Expand %F with the new file list, and add double-quotes on each side
                                ' of the file list after putting in a space to separate it from the rest
                                ' of the command.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", " " & filesList.TrimEnd)
                                ' Clean up unused flags.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
                            Else
                                ' If the user cancels, just remove the %F.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")
                                ' Clean up unused flags.
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                                cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
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
                            ' Assign the arg variable to the copy of the exec key and remove
                            ' the double-quotes before and after and the new exec key 
                            ' from the beginning of the URL list/arg variable.
                            urlList = originalCleanedExecKey.Remove(0, cleanedExecKey.Length + 2)
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

                    urlList = regexReplaceFlags(urlList, "%userprofile%", "C:\Users\drewn\", False)
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


            ' Add in a pause where the user can hit "Enter" to continue if enabled.
            If My.Settings.PauseBeforeExitOnSuccessfulLaunch = True Then
                Console.WriteLine()
                Console.WriteLine("Please press Enter to continue...")
                Console.ReadLine()
            End If

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

    Private Function convertPathsStyleToWSL(fileName As String) As String
        ' Convert Windows paths to be usable under WSL.
        If fileName.Substring(1, 2) = ":\" Then
            ' Grab the drive letter and make it lowercase for later use.
            Dim driveLetter As String = fileName.Substring(0, 1).ToLowerInvariant
            ' Remove the drive letter and the colon.
            fileName = fileName.Remove(0, 2)

            ' Prepend "/mnt/" and the drive letter to the textbox text.
            fileName = "/mnt/" & driveLetter & fileName

            ' Replace back slashes with forward slashes.
            fileName = fileName.Replace("\", "/")

        End If
        ' Remove the single quote on the end.
        fileName = fileName.TrimEnd(CType("'", Char()))
        Return fileName
    End Function

    Private Function regexReplaceFlags(input As String, flag As String, desiredReplacement As String, Optional caseSensitive As Boolean = True) As String
        ' Replaces flags in the style of %u with a string using regex.
        ' First we need to create a regular expression to match what'll
        ' be replaced.
        ' \s+ is for whitespace before the flag.
        ' \b is for the word border at the end.
        ' This can be used with flags/environment variables
        ' that end with a percent sign.
        ' The case-sensitive if statement may need to be cleaned up a bit.

        ' Create a temp string to hold the regex for now.
        Dim tempRegex As String = "\s+" & flag & "\b"

        If flag.EndsWith("%") Then
            ' If the flag ends with a percent sign,
            ' change the regex temp string to work
            ' with it so it's matched later.
            tempRegex = "\s+" & flag.TrimEnd(CType("%", Char())) & "\b%"
        End If

        If caseSensitive = False Then
            ' If case-insensitivity is fine for this
            ' flag, have the regex thing ignore case.
            Dim regexThing As New Regex(tempRegex, RegexOptions.IgnoreCase)
            ' Now we perform the replacement.
            Return regexThing.Replace(input, desiredReplacement)
        Else
            ' Otherwise, don't have the regex thing
            ' ignore case.
            Dim regexThing As New Regex(tempRegex)
            ' Now we perform the replacement.
            Return regexThing.Replace(input, desiredReplacement)
        End If
    End Function

    Private Function regexCheckFlags(input As String, flag As String) As Boolean
        ' Check to see if the input string contains a flag in the style of %u using regex.
        ' If there's a match, this'll return a Boolean.
        ' \s+ is for whitespace before the flag.
        ' \b is for the word border at the end.
        ' This can't be used with flags/environment variables
        ' that end with a percent sign.
        Dim tempRegex As String = "\s+" & flag & "\b"

        If flag.EndsWith("%") Then
            tempRegex = "\s+" & flag.TrimEnd(CType("%", Char())) & "\b%"
        End If

        Return Regex.IsMatch(input, tempRegex)
    End Function

End Module
