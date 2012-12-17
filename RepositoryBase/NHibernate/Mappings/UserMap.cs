using RepositoryBase.Models;

namespace RepositoryBase.NHibernate.Mappings
{
    public class UserMap : BaseModelMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Map(x => x.Email);
            Map(x => x.Salt);
            Map(x => x.Hash);
        }
    }
}
