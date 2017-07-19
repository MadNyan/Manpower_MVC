using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class printMonthWorkController : ApiController
    {
        // GET: printMonthWork
        public ActionResult Index()
        {
            DateTime _date = DateTime.Now;
            ViewBag.year = _date.Year;
            ViewBag.month = _date.Month;
            return View(getViewMonthWork(_date.Year, _date.Month));
        }
        [HttpPost]
        public ActionResult Index(DateTime? date)
        {
            if (date != null)
            {
                ViewBag.year = date.Value.Year;
                ViewBag.month = date.Value.Month;
                return View(getViewMonthWork(date.Value.Year, date.Value.Month));
            }
            return Index();
        }
        public ActionResult Print(int year, int month)
        {
            ViewBag.year = year;
            ViewBag.month = month;
            return View(getViewMonthWork(year, month));
        }
    }
}