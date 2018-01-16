using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.AppLogic.Service;
using Blog.AppLogic.DTO;
using Blog.Models;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class QuestionnaireController : Controller
    {
        public QuestionnaireController(IQuestionnaireService questionnaireService, 
            IQuestionnaireInteractionService questionnaireInteractionService)
        {
            _qService = questionnaireService;
            _qInteractionService = questionnaireInteractionService;
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult QuestionnaireHandler()
        {      
            if (HttpContext.Request.Form.Keys.Count == 0)
            {
                var mw = new ModelWrapper<QuestionnaireDto>()
                {
                    MainContent = _qService.GetAll().First(),
                    Voting = null
                };

                return View(mw);
            }
            else
            {
                var list = new List<Guid>();
                foreach(string element in HttpContext.Request.Form.Keys)
                {
                    list.Add(Guid.Parse(HttpContext.Request.Form[element]));  
                }

                var idQuestionnaire = list.ElementAt(0);
                list.RemoveAt(0);

                _qInteractionService.AddCompletedQuestionnaire(idQuestionnaire, list);

                var mw = new ModelWrapper<QuestionnaireStatisticDto>()
                {
                    MainContent = _qInteractionService.QuestionnaireStatistic(idQuestionnaire),
                     Voting = null
                };

                return View("Results", mw);
            }
        }

        private IQuestionnaireService _qService;
        private IQuestionnaireInteractionService _qInteractionService;
    }
}