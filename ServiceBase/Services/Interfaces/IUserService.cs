using System;
using RepositoryBase.Models;

namespace ServiceBase.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(string email, string password);
        bool ValidateUser(string email, string password);
        User GetUserByEmail(string email);
        string GetUserNameByEmail(string email);
        void Save<T>(T model) where T : BaseModel;
        T GetById<T>(Guid id) where T : BaseModel;
    }
}