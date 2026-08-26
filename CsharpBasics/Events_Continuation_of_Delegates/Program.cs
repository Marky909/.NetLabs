using Events_Continuation_of_Delegates;
Order or = new Order();

static void SendEmail()
{
    Console.WriteLine("Email sent.");
}
static void GenerateInvoice()
{
    Console.WriteLine("Invoice generated.");
}

static void NotifyWarehouse()
{
    Console.WriteLine("Warehouse notified.");
}

static void UpdateInventory()
{
    Console.WriteLine("Inventory updated.");
}


or.OrderPlaced += SendEmail;
or.OrderPlaced += GenerateInvoice;
or.OrderPlaced += NotifyWarehouse;
or.OrderPlaced += UpdateInventory;

or.PlaceOrder();
