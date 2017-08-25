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
    public class WorkListController : ApiController
    {
        public ActionResult Index()
        {
            if (Session["isLogin"] == null)
            {
                TempData["loginMsg"] = 1;
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult getViewWorkList()
        {
            return Json(getAllViewWorkList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getViewWorker(int? id)
        {
            if (id == null)
            {
                return Json(new List<ViewWorker>());
            }
            return Json(getSomeViewWorker(id.Value), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getEmp()
        {
            return Json(getAllEmp(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getWorkRight(int id)
        {
            return Json(getEmpWorkRight(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getBuilding()
        {
            return Json(getAllOwnerBuilding(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(WorkList list, List<Worker> worker)
        {
            WorkList _list = new WorkList()
            {
                BuildingID = list.BuildingID,
                CreateDate = DateTime.Now,
                SerialNum = list.SerialNum,
                SingleNum = list.SingleNum
            };
            db.WorkList.Add(_list);
            db.SaveChanges();
            for (int i = 0; i < worker.Count; i++)
            {
                if (i != 0)
                {
                    Worker _worker = new Worker()
                    {
                        ListID = _list.ID,
                        EmpID = worker[i].EmpID,
                        SalaryDay = worker[i].SalaryDay,
                        OvertimeHr = worker[i].OvertimeHr,
                        OverOvertimeHr = worker[i].OverOvertimeHr,
                        Remark = worker[i].Remark,
                        WorkCareID = worker[i].WorkCareID
                    };
                    db.Worker.Add(_worker);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return Json(getOneWorkList(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(WorkList list)
        {
            WorkList _list = getOneWorkList(list.ID);
            _list.BuildingID = list.BuildingID;
            _list.SerialNum = list.SerialNum;
            _list.SingleNum = list.SingleNum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            WorkList _list = getOneWorkList(id);
            List<Worker> _someWorker = getSomeWorker(id);
            foreach (Worker _worker in _someWorker)
            {
                db.Worker.Remove(_worker);
            }
            db.WorkList.Remove(_list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /****************************************************************************************************/
        
        [HttpPost]
        public ActionResult CreateWorker(Worker worker)
        {
            db.Worker.Add(worker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditWorker(int id)
        {
            return Json(getOneWorker(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditWorker(int id, Worker worker)
        {
            Worker _worker = getOneWorker(id);
            _worker.EmpID = worker.EmpID;
            _worker.OverOvertimeHr = worker.OverOvertimeHr;
            _worker.OvertimeHr = worker.OvertimeHr;
            _worker.Remark = worker.Remark;
            _worker.SalaryDay = worker.SalaryDay;
            _worker.WorkCareID = worker.WorkCareID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteWorker(int id)
        {
            Worker _worker = getOneWorker(id);
            db.Worker.Remove(_worker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}