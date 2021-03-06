﻿using System;
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
            return View(getAllWorkCate());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkCategory care)
        {
            db.WorkCategory.Add(care);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(getOneWorkCate(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkCategory care)
        {
            WorkCategory _care = getOneWorkCate(id);
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