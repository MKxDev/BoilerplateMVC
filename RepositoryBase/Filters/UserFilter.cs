using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Models;

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
