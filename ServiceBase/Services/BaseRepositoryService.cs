using System;
using DomainModels;
using RepositoryContracts.Repositories;
using ServiceBase.Services.Interfaces;

namespace ServiceBase.Services
{
    public abstract class BaseRepositoryService : IBaseRepositoryService
    {
        protected IBaseRepository _repository;

        public BaseRepositoryService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public virtual void Save<T>(T model) where T : BaseModel
        {
            _repository.Save(model);
        }

        public virtual T GetById<T>(Guid id) where T : BaseModel
        {
            return _repository.GetById<T>(id);
        }
    }
}
