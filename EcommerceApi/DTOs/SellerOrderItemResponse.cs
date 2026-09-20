namespace EcommerceApi.DTOs;

public class SellerOrderItemResponse
{
    public int OrderId { get; set; }
    public int OrderItemId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }
}