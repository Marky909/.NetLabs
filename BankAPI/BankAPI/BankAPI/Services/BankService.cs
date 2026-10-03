namespace BankAPI.Services
{
    public class BankService
    {
        private decimal _balance = 5000;

        public decimal Withdraw(decimal amount)
        {
            if(amount<=0)
            {
                throw new Exception("Withdrawl amount must be greater than 0");
            }

            if (amount > _balance)
                throw new Exception("Withdrawal amount cant exceed the total bank balance");


            _balance -= amount;

            return _balance;
        }


    }
}
