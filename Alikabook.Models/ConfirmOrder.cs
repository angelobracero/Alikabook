using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alikabook.Models
{
    public class ConfirmOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual CustomerInfo User { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string ItemStatus { get; set; } = "pending";

        [Required]
        public double TotalPrice { get; set; }

        public string? ProofOfPayment { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
