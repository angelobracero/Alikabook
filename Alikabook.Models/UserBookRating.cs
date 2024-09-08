using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alikabook.Models
{
    public class UserBookRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [ForeignKey("BookInfo")]
        public int BookId { get; set; }

        [Required]
        [Range(1, 5)] 
        public int Rating { get; set; }

        [Required]
        public DateTime RatedOn { get; set; }

        public virtual CustomerInfo User { get; set; } 
        public virtual BookInfo BookInfo { get; set; } 
    }
}
