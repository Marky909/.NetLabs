using System;
using System.Collections.Generic;
using System.Text;

namespace StructDemo
{
   struct Student
    {
        public int Id;
        public string Name;
        public double Marks;

        public void Display()
        {
            Console.WriteLine($"ID    : {Id}");
            Console.WriteLine($"Name  : {Name}");
            Console.WriteLine($"Marks : {Marks}");
        }
    }
}
