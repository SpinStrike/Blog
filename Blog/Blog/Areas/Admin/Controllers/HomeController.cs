using System.Web.Mvc;
using Blog.Models;
using Blog.Areas.Admin.Filters;

namespace Blog.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [AdminAccess]
        public ActionResult Index()
        {
            var mw = new ModelWrapper<string>();

            return View(mw);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NotAllowAccess()
        {
            var mw = new ModelWrapper<string>();

            return View(mw);
        }
    }
}