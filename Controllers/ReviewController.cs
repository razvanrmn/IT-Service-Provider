using MultiLanguage;
using MultiLanguage.Models;
using ProiectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectFinal.Controllers
{
    public class ReviewController : Controller
    {
        private MainDbContext context = new MainDbContext();
        DateTimeOffset dateTimeNow = DateTimeOffset.Now;
        public ActionResult Index()
        {
            Singleton.Instance.writeMessage("Review index button clicked created at: " + dateTimeNow.LocalDateTime);
            return View(context.Reviews.ToList());
        }

        [HttpGet]
        public ActionResult Create() 
        { 
            ReviewModel review= new ReviewModel();
            Singleton.Instance.writeMessage("Create review succesfuly at: " + dateTimeNow.LocalDateTime);
            return View(review);
        }

        [HttpPost]
        public ActionResult Create(ReviewModel review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Sort() 
        {
            var res = from r in context.Reviews
                      orderby r.NumberOfStars
                      select r;
            return View(res);
        }
    }
}