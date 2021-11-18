using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    abstract class Animal
    {
        private string name;
        public Animal(string name)
        {
            this.name = name;
        }

        public string Name { 
            get => name;
        }
        Random rnd = new Random();
        public virtual void CheckStatus(Cage cage)
        {
            if (this is IFlyable && rnd.Next(10) > 5)
            {
                ((IFlyable)this).Fly();
            }
            else if (this is IWalkable && rnd.Next(10) > 5)
            {
                ((IWalkable)this).Walk();
            }
            else if (this is ISwimmable && rnd.Next(10) > 5)
            {
                ((ISwimmable)this).Swim();
            }
            else if (this is ICanFight && rnd.Next(10) > 5)
            {
                ((ICanFight)this).Fight(cage.GetRandomOpponent());
            }
        }
    }
}
