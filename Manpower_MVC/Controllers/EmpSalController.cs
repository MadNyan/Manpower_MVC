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
        public ActionResult EmpSalDetail(int? year, int? month)
        {
            if (year != null && month != null)
            {
                return View(getViewEmpSalDetail(year.Value, month.Value));
            }
            return RedirectToAction("Index");
        }
    }
}