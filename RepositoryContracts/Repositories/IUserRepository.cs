using DomainModels;

namespace RepositoryContracts.Repositories
{
    public interface IUserRepository : IBaseRepository
    {
        User GetUserByEmail(string email);
        string GetUserNameByEmail(string email);
    }
}
