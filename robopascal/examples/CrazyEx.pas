{$reference ../lib/robocode.dll}
{$reference ../lib/robocode.control.dll}
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
            BodyColor   := Color.Red;
            GunColor    := Color.Black;
            RadarColor  := Color.Yellow;
            BulletColor := Color.Green;
            ScanColor   := Color.Green;
            
            while true do
            begin
                SetAhead(40000);
                movingForward := true;
                SetTurnRight(90);
                WaitFor(new TurnCompleteCondition(self));
                SetTurnLeft(180);
                WaitFor(new TurnCompleteCondition(self));
                SetTurnRight(180);
                WaitFor(new TurnCompleteCondition(self));                  
            end;       
        end;
        
        procedure OnHitWall(e: HitWallEvent); override;
        begin
            ReverseDirection();
        end;
              
        procedure OnScannedRobot(e: ScannedRobotEvent); override;
        begin
            Fire(1);
        end;
        
        procedure OnHitRobot(e: HitRobotEvent); override;
        begin
            if e.IsMyFault then reverseDirection();
        end;
    end;

end.