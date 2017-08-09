using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class HomeController : ApiController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult a01()
        {
            return View();
        }

        public ActionResult a02()
        {
            return View();
        }

        public ActionResult a03()
        {
            return View();
        }

        public ActionResult Emp()
        {
            return Json(getAllEmp(),JsonRequestBehavior.AllowGet);
        }
    }
}