using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookInfoRepository BookInfo { get; }
        ICustomerRepository Customer { get; }
        ICartRepository Cart { get; }
        IConfirmOrderRepository ConfirmOrder { get; }
        IOrderHistoryRepository OrderHistory { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IMessagesRepository Messages { get; }
        ICommentsRepository Comments { get; }
        IUserBookRatingsRepository UserBookRatings { get; }
        ICategoryRepository Category { get; }
        ISubcategoryRepository Subcategory { get; }


        void Save();
    }
}
