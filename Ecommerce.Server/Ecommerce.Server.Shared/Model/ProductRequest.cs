using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Product.Model
{
    public class ProductRequest
    {

        [Required]
        public Guid Id { get; set; }

        public int PurchaseQuantity { get; set; } = 1;


    }
}
