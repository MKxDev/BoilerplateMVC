using ServiceBase.Services;
using ServiceBase.Services.Interfaces;
using StructureMap.Configuration.DSL;

namespace ServiceBase.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IBaseRepositoryService>()
                .HybridHttpOrThreadLocalScoped();

            For<BaseRepositoryService>()
                .HybridHttpOrThreadLocalScoped();

            Scan(x =>
                {
                    x.AssemblyContainingType<BaseRepositoryService>();
                    x.WithDefaultConventions();
                });
        }
    }
}
