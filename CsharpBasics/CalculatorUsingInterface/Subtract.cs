using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorUsingInterface
{
    public class Subtract:IOperation
    {
        public double Calculate(double a , double b)
        {
            return a - b;
        }
    }
}
