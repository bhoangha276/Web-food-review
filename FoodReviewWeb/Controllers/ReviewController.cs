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
            Session["idPost"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var cmt = new List<Comment>();
                cmt = db.Comment.Where(x => x.PostID == id).OrderByDescending(x => x.ID).ToList();

                Session["idCmt"] = cmt;
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            Comment(id);
            return View(post);
        }

        public PartialViewResult Comment(string id)
        {
            var lst = new List<Comment>();
            lst = db.Comment.Where(x=>x.PostID==id).OrderByDescending(x => x.ID).ToList();

            return PartialView(lst);
        }

        public PartialViewResult CreateComment()
        {
            
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateComment([Bind(Include = "ID,PostID,UserID,Contents,CreateAt")] Comment cmt)
        {
            if (ModelState.IsValid)
            {
                db.Comment.Add(cmt);
                db.SaveChanges();
            }


            return PartialView(cmt);
        }
    }
}