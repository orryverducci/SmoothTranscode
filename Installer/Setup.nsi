;  Copyright (C) 2011 Atomic Wasteland
;  http://www.atomicwasteland.co.uk/
;
;  This Program is free software; you can redistribute it and/or modify
;  it under the terms of the GNU General Public License as published by
;  the Free Software Foundation; either version 2, or (at your option)
;  any later version.
;   
;  This Program is distributed in the hope that it will be useful,
;  but WITHOUT ANY WARRANTY; without even the implied warranty of
;  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
;  GNU General Public License for more details.
;   
;  You should have received a copy of the GNU General Public License
;  along with GNU Make; see the file COPYING.  If not, write to
;  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
;  http://www.gnu.org/copyleft/gpl.html

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "SmoothTranscode"
  OutFile "setup.exe"
  Caption "SmoothTranscode Beta Setup"
  UninstallCaption "SmoothTranscode Uninstall"
  BrandingText "SmoothTranscode"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\SmoothTranscode"

  ;Request application privileges for Windows Vista/7
  RequestExecutionLevel admin

  ;Version Information
  VIProductVersion "0.2.0.0"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "SmoothTranscode Installer"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyName" "Atomic Wasteland"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "Copyright © Atomic Wasteland 2011"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "Installs SmoothTranscode to your computer"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "1.0.0.0"
  VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductVersion" "0.2.0.0"

;--------------------------------
;Install Functions
Function "desktopshortcut"
  CreateShortCut "$DESKTOP\SmoothTranscode.lnk" "$INSTDIR\SmoothTranscode.exe"
FunctionEnd

;--------------------------------
;Interface Settings

;  !define MUI_ICON "InstallIcon.ico"
;  !define MUI_UNICON "InstallIcon.ico"
;  !define MUI_HEADERIMAGE
;  !define MUI_HEADERIMAGE_BITMAP "installheader.bmp"
;  !define MUI_HEADERIMAGE_RIGHT
;  !define MUI_WELCOMEFINISHPAGE_BITMAP "install.bmp"
;  !define MUI_UNWELCOMEFINISHPAGE_BITMAP "install.bmp"
  !define MUI_ABORTWARNING
  !define MUI_FINISHPAGE_RUN "$INSTDIR\SmoothTranscode.exe"
  !define MUI_FINISHPAGE_SHOWREADME
  !define MUI_FINISHPAGE_SHOWREADME_FUNCTION "desktopshortcut"
  !define MUI_FINISHPAGE_SHOWREADME_TEXT "Create Desktop Shortcut"
  !define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
  !define MUI_FINISHPAGE_RUN_NOTCHECKED
  !define MUI_FINISHPAGE_NOREBOOTSUPPORT

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "../gpl-2.0.txt"
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Settings

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "SmoothTranscode" SecPlayer

  SetOutPath "$INSTDIR"

  ;Files
  File "..\VideoConverter\Bin\Release\SmoothTranscode.exe"
  File "..\VideoConverter\Bin\Release\ffmpeg.exe"
  File "..\VideoConverter\Bin\Release\Help.dll"
  File "..\VideoConverter\Bin\Release\LinkLabel2.dll"
  File "..\VideoConverter\Bin\Release\Renderers.dll"
  File "..\VideoConverter\Bin\Release\Windows7ProgressBar.dll"

  ;Create Shortcuts
  CreateShortCut "$SMPROGRAMS\SmoothTranscode.lnk" "$INSTDIR\SmoothTranscode.exe"

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "DisplayName" "SmoothTranscode"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "UninstallString" "$INSTDIR\Uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "DisplayIcon" "$INSTDIR\SmoothTranscode.exe,0"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "URLInfoAbout" "http://www.atomicwasteland.co.uk/"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "URLUpdateInfo" "http://www.atomicwasteland.co.uk/software/smoothtranscode"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "DisplayVersion" "0.2"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "InstallLocation" "$INSTDIR"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "Publisher" "Atomic Wasteland"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "NoModify" 0x00000001
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode" "NoRepair" 0x00000001


SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecPlayer ${LANG_ENGLISH} "SmoothTranscode"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecPlayer} $(DESC_SecPlayer)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;Files
  Delete "$INSTDIR\SmoothTranscode.exe"
  Delete "$INSTDIR\ffmpeg.exe"
  Delete "$INSTDIR\Help.dll"
  Delete "$INSTDIR\LinkLabel2.dll"
  Delete "$INSTDIR\Renderers.dll"
  Delete "$INSTDIR\Windows7ProgressBar.dll"
  Delete "$SMPROGRAMS\SmoothTranscode.lnk"
  Delete "$INSTDIR\Uninstall.exe"

  ;Remove Directories
  RMDir "$INSTDIR"

  ;Registry
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SmoothTranscode"

SectionEnd