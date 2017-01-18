{$reference ../lib/robocode.dll}
{$reference System.Drawing.dll}

library SpinBotEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;


// �����, ������� ������������� �� ����� � ��������, ����� ����� ����������
type
    SpinBot = class(AdvancedRobot)
    public 
        constructor Create();
        begin
        end;
        
        procedure Run; override;
        begin
            // ������������� ���� ������
            BodyColor := Color.Blue;
            GunColor := Color.Blue;
            RadarColor := Color.Black;
            ScanColor := Color.Yellow;
            
            while True do 
            begin
                // ��������������
                SetTurnRight(10000);
                MaxVelocity := 5;
                // � ������������ �������� �����
                Ahead(10000);
            end;      
        end;
        
        // ���� ������ ����� ����� � ���� ������
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            // ��������
            Fire(3);
        end;
        
        // ���� ����� �������� � ������� ������
        procedure OnHitRobot(e: HitRobotEvent); override;
        begin
            // ���� ����� � ���� ������ - ��������
            if (e.Bearing > -10) and (e.Bearing < 10) then
                Fire(3);
            // ���� �������� ��� �����, �� ���������������
            if (e.IsMyFault) then
                TurnRight(10);          
        end;
    end;


end.    
