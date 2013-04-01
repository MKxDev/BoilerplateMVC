using System;
using RepositoryBase.Models;
using RepositoryBase.Repositories.Interfaces;
using ServiceBase.Services.Interfaces;

namespace ServiceBase.Services
{
    public abstract class BaseRepositoryService : IBaseRepositoryService
    {
        protected IBaseRepository Repository { get; private set; }

        protected BaseRepositoryService(IBaseRepository repository)
        {
            Repository = repository;
        }

        public virtual void Save<T>(T model) where T : BaseModel
        {
            Repository.Save(model);
        }

        public virtual T GetById<T>(Guid id) where T : BaseModel
        {
            return Repository.GetById<T>(id);
        }
    }
}
