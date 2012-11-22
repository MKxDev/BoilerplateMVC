using NHibernate;
using NHibernateBase.Data.NHibernate;
using StructureMap.Configuration.DSL;

namespace NHibernateBase.IoC
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
