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
            Session["isAdmin"] = null;
            Session["name"] = null;
            if (Get != null)
            {
                Session["isLogin"] = Get.ID;
                Session["name"] = Get.Name;
                Session["isAdmin"] = Get.isAdmin.ToString();
                return RedirectToAction("Index", "Home");
            }
            TempData["loginMsg"] = 0;
            return View();
        }
        public ActionResult Logout()
        {
            Session["isLogin"] = null;
            Session["isAdmin"] = null;
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
            user.isAdmin = 0;
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            if (Session["isAdmin"] != null)
            {
                if (Session["isAdmin"].Equals("1"))
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult getUser()
        {
            List<User> Get = (from p in db.User select p).ToList();
            return Json(Get, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            User Get = (from p in db.User where p.ID == id select p).FirstOrDefault();
            return Json(Get, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            User _user = (from p in db.User where p.ID == user.ID select p).FirstOrDefault();
            _user.Name = user.Name;
            _user.isAdmin = user.isAdmin;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.User.Remove((from p in db.User where p.ID == id select p).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}