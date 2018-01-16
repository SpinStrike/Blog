using System.Linq;
using System.Web.Mvc;
using Blog.Models;
using Blog.Models.ExtensionsMethods;
using Blog.AppLogic.Service;
using Blog.Areas.Admin.Filters;

namespace Blog.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleController(IArticleService articleService)
        {
            _aService = articleService;
        }

        [AdminAccess]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Article article)
        {
           var amw = new ArticleModelWrapper()
           {
               MainContent = _aService.GetAllTags()
               .Select(x => x.Text)
               .ToList()
           };

            if (ModelState.IsValid)
            {
                if (article.Tags != null && article.Tags.Count() != 0)
                {
                    var tags = article.Tags.SplitToTags().ToList();
                    _aService.Create(article.Title, article.Text, article.PublishingTime, tags);

                    ViewBag.SuccessString = "Статья успешно добавлена";
                }
            }

            return View(amw);
        }

        private IArticleService _aService;
    }
}