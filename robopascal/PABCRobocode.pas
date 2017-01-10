// Необходимые библиотеки
{$reference lib/robocode.dll}
{$reference lib/robocode.control.dll}

// Задает пространство имен, должно совпадать с именем файла
library PABCRobocode;

// Объявляем робота и наследуем его от отного из классов:
//  Robocode.Robot
//  Robocode.JuniorRobot
//  Robocode.AdvancedRobot
//  Robocode.TeamRobot
//  ...
type
    TestRobot = class(Robocode.Robot)
    public
        constructor Create();
        begin
        end;

        procedure Run(); override;
        begin

        end;
    end;


    // Можно объявлять нескольких роботов
    // Все они отобразятся в едином пространстве имен
    TestRobot2 = class(Robocode.Robot)
    public
        constructor Create();
        begin
        end;

        procedure Run(); override;
        begin

        end;
    end;
end.
