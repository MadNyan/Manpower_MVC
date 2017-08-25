using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class WorkCareController : ApiController
    {
        // GET: WorkCategory
        public ActionResult Index()
        {
            if (Session["isLogin"] == null)
            {
                TempData["loginMsg"] = 1;
                return RedirectToAction("Login", "User");
            }
            return View();
        }

        public ActionResult getWorkCate()
        {
            return Json(getAllWorkCate(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(WorkCategory care)
        {
            db.WorkCategory.Add(care);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return Json(getOneWorkCate(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(WorkCategory care)
        {
            WorkCategory _care = getOneWorkCate(care.ID);
            _care.WorkCareID = care.WorkCareID;
            _care.WorkCareName = care.WorkCareName;
            _care.Salary = care.Salary;
            _care.OvertimeSal = care.OvertimeSal;
            _care.OverOvertimeSal = care.OverOvertimeSal;
            _care.Remark = care.Remark;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.WorkCategory.Remove(getOneWorkCate(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Print()
        {
            return View(getAllWorkCate());
        }
    }
}