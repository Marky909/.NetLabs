namespace EcommerceApi.DTOs;

public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public SellerResponse Seller { get; set; } = null!;

    public CategoryResponse Category { get; set; } = null!;
}

public class SellerResponse
{
    public int Id { get; set; }

    public string StoreName { get; set; } = string.Empty;
}

public class CategoryResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}