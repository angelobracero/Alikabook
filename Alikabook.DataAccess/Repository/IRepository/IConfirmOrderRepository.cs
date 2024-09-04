using Alikabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository.IRepository
{
    public interface IConfirmOrderRepository : IRepository<ConfirmOrder>
    {
        void Update(ConfirmOrder obj);
    }
}
