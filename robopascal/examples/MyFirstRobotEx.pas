{$reference ../lib/robocode.dll}
{$reference System.Drawing.dll}

library MyFirstRobotEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;

type
    MyFirstRobot = class(Robot)
    public 
        constructor Create();
        begin
        end;
        
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
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            Fire(1);
        end;
    
    end;

end.    