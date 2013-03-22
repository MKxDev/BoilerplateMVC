using System;
using DomainModels;

namespace RepositoryContracts.Repositories
{
    public interface IBaseRepository
    {
        void Save<T>(T model) where T : BaseModel;
        T GetById<T>(Guid id) where T : BaseModel;
    }
}
