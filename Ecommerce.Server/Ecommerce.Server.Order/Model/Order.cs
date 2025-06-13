using System.Text.Json.Serialization;

namespace Ecommerce.Server.Order.Model
{
    public class Order
    {

        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }


        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.UtcNow; // Default to current time    


        public DateTime? DeliveryDate { get; set; } // Nullable if not yet delivered    

        public OrderStatus Status { get; set; } // e.g., "Pending", "Shipped", "Delivered", etc.



        // Additional properties can be added as needed
    }

     [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }

}