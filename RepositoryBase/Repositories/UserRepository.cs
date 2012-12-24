using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Repositories.Interfaces;
using NHibernate;
using RepositoryBase.Models;
using NHibernate.Linq;
using RepositoryBase.Filters;

namespace RepositoryBase.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ISession session) : base(session) { }

        public User GetUserByEmail(string email)
        {
            return _session.Query<User>()
                           .WithEmail(email)
                           .FirstOrDefault();
        }


        public string GetUserNameByEmail(string email)
        {
            return _session.Query<User>()
                           .WithEmail(email)
                           .Select(u => u.Email)
                           .FirstOrDefault();
        }
    }
}
