using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alikabook.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual CustomerInfo User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
