' libdotdesktop - Get info from .desktop files for the DotDesktop4Win
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



Imports System.IO
Imports MadMilkman.Ini
Public Class desktopEntryStuff

    Public Shared Function getInfo(inputFile As String, keyToGet As String, Optional fileName As String = "") As String

        ' Get the input file and put it in an INI file object for later use.
        Dim dotDesktopFile As New IniFile(
            New IniOptions() With {.CommentStarter = IniCommentStarter.Hash})
        dotDesktopFile.Load(New StringReader(inputFile))

        ' Define Desktop Entry section.
        Dim desktopEntrySection As IniSection = dotDesktopFile.Sections("Desktop Entry")

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
                ' Otherwise, return a message saying the key is not available.
                Return "(Exec key not available)"
            End If
            Return desktopEntrySection.Keys("Exec").Value
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
