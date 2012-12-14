using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using RepositoryBase.NHibernate.Mappings;
using RepositoryBase.Models;
using System.Data.SQLite;

namespace RepositoryBase.NHibernate
{
    public class FluentConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                    .Database(SQLiteConfiguration
                        .Standard
                        .ConnectionString(c => c.FromAppSetting("applicationConnectionString"))
                    )
                    .Mappings(m => {
                        m.FluentMappings.AddFromAssemblyOf<BaseModelMap<BaseModel>>();
                    })
                    .BuildSessionFactory();
        }
    }
}
