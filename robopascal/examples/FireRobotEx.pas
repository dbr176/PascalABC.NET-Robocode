{$reference ../lib/robocode.dll}
{$reference ../lib/robocode.control.dll}
{$reference System.Drawing.dll}

library FireRobotEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;

type
    FireRobot = class(Robot)
    private 
        dist: real := 50;
    
    public 
        constructor Create();
        begin
        end;
        
        procedure Run; override;
        begin
            // Просто поворачиваем орудие вправо
            while true do 
            begin              
                TurnGunRight(5);
            end;
        end;
        
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            // Если друго робот близко и у него много энергии 
            if (e.Distance < 50) and (Energy > 50) then
                // Делаем сильный выстрел
                Fire(3)
            else
                // Иначе делаем слабый выстрел
                Fire(1);
            Scan();           
        end;
        
        // Если в робота попали
        procedure OnHitByBullet(e: HitByBulletEvent); override;
        begin           
            TurnRight(Utils.NormalRelativeAngleDegrees(90 - (Heading - e.Heading)));
            
            Ahead(dist);
            dist *= -1;
            Scan();
        end;
        
        procedure OnHitRobot(e: HitRobotEvent); override;
        begin
            var turnGunAmt: real := Utils.NormalRelativeAngleDegrees(e.Bearing + Heading - GunHeading);
            TurnGunRight(turnGunAmt);
            
            Fire(3);
        end;
    end;

end.