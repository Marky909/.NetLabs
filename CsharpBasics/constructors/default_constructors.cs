using System;
class BankAccount1
{
    public string name;
    public double balance;

    public BankAccount1()
    {
        name = "unknown";
        balance = 0;
        Console.WriteLine("Bank account successfully created!");
    }
    public void showdetails()
    {
        Console.WriteLine($"Account name is {name}");
        Console.WriteLine($"Account balance is {balance}");
    }

}