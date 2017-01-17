{$reference ../lib/robocode.dll}
{$reference ../lib/robocode.control.dll}
{$reference System.Drawing.dll}

library MyFirstRobot;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;

type MyFirstRobot = class(Robot)
  procedure Run; override;
  begin
    while true do
    begin
      // �������� �����
      Ahead(100);
      // ����������� ������ ������
      TurnGunRight(360);
      // �������� �����
      Back(100);
      // ������������ ������ ������
      TurnGunRight(360);
    end;  
  end;
  
  // ���� ����� �����, �� ��������� �����
  procedure OnScannedRobot(e : ScannedRobotEvent); override;
  begin
      Fire(1);
  end;

end;

end.    