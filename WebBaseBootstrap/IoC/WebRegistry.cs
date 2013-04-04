using System.Web.Mvc;
using ServiceBase.Services;
using StructureMap;
using StructureMap.Configuration.DSL;
using WebBaseBootstrap.Services.Interfaces;
using ServiceBase.Services.Interfaces;

namespace WebBaseBootstrap.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<IBaseWebService>();
            });

            ObjectFactory.Initialize(x =>
            {
                x.SetAllProperties(p =>
                {
                    p.NameMatches(n => n.EndsWith("Service"));
                });
            });

            ControllerBuilder.Current.SetControllerFactory(new BaseControllerFactory());
        }
    }
}