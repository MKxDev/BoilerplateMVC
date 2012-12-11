using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Models;

namespace RepositoryBase.Filters
{
    public static class BaseFilters
    {
        public static IQueryable<T> WithId<T>(this IQueryable<T> query, Guid id) 
            where T : BaseModel
        {
            return query
                .Where(x => x.Id == id);
        }
    }
}
