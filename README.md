# PascalABC.NET Robocode

Используются готовые бинарники Robocode 1.9.2.5

## Структура

Проект распаковывается в папку PABCWork.NET, либо любую другую указанную при установке PascalABC.NET.

В данной папке создается подкаталог: Robocode.

Robocode включает в себя дистрибутив robocode'а и вспомогательный .exe для копирования .dll и запуска robocode.

Есть подкаталог pascal. Он включает в себя необходимые файлы для написания своих роботов на языке PascalABC.NET.

## Подготовка к сборке

Необходимые компоненты:
  * [PascalABC.NET](http://pascalabc.net/)
  * [Java](https://java.com/)

Необходимо скомпилировать robocode\RobocodeRun.pas
```
    cd robocode
    C:\Program Files (x86)\PascalABC.NET\pabcnetcclear.exe RobocodeRun.pas
```

## Сборка установочного пакета

Необходимые компоненты:
  * [Inno Setup Unicode](http://www.jrsoftware.org/isdl.php).
  * [Inno Script Studio](https://www.kymoto.org/products/inno-script-studio/downloads).

Открыть .iss файл и скомпилировать его.

## Запуск

Запустить .exe, на рабочем столе и в меню ПУСК появятся ярлыки на необходимые элементы.
