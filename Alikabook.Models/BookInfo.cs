using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Alikabook.Models
{
    public class BookInfo
    {
        [Key]
        public int BookId { get; set; }

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

        public string? Image { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int Stock { get; set; }
            
        public double? Rating { get; set; }

        public int RatingCount { get; set; } = 0;

        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
    }
}
