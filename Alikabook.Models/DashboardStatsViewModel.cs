using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.Models
{
    public class DashboardStatsViewModel
    {
        public int TotalPendingOrders { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalBooks { get; set; }
        public int TotalBooksSold { get; set; }
        public double TotalSales { get; set; }
    }
}
