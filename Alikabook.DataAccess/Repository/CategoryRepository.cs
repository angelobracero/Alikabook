using Alikabook.DataAccess.Data;
using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;

namespace Alikabook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}

