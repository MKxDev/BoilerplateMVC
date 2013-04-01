using StructureMap.Configuration.DSL;
using ServiceBase.Services.Interfaces;

namespace ServiceBase.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IBaseRepositoryService>()
                .HybridHttpOrThreadLocalScoped();

            Scan(x =>
                {
                    x.AssemblyContainingType<IBaseRepositoryService>();
                });
        }
    }
}
