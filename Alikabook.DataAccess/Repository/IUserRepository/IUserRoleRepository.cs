using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.DataAccess.Repository.IUserRepository
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRolesAsync();
    }
}
