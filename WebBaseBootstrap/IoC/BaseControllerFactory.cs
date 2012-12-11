using System;
using System.Web.Mvc;
using StructureMap;

namespace WebBaseBootstrap.IoC
{
    public class BaseControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null || controllerType == null)
            {
                return null;
            }

            return (Controller)ObjectFactory.GetInstance(controllerType);
        }
    }
}