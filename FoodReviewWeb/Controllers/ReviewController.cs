using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodReviewWeb.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            ViewBag.Message = "Your Review page.";

            var lst = new List<Models.Framework.Post>();
            Models.Framework.FoodReviewEntities1 db = new Models.Framework.FoodReviewEntities1();
            lst = db.Post.OrderByDescending(x => x.ID).ToList();

            return View(lst);
        }
        public ActionResult Detail()
        {
            return View();
        }
    }
}