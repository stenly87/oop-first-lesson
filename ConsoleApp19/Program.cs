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
            stud.PrintToConsole();
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
}
