using System;
using RepositoryBase.Models;

namespace ServiceBase.Services.Interfaces
{
    public interface IBaseRepositoryService
    {
        T GetById<T>(Guid id) where T : BaseModel;
        void Save<T>(T model) where T : BaseModel;
    }
}
