using NHibernate;
using RepositoryBase.NHibernate;
using StructureMap.Configuration.DSL;
using RepositoryBase.Repositories.Interfaces;
using RepositoryBase.Repositories;

namespace ServiceBase.IoC
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            var sessionFactory = FluentConfiguration.CreateSessionFactory();

            For<ISessionFactory>()
                .Singleton()
                .Use(sessionFactory);

            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x => x.GetInstance<ISessionFactory>().OpenSession());

            Scan(x =>
            {
                x.AddAllTypesOf<IBaseRepository>();
            });
        }
    }
}
