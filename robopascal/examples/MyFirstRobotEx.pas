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
                // Движемся вперёд
                Ahead(100);
                // Попрачиваем орудие вправо
                TurnGunRight(360);
                // Движемся назад
                Back(100);
                // попорачиваем орудие вправо
                TurnGunRight(360);
            end;  
        end;
        
        // Если видим врага, то открываем огонь
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            Fire(1);
        end;
    
    end;

end.    