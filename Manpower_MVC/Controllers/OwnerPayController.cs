using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.ViewModels;

namespace Manpower_MVC.Controllers
{
    public class OwnerPayController : Controller
    {
        private ManpowerDBEntities db = new ManpowerDBEntities();
        //for OwnerPayment
        /*************************************************************************************************/
        public ActionResult Index()
        {
            return View(getViewOwnerPayment());
        }
        public ActionResult CreatePayment()
        {
            ViewBag.owner = from p in db.Owner orderby p.ID descending select p;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePayment(OwnerPayment payment)
        {
            db.OwnerPayment.Add(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditPayment(int id)
        {
            ViewBag.owner = from p in db.Owner orderby p.ID descending select p;
            return View(getOneOwnerPay(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPayment(int id, OwnerPayment payment)
        {
            OwnerPayment _payment = getOneOwnerPay(id);
            _payment.PayID = payment.PayID;
            _payment.OwnerID = payment.OwnerID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePayment(int id)
        {
            foreach (OwnerPayWork payWork in getSomeOwnerPayWork(id))
            {
                db.OwnerPayWork.Remove(payWork);
            }
            db.OwnerPayment.Remove(getOneOwnerPay(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //for OwnerPayWork
        /*************************************************************************************************/
        public ActionResult ListPayWork(int? id)
        {
            if (id > 0)
            {
                ViewBag.payId = id;
                return View(getViewOwnerPayWork(id.Value));
            }
            return RedirectToAction("Index");
        }
        public ActionResult CreatePayWork(int? id)
        {
            if (id > 0)
            {
                ViewBag.payId = id;
                OwnerPayWork _payWork = new OwnerPayWork();
                _payWork.PayID = id.Value;
                ViewBag.cate = from p in db.WorkCategory orderby p.ID descending select p;
                return View(_payWork);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePayWork(OwnerPayWork payWork)
        {
            db.OwnerPayWork.Add(payWork);
            db.SaveChanges();
            return RedirectToAction("ListPayWork", new { id = payWork.PayID });
        }
        public ActionResult EditPayWork(int? id)
        {
            if (id > 0)
            {
                ViewBag.payId = id;
                ViewBag.cate = from p in db.WorkCategory orderby p.ID descending select p;
                return View(getOneOwnerPayWork(id.Value));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPayWork(int id, OwnerPayWork payWork)
        {
            OwnerPayWork _payWork = getOneOwnerPayWork(id);
            _payWork.SalaryDay = payWork.SalaryDay;
            _payWork.OvertimeHr = payWork.OvertimeHr;
            _payWork.OverOvertimeHr = payWork.OverOvertimeHr;
            _payWork.WorkCareID = payWork.WorkCareID;
            db.SaveChanges();
            return RedirectToAction("ListPayWork", new { id = _payWork.PayID });
        }
        public ActionResult DeletePayWork(int id)
        {
            OwnerPayWork _payWork = getOneOwnerPayWork(id);
            db.OwnerPayWork.Remove(_payWork);
            db.SaveChanges();
            return RedirectToAction("ListPayWork", new { id = _payWork.PayID });
        }
        //select方法
        /*************************************************************************************************/
        public OwnerPayment getOneOwnerPay(int id)
        {
            var Get = from p in db.OwnerPayment where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        public List<OwnerPayWork> getSomeOwnerPayWork(int id)
        {
            var Get = from p in db.OwnerPayWork where p.PayID == id select p;
            return Get.ToList();
        }
        public OwnerPayWork getOneOwnerPayWork(int id)
        {
            var Get = from p in db.OwnerPayWork where p.ID == id select p;
            return Get.FirstOrDefault();
        }
        public List<ViewOwnerPayment> getViewOwnerPayment()
        {
            var Get = from p in db.OwnerPayment
                      join e in db.Owner on p.OwnerID equals e.ID
                      select new ViewOwnerPayment
                      {
                          ID = p.ID,
                          PayID = p.PayID,
                          OwnerName = e.OwnerName
                      };
            return Get.ToList();
        }
        public List<ViewOwnerPayWork> getViewOwnerPayWork(int payId)
        {
            var Get = from p in db.OwnerPayWork
                      join e in db.WorkCategory on p.WorkCareID equals e.ID
                      where p.PayID == payId
                      select new ViewOwnerPayWork
                      {
                          ID = p.ID,
                          SalaryDay = p.SalaryDay,
                          OvertimeHr = p.OvertimeHr,
                          OverOvertimeHr = p.OverOvertimeHr,
                          WorkCareName = e.WorkCareName,
                          Salary = e.Salary,
                          OvertimeSal = e.OvertimeSal,
                          OverOvertimeSal = e.OverOvertimeSal
                      };
            return Get.ToList();
        }
    }
}