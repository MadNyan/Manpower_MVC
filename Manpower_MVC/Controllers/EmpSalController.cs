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
    public class EmpSalController : ApiController
    {
        // GET: EmpSal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getViewEmpSal()
        {
            return Json(getAllViewEmpSal(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getEmpSalDetail(int? id, int? year, int? month)
        {
            if (id != null && year != null && month != null)
            {
                return Json(getViewEmpSalDetail(id.Value, year.Value, month.Value), JsonRequestBehavior.AllowGet);
            }
            return Json(new List<ViewEmpSalDetail>(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Print(DateTime? date)
        {
            if (date != null)
            {
                ViewBag.year = date.Value.Year;
                ViewBag.month = date.Value.Month;
                return View(getViewPrintMonthSal(date.Value.Year, date.Value.Month));
            }
            return View(new ViewPrintMonthSal());
        }
    }
}