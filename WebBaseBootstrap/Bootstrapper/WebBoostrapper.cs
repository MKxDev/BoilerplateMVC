using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using ServiceBase.IoC;
using WebBaseBootstrap.IoC;

namespace WebBaseBootstrap.Bootstrapper
{
    public class WebBoostrapper
    {
        public virtual void StartUp()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new RepositoryRegistry());
                x.AddRegistry(new ServiceRegistry());
                x.AddRegistry(new WebRegistry());
            });
        }
    }
}