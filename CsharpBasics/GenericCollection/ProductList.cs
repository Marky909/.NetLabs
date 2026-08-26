using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GenericCollection
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string id, string name, double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public void ProductDetails()
        {
            Console.WriteLine("====Product Details====");
            Console.WriteLine();
            Console.WriteLine($"Product Id:   {ID}");
            Console.WriteLine($"Product Name:  {Name}");
            Console.WriteLine($"Product Price:  ${Price}");
            Console.WriteLine("\n");
        }

    }
}
