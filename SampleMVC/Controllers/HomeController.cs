using SampleMVC.Models;
using SampleMVC.Services.Interface;
using SampleMVC.Services.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVC.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService userService;

        public HomeController(IUserService Service)
        {
            this.userService = Service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            User u = this.userService.GetUser(user.uid, user.pwd);
            if (u.id > 0)
            {
                Session["User"] = u;
                return this.RedirectToAction("Dashboard", "Default");
            }

            return View(user);

        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("User");
            Session.Abandon();
            return this.RedirectToAction("Index", "Home");

        }
    }
}