using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.ViewModels;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class printMonthSalController : ApiController
    {
        public ActionResult Index()
        {
            DateTime _date = DateTime.Now;
            ViewBag.year = _date.Year;
            ViewBag.month = _date.Month;
            return View(getViewMonthSal(_date.Year, _date.Month));
        }
        [HttpPost]
        public ActionResult Index(DateTime? date)
        {
            if (date != null)
            {
                ViewBag.year = date.Value.Year;
                ViewBag.month = date.Value.Month;
                return View(getViewMonthSal(date.Value.Year, date.Value.Month));
            }
            DateTime _date = DateTime.Now;
            ViewBag.year = _date.Year;
            ViewBag.month = _date.Month;
            return View(getViewMonthSal(_date.Year, _date.Month));
        }
    }
}