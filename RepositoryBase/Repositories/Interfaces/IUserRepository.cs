using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Models;

namespace RepositoryBase.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        User GetUserByEmail(string email);
    }
}
