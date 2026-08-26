//base keyword to call a parent (base) constructor

using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritacne
{
 public class Employeee
    {
        public string Name;

        public Employeee(string name)
        {
            Name = name;
            Console.WriteLine("This is base class constructor");
        }
    }
    public class SoftwareEngineerr:Employeee
    {
        public string Language;

        public SoftwareEngineerr(string name , string language):base(name)
        {
            Language = language;
            Console.WriteLine("This is derived class constructor");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name of the employee is : {Name}");
            Console.WriteLine($"language  used by employee is : {Language}");

        }
    }
}
