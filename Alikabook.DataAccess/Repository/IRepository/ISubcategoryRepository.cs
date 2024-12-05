using Alikabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository.IRepository
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        void Update(Subcategory obj);
    }
}
