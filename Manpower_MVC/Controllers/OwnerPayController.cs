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
        public ActionResult Index()
        {
            if (Session["isLogin"] == null)
            {
                TempData["loginMsg"] = 1;
                return RedirectToAction("Login", "User");
            }
            else if ((Session["isAdmin"] != null) && ((bool)Session["isAdmin"]))
            {
                return View();
            }
            TempData["Msg"] = 1;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult getViewPay()
        {
            return Json(getViewOwnerPayment(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getViewPayWork(int? id)
        {
            if (id == null)
            {
                return Json(new List<OwnerBuilding>());
            }
            return Json(getViewOwnerPayWork(id.Value), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getWorkCate()
        {
            return Json(getAllWorkCate(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult getOwner()
        {
            return Json(getAllOwner(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(OwnerPayment payment, List<OwnerPayWork> payWork)
        {
            db.OwnerPayment.Add(payment);
            db.SaveChanges();
            for (int i = 0; i < payWork.Count; i++)
            {
                if (i != 0)
                {
                    OwnerPayWork _payWork = new OwnerPayWork()
                    {
                        PayID = payment.ID,
                        SalaryDay = payWork[i].SalaryDay,
                        OvertimeHr = payWork[i].OvertimeHr,
                        OverOvertimeHr = payWork[i].OverOvertimeHr,
                        WorkCareID = payWork[i].WorkCareID,
                        Remark = payWork[i].Remark
                    };
                    db.OwnerPayWork.Add(_payWork);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return Json(getOneOwnerPay(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(OwnerPayment payment)
        {
            OwnerPayment _payment = getOneOwnerPay(payment.ID);
            _payment.PayID = payment.PayID;
            _payment.OwnerID = payment.OwnerID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
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
        [HttpPost]
        public ActionResult CreatePayWork(OwnerPayWork payWork)
        {
            db.OwnerPayWork.Add(payWork);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditPayWork(int id)
        {
            return Json(getOneOwnerPayWork(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditPayWork(OwnerPayWork payWork)
        {
            OwnerPayWork _payWork = getOneOwnerPayWork(payWork.ID);
            _payWork.SalaryDay = payWork.SalaryDay;
            _payWork.OvertimeHr = payWork.OvertimeHr;
            _payWork.OverOvertimeHr = payWork.OverOvertimeHr;
            _payWork.WorkCareID = payWork.WorkCareID;
            _payWork.Remark = payWork.Remark;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePayWork(int id)
        {
            OwnerPayWork _payWork = getOneOwnerPayWork(id);
            db.OwnerPayWork.Remove(_payWork);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}