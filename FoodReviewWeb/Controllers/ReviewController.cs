using FoodReviewWeb.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodReviewWeb.Controllers
{
    public class ReviewController : Controller
    {
        private FoodReviewEntities1 db = new FoodReviewEntities1();

        // GET: Review
        public ActionResult Index()
        {
            ViewBag.Message = "Your Review page.";

            var lst = new List<Post>();
            lst = db.Post.OrderByDescending(x => x.ID).ToList();

            return View(lst);
        }
        public ActionResult Detail(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            //var lst = new List<Comment>();
            //lst = db.Comment.Where(x=>x.PostID == id).OrderByDescending(x => x.ID).ToList();
            return View(post);
        }
    }
}