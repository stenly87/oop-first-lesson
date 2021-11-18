using System;
using System.Collections.Generic;

namespace ConsoleApp19
{
    internal class Cage
    {
        List<Animal> animals = new List<Animal>();

        internal void AddAnimal(Animal animal)
        {// upcast преобразование к родительскому классу
            animals.Add(animal);
        }

        internal void CheckStatus()
        {
            animals.ForEach(s => s.CheckStatus(this));        
        }
        Random rnd = new Random();
        internal Animal GetRandomOpponent()
        {
            return animals[rnd.Next(0, animals.Count)];
        }
    }
}