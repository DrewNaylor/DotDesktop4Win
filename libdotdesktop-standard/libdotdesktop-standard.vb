' libdotdesktop-standard - Get info from .desktop files for the DotDesktop4Win
' partial implementation of Freedesktop.org's Desktop Entry spec.
' .NET Standard implementation of libdotdesktop.
' Copyright 2019-2021 Drew Naylor
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



Imports System.IO
Imports MadMilkman.Ini

Public Class desktopEntryStuff

    Public Shared Function checkHeader(inputFile As String) As String
        ' This is used to check to see if the file we're trying to open has a valid Desktop Entry
        ' or KDE Desktop Entry header.
        ' Returns True if a valid header is found, and False if there's no valid header.

        ' Get the input file and put it in an INI file object for later use.
        Dim dotDesktopFile As New IniFile(
            New IniOptions() With {.CommentStarter = IniCommentStarter.Hash})
        dotDesktopFile.Load(New StringReader(System.IO.File.ReadAllText(inputFile)))

        ' Define Desktop Entry section.
        Dim desktopEntrySection As IniSection = dotDesktopFile.Sections("Desktop Entry")
        Dim kdeDesktopEntrySection As IniSection = dotDesktopFile.Sections("KDE Desktop Entry")
        ' First we check that the header is there.
        If desktopEntrySection Is Nothing AndAlso kdeDesktopEntrySection Is Nothing Then
            ' There's neither a desktop entry section nor a KDE desktop entry section.
            Return "Nothing"
        ElseIf desktopEntrySection Is Nothing AndAlso kdeDesktopEntrySection IsNot Nothing Then
            ' If the desktop entry section doesn't exist but the KDE one does, use the KDE one.
            Return "KDE Desktop Entry"
        Else
            ' Otherwise, return the regular desktop entry name.
            Return "Desktop Entry"
        End If
    End Function

#Region "GetInfo function."
    Public Shared Function getInfo(inputFile As String, keyToGet As String, Optional fileName As String = "", Optional IsCustomKey As Boolean = False) As String

        ' Get the input file and put it in an INI file object for later use.
        Dim dotDesktopFile As New IniFile(
            New IniOptions() With {.CommentStarter = IniCommentStarter.Hash})
        dotDesktopFile.Load(New StringReader(System.IO.File.ReadAllText(inputFile)))

        ' Define Desktop Entry section.
        Dim desktopEntrySection As IniSection = dotDesktopFile.Sections(checkHeader(inputFile))


#Region "Getting and returning key values."

        ' Look in the inputFile and return the value for the keyToGet.
        ' This is using Select Case so it should be faster.
        ' We need another Select Case for custom keys.
        Select Case IsCustomKey
            Case True

#Region "Return the custom key if that's what the calling app wants."
                ' The calling app wants a custom key that's not otherwise supported by
                ' libdotdesktop.
                ' First make sure it's in there.
                If desktopEntrySection.Keys(keyToGet) IsNot Nothing Then
                    ' If it is in there, return it as expected.
                    Return desktopEntrySection.Keys(keyToGet).Value.ToLowerInvariant
                Else
                    ' Otherwise, return Nothing if the key is unavailable.
                    Return Nothing
                End If
#End Region
            Case False
                ' The calling app doesn't need a custom key.
                Select Case keyToGet
#Region "Get Type key."
                    Case "Type"

                        ' If we want to get the Type value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Type") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Type").Value
                        Else
                            ' Otherwise, return "Application" as the type.
                            Return "Application"
                        End If
#End Region

#Region "Get Name key."
                    Case "Name"

                        ' If we want to get the Name value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Name") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Name").Value
                        Else
                            ' Otherwise, return the filename as the name.
                            Return fileName
                        End If
#End Region

#Region "Get GenericName key."
                    Case "GenericName"

                        ' If we want to get the Name value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("GenericName") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("GenericName").Value
                        Else
                            ' Otherwise, return the filename as the name.
                            Return Nothing
                        End If
#End Region

#Region "Get Exec key."
                    Case "Exec"

                        ' If we want to get the Exec value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Exec") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Exec").Value
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get Path key."
                    Case "Path"

                        ' If we want to get the Path value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Path") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Path").Value
                        Else
                            ' Otherwise, return Nothing if the key is unavailable so
                            ' the application can hide the info.
                            Return Nothing
                        End If
#End Region

#Region "Get Version key."
                    Case "Version"

                        ' If we want to get the Version value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Version") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Version").Value
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get Comment key."
                    Case "Comment"

                        ' If we want to get the Comment value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Comment") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Comment").Value
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get Categories key."
                    Case "Categories"

                        ' If we want to get the Name value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Categories") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Categories").Value
                        Else
                            ' Otherwise, return the filename as the name.
                            Return Nothing
                        End If
#End Region

#Region "Get URL key."
                    Case "URL"

                        ' If we want to get the URL value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("URL") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("URL").Value
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get Terminal key."
                    Case "Terminal"

                        ' If we want to get the Terminal value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("Terminal") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("Terminal").Value.ToLowerInvariant
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get NoDisplay key."
                    Case "NoDisplay"

                        ' If we want to get the NoDisplay value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("NoDisplay") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("NoDisplay").Value.ToLowerInvariant
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "Get X-DotDesktop4Win-UseWSLFilePaths key."
                    Case "X-DotDesktop4Win-UseWSLFilePaths"

                        ' X-DotDesktop4Win-UseWSLFilePaths definition and use:
                        ' This key is used to force Linux-style paths to be used in
                        ' situations like WSL where file paths are expected to be
                        ' /mnt/c/whatever instead of C:\whatever.
                        ' This key is a Boolean, and can either be true or false.

                        ' If we want to get the X-DotDesktop4Win-UseWSLFilePaths value, return that.
                        ' First make sure it's in there.
                        If desktopEntrySection.Keys("X-DotDesktop4Win-UseWSLFilePaths") IsNot Nothing Then
                            ' If it is in there, return it as expected.
                            Return desktopEntrySection.Keys("X-DotDesktop4Win-UseWSLFilePaths").Value.ToLowerInvariant
                        Else
                            ' Otherwise, return Nothing if the key is unavailable.
                            Return Nothing
                        End If
#End Region

#Region "What to do when the key isn't an option here."
                    Case Else

                        ' Otherwise, just return whatever the user specified in the key field
                        ' if it's not a custom key.
                        Return "(Key not implemented)"
#End Region

                End Select

        End Select
#End Region
    End Function
#End Region


#Region "Cleaning keys."
    ' This function will clean keys as passed to it.
    ' Some features are only available on Windows, such as the file browser dialog.
    Public Shared Function cleanExecKey(inputFile As String) As String
        ' Before doing anything, make sure this is a valid .desktop file
        ' with the proper Desktop Entry/KDE Desktop Entry header.
        If checkHeader(inputFile) = "Desktop Entry" OrElse checkHeader(inputFile) = "KDE Desktop Entry" Then

            ' Now, clean the exec key.
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

                ' Expand environment variables.
                cleanedExecKey = expandEnvVars(cleanedExecKey)
                If My.Settings.ShowExecKeyBeforeLaunch = True Then
                    MessageBox.Show(cleanedExecKey)
                End If
                ' TODO: Switch the urlList to WSL paths if
                ' the .desktop file wants it.
                urlList = expandEnvVars(urlList)

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
    End Function
#End Region

End Class
