using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Continuation_of_Delegates
{
    public delegate void OrderHandler();
    public class Order
    {
        public event OrderHandler OrderPlaced;

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully.");

            OrderPlaced?.Invoke();
        }
    }
}

