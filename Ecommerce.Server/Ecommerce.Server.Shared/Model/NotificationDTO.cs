using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Server.Shared.Model

{
	public class NotificationDTO
	{
		[Required(ErrorMessage = "Notification ID is required")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Message is required")]
		public string Message { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}