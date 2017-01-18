{$reference ../lib/robocode.dll}
{$reference System.Drawing.dll}


library CrazyEx;

uses
    System.Drawing,
    Robocode,
    Robocode.Util;


type
    Crazy = class(AdvancedRobot)
    private 
        movingForward: boolean;
    public
    
        constructor Create();
        begin
        end;
        
        procedure ReverseDirection();
        begin
            if movingForward then begin
                SetBack(40000);
                movingForward := false;
            end
            else begin
                SetAhead(40000);
                movingForward := true;
            end;
        end;
        
        procedure Run; override;
        begin
            // Устанавливаем цвет робота
            BodyColor   := Color.Red;
            GunColor    := Color.Black;
            RadarColor  := Color.Yellow;
            BulletColor := Color.Green;
            ScanColor   := Color.Green;
            
            while true do
            begin
                // Приказываем роботу двигаться вперёд
                SetAhead(40000);
                movingForward := true;
                // Попрачиваем вправо на угол 90 градусов
                SetTurnRight(90);
                // Ожидаем конец хода
                WaitFor(new TurnCompleteCondition(self));
                SetTurnLeft(180);
                WaitFor(new TurnCompleteCondition(self));
                SetTurnRight(180);
                WaitFor(new TurnCompleteCondition(self));                  
            end;       
        end;
        
        // Вызывается, когда робот врезается в стену
        procedure OnHitWall(e: HitWallEvent); override;
        begin
            // Меняем направление
            ReverseDirection();
        end;
        
        // Вызывается, когда замечен другой робот
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            // Делаем выстрел
            Fire(1);
        end;
        
        // Вызывается, когда робот врезается в другого робота
        procedure OnHitRobot(e: HitRobotEvent); override;
        begin
            // Если врезался наш робот, то меняем направление
            if e.IsMyFault then reverseDirection();
        end;
    end;

end.