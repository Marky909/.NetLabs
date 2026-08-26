using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorUsingInterface
{
    
        public class Divide : IOperation
        {
            public double Calculate(double a, double b)
            {
                if (b == 0)
                {
                return double.NaN;
            }
                return a / b;
            }
        }

    }

