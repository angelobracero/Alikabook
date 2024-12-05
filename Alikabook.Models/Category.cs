using System.ComponentModel.DataAnnotations;

namespace Alikabook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }

        public virtual ICollection<BookInfo> BookInfos { get; set; } = new List<BookInfo>();

    }

}
