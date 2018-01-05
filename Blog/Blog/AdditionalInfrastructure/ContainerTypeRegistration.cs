using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Controllers;
using Blog.AppLogic.Service.Implementation;
using Blog.AppLogic.Service;

namespace Blog.AdditionalInfrastructure
{
    public static class ContainerTypeRegistration
    {
        public static void RegisterBlogTypes(this BlogDIContainer container)
        {
            container.RegisterSingletonInstance<IDbContextService, DbContextService>(new DbContextService());
            container.Register<IArticleService, ArticleService>();
            container.Register<IReviewService, ReviewService>();
            container.Register<IQuestionnaireInteractionService, QuestionnaireInteractionService>();
            container.Register<IQuestionnaireService, QuestionnaireService>();
            container.Register<IReviewService, ReviewService>();
            container.Register<IVotingService, VotingService>();

            container.Register<HomeController, HomeController>();
            container.Register<QuestionnaireController, QuestionnaireController>();
            container.Register<GuestController, GuestController>();
        }
    }
}