using System.Linq;
using DomainModels;

namespace RepositoryBase.Filters
{
    public static class UserFilter
    {
        public static IQueryable<User> WithEmail(this IQueryable<User> query, string email)
        {
            return query
                .Where(x => x.Email == email);
        }
    }
}
