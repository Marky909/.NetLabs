using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritacne
{
    public class Animal
    {
        public void Speak()
        {
            Console.WriteLine("Base Method is gonna hide!!!");
        }
    }
    public class Dog:Animal
    {
        public new void Speak()
        {
            Console.WriteLine("Child method");
        }
    }
}
