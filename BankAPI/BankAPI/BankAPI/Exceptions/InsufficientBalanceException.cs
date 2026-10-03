using System.Security.Cryptography.Pkcs;

namespace BankAPI.Exceptions
{
    public class InsufficientBalanceException:Exception
    {
        public InsufficientBalanceException(string message):base(message)
        { 
        }
    }
}
