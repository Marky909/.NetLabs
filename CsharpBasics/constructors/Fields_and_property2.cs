//Example 2 (Professional) – Bank ATM System 
//This is much closer to how software is written.
//Scenario
//You are developing software for an ATM.
//Every bank account has
//Account Number
//Owner Name
//Balance
//Company Rules
//Nobody can directly change Balance.
//Balance cannot become negative.
//Users should only read Balance.
//Deposits happen through methods.
using System;
using constructors; //or u can use namespace as well
public class BankAtmSystem
{
    public string AccountNumber;
    public string OwnerName;
    private double _balance;

    public double Balance
    {
        get
        {
            return _balance;
        }
        set
        {
            if (value < 0)
            {
                _balance = 0;
            }
            else
            {
                _balance = value;
            }
        }
    }
    public BankAtmSystem(string AccountNumber, string OwnerName,double InitialBalance)
    {
        this.AccountNumber = AccountNumber;
        this.OwnerName = OwnerName;
        Balance = InitialBalance;
    }
    public void ShowBalance()
    {
        Console.WriteLine($"{OwnerName} balance is {Balance}");
    }
}
