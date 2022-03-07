# SpaceGame
В проекте придерживался принципов SOLID.

Контент проекта:
  1) Игрок:
  
    a) Корабль.
    b) 3 типа орудий.
    c) 3 типа снарядов.
    d) Здоровье.
    e) Энергетический щит.

  2) Противники:
  
    a) 3 типа астероидов
    b) 2 типа атакующих кораблей
    c) Здоровье/урон.
    d) Респаун.

  3) Расходники.
  4) Интерфейс.
  5) Меню.
  6) Звуковое сопровождение.
____________________________________________

Любые объекты за пределами зоны видимости уничтожаются.
Интерфейс отображает информацию о здоровье, защите и очках игрока.

Каждое орудие имеет массив типа ChargeType(префаб снаряда, характеристики выстрела).
Для добавления очередного типа достаточно в инспекторе добавить префаб снаряда и указать характеристики для выстрела.

Каждый тип снаряда имеет свою траекторию движения.
Корректировка характеристик снаряда проводиться в инспекторе.

Респаун противников имеет два скрипта, для каждого типа противников.
Скрипты содержат массив типа SpawnWaveType(префабы противников, время респауна, время волны)
для удобного редактирования сложности уровня через инспектор.

Расходники(здоровье, энергия для щита, обоймы для снарядов) случайным образом выпадают из всех противников,
в инспекторе можно выставить вероятности.