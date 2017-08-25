using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;


namespace Manpower_MVC.Controllers
{
    public class UserController : ApiController
    {
        public ActionResult Login()
        {
            return View();
        }
        // GET: User
        [HttpPost]
        public ActionResult Login(string acc, string pwd)
        {
            User Get = (from p in db.User where p.Account == acc && p.Password == pwd select p).FirstOrDefault();
            Session["isLogin"] = null;
            Session["name"] = null;
            if (Get != null)
            {
                Session["isLogin"] = Get.ID;
                Session["name"] = Get.Name;
                return RedirectToAction("Index", "Home");
            }
            TempData["loginMsg"] = 0;
            return View();
        }
        public ActionResult Logout()
        {
            Session["isLogin"] = null;
            Session["name"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}