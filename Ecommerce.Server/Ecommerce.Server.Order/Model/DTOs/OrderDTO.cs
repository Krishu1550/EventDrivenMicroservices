namespace Ecommerce.Server.Order.Model.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }


        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Default to current time    


        public DateTime? DeliveryDate { get; set; } // Nullable if not yet delivered    

        public OrderStatus Status { get; set; } // e.g., "Pending", "Shipped", "Delivered", etc.

    }
}
