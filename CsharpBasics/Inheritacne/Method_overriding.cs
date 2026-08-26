using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritacne
{
    class Animal1
    {
        public virtual void Speak1()
        {
            Console.WriteLine("Animal speaks");
        }
    }

    class Dog1 : Animal1
    {
        public override void Speak1()
        {
            Console.WriteLine("Dog barks");
        }
}


}
