using System;
using System.ComponentModel.DataAnnotations;

namespace Alikabook.Models
{
    public class BookInfo
    {
        [Key]
        public int Bid { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public int Stock { get; set; }
    }
}
