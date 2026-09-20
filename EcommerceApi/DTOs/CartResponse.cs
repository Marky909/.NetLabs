namespace EcommerceApi.DTOs;

public class CartResponse
{
    public int CartId { get; set; }
    public List<CartItemResponse> Items { get; set; } = new();
}