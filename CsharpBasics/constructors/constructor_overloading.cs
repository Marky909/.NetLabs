using System;

namespace constructors
{
    class BankAccount
    {
        public string Name;
        public double Balance;

        public BankAccount(string name)
        {
            Name = name;
            Balance = 0;
        }

        public BankAccount(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public BankAccount()
        {
            Name = "unknown";
            Balance = 0;

        }
        public void ShowDetails()
        {
            Console.WriteLine($"Account name is {Name}");
            Console.WriteLine($"Account Balance is {Balance}");
        }
    }
}
