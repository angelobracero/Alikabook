using Alikabook.DataAccess.Data;
using Alikabook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IBookInfoRepository BookInfo { get; private set; }
        public ICustomerRepository Customer { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            BookInfo = new BookInfoRepository(db);
            Customer = new CustomerRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
