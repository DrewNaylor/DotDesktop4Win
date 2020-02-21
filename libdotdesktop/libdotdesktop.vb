' libdotdesktop - Get info from .desktop files for the DotDesktop4Win
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

    Public Shared Function getInfo(inputFile As String, keyToGet As String, Optional fileName As String = "") As String

        ' Get the input file and put it in an INI file object for later use.
        Dim dotDesktopFile As New IniFile(
            New IniOptions() With {.CommentStarter = IniCommentStarter.Hash})
        dotDesktopFile.Load(New StringReader(System.IO.File.ReadAllText(inputFile)))

        ' Define Desktop Entry section.
        Dim desktopEntrySection As IniSection = dotDesktopFile.Sections(checkHeader(inputFile))


#Region "Getting and returning key values."

        ' Look in the inputFile and return the value for the keyToGet.
#Region "Get Type key."
        If keyToGet = "Type" Then

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
        ElseIf keyToGet = "Name" Then

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

#Region "Get Exec key."
        ElseIf keyToGet = "Exec" Then

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
        ElseIf keyToGet = "Path" Then

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
        ElseIf keyToGet = "Version" Then

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
        ElseIf keyToGet = "Comment" Then

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

#Region "Get URL key."
        ElseIf keyToGet = "URL" Then

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

#Region "What to do when the key isn't an option here."
        Else

            ' Otherwise, just return whatever the user specified in the key field.
            Return "(Key not implemented)"
#End Region

        End If
#End Region

    End Function

End Class
