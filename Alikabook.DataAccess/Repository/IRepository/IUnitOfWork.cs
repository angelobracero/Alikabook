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

        void Save();
    }
}
