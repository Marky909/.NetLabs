using AbstractClass;
using System;
using System.Xml.Linq;

namespace AbstractClass
{
    class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says Meow!");
        }
    }
}