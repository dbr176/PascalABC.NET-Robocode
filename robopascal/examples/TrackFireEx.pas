{$reference ../lib/robocode.dll}
{$reference System.Drawing.dll}

library MyFirstRobot;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;

type
    TrackFire = class(Robot)
    public 
        constructor Create();
        begin
        end;
        
        procedure Run; override;
        begin
            // Всё время поворачиваем орудие вправо
            while True do
                TurnGunRight(10);
        end;
        
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            var absoluteBearing := Heading + e.Bearing;
            var bearingFromGun := Utils.NormalRelativeAngleDegrees(absoluteBearing - GunHeading);
            
            if Math.Abs(bearingFromGun) <= 3 then
            begin
                TurnGunRight(bearingFromGun);
                if GunHeat = 0 then
                    Fire(Math.Min(3 - Math.Abs(bearingFromGun), Energy - 0.1));
            end
            else TurnGunRight(bearingFromGun);
            
            if bearingFromGun = 0 then Scan();
            
        end;
    
    end;    


end.    