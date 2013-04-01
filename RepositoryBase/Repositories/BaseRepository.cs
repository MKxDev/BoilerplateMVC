using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using RepositoryBase.Filters;
using RepositoryBase.Models;
using RepositoryBase.Repositories.Interfaces;

namespace RepositoryBase.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected ISession _session;

        protected BaseRepository(ISession session) { _session = session; }

        public virtual void Save<T>(T model) where T : BaseModel
        {
            if (model.Id == Guid.Empty)
            {
                model.CreatedDate = DateTime.UtcNow;
            }

            model.ModifiedDate = DateTime.UtcNow;

            _session.Save(model);

            _session.Flush();
        }

        public virtual T GetById<T>(Guid id) where T : BaseModel
        {
            return _session.Query<T>()
                .WithId(id)
                .FirstOrDefault();
        }
    }
}
