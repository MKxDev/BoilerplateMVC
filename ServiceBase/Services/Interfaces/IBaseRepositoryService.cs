using System;
using DomainModels;

namespace ServiceBase.Services.Interfaces
{
    interface IBaseRepositoryService
    {
        T GetById<T>(Guid id) where T : BaseModel;
        void Save<T>(T model) where T : BaseModel;
    }
}
