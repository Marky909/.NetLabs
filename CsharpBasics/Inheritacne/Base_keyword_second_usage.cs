using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritacne
{
    class Employ
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee starts working.");
        }
    }

    class SoftwareEngineerrr : Employ
    {
        public override void Work()
        {
            base.Work();      // Call parent's Work()

            Console.WriteLine("Writes C# code.");
        }
    }

}
