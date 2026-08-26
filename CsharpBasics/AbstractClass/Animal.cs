using System;

namespace AbstractClass
{
    abstract class Animal
    {
        public string Name;

        public Animal(string name)
        {
            Name = name;
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }

        public abstract void MakeSound();
    }
}