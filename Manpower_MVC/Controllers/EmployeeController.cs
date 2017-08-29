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

        public ActionResult getEmp()
        {
            return Json(getAllEmp(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getWorkCate()
        {
            return Json(getAllWorkCate(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getViewEmpIns(int? id)
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
        public ActionResult Create(Employee emp, List<EmpInsurance> ins, int[] workCateID)
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
            for (int i=0; i<ins.Count; i++)
            {
                if (i != 0)
                {
                    EmpInsurance _empIns = new EmpInsurance()
                    {
                        EmpID = _emp.ID,
                        InsID = ins[i].InsID,
                        Price = ins[i].Price,
                        Remark = ins[i].Remark
                    };
                    db.EmpInsurance.Add(_empIns);
                }
            }
            createWorkRight(workCateID, _emp.ID);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewEmp viewEmp = new ViewEmp()
            {
                Emp = getOneEmp(id),
                WorkRight = getAllWorkRight(id)
            };
            return Json(viewEmp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp, int[] workCateID)
        {
            foreach (WorkRight _workRight in getAllWorkRight(emp.ID))
            {
                db.WorkRight.Remove(_workRight);
            }
            Employee _emp = getOneEmp(emp.ID);
            _emp.EmpID = emp.EmpID;
            _emp.EmpName = emp.EmpName;
            _emp.Tel = emp.Tel;
            _emp.Phone = emp.Phone;
            _emp.ConPerson = emp.ConPerson;
            _emp.ConPersonTel = emp.ConPersonTel;
            createWorkRight(workCateID, emp.ID);
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
            foreach (WorkRight _workRight in getAllWorkRight(id))
            {
                db.WorkRight.Remove(_workRight);
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
            db.EmpInsurance.Add(empIns);
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

        public void createWorkRight(int[] workCateID, int empID)
        {
            foreach (int _workCateID in workCateID)
            {
                if (_workCateID != 0)
                {
                    WorkRight _workRight = new WorkRight()
                    {
                        EmpID = empID,
                        WorkCateID = _workCateID
                    };
                    db.WorkRight.Add(_workRight);
                }
                db.SaveChanges();
            }
        }
    }
}