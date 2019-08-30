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


Imports System.IO
Imports MadMilkman.Ini
Public Class InterpretDotDesktopFile

    Friend Shared Sub ReadFile(DotDesktopFileInput As String)
        ' This code here is based on the parsing example:
        ' https://github.com/MarioZ/MadMilkman.Ini/blob/master/MadMilkman.Ini.Samples/MadMilkman.Ini.Samples.VB/IniSamples.vb#L213

        ' Load in the file from a string.
        Dim DotDesktopFile As New IniFile()
        DotDesktopFile.Load(New StringReader(DotDesktopFileInput))

        ' Define Desktop Entry section.
        Dim DesktopEntrySection As IniSection = DotDesktopFile.Sections("Desktop Entry")

    End Sub

End Class
