using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.AppLogic.Service.Implementation;
using Blog.AppLogic.Service;

namespace Blog.AdditionalInfrastructure
{
    public class BlogControllerFactory : DefaultControllerFactory
    {
        public BlogControllerFactory(BlogDIContainer diContainer)
        {
            _container = diContainer;
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controllerNamespace = ((IEnumerable<string>)requestContext.RouteData.DataTokens["Namespaces"]).First();

            var controllerType = Type.GetType(string.Concat(controllerNamespace,".",controllerName, "Controller"));

            IController controller = _container.Resolve(controllerType) as Controller;

            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);

            var contextService = _container.Resolve(typeof(IDbContextService)) as DbContextService;

            contextService.Dispose();
        }

        private BlogDIContainer _container;
    }
}