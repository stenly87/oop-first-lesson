using System;

namespace ConsoleApp19
{
    internal class Cage
    {
        private Cat cat;
        private Duck duck;

        internal void AddAnimal(Cat cat)
        {
            this.cat = cat;
        }

        internal void AddAnimal(Duck duck)
        {
            this.duck = duck;
        }

        internal void CheckStatus()
        {
            cat.Move();
            duck.Move();
        }
    }
}