using NHibernate;
using RepositoryBase.NHibernate;
using RepositoryBase.Repositories;
using RepositoryBase.Repositories.Interfaces;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

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

            For<BaseRepository>()
                .HybridHttpOrThreadLocalScoped();

            For<IBaseRepository>()
                .HybridHttpOrThreadLocalScoped();

            Scan(x =>
                {
                    x.AssemblyContainingType<BaseRepository>();
                    x.WithDefaultConventions();
                });
        }
    }
}
