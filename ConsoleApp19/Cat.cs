using System;

namespace ConsoleApp19
{
    internal class Cat : Animal, IWalkable, ISwimmable, ICanFight
    {
        public Cat(string name): base(name)
        {

        }

        public void Walk()
        {
            Console.WriteLine($"{Name} ходит");
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} плавает");
        }

        public void Fight(Animal opponent)
        {
            Console.WriteLine($"{Name} лупит {opponent.Name}");
        }
    }
}