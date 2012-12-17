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
            //var config = GetPgConfig();
            var config = GetSqliteConfig();

            var sessionFactory = config.BuildSessionFactory();

            // Execute update
            // TODO: Make this optional - check for a flag or something
            var schemaUpdate = new SchemaUpdate(config);
            schemaUpdate.Execute(false, true);

            return sessionFactory;
        }

        public static Configuration GetSqliteConfig()
        {
            var config = Fluently.Configure()
                .Database(SQLiteConfiguration
                    .Standard
                    .ConnectionString(c => c.FromAppSetting("boilerplaceSqliteConnectionString")))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<BaseModelMap<BaseModel>>();
                })
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetProperty("current_session_context_class", "call");
                    cfg.SetProperty("connection.release_mode", "on_close");
                })
                .BuildConfiguration();

            return config;
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
