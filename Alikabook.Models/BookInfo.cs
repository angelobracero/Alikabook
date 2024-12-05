using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int? CategoryId { get; set; }

        [NotMapped]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int? SubcategoryId { get; set; }

        [NotMapped]
        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Image { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        //[Required]
        public string? Publisher { get; set; }

        //[Required]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Invalid ISBN format")]
        public string? ISBN { get; set; } 

        //[Required]
        [Range(1450, int.MaxValue, ErrorMessage = "Year must be after 1450")] 
        public int? Year { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public int? Pages { get; set; }

        [Required]
        public int Stock { get; set; }
            
        public double? Rating { get; set; }

        public int RatingCount { get; set; } = 0;

        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
