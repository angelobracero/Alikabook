using Alikabook.Models;

public class PaginatedBooksViewModel
{
    public List<BookInfo> Books { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public string? SearchQuery { get; set; }
    public IEnumerable<int> PageNumbersToDisplay { get; set; }
}
