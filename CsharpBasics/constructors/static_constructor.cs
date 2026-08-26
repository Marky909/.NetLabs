using System;

namespace constructors
{
    public class Bankaccount
    {
        static Bankaccount()
        {
            Console.WriteLine("Server loading.......");
            Console.WriteLine("Server ready!!");
        }
        public Bankaccount()
        {
            Console.WriteLine("Bank account created of mr.......!!");
        }
    }
}
