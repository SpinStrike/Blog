using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Areas.Admin.Filters
{
    public class AdminAccessAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated ||
                !filterContext.HttpContext.User.IsInRole("Administrator"))
            {
                    filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary {
                                { "action", "NotAllowAccess" },
                                { "controller", "Home" }
                    });
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
    }
}

  
