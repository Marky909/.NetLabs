using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
   public class DelegateExample
    {
        public void Func()
        {
            Console.WriteLine("This is delegate");
        }
       
        public delegate void MyDel();

    }
}
