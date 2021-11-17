using System;

namespace ConsoleApp19
{
    internal class Duck
    {
        private string name;

        public Duck(string name)
        {
            this.name = name;
        }

        internal void Move()
        {
            Console.WriteLine($"{name} плавает");
        }
    }
}