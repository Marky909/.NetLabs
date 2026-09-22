namespace EcommerceApi.DTOs;

public class AdminOrderResponse
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<AdminOrderItemResponse> Items { get; set; } = new();
}