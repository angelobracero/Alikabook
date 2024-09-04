using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alikabook.Models
{
    public class OrderHistory
    {
        [Key]
        public int OrderHistoryId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual CustomerInfo User { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string ItemStatus { get; set; } = "completed";

        [Required]
        public double TotalPrice { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
