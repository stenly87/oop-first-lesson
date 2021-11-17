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
            //15.11 Объектно-ориентированное программирование
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

            //16.11 Принципы ООП
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

            // static - элементы помеченные как static,
            // создаются 1 раз за все время жизни приложения

            // 17.11 если класс отмечен как static, то
            // нельзя создать объект этого класса
            // нельзя создать в нем нестатичные конструкторы
            // нельзя создать деструктор и индексатор
            // зато мы можем использовать класс в любом
            // месте приложения, будут использоваться его
            // публичные и статичные элементы (поля, свойства,
            // события и методы (и 1 статичный конструктор))

            // если класс не static и в нем есть static-элементы
            // из не-static элементов мы можем обратиться к static
            // из static-элементов мы не может обратиться к НЕ-static
            // потому что не-static элементы не существуют без объекта

            // static-элементы создаются 1 раз!
            // не-static элементы могут быть созданы для каждого
            // экземпляра класса

            // static-элементы вызываются на классе
            // т.е. буквально с помощью названия класса
            // не-static элементы вызываются на экземпляре

            // 18.11 Интерфейсы

            // интерфейс это ссылочный тип данных, который 
            // декларирует (объявляет) методы, свойства, события
            // без реализации (в основном)

            // синтаксис
            // модификатор_доступа interface IНазваниеИнтерфейса
            // { тело с объявлениями методов, свойств и событий}

            // Нельзя создать экземпляр интерфейса
            // Интерфейсы всегда работают в связке с классами
            // Классы реализуют интерфейсы (буквально в коде
            // выглядит как наследование, причем один класс может
            // реализовывать (наследовать) множество интерфейсов
            // (в c# классы могут наследовать 1 (один) класс и
            // множество интерфейсов)

            // Все элементы, объявляемые в интерфейсе, не имеют
            // модификаторов доступа, поскольку при реализации
            // обязаны стать публичными (public)
            
            Cat cat = new Cat("Марфа");
            Duck duck = new Duck("Джимбо");

            // Новые требования от заказчика:
            // 1) В вольере может быть больше, чем 2 животных
            // на сколько больше, не уточняется
            // 2) Утки могут летать и ходить, а не только плавать
            // 3) Для вип-клиентов надо добавить резиновую утку
            // 4) Метод CheckStatus должен проверять статус всех
            // животных в вольере (включая резиновую уточку)
            // 5) Метод AddAnimal следует переработать с тем,
            // чтобы можно было передавать туда любых животных
            // в т.ч. резиновую уточку

            Cage cage = new Cage();
            cage.AddAnimal(cat);
            cage.AddAnimal(duck);
            cage.AddAnimal(duck);

            cage.CheckStatus();


            object c = new Child { Name = "Ребенок" };
            c = new Student();
            /*c = 1;*/
            if (c is IHumanoid humanoid)  // без этой проверки
                humanoid.Talk();          // будет ошибка, посколько хранится
            // число 1

            // ключевое слово is позволяет проверить
            // является ли объект указанным классом/интерфейсом
            // или его наследником

            // ключевое слово as позволяет произвести
            // безопасное преобразование ссылочных типов 

            // если преобразование невозможно, в левую часть
            // выражения уйдет null
            IHumanoid humanoid1 = c as IHumanoid;
            if (humanoid1 != null)
                humanoid1.Talk();

            // если c as Human == null, то будет создан 
            // новый Human. ?? - оператор проверки на null
            Human human = c as Human ?? new Human();
            human.Talk();

            Human h = new Human();
            Child child = new Child();
            var childInterface = (IHumanoid)child;
            IHumanoid childHumanoid = new Child();
            ((IHumanoid)h).Talk();
            childHumanoid.Walk();

            childHumanoid.Age = 2;
            Console.WriteLine(((Child)childHumanoid).Age);

            //Student human = new Student();
            //human.FirstName = "asfas";

            /*
            human.LastName = null;
            Console.WriteLine($"{human.FirstName} {human.LastName}");
            /*
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
            miniHuman.Talk();*/

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
            Student.PrintToConsole();
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

                if (value != null && value != "")
                if (!string.IsNullOrEmpty(value))
                    lastName = value;
            }
        }
        // краткая запись свойства
        public static int Age { get; set; }

        // события
        // модификатор_доступа event тип_делегата название;
        public static event Action GrowUp;

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
        // статичный конструктор в классе максимум 1
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

        static Dictionary<string, string> values =
            new Dictionary<string, string>();
        // индексатор
        // модификатор_доступа Тип_возврата this[тип индекс]
        // {
        //  get {}
        //  set {} 
        // }
        /*public string this[string key]
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
        }*/

        

        // методы
        public static void PrintToConsole()
        {
            

            GrowUp?.Invoke(); // запуск события на исполнение
            // если есть активные подписки
            //Console.WriteLine($"{lastName} {firstName}");
        }
    }

    // пример интерфейса
    interface IHumanoid
    {
        void Walk();
        void Talk();
        int Age { set; }
        event EventHandler SomeEvent;

    }

    class Human : IHumanoid
    {
        int _age;

        public event EventHandler SomeEvent;

        public string Name { get; set; }
        public int Age {
            get => _age;
            set
            {
                if (value > 0 && value < 150)
                    _age = value;
            }
        }

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
