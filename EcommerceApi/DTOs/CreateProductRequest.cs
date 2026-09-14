namespace EcommerceApi.DTOs;

public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int SellerId { get; set; }

    public int CategoryId { get; set; }
}