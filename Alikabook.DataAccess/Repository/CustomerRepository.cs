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
    public class CustomerRepository : Repository<CustomerInfo>, ICustomerRepository
    {
        private ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CustomerInfo obj)
        {
            _db.Customer.Update(obj);
        }
    }
}
