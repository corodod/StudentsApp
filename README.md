Задача 1

В каждой задаче необходимо создать класс, членами которого являются указанные поля и методы. 
Программа должна быть оконным приложением и демонстрировать работу объектов класса. Желательно придерживаться модели MVVM. 
На что следует обратить внимание (за невыполнение оценка будет снижена): 
Обязательно классы реализуются в отдельном модуле. 
Программа оформляется в соответствии с требованиями к разработке ПО (отступы, названия переменных и т.п.). 
В конструкторе класса могут и должны быть настроены значения полей и свойств класса, но инициализация значений должна быть вне класса. 
Например, не следует в конструкторе класса задавать в списке какие-то значения, или какое-то имя студента, если они не передаются в конструктор через параметр.
Варианты задач 1-5 рекомендуется сделать как обобщённые типы.

Вариант №7(мой):
Класс «Студент».
Свойства: фамилия, имя, дата рождения, оценки (индексатор с двумя индексами, первый - номер семестра, второй - строка с названием предмета), курс, группа, список предметов для каждого семестра (сделать возможность передать его в конструктор).
Методы: вычисление средней оценки по всем предметам, средней оценки по указанному предмету, возвращение списка предметов, по которым имеется задолженность.
