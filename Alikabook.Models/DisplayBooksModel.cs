using Alikabook.Models;

public class DisplayBooksModel
{
    public IEnumerable<BookInfo> Books { get; set; }
    public string Category { get; set; }
    public string Subcategory { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
