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
    public class CommentsRepository : Repository<Comments>, ICommentsRepository
    {
        private ApplicationDbContext _db;

        public CommentsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Comments obj)
        {
            _db.Comments.Update(obj);
        }
    }
}
