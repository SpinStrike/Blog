using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.AppLogic.Service;
using Blog.AppLogic.DTO;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IArticleService articleService, IVotingService votingService)
        {
             _aService = articleService;
             _vService = votingService;
        }

        [HttpGet]
        public ActionResult Index(Guid? idTag = null)
        {
            IEnumerable<ArticleDto> articles;
            if (idTag == null)
            {
                articles = _aService.GetAll().OrderByDescending(a => a.PublishingDate).ToList();
            }
            else
            {
                articles = _aService.GetAllByTag(idTag.Value).OrderByDescending(a => a.PublishingDate).ToList();
            }

            ((List<ArticleDto>)articles).ForEach(x => {
                if (x.Text.Count() > 200)
                    x.Text = $"{x.Text.Substring(0, 199)}...";
            });

            var mw = new ModelWrapper<IEnumerable<ArticleDto>>()
            {
                MainContent = articles,
                Voting = _vService.GetRandom()
            };

            return View(mw);
        }

        [HttpGet]
        public ActionResult ReadMore(Guid? id)
        {
            var mw = new ModelWrapper<ArticleDto>()
            {
                MainContent = _aService.FindById(id.Value),
                Voting = _vService.GetRandom()
            };
            return View(mw);
        }


        public async Task<PartialViewResult> Vote(Guid idVoting, Guid? option)
        {       
             var task = await Task.Factory.StartNew<VotingDto>(() =>
             {
                 if (option != null)
                 {
                     _vService.Vote(idVoting, option.Value);
                 }

                 var voting = _vService.FindById(idVoting);
                 voting.Options = voting.Options.OrderByDescending(x => x.Count).ToList();

                 return voting;
             });

             return PartialView("VotingResults", task);
        }

        private IArticleService _aService;
        private IVotingService _vService;
    }
}