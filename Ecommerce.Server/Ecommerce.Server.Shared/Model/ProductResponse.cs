using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Server.Shared.Model
{
    public  class ProductResponse
    {

        [Required]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Product Name is required")]   
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string TagMessage { get; set; } = string.Empty;  

        public string ImageUrl { get; set; } = string.Empty;


        [Required(ErrorMessage ="Category Type is required")]
       
        public int CategoryId { get; set; }


      
        public int DiscountPercentage { get; set; } = 0;  
    }
}
