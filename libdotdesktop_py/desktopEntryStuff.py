# libdotdesktop_py - Get info from .desktop files for the DotDesktop4Win
# partial implementation of Freedesktop.org's Desktop Entry spec.
# This is a limited port of libdotdesktop_standard to Python.
# Copyright (C) 2021 Drew Naylor
# (Note that the copyright years include the years left out by the hyphen.)
#
# This file is a part of the DotDesktop4Win project.
# Neither DotDesktop4Win nor Drew Naylor are associated with Freedesktop.org.
#
#
#   Licensed under the Apache License, Version 2.0 (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.



import configparser

def getInfo(self, inputFile, keyToGet, fileName = "", IsCustomKey = False):
	# fileName and IsCustomKey are both optional.