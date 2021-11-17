using System;

namespace ConsoleApp19
{
    internal class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public void Move()
        {
            Console.WriteLine($"{name} бегает");
        }
    }
}