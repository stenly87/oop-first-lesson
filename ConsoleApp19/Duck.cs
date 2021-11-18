using System;

namespace ConsoleApp19
{
    internal class Duck : Animal, IWalkable, ISwimmable, IFlyable
    {
        public Duck(string name) : base(name)
        {
        }
        
        public void Fly()
        {
            Console.WriteLine($"{Name} летает");
        }
        public void Walk()
        {
            Console.WriteLine($"{Name} ходит");
        }
        public void Swim()
        {
            Console.WriteLine($"{Name} плавает");
        }
    }
}