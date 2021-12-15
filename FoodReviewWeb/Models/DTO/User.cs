using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodReviewWeb.Models.DTO
{
    public class User
    {
        [Required(ErrorMessage = "Chưa nhập tài khoản!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Chưa nhập tài khoản!")]
        [MinLength(3, ErrorMessage = "Mật khẩu tối thiểu 3 kí tự!")]
        public string Password { get; set; }
    }
}