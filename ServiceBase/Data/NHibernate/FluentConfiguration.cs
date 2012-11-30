using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace ServiceBase.Data.NHibernate
{
    public class FluentConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                    .Database(PostgreSQLConfiguration // TODO: Change flavor here!
                        .Standard
                        .ConnectionString(c => c.FromAppSetting("YOUR_CONNECTION_STRING_ELEMENT"))
                    )
                    .Mappings(m => {
                        // m.FluentMappings.AddFromAssemblyOf<>() // TODO: Add your mappings
                    })
                    .BuildSessionFactory();
        }
    }
}
