using System;
using RepositoryBase.Models;

namespace RepositoryBase.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        void Save<T>(T model) where T : BaseModel;
        T GetById<T>(Guid id) where T : BaseModel;
    }
}
