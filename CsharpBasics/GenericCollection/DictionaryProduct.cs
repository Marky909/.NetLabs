using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollection
{
    public class DictionaryProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DictionaryProduct(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine($"Product ID : {Id}");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"Price      : ${Price}");
        }
    }
}
