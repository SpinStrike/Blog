using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.AppLogic.Service;
using Blog.AppLogic.Service.Implementation;
using Blog.AdditionalInfrastructure;
using Blog.Data.EF;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BlogDIContainer _container = new BlogDIContainer();
            _container.RegisterBlogTypes();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new BlogControllerFactory(_container));
        }
    }
}
