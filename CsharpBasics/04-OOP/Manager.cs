using System;

public class Manager : Employee
{
    public Manager()
    {
        department = "IT Department";
    }

    public void ShowDepartment()
    {
        Console.WriteLine($"Department: {department}");
    }
}