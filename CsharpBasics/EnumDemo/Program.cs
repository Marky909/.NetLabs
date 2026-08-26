using EnumDemo;

OrderStatus order = OrderStatus.Shipped;

Console.WriteLine($"Current Status : {order}");

if (order == OrderStatus.Shipped)
{
    Console.WriteLine("Your order is on the way.");
}

Console.ReadKey();