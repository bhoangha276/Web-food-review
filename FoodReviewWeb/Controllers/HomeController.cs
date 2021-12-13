using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodReviewWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Review()
        {
            ViewBag.Message = "Your Review page.";

            return View();
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