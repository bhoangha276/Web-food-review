using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodReviewWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Review()
        {
            ViewBag.Message = "Your Review page.";

            var lst = new List<Models.Framework.Post>();
            Models.Framework.FoodReviewEntities1 db = new Models.Framework.FoodReviewEntities1();
            lst = db.Post.OrderByDescending(x => x.ID).ToList();

            return View(lst);
        }

        public ActionResult Recipe()
        {
            ViewBag.Message = "Your Cooking Recipe page.";

            return View();
        }

        public ActionResult Intro()
        {
            ViewBag.Message = "Your More About Us page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }
    }
}