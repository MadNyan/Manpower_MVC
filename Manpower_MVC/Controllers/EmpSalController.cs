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
            return View(getAllViewEmpSal());
        }
        public ActionResult EmpSalDetail(int? id, int? year, int? month)
        {
            if (id != null && year != null && month != null)
            {
                List<ViewEmpSalDetail> details = getViewEmpSalDetail(id.Value, year.Value, month.Value);
                int posPrice = 0, negPrice = 0;
                foreach(ViewEmpSalDetail detail in details)
                {
                    if (detail.PosOrNeg.Equals("減項"))
                    {
                        negPrice += detail.Price;
                    }
                    else
                    {
                        posPrice += detail.Price;
                    }
                }
                ViewBag.pos = posPrice.ToString();
                ViewBag.neg = negPrice.ToString();
                ViewBag.sum = (posPrice - negPrice).ToString();
                return View(details);
            }
            return RedirectToAction("Index");
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