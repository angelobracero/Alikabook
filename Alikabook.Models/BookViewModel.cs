using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.Models
{
    public class BookViewModel
    {
        public List<BookInfo> RecentBooks { get; set; }
        public List<BookInfo> BusinessBooks { get; set; }
        public List<BookInfo> BasicBooks { get; set; }
        public List<BookInfo> AdvancedBooks { get; set; }
    }
}
