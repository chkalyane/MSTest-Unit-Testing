using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace YesMed.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //private readonly IUserService _userService;
        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        // GET: Admin/User
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/User/Index.cshtml");
        }
    }
}