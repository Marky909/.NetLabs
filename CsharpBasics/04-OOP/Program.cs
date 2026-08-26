using System;
using static _04_OOP.Program;

Console.WriteLine("===== Bank Account Example =====");

BankAccount account = new BankAccount();

account.Deposit(5000);
account.Withdraw(2000);
account.ShowBalance();

Console.WriteLine();

Console.WriteLine("===== Employee Example =====");

Manager manager = new Manager();

manager.Name = "Marky";

Console.WriteLine($"Manager Name: {manager.Name}");

manager.SetSalary(50000);

manager.ShowSalary();

manager.ShowDepartment();

// manager.salary = 50000;      // Error
// manager.department = "HR";   // Error


Console.WriteLine();
Console.WriteLine("===== Access Modifier Demo =====");

AccessModifierDemo.Run();