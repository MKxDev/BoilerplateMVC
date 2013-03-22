using System.Linq;
using DomainModels;
using NHibernate;
using NHibernate.Linq;
using RepositoryBase.Filters;
using RepositoryContracts.Repositories;

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
