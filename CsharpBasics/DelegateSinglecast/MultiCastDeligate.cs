using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public class Calc
    {
        public void Sum(int num1,int num2)
        {
            Console.WriteLine($"The sum of {num1} and {num2} is {num1 + num2}");
        }
        public void Diff(int num1, int num2)
        {
            Console.WriteLine($"The Diff of {num1} and {num2} is {num1 - num2}");
        }
        public void Product(int num1, int num2)
        {
            Console.WriteLine($"The Product of {num1} and {num2} is {num1 * num2}");
        }
        public void Div(int num1, int num2)
        {
            Console.WriteLine($"The Division of {num1} and {num2} is {num1 / num2}");
        }
        public void Modulus(int num1,int  num2)
        {
            Console.WriteLine($"The Modulus of {num1} and {num2} is {num1 % num2}");

        }

       

    }
    public delegate void MyDel(int a, int b);
}
