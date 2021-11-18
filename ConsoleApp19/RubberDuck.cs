using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class RubberDuck : Animal, ISwimmable
    {
        public RubberDuck(string name) : base(name)
        {
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} плавает");
        }
    }
}
