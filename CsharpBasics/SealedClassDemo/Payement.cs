using System;

namespace SealedClassDemo
{
    sealed class Payment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment Successful");
        }
    }
}