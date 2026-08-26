using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorUsingInterface
{
   
        public class Add : IOperation
        {
            public double Calculate(double a, double b)
            {
                return a + b;
            }
        }
    }

