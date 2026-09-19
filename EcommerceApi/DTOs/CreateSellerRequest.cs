using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs
{
    public class CreateSellerRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string StoreName { get; set; } = string.Empty;

    }
}
