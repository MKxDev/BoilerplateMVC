using RepositoryBase.Models;

namespace RepositoryBase.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        User GetUserByEmail(string email);
        string GetUserNameByEmail(string email);
    }
}
