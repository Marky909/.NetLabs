using System;

class Program
{
    static void Main()
    {
        string student = "mark,csit";

        string[] data = student.Split(',');

        string name = data[0].ToUpper();
        string course = data[1].ToLower();

        string result = string.Concat(name, " - ", course);

        Console.WriteLine(result);
    }
}