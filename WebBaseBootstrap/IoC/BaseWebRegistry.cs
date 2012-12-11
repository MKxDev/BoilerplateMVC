using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace WebBaseBootstrap.IoC
{
    public class BaseWebRegistry : Registry
    {
        public BaseWebRegistry()
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