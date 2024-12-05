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
        public ICartRepository Cart { get; private set; }
        public IConfirmOrderRepository ConfirmOrder { get; private set; }
        public IOrderHistoryRepository OrderHistory { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IMessagesRepository Messages { get; private set; }
        public ICommentsRepository Comments { get; private set; }
        public IUserBookRatingsRepository UserBookRatings { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ISubcategoryRepository Subcategory { get; private set; }



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            BookInfo = new BookInfoRepository(db);
            Customer = new CustomerRepository(db);
            Cart = new CartRepository(db);
            ConfirmOrder = new ConfirmOrderRepository(db);
            OrderHistory = new OrderHistoryRepository(db);
            OrderDetails = new OrderDetailsRepository(db);
            Messages = new MessagesRepository(db);
            Comments = new CommentsRepository(db);
            UserBookRatings = new UserBookRatingsRepository(db);
            Category = new CategoryRepository(db);
            Subcategory = new SubcategoryRepository(db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
