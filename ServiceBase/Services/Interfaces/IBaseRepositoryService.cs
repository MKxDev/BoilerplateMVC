using System;
namespace ServiceBase.Services.Interfaces
{
    interface IBaseRepositoryService
    {
        T GetById<T>(Guid id) where T : RepositoryBase.Models.BaseModel;
        T Save<T>(T model) where T : RepositoryBase.Models.BaseModel;
    }
}
