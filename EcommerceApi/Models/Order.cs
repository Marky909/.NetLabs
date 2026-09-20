namespace EcommerceApi.Models;

public class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = "Pending";

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}