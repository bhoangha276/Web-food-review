using FoodReviewWeb.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodReviewWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private FoodReviewEntities1 db = new FoodReviewEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logged(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
    }
}