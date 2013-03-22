using System;
using DomainModels;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using RepositoryBase.NHibernate.Mappings;


namespace RepositoryBase.NHibernate
{
    public class FluentConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
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
            var dbPath = AppDomain.CurrentDomain.BaseDirectory +
                         @"bin\App_Data\BoilerplateMVC.db3";

            var config = Fluently.Configure()
                .Database(SQLiteConfiguration
                .Standard
                .UsingFile(dbPath))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<BaseModelMap<BaseModel>>()
                )
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
