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
    public class OwnerPayController : ApiController
    {
        //for OwnerPayment
        /*************************************************************************************************/
        public ActionResult Index()
        {
            return View(getViewOwnerPayment());
        }
        public ActionResult CreatePayment()
        {
            ViewBag.owner = getAllOwner();
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
            ViewBag.owner = getAllOwner();
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
                Session["workId"] = id.ToString();
                ViewBag.cate = getAllWorkCate();
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePayWork(OwnerPayWork payWork)
        {
            OwnerPayWork _payWork = new OwnerPayWork()
            {
                OverOvertimeHr = payWork.OverOvertimeHr,
                OvertimeHr = payWork.OvertimeHr,
                PayID = Convert.ToInt32(Session["workId"].ToString()),
                SalaryDay = payWork.SalaryDay,
                WorkCareID = payWork.WorkCareID,
                Remark = payWork.Remark
            };
            db.OwnerPayWork.Add(_payWork);
            db.SaveChanges();
            return RedirectToAction("ListPayWork", new { id = _payWork.PayID });
        }
        public ActionResult EditPayWork(int? id)
        {
            if (id > 0)
            {
                ViewBag.payId = id;
                ViewBag.cate = getAllWorkCate();
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
            _payWork.Remark = payWork.Remark;
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
    }
}