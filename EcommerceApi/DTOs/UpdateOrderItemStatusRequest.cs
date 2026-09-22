using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs
{
    public class UpdateOrderItemStatusRequest
    {
        [Required]
        public string Status { get; set; } = "";
    }
}
