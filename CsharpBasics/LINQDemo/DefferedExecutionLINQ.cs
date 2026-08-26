using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LINQDemo
{
    internal class Student

    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name , int age)
        {
            Name = name;
            Age = age;
        }
    }
}
