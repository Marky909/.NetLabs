using System;

public class Employee
{
    private double salary;

    protected string department;

    public string Name;

    public void SetSalary(double amount)
    {
        if (amount > 0)
        {
            salary = amount;
            Console.WriteLine("Salary assigned successfully.");
        }
        else
        {
            Console.WriteLine("Salary must be greater than 0.");
        }
    }

    public void ShowSalary()
    {
        Console.WriteLine($"Salary: {salary}");
    }
}