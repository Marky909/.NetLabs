using System;


namespace _02_ControlStatements;

internal class IfElseTesting
{
    public static void Run()
    {
        int marks = 78;

        if (marks >= 90)
        {
            Console.WriteLine("Grade A+");
        }
        else if (marks >= 80)
        {
            Console.WriteLine("Grade A");
        }
        else if (marks >= 70)
        {
            Console.WriteLine("Grade B");
        }
        else
        {
            Console.WriteLine("Fail");
        }
    }
}