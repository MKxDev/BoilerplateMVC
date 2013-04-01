using System.Linq;
using NHibernate;
using NHibernate.Linq;
using RepositoryBase.Filters;
using RepositoryBase.Models;
using RepositoryBase.Repositories.Interfaces;

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
