using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объектно-ориентированное программирование
            // ООП
            // Класс это шаблон для объектов, обладающий
            // данными и поведением
            // Экземпляр (объект) это переменная,
            // созданная на основе класса
            // синтаксис разработки классов
            // объявление класса включает в себя ключевое слово
            // class и имя этого класса
            // после объявления класса следует тело класса
            // классы можно объявлять внутри пространств имен
            // или внутри других классов
            // объявление класса может включать модификаторы 
            // доступа, static, наследование и пр

            //new Student ().PrintToConsole();
            /*List<Student> students = new List<Student>();
            for (int i = 0; i < 10000; i++)
                students.Add(new Student());
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();*/

            //Принципы ООП
            //0) Абстрагирование (Абстрактное понятие описывается
            // классом, экземпляр класса это "сущность", что-то
            // конкретное)
            //1) Инкапсуляция - объединение кода и данных. Данные 
            // характеризуют состояние объекта. Данные внутри объекта
            // должны меняться самим объектом с помощью публичных
            // методов и свойств. Нельзя позволять изменять внутреннее 
            // состояние объекта без его разрешения
            //2) Наследование - создание новых классов на основе 
            // существующих. Новый класс получает разрешенные элементы
            // от родительского класса, плюс имеет собственное состояние
            // и поведение.
            //3) Полиморфизм - один интерфейс = множество реализаций.
            // Возможность работы с объектом с помощью общего интерфейса
            // Преобразование одних объектов в другие объекты
            // Переопределение поведения.

            Human human = new Human { Name = "Серега" };
            human.Walk();
            human.Talk();
            Console.WriteLine();

            Child child = new Child { Name = "Сережа" };
            child.Walk();
            child.Talk();

            // наоборот нельзя (из human в child нельзя)
            Human miniHuman = (Human)child;
            miniHuman.Walk();
            miniHuman.Talk();

            /*
            Student stud = new Student();
            Console.WriteLine(stud["FirstName"]);
            Console.WriteLine(stud["LastName"]);
            stud["FirstName"] = "Максим";
            Console.WriteLine(stud["FirstName"]);
            Console.WriteLine(stud.FirstName);
            stud.LastName = "Фамилия 2";
            Console.WriteLine(stud.LastName);
            stud.PrintToConsole();
            stud.GrowUp += Stud_GrowUp;
            stud.PrintToConsole();*/
        }

        private static void Stud_GrowUp()
        {
            Console.WriteLine("Случилось событие GrowUp");
        }
    }
    // область видимости
    // модификаторы доступа: public, internal, protected, private
    // пример создания класса
    public class Student
    {
        // переменные, объявленные внутри класса, называются
        // полями (field). Значения полей меняют состояние объекта
        string firstName;
        string lastName;

        // свойства (Properties)
        // модификатор_доступа тип_возврата Название 
        // {
        //    get{}
        //    set{}
        // }
        public string FirstName { get => firstName; }
        public string LastName {
            get => lastName;
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    lastName = value;
            }
        }
        // краткая запись свойства
        public int Age { get; set; }

        // события
        // модификатор_доступа event тип_делегата название;
        public event Action GrowUp;

        // конструкторы (код, выполняющийся при создании экземпляра)
        // синтаксис конструктора:
        // модификатор_доступа имя_класса (аргументы)
        // { тело }
        // если конструкторов несколько, то они различаются по аргументами
        // статичный конструктор не имеет аргументов и выполняется 1 раз
        public Student(string fname, string lname)
        {
            values.Add("FirstName", fname);
            values.Add("LastName", lname);
            //Console.WriteLine("Выполняется конструктор с 2 аргументами");
            firstName = fname;
            lastName = lname;
        }
        public Student() : this("Имя", "Фамилия")
        {

            //fs = File.OpenRead("1.txt");
            //Console.WriteLine("Выполняется конструктор без аргументов");
        }
        static Student()
        {

            //Console.WriteLine("Выполняется статичный конструктор");
        }
        //FileStream fs;
        // деструктор
        // тильда ИмяКласса(){}
        // невозможно предсказать, когда он будет выполнен!
        /*static int count = 0;
        ~ Student()
        {
            Console.WriteLine($"Деструктор сработал {++count}");
            if (fs != null)
            {
                fs.Close();
                fs.Dispose();
            }
        }*/

        Dictionary<string, string> values =
            new Dictionary<string, string>();
        // индексатор
        // модификатор_доступа Тип_возврата this[тип индекс]
        // {
        //  get {}
        //  set {} 
        // }
        public string this[string key]
        {
            get
            {
                if (values.ContainsKey(key))
                    return values[key];
                return "Нет такого ключа";
            }
            set // необязательный блок
            {
                values[key] = value;
            }
        }



        // методы
        public void PrintToConsole()
        {
            GrowUp?.Invoke(); // запуск события на исполнение
            // если есть активные подписки
            Console.WriteLine($"{lastName} {firstName}");
        }
    }

    class Human
    { 
        public string Name { get; set; }
        // virtual означает, что реализацию данного элемента
        // можно изменить в классах-наследниках
        public virtual void Walk()
        {
            Console.WriteLine($"{Name} идет");
        }
        public virtual void Talk()
        {
            Console.WriteLine($"{Name} говорит");
        }
    }
    // наследование одного от другого указывается через :
    // в объявлении класса.
    // при наследовании класс-наследник получает все элементы
    // родительского класса с модификатором доступа выше,
    // чем private.
    class Child : Human
    {
        // override используется для указания, что созданный
        // элемент класса переопределяет реализацию такого же
        // элемента в родительском классе
        public override void Walk()
        {
            Console.WriteLine($"{Name} ползет");
            //base.Walk(); через base можно вызвать реализацию
            // из родительского класса
        }

        public override void Talk()
        {
            Console.WriteLine($"{Name} лапочет белиберду");
        }
    }
}
