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
    public class EmployeeController : ApiController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getEmp()
        {
            return Json(getAllEmp(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getEmpIns(int? id)
        {
            if (id == null)
            {
                return Json(new List<ViewEmpIns>());
            }
            return Json(getAllViewEmpIns(id.Value), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getInsCate()
        {
            return Json(getAllInsCate(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Employee emp, List<EmpInsurance> ins)
        {
            Employee _emp = new Employee();
            _emp.EmpID = emp.EmpID;
            _emp.EmpName = emp.EmpName;
            _emp.Tel = emp.Tel;
            _emp.Phone = emp.Phone;
            _emp.ConPerson = emp.ConPerson;
            _emp.ConPersonTel = emp.ConPersonTel;
            _emp.CreateDate = DateTime.Now;
            db.Employee.Add(_emp);
            db.SaveChanges();
            foreach (EmpInsurance _ins in ins)
            {
                EmpInsurance _empIns = new EmpInsurance()
                {
                    EmpID = _emp.ID,
                    InsID = _ins.InsID,
                    Price = _ins.Price,
                    Remark = _ins.Remark
                };
                db.EmpInsurance.Add(_empIns);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return Json(getOneEmp(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee _emp = getOneEmp(emp.ID);
            _emp.EmpID = emp.EmpID;
            _emp.EmpName = emp.EmpName;
            _emp.Tel = emp.Tel;
            _emp.Phone = emp.Phone;
            _emp.ConPerson = emp.ConPerson;
            _emp.ConPersonTel = emp.ConPersonTel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.Employee.Remove(getOneEmp(id));
            foreach(EmpInsurance _empIns in getAllEmpIns(id))
            {
                db.EmpInsurance.Remove(_empIns);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Print()
        {
            return View(getAllEmp());
        }
        // ViewEmpIns
        /*************************************************************************************************/

        [HttpPost]
        public ActionResult CreateEmpIns(EmpInsurance empIns)
        {
            EmpInsurance _empIns = new EmpInsurance() {
                EmpID = empIns.EmpID,
                InsID = empIns.InsID,
                Price = empIns.Price,
                Remark = empIns.Remark
            };
            db.EmpInsurance.Add(_empIns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditEmpIns(int id)
        {
            return Json(getOneEmpIns(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditEmpIns(EmpInsurance empIns)
        {
            EmpInsurance _empIns = getOneEmpIns(empIns.ID);
            _empIns.InsID = empIns.InsID;
            _empIns.Price = empIns.Price;
            _empIns.Remark = empIns.Remark;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmpIns(int id)
        {
            EmpInsurance _empIns = getOneEmpIns(id);
            db.EmpInsurance.Remove(_empIns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}