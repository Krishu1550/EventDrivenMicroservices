using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Product.Model
{
    public class ProductCreate
    {

        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int StockQuantity { get; set; } = 0;

        [Required(ErrorMessage = "Category Type is required")]

        public int CategoryId { get; set; }

        public int DiscountPercentage { get; set; } = 0;

    }
}
