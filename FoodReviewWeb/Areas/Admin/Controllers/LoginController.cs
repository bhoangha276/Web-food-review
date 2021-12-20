using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodReviewWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FoodReviewWeb.Areas.Admin.Data.DTO.User user, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                FoodReviewWeb.Models.Framework.FoodReviewEntities1 db = new Models.Framework.FoodReviewEntities1();
                var _user = db.Account.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

                if (_user != null)
                {
                    //Thành công
                    //Lưu trạng thái đăng nhập
                    Session["user"] = _user;
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    string rs = Request.QueryString["ReturnUrl"];
                    if(ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
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