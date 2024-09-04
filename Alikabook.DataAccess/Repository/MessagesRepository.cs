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
    public class MessagesRepository : Repository<Messages>, IMessagesRepository
    {
        private ApplicationDbContext _db;

        public MessagesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Messages obj)
        {
            _db.Messages.Update(obj);
        }
    }
}
