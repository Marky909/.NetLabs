using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    internal class Calculator
    {
        [Obsolete]
        public void Add()
        {
            Console.WriteLine("Old add method");
        }
    }
}
