{$reference ../lib/robocode.dll}
{$reference mscorlib.dll}
{$reference System.Drawing.dll}

library CornersEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;

type
    Corners = class(Robot)
    private 
        // Количество роботов в игре
        others: integer;
        // Угол,в котором находится робот
        corner: integer;
        // Указывает, нужно ли останавливаться, когда другой робот попадает в поле зрения
        stopWhenSeeRobot: boolean;
        rand : System.Random;
    
    public
        constructor Create();
        begin
            rand := new System.Random();
        end;
        
        procedure GoCorner();
        begin
            stopWhenSeeRobot := false;
            TurnRight(Utils.NormalRelativeAngleDegrees(corner - Heading));
            stopWhenSeeRobot := true;
            Ahead(5000);
            TurnLeft(90);
            Ahead(5000);
            TurnGunLeft(90);
        end;
        
        procedure SmartFire(robotDistance: real);
        begin
            if (robotDistance > 200) or (Energy < 15) then
                Fire(1)
            else if (robotDistance > 50) then
                Fire(2)
            else
                Fire(3);
        end;
        
        procedure Run; override;
        begin
            // Устанавливает цвета робота
            BodyColor   := Color.Red;
            GunColor    := Color.Black;
            RadarColor  := Color.Yellow;
            BulletColor := Color.Green;
            ScanColor   := Color.Green;
            
            others      := Others;
            corner      := rand.Next(4) * 90;
            
            // Приказать роботу двигаться в угол
            GoCorner();
            
            // Скорость поворота орудия
            var gunIncrement: integer := 3;
            
            // Вращаем орудие робота
            while true do 
            begin
                for var i := 0 to 29 do
                    TurnGunLeft(gunIncrement);
                // Меняем направление движения оружия                  
                gunIncrement *= -1;        
            end;
        end;
        
        // Вызывается, когда замечен другой робот
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            if stopWhenSeeRobot then
            begin
                Stop();
                smartFire(e.Distance);
                Scan();
                Resume();
            end
            else
                smartFire(e.Distance);
        end;
    end;

end.