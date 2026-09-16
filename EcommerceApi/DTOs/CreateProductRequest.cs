using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs;

public class CreateProductRequest
{
    [Required]
    [StringLength(200,MinimumLength =2)]
    public string Name { get; set; } = string.Empty;
    [Range(0.01,double.MaxValue)]
    public decimal Price { get; set; }
    [Range(0,int.MaxValue)]
    public int Stock { get; set; }

    [Range(1, int.MaxValue)]

    public int CategoryId { get; set; }
}