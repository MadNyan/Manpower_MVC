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
        // GET: WorkList
        public ActionResult Index()
        {
            return View(getAllViewWorkList());
        }
        public ActionResult CreateWorkList()
        {
            ViewBag.owner = getAllOwner();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorkList(WorkList list)
        {
            WorkList _list = new WorkList()
            {
                BuildName = list.BuildName,
                ConPerson = list.ConPerson,
                CreateDate = DateTime.Now,
                OwnerID = list.OwnerID,
                SerialNum = list.SerialNum,
                SingleNum = list.SingleNum
            };
            db.WorkList.Add(_list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditWorkList(int id)
        {
            ViewBag.owner = getAllOwner();
            return View(getOneWorkList(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorkList(int id, WorkList list)
        {
            WorkList _list = getOneWorkList(id);
            _list.BuildName = list.BuildName;
            _list.ConPerson = list.ConPerson;
            _list.OwnerID = list.OwnerID;
            _list.SerialNum = list.SerialNum;
            _list.SingleNum = list.SingleNum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteWorkList(int id)
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
        public ActionResult ListWorker(int? listId)
        {
            if(listId > 0)
            {
                ViewBag.listId = listId.Value;
                return View(getSomeViewWorker(listId.Value));
            }
            return RedirectToAction("Index");
        }
        public ActionResult CreateWorker(int? listId)
        {
            if (listId > 0)
            {
                Session["listId"] = listId.ToString();
                ViewBag.serialNum = getOneWorkList(listId.Value).SerialNum;
                ViewBag.emp = getAllEmp();
                ViewBag.cate = getAllWorkCate();
                ViewBag.listId = listId.Value;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWorker(Worker worker)
        {
            Worker _worker = new Worker()
            {
                EmpID = worker.EmpID,
                ListID = Convert.ToInt32(Session["listId"].ToString()),
                OverOvertimeHr = worker.OverOvertimeHr,
                OvertimeHr = worker.OvertimeHr,
                Remark = worker.Remark,
                SalaryDay = worker.SalaryDay,
                WorkCareID = worker.WorkCareID
            };
            Session["listId"] = null;
            db.Worker.Add(_worker);
            db.SaveChanges();
            return RedirectToAction("ListWorker", new {ListId = _worker.ListID });
        }
        public ActionResult EditWorker(int id)
        {
            Worker _worker = getOneWorker(id);
            ViewBag.serialNum = getOneWorkList(_worker.ListID).SerialNum;
            ViewBag.emp = getAllEmp();
            ViewBag.cate = getAllWorkCate();
            ViewBag.listId = _worker.ListID;
            return View(_worker);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction("ListWorker", new { ListId = _worker.ListID });
        }
        public ActionResult DeleteWorker(int id)
        {
            Worker _worker = getOneWorker(id);
            db.Worker.Remove(_worker);
            db.SaveChanges();
            return RedirectToAction("ListWorker", new { ListId = _worker.ListID });
        }
    }
}