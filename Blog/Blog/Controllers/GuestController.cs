using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.AppLogic.Service;
using Blog.Models;

namespace Blog.Controllers
{
    public class GuestController : Controller
    {
        public GuestController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GuestReview()
        {
            var rmw = new ReviewModelWrapper()
            {
                MainContent = _service.GetAll().OrderByDescending(r => r.PublishingDate).ToList(),
                Voting = null
            };

            return View(rmw);
        }

        [HttpPost]
        public ActionResult AddReview(Review Review)
        {

            if (!ModelState.IsValid)
            {
                var rmw = new ReviewModelWrapper()
                {
                    MainContent = _service.GetAll().OrderByDescending(r => r.PublishingDate).ToList(),
                };
                return View("GuestReview", rmw);
            }

            else
            {
                _service.Create(Review.ReviewText, Review.Author, Review.Time);
                return RedirectToAction("GuestReview");
            }
        }

        private IReviewService _service;
    }
}