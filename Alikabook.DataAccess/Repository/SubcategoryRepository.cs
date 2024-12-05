using Alikabook.DataAccess.Data;
using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository
{
    public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        private ApplicationDbContext _db;

        public SubcategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Subcategory obj)
        {
            _db.Subcategories.Update(obj);
        }
    }
}
