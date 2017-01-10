; Ñêðèïò ñîçäàíèÿ óñòàíîâùèêà PascalABC.NET Robocode
; Áèðþêîâ À.Ñ.
; 2016

#define MyAppName             "PascalABC.NET Robocode"
#define MyAppVersion          "0.1"
#define MyAppPublisher        "MMCS"
#define MyAppURL              "http://pascalabc.net/"

#define PABCStartMenu         "PascalABC.NET"

#define PABCWorkINI           "pabcworknet.ini"
#define RobocodeInstallPrefix "Robocode"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9B10DB3F-AA15-4349-A290-2CC323514250}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
AppReadmeFile={#MyAppURL}
CreateAppDir=yes
LicenseFile=robocode/license/epl-v10.txt
DefaultDirName=/
DisableDirPage=yes
DisableProgramGroupPage=auto
DefaultGroupName={#PABCStartMenu}\{#RobocodeInstallPrefix}
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-setup
Compression=lzma
SolidCompression=yes
PrivilegesRequired=lowest
OutputDir=/

[Files]
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "robocode/*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; MinVersion: 0,5.01
Source: "robopascal/*"; DestDir: "{app}/robopascal"; Flags: ignoreversion recursesubdirs createallsubdirs; MinVersion: 0,5.01


[Icons]
; Ìåíþ Ïóñê
Name: "{group}\Robocode-ðîáîò"; Filename: "{app}/robopascal/PABCRobocode.pas"; WorkingDir: "{app}"; Comment: "{cm:AboutRobocode}"; IconFilename: "{app}/robocode.ico"
Name: "{group}\Çàïóñòèòü Robocode"; Filename: "{app}/RobocodeRun.exe"; WorkingDir: "{app}"; Comment: "{cm:RunRobocode}"; IconFilename: "{app}/robocode.ico"
Name: "{group}\Óäàëèòü PascalABC.NET Robocode"; Filename: "{uninstallexe}"
; Ðàáî÷èé ñòîë
Name: "{userdesktop}\Robocode-ðîáîò"; Filename: "{app}/robopascal/PABCRobocode.pas"; WorkingDir: "{app}"; Comment: "{cm:AboutRobocode}"; IconFilename: "{app}/robocode.ico"
Name: "{userdesktop}\Çàïóñòèòü Robocode"; Filename: "{app}/RobocodeRun.exe"; WorkingDir: "{app}"; Comment: "{cm:RunRobocode}"; IconFilename: "{app}/robocode.ico"


[Code]
var
  InstallDir: String;

function GetPABCPath: String;
var Path: String;
begin
  if RegQueryStringValue(HKEY_CURRENT_USER, 'SOFTWARE\PascalABC.NET', 'Install Directory', Path) then
  begin
    Result := Path;
  end;
end;

function InitializeSetup: Boolean;
var
  WorkPath: AnsiString;
begin
  Result := True;
  // Óñòàíîâëåí ëè PascalABC.NET
  if GetPABCPath = '' then
  begin
    Result := False;
    MsgBox(ExpandConstant('{cm:PascalNotFound}'), mbInformation, MB_OK);
  end;

  // Óñòàíàâëèâàåì ïóòü óñòàíîâêè â PABCWork.NET
  if not LoadStringFromFile(GetPABCPath + '/' + '{#PABCWorkINI}', WorkPath) then
  begin
    Result := False;
    MsgBox(ExpandConstant('{cm:PascalNotFound}'), mbInformation, MB_OK); // TODO: äðóãàÿ îøèáêà
  end;
  InstallDir := WorkPath + '/' + '{#RobocodeInstallPrefix}';
end;

procedure InitializeWizard();
begin
  WizardForm.DirEdit.Text := InstallDir;
end;


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[CustomMessages]
english.PascalNotFound=PascalABC.NET not found!
russian.PascalNotFound=PascalABC.NET íå íàéäåí!

russian.RunRobocode=Çàïóñòèòü Robocode ñî ñâîèì ðîáîòîì
english.RunRobocode=Run Robocode with your own robot

russian.AboutRobocode=Îòêðûâàåò ôàéë PascalABC.NET, â êîòîðîì ìîæíî îïèñàòü ðîáîòà
english.AboutRobocode=Open PascalABC.NET file, where you can write your own robot
