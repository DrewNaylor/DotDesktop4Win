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
Imports System.Text.RegularExpressions
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
    Public Shared Function cleanExecKey(inputFile As String, Optional autoCleanMissingFilePathsAndUrls As Boolean = True,
                                        Optional manuallyProvidedUrl As String = Nothing) As List(Of String)
        ' Before doing anything, make sure this is a valid .desktop file
        ' with the proper Desktop Entry/KDE Desktop Entry header.
        If checkHeader(inputFile) = "Desktop Entry" OrElse checkHeader(inputFile) = "KDE Desktop Entry" Then

            ' Now, clean the exec key.
            ' Catch NullReferenceExceptions, just in case there are issues in the file.
            ' The Try/Catch code is commented out for now as I don't know if Win32Exceptions would work
            ' on Linux.
            'Try
            ' Exec key.
            Dim cleanedExecKey As String
            ' Arguments list for apps that allow for passing arguments to apps.
            Dim argsList As String = ""

            ' Check to see if the desktop entry is a link or an application.
            If getInfo(inputFile, "Type") = "Link" AndAlso
                   getInfo(inputFile, "URL") IsNot Nothing Then
                ' If it's a link, grab the URL key if it exists.
                cleanedExecKey = getInfo(inputFile, "URL")

            ElseIf getInfo(inputFile, "Type") = "Link" AndAlso
                   getInfo(inputFile, "URL") Is Nothing Then
                ' If the URL key doesn't exist, allow for URL entry.
                ' We can't exactly do this in the library, so it needs to be passed
                ' back to the calling application with it intact unless a URL is passed
                ' from the calling app.
                If autoCleanMissingFilePathsAndUrls = False AndAlso manuallyProvidedUrl IsNot Nothing Then
                    cleanedExecKey = manuallyProvidedUrl
                End If

            ElseIf getInfo(inputFile, "Type") = "Directory" Then
                ' Directories aren't supported in this program.
                Console.WriteLine("Directory entries aren't supported by libdotdesktop-standard.", "Unsupported entry type")
                Exit Function
            Else
                ' Otherwise, assume it's an application.
                cleanedExecKey = getInfo(inputFile, "Exec")
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
                    ' If there's a %u in the file, either remove or expand the flag
                    ' based on the calling app.
                    If autoCleanMissingFilePathsAndUrls = False AndAlso manuallyProvidedUrl IsNot Nothing Then
                        argsList = manuallyProvidedUrl
                        ' Expand %u to what the user entered.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", " " & argsList)
                    Else
                        ' Automatically clean the flag.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", String.Empty)
                    End If
                    ' Clean up unused flags.
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")


                ElseIf regexCheckFlags(cleanedExecKey, "%U") Then
                    ' If there's a %U in the file, either remove or expand the flag
                    ' based on the calling app.
                    If autoCleanMissingFilePathsAndUrls = False AndAlso manuallyProvidedUrl IsNot Nothing Then
                        argsList = manuallyProvidedUrl
                        ' Expand %U to what the user entered.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", " " & argsList)
                    Else
                        ' Automatically clean the flag.
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", String.Empty)
                    End If

                    ' Clean up unused flags.
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")

                ElseIf regexCheckFlags(cleanedExecKey, "%f") Then
                    ' If there's a %f, allow for choosing one file.
                    ' For now this is commented out because there
                    ' needs to be a way to get a file from the calling
                    ' app, rather than in this library.
                    If autoCleanMissingFilePathsAndUrls = False Then
                        'Dim openFileDialog As New OpenFileDialog()
                        'openFileDialog.Filter = "All files (*.*)|*.*"
                        'openFileDialog.RestoreDirectory = True

                        'If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        '    ' If the user chooses a file, replace %f with the filename and path.
                        '    Dim fileName As String = openFileDialog.FileName
                        '    Dim quoteForFilePaths As String = (CChar(""""))
                        '    ' If the .desktop file requests it, switch the paths to be Linux-style.
                        '    If getInfo(inputFile, "X-DotDesktop4Win-UseWSLFilePaths") = "true" Then

                        '        ' Convert the filename/file path to what WSL distros expect.
                        '        fileName = convertPathsStyleToWSL(fileName)
                        '        ' Set quote used in file paths to a single quote.
                        '        quoteForFilePaths = "'"

                        '    Else
                        '        ' Remove the double-quotes on the end of the filename.
                        '        fileName = fileName.TrimEnd(CChar(""""))
                        '    End If

                        '    ' Update cleanedExecKey with the fileName, which may or may not have been modified
                        '    ' to be Linux-style if the desktop entry file wanted it or not.
                        '    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", " " & quoteForFilePaths & fileName & quoteForFilePaths)
                    Else
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", String.Empty)
                    End If
                    ' Clean up unused flags.
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", "")

                ElseIf regexCheckFlags(cleanedExecKey, "%F") Then
                    ' If there's a %F, allow for choosing multiple files.
                    If autoCleanMissingFilePathsAndUrls = False Then
                        ' This needs to be set up in a way that'll allow the calling app to send
                        ' over the list of files. Not sure how to do this at the moment, so it's
                        ' commented out for now.

                        '    Dim openFileDialog As New OpenFileDialog()
                        'openFileDialog.Filter = "All files (*.*)|*.*"
                        'openFileDialog.RestoreDirectory = True
                        'openFileDialog.Multiselect = True

                        'If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        '    ' If the user chooses files, replace %F with the filename and paths.
                        '    ' Get a file name list array as a string from the open file dialog.
                        '    Dim fileNameList As String() = openFileDialog.FileNames

                        '    ' Define a path list to store the filenames into.
                        '    Dim entirePathList As New List(Of String)
                        '    ' Define a quote character for putting at the beginning
                        '    ' and end of filenames. This can be changed if necessary,
                        '    ' such as if a desktop entry file wants to use a Linux-style
                        '    ' path instead of Windows-style.
                        '    Dim quoteForFilePaths As String = Chr(34)
                        '    For Each fileName As String In fileNameList
                        '        ' If the .desktop file requests it, switch the paths to be Linux-style.
                        '        If getInfo(inputFile, "X-DotDesktop4Win-UseWSLFilePaths") = "true" Then

                        '            ' Set quote used in file paths to a single quote.
                        '            quoteForFilePaths = "'"
                        '            ' Add the newly-modified filename to the path list.

                        '            ' Put a question mark at the end of the filename
                        '            ' for later use when joining the string.
                        '            ' It may be a good idea to allow this to be a configurable option
                        '            ' in case the user runs into issues on other filesystems that allow
                        '            ' the question mark to be in a filename.

                        '            ' Convert the filename/file path to what WSL distros expect.
                        '            entirePathList.Add(quoteForFilePaths & convertPathsStyleToWSL(fileName) & quoteForFilePaths & " ?")

                        '        Else
                        '            ' Remove the double-quotes on the end of the filename.
                        '            fileName = fileName.TrimEnd(Chr(34))
                        '            ' Add the filename to the path list.

                        '            ' Put a question mark at the end of the filename
                        '            ' for later use when joining the string.
                        '            ' It may be a good idea to allow this to be a configurable option
                        '            ' in case the user runs into issues on other filesystems that allow
                        '            ' the question mark to be in a filename.
                        '            entirePathList.Add(quoteForFilePaths & fileName & quoteForFilePaths & " ?")
                        '        End If

                        '    Next
                        '    ' Make a new string that joins the file name list into one string.
                        '    Dim filesList As String = String.Join("?", entirePathList)
                        '    ' Replace the joiner character with an empty string.
                        '    filesList = filesList.Replace("?", "")

                        ' Expand %F with the new file list, and add double-quotes on each side
                        ' of the file list after putting in a space to separate it from the rest
                        ' of the command.
                        'cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", " " & filesList.TrimEnd)
                    Else
                        cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%F", String.Empty)
                    End If
                    ' Clean up unused flags.
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%u", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%U", "")
                    cleanedExecKey = regexReplaceFlags(cleanedExecKey, "%f", "")
                End If

                ' Split Exec key's program from the arguments, if necessary.
                ' Check to see if it starts with double-quotes.
                ' Get rid of whitespace on the left side.
                ' This needs to be in a .NET 5 library, as .NET Standard 2.0
                ' doesn't support it.
                'cleanedExecKey = LTrim(cleanedExecKey)

                ' Check for Chr(34), which is the double-quote character.
                If cleanedExecKey.StartsWith(CChar("""")) Then
                    ' Copy the original cleaned exec key for later use in the arg variable.
                    Dim originalCleanedExecKey As String = cleanedExecKey
                    ' Create a temp key to be used when splitting out the EXE filename.
                    Dim tempExecKey As String() = cleanedExecKey.Split(CChar(""""))
                    ' Trim the exec key out at the second double-quote.
                    cleanedExecKey = tempExecKey(1).Trim
                    ' Assign the arg variable to the copy of the exec key and remove
                    ' the double-quotes before and after and the new exec key 
                    ' from the beginning of the URL list/arg variable.
                    argsList = originalCleanedExecKey.Remove(0, cleanedExecKey.Length + 2)
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
                    argsList = originalCleanedExecKey.TrimStart(cleanedExecKey.ToCharArray)
                End If
#End Region
                ' Done figuring out the desktop entry type.
            End If

            ' Expand environment variables.
            cleanedExecKey = expandEnvVars(cleanedExecKey)
            ' Comment out the stuff to determine whether the cleaned exec
            ' key should be shown before launch as that'll be handled
            ' by the calling app.
            'If My.Settings.ShowExecKeyBeforeLaunch = True Then
            '    MessageBox.Show(cleanedExecKey)
            'End If
            ' TODO: Switch the urlList to WSL paths if
            ' the .desktop file wants it.
            argsList = expandEnvVars(argsList)

            ' Need to add the urlList to the end of the cleanedExecKey as a String() array.
            Dim completeExecKey As New List(Of String)
            completeExecKey.Add(cleanedExecKey)
            completeExecKey.Add(argsList)

            ' Return the cleanedExecKey to the program that requested it.
            Return completeExecKey


            ' The launcher code is commented out because it may be useful.



            '        ' Now, see if urlList has anything in it, and if it does,
            '        ' send that URL as an argument to the application.
            '        Dim execProgram As New ProcessStartInfo
            '        execProgram.FileName = cleanedExecKey
            '        execProgram.Arguments = urlList.Trim
            '        ' Don't add space if there are no args.
            '        If execProgram.Arguments.Length > 0 Then
            '            Console.WriteLine("Launching " & execProgram.FileName & " " & execProgram.Arguments & "...")
            '        Else
            '            Console.WriteLine("Launching " & execProgram.FileName & "...")
            '        End If

            '        Process.Start(execProgram)

            'Catch ex As System.ComponentModel.Win32Exception
            '    ' Show a messagebox for explanation.
            '    ' If it's a Link, show the URL key.
            '    If getInfo(inputFile, "Type") = "Link" Then
            '        Console.WriteLine("We couldn't find the address that was listed in the URL key or passed manually. You can check the console output if you want to see what it could be." & vbCrLf &
            '                vbCrLf &
            '                "URL key value: " & getInfo(inputFile, "URL"), System.IO.Path.GetFileName(inputFile) & " - libdotdesktop-standard")
            '    Else
            '        ' If it's an application, show the Exec key.
            '        Console.WriteLine("Either there are characters where they shouldn't be, or we couldn't find the program specified in the Exec key. You can check the console output if you want to see what it could be." & vbCrLf &
            '                                        vbCrLf &
            '                                        "Exec key value: " & getInfo(inputFile, "Exec"), System.IO.Path.GetFileName(inputFile) & " - libdotdesktop-standard")
            '    End If


            'End Try

            'Else
            '    ' If it's not a valid Freedesktop.org .desktop file, tell the user.
            '    Console.WriteLine("This .desktop file doesn't have a valid Desktop Entry header/section, which is required by the Freedesktop.org Desktop Entry spec.",
            '                        "Launch .desktop file")
        End If
    End Function
#End Region

    Private Shared Function convertPathsStyleToWSL(fileName As String) As String
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

    Private Shared Function regexReplaceFlags(input As String, flag As String, desiredReplacement As String, Optional caseSensitive As Boolean = True) As String
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
            tempRegex = flag.TrimEnd(CType("%", Char())) & "\b%"
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

    Private Shared Function regexCheckFlags(input As String, flag As String, Optional caseSensitive As Boolean = True) As Boolean
        ' Check to see if the input string contains a flag in the style of %u using regex.
        ' If there's a match, this'll return a Boolean.
        ' \s+ is for whitespace before the flag.
        ' \b is for the word border at the end.
        ' This can be used with flags/environment variables
        ' that end with a percent sign.

        ' If this is a special folder, ignore space at beginning.

        ' Create temporary string for regex pattern.
        Dim tempRegex As String = "\s+" & flag & "\b"

        If flag.EndsWith("%") Then
            ' If the flag ends with a percent sign,
            ' change the regex string to work with it.
            ' This is a special folder, so ignore spacing
            ' requirements.
            tempRegex = flag.TrimEnd(CType("%", Char())) & "\b%"
        End If

        If caseSensitive = False Then
            ' If case sensitivity isn't desired for this
            ' flag (such as for %userprofile%), have
            ' the regex thing ignore case when returning
            ' the boolean.
            Return Regex.IsMatch(input, tempRegex, RegexOptions.IgnoreCase)
        Else
            ' Otherwise, case sensitivity is necessary, so
            ' it'll be used.
            Return Regex.IsMatch(input, tempRegex)
        End If

    End Function


    Private Shared Function expandEnvVars(execOrArg As String) As String
        'If My.Settings.ShowExecKeyBeforeLaunch = True Then
        '    MessageBox.Show(execOrArg)
        'End If
        ' First we expand %USERPROFILE%.
        Dim output As String = execOrArg
        If regexCheckFlags(execOrArg, "%USERPROFILE%", False) Then
            output = regexReplaceFlags(execOrArg, "%USERPROFILE%", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), False)
            'MessageBox.Show(output)
        End If

        ' Now we can replace %WINDIR%.
        If regexCheckFlags(execOrArg, "%WINDIR%", False) Then
            'MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.Windows))
            output = regexReplaceFlags(execOrArg, "%WINDIR%", Environment.GetFolderPath(Environment.SpecialFolder.Windows), False)
            'MessageBox.Show(output)
        End If

        ' Replace %ProgramFiles%.
        ' This returns "C:\Program Files (x86)" on 64-bit Windows
        ' when running an application in 32-bit mode, so to get the
        ' "real" Program Files, we'd need %ProgramW6432% instead.
        ' That requires a runtime check to make sure it's running
        ' on a 64-bit system, and if not, it'll use the "%ProgramFiles%"
        ' special folder instead.
        ' There's also the "%programfiles(x86)%" variable, which
        ' would go to "C:\Program Files (x86)" without redirection.
        If regexCheckFlags(execOrArg, "%PROGRAMFILES%", False) Then
            'MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
            output = regexReplaceFlags(execOrArg, "%PROGRAMFILES%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), False)
        End If

        ' Replace AppData.
        If regexCheckFlags(execOrArg, "%APPDATA%", False) Then
            'MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
            output = regexReplaceFlags(execOrArg, "%APPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), False)
        End If

        ' Replace LocalAppData.
        If regexCheckFlags(execOrArg, "%LOCALAPPDATA%", False) Then
            'MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
            output = regexReplaceFlags(execOrArg, "%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), False)
        End If

        ' Replace LocalAppData.
        If regexCheckFlags(execOrArg, "%TEMP%", False) Then
            'MessageBox.Show(System.IO.Path.GetTempPath)
            output = regexReplaceFlags(execOrArg, "%TEMP%", IO.Path.GetTempPath, False)
        End If

        ' Replace LocalAppData.
        If regexCheckFlags(execOrArg, "%TMP%", False) Then
            'MessageBox.Show(System.IO.Path.GetTempPath)
            output = regexReplaceFlags(execOrArg, "%TMP%", IO.Path.GetTempPath, False)
        End If

        Return output
    End Function

End Class
