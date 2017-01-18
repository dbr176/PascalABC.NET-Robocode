{$reference ../lib/robocode.dll}
{$reference System.Drawing.dll}

library SpinBotEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;


// –обот, который передвигаетс€ по кругу и стрел€ет, когда видит противника
type
    SpinBot = class(AdvancedRobot)
    public 
        constructor Create();
        begin
        end;
        
        procedure Run; override;
        begin
            // ”станавливаем цвет робота
            BodyColor := Color.Blue;
            GunColor := Color.Blue;
            RadarColor := Color.Black;
            ScanColor := Color.Yellow;
            
            while True do 
            begin
                // ѕоворачиваемс€
                SetTurnRight(10000);
                MaxVelocity := 5;
                // и одновременно движемс€ вперЄд
                Ahead(10000);
            end;      
        end;
        
        // ≈сли другой робот попал в поле зрени€
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            // —трел€ем
            Fire(3);
        end;
        
        // ≈сли робот врезалс€ в другого робота
        procedure OnHitRobot(e: HitRobotEvent); override;
        begin
            // если робот в поле зрени€ - стрел€ем
            if (e.Bearing > -10) and (e.Bearing < 10) then
                Fire(3);
            // если врезалс€ наш робот, то разворачиваемс€
            if (e.IsMyFault) then
                TurnRight(10);          
        end;
    end;


end.    
