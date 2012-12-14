using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using StructureMap.Configuration.DSL;
using RepositoryBase.Repositories.Interfaces;
using ServiceBase.Services.Interfaces;
using ServiceBase.Services;

namespace ServiceBase.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(x => {
                x.AddAllTypesOf<IBaseRepositoryService>();
            });
        }
    }
}
