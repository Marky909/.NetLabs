using System.Globalization;

namespace EcommerceApi.Models
{
    public class Seller
    {
        public  int  Id { get; set; }
        public  string StoreName{ get; set; }

        public int UserId { get; set; }
        public User  User { get; set; } 

        public ICollection<Product> Products { get; set; }

    }
}
