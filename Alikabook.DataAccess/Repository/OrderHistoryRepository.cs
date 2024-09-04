using Alikabook.DataAccess.Data;
using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository
{
    public class OrderHistoryRepository : Repository<OrderHistory>, IOrderHistoryRepository
    {
        private ApplicationDbContext _db;

        public OrderHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHistory obj)
        {
            _db.OrderHistory.Update(obj);
        }
    }
}
