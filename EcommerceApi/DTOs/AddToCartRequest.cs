using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs
{
    public class AddToCartRequest
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity  { get; set; }
    }
}
