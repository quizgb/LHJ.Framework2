; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "LHJ.DBViewer"
#define MyAppVersion "1.0"
#define MyAppPublisher "LHJ"
#define MyAppExeName "LHJ.DBViewer.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F842A986-D39E-4110-AFF9-C9D86E630AB5}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
InfoBeforeFile=C:\Users\Administrator\Source\Repos\LHJ.Framework\DBViewer_Setup\설치전.txt
InfoAfterFile=C:\Users\Administrator\Source\Repos\LHJ.Framework\DBViewer_Setup\설치후.txt
OutputDir=C:\Users\Administrator\Source\Repos\LHJ.Framework\DBViewer_Setup
OutputBaseFilename=LHJDBViewer_Setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "korean"; MessagesFile: "compiler:Languages\Korean.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\Administrator\Source\Repos\LHJ.Framework\Compile\LHJ.DBViewer.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Administrator\Source\Repos\LHJ.Framework\Compile\LHJ.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Administrator\Source\Repos\LHJ.Framework\Compile\LHJ.Controls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Administrator\Source\Repos\LHJ.Framework\Compile\LHJ.DBService.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: C:\Program Files\Codejock Software\ISSkin\ISSkin.dll; DestDir: {app}; Flags: dontcopy 
Source: C:\Program Files\Codejock Software\ISSkin\Styles\Office2007.cjstyles; DestDir: {tmp}; Flags: dontcopy
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
procedure LoadSkin(lpszPath: String; lpszIniFileName: String);
external 'LoadSkin@files:isskin.dll stdcall';
procedure UnloadSkin();
external 'UnloadSkin@files:isskin.dll stdcall';
function ShowWindow(hWnd: Integer; uType: Integer): Integer;
external 'ShowWindow@user32.dll stdcall';
function InitializeSetup(): Boolean;
begin
  ExtractTemporaryFile('Office2007.cjstyles');
  LoadSkin(ExpandConstant('{tmp}\Office2007.cjstyles'), 'NormalBlack.ini');
  Result := True;
end;
procedure DeinitializeSetup();
begin
 ShowWindow(StrToInt(ExpandConstant('{wizardhwnd}')), 0);
 UnloadSkin();
end;