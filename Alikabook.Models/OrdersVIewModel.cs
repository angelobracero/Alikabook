using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.Models
{
    public class OrdersViewModel
    {
        public IEnumerable<OrderDetails> Orders { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<int> PageNumbersToDisplay { get; set; }
        public string Status { get; set; }
    }

}
