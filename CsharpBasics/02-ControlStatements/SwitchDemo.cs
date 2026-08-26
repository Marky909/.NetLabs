using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ControlStatements
{

    internal class SwitchDemo
    {
        public static void Run()
        {
            int day = 3;

            switch (day)
            {
                case 1:
                    Console.WriteLine("Sunday");
                    break;

                case 2:
                    Console.WriteLine("Monday");
                    break;

                case 3:
                    Console.WriteLine("Tuesday");
                    break;

                default:
                    Console.WriteLine("Invalid Day");
                    break;
            }
        }
    }
}

