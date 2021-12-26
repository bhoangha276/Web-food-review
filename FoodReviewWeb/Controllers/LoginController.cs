using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodReviewWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FoodReviewWeb.Areas.Admin.Data.DTO.User user)
        {
            if (ModelState.IsValid)
            {
                FoodReviewWeb.Models.Framework.FoodReviewEntities1 db = new Models.Framework.FoodReviewEntities1();
                var _user = db.Account.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

                if (_user != null)
                {
                    Session["id"] = _user.ID;
                    Session["name"] = _user.Name;
                    Session["email"] = _user.Email;
                    Session["number"] = _user.Number;
                    Session["avatar"] = _user.Avatar;
                    Session["intro"] = _user.Intro;
                    //Thành công
                    //Lưu trạng thái đăng nhập
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("Logged", "Home", new { id = _user.ID });
                }
                else
                {
                    //Thất bại
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }

            }
            return View(user);
        }

        public ActionResult Logout()
        {
            // Hủy cookie đã lưu dưới Client
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}