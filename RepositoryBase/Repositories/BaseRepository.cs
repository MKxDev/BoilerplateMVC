using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;
using RepositoryBase.Models;
using RepositoryBase.Filters;

namespace RepositoryBase.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        private ISession _session;

        protected BaseRepository(ISession session) { _session = session; }

        public virtual T Save<T>(T model) where T : BaseModel
        {
            return _session.Save(model) as T;
        }

        public virtual T GetById<T>(Guid id) where T : BaseModel
        {
            return _session.Query<T>()
                .WithId(id)
                .FirstOrDefault();
        }
    }
}
