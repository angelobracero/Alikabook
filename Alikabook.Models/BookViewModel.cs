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
        public List<BookInfo> ProgrammingBooks { get; set; }
        public List<BookInfo> FictionBooks { get; set; }
        public List<BookInfo> NonFictionBooks { get; set; }
        public List<BookInfo> ChildrenBooks { get; set; }
        public List<BookInfo> GraphicBooks { get; set; }
        public List<BookInfo> ScienceBooks { get; set; }

    }
}
