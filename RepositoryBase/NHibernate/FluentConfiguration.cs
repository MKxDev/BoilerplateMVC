using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using RepositoryBase.NHibernate.Mappings;
using RepositoryBase.Models;


namespace RepositoryBase.NHibernate
{
    public class FluentConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var config = GetPgConfig();

            // Execute update
            // TODO: Make this optional
            var schemaUpdate = new SchemaUpdate(config);
            schemaUpdate.Execute(false, true);

            return config.BuildSessionFactory();
        }

        public static Configuration GetSqliteConfig()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration
                    .Standard
                    .ConnectionString(c => c.FromAppSetting("boilerplaceSqliteConnectionString")))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<BaseModelMap<BaseModel>>();
                })
                .BuildConfiguration();
        }

        public static Configuration GetPgConfig()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration
                    .PostgreSQL82
                    .ConnectionString(c => c.FromAppSetting("boilerplacePgConnectionString")))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<BaseModelMap<BaseModel>>();
                })
                .BuildConfiguration();
        }
    }
}
