using GenericCollection;


Console.WriteLine("=======List=======");
List<Product> prd = new List<Product>();
prd.Add(new Product("P100", "KeyBoard", 5000));
prd.Add(new Product("P101", "Monitor", 6000));
prd.Add(new Product("P102", "Graphics card", 7000));


foreach(Product p in prd)
{
    p.ProductDetails();
}

//Console.WriteLine("===Dictionary example ======");
//Dictionary<int, DictionaryProduct> products = new Dictionary<int, DictionaryProduct>();

//// Add products
//products.Add(101, new DictionaryProduct(101, "Laptop", 950.00m));
//products.Add(102, new DictionaryProduct(102, "Mouse", 25.50m));
//products.Add(103, new DictionaryProduct(103, "Keyboard", 75.99m));

//Console.WriteLine("===== Product Search =====\n");

//int searchId = 102;

//if (products.ContainsKey(searchId))
//{
//    Console.WriteLine($"Product found with ID {searchId}\n");
//    products[searchId].Display();
//}
//else
//{
//    Console.WriteLine("Product not found.");
//}