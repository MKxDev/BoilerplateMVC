using NHibernate;
using ServiceBase.Data.NHibernate;
using StructureMap.Configuration.DSL;

namespace ServiceBase.IoC
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            var sessionFactory = FluentConfiguration.CreateSessionFactory();

            For<ISessionFactory>()
                .Singleton()
                .Use(sessionFactory);

            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x => x.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}
