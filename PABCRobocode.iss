; Скрипт создания установщика PascalABC.NET Robocode
; Бирюков А.С.
; 2016

#define MyAppName             "PascalABC.NET Robocode"
#define MyAppVersion          "0.1"
#define MyAppPublisher        "MMCS"
#define MyAppURL              "http://pascalabc.net/"

#define PABCStartMenu         "PascalABC.NET"

#define PABCWorkINI           "pabcworknet.ini"
#define RobocodeInstallPrefix "Robocode"

#define MinJRE                "1.6"
#define WebJRE                "https://java.com"


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
; Меню Пуск
Name: "{group}\Запустить Robocode"; Filename: "{app}/robopascal-runner.exe"; WorkingDir: "{app}"; Comment: "{cm:RunRobocode}"; IconFilename: "{app}/robocode.ico"
Name: "{group}\Удалить PascalABC.NET Robocode"; Filename: "{uninstallexe}"
; Рабочий стол
Name: "{userdesktop}\Запустить Robocode"; Filename: "{app}/robopascal-runner.exe"; WorkingDir: "{app}"; Comment: "{cm:RunRobocode}"; IconFilename: "{app}/robocode.ico"


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

function IsJREInstalled: Boolean;
var
  JREVersion: string;
begin
  Result := RegQueryStringValue(HKLM32, 'Software\JavaSoft\Java Runtime Environment',
    'CurrentVersion', JREVersion);

  if not Result and IsWin64 then
    Result := RegQueryStringValue(HKLM64, 'Software\JavaSoft\Java Runtime Environment',
      'CurrentVersion', JREVersion);

  if Result then
    Result := CompareStr(JREVersion, '{#MinJRE}') >= 0;
end;


function IsPascalInstalled: Boolean;
begin
  Result := GetPABCPath <> '';
end;



function InitializeSetup: Boolean;
var
  WorkPath: AnsiString;
  ErrorCode: Integer;
begin
  Result := True;
  if not IsPascalInstalled then
  begin
    if MsgBox(ExpandConstant('{cm:PascalNotFound}'), mbConfirmation, MB_YESNO) = IDYES then
    begin
      Result := False;
      ShellExec('', '{#MyAppURL}', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
    end;
  end;

  if not IsJREInstalled then
  begin
    if MsgBox(ExpandConstant('{cm:JavaNotFound}'), mbConfirmation, MB_YESNO) = IDYES then
    begin
      ShellExec('', '{#WebJRE}', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
    end;
  end;


  // Устанавливаем путь установки в PABCWork.NET
  if not LoadStringFromFile(GetPABCPath + '/' + '{#PABCWorkINI}', WorkPath) then
  begin
    Result := False;
    MsgBox(ExpandConstant('{cm:PascalNotFound}'), mbInformation, MB_OK); // TODO: другая ошибка
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
english.PascalNotFound=PascalABC.NET not found! Do you want to download it now?
russian.PascalNotFound=PascalABC.NET не найден! Перейти на сайт для загрузки?

english.JavaNotFound=JRE not found! Do you want to download it now?
russian.JavaNotFound=JRE не найден! Перейти на сайт для загрузки?

russian.RunRobocode=Запустить Robocode
english.RunRobocode=Run Robocode
