using System;

public class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"{amount} deposited in the bank account.");
        }
        else
        {
            Console.WriteLine("Cannot deposit an amount less than or equal to 0.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"{amount} withdrawn successfully.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Current Balance: {balance}");
    }
}