using NHibernate;
using RepositoryBase.NHibernate;
using RepositoryBase.Repositories;
using RepositoryContracts.Repositories;
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

            Scan(x =>
                {
                    x.TheCallingAssembly();

                    x.AddAllTypesOf<IBaseRepository>();
                    x.AddAllTypesOf<BaseRepository>();

                    x.WithDefaultConventions();
                });
        }
    }
}
