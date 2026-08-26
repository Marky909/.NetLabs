using System;


namespace constructors
{
    public class Bankaccc
    {
        public Bankaccc()
        {
            Console.WriteLine("Account created");
        }
        ~Bankaccc()
        {
            Console.WriteLine("Account destroyed");
        }
    }
}

//In modern C#, you almost never write destructors.

//Why?

//The Garbage Collector (GC) automatically frees memory.

//Destructors are only useful when you manage unmanaged resources 
//    (like native file handles or OS resources), and even then, 
//    the preferred pattern is IDisposable with Dispose().