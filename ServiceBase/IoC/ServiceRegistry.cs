using StructureMap.Configuration.DSL;
using ServiceBase.Services.Interfaces;

namespace ServiceBase.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(x => x.AddAllTypesOf<IBaseRepositoryService>());
        }
    }
}
