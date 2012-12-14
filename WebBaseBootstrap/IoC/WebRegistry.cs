using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace WebBaseBootstrap.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
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